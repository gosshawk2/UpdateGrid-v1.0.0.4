Public Class ImportfromCSV
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'BROWSE for CSV file:
        Dim dlg As New OpenFileDialog
        Dim Filename As String
        Dim REsult As DialogResult

        REsult = dlg.ShowDialog()
        If REsult = Windows.Forms.DialogResult.OK Then
            Filename = dlg.FileName
        End If
        txtFilename.Text = Filename

    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        'IMPORT:
        Dim myDAL As New SQLBuilderdal


    End Sub
End Class