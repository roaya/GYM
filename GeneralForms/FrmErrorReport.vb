Imports System.Net.Mail

Public Class FrmErrorReport

    Public ErrTxtMsg, Frm As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.EnableSsl = False
            SmtpServer.Credentials = New  _
    Net.NetworkCredential("info@roayasoft.com", "roaya")
            'SmtpServer.EnableSsl = False
            SmtpServer.Port = 587
            SmtpServer.Host = "mail.roayasoft.com"

            mail = New MailMessage()
            mail.From = New MailAddress("info@roayasoft.com")
            mail.To.Add("info@roayasoft.com")
            mail.Subject = "Master Chief - System Errors"
            mail.Body = ErrTxtMsg
            SmtpServer.Send(mail)

            MsgBox("تم ارسال تقرير الأخطاء بنجاح", MsgBoxStyle.Information, ProjectTitle)
            Me.Close()
        Catch ex As Exception
            MsgBox("حدث خطأ أثناء ارسال تقرير الأخطاء برجاء التحقق من اتصالك بالانترنت", MsgBoxStyle.Critical, ProjectTitle)

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\App.Err") = False Then
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\App.Err", ErrTxtMsg & " - " & UserNameVar & " - " & EmpIDVar & " - " & EmpNameVar & " - " & Frm, False)
            Else
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\App.Err", ErrTxtMsg & " - " & UserNameVar & " - " & EmpIDVar & " - " & EmpNameVar & " - " & Frm, True)
            End If
            MsgBox("تم انشاء تقرير الأخطاء بنجاح", MsgBoxStyle.Information, ProjectTitle)
            Me.Close()
        Catch ex As Exception
            MsgBox("حدث خطأ أثناء كتابة التقرير برجاء الاتصال بمسئولي الدعم الفني بشركة رؤيه للبرمجيات", MsgBoxStyle.Critical, ProjectTitle)

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class