<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrainerAttendance
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
        Me.ShiftDetailID = New System.Windows.Forms.ComboBox()
        Me.RadShift = New System.Windows.Forms.RadioButton()
        Me.ShiftID = New System.Windows.Forms.ComboBox()
        Me.RadShiftDetails = New System.Windows.Forms.RadioButton()
        Me.RadHall = New System.Windows.Forms.RadioButton()
        Me.HallID = New System.Windows.Forms.ComboBox()
        Me.Rademp = New System.Windows.Forms.RadioButton()
        Me.EmpID = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Report = New System.Windows.Forms.TabPage()
        Me.crystalreportviewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
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
        Me.GroupBox1.Controls.Add(Me.ShiftDetailID)
        Me.GroupBox1.Controls.Add(Me.RadShift)
        Me.GroupBox1.Controls.Add(Me.ShiftID)
        Me.GroupBox1.Controls.Add(Me.RadShiftDetails)
        Me.GroupBox1.Controls.Add(Me.RadHall)
        Me.GroupBox1.Controls.Add(Me.HallID)
        Me.GroupBox1.Controls.Add(Me.Rademp)
        Me.GroupBox1.Controls.Add(Me.EmpID)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(422, 147)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(519, 260)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'ShiftDetailID
        '
        Me.ShiftDetailID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ShiftDetailID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ShiftDetailID.Enabled = False
        Me.ShiftDetailID.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.ShiftDetailID.FormattingEnabled = True
        Me.ShiftDetailID.Location = New System.Drawing.Point(46, 192)
        Me.ShiftDetailID.Name = "ShiftDetailID"
        Me.ShiftDetailID.Size = New System.Drawing.Size(301, 26)
        Me.ShiftDetailID.TabIndex = 12
        '
        'RadShift
        '
        Me.RadShift.AutoSize = True
        Me.RadShift.Location = New System.Drawing.Point(382, 141)
        Me.RadShift.Name = "RadShift"
        Me.RadShift.Size = New System.Drawing.Size(91, 22)
        Me.RadShift.TabIndex = 11
        Me.RadShift.Text = "نوع الورديه"
        Me.RadShift.UseVisualStyleBackColor = True
        '
        'ShiftID
        '
        Me.ShiftID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ShiftID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ShiftID.Enabled = False
        Me.ShiftID.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.ShiftID.FormattingEnabled = True
        Me.ShiftID.Location = New System.Drawing.Point(46, 142)
        Me.ShiftID.Name = "ShiftID"
        Me.ShiftID.Size = New System.Drawing.Size(301, 26)
        Me.ShiftID.TabIndex = 10
        '
        'RadShiftDetails
        '
        Me.RadShiftDetails.AutoSize = True
        Me.RadShiftDetails.Location = New System.Drawing.Point(373, 192)
        Me.RadShiftDetails.Name = "RadShiftDetails"
        Me.RadShiftDetails.Size = New System.Drawing.Size(100, 22)
        Me.RadShiftDetails.TabIndex = 9
        Me.RadShiftDetails.Text = "اسم الورديه"
        Me.RadShiftDetails.UseVisualStyleBackColor = True
        '
        'RadHall
        '
        Me.RadHall.AutoSize = True
        Me.RadHall.Checked = True
        Me.RadHall.Location = New System.Drawing.Point(375, 44)
        Me.RadHall.Name = "RadHall"
        Me.RadHall.Size = New System.Drawing.Size(98, 22)
        Me.RadHall.TabIndex = 8
        Me.RadHall.TabStop = True
        Me.RadHall.Text = "اسم الصاله"
        Me.RadHall.UseVisualStyleBackColor = True
        '
        'HallID
        '
        Me.HallID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.HallID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.HallID.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.HallID.FormattingEnabled = True
        Me.HallID.Location = New System.Drawing.Point(46, 43)
        Me.HallID.Name = "HallID"
        Me.HallID.Size = New System.Drawing.Size(301, 26)
        Me.HallID.TabIndex = 6
        '
        'Rademp
        '
        Me.Rademp.AutoSize = True
        Me.Rademp.Location = New System.Drawing.Point(371, 92)
        Me.Rademp.Name = "Rademp"
        Me.Rademp.Size = New System.Drawing.Size(102, 22)
        Me.Rademp.TabIndex = 1
        Me.Rademp.Text = "اسم المدرب"
        Me.Rademp.UseVisualStyleBackColor = True
        '
        'EmpID
        '
        Me.EmpID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.EmpID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.EmpID.Enabled = False
        Me.EmpID.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.EmpID.FormattingEnabled = True
        Me.EmpID.Location = New System.Drawing.Point(46, 92)
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
        Me.Button1.Location = New System.Drawing.Point(774, 481)
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
        Me.Button2.Location = New System.Drawing.Point(445, 481)
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
        Me.Report.Size = New System.Drawing.Size(1362, 719)
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
        Me.crystalreportviewer1.Size = New System.Drawing.Size(1356, 718)
        Me.crystalreportviewer1.TabIndex = 0
        Me.crystalreportviewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'FrmTrainerAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 750)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmTrainerAttendance"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "كشف حضور المدربيين"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Report.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadShift As System.Windows.Forms.RadioButton
    Friend WithEvents ShiftID As System.Windows.Forms.ComboBox
    Friend WithEvents RadShiftDetails As System.Windows.Forms.RadioButton
    Friend WithEvents RadHall As System.Windows.Forms.RadioButton
    Friend WithEvents HallID As System.Windows.Forms.ComboBox
    Friend WithEvents Rademp As System.Windows.Forms.RadioButton
    Friend WithEvents EmpID As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Report As System.Windows.Forms.TabPage
    Friend WithEvents crystalreportviewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ShiftDetailID As System.Windows.Forms.ComboBox
End Class
