Public Class PaymentSchedule

    Friend CustID As Integer

    Private Sub CheckFirstPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckFirstPayment.CheckedChanged
        If CheckFirstPayment.Checked = True Then
            FirstPayment.Enabled = True
            FirstDate.Enabled = True
            SecondPayment.Enabled = False
            SecondDate.Enabled = False
            ThirdPayment.Enabled = False
            ThirdDate.Enabled = False
            ForthPayment.Enabled = False
            ForthDate.Enabled = False
            FifthPayment.Enabled = False
            FifthDate.Enabled = False
            SixthPayment.Enabled = False
            SixthDate.Enabled = False
            SeventhPayment.Enabled = False
            SeventhDate.Enabled = False
            EightthPayment.Enabled = False
            EightthDate.Enabled = False
            NinthPayment.Enabled = False
            NinthDate.Enabled = False
            TenthPayment.Enabled = False
            TenthDate.Enabled = False
            ElevnethPayment.Enabled = False
            ElevnethDate.Enabled = False
            TwelvethPayment.Enabled = False
            TwelvethDate.Enabled = False
            TherteenthPayment.Enabled = False
            TherteenthDate.Enabled = False
            FourteenthPayment.Enabled = False
            FourteenthDate.Enabled = False
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        FirstPayment.Value = 0
        SecondPayment.Value = 0
        ThirdPayment.Value = 0
        ForthPayment.Value = 0
        FifthPayment.Value = 0
        SixthPayment.Value = 0
        SeventhPayment.Value = 0
        EightthPayment.Value = 0
        NinthPayment.Value = 0
        TenthPayment.Value = 0
        ElevnethPayment.Value = 0
        TwelvethPayment.Value = 0
        TherteenthPayment.Value = 0
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckSecondPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckSecondPayment.CheckedChanged
        If CheckSecondPayment.Checked = True Then
            SecondPayment.Enabled = True
            SecondDate.Enabled = True
            ThirdPayment.Enabled = False
            ThirdDate.Enabled = False
            ForthPayment.Enabled = False
            ForthDate.Enabled = False
            FifthPayment.Enabled = False
            FifthDate.Enabled = False
        
            SixthPayment.Enabled = False
            SixthDate.Enabled = False
            SeventhPayment.Enabled = False
            SeventhDate.Enabled = False
            EightthPayment.Enabled = False
            EightthDate.Enabled = False
            NinthPayment.Enabled = False
            NinthDate.Enabled = False
            TenthPayment.Enabled = False
            TenthDate.Enabled = False
            ElevnethPayment.Enabled = False
            ElevnethDate.Enabled = False
            TwelvethPayment.Enabled = False
            TwelvethDate.Enabled = False
            TherteenthPayment.Enabled = False
            TherteenthDate.Enabled = False
            FourteenthPayment.Enabled = False
            FourteenthDate.Enabled = False
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        SecondPayment.Value = 0
        ThirdPayment.Value = 0
        ForthPayment.Value = 0
        FifthPayment.Value = 0
        SixthPayment.Value = 0
        SeventhPayment.Value = 0
        EightthPayment.Value = 0
        NinthPayment.Value = 0
        TenthPayment.Value = 0
        ElevnethPayment.Value = 0
        TwelvethPayment.Value = 0
        TherteenthPayment.Value = 0
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckThirdPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckThirdPayment.CheckedChanged
        If CheckThirdPayment.Checked = True Then
            ThirdPayment.Enabled = True
            ThirdDate.Enabled = True
            ForthPayment.Enabled = False
            ForthDate.Enabled = False
            FifthPayment.Enabled = False
            FifthDate.Enabled = False

            SixthPayment.Enabled = False
            SixthDate.Enabled = False
            SeventhPayment.Enabled = False
            SeventhDate.Enabled = False
            EightthPayment.Enabled = False
            EightthDate.Enabled = False
            NinthPayment.Enabled = False
            NinthDate.Enabled = False
            TenthPayment.Enabled = False
            TenthDate.Enabled = False
            ElevnethPayment.Enabled = False
            ElevnethDate.Enabled = False
            TwelvethPayment.Enabled = False
            TwelvethDate.Enabled = False
            TherteenthPayment.Enabled = False
            TherteenthDate.Enabled = False
            FourteenthPayment.Enabled = False
            FourteenthDate.Enabled = False
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        ThirdPayment.Value = 0
        ForthPayment.Value = 0
        FifthPayment.Value = 0
        SixthPayment.Value = 0
        SeventhPayment.Value = 0
        EightthPayment.Value = 0
        NinthPayment.Value = 0
        TenthPayment.Value = 0
        ElevnethPayment.Value = 0
        TwelvethPayment.Value = 0
        TherteenthPayment.Value = 0
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckForthPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckForthPayment.CheckedChanged
        If CheckForthPayment.Checked = True Then
            ForthPayment.Enabled = True
            ForthDate.Enabled = True
            FifthPayment.Enabled = False
            FifthDate.Enabled = False

            SixthPayment.Enabled = False
            SixthDate.Enabled = False
            SeventhPayment.Enabled = False
            SeventhDate.Enabled = False
            EightthPayment.Enabled = False
            EightthDate.Enabled = False
            NinthPayment.Enabled = False
            NinthDate.Enabled = False
            TenthPayment.Enabled = False
            TenthDate.Enabled = False
            ElevnethPayment.Enabled = False
            ElevnethDate.Enabled = False
            TwelvethPayment.Enabled = False
            TwelvethDate.Enabled = False
            TherteenthPayment.Enabled = False
            TherteenthDate.Enabled = False
            FourteenthPayment.Enabled = False
            FourteenthDate.Enabled = False
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        ForthPayment.Value = 0
        FifthPayment.Value = 0
        SixthPayment.Value = 0
        SeventhPayment.Value = 0
        EightthPayment.Value = 0
        NinthPayment.Value = 0
        TenthPayment.Value = 0
        ElevnethPayment.Value = 0
        TwelvethPayment.Value = 0
        TherteenthPayment.Value = 0
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckFifthPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckFifthPayment.CheckedChanged
        If CheckForthPayment.Checked = True Then
            FifthPayment.Enabled = True
            FifthDate.Enabled = True

            SixthPayment.Enabled = False
            SixthDate.Enabled = False
            SeventhPayment.Enabled = False
            SeventhDate.Enabled = False
            EightthPayment.Enabled = False
            EightthDate.Enabled = False
            NinthPayment.Enabled = False
            NinthDate.Enabled = False
            TenthPayment.Enabled = False
            TenthDate.Enabled = False
            ElevnethPayment.Enabled = False
            ElevnethDate.Enabled = False
            TwelvethPayment.Enabled = False
            TwelvethDate.Enabled = False
            TherteenthPayment.Enabled = False
            TherteenthDate.Enabled = False
            FourteenthPayment.Enabled = False
            FourteenthDate.Enabled = False
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        FifthPayment.Value = 0
        SixthPayment.Value = 0
        SeventhPayment.Value = 0
        EightthPayment.Value = 0
        NinthPayment.Value = 0
        TenthPayment.Value = 0
        ElevnethPayment.Value = 0
        TwelvethPayment.Value = 0
        TherteenthPayment.Value = 0
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If FirstPayment.Value + SecondPayment.Value + ThirdPayment.Value + ForthPayment.Value + FifthPayment.Value + SixthPayment.Value + SeventhPayment.Value + EightthPayment.Value + NinthPayment.Value + TenthPayment.Value + ElevnethPayment.Value + TwelvethPayment.Value + TherteenthPayment.Value + FourteenthPayment.Value + FifteenthPayment.Value + SixteenthPayment.Value + SeventeenthPayment.Value + EighteenthPayment.Value + NineteenthPayment.Value + TwentyPayment.Value <> CDbl(TotalPayments.Text) Then
                cls.MsgCritical("القيم المجدولة يجب ان تتساوي مع اجمالي قيمة الآجل", "value of scheduled phases must be equal to total credit")
            ElseIf CheckFirstPayment.Checked = True And FirstPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckSecondPayment.Checked = True And SecondPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckThirdPayment.Checked = True And ThirdPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckForthPayment.Checked = True And ForthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckFifthPayment.Checked = True And FifthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckSixth.Checked = True And SixthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckSeventhPayment.Checked = True And SeventhPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckEightthPayment.Checked = True And EightthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckNinthPayment.Checked = True And NinthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckTenth.Checked = True And TenthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckElevnethPayment.Checked = True And ElevnethPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckTwelvethPayment.Checked = True And TwelvethPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckTherteenthPayment.Checked = True And TherteenthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckFourteenthPayment.Checked = True And FourteenthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckFifteenthPayment.Checked = True And FifteenthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckSixteenthPayment.Checked = True And SixteenthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckSeventeenthPayment.Checked = True And SeventeenthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckEighteenthPayment.Checked = True And EighteenthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckNineteenthPayment.Checked = True And NineteenthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            ElseIf CheckTwentyPayment.Checked = True And TwentyPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة", "please enter phase value")
            Else

                MyDs.Tables("Sch_Payments").Rows.Clear()

                If CheckFirstPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = FirstDate.Text '.ToString("MM/dd/yyyy")
                    r("Customer_ID") = CustID
                    r("Payment_Value") = FirstPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)

                    'cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & CustID & " , " & FirstPayment.Value
                    'cmd.ExecuteNonQuery()
                End If

                If CheckSecondPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = SecondDate.Text 'd.ToString("MM/dd/yyyy")
                    r("Customer_ID") = CustID
                    r("Payment_Value") = SecondPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                    'cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & CustID & " , " & SecondPayment.Value
                    'cmd.ExecuteNonQuery()
                End If

                If CheckThirdPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = ThirdDate.Text 'd.ToString("MM/dd/yyyy")
                    r("Customer_ID") = CustID
                    r("Payment_Value") = ThirdPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                    'cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & CustID & " , " & ThirdPayment.Value
                    'cmd.ExecuteNonQuery()
                End If

                If CheckForthPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = ForthDate.Text 'd.ToString("MM/dd/yyyy")
                    r("Customer_ID") = CustID
                    r("Payment_Value") = ForthPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                    'cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & CustID & " , " & ForthPayment.Value
                    'cmd.ExecuteNonQuery()
                End If

                If CheckFifthPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = FifthDate.Text 'd.ToString("MM/dd/yyyy")
                    r("Customer_ID") = CustID
                    r("Payment_Value") = FifthPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                    'cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & CustID & " , " & FifthPayment.Value
                    'cmd.ExecuteNonQuery()
                End If

                If CheckSixth.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = SixthDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = SixthPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckSeventhPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = SeventhDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = SeventhPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckEightthPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = EightthDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = EightthPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckNinthPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = NinthDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = NinthPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckTenth.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = TenthDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = TenthPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckElevnethPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = ElevnethDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = ElevnethPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckTwelvethPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = TwelvethDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = TwelvethPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckTherteenthPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = TherteenthDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = TherteenthPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckFourteenthPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = FourteenthDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = FourteenthPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckFifteenthPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = FifteenthDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = FifteenthPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckSixteenthPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = SixteenthDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = SixteenthPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckSeventeenthPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = SeventeenthDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = SeventeenthPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckEighteenthPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = EighteenthDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = EighteenthPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckNineteenthPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = NineteenthDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = NineteenthPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                If CheckTwentyPayment.Checked = True Then
                    r = MyDs.Tables("Sch_Payments").NewRow
                    r("Payment_Date") = TwentyDate.Text
                    r("Customer_ID") = CustID
                    r("Payment_Value") = TwentyPayment.Value
                    MyDs.Tables("Sch_Payments").Rows.Add(r)
                End If

                cls.MsgInfo("تم جدولة مواعيد الدفع بنجاح", "payment phases has been scheduled successfully")
                Me.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Cust Sch Payments")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MyDs.Tables("Sch_Payments").Rows.Clear()
        cls.MsgInfo("تم الغاء الدفعات المجدولة بنجاح", "phases has been canceled successfully")
        Me.Close()
    End Sub

    Private Sub CheckSixth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckSixth.CheckedChanged
        If CheckSixth.Checked = True Then

            SixthPayment.Enabled = True
            SixthDate.Enabled = True
            SeventhPayment.Enabled = False
            SeventhDate.Enabled = False
            EightthPayment.Enabled = False
            EightthDate.Enabled = False
            NinthPayment.Enabled = False
            NinthDate.Enabled = False
            TenthPayment.Enabled = False
            TenthDate.Enabled = False
            ElevnethPayment.Enabled = False
            ElevnethDate.Enabled = False
            TwelvethPayment.Enabled = False
            TwelvethDate.Enabled = False
            TherteenthPayment.Enabled = False
            TherteenthDate.Enabled = False
            FourteenthPayment.Enabled = False
            FourteenthDate.Enabled = False
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        SixthPayment.Value = 0
        SeventhPayment.Value = 0
        EightthPayment.Value = 0
        NinthPayment.Value = 0
        TenthPayment.Value = 0
        ElevnethPayment.Value = 0
        TwelvethPayment.Value = 0
        TherteenthPayment.Value = 0
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckSeventhPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckSeventhPayment.CheckedChanged
        If CheckSeventhPayment.Checked = True Then
            SeventhPayment.Enabled = True
            SeventhDate.Enabled = True
            EightthPayment.Enabled = False
            EightthDate.Enabled = False
            NinthPayment.Enabled = False
            NinthDate.Enabled = False
            TenthPayment.Enabled = False
            TenthDate.Enabled = False
            ElevnethPayment.Enabled = False
            ElevnethDate.Enabled = False
            TwelvethPayment.Enabled = False
            TwelvethDate.Enabled = False
            TherteenthPayment.Enabled = False
            TherteenthDate.Enabled = False
            FourteenthPayment.Enabled = False
            FourteenthDate.Enabled = False
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        SeventhPayment.Value = 0
        EightthPayment.Value = 0
        NinthPayment.Value = 0
        TenthPayment.Value = 0
        ElevnethPayment.Value = 0
        TwelvethPayment.Value = 0
        TherteenthPayment.Value = 0
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckEightthPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEightthPayment.CheckedChanged
        If CheckEightthPayment.Checked = True Then
            EightthPayment.Enabled = True
            EightthDate.Enabled = True
            NinthPayment.Enabled = False
            NinthDate.Enabled = False
            TenthPayment.Enabled = False
            TenthDate.Enabled = False
            ElevnethPayment.Enabled = False
            ElevnethDate.Enabled = False
            TwelvethPayment.Enabled = False
            TwelvethDate.Enabled = False
            TherteenthPayment.Enabled = False
            TherteenthDate.Enabled = False
            FourteenthPayment.Enabled = False
            FourteenthDate.Enabled = False
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        EightthPayment.Value = 0
        NinthPayment.Value = 0
        TenthPayment.Value = 0
        ElevnethPayment.Value = 0
        TwelvethPayment.Value = 0
        TherteenthPayment.Value = 0
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckNinthPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckNinthPayment.CheckedChanged
        If CheckNinthPayment.Checked = True Then
            NinthPayment.Enabled = True
            NinthDate.Enabled = True
            TenthPayment.Enabled = False
            TenthDate.Enabled = False
            ElevnethPayment.Enabled = False
            ElevnethDate.Enabled = False
            TwelvethPayment.Enabled = False
            TwelvethDate.Enabled = False
            TherteenthPayment.Enabled = False
            TherteenthDate.Enabled = False
            FourteenthPayment.Enabled = False
            FourteenthDate.Enabled = False
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        NinthPayment.Value = 0
        TenthPayment.Value = 0
        ElevnethPayment.Value = 0
        TwelvethPayment.Value = 0
        TherteenthPayment.Value = 0
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckTenth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTenth.CheckedChanged
        If CheckTenth.Checked = True Then
            TenthPayment.Enabled = True
            TenthDate.Enabled = True
            ElevnethPayment.Enabled = False
            ElevnethDate.Enabled = False
            TwelvethPayment.Enabled = False
            TwelvethDate.Enabled = False
            TherteenthPayment.Enabled = False
            TherteenthDate.Enabled = False
            FourteenthPayment.Enabled = False
            FourteenthDate.Enabled = False
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        TenthPayment.Value = 0
        ElevnethPayment.Value = 0
        TwelvethPayment.Value = 0
        TherteenthPayment.Value = 0
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckElevnethPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckElevnethPayment.CheckedChanged
        If CheckElevnethPayment.Checked = True Then
            ElevnethPayment.Enabled = True
            ElevnethDate.Enabled = True
            TwelvethPayment.Enabled = False
            TwelvethDate.Enabled = False
            TherteenthPayment.Enabled = False
            TherteenthDate.Enabled = False
            FourteenthPayment.Enabled = False
            FourteenthDate.Enabled = False
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        ElevnethPayment.Value = 0
        TwelvethPayment.Value = 0
        TherteenthPayment.Value = 0
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckTwelvethPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTwelvethPayment.CheckedChanged
        If CheckTwelvethPayment.Checked = True Then
            TwelvethPayment.Enabled = True
            TwelvethDate.Enabled = True
            TherteenthPayment.Enabled = False
            TherteenthDate.Enabled = False
            FourteenthPayment.Enabled = False
            FourteenthDate.Enabled = False
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        TwelvethPayment.Value = 0
        TherteenthPayment.Value = 0
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckTherteenthPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTherteenthPayment.CheckedChanged
        If CheckTherteenthPayment.Checked = True Then
            TherteenthPayment.Enabled = True
            TherteenthDate.Enabled = True
            FourteenthPayment.Enabled = False
            FourteenthDate.Enabled = False
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        TherteenthPayment.Value = 0
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckFourteenthPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckFourteenthPayment.CheckedChanged
        If CheckFourteenthPayment.Checked = True Then
            FourteenthPayment.Enabled = True
            FourteenthDate.Enabled = True
            FifteenthPayment.Enabled = False
            FifteenthDate.Enabled = False
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        FourteenthPayment.Value = 0
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckFifteenthPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckFifteenthPayment.CheckedChanged
        If CheckFifteenthPayment.Checked = True Then
            FifteenthPayment.Enabled = True
            FifteenthDate.Enabled = True
            SixteenthPayment.Enabled = False
            SixteenthDate.Enabled = False
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        FifteenthPayment.Value = 0
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckSixteenthPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckSixteenthPayment.CheckedChanged
        If CheckSixteenthPayment.Checked = True Then
            SixteenthPayment.Enabled = True
            SixteenthDate.Enabled = True
            SeventeenthPayment.Enabled = False
            SeventeenthDate.Enabled = False
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        SixteenthPayment.Value = 0
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckSeventeenthPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckSeventeenthPayment.CheckedChanged
        If CheckSeventeenthPayment.Checked = True Then
            SeventeenthPayment.Enabled = True
            SeventeenthDate.Enabled = True
            EighteenthPayment.Enabled = False
            EighteenthDate.Enabled = False
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        SeventeenthPayment.Value = 0
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckEighteenthPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEighteenthPayment.CheckedChanged
        If CheckEighteenthPayment.Checked = True Then
            EighteenthPayment.Enabled = True
            EighteenthDate.Enabled = True
            NineteenthPayment.Enabled = False
            NineteenthDate.Enabled = False
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        EighteenthPayment.Value = 0
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckNineteenthPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckNineteenthPayment.CheckedChanged
        If CheckNineteenthPayment.Checked = True Then
            NineteenthPayment.Enabled = True
            NineteenthDate.Enabled = True
            TwentyPayment.Enabled = False
            TwentyDate.Enabled = False
        End If
        NineteenthPayment.Value = 0
        TwentyPayment.Value = 0
    End Sub

    Private Sub CheckTwentyPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTwentyPayment.CheckedChanged
        If CheckTwentyPayment.Checked = True Then
            TwentyPayment.Enabled = True
            TwentyDate.Enabled = True
        End If
        TwentyPayment.Value = 0
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            MyDs.Tables("Sch_Payments").Rows.Clear()
            Dim i As Integer = InputBox("أدخل عدد الاقساط", ProjectTitle)
            If i > 20 Then
                cls.MsgExclamation("عدد الأقساط يجب ألا يزيد علي 20 قسط", "Number of phases must be less than or equal twenty")
                Exit Sub
            End If
            Dim PhaseValue As Double = CDbl(TotalPayments.Text) / i

            For x As Integer = 0 To i - 1
                r = MyDs.Tables("Sch_Payments").NewRow
                r("Payment_Date") = Now.AddMonths(x + 1).ToString("dd/MM/yyyy")
                r("Customer_ID") = CustID
                r("Payment_Value") = Math.Round(PhaseValue, 2)
                MyDs.Tables("Sch_Payments").Rows.Add(r)
            Next
            cls.MsgInfo("تم جدولة الأقساط بنجاح", "phases have been scheduled successfully")
            Me.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Cust Payment Schedule")
        End Try
    End Sub
End Class