Public Class ViewSelectedRow
    Dim ctrl As New DGComponentManager
    Private Sub ViewSelectedRow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'BuildFormView()
    End Sub

    Sub BuildFormView()
        ctrl.AddFormControls(Me, "Label", "lblRecordID", "Record ID:", "1", 6, 6, 20, 0, Nothing, "", "")
        ctrl.AddFormControls(Me, "Textbox", "txtRecordID", "Record ID:", "1", 30, 6, 40, 0, Nothing, "", "")
    End Sub

    Sub PopulateForm(ByRef RowContent As Object)
        Dim ColumnName As String
        Dim ColumnText As String
        Dim txtWidth As Integer
        Dim LastPos As Integer
        Dim arr() As String

        For i As Integer = 0 To RowContent.length - 1
            If RowContent(i) = Nothing Then
                Continue For
            End If
            arr = Split(RowContent(i), "=")
            ColumnName = arr(0)
            ColumnText = arr(1)
            txtWidth = 80
            If Len(ColumnText) > 20 Then
                txtWidth = 100 + (Len(ColumnText) * 10)
            End If
            ctrl.AddFormControls(Me, "Label", "lblRecordID", ColumnName & ":", CStr(i + 1), 5 + (i * 105), 6, txtWidth, 0, Nothing, "", "")
            ctrl.AddFormControls(Me, "Textbox_r", "txtRecordID", ColumnText, CStr(i + 1), 5 + (i * 105), 36, txtWidth, 0, Nothing, "", "")
            LastPos = i
        Next
        ctrl.AddFormControls(Me, "button", "btnClose", "Close", CStr(LastPos + 1), 5 + (LastPos * 105) + txtWidth + 10, 17, 50, 40, Nothing, "", "")
    End Sub
End Class