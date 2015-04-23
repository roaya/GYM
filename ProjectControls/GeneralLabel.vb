Public Class GeneralLabel

    Dim LblTxt As String
    Dim _IsRequired As Boolean = False

    Property SetLabelTxt() As String
        Get
            Return LblTxt
        End Get
        Set(ByVal value As String)
            LblTxt = value
            Label1.Text = LblTxt
        End Set
    End Property

    Property IsRequired() As Boolean
        Get
            Return _IsRequired
        End Get
        Set(ByVal value As Boolean)
            _IsRequired = value
            If _IsRequired = False Then
                Me.BackColor = Color.Gainsboro
                Label1.ForeColor = Color.Black
            Else
                Label1.ForeColor = Color.Red
                Me.BackColor = Color.Gainsboro
            End If
        End Set
    End Property

End Class
