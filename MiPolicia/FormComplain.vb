Imports System.Data.SqlClient

Public Class FormComplain
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
            Dim sqlquery As String = "INSERT INTO denuncia (den_nom, den_fecha, den_lugar, den_motivo, den_telefono, den_apprela, den_direccion) VALUES (@param2, @param3, @param4, @param5, @param6, @param7, @param8)"
            Dim adapter As New SqlDataAdapter
            Dim parameter As New SqlParameter
            Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
            With command.Parameters
                Dim fecha As Date = DateTimePicker1.Value

                .Add(New SqlParameter("@param2", TextBox1.Text()))
                .Add(New SqlParameter("@param3", fecha))
                .Add(New SqlParameter("@param4", TextBox2.Text()))
                .Add(New SqlParameter("@param5", TextBox3.Text()))
                .Add(New SqlParameter("@param6", TextBox4.Text()))
                .Add(New SqlParameter("@param7", TextBox5.Text()))
                .Add(New SqlParameter("@param8", TextBox6.Text()))
            End With

            command.Connection = conn
            adapter.SelectCommand = command
            command.ExecuteReader()
            conn.Close()

            Me.GetLastID()
            Me.ClearTextBoxes()

        Catch ex As Exception
            Console.Write(ex)
        End Try
    End Sub

    Private Sub GetLastID()
        Dim conn As New SqlConnection
        If conn.State = ConnectionState.Closed Then
            conn.ConnectionString = ("Server=DESKTOP-TO0SORL;Database=mipolicia;Integrated Security=True")
        End If

        Try
            conn.Open()
            Dim sqlquery As String = "SELECT MAX(id_den) AS LastId FROM denuncia"
            Dim data As SqlDataReader
            Dim adapter As New SqlDataAdapter
            Dim command As SqlCommand = New SqlCommand(sqlquery, conn)

            command.Connection = conn
            adapter.SelectCommand = command
            data = command.ExecuteReader()

            While data.Read
                If data.HasRows = True Then
                    Console.Write(data(0).ToString)
                    Me.ShowMessage("Tu Folio es", "FOLIO: FP-" + data(0).ToString())
                Else
                    MsgBox("Error")
                End If
            End While


            conn.Close()
        Catch ex As Exception
            Console.Write(ex)
        End Try
    End Sub

    Private Sub ClearTextBoxes()
        TextBox1.ResetText()
        TextBox2.ResetText()
        TextBox3.ResetText()
        TextBox4.ResetText()
        TextBox5.ResetText()
        TextBox6.ResetText()
    End Sub

    Private Sub ShowMessage(title As String, msg As String)
        Dim response As MsgBoxResult
        response = MsgBox(msg, MsgBoxStyle.ApplicationModal, title)
    End Sub
End Class
