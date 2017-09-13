Imports System.Data.SqlClient

Public Class FormSearch
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conn As New SqlConnection
        If conn.State = ConnectionState.Closed Then
            conn.ConnectionString = ("Server=Lenovo-pc\SQLEXPRESS;Database=mipolicia;Integrated Security=True")
            'conn.ConnectionString = ("Server=I-SHOOL-LAP\SQLEXPRESS;Database=mipolicia;Integrated Security=True")
        End If


        Try
            conn.Open()
            Dim sqlquery As String = "SELECT cua_num COLONIA, cua_x LAT, cua_y LONG, cua_jefe JEFE  FROM cuadrantes Where cua_num = @colonia;"

            Dim adapter As New SqlDataAdapter
            Dim parameter As New SqlParameter
            Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
            Dim ds As New DataSet

            Dim buscar As String

            buscar = TextBox1.Text


            With command.Parameters
                .Add(New SqlParameter("@colonia", buscar))
            End With
            command.Connection = conn
            adapter.SelectCommand = command





            adapter.Fill(ds, "cuadrantes")
            DataGridView1.DataSource = ds.Tables("cuadrantes")
            DataGridView1.Show()


            conn.Close()
        Catch ex As Exception
            Console.Write(ex)
        End Try
    End Sub

End Class
