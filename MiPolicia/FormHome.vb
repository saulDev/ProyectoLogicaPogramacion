Imports Twilio
Imports Twilio.Rest.Api.V2010.Account
Imports Twilio.Types

Public Class FormHome
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ShowMessage("Emergencia", "¿Desea realizar la llamada de emergencia?")
    End Sub

    Private Sub ShowMessage(title As String, msg As String)
        Dim response As MsgBoxResult
        response = MsgBox(msg, MsgBoxStyle.YesNo, title)

        If response = MsgBoxResult.Yes Then
            FormEmergency.Show()
            MakeCall()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormDeposit.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FormComplain.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FormSearch.Show()
    End Sub

    Sub MakeCall()
        ' Find your Account Sid and Auth Token at twilio.com/console
        Const accountSid = "AC6d905082575610645a49bc67d1811b76"
        Const authToken = "eccb4c9bc862fb7ce4a83a1ed415c7d1"
        TwilioClient.Init(accountSid, authToken)

        Dim toNumber = New PhoneNumber("+525543183156")
        Dim message = CallResource.Create(
            toNumber, from:=New PhoneNumber("+525543183156"),
            url:=New Uri("http://demo.twilio.com/docs/voice.xml"))

        Console.WriteLine(message.Sid)
    End Sub
End Class
