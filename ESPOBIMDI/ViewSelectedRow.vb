Public Class ViewSelectedRow
    Dim ctrl As New UpdateGrid.DGComponentManager
    Private Sub ViewSelectedRow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuildFormView()
    End Sub

    Sub BuildFormView()
        ctrl.AddFormControls(Me, "Label", "lblRecordID", "Record ID:", "1", 6, 6, 20, 0, Nothing, "", "")
        ctrl.AddFormControls(Me, "Textbox", "txtRecordID", "Record ID:", "1", 30, 6, 40, 0, Nothing, "", "")
    End Sub
End Class