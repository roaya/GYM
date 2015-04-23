<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckDetails
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckDetails))
        Me.GroupDetails = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Col_Serial_PK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Check_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Item_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Item_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_System_Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_User_Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Diff_Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Expired_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Check_Type = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Col_Partner_ID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Col_Employee_ID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ContentPanel = New System.Windows.Forms.Panel()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckID = New System.Windows.Forms.ComboBox()
        Me.RadioCheckClosed = New System.Windows.Forms.RadioButton()
        Me.RadioCheckOpened = New System.Windows.Forms.RadioButton()
        Me.GeneralLabel1 = New GYM.GeneralLabel()
        Me.GeneralLabel10 = New GYM.GeneralLabel()
        Me.GroupDetails.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContentPanel.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupDetails
        '
        Me.GroupDetails.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GroupDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GroupDetails.Controls.Add(Me.Panel3)
        Me.GroupDetails.Location = New System.Drawing.Point(10, 264)
        Me.GroupDetails.Name = "GroupDetails"
        Me.GroupDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupDetails.Size = New System.Drawing.Size(1346, 479)
        Me.GroupDetails.TabIndex = 114
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1342, 475)
        Me.Panel3.TabIndex = 20
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_Serial_PK, Me.Col_Check_ID, Me.Col_Item_ID, Me.Col_Item_Name, Me.Col_Barcode, Me.Col_System_Quantity, Me.Col_User_Quantity, Me.Col_Diff_Quantity, Me.Col_Price, Me.Col_Expired_Date, Me.Col_Check_Type, Me.Col_Partner_ID, Me.Col_Employee_ID})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1340, 473)
        Me.DataGridView1.TabIndex = 1
        '
        'Col_Serial_PK
        '
        Me.Col_Serial_PK.HeaderText = "Col_Serial_PK"
        Me.Col_Serial_PK.Name = "Col_Serial_PK"
        Me.Col_Serial_PK.Visible = False
        '
        'Col_Check_ID
        '
        Me.Col_Check_ID.HeaderText = "Col_Check_ID"
        Me.Col_Check_ID.Name = "Col_Check_ID"
        Me.Col_Check_ID.Visible = False
        '
        'Col_Item_ID
        '
        Me.Col_Item_ID.HeaderText = "Col_Item_ID"
        Me.Col_Item_ID.Name = "Col_Item_ID"
        Me.Col_Item_ID.Visible = False
        '
        'Col_Item_Name
        '
        Me.Col_Item_Name.HeaderText = "اسم الصنف"
        Me.Col_Item_Name.Name = "Col_Item_Name"
        Me.Col_Item_Name.ReadOnly = True
        '
        'Col_Barcode
        '
        Me.Col_Barcode.HeaderText = "الباركود"
        Me.Col_Barcode.Name = "Col_Barcode"
        Me.Col_Barcode.ReadOnly = True
        '
        'Col_System_Quantity
        '
        Me.Col_System_Quantity.HeaderText = "العدد الموجود بالبرنامج"
        Me.Col_System_Quantity.Name = "Col_System_Quantity"
        Me.Col_System_Quantity.ReadOnly = True
        '
        'Col_User_Quantity
        '
        Me.Col_User_Quantity.HeaderText = "العدد المدخل"
        Me.Col_User_Quantity.Name = "Col_User_Quantity"
        '
        'Col_Diff_Quantity
        '
        Me.Col_Diff_Quantity.HeaderText = "الفرق"
        Me.Col_Diff_Quantity.Name = "Col_Diff_Quantity"
        Me.Col_Diff_Quantity.ReadOnly = True
        '
        'Col_Price
        '
        Me.Col_Price.HeaderText = "سعر التكلفه"
        Me.Col_Price.Name = "Col_Price"
        Me.Col_Price.ReadOnly = True
        '
        'Col_Expired_Date
        '
        Me.Col_Expired_Date.HeaderText = "تاريخ الصلاحيه"
        Me.Col_Expired_Date.Name = "Col_Expired_Date"
        Me.Col_Expired_Date.ReadOnly = True
        '
        'Col_Check_Type
        '
        Me.Col_Check_Type.HeaderText = "سبب الفرق"
        Me.Col_Check_Type.Items.AddRange(New Object() {"لا يوجد", "طبيعي", "جاري الشركاء", "موظف", "زياده مخزنيه"})
        Me.Col_Check_Type.Name = "Col_Check_Type"
        Me.Col_Check_Type.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_Check_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Col_Partner_ID
        '
        Me.Col_Partner_ID.HeaderText = "جاري الشركاء"
        Me.Col_Partner_ID.Name = "Col_Partner_ID"
        Me.Col_Partner_ID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_Partner_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Col_Employee_ID
        '
        Me.Col_Employee_ID.HeaderText = "الموظف المسئول"
        Me.Col_Employee_ID.Name = "Col_Employee_ID"
        Me.Col_Employee_ID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_Employee_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ContentPanel
        '
        Me.ContentPanel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContentPanel.Controls.Add(Me.BtnPrint)
        Me.ContentPanel.Controls.Add(Me.BtnSave)
        Me.ContentPanel.Controls.Add(Me.BtnExit)
        Me.ContentPanel.Controls.Add(Me.BtnNew)
        Me.ContentPanel.Controls.Add(Me.GroupBox1)
        Me.ContentPanel.Controls.Add(Me.GroupDetails)
        Me.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentPanel.Location = New System.Drawing.Point(0, 0)
        Me.ContentPanel.Name = "ContentPanel"
        Me.ContentPanel.Size = New System.Drawing.Size(1290, 748)
        Me.ContentPanel.TabIndex = 116
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.BackgroundImage = CType(resources.GetObject("BtnPrint.BackgroundImage"), System.Drawing.Image)
        Me.BtnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPrint.FlatAppearance.BorderSize = 0
        Me.BtnPrint.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Location = New System.Drawing.Point(744, 25)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(171, 44)
        Me.BtnPrint.TabIndex = 120
        Me.BtnPrint.Text = "طباعه"
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Location = New System.Drawing.Point(947, 25)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(171, 44)
        Me.BtnSave.TabIndex = 119
        Me.BtnSave.Text = "حفظ"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.Transparent
        Me.BtnExit.BackgroundImage = CType(resources.GetObject("BtnExit.BackgroundImage"), System.Drawing.Image)
        Me.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnExit.FlatAppearance.BorderSize = 0
        Me.BtnExit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BtnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExit.Location = New System.Drawing.Point(541, 25)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(171, 44)
        Me.BtnExit.TabIndex = 118
        Me.BtnExit.Text = "خروج"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.Transparent
        Me.BtnNew.BackgroundImage = CType(resources.GetObject("BtnNew.BackgroundImage"), System.Drawing.Image)
        Me.BtnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNew.FlatAppearance.BorderSize = 0
        Me.BtnNew.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BtnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Location = New System.Drawing.Point(1150, 25)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(171, 44)
        Me.BtnNew.TabIndex = 117
        Me.BtnNew.Text = "استعلام"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CheckID)
        Me.GroupBox1.Controls.Add(Me.RadioCheckClosed)
        Me.GroupBox1.Controls.Add(Me.RadioCheckOpened)
        Me.GroupBox1.Controls.Add(Me.GeneralLabel1)
        Me.GroupBox1.Controls.Add(Me.GeneralLabel10)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(10, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(1346, 126)
        Me.GroupBox1.TabIndex = 116
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "البيانات العامة للأصناف"
        '
        'CheckID
        '
        Me.CheckID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CheckID.FormattingEnabled = True
        Me.CheckID.Location = New System.Drawing.Point(796, 55)
        Me.CheckID.Name = "CheckID"
        Me.CheckID.Size = New System.Drawing.Size(278, 26)
        Me.CheckID.TabIndex = 58
        '
        'RadioCheckClosed
        '
        Me.RadioCheckClosed.AutoSize = True
        Me.RadioCheckClosed.Location = New System.Drawing.Point(139, 56)
        Me.RadioCheckClosed.Name = "RadioCheckClosed"
        Me.RadioCheckClosed.Size = New System.Drawing.Size(59, 22)
        Me.RadioCheckClosed.TabIndex = 57
        Me.RadioCheckClosed.Text = "مغلق"
        Me.RadioCheckClosed.UseVisualStyleBackColor = True
        '
        'RadioCheckOpened
        '
        Me.RadioCheckOpened.AutoSize = True
        Me.RadioCheckOpened.Checked = True
        Me.RadioCheckOpened.Location = New System.Drawing.Point(262, 56)
        Me.RadioCheckOpened.Name = "RadioCheckOpened"
        Me.RadioCheckOpened.Size = New System.Drawing.Size(63, 22)
        Me.RadioCheckOpened.TabIndex = 56
        Me.RadioCheckOpened.TabStop = True
        Me.RadioCheckOpened.Text = "مفتوح"
        Me.RadioCheckOpened.UseVisualStyleBackColor = True
        '
        'GeneralLabel1
        '
        Me.GeneralLabel1.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel1.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel1.IsRequired = False
        Me.GeneralLabel1.Location = New System.Drawing.Point(362, 55)
        Me.GeneralLabel1.Name = "GeneralLabel1"
        Me.GeneralLabel1.SetLabelTxt = "حالة الجرد :"
        Me.GeneralLabel1.Size = New System.Drawing.Size(123, 26)
        Me.GeneralLabel1.TabIndex = 55
        '
        'GeneralLabel10
        '
        Me.GeneralLabel10.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel10.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel10.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel10.IsRequired = False
        Me.GeneralLabel10.Location = New System.Drawing.Point(1078, 55)
        Me.GeneralLabel10.Name = "GeneralLabel10"
        Me.GeneralLabel10.SetLabelTxt = "اسم الجرد :"
        Me.GeneralLabel10.Size = New System.Drawing.Size(129, 26)
        Me.GeneralLabel10.TabIndex = 53
        '
        'CheckDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1290, 748)
        Me.Controls.Add(Me.ContentPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CheckDetails"
        Me.RightToLeftLayout = True
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تفاصيل الجرد"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupDetails.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContentPanel.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupDetails As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ContentPanel As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GeneralLabel10 As GYM.GeneralLabel
    Friend WithEvents RadioCheckClosed As System.Windows.Forms.RadioButton
    Friend WithEvents RadioCheckOpened As System.Windows.Forms.RadioButton
    Friend WithEvents GeneralLabel1 As GYM.GeneralLabel
    Friend WithEvents CheckID As System.Windows.Forms.ComboBox
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Col_Serial_PK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Check_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Item_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Item_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_System_Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_User_Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Diff_Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Expired_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Check_Type As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Col_Partner_ID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Col_Employee_ID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
End Class
