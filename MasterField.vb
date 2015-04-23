Public Class MasterField

    Dim Is_R As Boolean = True
    Dim _LeaveColor As Color = Color.Red
    Dim Is_N As Boolean = False
    Dim Enable_Field As Boolean = False
    Dim TxtAll As New TextBox
    Dim DsVal, Vval As String
    Dim Enable_Lockup As Boolean = True
    Dim Lockup_Image As Image

    Public Property IsNum() As Boolean
        Get
            Return Is_N
        End Get
        Set(ByVal value As Boolean)
            Is_N = value
        End Set
    End Property

    Public Property IsRequired() As Boolean
        Get
            Return Is_R
        End Get
        Set(ByVal value As Boolean)
            Me.BackColor = Color.Gainsboro
            TextBox1.BackColor = Color.Gainsboro

            Is_R = value
        End Set
    End Property


    <System.ComponentModel.Description("The color of the control when it leave focus"), _
  System.ComponentModel.Category("Appearance")> _
  Public Property SetLeaveColor() As Color
        Get
            Return _LeaveColor
        End Get
        Set(ByVal value As Color)
            _LeaveColor = value
        End Set
    End Property

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.BackColor = SetLeaveColor
    End Sub


    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        'If IsRequired = True And TextBox1.Text = "" Then
        '    cls.MsgExclamation("ÌÃ» «œŒ«· »Ì«‰«  «·Õﬁ· «·‰«ﬁ’", "please enter required field")
        '    Me.Focus()
        '    Me.BackColor = SetLeaveColor
        'ElseIf IsNum = True And Not IsNumeric(TextBox1.Text) And TextBox1.Text <> "" Then
        '    cls.MsgExclamation("ÌÃ» «œŒ«· »Ì«‰«  —ﬁ„Ì… ›ﬁÿ", "you must enter numeric data only")
        '    Me.Focus()
        '    Me.BackColor = SetLeaveColor
        'Else
        '    Me.BackColor = Color.White
        'End If


        TextBox1.BackColor = Color.Gainsboro
    End Sub

    Public Property GetAllField() As TextBox
        Get
            Return TxtAll
        End Get
        Set(ByVal value As TextBox)
            TxtAll = value
            TextBox1 = TxtAll
        End Set
    End Property

    Public Property SetDisplayMember() As String
        Get
            Return DsVal
        End Get
        Set(ByVal value As String)
            DsVal = value
        End Set
    End Property

    Public Property SetValueMember() As String
        Get
            Return Vval
        End Get
        Set(ByVal value As String)
            Vval = value
        End Set
    End Property

    Public Property EnableField() As Boolean
        Get
            Return Enable_Field
        End Get
        Set(ByVal value As Boolean)
            Enable_Field = value
            TextBox1.Enabled = Enable_Field
        End Set
    End Property

    Public Property EnableLockup() As Boolean
        Get
            Return Enable_Lockup
        End Get
        Set(ByVal value As Boolean)
            Enable_Lockup = value
            Button1.Enabled = Enable_Lockup
        End Set
    End Property

    Public Property SetLockupImage() As Image
        Get
            Return Lockup_Image
        End Get
        Set(ByVal value As Image)
            Lockup_Image = value
            Button1.Image = Lockup_Image
        End Set
    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim m As New SearchWindow
        m.DsMember = SetDisplayMember
        m.ValMember = SetValueMember
        m.ShowDialog()


    End Sub

End Class
