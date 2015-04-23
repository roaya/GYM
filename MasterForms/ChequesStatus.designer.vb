<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChequesStatus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChequesStatus))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ComboProcedureID = New System.Windows.Forms.ComboBox()
        Me.CheckBoxRefuseProID = New System.Windows.Forms.CheckBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ChequeNo = New System.Windows.Forms.TextBox()
        Me.RadioChequeNo = New System.Windows.Forms.RadioButton()
        Me.RadioChequeStatus = New System.Windows.Forms.RadioButton()
        Me.ChequeStatus = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboProcedureID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBoxRefuseProID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChequeNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadioChequeNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadioChequeStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChequeStatus)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Size = New System.Drawing.Size(1035, 577)
        Me.SplitContainer1.SplitterDistance = 230
        Me.SplitContainer1.TabIndex = 1
        '
        'ComboProcedureID
        '
        Me.ComboProcedureID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboProcedureID.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboProcedureID.FormattingEnabled = True
        Me.ComboProcedureID.Items.AddRange(New Object() {"جديد", "غير محصل", "محصل", "غير منصرف", "منصرف"})
        Me.ComboProcedureID.Location = New System.Drawing.Point(10, 319)
        Me.ComboProcedureID.Name = "ComboProcedureID"
        Me.ComboProcedureID.Size = New System.Drawing.Size(210, 26)
        Me.ComboProcedureID.TabIndex = 30
        '
        'CheckBoxRefuseProID
        '
        Me.CheckBoxRefuseProID.AutoSize = True
        Me.CheckBoxRefuseProID.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxRefuseProID.Location = New System.Drawing.Point(38, 294)
        Me.CheckBoxRefuseProID.Name = "CheckBoxRefuseProID"
        Me.CheckBoxRefuseProID.Size = New System.Drawing.Size(182, 22)
        Me.CheckBoxRefuseProID.TabIndex = 29
        Me.CheckBoxRefuseProID.Text = "رفض الشيك علي حساب"
        Me.CheckBoxRefuseProID.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.BackgroundImage = CType(resources.GetObject("Button5.BackgroundImage"), System.Drawing.Image)
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(16, 534)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(93, 28)
        Me.Button5.TabIndex = 28
        Me.Button5.Text = "رفض"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(123, 534)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(93, 28)
        Me.Button3.TabIndex = 26
        Me.Button3.Text = "تحصيل"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(16, 489)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(93, 28)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "صرف"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(123, 489)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 28)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "استعلام"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ChequeNo
        '
        Me.ChequeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ChequeNo.Enabled = False
        Me.ChequeNo.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChequeNo.Location = New System.Drawing.Point(10, 224)
        Me.ChequeNo.Name = "ChequeNo"
        Me.ChequeNo.Size = New System.Drawing.Size(210, 26)
        Me.ChequeNo.TabIndex = 23
        '
        'RadioChequeNo
        '
        Me.RadioChequeNo.AutoSize = True
        Me.RadioChequeNo.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioChequeNo.Location = New System.Drawing.Point(117, 200)
        Me.RadioChequeNo.Name = "RadioChequeNo"
        Me.RadioChequeNo.Size = New System.Drawing.Size(103, 22)
        Me.RadioChequeNo.TabIndex = 22
        Me.RadioChequeNo.Text = "رقم الشيك :"
        Me.RadioChequeNo.UseVisualStyleBackColor = True
        '
        'RadioChequeStatus
        '
        Me.RadioChequeStatus.AutoSize = True
        Me.RadioChequeStatus.Checked = True
        Me.RadioChequeStatus.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioChequeStatus.Location = New System.Drawing.Point(111, 95)
        Me.RadioChequeStatus.Name = "RadioChequeStatus"
        Me.RadioChequeStatus.Size = New System.Drawing.Size(109, 22)
        Me.RadioChequeStatus.TabIndex = 21
        Me.RadioChequeStatus.TabStop = True
        Me.RadioChequeStatus.Text = "حالة الشيك :"
        Me.RadioChequeStatus.UseVisualStyleBackColor = True
        '
        'ChequeStatus
        '
        Me.ChequeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ChequeStatus.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChequeStatus.FormattingEnabled = True
        Me.ChequeStatus.Items.AddRange(New Object() {"جديد", "غير محصل", "محصل", "غير منصرف", "منصرف"})
        Me.ChequeStatus.Location = New System.Drawing.Point(10, 119)
        Me.ChequeStatus.Name = "ChequeStatus"
        Me.ChequeStatus.Size = New System.Drawing.Size(210, 26)
        Me.ChequeStatus.TabIndex = 20
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(801, 577)
        Me.DataGridView1.TabIndex = 0
        '
        'ChequesStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.GYM.My.Resources.Resources.Bigbg
        Me.ClientSize = New System.Drawing.Size(1035, 577)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "ChequesStatus"
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تفاصيل الشيكات"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ComboProcedureID As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxRefuseProID As System.Windows.Forms.CheckBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents RadioChequeNo As System.Windows.Forms.RadioButton
    Friend WithEvents RadioChequeStatus As System.Windows.Forms.RadioButton
    Friend WithEvents ChequeStatus As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
