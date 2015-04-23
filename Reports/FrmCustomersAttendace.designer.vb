<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomersAttendace
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
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.subsc = New System.Windows.Forms.ComboBox()
        Me.BySubsc = New System.Windows.Forms.CheckBox()
        Me.bycoach = New System.Windows.Forms.RadioButton()
        Me.emp = New System.Windows.Forms.ComboBox()
        Me.byall = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.RadCust = New System.Windows.Forms.RadioButton()
        Me.CustID = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Report = New System.Windows.Forms.TabPage()
        Me.crystalreportviewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Report.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.Report)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1284, 750)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1276, 719)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "معاملات التقرير"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.subsc)
        Me.GroupBox1.Controls.Add(Me.BySubsc)
        Me.GroupBox1.Controls.Add(Me.bycoach)
        Me.GroupBox1.Controls.Add(Me.emp)
        Me.GroupBox1.Controls.Add(Me.byall)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.RadCust)
        Me.GroupBox1.Controls.Add(Me.CustID)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(422, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(519, 380)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'subsc
        '
        Me.subsc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.subsc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.subsc.Enabled = False
        Me.subsc.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.subsc.FormattingEnabled = True
        Me.subsc.Location = New System.Drawing.Point(56, 194)
        Me.subsc.Name = "subsc"
        Me.subsc.Size = New System.Drawing.Size(301, 26)
        Me.subsc.TabIndex = 7
        '
        'BySubsc
        '
        Me.BySubsc.AutoSize = True
        Me.BySubsc.Location = New System.Drawing.Point(408, 196)
        Me.BySubsc.Name = "BySubsc"
        Me.BySubsc.Size = New System.Drawing.Size(85, 22)
        Me.BySubsc.TabIndex = 6
        Me.BySubsc.Text = "بالاشتراك"
        Me.BySubsc.UseVisualStyleBackColor = True
        '
        'bycoach
        '
        Me.bycoach.AutoSize = True
        Me.bycoach.Location = New System.Drawing.Point(391, 137)
        Me.bycoach.Name = "bycoach"
        Me.bycoach.Size = New System.Drawing.Size(102, 22)
        Me.bycoach.TabIndex = 5
        Me.bycoach.Text = "اسم المدرب"
        Me.bycoach.UseVisualStyleBackColor = True
        '
        'emp
        '
        Me.emp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.emp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.emp.Enabled = False
        Me.emp.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.emp.FormattingEnabled = True
        Me.emp.Location = New System.Drawing.Point(56, 137)
        Me.emp.Name = "emp"
        Me.emp.Size = New System.Drawing.Size(301, 26)
        Me.emp.TabIndex = 4
        '
        'byall
        '
        Me.byall.AutoSize = True
        Me.byall.Checked = True
        Me.byall.Location = New System.Drawing.Point(398, 25)
        Me.byall.Name = "byall"
        Me.byall.Size = New System.Drawing.Size(95, 22)
        Me.byall.TabIndex = 3
        Me.byall.TabStop = True
        Me.byall.Text = "بكل العملاء"
        Me.byall.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox2.Location = New System.Drawing.Point(85, 231)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 120)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(278, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "الى"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(278, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "من"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(59, 77)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DateTimePicker2.RightToLeftLayout = True
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 26)
        Me.DateTimePicker2.TabIndex = 1
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(59, 25)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DateTimePicker1.RightToLeftLayout = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 26)
        Me.DateTimePicker1.TabIndex = 0
        '
        'RadCust
        '
        Me.RadCust.AutoSize = True
        Me.RadCust.Location = New System.Drawing.Point(393, 80)
        Me.RadCust.Name = "RadCust"
        Me.RadCust.Size = New System.Drawing.Size(100, 22)
        Me.RadCust.TabIndex = 1
        Me.RadCust.Text = "اسم العميل"
        Me.RadCust.UseVisualStyleBackColor = True
        '
        'CustID
        '
        Me.CustID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CustID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CustID.Enabled = False
        Me.CustID.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.CustID.FormattingEnabled = True
        Me.CustID.Location = New System.Drawing.Point(56, 80)
        Me.CustID.Name = "CustID"
        Me.CustID.Size = New System.Drawing.Size(301, 26)
        Me.CustID.TabIndex = 0
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
        Me.Button1.Location = New System.Drawing.Point(774, 494)
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
        Me.Button2.Location = New System.Drawing.Point(445, 494)
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
        Me.Report.Size = New System.Drawing.Size(1276, 719)
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
        Me.crystalreportviewer1.Size = New System.Drawing.Size(1270, 713)
        Me.crystalreportviewer1.TabIndex = 0
        Me.crystalreportviewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'FrmCustomersAttendace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 750)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmCustomersAttendace"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "كشف حضور العملاء"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Report.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadCust As System.Windows.Forms.RadioButton
    Friend WithEvents CustID As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Report As System.Windows.Forms.TabPage
    Friend WithEvents crystalreportviewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents bycoach As System.Windows.Forms.RadioButton
    Friend WithEvents emp As System.Windows.Forms.ComboBox
    Friend WithEvents byall As System.Windows.Forms.RadioButton
    Friend WithEvents BySubsc As System.Windows.Forms.CheckBox
    Friend WithEvents subsc As System.Windows.Forms.ComboBox
End Class
