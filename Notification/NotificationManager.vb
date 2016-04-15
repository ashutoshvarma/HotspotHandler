Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.Windows.Forms




Public Module NotificationManager

    'Timers
    Dim WithEvents tmrAnimation As Timer
    Dim WithEvents tmrDelay As Timer

    'Control where the message will be displayed.
    Dim WithEvents displaycontrol As New ExtendedControl()

    'Some property variables.
    Dim GlowColor As Color = Color.Blue
    Dim alphaval As Single = 0
    Dim incr As Single = 0.1
    Dim isVisible As Boolean = False
    Dim textSize As SizeF
    Dim msg As String = ""
    Dim prnt As Windows.Forms.Control

#Region "eventhandlers"

    'Handles the paint event of the display control.
    Private Sub Control_Paint(ByVal sender As Object, ByVal pe As PaintEventArgs) Handles displaycontrol.Paint
        'This BITMAP object will hold the appearance of the notification dialog.
        'Why paint in bitmap? because we will set its opacity and paint it on the control later with a specified alpha.
        Dim img As New Bitmap(displaycontrol.Width, displaycontrol.Height)
        Dim e As Graphics = Graphics.FromImage(img)

        'Set smoothing.
        e.SmoothingMode = SmoothingMode.AntiAlias

        'Prepare drawing tools.
        Dim bru As Brush = New SolidBrush(Color.FromArgb(50, GlowColor))
        Dim pn As Pen = New Pen(bru, 6)
        Dim gp As New GraphicsPath()

        'Make connecting edges rounded.
        pn.LineJoin = LineJoin.Round

        'Draw borders
        'Outmost, 50 alpha
        gp.AddRectangle(New Rectangle(3, 3, displaycontrol.Width - 10, displaycontrol.Height - 10))
        e.DrawPath(pn, gp)

        'level 3, A bit solid
        gp.Reset()
        gp.AddRectangle(New Rectangle(5, 5, displaycontrol.Width - 14, displaycontrol.Height - 14))
        e.DrawPath(pn, gp)

        'level 2, a bit more solid
        gp.Reset()
        gp.AddRectangle(New Rectangle(7, 7, displaycontrol.Width - 18, displaycontrol.Height - 18))
        e.DrawPath(pn, gp)

        'level 1, more solidness
        gp.Reset()
        gp.AddRectangle(New Rectangle(9, 9, displaycontrol.Width - 22, displaycontrol.Height - 22))
        e.DrawPath(pn, gp)

        'Draw Content Rectangle.
        gp.Reset()
        bru = New SolidBrush(Color.FromArgb(7, 7, 7))
        pn = New Pen(bru, 5)
        pn.LineJoin = LineJoin.Round
        gp.AddRectangle(New Rectangle(8, 8, displaycontrol.Width - 20, displaycontrol.Height - 20))
        e.DrawPath(pn, gp)
        e.FillRectangle(bru, New Rectangle(9, 9, displaycontrol.Width - 21, displaycontrol.Height - 21))

        'Set COLORMATRIX (RGBAw).
        'Matrix [3,3] will be the Alpha. Alpha is in float, 0(transparent) - 1(opaque).
        Dim cma As New ColorMatrix()
        cma.Matrix33 = alphaval
        Dim imga As New ImageAttributes()
        imga.SetColorMatrix(cma)

        'Draw the notification message..
        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        e.DrawString(msg, prnt.Font, New SolidBrush(Color.FromArgb(247, 247, 247)), New Rectangle(9, 9, displaycontrol.Width - 21, displaycontrol.Height - 21), sf)

        'Now, draw the content on the control.
        pe.Graphics.DrawImage(img, New Rectangle(0, 0, displaycontrol.Width, displaycontrol.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imga)

        'Free the memory.
        cma = Nothing
        sf.Dispose()
        imga.Dispose()
        e.Dispose()
        img.Dispose()
        bru.Dispose()
        pn.Dispose()
        gp.Dispose()

    End Sub

    'Handles the window animation.
    Private Sub tmr_tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrAnimation.Tick
        If (incr > 0) Then
            If (alphaval < 1) Then
                If (alphaval + incr <= 1) Then
                    alphaval += incr
                    displaycontrol.Refresh()
                Else
                    alphaval = 1
                    displaycontrol.Refresh()
                    tmrAnimation.Enabled = False
                    tmrDelay.Enabled = True
                End If
            End If
        Else
            If (alphaval > 0) Then
                If (alphaval + incr >= 0) Then
                    alphaval += incr
                    displaycontrol.Refresh()
                Else
                    alphaval = 0
                    tmrAnimation.Enabled = False
                    tmrAnimation.Dispose()
                    tmrDelay.Dispose()
                    displaycontrol.Dispose()
                    incr = 0.1
                    isVisible = False
                End If
            End If
        End If
    End Sub

    'handles the delay.
    Private Sub tmrDelay_tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrDelay.Tick
        incr = -0.1
        tmrAnimation.Enabled = True
        tmrDelay.Enabled = False
    End Sub

#End Region

#Region "Function"

    ''' <summary>
    ''' Shows the message to the user.
    ''' </summary>
    ''' <param name="Message">The message to show.</param>
    ''' <param name="glw">Color of the glow.</param>
    ''' <param name="delay">The time before the message to disappear, in Milliseconds.</param>
    ''' <remarks></remarks>
    Public Sub Show(ByRef Parent As Control, ByVal Message As String, ByVal glw As Color, ByVal delay As Integer)
        If Not (isVisible) Then
            isVisible = True
            prnt = Parent
            msg = Message
            'Set up notification window.
            displaycontrol = New ExtendedControl()
            displaycontrol.IsTransparent = True

            'Measure message
            textSize = displaycontrol.CreateGraphics().MeasureString(Message, Parent.Font)
            displaycontrol.Height = 25 + textSize.Height
            displaycontrol.Width = 35 + textSize.Width
            If (textSize.Width > Parent.Width - 100) Then
                displaycontrol.Width = Parent.Width - 100
                Dim hf As Integer = CInt(textSize.Width) / (Parent.Width - 100)
                displaycontrol.Height += (textSize.Height * hf)
            End If

            'Position control in parent
            displaycontrol.Left = (Parent.Width - displaycontrol.Width) / 2
            displaycontrol.Top = (Parent.Height - displaycontrol.Height) - 50
            Parent.Controls.Add(displaycontrol)
            displaycontrol.BringToFront()
            GlowColor = glw

            'Set up animation
            tmrAnimation = New Timer()
            tmrAnimation.Interval = 15
            tmrAnimation.Enabled = True

            tmrDelay = New Timer()
            tmrDelay.Interval = delay
        Else
            tmrDelay.Stop()
            tmrDelay.Start()
        End If
    End Sub

#End Region

End Module
