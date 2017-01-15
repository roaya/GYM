<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class salarygroups
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
        Me.GeneralLabel4 = New GYM.GeneralLabel()
        Me.ContentPanel = New System.Windows.Forms.Panel()
        Me.GeneralLabel11 = New GYM.GeneralLabel()
        Me.GenericDesc = New GYM.GeneralTextBox()
        Me.GeneralLabel9 = New GYM.GeneralLabel()
        Me.GeneralLabel8 = New GYM.GeneralLabel()
        Me.GeneralLabel7 = New GYM.GeneralLabel()
        Me.GeneralLabel6 = New GYM.GeneralLabel()
        Me.GeneralLabel5 = New GYM.GeneralLabel()
        Me.Subsc_Value = New System.Windows.Forms.NumericUpDown()
        Me.Custs_Disc = New System.Windows.Forms.NumericUpDown()
        Me.Extra_Custs = New System.Windows.Forms.NumericUpDown()
        Me.Min_Custs = New System.Windows.Forms.NumericUpDown()
        Me.Hours_Disc = New System.Windows.Forms.NumericUpDown()
        Me.Extra_Hours = New System.Windows.Forms.NumericUpDown()
        Me.Work_Hours = New System.Windows.Forms.NumericUpDown()
        Me.Min_Hours = New System.Windows.Forms.NumericUpDown()
        Me.MasterField1 = New GYM.MasterField()
        Me.GeneralLabel3 = New GYM.GeneralLabel()
        Me.GeneralLabel2 = New GYM.GeneralLabel()
        Me.GeneralLabel1 = New GYM.GeneralLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnLast = New System.Windows.Forms.Button()
        Me.OrderByCombo = New System.Windows.Forms.ComboBox()
        Me.BtnNext = New System.Windows.Forms.Button()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnReload = New System.Windows.Forms.Button()
        Me.BtnHelp = New System.Windows.Forms.Button()
        Me.BtnCancelSerach = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BtnPrevious = New System.Windows.Forms.Button()
        Me.BtnData = New System.Windows.Forms.Button()
        Me.CountRecords = New System.Windows.Forms.Label()
        Me.BtnFirst = New System.Windows.Forms.Button()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.BtnFile = New System.Windows.Forms.Button()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.GeneralLabel10 = New GYM.GeneralLabel()
        Me.GeneralLabel12 = New GYM.GeneralLabel()
        Me.GeneralLabel13 = New GYM.GeneralLabel()
        Me.Loan_Duration_Limit = New System.Windows.Forms.NumericUpDown()
        Me.Loan_Pay_Limit = New System.Windows.Forms.NumericUpDown()
        Me.Loan_Value_Limit = New System.Windows.Forms.NumericUpDown()
        Me.ContentPanel.SuspendLayout
        CType(Me.Subsc_Value,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Custs_Disc,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Extra_Custs,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Min_Custs,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Hours_Disc,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Extra_Hours,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Work_Hours,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Min_Hours,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Loan_Duration_Limit,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Loan_Pay_Limit,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Loan_Value_Limit,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'GeneralLabel4
        '
        Me.GeneralLabel4.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel4.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel4.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GeneralLabel4.IsRequired = true
        Me.GeneralLabel4.Location = New System.Drawing.Point(411, 204)
        Me.GeneralLabel4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel4.Name = "GeneralLabel4"
        Me.GeneralLabel4.SetLabelTxt = "اضافي الحضور للساعة :"
        Me.GeneralLabel4.Size = New System.Drawing.Size(224, 32)
        Me.GeneralLabel4.TabIndex = 25
        Me.GeneralLabel4.TabStop = false
        '
        'ContentPanel
        '
        Me.ContentPanel.BackColor = System.Drawing.Color.Transparent
        Me.ContentPanel.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ContentPanel.Controls.Add(Me.GeneralLabel10)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel12)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel13)
        Me.ContentPanel.Controls.Add(Me.Loan_Duration_Limit)
        Me.ContentPanel.Controls.Add(Me.Loan_Pay_Limit)
        Me.ContentPanel.Controls.Add(Me.Loan_Value_Limit)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel11)
        Me.ContentPanel.Controls.Add(Me.GenericDesc)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel9)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel8)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel7)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel6)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel5)
        Me.ContentPanel.Controls.Add(Me.Subsc_Value)
        Me.ContentPanel.Controls.Add(Me.Custs_Disc)
        Me.ContentPanel.Controls.Add(Me.Extra_Custs)
        Me.ContentPanel.Controls.Add(Me.Min_Custs)
        Me.ContentPanel.Controls.Add(Me.Hours_Disc)
        Me.ContentPanel.Controls.Add(Me.Extra_Hours)
        Me.ContentPanel.Controls.Add(Me.Work_Hours)
        Me.ContentPanel.Controls.Add(Me.Min_Hours)
        Me.ContentPanel.Controls.Add(Me.MasterField1)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel4)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel3)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel2)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel1)
        Me.ContentPanel.Location = New System.Drawing.Point(15, 113)
        Me.ContentPanel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ContentPanel.Name = "ContentPanel"
        Me.ContentPanel.Size = New System.Drawing.Size(674, 741)
        Me.ContentPanel.TabIndex = 130
        '
        'GeneralLabel11
        '
        Me.GeneralLabel11.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel11.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel11.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GeneralLabel11.IsRequired = false
        Me.GeneralLabel11.Location = New System.Drawing.Point(406, 643)
        Me.GeneralLabel11.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel11.Name = "GeneralLabel11"
        Me.GeneralLabel11.SetLabelTxt = "الوصف :"
        Me.GeneralLabel11.Size = New System.Drawing.Size(224, 32)
        Me.GeneralLabel11.TabIndex = 167
        Me.GeneralLabel11.TabStop = false
        '
        'GenericDesc
        '
        Me.GenericDesc.BackColor = System.Drawing.Color.Gainsboro
        Me.GenericDesc.Font = New System.Drawing.Font("Tahoma", 11!)
        Me.GenericDesc.IsEmail = false
        Me.GenericDesc.IsNum = false
        Me.GenericDesc.IsRequired = false
        Me.GenericDesc.Location = New System.Drawing.Point(50, 642)
        Me.GenericDesc.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.GenericDesc.Name = "GenericDesc"
        Me.GenericDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GenericDesc.SetLeaveColor = System.Drawing.SystemColors.ActiveCaption
        Me.GenericDesc.Size = New System.Drawing.Size(328, 33)
        Me.GenericDesc.TabIndex = 166
        '
        'GeneralLabel9
        '
        Me.GeneralLabel9.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel9.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel9.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GeneralLabel9.IsRequired = false
        Me.GeneralLabel9.Location = New System.Drawing.Point(411, 447)
        Me.GeneralLabel9.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel9.Name = "GeneralLabel9"
        Me.GeneralLabel9.SetLabelTxt = "نسبة الاشتراك الخاص :"
        Me.GeneralLabel9.Size = New System.Drawing.Size(224, 32)
        Me.GeneralLabel9.TabIndex = 164
        Me.GeneralLabel9.TabStop = false
        '
        'GeneralLabel8
        '
        Me.GeneralLabel8.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel8.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel8.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GeneralLabel8.IsRequired = false
        Me.GeneralLabel8.Location = New System.Drawing.Point(411, 398)
        Me.GeneralLabel8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel8.Name = "GeneralLabel8"
        Me.GeneralLabel8.SetLabelTxt = "خصم العملاء :"
        Me.GeneralLabel8.Size = New System.Drawing.Size(224, 32)
        Me.GeneralLabel8.TabIndex = 163
        Me.GeneralLabel8.TabStop = false
        '
        'GeneralLabel7
        '
        Me.GeneralLabel7.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel7.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel7.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GeneralLabel7.IsRequired = false
        Me.GeneralLabel7.Location = New System.Drawing.Point(411, 348)
        Me.GeneralLabel7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel7.Name = "GeneralLabel7"
        Me.GeneralLabel7.SetLabelTxt = "اضافي العملاء :"
        Me.GeneralLabel7.Size = New System.Drawing.Size(224, 32)
        Me.GeneralLabel7.TabIndex = 162
        Me.GeneralLabel7.TabStop = false
        '
        'GeneralLabel6
        '
        Me.GeneralLabel6.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel6.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel6.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GeneralLabel6.IsRequired = false
        Me.GeneralLabel6.Location = New System.Drawing.Point(411, 299)
        Me.GeneralLabel6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel6.Name = "GeneralLabel6"
        Me.GeneralLabel6.SetLabelTxt = "الحد الادنى للعملاء :"
        Me.GeneralLabel6.Size = New System.Drawing.Size(224, 32)
        Me.GeneralLabel6.TabIndex = 161
        Me.GeneralLabel6.TabStop = false
        '
        'GeneralLabel5
        '
        Me.GeneralLabel5.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel5.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel5.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GeneralLabel5.IsRequired = true
        Me.GeneralLabel5.Location = New System.Drawing.Point(411, 250)
        Me.GeneralLabel5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel5.Name = "GeneralLabel5"
        Me.GeneralLabel5.SetLabelTxt = "خصم الحضور للساعة :"
        Me.GeneralLabel5.Size = New System.Drawing.Size(224, 32)
        Me.GeneralLabel5.TabIndex = 160
        Me.GeneralLabel5.TabStop = false
        '
        'Subsc_Value
        '
        Me.Subsc_Value.BackColor = System.Drawing.Color.Gainsboro
        Me.Subsc_Value.DecimalPlaces = 2
        Me.Subsc_Value.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Subsc_Value.Location = New System.Drawing.Point(52, 446)
        Me.Subsc_Value.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Subsc_Value.Name = "Subsc_Value"
        Me.Subsc_Value.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Subsc_Value.Size = New System.Drawing.Size(328, 30)
        Me.Subsc_Value.TabIndex = 158
        Me.Subsc_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Custs_Disc
        '
        Me.Custs_Disc.BackColor = System.Drawing.Color.Gainsboro
        Me.Custs_Disc.DecimalPlaces = 2
        Me.Custs_Disc.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Custs_Disc.Location = New System.Drawing.Point(52, 396)
        Me.Custs_Disc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Custs_Disc.Maximum = New Decimal(New Integer() {276447232, 23283, 0, 0})
        Me.Custs_Disc.Name = "Custs_Disc"
        Me.Custs_Disc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Custs_Disc.Size = New System.Drawing.Size(328, 30)
        Me.Custs_Disc.TabIndex = 157
        Me.Custs_Disc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Extra_Custs
        '
        Me.Extra_Custs.BackColor = System.Drawing.Color.Gainsboro
        Me.Extra_Custs.DecimalPlaces = 2
        Me.Extra_Custs.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Extra_Custs.Location = New System.Drawing.Point(52, 347)
        Me.Extra_Custs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Extra_Custs.Maximum = New Decimal(New Integer() {276447232, 23283, 0, 0})
        Me.Extra_Custs.Name = "Extra_Custs"
        Me.Extra_Custs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Extra_Custs.Size = New System.Drawing.Size(328, 30)
        Me.Extra_Custs.TabIndex = 156
        Me.Extra_Custs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Min_Custs
        '
        Me.Min_Custs.BackColor = System.Drawing.Color.Gainsboro
        Me.Min_Custs.DecimalPlaces = 2
        Me.Min_Custs.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Min_Custs.Location = New System.Drawing.Point(52, 298)
        Me.Min_Custs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Min_Custs.Maximum = New Decimal(New Integer() {276447232, 23283, 0, 0})
        Me.Min_Custs.Name = "Min_Custs"
        Me.Min_Custs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Min_Custs.Size = New System.Drawing.Size(328, 30)
        Me.Min_Custs.TabIndex = 155
        Me.Min_Custs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Hours_Disc
        '
        Me.Hours_Disc.BackColor = System.Drawing.Color.Gainsboro
        Me.Hours_Disc.DecimalPlaces = 2
        Me.Hours_Disc.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Hours_Disc.Location = New System.Drawing.Point(52, 249)
        Me.Hours_Disc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Hours_Disc.Maximum = New Decimal(New Integer() {276447232, 23283, 0, 0})
        Me.Hours_Disc.Name = "Hours_Disc"
        Me.Hours_Disc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Hours_Disc.Size = New System.Drawing.Size(328, 30)
        Me.Hours_Disc.TabIndex = 154
        Me.Hours_Disc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Extra_Hours
        '
        Me.Extra_Hours.BackColor = System.Drawing.Color.Gainsboro
        Me.Extra_Hours.DecimalPlaces = 2
        Me.Extra_Hours.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Extra_Hours.Location = New System.Drawing.Point(52, 203)
        Me.Extra_Hours.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Extra_Hours.Maximum = New Decimal(New Integer() {276447232, 23283, 0, 0})
        Me.Extra_Hours.Name = "Extra_Hours"
        Me.Extra_Hours.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Extra_Hours.Size = New System.Drawing.Size(328, 30)
        Me.Extra_Hours.TabIndex = 153
        Me.Extra_Hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Work_Hours
        '
        Me.Work_Hours.BackColor = System.Drawing.Color.Gainsboro
        Me.Work_Hours.DecimalPlaces = 2
        Me.Work_Hours.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Work_Hours.Location = New System.Drawing.Point(52, 154)
        Me.Work_Hours.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Work_Hours.Maximum = New Decimal(New Integer() {276447232, 23283, 0, 0})
        Me.Work_Hours.Name = "Work_Hours"
        Me.Work_Hours.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Work_Hours.Size = New System.Drawing.Size(328, 30)
        Me.Work_Hours.TabIndex = 152
        Me.Work_Hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Min_Hours
        '
        Me.Min_Hours.BackColor = System.Drawing.Color.Gainsboro
        Me.Min_Hours.DecimalPlaces = 2
        Me.Min_Hours.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Min_Hours.Location = New System.Drawing.Point(52, 105)
        Me.Min_Hours.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Min_Hours.Maximum = New Decimal(New Integer() {276447232, 23283, 0, 0})
        Me.Min_Hours.Name = "Min_Hours"
        Me.Min_Hours.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Min_Hours.Size = New System.Drawing.Size(328, 30)
        Me.Min_Hours.TabIndex = 151
        Me.Min_Hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MasterField1
        '
        Me.MasterField1.BackColor = System.Drawing.Color.Gainsboro
        Me.MasterField1.EnableField = true
        Me.MasterField1.EnableLockup = true
        Me.MasterField1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.MasterField1.IsNum = false
        Me.MasterField1.IsRequired = true
        Me.MasterField1.Location = New System.Drawing.Point(52, 52)
        Me.MasterField1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.MasterField1.Name = "MasterField1"
        Me.MasterField1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MasterField1.SetDisplayMember = "Stocks.Stock_Name"
        Me.MasterField1.SetLeaveColor = System.Drawing.SystemColors.ActiveCaption
        Me.MasterField1.SetLockupImage = Nothing
        Me.MasterField1.SetValueMember = "Stocks.Stock_ID"
        Me.MasterField1.Size = New System.Drawing.Size(328, 34)
        Me.MasterField1.TabIndex = 150
        '
        'GeneralLabel3
        '
        Me.GeneralLabel3.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel3.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel3.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GeneralLabel3.IsRequired = true
        Me.GeneralLabel3.Location = New System.Drawing.Point(411, 111)
        Me.GeneralLabel3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel3.Name = "GeneralLabel3"
        Me.GeneralLabel3.SetLabelTxt = "الحد الادنى للساعات :"
        Me.GeneralLabel3.Size = New System.Drawing.Size(224, 34)
        Me.GeneralLabel3.TabIndex = 24
        Me.GeneralLabel3.TabStop = false
        '
        'GeneralLabel2
        '
        Me.GeneralLabel2.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel2.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GeneralLabel2.IsRequired = true
        Me.GeneralLabel2.Location = New System.Drawing.Point(411, 155)
        Me.GeneralLabel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel2.Name = "GeneralLabel2"
        Me.GeneralLabel2.SetLabelTxt = "ساعات العمل :"
        Me.GeneralLabel2.Size = New System.Drawing.Size(224, 32)
        Me.GeneralLabel2.TabIndex = 23
        Me.GeneralLabel2.TabStop = false
        '
        'GeneralLabel1
        '
        Me.GeneralLabel1.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel1.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GeneralLabel1.IsRequired = true
        Me.GeneralLabel1.Location = New System.Drawing.Point(411, 52)
        Me.GeneralLabel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel1.Name = "GeneralLabel1"
        Me.GeneralLabel1.SetLabelTxt = "اسم المجموعه :"
        Me.GeneralLabel1.Size = New System.Drawing.Size(224, 34)
        Me.GeneralLabel1.TabIndex = 5
        Me.GeneralLabel1.TabStop = false
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(92, 867)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(137, 24)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "عدد السجلات :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnLast
        '
        Me.BtnLast.BackColor = System.Drawing.Color.Transparent
        Me.BtnLast.BackgroundImage = Global.GYM.My.Resources.Resources.master_16
        Me.BtnLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnLast.FlatAppearance.BorderSize = 0
        Me.BtnLast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnLast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLast.Location = New System.Drawing.Point(250, 871)
        Me.BtnLast.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(19, 20)
        Me.BtnLast.TabIndex = 142
        Me.BtnLast.TabStop = false
        Me.BtnLast.Text = "دخول"
        Me.BtnLast.UseVisualStyleBackColor = false
        '
        'OrderByCombo
        '
        Me.OrderByCombo.BackColor = System.Drawing.Color.Gainsboro
        Me.OrderByCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OrderByCombo.FormattingEnabled = true
        Me.OrderByCombo.Location = New System.Drawing.Point(323, 870)
        Me.OrderByCombo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.OrderByCombo.Name = "OrderByCombo"
        Me.OrderByCombo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.OrderByCombo.Size = New System.Drawing.Size(175, 24)
        Me.OrderByCombo.TabIndex = 140
        Me.OrderByCombo.TabStop = false
        '
        'BtnNext
        '
        Me.BtnNext.BackColor = System.Drawing.Color.Transparent
        Me.BtnNext.BackgroundImage = Global.GYM.My.Resources.Resources.master_18
        Me.BtnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNext.FlatAppearance.BorderSize = 0
        Me.BtnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNext.Location = New System.Drawing.Point(289, 871)
        Me.BtnNext.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(19, 20)
        Me.BtnNext.TabIndex = 141
        Me.BtnNext.TabStop = false
        Me.BtnNext.Text = "دخول"
        Me.BtnNext.UseVisualStyleBackColor = false
        '
        'UsernameLabel
        '
        Me.UsernameLabel.AutoSize = true
        Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
        Me.UsernameLabel.Font = New System.Drawing.Font("Tahoma", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.UsernameLabel.ForeColor = System.Drawing.Color.White
        Me.UsernameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsernameLabel.Location = New System.Drawing.Point(506, 867)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(68, 24)
        Me.UsernameLabel.TabIndex = 139
        Me.UsernameLabel.Text = "الترتيب"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.Transparent
        Me.BtnDelete.BackgroundImage = Global.GYM.My.Resources.Resources.delete_1_21
        Me.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnDelete.Location = New System.Drawing.Point(667, 389)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(176, 70)
        Me.BtnDelete.TabIndex = 135
        Me.BtnDelete.TabStop = false
        Me.BtnDelete.Text = "حذف"
        Me.BtnDelete.UseVisualStyleBackColor = false
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = Global.GYM.My.Resources.Resources.save_18_18
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnSave.Location = New System.Drawing.Point(667, 234)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(176, 70)
        Me.BtnSave.TabIndex = 132
        Me.BtnSave.TabStop = false
        Me.BtnSave.Text = "حفظ"
        Me.BtnSave.UseVisualStyleBackColor = false
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.Transparent
        Me.BtnNew.BackgroundImage = Global.GYM.My.Resources.Resources.without_text_16
        Me.BtnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNew.FlatAppearance.BorderSize = 0
        Me.BtnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnNew.Location = New System.Drawing.Point(667, 156)
        Me.BtnNew.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(176, 70)
        Me.BtnNew.TabIndex = 131
        Me.BtnNew.TabStop = false
        Me.BtnNew.Text = "جديد"
        Me.BtnNew.UseVisualStyleBackColor = false
        '
        'BtnReload
        '
        Me.BtnReload.BackColor = System.Drawing.Color.Transparent
        Me.BtnReload.BackgroundImage = Global.GYM.My.Resources.Resources.without_texte_2_16
        Me.BtnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnReload.FlatAppearance.BorderSize = 0
        Me.BtnReload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnReload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnReload.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnReload.Location = New System.Drawing.Point(667, 156)
        Me.BtnReload.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnReload.Name = "BtnReload"
        Me.BtnReload.Size = New System.Drawing.Size(176, 70)
        Me.BtnReload.TabIndex = 148
        Me.BtnReload.TabStop = false
        Me.BtnReload.Text = "تحميل"
        Me.BtnReload.UseVisualStyleBackColor = false
        Me.BtnReload.Visible = false
        '
        'BtnHelp
        '
        Me.BtnHelp.BackColor = System.Drawing.Color.Transparent
        Me.BtnHelp.BackgroundImage = Global.GYM.My.Resources.Resources.master_03
        Me.BtnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnHelp.FlatAppearance.BorderSize = 0
        Me.BtnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHelp.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnHelp.Location = New System.Drawing.Point(232, 28)
        Me.BtnHelp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(147, 70)
        Me.BtnHelp.TabIndex = 147
        Me.BtnHelp.TabStop = false
        Me.BtnHelp.UseVisualStyleBackColor = false
        '
        'BtnCancelSerach
        '
        Me.BtnCancelSerach.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancelSerach.BackgroundImage = Global.GYM.My.Resources.Resources.save_2_18
        Me.BtnCancelSerach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCancelSerach.FlatAppearance.BorderSize = 0
        Me.BtnCancelSerach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnCancelSerach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnCancelSerach.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelSerach.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnCancelSerach.Location = New System.Drawing.Point(667, 234)
        Me.BtnCancelSerach.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCancelSerach.Name = "BtnCancelSerach"
        Me.BtnCancelSerach.Size = New System.Drawing.Size(176, 70)
        Me.BtnCancelSerach.TabIndex = 149
        Me.BtnCancelSerach.TabStop = false
        Me.BtnCancelSerach.Text = "بحث عام"
        Me.BtnCancelSerach.UseVisualStyleBackColor = false
        Me.BtnCancelSerach.Visible = false
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.AutoUpgradeEnabled = false
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrevious.BackgroundImage = Global.GYM.My.Resources.Resources.master_18_copy
        Me.BtnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPrevious.FlatAppearance.BorderSize = 0
        Me.BtnPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrevious.Location = New System.Drawing.Point(586, 871)
        Me.BtnPrevious.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(19, 20)
        Me.BtnPrevious.TabIndex = 138
        Me.BtnPrevious.TabStop = false
        Me.BtnPrevious.Text = "دخول"
        Me.BtnPrevious.UseVisualStyleBackColor = false
        '
        'BtnData
        '
        Me.BtnData.BackColor = System.Drawing.Color.Transparent
        Me.BtnData.BackgroundImage = Global.GYM.My.Resources.Resources.master_05
        Me.BtnData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnData.FlatAppearance.BorderSize = 0
        Me.BtnData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnData.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnData.Location = New System.Drawing.Point(390, 28)
        Me.BtnData.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnData.Name = "BtnData"
        Me.BtnData.Size = New System.Drawing.Size(147, 70)
        Me.BtnData.TabIndex = 146
        Me.BtnData.TabStop = false
        Me.BtnData.UseVisualStyleBackColor = false
        '
        'CountRecords
        '
        Me.CountRecords.BackColor = System.Drawing.Color.Transparent
        Me.CountRecords.Font = New System.Drawing.Font("Tahoma", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.CountRecords.ForeColor = System.Drawing.Color.White
        Me.CountRecords.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CountRecords.Location = New System.Drawing.Point(40, 867)
        Me.CountRecords.Name = "CountRecords"
        Me.CountRecords.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CountRecords.Size = New System.Drawing.Size(52, 23)
        Me.CountRecords.TabIndex = 144
        Me.CountRecords.Text = "0"
        Me.CountRecords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnFirst
        '
        Me.BtnFirst.BackColor = System.Drawing.Color.Transparent
        Me.BtnFirst.BackgroundImage = Global.GYM.My.Resources.Resources.master_16_copy
        Me.BtnFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFirst.FlatAppearance.BorderSize = 0
        Me.BtnFirst.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnFirst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFirst.Location = New System.Drawing.Point(625, 871)
        Me.BtnFirst.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(19, 20)
        Me.BtnFirst.TabIndex = 137
        Me.BtnFirst.TabStop = false
        Me.BtnFirst.Text = "دخول"
        Me.BtnFirst.UseVisualStyleBackColor = false
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Location = New System.Drawing.Point(61, 27)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(139, 79)
        Me.PictureBox5.TabIndex = 136
        Me.PictureBox5.TabStop = false
        '
        'BtnFile
        '
        Me.BtnFile.BackColor = System.Drawing.Color.Transparent
        Me.BtnFile.BackgroundImage = Global.GYM.My.Resources.Resources.master_09Selected
        Me.BtnFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFile.FlatAppearance.BorderSize = 0
        Me.BtnFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFile.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnFile.Location = New System.Drawing.Point(547, 28)
        Me.BtnFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnFile.Name = "BtnFile"
        Me.BtnFile.Size = New System.Drawing.Size(147, 70)
        Me.BtnFile.TabIndex = 145
        Me.BtnFile.TabStop = false
        Me.BtnFile.UseVisualStyleBackColor = false
        '
        'BtnSearch
        '
        Me.BtnSearch.BackColor = System.Drawing.Color.Transparent
        Me.BtnSearch.BackgroundImage = Global.GYM.My.Resources.Resources.edit_1_19
        Me.BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSearch.FlatAppearance.BorderSize = 0
        Me.BtnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSearch.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnSearch.Location = New System.Drawing.Point(667, 311)
        Me.BtnSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(176, 70)
        Me.BtnSearch.TabIndex = 133
        Me.BtnSearch.TabStop = false
        Me.BtnSearch.Text = "تعديل"
        Me.BtnSearch.UseVisualStyleBackColor = false
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.Transparent
        Me.BtnExit.BackgroundImage = Global.GYM.My.Resources.Resources.exit_22
        Me.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnExit.FlatAppearance.BorderSize = 0
        Me.BtnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExit.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnExit.Location = New System.Drawing.Point(667, 466)
        Me.BtnExit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(176, 70)
        Me.BtnExit.TabIndex = 134
        Me.BtnExit.TabStop = false
        Me.BtnExit.Text = "خروج"
        Me.BtnExit.UseVisualStyleBackColor = false
        '
        'GeneralLabel10
        '
        Me.GeneralLabel10.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel10.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel10.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GeneralLabel10.IsRequired = false
        Me.GeneralLabel10.Location = New System.Drawing.Point(405, 597)
        Me.GeneralLabel10.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel10.Name = "GeneralLabel10"
        Me.GeneralLabel10.SetLabelTxt = "الحد الأقصى للمدة :"
        Me.GeneralLabel10.Size = New System.Drawing.Size(224, 32)
        Me.GeneralLabel10.TabIndex = 173
        Me.GeneralLabel10.TabStop = false
        '
        'GeneralLabel12
        '
        Me.GeneralLabel12.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel12.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel12.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GeneralLabel12.IsRequired = false
        Me.GeneralLabel12.Location = New System.Drawing.Point(405, 548)
        Me.GeneralLabel12.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel12.Name = "GeneralLabel12"
        Me.GeneralLabel12.SetLabelTxt = "الحد الأقصى للدفعة :"
        Me.GeneralLabel12.Size = New System.Drawing.Size(224, 32)
        Me.GeneralLabel12.TabIndex = 172
        Me.GeneralLabel12.TabStop = false
        '
        'GeneralLabel13
        '
        Me.GeneralLabel13.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel13.BackgroundImage = Global.GYM.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel13.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GeneralLabel13.IsRequired = false
        Me.GeneralLabel13.Location = New System.Drawing.Point(405, 498)
        Me.GeneralLabel13.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel13.Name = "GeneralLabel13"
        Me.GeneralLabel13.SetLabelTxt = "الحد الأقصى للسلفة :"
        Me.GeneralLabel13.Size = New System.Drawing.Size(224, 32)
        Me.GeneralLabel13.TabIndex = 171
        Me.GeneralLabel13.TabStop = false
        '
        'Loan_Duration_Limit
        '
        Me.Loan_Duration_Limit.BackColor = System.Drawing.Color.Gainsboro
        Me.Loan_Duration_Limit.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Loan_Duration_Limit.Location = New System.Drawing.Point(46, 596)
        Me.Loan_Duration_Limit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Loan_Duration_Limit.Name = "Loan_Duration_Limit"
        Me.Loan_Duration_Limit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Loan_Duration_Limit.Size = New System.Drawing.Size(328, 30)
        Me.Loan_Duration_Limit.TabIndex = 170
        Me.Loan_Duration_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Loan_Pay_Limit
        '
        Me.Loan_Pay_Limit.BackColor = System.Drawing.Color.Gainsboro
        Me.Loan_Pay_Limit.DecimalPlaces = 2
        Me.Loan_Pay_Limit.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Loan_Pay_Limit.Location = New System.Drawing.Point(46, 546)
        Me.Loan_Pay_Limit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Loan_Pay_Limit.Maximum = New Decimal(New Integer() {276447232, 23283, 0, 0})
        Me.Loan_Pay_Limit.Name = "Loan_Pay_Limit"
        Me.Loan_Pay_Limit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Loan_Pay_Limit.Size = New System.Drawing.Size(328, 30)
        Me.Loan_Pay_Limit.TabIndex = 169
        Me.Loan_Pay_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Loan_Value_Limit
        '
        Me.Loan_Value_Limit.BackColor = System.Drawing.Color.Gainsboro
        Me.Loan_Value_Limit.DecimalPlaces = 2
        Me.Loan_Value_Limit.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Loan_Value_Limit.Location = New System.Drawing.Point(46, 497)
        Me.Loan_Value_Limit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Loan_Value_Limit.Maximum = New Decimal(New Integer() {276447232, 23283, 0, 0})
        Me.Loan_Value_Limit.Name = "Loan_Value_Limit"
        Me.Loan_Value_Limit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Loan_Value_Limit.Size = New System.Drawing.Size(328, 30)
        Me.Loan_Value_Limit.TabIndex = 168
        Me.Loan_Value_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'salarygroups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.GYM.My.Resources.Resources.enter_screen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(873, 902)
        Me.Controls.Add(Me.ContentPanel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnLast)
        Me.Controls.Add(Me.OrderByCombo)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.BtnReload)
        Me.Controls.Add(Me.BtnHelp)
        Me.Controls.Add(Me.BtnCancelSerach)
        Me.Controls.Add(Me.BtnPrevious)
        Me.Controls.Add(Me.BtnData)
        Me.Controls.Add(Me.CountRecords)
        Me.Controls.Add(Me.BtnFirst)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.BtnFile)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.BtnExit)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "salarygroups"
        Me.Text = "SalaryGroups"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContentPanel.ResumeLayout(false)
        CType(Me.Subsc_Value,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Custs_Disc,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Extra_Custs,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Min_Custs,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Hours_Disc,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Extra_Hours,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Work_Hours,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Min_Hours,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Loan_Duration_Limit,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Loan_Pay_Limit,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Loan_Value_Limit,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents GeneralLabel4 As GYM.GeneralLabel
    Friend WithEvents ContentPanel As System.Windows.Forms.Panel
    Friend WithEvents GeneralLabel3 As GYM.GeneralLabel
    Friend WithEvents GeneralLabel2 As GYM.GeneralLabel
    Friend WithEvents GeneralLabel1 As GYM.GeneralLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnLast As System.Windows.Forms.Button
    Friend WithEvents OrderByCombo As System.Windows.Forms.ComboBox
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnReload As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnCancelSerach As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BtnPrevious As System.Windows.Forms.Button
    Friend WithEvents BtnData As System.Windows.Forms.Button
    Friend WithEvents CountRecords As System.Windows.Forms.Label
    Friend WithEvents BtnFirst As System.Windows.Forms.Button
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnFile As System.Windows.Forms.Button
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents MasterField1 As GYM.MasterField
    Friend WithEvents GeneralLabel6 As GYM.GeneralLabel
    Friend WithEvents GeneralLabel5 As GYM.GeneralLabel
    Friend WithEvents Subsc_Value As System.Windows.Forms.NumericUpDown
    Friend WithEvents Custs_Disc As System.Windows.Forms.NumericUpDown
    Friend WithEvents Extra_Custs As System.Windows.Forms.NumericUpDown
    Friend WithEvents Min_Custs As System.Windows.Forms.NumericUpDown
    Friend WithEvents Hours_Disc As System.Windows.Forms.NumericUpDown
    Friend WithEvents Extra_Hours As System.Windows.Forms.NumericUpDown
    Friend WithEvents Work_Hours As System.Windows.Forms.NumericUpDown
    Friend WithEvents Min_Hours As System.Windows.Forms.NumericUpDown
    Friend WithEvents GeneralLabel9 As GYM.GeneralLabel
    Friend WithEvents GeneralLabel8 As GYM.GeneralLabel
    Friend WithEvents GeneralLabel7 As GYM.GeneralLabel
    Friend WithEvents GeneralLabel11 As GYM.GeneralLabel
    Friend WithEvents GenericDesc As GYM.GeneralTextBox
    Friend WithEvents GeneralLabel10 As GeneralLabel
    Friend WithEvents GeneralLabel12 As GeneralLabel
    Friend WithEvents GeneralLabel13 As GeneralLabel
    Friend WithEvents Loan_Duration_Limit As NumericUpDown
    Friend WithEvents Loan_Pay_Limit As NumericUpDown
    Friend WithEvents Loan_Value_Limit As NumericUpDown
End Class
