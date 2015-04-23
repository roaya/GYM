<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportSubscription
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
        Me.ByAll = New System.Windows.Forms.RadioButton()
        Me.ByCategory = New System.Windows.Forms.RadioButton()
        Me.Type = New System.Windows.Forms.ComboBox()
        Me.Report = New System.Windows.Forms.TabPage()
        Me.RMeals = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SpecialSubs = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.TabControl1.Size = New System.Drawing.Size(1290, 748)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1282, 717)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "معاملات التقرير"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SpecialSubs)
        Me.GroupBox1.Controls.Add(Me.ByAll)
        Me.GroupBox1.Controls.Add(Me.ByCategory)
        Me.GroupBox1.Controls.Add(Me.Type)
        Me.GroupBox1.Location = New System.Drawing.Point(399, 138)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(562, 215)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'ByAll
        '
        Me.ByAll.AutoSize = True
        Me.ByAll.Checked = True
        Me.ByAll.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.ByAll.Location = New System.Drawing.Point(396, 41)
        Me.ByAll.Name = "ByAll"
        Me.ByAll.Size = New System.Drawing.Size(143, 22)
        Me.ByAll.TabIndex = 8
        Me.ByAll.TabStop = True
        Me.ByAll.Text = "كل بنود الاشتراكات"
        Me.ByAll.UseVisualStyleBackColor = True
        '
        'ByCategory
        '
        Me.ByCategory.AutoSize = True
        Me.ByCategory.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.ByCategory.Location = New System.Drawing.Point(432, 92)
        Me.ByCategory.Name = "ByCategory"
        Me.ByCategory.Size = New System.Drawing.Size(107, 22)
        Me.ByCategory.TabIndex = 7
        Me.ByCategory.Text = "ببند الاشتراك"
        Me.ByCategory.UseVisualStyleBackColor = True
        '
        'Type
        '
        Me.Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Type.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Type.FormattingEnabled = True
        Me.Type.Items.AddRange(New Object() {"حضور", "انصراف", "حضور و انصراف"})
        Me.Type.Location = New System.Drawing.Point(54, 91)
        Me.Type.Name = "Type"
        Me.Type.Size = New System.Drawing.Size(342, 26)
        Me.Type.TabIndex = 5
        '
        'Report
        '
        Me.Report.Controls.Add(Me.RMeals)
        Me.Report.Location = New System.Drawing.Point(4, 27)
        Me.Report.Name = "Report"
        Me.Report.Padding = New System.Windows.Forms.Padding(3)
        Me.Report.Size = New System.Drawing.Size(1282, 717)
        Me.Report.TabIndex = 1
        Me.Report.Text = "التقرير"
        Me.Report.UseVisualStyleBackColor = True
        '
        'RMeals
        '
        Me.RMeals.ActiveViewIndex = -1
        Me.RMeals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RMeals.Cursor = System.Windows.Forms.Cursors.Default
        Me.RMeals.DisplayStatusBar = False
        Me.RMeals.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RMeals.Location = New System.Drawing.Point(3, 3)
        Me.RMeals.Name = "RMeals"
        Me.RMeals.ShowCloseButton = False
        Me.RMeals.ShowCopyButton = False
        Me.RMeals.ShowGroupTreeButton = False
        Me.RMeals.ShowParameterPanelButton = False
        Me.RMeals.Size = New System.Drawing.Size(1276, 711)
        Me.RMeals.TabIndex = 0
        Me.RMeals.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'SpecialSubs
        '
        Me.SpecialSubs.AutoSize = True
        Me.SpecialSubs.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.SpecialSubs.Location = New System.Drawing.Point(377, 155)
        Me.SpecialSubs.Name = "SpecialSubs"
        Me.SpecialSubs.Size = New System.Drawing.Size(162, 22)
        Me.SpecialSubs.TabIndex = 9
        Me.SpecialSubs.Text = "تقرير الجلسات الخاصه"
        Me.SpecialSubs.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.GYM.My.Resources.Resources.enter
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(456, 395)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(143, 37)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "خروج"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.GYM.My.Resources.Resources.enter
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(761, 395)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 37)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "عرض"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ReportSubscription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1290, 748)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "ReportSubscription"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تقرير الاشتراكات"
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
    Friend WithEvents Type As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Report As System.Windows.Forms.TabPage
    Friend WithEvents RMeals As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ByAll As System.Windows.Forms.RadioButton
    Friend WithEvents ByCategory As System.Windows.Forms.RadioButton
    Friend WithEvents SpecialSubs As System.Windows.Forms.RadioButton
End Class
