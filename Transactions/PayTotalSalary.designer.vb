<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayTotalSalary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayTotalSalary))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TotalSalaryDep = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PaymentDesc = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TxtCheque = New System.Windows.Forms.TextBox()
        Me.RadioBank = New System.Windows.Forms.RadioButton()
        Me.RadioCash = New System.Windows.Forms.RadioButton()
        Me.TotalSalaryMarketing = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TotalSalaryDep)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PaymentDesc)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.TotalSalaryMarketing)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(31, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(466, 358)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "مرتبات الموظفين"
        '
        'TotalSalaryDep
        '
        Me.TotalSalaryDep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalSalaryDep.Location = New System.Drawing.Point(60, 98)
        Me.TotalSalaryDep.Name = "TotalSalaryDep"
        Me.TotalSalaryDep.Size = New System.Drawing.Size(140, 22)
        Me.TotalSalaryDep.TabIndex = 14
        Me.TotalSalaryDep.Text = "0"
        Me.TotalSalaryDep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(241, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 18)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "اجمالي المرتبات الاداريه :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(265, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 18)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "وصف عملية السداد :"
        '
        'PaymentDesc
        '
        Me.PaymentDesc.Location = New System.Drawing.Point(60, 163)
        Me.PaymentDesc.Name = "PaymentDesc"
        Me.PaymentDesc.Size = New System.Drawing.Size(342, 26)
        Me.PaymentDesc.TabIndex = 11
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Button2)
        Me.GroupBox6.Controls.Add(Me.TxtCheque)
        Me.GroupBox6.Controls.Add(Me.RadioBank)
        Me.GroupBox6.Controls.Add(Me.RadioCash)
        Me.GroupBox6.Location = New System.Drawing.Point(37, 223)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(392, 113)
        Me.GroupBox6.TabIndex = 10
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "طريقة التعامل"
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.GYM.My.Resources.Resources.Back
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Location = New System.Drawing.Point(40, 70)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(28, 26)
        Me.Button2.TabIndex = 10
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TxtCheque
        '
        Me.TxtCheque.Location = New System.Drawing.Point(70, 70)
        Me.TxtCheque.Name = "TxtCheque"
        Me.TxtCheque.Size = New System.Drawing.Size(219, 26)
        Me.TxtCheque.TabIndex = 8
        '
        'RadioBank
        '
        Me.RadioBank.AutoSize = True
        Me.RadioBank.Location = New System.Drawing.Point(295, 72)
        Me.RadioBank.Name = "RadioBank"
        Me.RadioBank.Size = New System.Drawing.Size(58, 22)
        Me.RadioBank.TabIndex = 7
        Me.RadioBank.Text = "شيك"
        Me.RadioBank.UseVisualStyleBackColor = True
        '
        'RadioCash
        '
        Me.RadioCash.AutoSize = True
        Me.RadioCash.Checked = True
        Me.RadioCash.Location = New System.Drawing.Point(294, 31)
        Me.RadioCash.Name = "RadioCash"
        Me.RadioCash.Size = New System.Drawing.Size(59, 22)
        Me.RadioCash.TabIndex = 6
        Me.RadioCash.TabStop = True
        Me.RadioCash.Text = "نقدي"
        Me.RadioCash.UseVisualStyleBackColor = True
        '
        'TotalSalaryMarketing
        '
        Me.TotalSalaryMarketing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalSalaryMarketing.Location = New System.Drawing.Point(60, 51)
        Me.TotalSalaryMarketing.Name = "TotalSalaryMarketing"
        Me.TotalSalaryMarketing.Size = New System.Drawing.Size(140, 22)
        Me.TotalSalaryMarketing.TabIndex = 1
        Me.TotalSalaryMarketing.Text = "0"
        Me.TotalSalaryMarketing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(221, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "اجمالي المرتبات التسويقيه :"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(276, 406)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(140, 39)
        Me.Button3.TabIndex = 47
        Me.Button3.Text = "سداد"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(112, 406)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(140, 39)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "خروج"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PayTotalSalary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.GYM.My.Resources.Resources.Bigbg
        Me.ClientSize = New System.Drawing.Size(529, 466)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "PayTotalSalary"
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "دفع مرتبات شهر محدد"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TotalSalaryMarketing As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TxtCheque As System.Windows.Forms.TextBox
    Friend WithEvents RadioBank As System.Windows.Forms.RadioButton
    Friend WithEvents RadioCash As System.Windows.Forms.RadioButton
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PaymentDesc As System.Windows.Forms.TextBox
    Friend WithEvents TotalSalaryDep As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
