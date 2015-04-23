Public Class GeneralSearch

    Public STable As New GeneralDataSet.SearchTableDataTable
    Public DtlTbl As New DataTable
   
    Private Sub GeneralSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GrdSearch.DataSource = STable
        GrdSearch.Columns(0).Visible = False
        GrdSearch.Columns(1).HeaderText = "نوع البيانات"
        GrdSearch.Columns(2).HeaderText = "البيان التوضيحي"
        GrdSearch.Columns(3).HeaderText = "وصف البيانات"
        GrdSearchDetails.DataSource = DtlTbl
        
    End Sub

    Private Sub GrdSearch_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdSearch.RowHeaderMouseDoubleClick

        DtlTbl.Rows.Clear()
        DtlTbl.Columns.Clear()

        Select Case GrdSearch.SelectedRows(0).Cells("ColType").Value
            Case "عملاء"
                cmd.CommandText = "select customer_id , customer_name as N'اسم العميل',customer_code as N'كود العميل' ,address as N'العنوان', Mobile as N'الموبايل', Tele as N'التليفون' from customers where customer_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "موردين"
                cmd.CommandText = "select vendor_id , vendor_name as N'اسم المورد', address as N'العنوان', Mobile as N'الموبايل', Tele as N'التليفون' from vendors where vendor_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بيانات العاملين"
                cmd.CommandText = "select employee_id , employee_name as N'اسم الموظف', address as N'العنوان', Mobile as N'الموبايل', Tele as N'التليفون' from employees where employee_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بنود المصروفات"
                cmd.CommandText = "select Expense_Detail_id , Expense_name as N'اسم المصروف' from Expenses_Details where Expense_Category_ID = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بيانات الأصناف"
                cmd.CommandText = "select distinct item_id , Corporation_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله' from Query_All_Items where item_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "المحلات"
                cmd.CommandText = "select distinct item_id ,Corporation_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله' from Query_All_Items where stock_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بنود المخزن"
                cmd.CommandText = "select distinct item_id ,Corporation_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله' from Query_All_Items where category_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "الشركات"
                cmd.CommandText = "select distinct item_id ,Corporation_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله' from Query_All_Items where corporation_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "مجموعات القياس"
                cmd.CommandText = "select distinct item_id ,Corporation_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله' from Query_All_Items where Um_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "البنوك"
                cmd.CommandText = "select distinct Account_ID ,Account_Number as N'رقم الحساب' ,Created_Date as N'تاريخ الانشاء' from Banks_Accounts where Bank_ID = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "الشيكات"
                cmd.CommandText = "select distinct Cheque_ID ,Cheque_Number as N'رقم الشيك' ,Cheque_Value as N'قيمة الشيك',Cheque_Status as N'الحاله'  from Cheques where Cheque_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "فئات الآجل"
                cmd.CommandText = "select customer_id , customer_name as N'اسم العميل', address as N'العنوان', Mobile as N'الموبايل', Tele as N'التليفون' from customers where Level_ID = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "فئات الخصم"
                cmd.CommandText = "select customer_id , customer_name as N'اسم العميل', address as N'العنوان', Mobile as N'الموبايل', Tele as N'التليفون' from customers where Discount_Level_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "شجرة الحسابات"
                cmd.CommandText = "select Procedure_Master_ID , Daily_Procedure_Name as N'اسم الحساب', Procedure_Category as N'بند الحساب', Procedure_Type as N'طبيعة الحساب' from Procedure_Master where Procedure_Master_ID = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "الاشتراكات"
                cmd.CommandText = "select subscription_id , subscription_Name as N'اسم الاشتراك', value_group as N'سعر المجموعه',value_single as N'سعر الخاص' from subscriptions where subscription_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بنود الاشتراكات"
                cmd.CommandText = "select category_id , category_name as N'بند الاشتراك', generic_desc as N'وصف مختصر' from subscriptions_categories where category_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "الجلسات الخاصه"
                cmd.CommandText = "select special_categories_id , category_Name as N'الجلسه الخاصه', value as N'قيمة الجلسه' ,Coach_percent as N'نسبة المدرب' from special_categories where special_categories_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value


        End Select

        da.SelectCommand = cmd
        da.Fill(DtlTbl)
        GrdSearchDetails.Columns(0).Visible = False
    End Sub

    Private Sub GrdSearchDetails_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdSearchDetails.RowHeaderMouseDoubleClick
        Select Case GrdSearchDetails.SelectedRows(0).Cells(0).OwningColumn.Name
            Case "customer_id"
                Dim m As New Customers
                m.SearchCustomerID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "vendor_id"
                Dim m As New Vendors
                m.SearchVendorID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "employee_id"
                Dim m As New Employees
                m.SearchEmployeeID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "Expense_Detail_id"
                Dim m As New ExpensesDetails
                m.SearchExpenseDetailID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "item_id"
                Dim m As New Items
                m.SearchItemID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "Account_ID"
                Dim m As New BankAccounts
                m.SearchAccID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "Cheque_ID"
                Dim m As New Cheques
                m.SearchChqID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "Procedure_Master_ID"
                Dim m As New DailyProcedures
                m.SearchProID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "Visa_ID"
                Dim m As New Visa
                m.SearchVisaID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "subscription_id"
                Dim m As New Subscriptions
                m.SearchSubscriptionId = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "category_id"
                Dim m As New SubscriptionsCategories
                m.SearchSubscCategoryID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "subscription_categories_id"
                Dim m As New SpecialCategories
                m.SearchSpecialID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
        End Select
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Visible = False
    End Sub

   
End Class