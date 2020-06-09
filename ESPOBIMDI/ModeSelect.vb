Public Class ModeSelect
    Private _Trustcode As String
    'Dim GlobalSession As New ESPOParms.Session
    'Dim GlobalParms As New ESPOParms.Framework

    'Public Sub GetParms(ByRef Session As ESPOParms.Session, ByRef Parms As ESPOParms.Framework)
    '    GlobalParms = Parms
    '   GlobalSession = Session
    ' End Sub

    Private Sub SelectMode_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboMode.Items.Add("LIVE")
        cboMode.Items.Add("TEST")
        cboMode.SelectedText = "LIVE"
        'cboMode.SelectedText = "TEST"
        AcceptButton = btnOK
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '        GlobalSession.CurrentMode = cboMode.Text
        Trustcode = cboMode.Text
        Hide()

    End Sub
    Public Function GetMode() As String
        'Return (cboMode.Text)
        Return (Trustcode)
    End Function
    Public Property Trustcode As String
        Get
            Trustcode = _Trustcode
        End Get

        Set(Value As String)
            _Trustcode = Value
        End Set
    End Property

End Class