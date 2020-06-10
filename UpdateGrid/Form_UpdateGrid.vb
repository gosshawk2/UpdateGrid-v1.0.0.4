Public Class UpdateGrid
    Dim GlobalParms As New ESPOParms.Framework
    Dim GlobalSession As New ESPOParms.Session
    Dim DAL As New UpdateGridDAL
    Private _FirstEntry As String
    Private _LastEntry As String
    Public Shared DBVersion As String
    Public Shared ThemeSelection As Integer

    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOParms.Framework)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub

    Property FirstEntry As String
        Get
            Return _FirstEntry
        End Get
        Set(value As String)
            _FirstEntry = value
        End Set
    End Property

    Property LastEntry As String
        Get
            Return _LastEntry
        End Get
        Set(value As String)
            _LastEntry = value
        End Set
    End Property

    Private Sub UpdateGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        If ThemeSelection = 0 Then
            Me.BackColor = SystemColors.Control
            dgvUpdateGrid.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromWin32(RGB(245, 255, 245))
            dgvUpdateGrid.DefaultCellStyle.BackColor = ColorTranslator.FromWin32(RGB(235, 255, 235)) 'LIGHT GREEN
        Else
            Me.BackColor = SystemColors.ControlDark
            dgvUpdateGrid.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromWin32(RGB(245, 255, 245))
            dgvUpdateGrid.DefaultCellStyle.BackColor = ColorTranslator.FromWin32(RGB(235, 255, 235)) 'LIGHT GREEN
        End If
        dgvUpdateGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvUpdateGrid.AllowUserToOrderColumns = True
        dgvUpdateGrid.AllowUserToResizeColumns = True
        'dgvUpdateGrid.AllowUserToAddRows = True
        'dgvUpdateGrid.AllowUserToDeleteRows = True
        'dgvUpdateGrid.MultiSelect = True
        'dgvUpdateGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUpdateGrid.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom

        'FieldAttributes.ClearSelectedAttributesList()

        For Each c As Control In Controls
            AddHandler c.MouseClick, AddressOf ClickHandler
        Next
    End Sub

    Sub PopulateForm()
        Dim dt As DataTable
        Dim dgvCheckUpdate As New DataGridViewCheckBoxColumn()

        dgvCheckUpdate.HeaderText = "UPDATED"
        dgvCheckUpdate.Name = "UPDATED"

        Try
            dgvUpdateGrid.Columns.Clear()

            If DBVersion = "MYSQL" Then
                dt = DAL.GetAPEMaster_MYSQL("")
            Else
                dt = DAL.GetAPEMaster(GlobalSession.ConnectString, "")
            End If
            If dt IsNot Nothing Then
                dgvUpdateGrid.DataSource = dt
                stsUpdateGridLabel1.Text = "Records: " & CStr(dt.Rows.Count)
            End If
            dgvUpdateGrid.Columns.Add(dgvCheckUpdate)
            dgvUpdateGrid.Columns.Add("UPDATED2", "UPDATED2")
            Lock_RecordColumn()
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Error in PopulateForm(): " & ex.Message)
        End Try
        Cursor = Cursors.Default

    End Sub

    Sub Lock_RecordColumn()
        dgvUpdateGrid.Columns("Record ID").ReadOnly = True
        dgvUpdateGrid.Columns("Profit").ReadOnly = True
        dgvUpdateGrid.Columns("Margin%").ReadOnly = True
    End Sub

    Private Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        'Label24.Text = String.Format("Clicked ""{0}"" with the {1} mouse button.", sender.name, e.Button.ToString.ToLower)
        Select Case e.Button
            Case MouseButtons.Left
                Me.BringToFront()

        End Select
    End Sub

    Private Function UpdateDBfromGrid()
        Dim Percentage As Double = 0.0
        Dim Message As String
        Dim watch As Stopwatch = Stopwatch.StartNew()
        Dim RecordID As Integer

        stsUpdateGridLabel1.Text = "Update Grid..."

        For i As Integer = 0 To dgvUpdateGrid.Rows.Count - 1
            If Trim(dgvUpdateGrid.Rows(i).Cells("Record ID").Value) = Nothing Then
                RecordID = 0
            ElseIf Trim(dgvUpdateGrid.Rows(i).Cells("Record ID").Value.ToString) = "" Then
                RecordID = 0
            Else
                RecordID = Trim(dgvUpdateGrid.Rows(i).Cells("Record ID").Value)
            End If

            If Trim(dgvUpdateGrid.Rows(i).Cells("S21 Item Code").Value) <> Nothing Then
                DAL.UpdateAPEMaster(
                        GlobalSession.ConnectString,
                        RecordID,
                        Trim(dgvUpdateGrid.Rows(i).Cells("S21 Item Code").Value.ToString),
                        Trim(dgvUpdateGrid.Rows(i).Cells("Item Description").Value.ToString),
                        Trim(dgvUpdateGrid.Rows(i).Cells("Selling Price").Value),
                        Trim(dgvUpdateGrid.Rows(i).Cells("Current Price").Value)
                    )
            End If

            Message = ""
            'Percentage = (i / dgvUpdateGrid.Rows.Count - 1) * 100
            'Message = "Updating Grid: " & CStr(Percentage) & "%"
            'stsUpdateGridLabel1.Text = Message
        Next i
        watch.Stop()
        stsUpdateGridLabel1.Text = "Completed in " & " (" & CStr(watch.Elapsed.TotalSeconds) & " seconds)"
    End Function

    Private Function UpdateDBfromGridDan()
        Dim Percentage As Double = 0.0
        Dim Message As String
        Dim watch As Stopwatch = Stopwatch.StartNew()
        Dim RecordID As Integer
        Dim strS21ItemCode As String
        Dim strItemDescription As String
        Dim strSellingPrice As String
        Dim strCurrentPrice As String

        stsUpdateGridLabel1.Text = "Update Grid..."

        For i As Integer = 0 To dgvUpdateGrid.Rows.Count - 1
            If dgvUpdateGrid.Rows(i).Cells("UPDATED").Value = True Then
                If Not IsDBNull(dgvUpdateGrid.Rows(i).Cells("S21 Item Code").Value) Then
                    If dgvUpdateGrid.Rows(i).Cells("S21 Item Code").Value = Nothing Then
                        strS21ItemCode = ""
                    Else
                        strS21ItemCode = Trim(dgvUpdateGrid.Rows(i).Cells("S21 Item Code").Value.ToString)
                    End If
                Else
                    strS21ItemCode = ""
                End If
                If Not IsDBNull(dgvUpdateGrid.Rows(i).Cells("Item Description").Value) Then
                    If dgvUpdateGrid.Rows(i).Cells("Item Description").Value = Nothing Then
                        strItemDescription = ""
                    Else
                        strItemDescription = Trim(dgvUpdateGrid.Rows(i).Cells("Item Description").Value.ToString)
                    End If
                Else
                    strItemDescription = ""
                End If
                If Not IsDBNull(dgvUpdateGrid.Rows(i).Cells("Selling Price").Value) Then
                    If dgvUpdateGrid.Rows(i).Cells("Selling Price").Value = Nothing Then
                        strSellingPrice = "0"
                    Else
                        strSellingPrice = dgvUpdateGrid.Rows(i).Cells("Selling Price").Value.ToString
                    End If
                Else
                    strSellingPrice = "0"
                End If
                If Not IsDBNull(dgvUpdateGrid.Rows(i).Cells("Current Price").Value) Then
                    If dgvUpdateGrid.Rows(i).Cells("Current Price").Value = Nothing Then
                        strCurrentPrice = "0"
                    Else
                        strCurrentPrice = dgvUpdateGrid.Rows(i).Cells("Current Price").Value.ToString
                    End If
                Else
                    strCurrentPrice = "0"
                End If
                If IsDBNull(dgvUpdateGrid.Rows(i).Cells("Record ID").Value) Then
                    RecordID = 0
                ElseIf dgvUpdateGrid.Rows(i).Cells("Record ID").Value = Nothing Then
                    RecordID = 0
                    'Continue For
                Else
                    RecordID = Trim(dgvUpdateGrid.Rows(i).Cells("Record ID").Value)
                End If
                If strS21ItemCode <> "" Then
                    If DBVersion = "MYSQL" Then
                        DAL.UpdateAPEMaster_MYSQL(RecordID, strS21ItemCode, strItemDescription, strSellingPrice, strCurrentPrice)
                    Else
                        DAL.UpdateAPEMaster(GlobalSession.ConnectString, RecordID, strS21ItemCode, strItemDescription, strSellingPrice, strCurrentPrice)
                    End If
                End If
            End If
            Message = ""
            'Percentage = (i / dgvUpdateGrid.Rows.Count - 1) * 100
            'Message = "Updating Grid: " & CStr(Percentage) & "%"
            'stsUpdateGridLabel1.Text = Message
        Next i
        watch.Stop()
        stsUpdateGridLabel1.Text = "Completed in " & "" & CStr(watch.Elapsed.TotalSeconds) & " seconds"
    End Function

    Private Sub InsertRow()
        Dim dt As DataTable

        'dgvUpdateGrid.DataSource = Nothing
        dgvUpdateGrid.Rows.Add() 'Gives error
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        PopulateForm()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If DBVersion = "MYSQL" Then
            UpdateDBfromGridDan()
        Else
            UpdateDBfromGridDan()
        End If

        'PopulateForm()
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        InsertRow()
    End Sub

    Private Sub dgvUpdateGrid_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvUpdateGrid.CellBeginEdit
        If Not IsDBNull(dgvUpdateGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
            If Not IsNothing(dgvUpdateGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                Me.FirstEntry = dgvUpdateGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            End If
        End If

    End Sub

    Private Sub dgvUpdateGrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUpdateGrid.CellEndEdit
        If Not IsDBNull(dgvUpdateGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
            If Not IsNothing(dgvUpdateGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                Me.LastEntry = dgvUpdateGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                If Me.FirstEntry <> Me.LastEntry Then
                    dgvUpdateGrid.Rows(e.RowIndex).Cells("UPDATED").Value = True
                    dgvUpdateGrid.Rows(e.RowIndex).Cells("UPDATED2").Value = "1"
                End If
            End If
        End If

    End Sub
End Class
