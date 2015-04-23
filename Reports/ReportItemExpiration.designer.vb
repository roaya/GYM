<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reportItemExpiration
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
        Me.Report = New System.Windows.Forms.TabPage()
        Me.RMeals = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Remaining = New System.Windows.Forms.NumericUpDown()
        Me.thestock = New System.Windows.Forms.ComboBox()
        Me.bystock = New System.Windows.Forms.CheckBox()
        Me.byall = New System.Windows.Forms.RadioButton()
        Me.byname = New System.Windows.Forms.RadioButton()
        Me.thename = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Report.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Remaining, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Report
        '
        Me.Report.Controls.Add(Me.RMeals)
        Me.Report.Location = New System.Drawing.Point(4, 27)
        Me.Report.Name = "Report"
        Me.Report.Padding = New System.Windows.Forms.Padding(3)
        Me.Report.Size = New System.Drawing.Size(1282, 725)
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
        Me.RMeals.Size = New System.Drawing.Size(1362, 724)
        Me.RMeals.TabIndex = 0
        Me.RMeals.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Remaining)
        Me.GroupBox1.Controls.Add(Me.thestock)
        Me.GroupBox1.Controls.Add(Me.bystock)
        Me.GroupBox1.Controls.Add(Me.byall)
        Me.GroupBox1.Controls.Add(Me.byname)
        Me.GroupBox1.Controls.Add(Me.thename)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(403, 142)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(562, 333)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(425, 252)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "الفترة بالأيام"
        '
        'Remaining
        '
        Me.Remaining.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Remaining.Location = New System.Drawing.Point(56, 250)
        Me.Remaining.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.Remaining.Name = "Remaining"
        Me.Remaining.Size = New System.Drawing.Size(334, 25)
        Me.Remaining.TabIndex = 7
        Me.Remaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'thestock
        '
        Me.thestock.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.thestock.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.thestock.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.thestock.FormattingEnabled = True
        Me.thestock.Location = New System.Drawing.Point(56, 70)
        Me.thestock.Name = "thestock"
        Me.thestock.Size = New System.Drawing.Size(334, 26)
        Me.thestock.TabIndex = 6
        '
        'bystock
        '
        Me.bystock.AutoSize = True
        Me.bystock.Checked = True
        Me.bystock.CheckState = System.Windows.Forms.CheckState.Checked
        Me.bystock.Location = New System.Drawing.Point(398, 72)
        Me.bystock.Name = "bystock"
        Me.bystock.Size = New System.Drawing.Size(108, 22)
        Me.bystock.TabIndex = 5
        Me.bystock.Text = "باسم المخزن"
        Me.bystock.UseVisualStyleBackColor = True
        '
        'byall
        '
        Me.byall.AutoSize = True
        Me.byall.Location = New System.Drawing.Point(410, 192)
        Me.byall.Name = "byall"
        Me.byall.Size = New System.Drawing.Size(96, 22)
        Me.byall.TabIndex = 2
        Me.byall.Text = "كل الاصناف"
        Me.byall.UseVisualStyleBackColor = True
        '
        'byname
        '
        Me.byname.AutoSize = True
        Me.byname.Checked = True
        Me.byname.Location = New System.Drawing.Point(406, 132)
        Me.byname.Name = "byname"
        Me.byname.Size = New System.Drawing.Size(100, 22)
        Me.byname.TabIndex = 1
        Me.byname.TabStop = True
        Me.byname.Text = "اسم الصنف"
        Me.byname.UseVisualStyleBackColor = True
        '
        'thename
        '
        Me.thename.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.thename.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.thename.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.thename.FormattingEnabled = True
        Me.thename.Location = New System.Drawing.Point(56, 131)
        Me.thename.Name = "thename"
        Me.thename.Size = New System.Drawing.Size(334, 26)
        Me.thename.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.GYM.My.Resources.Resources.enter
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(497, 525)
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
        Me.Button1.Location = New System.Drawing.Point(729, 525)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 37)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "عرض"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.TabPage1.Size = New System.Drawing.Size(1018, 717)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "معاملات التقرير"
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
        Me.TabControl1.Size = New System.Drawing.Size(1026, 748)
        Me.TabControl1.TabIndex = 2
        '
        'reportItemExpiration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 748)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "reportItemExpiration"
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الأصناف التي قاربت علي الانتهاء"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Report.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Remaining, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Report As System.Windows.Forms.TabPage
    Friend WithEvents RMeals As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents byall As System.Windows.Forms.RadioButton
    Friend WithEvents byname As System.Windows.Forms.RadioButton
    Friend WithEvents thename As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents bystock As System.Windows.Forms.CheckBox
    Friend WithEvents thestock As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Remaining As System.Windows.Forms.NumericUpDown
End Class
