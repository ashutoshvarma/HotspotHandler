'An object from the Control class
'Created for transparency support.

Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Forms
Imports System.Drawing

Public Class ExtendedControl
    Inherits Control

#Region "Ctor"

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

#End Region

#Region "Properties"

    Dim m_isTransparent As Boolean = False

    ''' <summary>
    ''' Gets or sets the transparency of the control.
    ''' Transparency means you can see the controls beneath this control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    <Description("Gets or sets the 'real' transparency of the control.")> _
    Public Property IsTransparent() As Boolean
        Get
            Return m_isTransparent
        End Get
        Set(ByVal value As Boolean)
            m_isTransparent = value
            If (value = True) Then
                Me.BackColor = Color.Transparent
            End If
            Invalidate()
        End Set
    End Property

#End Region

#Region "Overrides"

    'Override the default paint background event.
    'Append here the true transparency effect.
    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)

        MyBase.OnPaintBackground(e)

        If (IsTransparent) Then
            If Not (Parent Is Nothing) Then
                Dim myIndex As Integer = Parent.Controls.GetChildIndex(Me)
                For i As Integer = Parent.Controls.Count - 1 To myIndex + 1 Step -1
                    Dim ctrl As Control = Parent.Controls(i)
                    If (ctrl.Bounds.IntersectsWith(Bounds)) Then
                        If (ctrl.Visible) Then
                            Dim bmp As Bitmap = New Bitmap(ctrl.Width, ctrl.Height)
                            ctrl.DrawToBitmap(bmp, ctrl.ClientRectangle)
                            e.Graphics.TranslateTransform(ctrl.Left - Left(), ctrl.Top - Top)
                            e.Graphics.DrawImage(bmp, Point.Empty)
                            e.Graphics.TranslateTransform(Left() - ctrl.Left, Top - ctrl.Top)
                            bmp.Dispose()
                        End If
                    End If
                Next
            End If

        End If

    End Sub

#End Region

End Class