﻿Imports KremerControlsWin32

Public Class MachinePond_Manual

    Private Sub InitControls()

        'User level check
        For Each IoCtl As Control In Me.Controls
            If TypeOf IoCtl Is KremerIoField Then CType(IoCtl, KremerIoField).UserInfo = HmiUserInfo
            If TypeOf IoCtl Is KremerTextField Then CType(IoCtl, KremerTextField).UserInfo = HmiUserInfo
        Next
    End Sub


    'Connecting the kremer connector
    Private Sub MachinePond_Manual_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged
        If Not Me.Parent Is Nothing Then

            InitControls()

            GetControlLabel(Me.Controls)

            KrConnector.PLC = frmMain.CX1020
            KrConnector.VarCollector = Me.VarCollector
            KrConnector.Connect()
        Else
            KrConnector.Disconnect()
        End If
    End Sub


    Private Sub btn_Settings_Click(sender As Object, e As EventArgs) Handles btn_Settings.Click
        frmMain.SubFormChange(frmMain.SubMachinePond_Settings)
    End Sub

    Private Sub Btn_Overview_Click(sender As Object, e As EventArgs) Handles Btn_Overview.Click
        frmMain.SubFormChange(frmMain.SubMachinePond_Overview)
    End Sub
End Class
