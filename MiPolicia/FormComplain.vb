Imports System.Data.SqlClient

Public Class FormComplain
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conn As New SqlConnection
        If conn.State = ConnectionState.Closed Then
            conn.ConnectionString = ("Server=lenovo-pc\sqlexpress;Database=mipolicia;User Id=lenovo-pc\user;Password=Passw0rd01;Integrated Security=True")
        End If

        Try
            conn.Open()
            Dim sqlquery As String = "INSERT INTO denuncia (den_num, den_nom, den_fecha, den_lugar, den_motivo, den_telefono, den_apprela, den_direccion) VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8)"
            Dim adapter As New SqlDataAdapter
            Dim parameter As New SqlParameter
            Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
            With command.Parameters
                .Add(New SqlParameter("@param1", "Hello"))
                .Add(New SqlParameter("@param2", "Hello"))
                .Add(New SqlParameter("@param3", "2017-01-01"))
                .Add(New SqlParameter("@param4", "Hello"))
                .Add(New SqlParameter("@param5", "Hello"))
                .Add(New SqlParameter("@param6", 1))
                .Add(New SqlParameter("@param7", "Hello"))
                .Add(New SqlParameter("@param8", "Hello"))
            End With

            command.Connection = conn
            adapter.SelectCommand = command
            command.ExecuteReader()
            conn.Close()
        Catch ex As Exception
            Console.Write(ex)
        End Try
    End Sub
End Class
