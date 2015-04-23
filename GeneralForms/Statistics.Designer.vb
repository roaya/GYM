<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Statistics
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
        Me.FromDate = New System.Windows.Forms.DateTimePicker()
        Me.ToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.all = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.CustBySubsc = New System.Windows.Forms.RadioButton()
        Me.CustByCoach = New System.Windows.Forms.RadioButton()
        Me.CustsSubsc = New System.Windows.Forms.ComboBox()
        Me.CustsCoach = New System.Windows.Forms.ComboBox()
        Me.Emps = New System.Windows.Forms.ComboBox()
        Me.BySubsc = New System.Windows.Forms.RadioButton()
        Me.ByCat = New System.Windows.Forms.RadioButton()
        Me.ByCoach = New System.Windows.Forms.RadioButton()
        Me.Coachs = New System.Windows.Forms.ComboBox()
        Me.Subsc = New System.Windows.Forms.ComboBox()
        Me.Cat = New System.Windows.Forms.ComboBox()
        Me.BySpecialCoach = New System.Windows.Forms.RadioButton()
        Me.BySpecial = New System.Windows.Forms.RadioButton()
        Me.SpecialCoach = New System.Windows.Forms.ComboBox()
        Me.Special = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Customers = New System.Windows.Forms.GroupBox()
        Me.Attendance = New System.Windows.Forms.GroupBox()
        Me.Subscriptions = New System.Windows.Forms.GroupBox()
        Me.SpecialSubscriptions = New System.Windows.Forms.GroupBox()
        Me.GeneralStatistics = New System.Windows.Forms.GroupBox()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Customers.SuspendLayout()
        Me.Attendance.SuspendLayout()
        Me.Subscriptions.SuspendLayout()
        Me.SpecialSubscriptions.SuspendLayout()
        Me.GeneralStatistics.SuspendLayout()
        Me.SuspendLayout()
        '
        'FromDate
        '
        Me.FromDate.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FromDate.Location = New System.Drawing.Point(15, 17)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FromDate.RightToLeftLayout = True
        Me.FromDate.Size = New System.Drawing.Size(167, 25)
        Me.FromDate.TabIndex = 0
        '
        'ToDate
        '
        Me.ToDate.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ToDate.Location = New System.Drawing.Point(15, 48)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToDate.RightToLeftLayout = True
        Me.ToDate.Size = New System.Drawing.Size(167, 25)
        Me.ToDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Label1.Location = New System.Drawing.Point(192, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "من"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Label2.Location = New System.Drawing.Point(188, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "الى"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.all)
        Me.Panel1.Controls.Add(Me.FromDate)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ToDate)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(186, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(241, 104)
        Me.Panel1.TabIndex = 4
        '
        'all
        '
        Me.all.AutoSize = True
        Me.all.Checked = True
        Me.all.CheckState = System.Windows.Forms.CheckState.Checked
        Me.all.Location = New System.Drawing.Point(63, 79)
        Me.all.Name = "all"
        Me.all.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.all.Size = New System.Drawing.Size(95, 17)
        Me.all.TabIndex = 14
        Me.all.Text = "جميع السجلات"
        Me.all.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(378, 241)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(156, 35)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "عدد المتدربين"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(75, 241)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(156, 35)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "ساعات الحضور لموظف"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(378, 406)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(156, 35)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "العدد"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(378, 447)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(156, 35)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "اجمالي المدفوع"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(75, 406)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(156, 35)
        Me.Button5.TabIndex = 9
        Me.Button5.Text = "العدد"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.BackColor = System.Drawing.Color.Transparent
        Me.Button6.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(75, 447)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(156, 35)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "اجمالي المدفوع"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'CustBySubsc
        '
        Me.CustBySubsc.AutoSize = True
        Me.CustBySubsc.Location = New System.Drawing.Point(214, 49)
        Me.CustBySubsc.Name = "CustBySubsc"
        Me.CustBySubsc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CustBySubsc.Size = New System.Drawing.Size(66, 17)
        Me.CustBySubsc.TabIndex = 9
        Me.CustBySubsc.Text = "الاشتراك"
        Me.CustBySubsc.UseVisualStyleBackColor = True
        '
        'CustByCoach
        '
        Me.CustByCoach.AutoSize = True
        Me.CustByCoach.Checked = True
        Me.CustByCoach.Location = New System.Drawing.Point(223, 17)
        Me.CustByCoach.Name = "CustByCoach"
        Me.CustByCoach.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CustByCoach.Size = New System.Drawing.Size(57, 17)
        Me.CustByCoach.TabIndex = 8
        Me.CustByCoach.TabStop = True
        Me.CustByCoach.Text = "المدرب"
        Me.CustByCoach.UseVisualStyleBackColor = True
        '
        'CustsSubsc
        '
        Me.CustsSubsc.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.CustsSubsc.FormattingEnabled = True
        Me.CustsSubsc.Location = New System.Drawing.Point(13, 44)
        Me.CustsSubsc.Name = "CustsSubsc"
        Me.CustsSubsc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CustsSubsc.Size = New System.Drawing.Size(192, 26)
        Me.CustsSubsc.TabIndex = 7
        '
        'CustsCoach
        '
        Me.CustsCoach.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.CustsCoach.FormattingEnabled = True
        Me.CustsCoach.Location = New System.Drawing.Point(13, 12)
        Me.CustsCoach.Name = "CustsCoach"
        Me.CustsCoach.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CustsCoach.Size = New System.Drawing.Size(192, 26)
        Me.CustsCoach.TabIndex = 6
        '
        'Emps
        '
        Me.Emps.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Emps.FormattingEnabled = True
        Me.Emps.Location = New System.Drawing.Point(11, 19)
        Me.Emps.Name = "Emps"
        Me.Emps.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Emps.Size = New System.Drawing.Size(181, 26)
        Me.Emps.TabIndex = 8
        '
        'BySubsc
        '
        Me.BySubsc.AutoSize = True
        Me.BySubsc.Location = New System.Drawing.Point(214, 54)
        Me.BySubsc.Name = "BySubsc"
        Me.BySubsc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BySubsc.Size = New System.Drawing.Size(66, 17)
        Me.BySubsc.TabIndex = 16
        Me.BySubsc.Text = "الاشتراك"
        Me.BySubsc.UseVisualStyleBackColor = True
        '
        'ByCat
        '
        Me.ByCat.AutoSize = True
        Me.ByCat.Checked = True
        Me.ByCat.Location = New System.Drawing.Point(235, 22)
        Me.ByCat.Name = "ByCat"
        Me.ByCat.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ByCat.Size = New System.Drawing.Size(45, 17)
        Me.ByCat.TabIndex = 15
        Me.ByCat.TabStop = True
        Me.ByCat.Text = "البند"
        Me.ByCat.UseVisualStyleBackColor = True
        '
        'ByCoach
        '
        Me.ByCoach.AutoSize = True
        Me.ByCoach.Location = New System.Drawing.Point(223, 86)
        Me.ByCoach.Name = "ByCoach"
        Me.ByCoach.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ByCoach.Size = New System.Drawing.Size(57, 17)
        Me.ByCoach.TabIndex = 14
        Me.ByCoach.Text = "المدرب"
        Me.ByCoach.UseVisualStyleBackColor = True
        '
        'Coachs
        '
        Me.Coachs.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Coachs.FormattingEnabled = True
        Me.Coachs.Location = New System.Drawing.Point(16, 81)
        Me.Coachs.Name = "Coachs"
        Me.Coachs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Coachs.Size = New System.Drawing.Size(192, 26)
        Me.Coachs.TabIndex = 13
        '
        'Subsc
        '
        Me.Subsc.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Subsc.FormattingEnabled = True
        Me.Subsc.Location = New System.Drawing.Point(16, 49)
        Me.Subsc.Name = "Subsc"
        Me.Subsc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Subsc.Size = New System.Drawing.Size(192, 26)
        Me.Subsc.TabIndex = 12
        '
        'Cat
        '
        Me.Cat.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Cat.FormattingEnabled = True
        Me.Cat.Location = New System.Drawing.Point(16, 17)
        Me.Cat.Name = "Cat"
        Me.Cat.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Cat.Size = New System.Drawing.Size(192, 26)
        Me.Cat.TabIndex = 11
        '
        'BySpecialCoach
        '
        Me.BySpecialCoach.AutoSize = True
        Me.BySpecialCoach.Location = New System.Drawing.Point(230, 59)
        Me.BySpecialCoach.Name = "BySpecialCoach"
        Me.BySpecialCoach.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BySpecialCoach.Size = New System.Drawing.Size(57, 17)
        Me.BySpecialCoach.TabIndex = 14
        Me.BySpecialCoach.Text = "المدرب"
        Me.BySpecialCoach.UseVisualStyleBackColor = True
        '
        'BySpecial
        '
        Me.BySpecial.AutoSize = True
        Me.BySpecial.Checked = True
        Me.BySpecial.Location = New System.Drawing.Point(209, 27)
        Me.BySpecial.Name = "BySpecial"
        Me.BySpecial.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BySpecial.Size = New System.Drawing.Size(78, 17)
        Me.BySpecial.TabIndex = 11
        Me.BySpecial.TabStop = True
        Me.BySpecial.Text = "نوع الجلسه"
        Me.BySpecial.UseVisualStyleBackColor = True
        '
        'SpecialCoach
        '
        Me.SpecialCoach.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.SpecialCoach.FormattingEnabled = True
        Me.SpecialCoach.Location = New System.Drawing.Point(5, 54)
        Me.SpecialCoach.Name = "SpecialCoach"
        Me.SpecialCoach.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SpecialCoach.Size = New System.Drawing.Size(181, 26)
        Me.SpecialCoach.TabIndex = 13
        '
        'Special
        '
        Me.Special.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Special.FormattingEnabled = True
        Me.Special.Location = New System.Drawing.Point(5, 22)
        Me.Special.Name = "Special"
        Me.Special.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Special.Size = New System.Drawing.Size(181, 26)
        Me.Special.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Label3.Location = New System.Drawing.Point(197, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 18)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "اسم الموظف"
        '
        'Customers
        '
        Me.Customers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Customers.Controls.Add(Me.CustsCoach)
        Me.Customers.Controls.Add(Me.CustBySubsc)
        Me.Customers.Controls.Add(Me.CustsSubsc)
        Me.Customers.Controls.Add(Me.CustByCoach)
        Me.Customers.Enabled = False
        Me.Customers.Location = New System.Drawing.Point(309, 154)
        Me.Customers.Name = "Customers"
        Me.Customers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Customers.Size = New System.Drawing.Size(294, 81)
        Me.Customers.TabIndex = 14
        Me.Customers.TabStop = False
        Me.Customers.Text = "حضور العملاء"
        '
        'Attendance
        '
        Me.Attendance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Attendance.Controls.Add(Me.Emps)
        Me.Attendance.Controls.Add(Me.Label3)
        Me.Attendance.Location = New System.Drawing.Point(6, 154)
        Me.Attendance.Name = "Attendance"
        Me.Attendance.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Attendance.Size = New System.Drawing.Size(294, 81)
        Me.Attendance.TabIndex = 15
        Me.Attendance.TabStop = False
        Me.Attendance.Text = "حضور الموظفين"
        '
        'Subscriptions
        '
        Me.Subscriptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Subscriptions.Controls.Add(Me.Cat)
        Me.Subscriptions.Controls.Add(Me.BySubsc)
        Me.Subscriptions.Controls.Add(Me.Subsc)
        Me.Subscriptions.Controls.Add(Me.Coachs)
        Me.Subscriptions.Controls.Add(Me.ByCat)
        Me.Subscriptions.Controls.Add(Me.ByCoach)
        Me.Subscriptions.Enabled = False
        Me.Subscriptions.Location = New System.Drawing.Point(309, 282)
        Me.Subscriptions.Name = "Subscriptions"
        Me.Subscriptions.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Subscriptions.Size = New System.Drawing.Size(294, 118)
        Me.Subscriptions.TabIndex = 16
        Me.Subscriptions.TabStop = False
        Me.Subscriptions.Text = "الاشتراكات و الخدمات"
        '
        'SpecialSubscriptions
        '
        Me.SpecialSubscriptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SpecialSubscriptions.Controls.Add(Me.Special)
        Me.SpecialSubscriptions.Controls.Add(Me.BySpecialCoach)
        Me.SpecialSubscriptions.Controls.Add(Me.SpecialCoach)
        Me.SpecialSubscriptions.Controls.Add(Me.BySpecial)
        Me.SpecialSubscriptions.Enabled = False
        Me.SpecialSubscriptions.Location = New System.Drawing.Point(6, 282)
        Me.SpecialSubscriptions.Name = "SpecialSubscriptions"
        Me.SpecialSubscriptions.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SpecialSubscriptions.Size = New System.Drawing.Size(294, 118)
        Me.SpecialSubscriptions.TabIndex = 16
        Me.SpecialSubscriptions.TabStop = False
        Me.SpecialSubscriptions.Text = "الجلسات الخاصه"
        '
        'GeneralStatistics
        '
        Me.GeneralStatistics.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GeneralStatistics.Controls.Add(Me.Button15)
        Me.GeneralStatistics.Controls.Add(Me.Button13)
        Me.GeneralStatistics.Controls.Add(Me.Button14)
        Me.GeneralStatistics.Controls.Add(Me.Button10)
        Me.GeneralStatistics.Controls.Add(Me.Button9)
        Me.GeneralStatistics.Controls.Add(Me.Button8)
        Me.GeneralStatistics.Controls.Add(Me.Button7)
        Me.GeneralStatistics.Location = New System.Drawing.Point(618, 12)
        Me.GeneralStatistics.Name = "GeneralStatistics"
        Me.GeneralStatistics.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GeneralStatistics.Size = New System.Drawing.Size(170, 468)
        Me.GeneralStatistics.TabIndex = 16
        Me.GeneralStatistics.TabStop = False
        Me.GeneralStatistics.Text = "احصائيات عامه"
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.Transparent
        Me.Button15.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button15.FlatAppearance.BorderSize = 0
        Me.Button15.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button15.Location = New System.Drawing.Point(8, 390)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(156, 35)
        Me.Button15.TabIndex = 25
        Me.Button15.Text = "المدرب صاحب اكبر عدد من الجلسات الخاصه"
        Me.Button15.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.Transparent
        Me.Button13.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button13.FlatAppearance.BorderSize = 0
        Me.Button13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button13.Location = New System.Drawing.Point(8, 146)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(156, 35)
        Me.Button13.TabIndex = 23
        Me.Button13.Text = "المدرب صاحب اكبر عدد حضور من العملاء"
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.Transparent
        Me.Button14.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button14.FlatAppearance.BorderSize = 0
        Me.Button14.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Location = New System.Drawing.Point(8, 268)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(156, 35)
        Me.Button14.TabIndex = 24
        Me.Button14.Text = "المدرب صاحب اكبر عدد من الاشتراكات الخاصه"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.Transparent
        Me.Button10.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Location = New System.Drawing.Point(8, 329)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(156, 35)
        Me.Button10.TabIndex = 20
        Me.Button10.Text = "الجلسة الخاصه صاحبة اكبر استهلاك"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Transparent
        Me.Button9.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Location = New System.Drawing.Point(8, 207)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(156, 35)
        Me.Button9.TabIndex = 19
        Me.Button9.Text = "الاشتراك ذو اكبر استهلاك"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Transparent
        Me.Button8.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Location = New System.Drawing.Point(8, 85)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(156, 35)
        Me.Button8.TabIndex = 18
        Me.Button8.Text = "اكثر العملاء حضور"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Transparent
        Me.Button7.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Location = New System.Drawing.Point(8, 24)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(156, 35)
        Me.Button7.TabIndex = 17
        Me.Button7.Text = "اكثر الموظفين حضورا"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Statistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(791, 492)
        Me.Controls.Add(Me.GeneralStatistics)
        Me.Controls.Add(Me.SpecialSubscriptions)
        Me.Controls.Add(Me.Subscriptions)
        Me.Controls.Add(Me.Attendance)
        Me.Controls.Add(Me.Customers)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Statistics"
        Me.Text = "الاحصائيات"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Customers.ResumeLayout(False)
        Me.Customers.PerformLayout()
        Me.Attendance.ResumeLayout(False)
        Me.Attendance.PerformLayout()
        Me.Subscriptions.ResumeLayout(False)
        Me.Subscriptions.PerformLayout()
        Me.SpecialSubscriptions.ResumeLayout(False)
        Me.SpecialSubscriptions.PerformLayout()
        Me.GeneralStatistics.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents CustBySubsc As System.Windows.Forms.RadioButton
    Friend WithEvents CustByCoach As System.Windows.Forms.RadioButton
    Friend WithEvents CustsSubsc As System.Windows.Forms.ComboBox
    Friend WithEvents CustsCoach As System.Windows.Forms.ComboBox
    Friend WithEvents Emps As System.Windows.Forms.ComboBox
    Friend WithEvents ByCoach As System.Windows.Forms.RadioButton
    Friend WithEvents Coachs As System.Windows.Forms.ComboBox
    Friend WithEvents Subsc As System.Windows.Forms.ComboBox
    Friend WithEvents Cat As System.Windows.Forms.ComboBox
    Friend WithEvents SpecialCoach As System.Windows.Forms.ComboBox
    Friend WithEvents Special As System.Windows.Forms.ComboBox
    Friend WithEvents all As System.Windows.Forms.CheckBox
    Friend WithEvents BySubsc As System.Windows.Forms.RadioButton
    Friend WithEvents ByCat As System.Windows.Forms.RadioButton
    Friend WithEvents BySpecialCoach As System.Windows.Forms.RadioButton
    Friend WithEvents BySpecial As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Customers As System.Windows.Forms.GroupBox
    Friend WithEvents Attendance As System.Windows.Forms.GroupBox
    Friend WithEvents Subscriptions As System.Windows.Forms.GroupBox
    Friend WithEvents SpecialSubscriptions As System.Windows.Forms.GroupBox
    Friend WithEvents GeneralStatistics As System.Windows.Forms.GroupBox
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
End Class
