Imports System.Data.SqlClient

Public Class FormDeposit
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim conn As New SqlConnection(My.Settings.basededatos)
        Dim conn As New SqlConnection
        If conn.State = ConnectionState.Closed Then
            conn.ConnectionString = ("Server=I-SHOOL-LAP\SQLEXPRESS;Database=mipolicia;Integrated Security=True")
        End If


        Try
            conn.Open()
            Dim sqlquery As String = "SELECT corr_marca MARCA,corr_modelo MODELO,corr_ubica UBICACION,corr_fecha FECHA_ARRASTRE FROM corralones Where corr_placa = @buscar;"

            Dim adapter As New SqlDataAdapter
            Dim parameter As New SqlParameter
            Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
            Dim ds As New DataSet

            Dim buscar As String

            buscar = TextBox1.Text


            With command.Parameters
                .Add(New SqlParameter("@buscar", buscar))
            End With
            command.Connection = conn
            adapter.SelectCommand = command





            adapter.Fill(ds, "corralones")
            DataGridViewLista.DataSource = ds.Tables("corralones")
            DataGridViewLista.Show()


            conn.Close()
        Catch ex As Exception
            Console.Write(ex)
        End Try
    End Sub
End Class
