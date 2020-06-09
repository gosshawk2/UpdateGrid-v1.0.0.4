Imports System.Data.Odbc
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class UpdateGridDAL
    Function GetAPEMaster(ConnectString As String, Criteria As String) As DataTable
        Dim SQLStatement As String
        Dim cn As New OdbcConnection(ConnectString)
        Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection

        GetAPEMaster = Nothing
        'EPOUTILTST/APEMaster
        SQLStatement = "SELECT " &
            "RecordID as ""Record ID"", " &
            "trim(S21ItemCode) as ""S21 Item Code"", " &
            "trim(ItemDescription) as ""Item Description"", " &
            "SellingPrice as ""Selling Price"", " &
            "CurrentPrice as ""Current Price"" " &
            "FROM APEMaster"

        If Len(Criteria) > 0 Then
            SQLStatement += " WHERE " & Criteria
        End If
        SQLStatement += " ORDER BY RecordID"

        cn.Open()
        cm.CommandTimeout = 0
        cm.CommandType = CommandType.Text
        cm.CommandText = SQLStatement
        Dim da As New OdbcDataAdapter(cm)
        Dim ds As New DataSet
        da.Fill(ds)
        Return ds.Tables(0)
    End Function

    Public Function UpdateAPEMaster(
                    ConnectString As String,
                    RecordID As Integer,
                    S21ItemCode As String,
                    ItemDescription As String,
                    SellingPrice As Decimal,
                    CurrentPrice As Decimal
)
        Dim SQLStatement As String
        Dim SQLOK As Boolean = True
        Dim ReworkFlag As String = "0"
        Dim cn As New OdbcConnection(ConnectString)

        cn.Open()
        Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection
        SQLStatement =
        "Select RecordID  " &
        "From apemaster  " &
        "Where RecordID =" & RecordID & " "
        cm.CommandTimeout = 0
        cm.CommandType = CommandType.Text
        cm.CommandText = SQLStatement
        Dim da As New OdbcDataAdapter(cm)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            SQLStatement =
            "Update ApeMaster " &
            "set " &
            "S21ItemCode='" & S21ItemCode & "', " &
            "ItemDescription='" & ItemDescription & "', " &
            "SellingPrice=" & SellingPrice & ", " &
            "CurrentPrice=" & CurrentPrice & " " &
            "Where RecordID =" & RecordID & " "
        Else
            SQLStatement =
            "Insert into APEMaster ( " &
            "S21ItemCode, " &
            "ItemDescription, " &
            "SellingPrice, " &
            "CurrentPrice " &
            ")  " &
            "Values(" &
            "'" & S21ItemCode & "' , " &
            "'" & ItemDescription & "' , " &
            SellingPrice & ", " &
            CurrentPrice & " " &
            ")"
        End If
        cm.CommandText = SQLStatement
        Dim da1 As New OdbcDataAdapter(cm)
        Dim ds1 As New DataSet
        Try
            da1.Fill(ds1)
        Catch ex As Exception
            MsgBox(ex.Message)
            SQLOK = False
        End Try
        Return (SQLOK)
    End Function

    Function GetAPEMaster_MYSQL(Criteria As String) As DataTable
        Dim SQLStatement As String
        Dim ConnString As String
        Dim ZeroDatetime As Boolean = True
        Dim Server As String = "localhost"
        Dim DbaseName As String = "espotest"
        Dim USERNAME As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"

        Try
            ConnString = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
            Dim cn As New MySqlConnection(ConnString)
            cn.Open()
            Dim cm As MySqlCommand = cn.CreateCommand 'Create a command object via the connection
            GetAPEMaster_MYSQL = Nothing
            'EPOUTILTST/APEMaster
            SQLStatement = "SELECT " &
                "RecordID as ""Record ID"", " &
                "trim(S21ItemCode) as ""S21 Item Code"", " &
                "trim(ItemDescription) as ""Item Description"", " &
                "SellingPrice as ""Selling Price"", " &
                "CurrentPrice as ""Current Price"" " &
                "FROM APEMaster"

            If Len(Criteria) > 0 Then
                SQLStatement += " WHERE " & Criteria
            End If
            SQLStatement += " ORDER BY RecordID"

            cm.CommandTimeout = 0
            cm.CommandType = CommandType.Text
            cm.CommandText = SQLStatement
            Dim da As New MySqlDataAdapter(cm)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("Error in GetAPEMaster(): " & ex.Message)
        End Try

    End Function

    Public Function UpdateAPEMaster_MYSQL(
                    RecordID As Integer,
                    S21ItemCode As String,
                    ItemDescription As String,
                    SellingPrice As Decimal,
                    CurrentPrice As Decimal
)
        Dim SQLStatement As String
        Dim SQLOK As Boolean = True
        Dim ReworkFlag As String = "0"
        Dim ConnString As String
        Dim ZeroDatetime As Boolean = True
        Dim Server As String = "localhost"
        Dim DbaseName As String = "espotest"
        Dim USERNAME As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"

        Try
            ConnString = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
            Dim cn As New MySqlConnection(ConnString)
            cn.Open()
            Dim cm As MySqlCommand = cn.CreateCommand 'Create a command object via the connection
            SQLStatement =
                "Select RecordID  " &
                "From apemaster  " &
                "Where RecordID =" & RecordID & " "
            cm.CommandTimeout = 0
            cm.CommandType = CommandType.Text
            cm.CommandText = SQLStatement
            Dim da As New MySqlDataAdapter(cm)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                SQLStatement =
                "Update ApeMaster " &
                "set " &
                "S21ItemCode='" & S21ItemCode & "', " &
                "ItemDescription='" & ItemDescription & "', " &
                "SellingPrice=" & SellingPrice & ", " &
                "CurrentPrice=" & CurrentPrice & " " &
                "Where RecordID =" & RecordID & " "
            Else
                SQLStatement =
                "Insert into APEMaster ( " &
                "S21ItemCode, " &
                "ItemDescription, " &
                "SellingPrice, " &
                "CurrentPrice " &
                ")  " &
                "Values(" &
                "'" & S21ItemCode & "' , " &
                "'" & ItemDescription & "' , " &
                SellingPrice & ", " &
                CurrentPrice & " " &
                ")"
            End If
            cm.CommandText = SQLStatement
            Dim da1 As New MySqlDataAdapter(cm)
            Dim ds1 As New DataSet
            Try
                da1.Fill(ds1)
            Catch ex As Exception
                MsgBox("Error2 in UpdateAPEMaster_MYSQL: " & ex.Message)
                SQLOK = False
            End Try
            Return (SQLOK)
        Catch ex As Exception
            MsgBox("Error in UpdateAPEMaster_MYSQL(): " & ex.Message)
        End Try

    End Function

End Class
