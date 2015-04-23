<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyProcedures
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DailyProcedures))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnNew = New System.Windows.Forms.ToolStripButton()
        Me.BtnSave = New System.Windows.Forms.ToolStripButton()
        Me.BtnSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnHelp = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NavigationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NavigationMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuFirst = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPrevious = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuNext = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuLast = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviousToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.CountHitsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuReload = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuCancelSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutThisWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentPanel = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Col_Procedure_Master_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Daily_Procedure_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Reference_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Generic_Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Balance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Procedure_Category = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Col_Procedure_Type = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.BtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.BtnPervious = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.OrderByCombo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnLast = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.CountRecords = New System.Windows.Forms.ToolStripLabel()
        Me.NavigationBar = New System.Windows.Forms.ToolStrip()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ContentPanel.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavigationBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNew, Me.BtnSave, Me.BtnSearch, Me.ToolStripSeparator1, Me.BtnDelete, Me.ToolStripSeparator5, Me.BtnExit, Me.ToolStripSeparator12, Me.BtnHelp})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(1284, 35)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnNew
        '
        Me.BtnNew.Image = Global.GYM.My.Resources.Resources.Symbol_Add
        Me.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(62, 32)
        Me.BtnNew.Text = "ÃœÌœ"
        Me.BtnNew.Visible = False
        '
        'BtnSave
        '
        Me.BtnSave.AutoSize = False
        Me.BtnSave.BackgroundImage = Global.GYM.My.Resources.Resources.save_2_18
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(150, 35)
        Me.BtnSave.Text = "Õ›Ÿ"
        '
        'BtnSearch
        '
        Me.BtnSearch.Image = Global.GYM.My.Resources.Resources.Edit
        Me.BtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(68, 32)
        Me.BtnSearch.Text = " ⁄œÌ·"
        Me.BtnSearch.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 35)
        '
        'BtnDelete
        '
        Me.BtnDelete.AutoSize = False
        Me.BtnDelete.BackgroundImage = Global.GYM.My.Resources.Resources.delete_2_21
        Me.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(150, 35)
        Me.BtnDelete.Text = "Õ–›"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 35)
        '
        'BtnExit
        '
        Me.BtnExit.AutoSize = False
        Me.BtnExit.BackgroundImage = Global.GYM.My.Resources.Resources.EXIT_2_22
        Me.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(150, 35)
        Me.BtnExit.Text = "Œ—ÊÃ"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 35)
        Me.ToolStripSeparator12.Visible = False
        '
        'BtnHelp
        '
        Me.BtnHelp.Image = Global.GYM.My.Resources.Resources.Symbol_Help
        Me.BtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(86, 32)
        Me.BtnHelp.Text = "„”«⁄œ…"
        Me.BtnHelp.ToolTipText = "Help"
        Me.BtnHelp.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.NavigationToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1261, 24)
        Me.MenuStrip1.TabIndex = 19
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuNew, Me.MenuSave, Me.MenuDelete, Me.ToolStripSeparator4, Me.MenuExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(36, 20)
        Me.FileToolStripMenuItem.Text = "„·›"
        '
        'MenuNew
        '
        Me.MenuNew.Image = Global.GYM.My.Resources.Resources.Symbol_Add
        Me.MenuNew.Name = "MenuNew"
        Me.MenuNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.MenuNew.Size = New System.Drawing.Size(146, 22)
        Me.MenuNew.Text = "ÃœÌœ"
        Me.MenuNew.Visible = False
        '
        'MenuSave
        '
        Me.MenuSave.Image = Global.GYM.My.Resources.Resources.Save
        Me.MenuSave.Name = "MenuSave"
        Me.MenuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MenuSave.Size = New System.Drawing.Size(146, 22)
        Me.MenuSave.Text = "Õ›Ÿ"
        '
        'MenuDelete
        '
        Me.MenuDelete.Enabled = False
        Me.MenuDelete.Image = Global.GYM.My.Resources.Resources.Symbol_Delete
        Me.MenuDelete.Name = "MenuDelete"
        Me.MenuDelete.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.MenuDelete.Size = New System.Drawing.Size(146, 22)
        Me.MenuDelete.Text = "Õ–›"
        Me.MenuDelete.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(143, 6)
        '
        'MenuExit
        '
        Me.MenuExit.Image = Global.GYM.My.Resources.Resources.ExitRed
        Me.MenuExit.Name = "MenuExit"
        Me.MenuExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.MenuExit.Size = New System.Drawing.Size(146, 22)
        Me.MenuExit.Text = "Œ—ÊÃ"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.CutToolStripMenuItem, Me.PasteToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.EditToolStripMenuItem.Text = " ⁄œÌ·"
        Me.EditToolStripMenuItem.Visible = False
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = Global.GYM.My.Resources.Resources.Copy
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.CopyToolStripMenuItem.Text = "‰”Œ"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = Global.GYM.My.Resources.Resources.Cut
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.CutToolStripMenuItem.Text = "ﬁ’"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = Global.GYM.My.Resources.Resources.paste_256
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.PasteToolStripMenuItem.Text = "·’ﬁ"
        '
        'NavigationToolStripMenuItem
        '
        Me.NavigationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NavigationMenu, Me.PreviousToolStripMenuItem, Me.MenuSearch, Me.CountHitsToolStripMenuItem, Me.MenuReload, Me.MenuCancelSearch})
        Me.NavigationToolStripMenuItem.Name = "NavigationToolStripMenuItem"
        Me.NavigationToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.NavigationToolStripMenuItem.Text = "«·»Ì«‰« "
        '
        'NavigationMenu
        '
        Me.NavigationMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFirst, Me.MenuPrevious, Me.ToolStripSeparator7, Me.MenuNext, Me.MenuLast})
        Me.NavigationMenu.Name = "NavigationMenu"
        Me.NavigationMenu.Size = New System.Drawing.Size(181, 22)
        Me.NavigationMenu.Text = "«· ‰ﬁ· »Ì‰ «·”Ã·« "
        '
        'MenuFirst
        '
        Me.MenuFirst.Image = Global.GYM.My.Resources.Resources.Left
        Me.MenuFirst.Name = "MenuFirst"
        Me.MenuFirst.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.MenuFirst.Size = New System.Drawing.Size(177, 22)
        Me.MenuFirst.Text = "«·”Ã· «·«Ê·"
        '
        'MenuPrevious
        '
        Me.MenuPrevious.Image = Global.GYM.My.Resources.Resources.Previous
        Me.MenuPrevious.Name = "MenuPrevious"
        Me.MenuPrevious.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MenuPrevious.Size = New System.Drawing.Size(177, 22)
        Me.MenuPrevious.Text = "«·”Ã· «·”«»ﬁ"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(174, 6)
        '
        'MenuNext
        '
        Me.MenuNext.Image = Global.GYM.My.Resources.Resources._Next
        Me.MenuNext.Name = "MenuNext"
        Me.MenuNext.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.MenuNext.Size = New System.Drawing.Size(177, 22)
        Me.MenuNext.Text = "«·”Ã· «· «·Ì"
        '
        'MenuLast
        '
        Me.MenuLast.Image = Global.GYM.My.Resources.Resources.FirstRight
        Me.MenuLast.Name = "MenuLast"
        Me.MenuLast.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.MenuLast.Size = New System.Drawing.Size(177, 22)
        Me.MenuLast.Text = "«·”Ã· «·«ŒÌ—"
        '
        'PreviousToolStripMenuItem
        '
        Me.PreviousToolStripMenuItem.Name = "PreviousToolStripMenuItem"
        Me.PreviousToolStripMenuItem.Size = New System.Drawing.Size(178, 6)
        '
        'MenuSearch
        '
        Me.MenuSearch.Image = Global.GYM.My.Resources.Resources.Edit
        Me.MenuSearch.Name = "MenuSearch"
        Me.MenuSearch.Size = New System.Drawing.Size(181, 22)
        Me.MenuSearch.Text = " ⁄œÌ·"
        '
        'CountHitsToolStripMenuItem
        '
        Me.CountHitsToolStripMenuItem.Name = "CountHitsToolStripMenuItem"
        Me.CountHitsToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.CountHitsToolStripMenuItem.Text = "⁄œœ «·”Ã·« "
        '
        'MenuReload
        '
        Me.MenuReload.Name = "MenuReload"
        Me.MenuReload.Size = New System.Drawing.Size(181, 22)
        Me.MenuReload.Text = "«⁄«œ…  Õ„Ì· «·”Ã·« "
        '
        'MenuCancelSearch
        '
        Me.MenuCancelSearch.Name = "MenuCancelSearch"
        Me.MenuCancelSearch.Size = New System.Drawing.Size(181, 22)
        Me.MenuCancelSearch.Text = "«·»ÕÀ «·⁄«„ ·ﬂ· «·”Ã·« "
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutThisWindowToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.HelpToolStripMenuItem.Text = "„”«⁄œ…"
        Me.HelpToolStripMenuItem.Visible = False
        '
        'AboutThisWindowToolStripMenuItem
        '
        Me.AboutThisWindowToolStripMenuItem.Image = Global.GYM.My.Resources.Resources.Symbol_Help
        Me.AboutThisWindowToolStripMenuItem.Name = "AboutThisWindowToolStripMenuItem"
        Me.AboutThisWindowToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.AboutThisWindowToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.AboutThisWindowToolStripMenuItem.Text = "⁄‰ Â–Â «·‰«›–…"
        '
        'ContentPanel
        '
        Me.ContentPanel.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContentPanel.Controls.Add(Me.DataGridView1)
        Me.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentPanel.Location = New System.Drawing.Point(0, 35)
        Me.ContentPanel.Name = "ContentPanel"
        Me.ContentPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContentPanel.Size = New System.Drawing.Size(1284, 715)
        Me.ContentPanel.TabIndex = 20
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_Procedure_Master_ID, Me.Col_Daily_Procedure_Name, Me.Col_Reference_ID, Me.Col_Generic_Desc, Me.Col_Balance, Me.Col_Procedure_Category, Me.Col_Procedure_Type})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.Size = New System.Drawing.Size(1282, 713)
        Me.DataGridView1.TabIndex = 0
        '
        'Col_Procedure_Master_ID
        '
        Me.Col_Procedure_Master_ID.HeaderText = "Procedure_Master_ID"
        Me.Col_Procedure_Master_ID.Name = "Col_Procedure_Master_ID"
        Me.Col_Procedure_Master_ID.Visible = False
        '
        'Col_Daily_Procedure_Name
        '
        Me.Col_Daily_Procedure_Name.HeaderText = "«”„ «·Õ”«»"
        Me.Col_Daily_Procedure_Name.Name = "Col_Daily_Procedure_Name"
        '
        'Col_Reference_ID
        '
        Me.Col_Reference_ID.HeaderText = "ﬂÊœ «·Õ”«»"
        Me.Col_Reference_ID.Name = "Col_Reference_ID"
        Me.Col_Reference_ID.ReadOnly = True
        '
        'Col_Generic_Desc
        '
        Me.Col_Generic_Desc.HeaderText = "Ê’› «·Õ”«»"
        Me.Col_Generic_Desc.Name = "Col_Generic_Desc"
        '
        'Col_Balance
        '
        Me.Col_Balance.HeaderText = "«·—’Ìœ"
        Me.Col_Balance.Name = "Col_Balance"
        '
        'Col_Procedure_Category
        '
        Me.Col_Procedure_Category.HeaderText = "‰Ê⁄ «·Õ”«»"
        Me.Col_Procedure_Category.Items.AddRange(New Object() {"«Ì—«œ«  „ ‰Ê⁄Â", "⁄„·«¡", "„Ê—œÌ‰", "»‰Êﬂ", "Ã«—Ì «·‘—Ìﬂ", "›Ì“«", "√’Ê· À«» Â", "√’Ê· „ œ«Ê·Â", "√—’œÂ „œÌ‰Â", "√—’œÂ œ«∆‰Â", "ÕﬁÊﬁ „·ﬂÌÂ", "Œ’Ê„ „ œ«Ê·Â", "„Ã„⁄ «Â·«ﬂ« ", "„’«—Ì›  ”ÊÌﬁÌÂ", "„’«—Ì› «œ«—ÌÂ", "ﬁ«∆„… «·œŒ·"})
        Me.Col_Procedure_Category.Name = "Col_Procedure_Category"
        '
        'Col_Procedure_Type
        '
        Me.Col_Procedure_Type.HeaderText = "ÿ»Ì⁄… «·Õ”«»"
        Me.Col_Procedure_Type.Items.AddRange(New Object() {"„œÌ‰", "œ«∆‰"})
        Me.Col_Procedure_Type.Name = "Col_Procedure_Type"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Image = Global.GYM.My.Resources.Resources.FirstRight
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "ToolStripButton7"
        Me.BtnFirst.ToolTipText = "First Item"
        '
        'BtnPervious
        '
        Me.BtnPervious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPervious.Image = Global.GYM.My.Resources.Resources._Next
        Me.BtnPervious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPervious.Name = "BtnPervious"
        Me.BtnPervious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPervious.Text = "ToolStripButton8"
        Me.BtnPervious.ToolTipText = "Previous Item"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(39, 22)
        Me.ToolStripLabel1.Text = "«· — Ì»"
        '
        'OrderByCombo
        '
        Me.OrderByCombo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.OrderByCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OrderByCombo.Name = "OrderByCombo"
        Me.OrderByCombo.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Image = Global.GYM.My.Resources.Resources.Previous
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "ToolStripButton9"
        Me.BtnNext.ToolTipText = "Next Item"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Image = Global.GYM.My.Resources.Resources.Left
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "ToolStripButton10"
        Me.BtnLast.ToolTipText = "Last Item"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Image = Global.GYM.My.Resources.Resources.rar_256
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(86, 22)
        Me.ToolStripLabel2.Text = "⁄œœ «·”Ã·«  :"
        '
        'CountRecords
        '
        Me.CountRecords.Name = "CountRecords"
        Me.CountRecords.Size = New System.Drawing.Size(13, 22)
        Me.CountRecords.Text = "0"
        '
        'NavigationBar
        '
        Me.NavigationBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.NavigationBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.NavigationBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.NavigationBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnFirst, Me.BtnPervious, Me.ToolStripSeparator6, Me.ToolStripLabel1, Me.OrderByCombo, Me.ToolStripSeparator9, Me.BtnNext, Me.BtnLast, Me.ToolStripSeparator10, Me.ToolStripLabel2, Me.CountRecords})
        Me.NavigationBar.Location = New System.Drawing.Point(0, 725)
        Me.NavigationBar.Name = "NavigationBar"
        Me.NavigationBar.Size = New System.Drawing.Size(1261, 25)
        Me.NavigationBar.TabIndex = 18
        Me.NavigationBar.Text = "ToolStrip2"
        Me.NavigationBar.Visible = False
        '
        'DailyProcedures
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1284, 750)
        Me.Controls.Add(Me.ContentPanel)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.NavigationBar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "DailyProcedures"
        Me.RightToLeftLayout = True
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContentPanel.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavigationBar.ResumeLayout(False)
        Me.NavigationBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NavigationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NavigationMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreviousToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CountHitsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuFirst As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPrevious As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuNext As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuLast As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutThisWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContentPanel As System.Windows.Forms.Panel
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuReload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuCancelSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BtnFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPervious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents OrderByCombo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CountRecords As System.Windows.Forms.ToolStripLabel
    Friend WithEvents NavigationBar As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Col_Procedure_Master_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Daily_Procedure_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Reference_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Generic_Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Balance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Procedure_Category As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Col_Procedure_Type As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
