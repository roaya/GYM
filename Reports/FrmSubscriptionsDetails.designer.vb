<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSubscriptionsDetails
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Yes = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadAll = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Ret = New System.Windows.Forms.RadioButton()
        Me.both = New System.Windows.Forms.RadioButton()
        Me.Closed = New System.Windows.Forms.RadioButton()
        Me.Open = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.fromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.todate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RadCoach = New System.Windows.Forms.RadioButton()
        Me.coach = New System.Windows.Forms.ComboBox()
        Me.CategoryID = New System.Windows.Forms.ComboBox()
        Me.RadSub = New System.Windows.Forms.RadioButton()
        Me.SubscriptionID = New System.Windows.Forms.ComboBox()
        Me.RadCategory = New System.Windows.Forms.RadioButton()
        Me.RadCust = New System.Windows.Forms.RadioButton()
        Me.Custid = New System.Windows.Forms.ComboBox()
        Me.Rademp = New System.Windows.Forms.RadioButton()
        Me.EmpID = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Report = New System.Windows.Forms.TabPage()
        Me.crystalreportviewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabControl1.SuspendLayout()
        Me.Yes.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Report.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Yes)
        Me.TabControl1.Controls.Add(Me.Report)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1284, 742)
        Me.TabControl1.TabIndex = 4
        '
        'Yes
        '
        Me.Yes.AutoScroll = True
        Me.Yes.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Yes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Yes.Controls.Add(Me.GroupBox1)
        Me.Yes.Controls.Add(Me.Button1)
        Me.Yes.Controls.Add(Me.Button2)
        Me.Yes.Location = New System.Drawing.Point(4, 27)
        Me.Yes.Name = "Yes"
        Me.Yes.Padding = New System.Windows.Forms.Padding(3)
        Me.Yes.Size = New System.Drawing.Size(1276, 711)
        Me.Yes.TabIndex = 0
        Me.Yes.Text = "معاملات التقرير"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadAll)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.RadCoach)
        Me.GroupBox1.Controls.Add(Me.coach)
        Me.GroupBox1.Controls.Add(Me.CategoryID)
        Me.GroupBox1.Controls.Add(Me.RadSub)
        Me.GroupBox1.Controls.Add(Me.SubscriptionID)
        Me.GroupBox1.Controls.Add(Me.RadCategory)
        Me.GroupBox1.Controls.Add(Me.RadCust)
        Me.GroupBox1.Controls.Add(Me.Custid)
        Me.GroupBox1.Controls.Add(Me.Rademp)
        Me.GroupBox1.Controls.Add(Me.EmpID)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(422, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(519, 470)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'RadAll
        '
        Me.RadAll.AutoSize = True
        Me.RadAll.Checked = True
        Me.RadAll.Location = New System.Drawing.Point(420, 25)
        Me.RadAll.Name = "RadAll"
        Me.RadAll.Size = New System.Drawing.Size(57, 22)
        Me.RadAll.TabIndex = 21
        Me.RadAll.TabStop = True
        Me.RadAll.Text = "بالكل"
        Me.RadAll.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Ret)
        Me.GroupBox3.Controls.Add(Me.both)
        Me.GroupBox3.Controls.Add(Me.Closed)
        Me.GroupBox3.Controls.Add(Me.Open)
        Me.GroupBox3.Location = New System.Drawing.Point(48, 278)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(410, 58)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "حالة الاشتراك"
        '
        'Ret
        '
        Me.Ret.AutoSize = True
        Me.Ret.Location = New System.Drawing.Point(31, 22)
        Me.Ret.Name = "Ret"
        Me.Ret.Size = New System.Drawing.Size(63, 22)
        Me.Ret.TabIndex = 20
        Me.Ret.Text = "مرتجع"
        Me.Ret.UseVisualStyleBackColor = True
        '
        'both
        '
        Me.both.AutoSize = True
        Me.both.Checked = True
        Me.both.Location = New System.Drawing.Point(315, 22)
        Me.both.Name = "both"
        Me.both.Size = New System.Drawing.Size(53, 22)
        Me.both.TabIndex = 19
        Me.both.TabStop = True
        Me.both.Text = "الكل"
        Me.both.UseVisualStyleBackColor = True
        '
        'Closed
        '
        Me.Closed.AutoSize = True
        Me.Closed.Location = New System.Drawing.Point(133, 22)
        Me.Closed.Name = "Closed"
        Me.Closed.Size = New System.Drawing.Size(67, 22)
        Me.Closed.TabIndex = 18
        Me.Closed.Text = "منتهي"
        Me.Closed.UseVisualStyleBackColor = True
        '
        'Open
        '
        Me.Open.AutoSize = True
        Me.Open.Location = New System.Drawing.Point(241, 22)
        Me.Open.Name = "Open"
        Me.Open.Size = New System.Drawing.Size(58, 22)
        Me.Open.TabIndex = 17
        Me.Open.Text = "جاري"
        Me.Open.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.fromdate)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.todate)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(54, 342)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(402, 105)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "تاريخ الحجز"
        '
        'fromdate
        '
        Me.fromdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fromdate.Location = New System.Drawing.Point(25, 21)
        Me.fromdate.Name = "fromdate"
        Me.fromdate.RightToLeftLayout = True
        Me.fromdate.Size = New System.Drawing.Size(263, 26)
        Me.fromdate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(313, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "من تاريخ"
        '
        'todate
        '
        Me.todate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.todate.Location = New System.Drawing.Point(25, 70)
        Me.todate.Name = "todate"
        Me.todate.RightToLeftLayout = True
        Me.todate.Size = New System.Drawing.Size(263, 26)
        Me.todate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(313, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "الى تاريخ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'RadCoach
        '
        Me.RadCoach.AutoSize = True
        Me.RadCoach.Location = New System.Drawing.Point(375, 154)
        Me.RadCoach.Name = "RadCoach"
        Me.RadCoach.Size = New System.Drawing.Size(102, 22)
        Me.RadCoach.TabIndex = 14
        Me.RadCoach.Text = "اسم المدرب"
        Me.RadCoach.UseVisualStyleBackColor = True
        '
        'coach
        '
        Me.coach.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.coach.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.coach.Enabled = False
        Me.coach.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.coach.FormattingEnabled = True
        Me.coach.Location = New System.Drawing.Point(46, 153)
        Me.coach.Name = "coach"
        Me.coach.Size = New System.Drawing.Size(301, 26)
        Me.coach.TabIndex = 13
        '
        'CategoryID
        '
        Me.CategoryID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CategoryID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CategoryID.Enabled = False
        Me.CategoryID.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.CategoryID.FormattingEnabled = True
        Me.CategoryID.Location = New System.Drawing.Point(46, 246)
        Me.CategoryID.Name = "CategoryID"
        Me.CategoryID.Size = New System.Drawing.Size(301, 26)
        Me.CategoryID.TabIndex = 12
        '
        'RadSub
        '
        Me.RadSub.AutoSize = True
        Me.RadSub.Location = New System.Drawing.Point(363, 200)
        Me.RadSub.Name = "RadSub"
        Me.RadSub.Size = New System.Drawing.Size(114, 22)
        Me.RadSub.TabIndex = 11
        Me.RadSub.Text = "اسم الاشتراك"
        Me.RadSub.UseVisualStyleBackColor = True
        '
        'SubscriptionID
        '
        Me.SubscriptionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.SubscriptionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SubscriptionID.Enabled = False
        Me.SubscriptionID.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.SubscriptionID.FormattingEnabled = True
        Me.SubscriptionID.Location = New System.Drawing.Point(46, 200)
        Me.SubscriptionID.Name = "SubscriptionID"
        Me.SubscriptionID.Size = New System.Drawing.Size(301, 26)
        Me.SubscriptionID.TabIndex = 10
        '
        'RadCategory
        '
        Me.RadCategory.AutoSize = True
        Me.RadCategory.Location = New System.Drawing.Point(372, 246)
        Me.RadCategory.Name = "RadCategory"
        Me.RadCategory.Size = New System.Drawing.Size(105, 22)
        Me.RadCategory.TabIndex = 9
        Me.RadCategory.Text = "نوع الاشتراك"
        Me.RadCategory.UseVisualStyleBackColor = True
        '
        'RadCust
        '
        Me.RadCust.AutoSize = True
        Me.RadCust.Location = New System.Drawing.Point(377, 65)
        Me.RadCust.Name = "RadCust"
        Me.RadCust.Size = New System.Drawing.Size(100, 22)
        Me.RadCust.TabIndex = 8
        Me.RadCust.Text = "اسم العميل"
        Me.RadCust.UseVisualStyleBackColor = True
        '
        'Custid
        '
        Me.Custid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Custid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Custid.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Custid.FormattingEnabled = True
        Me.Custid.Location = New System.Drawing.Point(46, 65)
        Me.Custid.Name = "Custid"
        Me.Custid.Size = New System.Drawing.Size(301, 26)
        Me.Custid.TabIndex = 6
        '
        'Rademp
        '
        Me.Rademp.AutoSize = True
        Me.Rademp.Location = New System.Drawing.Point(369, 112)
        Me.Rademp.Name = "Rademp"
        Me.Rademp.Size = New System.Drawing.Size(108, 22)
        Me.Rademp.TabIndex = 1
        Me.Rademp.Text = "اسم الموظف"
        Me.Rademp.UseVisualStyleBackColor = True
        '
        'EmpID
        '
        Me.EmpID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.EmpID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.EmpID.Enabled = False
        Me.EmpID.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.EmpID.FormattingEnabled = True
        Me.EmpID.Location = New System.Drawing.Point(46, 111)
        Me.EmpID.Name = "EmpID"
        Me.EmpID.Size = New System.Drawing.Size(301, 26)
        Me.EmpID.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.GYM.My.Resources.Resources.enter
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(774, 518)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 37)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "عرض"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.GYM.My.Resources.Resources.enter
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(445, 518)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(143, 37)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "خروج"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Report
        '
        Me.Report.Controls.Add(Me.crystalreportviewer1)
        Me.Report.Location = New System.Drawing.Point(4, 27)
        Me.Report.Name = "Report"
        Me.Report.Padding = New System.Windows.Forms.Padding(3)
        Me.Report.Size = New System.Drawing.Size(1276, 711)
        Me.Report.TabIndex = 1
        Me.Report.Text = "التقرير"
        Me.Report.UseVisualStyleBackColor = True
        '
        'crystalreportviewer1
        '
        Me.crystalreportviewer1.ActiveViewIndex = -1
        Me.crystalreportviewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crystalreportviewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.crystalreportviewer1.DisplayStatusBar = False
        Me.crystalreportviewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crystalreportviewer1.Location = New System.Drawing.Point(3, 3)
        Me.crystalreportviewer1.Name = "crystalreportviewer1"
        Me.crystalreportviewer1.ShowCloseButton = False
        Me.crystalreportviewer1.ShowCopyButton = False
        Me.crystalreportviewer1.ShowGroupTreeButton = False
        Me.crystalreportviewer1.ShowParameterPanelButton = False
        Me.crystalreportviewer1.Size = New System.Drawing.Size(1270, 705)
        Me.crystalreportviewer1.TabIndex = 0
        Me.crystalreportviewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'FrmSubscriptionsDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 742)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmSubscriptionsDetails"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تقرير تفاصيل الاشتراكات"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.Yes.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Report.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Yes As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents RadSub As System.Windows.Forms.RadioButton
    Friend WithEvents SubscriptionID As System.Windows.Forms.ComboBox
    Friend WithEvents RadCategory As System.Windows.Forms.RadioButton
    Friend WithEvents RadCust As System.Windows.Forms.RadioButton
    Friend WithEvents Custid As System.Windows.Forms.ComboBox
    Friend WithEvents Rademp As System.Windows.Forms.RadioButton
    Friend WithEvents EmpID As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Report As System.Windows.Forms.TabPage
    Friend WithEvents crystalreportviewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents RadCoach As System.Windows.Forms.RadioButton
    Friend WithEvents coach As System.Windows.Forms.ComboBox
    Friend WithEvents Closed As System.Windows.Forms.RadioButton
    Friend WithEvents Open As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents fromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents todate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadAll As System.Windows.Forms.RadioButton
    Friend WithEvents both As System.Windows.Forms.RadioButton
    Friend WithEvents Ret As System.Windows.Forms.RadioButton
End Class
