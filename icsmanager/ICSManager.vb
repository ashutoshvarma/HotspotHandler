Public Class ICSManager

    Sub New()

    End Sub


    Private Function EnableDisableICS(ByVal sPublicConnectionName As String, ByVal sPrivateConnectionName As String, ByVal bEnable As Boolean) As Boolean

        Try

            Dim bFound As Boolean
            Dim oNetSharingManager, oConnectionCollection, oItem, EveryConnection, objNCProps
            oNetSharingManager = CreateObject("HNetCfg.HNetShare.1")
            oConnectionCollection = oNetSharingManager.EnumEveryConnection

            For Each oItem In oConnectionCollection
                EveryConnection = oNetSharingManager.INetSharingConfigurationForINetConnection(oItem)
                objNCProps = oNetSharingManager.NetConnectionProps(oItem)
                If objNCProps.name = sPrivateConnectionName Then
                    bFound = True





                    If bEnable Then
                        EveryConnection.EnableSharing(1)
                    Else
                        EveryConnection.DisableSharing()
                    End If
                End If
            Next


            oConnectionCollection = oNetSharingManager.EnumEveryConnection

            For Each oItem In oConnectionCollection
                EveryConnection = oNetSharingManager.INetSharingConfigurationForINetConnection(oItem)
                objNCProps = oNetSharingManager.NetConnectionProps(oItem)
                If objNCProps.name = sPublicConnectionName Then
                    bFound = True





                    If bEnable Then
                        EveryConnection.EnableSharing(0)
                    Else
                        EveryConnection.DisableSharing()
                    End If
                End If
            Next


            Return True

        Catch ex As Exception
            Return False
        End Try



    End Function


End Class
