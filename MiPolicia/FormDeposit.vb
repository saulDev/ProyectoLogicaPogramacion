Imports System.Data.SqlClient

Public Class FormDeposit
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conn As New SqlConnection
        If conn.State = ConnectionState.Closed Then
            conn.ConnectionString = ("Server=DESKTOP-TO0SORL;Database=mipolicia;Integrated Security=True")
        End If

        Try
            conn.Open()
            Dim sqlquery As String = "SELECT * FROM corralones Where corr_placa = @placa;"

            Dim data As SqlDataReader
            Dim adapter As New SqlDataAdapter
            Dim parameter As New SqlParameter
            Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
            With command.Parameters
                .Add(New SqlParameter("@user", "Hello"))
            End With
            command.Connection = conn
            adapter.SelectCommand = command
            data = command.ExecuteReader()
            While data.Read
                If data.HasRows = True Then
                    MsgBox(data(2).ToString)
                Else
                    MsgBox("Error")
                End If
            End While
            conn.Close()
        Catch ex As Exception
            Console.Write(ex)
        End Try
    End Sub
End Class
