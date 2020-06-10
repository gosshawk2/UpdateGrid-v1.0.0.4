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
        Dim lblXPos As Integer
        Dim lblYpos As Integer
        Dim lblWidth As Integer
        Dim txtXPos As Integer
        Dim txtYpos As Integer
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
            lblXPos = 400
            lblYpos = 18 + (i * 30)
            lblWidth = 60
            txtXPos = 530
            txtYpos = 15 + (i * 30)
            txtWidth = 100
            If Len(ColumnText) > 20 Then
                txtWidth = 250
            End If
            ctrl.AddFormControls(Me, "Label", "lblRecordID", ColumnName & ":", CStr(i + 1), lblXPos, lblYpos, lblWidth, 20, Nothing, "", "")
            ctrl.AddFormControls(Me, "Textbox_r", "txtRecordID", ColumnText, CStr(i + 1), txtXPos, txtYpos, txtWidth, 20, Nothing, "", "")
            LastPos = i
        Next
        ctrl.AddFormControls(Me, "button", "btnClose", "Close", CStr(LastPos + 1), txtXPos, txtYpos + 30, 50, 40, Nothing, "", "")
    End Sub
End Class