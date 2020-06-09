<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateGrid
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvUpdateGrid = New System.Windows.Forms.DataGridView()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.stsUpdateGrid = New System.Windows.Forms.StatusStrip()
        Me.stsUpdateGridLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgvUpdateGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.stsUpdateGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvUpdateGrid
        '
        Me.dgvUpdateGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUpdateGrid.Location = New System.Drawing.Point(1, 48)
        Me.dgvUpdateGrid.Name = "dgvUpdateGrid"
        Me.dgvUpdateGrid.Size = New System.Drawing.Size(594, 244)
        Me.dgvUpdateGrid.TabIndex = 0
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.btnInsert)
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnUpdate)
        Me.pnlButtons.Controls.Add(Me.btnRefresh)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButtons.Location = New System.Drawing.Point(0, 0)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(597, 45)
        Me.pnlButtons.TabIndex = 1
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(196, 12)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(75, 23)
        Me.btnInsert.TabIndex = 3
        Me.btnInsert.Text = "Insert"
        Me.btnInsert.UseVisualStyleBackColor = True
        Me.btnInsert.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(288, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(100, 12)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(3, 12)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 0
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'stsUpdateGrid
        '
        Me.stsUpdateGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsUpdateGridLabel1})
        Me.stsUpdateGrid.Location = New System.Drawing.Point(0, 272)
        Me.stsUpdateGrid.Name = "stsUpdateGrid"
        Me.stsUpdateGrid.Size = New System.Drawing.Size(597, 22)
        Me.stsUpdateGrid.TabIndex = 2
        '
        'stsUpdateGridLabel1
        '
        Me.stsUpdateGridLabel1.Name = "stsUpdateGridLabel1"
        Me.stsUpdateGridLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'UpdateGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 294)
        Me.Controls.Add(Me.stsUpdateGrid)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.dgvUpdateGrid)
        Me.Name = "UpdateGrid"
        Me.Text = "Update Grid"
        CType(Me.dgvUpdateGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButtons.ResumeLayout(False)
        Me.stsUpdateGrid.ResumeLayout(False)
        Me.stsUpdateGrid.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvUpdateGrid As DataGridView
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents stsUpdateGrid As StatusStrip
    Friend WithEvents stsUpdateGridLabel1 As ToolStripStatusLabel
    Friend WithEvents btnInsert As Button
End Class
