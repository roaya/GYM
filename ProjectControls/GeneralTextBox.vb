Public Class GeneralTextBox

    Dim Is_R As Boolean = False
    Dim Is_E As Boolean = False
    Dim _LeaveColor As Color = Color.Yellow
    Dim Is_N As Boolean = False
    Dim TxtAll As New TextBox

    Public Property IsNum() As Boolean
        Get
            Return Is_N
        End Get
        Set(ByVal value As Boolean)
            Is_N = value
        End Set
    End Property

    Public Property IsEmail() As Boolean
        Get
            Return Is_E
        End Get
        Set(ByVal value As Boolean)
            Is_E = value
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
        '    cls.MsgExclamation("ÌÃ» «œŒ«· »Ì«‰«  «·Õﬁ· «·‰«ﬁ’")
        '    TextBox1.BackColor = SetLeaveColor
        '    'TextBox1.Focus()
        '    Exit Sub
        'End If

        'If IsNum = True And Not IsNumeric(TextBox1.Text) And TextBox1.Text <> "" Then
        '    cls.MsgExclamation("ÌÃ» «œŒ«· »Ì«‰«  —ﬁ„Ì… ›ﬁÿ")
        '    TextBox1.BackColor = SetLeaveColor
        '    'TextBox1.Focus()
        '    Exit Sub
        'End If

        'If IsEmail = True And TextBox1.Text <> "" Then
        '    If Not TextBox1.Text Like "%@%.com" Then
        '        cls.MsgExclamation("ÌÃ» «œŒ«· «·«Ì„Ì· »ÿ—Ìﬁ… ’ÕÌÕ…")
        '        TextBox1.BackColor = SetLeaveColor
        '        'TextBox1.Focus()
        '        Exit Sub
        '    End If
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

End Class
