Namespace GeneralSp

    Public Class GeneralClass

        Dim ConnString As String
        Dim CurID, SeqID As New SqlClient.SqlParameter
        Dim cmdPro As New SqlClient.SqlCommand
        '''''Dim CmdRefresh As New SqlClient.SqlCommand
        '''''Dim drRefresh As SqlClient.SqlDataReader


        Public Sub OpenConn(ByVal DB As String, ByVal RptSerName As String, Optional ByVal Usr As String = "Sa", Optional ByVal Pwd As String = "pass@word1", Optional ByVal IsLocal As Boolean = True)

            'RptSerName = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Server.Srvr")
            ' = "(local)"
            If IsLocal = True Then
                ConnString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" & DB & ";Data Source=" & RptSerName
            Else
                ConnString = "Password=" & Pwd & ";Persist Security Info=false;User ID=" & Usr & ";Initial Catalog=master;Data Source=" & RptSerName
                cn.ConnectionString = ConnString
                cn.Open()
                cmd.CommandType = CommandType.Text
                cmd.Connection = cn
                da.SelectCommand = cmd

                If CheckDatabaseAttached("gym") = False Then
                    If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\gym.mdf") = True Then
                        AttachDatabase()
                    Else
                        If MsgBox("·« ÌÊÃœ ﬁ«⁄œ… »Ì«‰«  „ ’·… »«·”—›— Â·  —Ìœ «‰‘«¡ ﬁ«⁄œ… »Ì«‰«  ÃœÌœ…", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
                            Dim m As New CreateDB
                            m.RadioRecreate.Enabled = False
                            m.RadioNewDB.Checked = True
                            m.ShowDialog()
                        Else
                            End
                        End If
                    End If
                End If
                'cmd.CommandText = "SELECT is_read_only FROM sys.DATABASES WHERE name='StandardClothes'"
                'If cmd.ExecuteScalar = True Then
                '    cmd.CommandText = "ALTER DATABASE StandardClothes SET  READ_WRITE"
                '    cmd.ExecuteNonQuery()
                'End If
                'End If

                cn.Close()


                ConnString = "Password=" & Pwd & ";Persist Security Info=false;User ID=" & Usr & ";Initial Catalog=" & DB & ";Data Source=" & RptSerName


            End If

            cn.ConnectionString = ConnString
            cn.Open()
            cmd.CommandType = CommandType.Text
            cmd.Connection = cn
            da.SelectCommand = cmd
            'FillDataSet()
            '''''CmdRefresh.Connection = cn

            cmdPro.Connection = cn
            cmdPro.CommandType = CommandType.StoredProcedure

            cls.FillSelectedTable("select * from App_Preferences", "App_Preferences")


        End Sub

        Public Sub CloseConn()
            cn.Close()
        End Sub



#Region "DBAttach"

        Public Function CheckDatabaseAttached(ByVal DatabaseName As String) As Boolean

            cmd.CommandText = "Select count(DISTINCT name) from master.dbo.sysdatabases where name Like '" & DatabaseName & "' and has_dbaccess(Name) = 1 "

            Dim i As Integer = cmd.ExecuteScalar
            If i > 0 Then

                Return True
            Else
                Return False
            End If

        End Function


        Public Sub AttachDatabase()
            If CheckDatabaseAttached("gym") = False Then
                Dim DBData, DBLog As String
                DBData = My.Application.Info.DirectoryPath & "\gym.mdf"
                DBLog = My.Application.Info.DirectoryPath & "\gym_log.ldf"

                'cmd.CommandText = "sp_attach_db " & RptDB & ",'" & DBData & "'" & ",'" & DBLog & "'"
                cmd.CommandText = "CREATE DATABASE [gym] ON (FILENAME = N'" & DBData & "' ),( FILENAME = N'" & DBLog & "' ) FOR ATTACH"
                cmd.ExecuteNonQuery()
            End If
        End Sub


#End Region

        Public Sub SetGrant(ByVal M As ToolStripMenuItem, ByVal S As String)
            cmd.CommandText = "select distinct granted from emp_security where privilege_name = N'" & S & "'"
            If cmd.ExecuteScalar = True Then
                M.Visible = True
            Else
                M.Visible = False
            End If
        End Sub

        Public Sub FillSelectedTable(ByVal cmdTxt As String, ByVal Tbl As String)
            MyDs.Tables(Tbl).Rows.Clear()
            cmd.CommandText = cmdTxt
            da.Fill(MyDs.Tables(Tbl))
        End Sub

        Public Sub FillSelectedTable(ByVal cmdTxt As String, ByVal Tbl As DataTable)
            Tbl.Rows.Clear()
            cmd.CommandText = cmdTxt
            da.Fill(Tbl)
        End Sub

        Public Sub MsgInfo(Optional ByVal msgTxt As String = "", Optional ByVal MsgVoice As String = "")
            'If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Assistant_Type") = "⁄«œÌ…" Then
            MsgBox(msgTxt, MsgBoxStyle.Information, ProjectTitle)
            'Else
            'AssistantSound.Volume = 100
            'AssistantSound.Speak(MsgVoice)
            'End If
        End Sub

        Public Sub MsgExclamation(Optional ByVal msgTxt As String = "", Optional ByVal MsgVoice As String = "")
            'If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Assistant_Type") = "⁄«œÌ…" Then
            MsgBox(msgTxt, MsgBoxStyle.Exclamation, ProjectTitle)
            'Else
            'AssistantSound.Volume = 100
            'AssistantSound.Speak(MsgVoice)
            'End If
        End Sub

        Public Sub MsgCritical(Optional ByVal msgTxt As String = "", Optional ByVal MsgVoice As String = "")
            'If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Assistant_Type") = "⁄«œÌ…" Then
            MsgBox(msgTxt, MsgBoxStyle.Critical, ProjectTitle)
            'Else
            'AssistantSound.Volume = 100
            'AssistantSound.Speak(MsgVoice)
            'End If
        End Sub

        Public Sub ErrMsg()
            MsgBox("ÕœÀ Œÿ√ œ«Œ·Ì »—Ã«¡ «·« ’«· »„œÌ— «·‰Ÿ«„", MsgBoxStyle.Critical, ProjectTitle)
        End Sub

        Public Sub MsgComplete()
            cls.MsgExclamation("√œŒ· «·»Ì«‰«  «·‰«ﬁ’…", "please enter missing data")
        End Sub

        Public Sub ViewAll(ByVal t As TabPage)
            Dim c As Control
            For Each c In t.Controls
                c.Visible = True
            Next
        End Sub

        Public Sub HideAll(ByVal t As TabPage)
            Dim c As Control
            For Each c In t.Controls
                c.Visible = False
            Next
        End Sub

        Public Sub WriteError(ByVal ErrTxtMsg As String, ByVal Frm As String)
            Try
                MsgBox(ErrTxtMsg)

                If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\App.Err") = False Then
                    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\App.Err", ErrTxtMsg & " - " & UserNameVar & " - " & EmpIDVar & " - " & EmpNameVar & " - " & Frm, False)
                Else
                    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\App.Err", ErrTxtMsg & " - " & UserNameVar & " - " & EmpIDVar & " - " & EmpNameVar & " - " & Frm, True)
                End If
                cls.MsgCritical("—Ã«¡ «·« ’«· »„œÌ— «·‰Ÿ«„", "Please contact system admin")
            Catch ex As Exception
                ErrMsg()
            End Try
        End Sub

        Public Sub SetDetailsHeader(ByVal Tbl As DataTable, ByVal DgrdVu As DataGridView)
            For i As Integer = 0 To Tbl.Columns.Count - 1
                DgrdVu.Columns(i).HeaderText = Tbl.Columns(i).Caption
            Next
        End Sub

        'Public Function CanDelete(ByVal Tbl As String, ByVal Col As String, ByVal Val As Integer) As Boolean
        '    Dim b As Boolean = True
        '    cmd.CommandText = "select count(*) from " & Tbl & " where " & Col & " = " & Val
        '    If cmd.ExecuteScalar = 1 Then
        '        b = False
        '    End If
        '    Return b
        'End Function


        Public Function GetImagePath() As String
            Dim Fpath As String = ""
            Dim p As New OpenFileDialog
l:
            p.Title = "«Œ — ’Ê—… ·⁄—÷Â« ⁄·Ì «·‰«›–…"
            p.Filter = "Image Files|*.JPG;*.JPEG;*.png;*.Gif;"
            p.AutoUpgradeEnabled = True

            If p.ShowDialog() = DialogResult.Cancel Then
                If MsgBox("·„ Ì „ «Œ Ì«— «·’Ê—… Â·  —Ìœ «⁄«œ… «·«Œ Ì«— ø", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = DialogResult.Yes Then
                    GoTo l
                End If
            Else
                Fpath = p.FileName
            End If
            Return Fpath
        End Function

        Public Sub LoadList(ByVal Col As String, ByVal Tbl As String, ByVal Cmbo As ComboBox, Optional ByVal Whr As String = Nothing)
            Cmbo.Items.Clear()
            If Whr Is Nothing Then
                cmd.CommandText = "select " & Col & " from " & Tbl
            Else
                cmd.CommandText = "select " & Col & " from " & Tbl & Whr
            End If
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                Cmbo.Items.Add(dr(Col))
            Loop
            dr.Close()
        End Sub

        Public Sub LoadList(ByVal Col As String, ByVal Tbl As String, ByVal Cmbo As ToolStripComboBox, Optional ByVal Whr As String = Nothing)
            Cmbo.Items.Clear()
            If Whr Is Nothing Then
                cmd.CommandText = "select " & Col & " from " & Tbl
            Else
                cmd.CommandText = "select " & Col & " from " & Tbl & Whr
            End If
            dr = cmd.ExecuteReader

            Do While Not dr.Read = False
                Cmbo.ComboBox.Items.Add(dr(Col))
            Loop
            dr.Close()
        End Sub

        Function Seq(ByVal ID As Integer) As Integer
            CurID.DbType = DbType.Int32
            CurID.ParameterName = "CURR_ID"
            CurID.Direction = ParameterDirection.Output
            SeqID.DbType = DbType.Int32
            SeqID.ParameterName = "S_ID"
            SeqID.Direction = ParameterDirection.Input
            SeqID.Value = ID
            cmdPro.Parameters.Add(SeqID)
            cmdPro.Parameters.Add(CurID)
            cmdPro.CommandText = "UPDATE_SEQ"
            cmdPro.ExecuteNonQuery()
            Return CurID.Value
        End Function

        Public Sub RefreshData(ByVal Tbl As DataTable, ByVal TblNme As String, Optional ByVal OrderBy As String = Nothing)

            Tbl.Rows.Clear()
            If Not OrderBy Is Nothing Then
                cmd.CommandText = "select * from " & TblNme & " order by " & OrderBy & " Asc"
            Else
                cmd.CommandText = "select * from " & TblNme
            End If

            da.Fill(Tbl)

        End Sub

        Public Sub RefreshData(ByVal Stmt As String, ByVal Tbl As DataTable)

            Tbl.Rows.Clear()
            cmd.CommandText = Stmt

            da.Fill(Tbl)

        End Sub

        Public Sub RefreshData(ByVal Tbl As String)

            MyDs.Tables(Tbl).Rows.Clear()
            cmd.CommandText = "select * from " & Tbl
            da.Fill(MyDs.Tables(Tbl))

            '''''CmdRefresh.CommandText = "select * from " & Tbl
            '''''drRefresh = CmdRefresh.ExecuteReader
            '''''MyDs.Tables(Tbl).Load(drRefresh) ', System.Data.LoadOption.OverwriteChanges)
            '''''drRefresh.Close()
        End Sub

        Public Sub RefreshData(ByVal Tbl As String, ByVal OrderBy As String)

            MyDs.Tables(Tbl).Rows.Clear()
            cmd.CommandText = "select * from " & Tbl & " order by " & OrderBy & " Asc"
            da.Fill(MyDs.Tables(Tbl))

            '''''CmdRefresh.CommandText = "select * from " & Tbl & " order by " & OrderBy & " Asc"
            '''''drRefresh = CmdRefresh.ExecuteReader
            '''''MyDs.Tables(Tbl).Load(drRefresh) ', System.Data.LoadOption.OverwriteChanges)
            '''''drRefresh.Close()
        End Sub

    End Class

    Class MasterForms
        Dim cmdb As New SqlClient.SqlCommandBuilder
        Dim T As String
        Dim Btns(5) As ToolStripButton
        Dim Menus(5) As ToolStripMenuItem
        Dim NavigationBar As New ToolStrip
        Dim NavigationMenu As New ToolStripMenuItem
        Dim P As New Panel
        Dim BSource As New BindingSource
        Dim TxtTitle As String
        Dim Mfld As MasterField
        Dim CountTxt As New ToolStripLabel

        Dim CmdSync As New SqlClient.SqlCommand
        Dim drSync As SqlClient.SqlDataReader


        Enum EnumBtnNames
            BNew = 0
            BSave = 1
            BDelete = 2
            BFind = 3
            BExit = 4
        End Enum
        Enum EnumMenuNames
            MNew = 0
            MSave = 1
            MDelete = 2
            MFind = 3
            MExit = 4
        End Enum

        Sub New(ByVal TblName As String, ByVal BS As BindingSource, ByVal MnuNew As ToolStripMenuItem, ByVal MnuSave As ToolStripMenuItem, ByVal MnuDelete As ToolStripMenuItem, ByVal MnuFind As ToolStripMenuItem, ByVal MnuExit As ToolStripMenuItem, ByVal BtnNew As ToolStripButton, ByVal BtnSave As ToolStripButton, ByVal BtnDelete As ToolStripButton, ByVal BtnFind As ToolStripButton, ByVal BtnExit As ToolStripButton, ByVal NavBar As ToolStrip, ByVal Panel1 As Panel, ByVal NavMenu As ToolStripMenuItem, Optional ByVal Mfield As MasterField = Nothing, Optional ByVal TBox As ToolStripLabel = Nothing)

            CmdSync.Connection = cn
            T = TblName
            Btns(EnumBtnNames.BNew) = BtnNew
            Btns(EnumBtnNames.BSave) = BtnSave
            Btns(EnumBtnNames.BDelete) = BtnDelete
            Btns(EnumBtnNames.BFind) = BtnFind
            Btns(EnumBtnNames.BExit) = BtnExit

            Menus(EnumMenuNames.MNew) = MnuNew
            Menus(EnumMenuNames.MSave) = MnuSave
            Menus(EnumMenuNames.MDelete) = MnuDelete
            Menus(EnumMenuNames.MFind) = MnuFind
            Menus(EnumMenuNames.MExit) = MnuExit

            CountTxt = TBox
            If Not Mfield Is Nothing Then
                Mfld = Mfield
            Else
                Mfld = Nothing
            End If
            BSource = BS
            P = Panel1
            NavigationBar = NavBar
            NavigationMenu = NavMenu
            BSource.DataSource = MyDs
            BSource.DataMember = T
            CountTxt.Text = GetCountRecordsLogical()

            DisableAll()
        End Sub

        Function GetCountRecordsLogical() As Integer
            Return MyDs.Tables(T).Rows.Count()
        End Function

        Function GetCountRecordsPhysical(ByVal Tbl As String) As Integer
            Dim i As Integer
            cmd.CommandText = "select count(*) from " & Tbl
            i = cmd.ExecuteScalar
            Return i
        End Function

        Sub CheckRunFirst(ByVal P As Panel)
            If MyDs.Tables(T).Rows.Count <= 0 Then
                DisableAll()
            Else
                EnableAll()
            End If
        End Sub

        Sub NewRecord()
            Try
                BSource.AddNew()

                Btns(EnumBtnNames.BSave).Enabled = True
                Btns(EnumBtnNames.BDelete).Enabled = True
                Btns(EnumBtnNames.BExit).Enabled = False
                Btns(EnumBtnNames.BNew).Enabled = False
                Btns(EnumBtnNames.BFind).Enabled = False

                Menus(EnumMenuNames.MSave).Enabled = True
                Menus(EnumMenuNames.MDelete).Enabled = True
                Menus(EnumMenuNames.MExit).Enabled = False
                Menus(EnumMenuNames.MNew).Enabled = False
                Menus(EnumMenuNames.MFind).Enabled = False

                NavigationBar.Enabled = False
                NavigationMenu.Enabled = False
                EnableAll()

                CountTxt.Text = GetCountRecordsLogical()
            Catch con As ConstraintException
                cls.MsgExclamation("√⁄œ «‰‘«¡ Â–« «·”Ã·", "Please reenter this record")
                cls.FillSelectedTable("select * from " & T, T)
            Catch ex As Exception
                cls.WriteError(ex.Message, "New Method (Main)")
            End Try
        End Sub

        Sub SaveRecord()

            Try

                BSource.EndEdit()
                cmd.CommandText = "select * from " & T
                cmdb.DataAdapter = da
                da.Update(MyDs.Tables(T))
                cls.RefreshData(T)
                '--------------
                'MyDs.Tables(T).GetChanges()
                'If drSync.IsClosed = False Then
                '    drSync.Close()
                'End If
                ''''''If MyDs.Tables(T).Rows.Count <= 2 Then
                ''''''    cls.FillSelectedTable("select * from " & T, T)
                ''''''Else
                ''''''    CmdSync.CommandText = "select * from " & T
                ''''''    drSync = CmdSync.ExecuteReader
                ''''''    MyDs.Tables(T).Load(drSync, System.Data.LoadOption.OverwriteChanges)
                ''''''    drSync.Close()
                ''''''End If
                '-----------

                Btns(EnumBtnNames.BNew).Enabled = True
                Btns(EnumBtnNames.BFind).Enabled = True
                Btns(EnumBtnNames.BDelete).Enabled = True
                Btns(EnumBtnNames.BSave).Enabled = False
                Btns(EnumBtnNames.BExit).Enabled = True


                Menus(EnumMenuNames.MNew).Enabled = True
                Menus(EnumMenuNames.MFind).Enabled = True
                Menus(EnumMenuNames.MDelete).Enabled = True
                Menus(EnumMenuNames.MSave).Enabled = False
                Menus(EnumMenuNames.MExit).Enabled = True

                DisableAll()


                BSource.RemoveFilter()
                NavigationBar.Enabled = True
                NavigationMenu.Enabled = True
                CountTxt.Text = GetCountRecordsLogical()
                'If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                '    cls.MsgInfo(" „ Õ›Ÿ «· €ÌÌ—«  »‰Ã«Õ", "Data saved successfully")
                'End If
            Catch con As ConstraintException
                cls.MsgExclamation("Â–Â «·»Ì«‰«  „ÊÃÊœ… „”»ﬁ« »—Ã«¡ «⁄«œ… «·«œŒ«·", "Data already existed please reenter a unique data")
            Catch exUn As SqlClient.SqlException
                cls.MsgExclamation("Â–Â «·»Ì«‰«  „ÊÃÊœ… „”»ﬁ« »—Ã«¡ «⁄«œ… «·«œŒ«·", "Data already existed please reenter a unique data")
            Catch ex As InvalidOperationException
                Try
                    If drSync.IsClosed = False Then
                        drSync.Close()
                    End If
                    cls.MsgExclamation("·„ Ì „ Õ›Ÿ «·»Ì«‰«  »—Ã«¡ «⁄«œ… Õ›Ÿ «·»Ì«‰« ", "System is unable to save data please try again later")
                Catch ex1 As Exception
                    cls.WriteError(ex1.Message, "G Class")
                End Try

            Catch ex As Exception
                cls.WriteError(ex.Message, "G Class")
            End Try

        End Sub

        Sub EditRecord()

            Btns(EnumBtnNames.BNew).Enabled = False
            Btns(EnumBtnNames.BFind).Enabled = False
            Btns(EnumBtnNames.BSave).Enabled = True
            EnableAll()
            Menus(EnumMenuNames.MNew).Enabled = False
            Menus(EnumMenuNames.MFind).Enabled = False
            Menus(EnumMenuNames.MSave).Enabled = True

        End Sub

        Sub DeleteRecord()
            Try
                If MsgBox("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ì", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then

                    '''''CmdSync.CommandText = "select * from " & T
                    '''''drSync = CmdSync.ExecuteReader
                    '''''MyDs.Tables(T).Load(drSync) ', System.Data.LoadOption.OverwriteChanges)
                    '''''drSync.Close()


                    BSource.RemoveCurrent()
                    BSource.EndEdit()
                    cmd.CommandText = "select * from " & T
                    cmdb.DataAdapter = da
                    da.Update(MyDs.Tables(T))

                    Btns(EnumBtnNames.BNew).Enabled = True
                    Btns(EnumBtnNames.BFind).Enabled = True
                    Btns(EnumBtnNames.BDelete).Enabled = True
                    Btns(EnumBtnNames.BSave).Enabled = False
                    Btns(EnumBtnNames.BExit).Enabled = True

                    Menus(EnumMenuNames.MNew).Enabled = True
                    Menus(EnumMenuNames.MFind).Enabled = True
                    Menus(EnumMenuNames.MDelete).Enabled = True
                    Menus(EnumMenuNames.MSave).Enabled = False
                    Menus(EnumMenuNames.MExit).Enabled = True

                    DisableAll()
                    NavigationBar.Enabled = True
                    NavigationMenu.Enabled = True

                    BSource.RemoveFilter()
                    CountTxt.Text = GetCountRecordsLogical()
                    'If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    '    cls.MsgInfo(" „ Õ–› »Ì«‰«  «·”Ã· «·Õ«·Ì", "Data deleted successfully")
                    'End If
                End If

            Catch Fk_Err As SqlClient.SqlException
                MyDs.Tables(T).RejectChanges()
                cls.MsgCritical("Â–« «·”Ã· „— »ÿ »”Ã·«  √Œ—Ì Ê ·«Ì„ﬂ‰ Õ–›Â", "this record is attached to another record and cannot be removed")
            Catch con As ConstraintException
                MyDs.Tables(T).RejectChanges()
                cls.MsgCritical("Â–« «·”Ã· „— »ÿ »”Ã·«  √Œ—Ì Ê ·«Ì„ﬂ‰ Õ–›Â", "this record is attached to another record and cannot be removed")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Sub FirstRec()
            BSource.MoveFirst()
        End Sub

        Sub LastRec()
            BSource.MoveLast()
        End Sub

        Sub PreviousRec()
            BSource.MovePrevious()
        End Sub

        Sub NextRec()
            BSource.MoveNext()
        End Sub

        Sub ExitForm()

            Try

                If Not MyDs.Tables(T).GetChanges() Is Nothing And MyDs.Tables(T).Rows.Count <> 0 Then
                    If MsgBox("Â·  —Ìœ Õ›Ÿ «· €ÌÌ—«  ﬁ»· «·Œ—ÊÃ „‰ «·‰«›–…", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, ProjectTitle) = MsgBoxResult.Yes Then
                        SaveRecord()
                    Else
                        MyDs.Tables(T).RejectChanges()
                    End If
                End If
                MyDs.Tables(T).RejectChanges()

            Catch ex As Exception
                cls.ErrMsg()
            End Try
        End Sub

        Sub CutData(ByVal frm As Panel)
            Dim c As TextBox
            For Each c In frm.Controls
                If TypeOf c Is TextBox Then
                    c.Cut()
                End If
            Next

        End Sub

        Sub CopyData(ByVal frm As Panel)
            Dim c As TextBox
            For Each c In frm.Controls
                If TypeOf c Is TextBox Then
                    c.Copy()
                End If
            Next

        End Sub

        Sub PasteData(ByVal frm As Panel)
            Dim c As TextBox
            For Each c In frm.Controls
                If TypeOf c Is TextBox Then
                    c.Paste()
                End If
            Next

        End Sub

        Sub SortData(ByVal B As BindingSource, ByVal ColName As String)
            B.Sort = ColName
        End Sub

        Property SetWTitle() As String
            Get
                Return TxtTitle
            End Get
            Set(ByVal value As String)
                TxtTitle = value & " - «·„” Œœ„ «·Õ«·Ì : " & EmpNameVar
            End Set
        End Property

        Public Sub EnableAll()
            Dim c As Control
            If Not Mfld Is Nothing Then
                Mfld.EnableField = True
            End If
            For Each c In P.Controls
                If TypeOf c Is TextBox Or TypeOf c Is ComboBox Or TypeOf c Is CheckBox Or TypeOf c Is Button Or TypeOf c Is RadioButton Or TypeOf c Is GeneralTextBox Or TypeOf c Is NumericUpDown Or TypeOf c Is DateTimePicker Or TypeOf c Is Panel Or TypeOf c Is SplitContainer Then
                    c.Enabled = True
                End If
            Next
        End Sub

        Public Sub DisableAll()
            Dim c As Control
            If Not Mfld Is Nothing Then
                Mfld.EnableField = False
            End If
            For Each c In P.Controls
                If TypeOf c Is TextBox Or TypeOf c Is ComboBox Or TypeOf c Is CheckBox Or TypeOf c Is Button Or TypeOf c Is RadioButton Or TypeOf c Is GeneralTextBox Or TypeOf c Is NumericUpDown Or TypeOf c Is DateTimePicker Or TypeOf c Is Panel Or TypeOf c Is SplitContainer Then
                    c.Enabled = False
                End If
            Next
        End Sub

    End Class

    '/***********************New Master Forms*************************/

    Class NewMasterForms

        Dim cmdb As New SqlClient.SqlCommandBuilder
        Dim T As String
        Dim P As New Panel
        Dim BSource As New BindingSource
        Dim TxtTitle As String
        Dim Mfld As MasterField
        Dim CountTxt As New Label
        Dim Btns(14) As Button
        Dim OrderByCombo As ComboBox
        '''Dim CmdSync As New SqlClient.SqlCommand
        '''Dim drSync As SqlClient.SqlDataReader


        Enum EnumBtnNames
            BNew = 0
            BSave = 1
            BDelete = 2
            BFind = 3
            BExit = 4
            BReload = 5
            BCancelSearch = 6
            BFirst = 7
            BPrevious = 8
            BNext = 9
            BLast = 10
            BFile = 11
            BData = 12
            BHelp = 13
        End Enum


        Sub New(ByVal TblName As String, ByVal BS As BindingSource, ByVal BtnNew As Button, ByVal BtnSave As Button, ByVal BtnDelete As Button, ByVal BtnFind As Button, ByVal BtnExit As Button, ByVal BtnReload As Button, ByVal BtnCancelSearch As Button, ByVal BtnFirst As Button, ByVal BtnPrevious As Button, ByVal BtnNext As Button, ByVal BtnLast As Button, ByVal BtnFile As Button, ByVal BtnData As Button, ByVal BtnHelp As Button, ByVal OByCmb As ComboBox, ByVal Panel1 As Panel, Optional ByVal Mfield As MasterField = Nothing, Optional ByVal TBox As Label = Nothing)

            '''' CmdSync.Connection = cn
            T = TblName

            CountTxt = TBox
            If Not Mfield Is Nothing Then
                Mfld = Mfield
            Else
                Mfld = Nothing
            End If
            BSource = BS
            P = Panel1

            Btns(EnumBtnNames.BNew) = BtnNew
            Btns(EnumBtnNames.BSave) = BtnSave
            Btns(EnumBtnNames.BDelete) = BtnDelete
            Btns(EnumBtnNames.BFind) = BtnFind
            Btns(EnumBtnNames.BExit) = BtnExit
            Btns(EnumBtnNames.BReload) = BtnReload
            Btns(EnumBtnNames.BCancelSearch) = BtnCancelSearch
            Btns(EnumBtnNames.BFirst) = BtnFirst
            Btns(EnumBtnNames.BPrevious) = BtnPrevious
            Btns(EnumBtnNames.BNext) = BtnNext
            Btns(EnumBtnNames.BLast) = BtnLast
            Btns(EnumBtnNames.BFile) = BtnFile
            Btns(EnumBtnNames.BData) = BtnData
            Btns(EnumBtnNames.BHelp) = BtnHelp

            OrderByCombo = OByCmb

            BSource.DataSource = MyDs
            BSource.DataMember = T
            CountTxt.Text = GetCountRecordsLogical()

            DisableAll()
        End Sub

        Function GetCountRecordsLogical() As Integer
            Return MyDs.Tables(T).Rows.Count()
        End Function

        Function GetCountRecordsPhysical(ByVal Tbl As String) As Integer
            Dim i As Integer
            cmd.CommandText = "select count(*) from " & Tbl
            i = cmd.ExecuteScalar
            Return i
        End Function

        Sub CheckRunFirst(ByVal P As Panel)
            If MyDs.Tables(T).Rows.Count <= 0 Then
                DisableAll()
            Else
                EnableAll()
            End If
        End Sub

        Sub NewRecord()
            Try
                BSource.AddNew()

                Btns(EnumBtnNames.BSave).Enabled = True
                Btns(EnumBtnNames.BDelete).Enabled = True
                Btns(EnumBtnNames.BExit).Enabled = False
                Btns(EnumBtnNames.BNew).Enabled = False
                Btns(EnumBtnNames.BFind).Enabled = False
                Btns(EnumBtnNames.BReload).Enabled = False
                Btns(EnumBtnNames.BCancelSearch).Enabled = False
                Btns(EnumBtnNames.BFirst).Enabled = False
                Btns(EnumBtnNames.BPrevious).Enabled = False
                Btns(EnumBtnNames.BNext).Enabled = False
                Btns(EnumBtnNames.BLast).Enabled = False

                '---------------------------------------------
                Btns(EnumBtnNames.BNew).BackgroundImage = My.Resources.without_texte_2_16
                Btns(EnumBtnNames.BSave).BackgroundImage = My.Resources.save_18_18
                Btns(EnumBtnNames.BFind).BackgroundImage = My.Resources.edit_1_19
                Btns(EnumBtnNames.BDelete).BackgroundImage = My.Resources.delete_1_21
                '---------------------------------------------

                OrderByCombo.Enabled = False

                EnableAll()

                CountTxt.Text = GetCountRecordsLogical()
            Catch con As ConstraintException
                cls.MsgExclamation("√⁄œ «‰‘«¡ Â–« «·”Ã·", "Please reenter this record")
                cls.FillSelectedTable("select * from " & T, T)
            Catch ex As Exception
                cls.WriteError(ex.Message, "New Method (Main)")
            End Try
        End Sub

        Sub SaveRecord()

            Try

                BSource.EndEdit()
                cmd.CommandText = "select * from " & T
                cmdb.DataAdapter = da
                da.Update(MyDs.Tables(T))

                '--------------
                'MyDs.Tables(T).GetChanges()
                'If drSync.IsClosed = False Then
                '    drSync.Close()
                'End If
                ''''If MyDs.Tables(T).Rows.Count <= 2 Then
                cls.FillSelectedTable("select * from " & T, T)
                ''''Else
                ''''    CmdSync.CommandText = "select * from " & T
                ''''    drSync = CmdSync.ExecuteReader
                ''''    MyDs.Tables(T).Load(drSync, System.Data.LoadOption.OverwriteChanges)
                ''''    drSync.Close()
                ''''End If
                '-----------

                Btns(EnumBtnNames.BNew).Enabled = True
                Btns(EnumBtnNames.BFind).Enabled = True
                Btns(EnumBtnNames.BDelete).Enabled = True
                Btns(EnumBtnNames.BSave).Enabled = False
                Btns(EnumBtnNames.BExit).Enabled = True
                Btns(EnumBtnNames.BReload).Enabled = True
                Btns(EnumBtnNames.BCancelSearch).Enabled = True
                Btns(EnumBtnNames.BFirst).Enabled = True
                Btns(EnumBtnNames.BPrevious).Enabled = True
                Btns(EnumBtnNames.BNext).Enabled = True
                Btns(EnumBtnNames.BLast).Enabled = True

                '---------------------------------------------
                Btns(EnumBtnNames.BNew).BackgroundImage = My.Resources.without_text_16
                Btns(EnumBtnNames.BSave).BackgroundImage = My.Resources.save_2_18
                Btns(EnumBtnNames.BFind).BackgroundImage = My.Resources.edit_1_19
                Btns(EnumBtnNames.BDelete).BackgroundImage = My.Resources.delete_1_21
                '---------------------------------------------

                DisableAll()


                BSource.RemoveFilter()

                CountTxt.Text = GetCountRecordsLogical()
                'If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                '    cls.MsgInfo(" „ Õ›Ÿ «· €ÌÌ—«  »‰Ã«Õ", "Data saved successfully")
                'End If
            Catch con As ConstraintException
                cls.MsgExclamation("Â–Â «·»Ì«‰«  „ÊÃÊœ… „”»ﬁ« »—Ã«¡ «⁄«œ… «·«œŒ«·", "Data already existed please reenter a unique data")
            Catch exUn As SqlClient.SqlException
                cls.MsgExclamation("Â–Â «·»Ì«‰«  „ÊÃÊœ… „”»ﬁ« »—Ã«¡ «⁄«œ… «·«œŒ«·", "Data already existed please reenter a unique data")
                '''' Catch ex As InvalidOperationException
                ''''Try
                ''''    '''        If drSync.IsClosed = False Then
                ''''    '''            drSync.Close()
                ''''    '''        End If
                ''''    '''        cls.MsgExclamation("·„ Ì „ Õ›Ÿ «·»Ì«‰«  »—Ã«¡ «⁄«œ… Õ›Ÿ «·»Ì«‰« ", "System is unable to save data please try again later")
                ''''Catch ex1 As Exception
                ''''    cls.WriteError(ex1.Message, "G Class")
                ''''End Try

            Catch ex As Exception
                cls.WriteError(ex.Message, "G Class")
            End Try

        End Sub

        Sub EditRecord()

            Btns(EnumBtnNames.BNew).Enabled = False
            Btns(EnumBtnNames.BFind).Enabled = False
            Btns(EnumBtnNames.BSave).Enabled = True

            Btns(EnumBtnNames.BNew).BackgroundImage = My.Resources.without_text_16
            Btns(EnumBtnNames.BSave).BackgroundImage = My.Resources.save_18_18
            Btns(EnumBtnNames.BFind).BackgroundImage = My.Resources.edit_2_20
            Btns(EnumBtnNames.BDelete).BackgroundImage = My.Resources.delete_1_21

            EnableAll()


        End Sub

        Sub DeleteRecord()
            Try
                If MsgBox("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ì", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then

                    ''''CmdSync.CommandText = "select * from " & T
                    ''''drSync = CmdSync.ExecuteReader
                    ''''MyDs.Tables(T).Load(drSync) ', System.Data.LoadOption.OverwriteChanges)
                    ''''drSync.Close()

                    Btns(EnumBtnNames.BNew).BackgroundImage = My.Resources.without_text_16
                    Btns(EnumBtnNames.BSave).BackgroundImage = My.Resources.save_18_18
                    Btns(EnumBtnNames.BFind).BackgroundImage = My.Resources.edit_1_19
                    Btns(EnumBtnNames.BDelete).BackgroundImage = My.Resources.delete_2_21

                    BSource.RemoveCurrent()
                    BSource.EndEdit()
                    cmd.CommandText = "select * from " & T
                    cmdb.DataAdapter = da
                    da.Update(MyDs.Tables(T))

                    cls.FillSelectedTable("select * from " & T, T)

                    Btns(EnumBtnNames.BNew).Enabled = True
                    Btns(EnumBtnNames.BFind).Enabled = True
                    Btns(EnumBtnNames.BDelete).Enabled = True
                    Btns(EnumBtnNames.BSave).Enabled = False
                    Btns(EnumBtnNames.BExit).Enabled = True
                    Btns(EnumBtnNames.BReload).Enabled = True
                    Btns(EnumBtnNames.BCancelSearch).Enabled = True
                    Btns(EnumBtnNames.BFirst).Enabled = True
                    Btns(EnumBtnNames.BPrevious).Enabled = True
                    Btns(EnumBtnNames.BNext).Enabled = True
                    Btns(EnumBtnNames.BLast).Enabled = True


                    DisableAll()


                    BSource.RemoveFilter()
                    CountTxt.Text = GetCountRecordsLogical()
                    'If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    '    cls.MsgInfo(" „ Õ–› »Ì«‰«  «·”Ã· «·Õ«·Ì", "Data deleted successfully")
                    'End If
                End If

            Catch Fk_Err As SqlClient.SqlException
                MyDs.Tables(T).RejectChanges()
                cls.MsgCritical("Â–« «·”Ã· „— »ÿ »”Ã·«  √Œ—Ì Ê ·«Ì„ﬂ‰ Õ–›Â", "this record is attached to another record and cannot be removed")
            Catch con As ConstraintException
                MyDs.Tables(T).RejectChanges()
                cls.MsgCritical("Â–« «·”Ã· „— »ÿ »”Ã·«  √Œ—Ì Ê ·«Ì„ﬂ‰ Õ–›Â", "this record is attached to another record and cannot be removed")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Sub FirstRec()
            BSource.MoveFirst()
        End Sub

        Sub LastRec()
            BSource.MoveLast()
        End Sub

        Sub PreviousRec()
            BSource.MovePrevious()
        End Sub

        Sub NextRec()
            BSource.MoveNext()
        End Sub

        Sub ExitForm()

            Try

                'If Not MyDs.Tables(T).GetChanges() Is Nothing And MyDs.Tables(T).Rows.Count <> 0 Then
                '    If MsgBox("Â·  —Ìœ Õ›Ÿ «· €ÌÌ—«  ﬁ»· «·Œ—ÊÃ „‰ «·‰«›–…", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, ProjectTitle) = MsgBoxResult.Yes Then
                '        SaveRecord()
                '    Else
                '        MyDs.Tables(T).RejectChanges()
                '    End If
                'End If
                MyDs.Tables(T).RejectChanges()

            Catch ex As Exception
                cls.ErrMsg()
            End Try
        End Sub

        Sub CutData(ByVal frm As Panel)
            Dim c As TextBox
            For Each c In frm.Controls
                If TypeOf c Is TextBox Then
                    c.Cut()
                End If
            Next

        End Sub

        Sub CopyData(ByVal frm As Panel)
            Dim c As TextBox
            For Each c In frm.Controls
                If TypeOf c Is TextBox Then
                    c.Copy()
                End If
            Next

        End Sub

        Sub PasteData(ByVal frm As Panel)
            Dim c As TextBox
            For Each c In frm.Controls
                If TypeOf c Is TextBox Then
                    c.Paste()
                End If
            Next

        End Sub

        Sub SortData(ByVal B As BindingSource, ByVal ColName As String)
            B.Sort = ColName
        End Sub

        Property SetWTitle() As String
            Get
                Return TxtTitle
            End Get
            Set(ByVal value As String)
                TxtTitle = value & " - «·„” Œœ„ «·Õ«·Ì : " & EmpNameVar
            End Set
        End Property

        Public Sub EnableAll()
            Dim c As Control
            If Not Mfld Is Nothing Then
                Mfld.EnableField = True
            End If
            For Each c In P.Controls
                If TypeOf c Is TextBox Or TypeOf c Is ComboBox Or TypeOf c Is CheckBox Or TypeOf c Is Button Or TypeOf c Is RadioButton Or TypeOf c Is GeneralTextBox Or TypeOf c Is NumericUpDown Or TypeOf c Is DateTimePicker Or TypeOf c Is Panel Or TypeOf c Is SplitContainer Then
                    c.Enabled = True
                End If
            Next
        End Sub

        Public Sub DisableAll()
            Dim c As Control
            If Not Mfld Is Nothing Then
                Mfld.EnableField = False
            End If
            For Each c In P.Controls
                If TypeOf c Is TextBox Or TypeOf c Is ComboBox Or TypeOf c Is CheckBox Or TypeOf c Is Button Or TypeOf c Is RadioButton Or TypeOf c Is GeneralTextBox Or TypeOf c Is NumericUpDown Or TypeOf c Is DateTimePicker Or TypeOf c Is Panel Or TypeOf c Is SplitContainer Then
                    c.Enabled = False
                End If
            Next
        End Sub

        Public Sub BtnFile()
            Btns(EnumBtnNames.BNew).Visible = True
            Btns(EnumBtnNames.BFind).Visible = True
            Btns(EnumBtnNames.BDelete).Visible = True
            Btns(EnumBtnNames.BSave).Visible = True
            Btns(EnumBtnNames.BExit).Visible = True
            Btns(EnumBtnNames.BReload).Visible = False
            Btns(EnumBtnNames.BCancelSearch).Visible = False
            Btns(EnumBtnNames.BFile).BackgroundImage = My.Resources.master_09Selected
            Btns(EnumBtnNames.BData).BackgroundImage = My.Resources.master_05
            Btns(EnumBtnNames.BHelp).BackgroundImage = My.Resources.master_03

        End Sub

        Public Sub BtnData()
            Btns(EnumBtnNames.BNew).Visible = False
            Btns(EnumBtnNames.BFind).Visible = False
            Btns(EnumBtnNames.BDelete).Visible = False
            Btns(EnumBtnNames.BSave).Visible = False
            Btns(EnumBtnNames.BExit).Visible = False
            Btns(EnumBtnNames.BReload).Visible = True
            Btns(EnumBtnNames.BCancelSearch).Visible = True
            Btns(EnumBtnNames.BFile).BackgroundImage = My.Resources.master_09
            Btns(EnumBtnNames.BData).BackgroundImage = My.Resources.master_05Selected
            Btns(EnumBtnNames.BHelp).BackgroundImage = My.Resources.master_03
        End Sub

        Public Sub BtnHelp()
            Btns(EnumBtnNames.BFile).BackgroundImage = My.Resources.master_09
            Btns(EnumBtnNames.BData).BackgroundImage = My.Resources.master_05
            Btns(EnumBtnNames.BHelp).BackgroundImage = My.Resources.master_03Selected
        End Sub

        Sub ReloadData()
            cls.FillSelectedTable("select * from " & T, T)
        End Sub
    End Class

End Namespace