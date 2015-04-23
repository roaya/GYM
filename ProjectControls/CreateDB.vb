Public Class CreateDB

    Dim b As Boolean = True

    Sub CalcProgress()
        ProgressBar1.Value = ProgressBar1.Value + 10
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            ProgressBar1.Value = 0
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Button1.Enabled = False
            ProgressBar1.Visible = True
            Label1.Visible = True

            Me.Cursor = Cursors.WaitCursor

            If RadioNewDB.Checked = True Then
                b = False
                CreateNewDB()
                Me.Cursor = Cursors.Default
                cls.MsgInfo("تم انشاء قاعدة البيانات بنجاح", "a new database has been created successfully please be noticed that a new user has been created successfully according to the default security setting also system settings have been adjusted to the default system settings")
                b = True
                Me.Close()

            ElseIf RadioRecreate.Checked = True Then
                Try
                    b = False
                    If cls.CheckDatabaseAttached("gym") = False Then
                        cmd.CommandText = "EXECUTE sp_detach_db N'gym'"
                        cmd.ExecuteNonQuery()
                    End If
                    If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\gym.mdf") = True Then
                        My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\gym.mdf", False, False)
                    End If

                    If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\gym_log.ldf") = True Then
                        My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\gym_log.ldf", False, False)
                    End If
                    CreateNewDB()
                Catch ex As Exception
                    Button1.Enabled = True
                    Label1.Visible = False
                    ProgressBar1.Value = False
                    ProgressBar1.Value = 0
                    b = True
                    cls.MsgCritical("تعذر حذف قاعدة البيانات المحددة", "unable to remove current database please contact system administrator")
                End Try
            End If


        Catch ex As Exception
            b = True
            Button1.Enabled = True
            Label1.Visible = False
            ProgressBar1.Value = False
            ProgressBar1.Value = 0
            cls.MsgCritical("تعذر انشاء قاعدة البيانات المحددة", "unable to create new database please contact system administrator")
            cls.WriteError(ex.Message, "Create DB")
            End
        End Try
    End Sub

    Sub CreateNewDB()
        cmd.CommandText = "use master; CREATE DATABASE [gym] ON PRIMARY( NAME = N'gym', FILENAME = N'" & My.Application.Info.DirectoryPath & "\gym.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ) LOG ON ( NAME = N'gym_log', FILENAME = N'" & My.Application.Info.DirectoryPath & "\gym_log.ldf' , SIZE = 1024KB , MAXSIZE =  2048GB , FILEGROWTH = 10%);"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = TextBox1.Text
        cmd.ExecuteNonQuery()

        CalcProgress()


        '**************************************************************************************************



        cmd.CommandText = " USE [gym]"
        cmd.ExecuteNonQuery()



        cmd.CommandText = " CREATE TABLE [dbo].[Um_Master]( 	[Um_Id] [int] IDENTITY(1,1) NOT NULL, 	[Um_Name] [nvarchar](50) NOT NULL, 	[Um_Desc] [nvarchar](150) NULL, 	[Base_Um] [nvarchar](50) NULL,  CONSTRAINT [Um_Master_um_id_pk] PRIMARY KEY CLUSTERED  ( 	[Um_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [Um_Master_um_name_un] UNIQUE NONCLUSTERED  ( 	[Um_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " CREATE TABLE [dbo].[Um_Details]( 	[Um_Detail_Id] [int] IDENTITY(1,1) NOT NULL, 	[Equivalent_name] [nvarchar](50) NOT NULL, 	[Equivalent_Quantity] [decimal](18, 2) NULL, 	[Um_Id] [int] NOT NULL,  CONSTRAINT [um_details_um_detail_id_pk] PRIMARY KEY CLUSTERED  ( 	[Um_Detail_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [um_details_equivelant_name_un] UNIQUE NONCLUSTERED  ( 	[Equivalent_name] ASC, 	[Um_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " CREATE TABLE [dbo].[Stocks]( 	[Stock_Id] [int] IDENTITY(1,1) NOT NULL, 	[Stock_Name] [nvarchar](50) NOT NULL, 	[Description] [nvarchar](150) NULL, 	[Tele] [nvarchar](25) NULL, 	[Address] [nvarchar](150) NULL, 	[Web_Site] [nvarchar](50) NULL, 	[Logo] [image] NULL, 	[Emp_Reference_ID] [int] NULL,  CONSTRAINT [stocks_stock_id_pk] PRIMARY KEY CLUSTERED  ( 	[Stock_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [stocks_stock_name_un] UNIQUE NONCLUSTERED  ( 	[Stock_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " CREATE TABLE [dbo].[Categories]( 	[Category_Id] [int] IDENTITY(1,1) NOT NULL, 	[Category_Name] [nvarchar](50) NOT NULL, 	[Generic_Description] [nvarchar](150) NULL,  CONSTRAINT [categories_category_id_pk] PRIMARY KEY CLUSTERED  ( 	[Category_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [categories_category_name_un] UNIQUE NONCLUSTERED  ( 	[Category_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " CREATE TABLE [dbo].[App_Preferences]( 	[Serial_PK] [int] NOT NULL, 	[Gen_View_Alert] [bit] NULL, 	[Gen_Print_Barcode] [nvarchar](5) NULL, 	[Gen_Attach_Item_Stk] [bit] NULL, 	[Gen_Attach_Item_Ven] [bit] NULL, 	[Gen_Print_Type] [nvarchar](50) NULL, 	[Gen_View_Msg] [bit] NULL, 	[Gen_View_Before_Print] [bit] NULL, 	[Gen_Back_Photo] [image] NULL, 	[Pur_Stk_ID] [int] NULL, 	[Pur_Def_Qty] [int] NULL, 	[Pur_Def_Style] [nvarchar](15) NULL, 	[Pur_Def_Sch] [nvarchar](15) NULL, 	[Pur_Def_Filter] [nvarchar](50) NULL, 	[Sal_Def_Qty] [int] NULL, 	[Sal_Def_Style] [nvarchar](15) NULL, 	[Sal_Def_Sch] [nvarchar](15) NULL, 	[Sal_Def_Filter] [nvarchar](50) NULL, 	[Sal_Def_Ord_Type] [nvarchar](15) NULL, 	[Sal_Edit_Emp_ID] [bit] NULL, 	[Sal_Edit_Date] [bit] NULL, 	[Ret_Cus_Def_Qty] [int] NULL, 	[Ret_Cus_Def_Sch] [nvarchar](15) NULL, 	[Ret_Ven_Def_Qty] [int] NULL, 	[Ret_Ven_Def_Sch] [nvarchar](15) NULL, 	[Dep_Def_Qty] [int] NULL, 	[Dep_Def_Sch] [nvarchar](15) NULL, 	[Req_Cus_Def_Qty] [int] NULL, 	[Req_Cus_Def_Sch] [nvarchar](15) NULL, 	[Adj_Def_Qty] [int] NULL, 	[Adj_Def_Sch] [nvarchar](15) NULL, 	[Gen_Sender_Email] [nvarchar](150) NULL, 	[Gen_Sender_Pwd] [nvarchar](50) NULL, 	[Gen_Is_Send] [bit] NULL, 	[Gen_Receipt_Email] [nvarchar](150) NULL, 	[Gen_Send_Action] [nvarchar](20) NULL, 	[Sal_Footer] [nvarchar](150) NULL, 	[Gen_SMS_Is_Send] [bit] NULL, 	[Gen_SMS_URL] [nvarchar](4000) NULL, 	[Min_Hours] [decimal](18, 2) NULL, 	[Work_Hours] [decimal](18, 2) NULL, 	[Extra_Hours] [decimal](18, 2) NULL, 	[Less_Hours] [decimal](18, 2) NULL, 	[Min_Customers] [decimal](18, 2) NULL, 	[Extra_Customers] [decimal](18, 2) NULL, 	[Less_Customers] [decimal](18, 2) NULL,[Extra_Subsc] [decimal](18, 2) NULL,P_HeaderReport nvarchar(100),Logo image,  CONSTRAINT [PK_App_Preferences] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " CREATE TABLE [dbo].[Corporations]( 	[Corporation_Id] [int] IDENTITY(1,1) NOT NULL, 	[Corporation_Name] [nvarchar](50) NOT NULL, 	[Corporation_Code] [nvarchar](50) NOT NULL, 	[Email] [nvarchar](50) NULL, 	[Web_Site] [nvarchar](50) NULL, 	[Contact_Person] [nvarchar](50) NULL, 	[Tele] [nvarchar](25) NULL, 	[Mobile] [nvarchar](25) NULL, 	[Fax] [nvarchar](50) NULL, 	[Nationality] [nvarchar](50) NULL,  CONSTRAINT [corporations_corporation_id_pk] PRIMARY KEY CLUSTERED  ( 	[Corporation_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [corporations_corporation_name_un] UNIQUE NONCLUSTERED  ( 	[Corporation_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [Corporations_Corproation_Code_Un] UNIQUE NONCLUSTERED  ( 	[Corporation_Code] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " CREATE PROCEDURE [dbo].[Attach_All_Stock_Item](@ITM_ID INT) AS BEGIN DECLARE @STK_ID INT DECLARE CUR1 SCROLL CURSOR FOR SELECT STOCK_ID FROM STOCKS OPEN CUR1 WHILE (@@FETCH_STATUS<>-1) BEGIN INSERT INTO Items_Stocks(ITEM_ID,STOCK_ID) VALUES (@ITM_ID,@STK_ID) FETCH NEXT FROM CUR1 INTO @STK_ID END CLOSE CUR1 DEALLOCATE CUR1 END;"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " CREATE TABLE [dbo].[Procedure_Master]( 	[Procedure_Master_ID] [int] IDENTITY(1,1) NOT NULL, 	[Daily_Procedure_Name] [nvarchar](50) NULL, 	[Reference_ID] [int] NULL, 	[Generic_Desc] [nvarchar](150) NULL, 	[Balance] [decimal](18, 2) NULL, 	[Procedure_Category] [nvarchar](50) NULL, 	[Procedure_Type] [nvarchar](5) NULL,  CONSTRAINT [PK_Procedure_Master] PRIMARY KEY CLUSTERED  ( 	[Procedure_Master_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [Procedure_Master_Pro_Name_Un] UNIQUE NONCLUSTERED  ( 	[Daily_Procedure_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " CREATE TABLE [dbo].[Vendors]( 	[Vendor_Id] [int] IDENTITY(1,1) NOT NULL, 	[Vendor_Name] [nvarchar](50) NULL, 	[Tele] [nvarchar](25) NULL, 	[Address] [nvarchar](150) NULL, 	[Email] [nvarchar](75) NULL, 	[Personal_Id] [nvarchar](20) NULL, 	[Comments] [nvarchar](100) NULL, 	[Web_Site] [nvarchar](50) NULL, 	[Rep_Person] [nvarchar](50) NULL, 	[Mobile] [nvarchar](25) NULL,  CONSTRAINT [PK_vendors] PRIMARY KEY CLUSTERED  ( 	[Vendor_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_vendors] UNIQUE NONCLUSTERED  ( 	[Vendor_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " CREATE PROCEDURE [dbo].[Attach_All_Vendor_Item](@ITM_ID INT) AS BEGIN DECLARE @VEN_ID INT DECLARE CUR1 SCROLL CURSOR FOR SELECT VENDOR_ID FROM VENDORS OPEN CUR1 WHILE (@@FETCH_STATUS<>-1) BEGIN INSERT INTO Items_Vendors (ITEM_ID,VENDOR_ID) VALUES (@ITM_ID,@VEN_ID) FETCH NEXT FROM CUR1 INTO @VEN_ID END CLOSE CUR1 DEALLOCATE CUR1 END;"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " CREATE TABLE [dbo].[Items]( 	[Item_Id] [int] IDENTITY(1,1) NOT NULL, 	[Item_Name] [nvarchar](300) NOT NULL, 	[Barcode] [nvarchar](300) NULL, 	[Purchase_price] [decimal](18, 2) NULL, 	[Sale_Price] [decimal](18, 2) NULL, 	[Sale_Total_Price] [decimal](18, 2) NULL, 	[Alert_Balance] [decimal](18, 2) NULL, 	[Order_Balance] [decimal](18, 2) NULL, 	[Max_Order] [decimal](18, 2) NULL, 	[Min_Order] [decimal](18, 2) NULL, 	[Photo] [image] NULL, 	[Um_id] [int] NOT NULL, 	[Category_Id] [int] NOT NULL, 	[Corporation_Id] [int] NOT NULL, 	[Generic_Desc] [nvarchar](1000) NULL,  CONSTRAINT [items_item_id_pk] PRIMARY KEY CLUSTERED  ( 	[Item_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [items_item_name_un] UNIQUE NONCLUSTERED  ( 	[Item_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " CREATE TABLE [dbo].[Items_stocks]( 	[Serial_pk] [int] IDENTITY(1,1) NOT NULL, 	[Stock_Id] [int] NULL, 	[Item_Id] [int] NULL, 	[Expired_Date] [date] NULL, 	[Balance] [decimal](18, 2) NULL, 	[Price] [decimal](18, 2) NULL,  CONSTRAINT [PK_Items_stocks] PRIMARY KEY CLUSTERED  ( 	[Serial_pk] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " CREATE VIEW [dbo].[Query_Items_Stocks] AS SELECT     dbo.Items_stocks.Serial_pk, dbo.Stocks.Stock_Id, dbo.Stocks.Stock_Name, dbo.Items.Item_Id, dbo.Items.Item_Name, dbo.Items.Barcode, dbo.Items_stocks.Balance,                        dbo.Items_stocks.Expired_Date, dbo.Items_stocks.Price FROM         dbo.Items INNER JOIN                       dbo.Items_stocks ON dbo.Items.Item_Id = dbo.Items_stocks.Item_Id INNER JOIN                       dbo.Stocks ON dbo.Items_stocks.Stock_Id = dbo.Stocks.Stock_Id"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " create FUNCTION [dbo].[Is_Item_Attached](@ITM_ID INT,@ITM_NAME NVARCHAR(50),@ITM_CODE NVARCHAR(50),@STK_ID INT)  RETURNS BIT AS  BEGIN  DECLARE @B BIT,@Itm_Cnt decimal(18,0) SET @B=1  IF @ITM_ID<>0  BEGIN  SET @Itm_Cnt=(SELECT count(*) FROM Query_Items_Stocks WHERE ITEM_ID = @ITM_ID AND STOCK_ID = @STK_ID) END  ELSE IF @ITM_NAME<>'None'  BEGIN  SET @Itm_Cnt=(SELECT count(*) FROM Query_Items_Stocks WHERE ITEM_NAME = @ITM_NAME AND STOCK_ID = @STK_ID) END  ELSE IF @ITM_CODE<>'None'  BEGIN  SET @Itm_Cnt=(SELECT count(*) FROM Query_Items_Stocks WHERE BARCODE = @ITM_CODE AND STOCK_ID = @STK_ID)  END  IF @Itm_Cnt<=0  BEGIN  SET @B=0  END  RETURN @B  END;"
        cmd.ExecuteNonQuery()

        CalcProgress()

        cmd.CommandText = " CREATE TABLE [dbo].[Loans_Details]( 	[Phase_ID] [int] IDENTITY(1,1) NOT NULL, 	[Loan_ID] [int] NOT NULL, 	[Phase_Value] [decimal](18, 2) NULL, 	[Phase_Status] [nvarchar](50) NULL, 	[Pay_Date] [date] NULL,  CONSTRAINT [PK_Loans_Details] PRIMARY KEY CLUSTERED  ( 	[Phase_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()
        CalcProgress()

        cmd.CommandText = " create trigger [dbo].[treg_um_master_um] on [dbo].[Um_Master] after insert  as begin	 declare @eq_name nvarchar(30),@eq_quantity decimal(18,2),@u_id int; select @eq_name=Base_Um, @u_id=Um_Id from inserted  insert into um_details(Equivalent_Name,Equivalent_Quantity,Um_Id) values(@eq_name,1,@u_id) end"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " CREATE TABLE [dbo].[Security_Group_Details]( 	[Privilege_ID] [int] IDENTITY(1,1) NOT NULL, 	[Privilege_Name] [nvarchar](50) NOT NULL, 	[Granted] [bit] NULL, 	[Group_ID] [int] NULL, 	[Grant_Type] [int] NULL,  CONSTRAINT [PK_Security_Group_Details] PRIMARY KEY CLUSTERED  ( 	[Privilege_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()
        CalcProgress()

        cmd.CommandText = " create FUNCTION [dbo].[Check_Item_In_Stock](@STOCK_ID INT,@ITEM_ID INT,@EXPIRED_DATE DATE) RETURNS BIT AS BEGIN DECLARE @I INT SET @I=(SELECT COUNT(*) FROM ITEMS_STOCKS WHERE STOCK_ID=@STOCK_ID AND ITEM_ID=@ITEM_ID AND EXPIRED_DATE=@EXPIRED_DATE) RETURN @I END"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Jobs]( 	[Job_Id] [int] IDENTITY(1,1) NOT NULL, 	[Job_Title] [nvarchar](50) NOT NULL, 	[Job_Desc] [nvarchar](150) NULL,  CONSTRAINT [jobs_job_id_pk] PRIMARY KEY CLUSTERED  ( 	[Job_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [jobs_job_title_un] UNIQUE NONCLUSTERED  ( 	[Job_Title] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Departments]( 	[Department_Id] [int] IDENTITY(1,1) NOT NULL, 	[Department_Name] [nvarchar](50) NOT NULL, 	[Generic_Desc] [nvarchar](150) NULL,  CONSTRAINT [departments_department_id_pk] PRIMARY KEY CLUSTERED  ( 	[Department_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [departments_department_name_un] UNIQUE NONCLUSTERED  ( 	[Department_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Employees]( 	[Employee_Id] [int] IDENTITY(1,1) NOT NULL, 	[Employee_Name] [nvarchar](50) NULL, 	[Barcode] [nvarchar](50) NULL, 	[Mobile] [nvarchar](25) NULL, 	[Email] [nvarchar](50) NULL, 	[Address] [nvarchar](150) NULL, 	[Job_Id] [int] NULL, 	[Department_Id] [int] NULL, 	[Tele] [nvarchar](25) NULL, 	[Hire_Date] [date] NULL, 	[Education] [nvarchar](50) NULL, 	[photo] [image] NULL, 	[Basic_Salary] [decimal](18, 2) NULL, 	[Variable_Salary] [decimal](18, 2) NULL,  CONSTRAINT [employees_employee-id_pk] PRIMARY KEY CLUSTERED  ( 	[Employee_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [Employees_Employee_Name_Un] UNIQUE NONCLUSTERED  ( 	[Employee_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE PROCEDURE [dbo].[Create_Sec_Dtls](@G_ID INT)  AS BEGIN INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة المسمى الوظيفى',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة بيانات الاداره',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة بيانات الموظفيين',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة الحضور و الانصراف',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة الاجازات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة الخصومات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة المكافات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة بيانات المهمات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة البدلات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة الاصناف الاساسيه',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة بيانات الشركات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'شركات العملاء',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذه مجموعه القياس',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذه تفاصيل مجموعه القياس',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة ادخال ارصدة اول مده',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة بنود الاصناف الاساسيه',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة بيانات المخازن' ,@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة اهلاك الاصناف',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة اذونات التحويل',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة جرد الاصناف',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة تفاصيل جرد الاصناف',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة بيانات العملاء',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة فواتير المبيعات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة مرتجع العملاء',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة بيانات الصاله',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة نوع الاشتراك',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة تفاصيل الاشتراك',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة حجز اشتراك',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة تسجيل الحضور و الانصراف',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة جلسه خاصه',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة بنود الجلسات خاصه',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة بيانات المورديين',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة ربط المورديين بالاصناف',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة فواتير المشتريات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة اذن ارتجاع مورد',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة المصروفات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة قائمه الدخل التفصيليه',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة اسماء الحسابات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة القيود',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة الشيكات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة تعاملات البنوك',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة اذونات الدفع',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة حساب الاستاذ',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة ميزان المراجعه',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة الميزانيه العموميه',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة اهلاك الاصول الثابته',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة حسابات شئون العامليين',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'مرتب الموظف',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير فواتير المبيعات',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير فواتير المشتريات',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير اذونات التحويل',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير اذونات اهلاك الاصناف',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير اذونات ارتجاع الموردين',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير اذونات ارتجاع العملاء',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير حركة المخزن',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير حركة المستخدين',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير تقييم المخزن',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير طباعه باركود الاصناف',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير وحدات القياس',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'التقرير العام لارصده المخزن',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'التقرير التفصيلى لارصده المخزن',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير حضور وانصراف المدربين',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير حضور وانصراف الموظفين',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير طباعه الكروت',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير كشف حساب عميل',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير ارصدة الحسابات',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير كشف حساب مورد',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير كشف حساب بنك',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير كشف حساب عام',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير تواريخ صلاحيه الاصناف',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير كشف الاجور لموظف واحد',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'تقرير كشف الاجور العام',@G_ID,3)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة الورديات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة اعدادات البرنامج',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة مجموعات الامان',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة صلاحيات مجموعات الامان',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة بيانات المستخدمين',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة تشغيل سرفر الشات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة الدخول للشات',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة الوضع الافتراضى',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة الدول',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة المدن',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة المناطق',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة العناوين',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة دفتر التليفون',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة ارقام التليفون',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'نافذة اوامر النظام',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'احصائية الصالات بنسبة الحضور',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'احصائية المتدربين للمدرب الواحد',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'احصائية الجلسات الخاصه',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'احصائية الاشتراكات بنسبة الحجز-بيانيه',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'احصائية الاشتراكات بنسبة الحجز-رقميه',@G_ID,1)INSERT INTO Security_Group_Details(Privilege_Name,Group_ID,Grant_Type) VALUES(N'اضافة فتره و عدد من التمرينات للاشتراك',@G_ID,1)end"
        cmd.ExecuteNonQuery()

        CalcProgress()




        cmd.CommandText = " CREATE TABLE [dbo].[Security_Group_Header]( 	[Group_ID] [int] IDENTITY(1,1) NOT NULL, 	[Group_Name] [nvarchar](50) NOT NULL, 	[Generic_Desc] [nvarchar](150) NULL,  CONSTRAINT [PK_Security_Group_Header] PRIMARY KEY CLUSTERED  ( 	[Group_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Security_Group_Header] UNIQUE NONCLUSTERED  ( 	[Group_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[App_Users]( 	[User_ID] [int] IDENTITY(1,1) NOT NULL, 	[User_Name] [nvarchar](30) NOT NULL, 	[User_Password] [nvarchar](15) NOT NULL, 	[Employee_ID] [int] NULL, 	[Group_ID] [int] NULL, 	[Account_Status] [bit] NULL,  CONSTRAINT [PK_App_Users] PRIMARY KEY CLUSTERED  ( 	[User_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_App_Users] UNIQUE NONCLUSTERED  ( 	[User_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[User_Log]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[User_ID] [int] NULL, 	[Action] [nvarchar](15) NULL, 	[Action_Date] [date] NULL, 	[Action_Time] [time](7) NULL,  CONSTRAINT [PK_User_Log] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " CREATE TABLE [dbo].[Items_Vendors]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Item_ID] [int] NULL, 	[Vendor_ID] [int] NULL,  CONSTRAINT [PK_Items_Vendors] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE VIEW [dbo].[Query_Items_Vendors] AS SELECT     dbo.vendors.Vendor_Id, dbo.vendors.Vendor_Name, dbo.items.Item_Id, dbo.items.Item_Name, dbo.items.Barcode FROM         dbo.vendors INNER JOIN                       dbo.Items_Vendors ON dbo.vendors.Vendor_Id = dbo.Items_Vendors.Vendor_ID INNER JOIN                       dbo.items ON dbo.Items_Vendors.Item_ID = dbo.items.Item_Id"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " create FUNCTION [dbo].[Checked_Vendor_Items](@V_ID INT,@ITM_ID INT,@BAR_CDE NVARCHAR(50)) RETURNS BIT  AS BEGIN DECLARE @B BIT=0,@R_COUNT INT IF @BAR_CDE <> 'None' BEGIN SET @R_COUNT = (SELECT COUNT(*) FROM Query_Items_Vendors WHERE BARCODE = @BAR_CDE AND VENDOR_ID = @V_ID) END ELSE BEGIN SET @R_COUNT=(SELECT COUNT(*) FROM Query_Items_Vendors WHERE ITEM_ID = @ITM_ID AND VENDOR_ID = @V_ID) END IF @R_COUNT <> 0 BEGIN SET @B=1 END RETURN @B END;"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " create PROCEDURE [dbo].[COMMIT_CHECK](@STK_ID INT , @ITM_ID INT , @BAL DECIMAL(18,0),@Expired_Date date)  AS BEGIN UPDATE Items_stocks SET Balance=@BAL WHERE Item_ID = @ITM_ID AND stock_ID = @STK_ID and  Expired_Date = @Expired_Date  END;"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TRIGGER [dbo].[TRIG_CREATE_SEC_GROUP_HDR] ON [dbo].[Security_Group_Header] FOR INSERT AS BEGIN DECLARE @G_ID INT SELECT @G_ID=GROUP_ID FROM INSERTED EXEC Create_Sec_Dtls @G_ID END;"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE PROCEDURE [dbo].[CREATE_CHECK](@CHK_ID INT,@STK_ID INT)  AS BEGIN  INSERT INTO Check_Details (ITEM_ID,SYSTEM_QUANTITY,Expired_Date,Price,User_Quantity)  SELECT ITEM_ID,BALANCE,Expired_Date,Price,BALANCE FROM Query_Items_Stocks WHERE Stock_ID =@STK_ID UPDATE Check_Details SET Check_ID = @CHK_ID , Check_Type = N'لا يوجد'  WHERE CHECK_ID IS NULL END; /* DECLARE @ITM_ID INT,@BAL DECIMAL(18,0) DECLARE CUR1 SCROLL CURSOR FOR  SELECT ITEM_ID,BALANCE FROM Query_Items_Restaurant WHERE Restaurant_ID =  @STK_ID OPEN CUR1 WHILE (@@FETCH_STATUS<>-1) BEGIN  FETCH NEXT FROM CUR1 INTO @ITM_ID,@BAL END CLOSE CUR1 DEALLOCATE CUR1  INSERT INTO Check_Details(Check_ID,Item_ID,System_Quantity) VALUES (@CHK_ID,@ITM_ID,@BAL) */"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Check_Header]( 	[Check_Id] [int] NOT NULL, 	[Check_Name] [nvarchar](50) NOT NULL, 	[Created_date] [date] NULL, 	[Created_Time] [nvarchar](15) NULL, 	[Stock_Id] [int] NOT NULL, 	[Employee_Id] [int] NOT NULL, 	[Check_Status] [nvarchar](50) NULL,  CONSTRAINT [PK_check_header] PRIMARY KEY CLUSTERED  ( 	[Check_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_check_header] UNIQUE NONCLUSTERED  ( 	[Check_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TRIGGER [dbo].[TRIG_CREATE_CHECK] ON [dbo].[Check_Header]  after INSERT AS BEGIN DECLARE @CH_ID INT,@STK_ID INT  SELECT @CH_ID=CHECK_ID,@STK_ID=STOCK_ID FROM INSERTED EXEC CREATE_CHECK @CH_ID,@STK_ID END"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE VIEW [dbo].[Query_Items_Um] AS SELECT     dbo.Um_Master.Um_Id, dbo.Um_Master.Um_Name, dbo.items.Item_Name, dbo.Um_Details.Equivalent_name, dbo.Um_Details.Equivalent_Quantity,                        dbo.items.Item_Id, dbo.Um_Details.Um_Detail_Id FROM         dbo.items INNER JOIN                       dbo.Um_Master ON dbo.items.Um_id = dbo.Um_Master.Um_Id INNER JOIN                       dbo.Um_Details ON dbo.Um_Master.Um_Id = dbo.Um_Details.Um_Id"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Check_Details]( 	[Serial_Pk] [int] IDENTITY(1,1) NOT NULL, 	[Check_Id] [int] NULL, 	[Item_Id] [int] NULL, 	[System_Quantity] [decimal](18, 2) NULL, 	[User_Quantity] [decimal](18, 2) NULL, 	[Expired_date] [date] NULL, 	[Price] [decimal](18, 5) NULL, 	[Check_Type] [nvarchar](50) NULL, 	[Partner_ID] [int] NULL, 	[Employee_ID] [int] NULL,  CONSTRAINT [PK_check_details] PRIMARY KEY CLUSTERED  ( 	[Serial_Pk] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE VIEW [dbo].[Query_Check_Items] AS SELECT     dbo.Check_Details.Serial_PK, dbo.Check_Details.Check_ID, dbo.Check_Details.Item_ID, dbo.Items.Item_Name, dbo.Items.Barcode,                        dbo.Check_Details.System_Quantity, dbo.Check_Details.User_Quantity, dbo.Check_Details.Price, dbo.Check_Details.Expired_Date, dbo.Check_Details.Check_Type,                        dbo.Check_Details.Partner_ID, dbo.Check_Details.Employee_ID FROM         dbo.Check_Details INNER JOIN                       dbo.Items ON dbo.Check_Details.Item_ID = dbo.Items.Item_ID"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Dep_Header]( 	[Bill_Id] [int] NOT NULL, 	[Bill_Date] [date] NULL, 	[Bill_Time] [time](7) NULL, 	[Stock_Id] [int] NOT NULL, 	[Employee_Id] [int] NOT NULL, 	[Dep_Desc] [nvarchar](150) NULL, 	[Total_Bill] [decimal](18, 5) NULL,  CONSTRAINT [PK_dep_header] PRIMARY KEY CLUSTERED  ( 	[Bill_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " SET QUOTED_IDENTIFIER ON"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " CREATE TABLE [dbo].[Dep_Details]( 	[Serial_pk] [int] IDENTITY(1,1) NOT NULL, 	[Bill_Id] [int] NOT NULL, 	[Item_Id] [int] NOT NULL, 	[Um_Detail_Id] [int] NOT NULL, 	[Quantity] [decimal](18, 2) NULL, 	[Reason] [nvarchar](150) NOT NULL, 	[Expired_Date] [date] NULL, 	[Price] [decimal](18, 5) NULL, 	[Total_Item] [decimal](18, 5) NULL,  CONSTRAINT [dep_details_serial_pk_pk] PRIMARY KEY CLUSTERED  ( 	[Serial_pk] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " create view [dbo].[Most_Dep_Item_All] as SELECT I.Item_Name, ISNULL(COUNT(D.Item_ID),0) AS TOTAL_DEP FROM dbo.ITEMS AS I,dbo.Dep_Details AS D  where D.Item_ID  = I.Item_ID   GROUP BY I.Item_Name ;"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " create FUNCTION [dbo].[Is_Item_EXISTS](@Search_Type bit,@Item_Name nvarchar(50),@Barcode nvarchar(50)) returns bit AS BEGIN DECLARE @I INT,@B BIT=0 IF @SEARCH_TYPE=1 BEGIN SET @I=(SELECT COUNT(*) FROM ITEMS WHERE ITEM_NAME = @ITEM_NAME) END ELSE BEGIN SET @I=(SELECT COUNT(*) FROM ITEMS WHERE BARCODE = @BARCODE) END IF @I>0 BEGIN SET @B=1 END RETURN @B END"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " create FUNCTION [dbo].[Check_Item_Name_Exists](@Itm NVARCHAR(50)) RETURNS BIT AS BEGIN DECLARE @B BIT=1,@R_COUNT INT SET @R_COUNT=(SELECT COUNT(*) FROM ITEMS WHERE ITEM_NAME = @ITM) IF @R_COUNT=0 BEGIN SET @B=0 END RETURN @B END;"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " create FUNCTION [dbo].[Check_Barcode_Exists](@Var_Barcode NVARCHAR(50)) RETURNS BIT AS BEGIN DECLARE @B BIT=1,@R_COUNT INT SET @R_COUNT=(SELECT COUNT(*) FROM ITEMS WHERE barcode = @Var_Barcode) IF @R_COUNT=0 BEGIN SET @B=0 END RETURN @B END;"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE PROCEDURE [dbo].[Attach_Vendor_Item](@ITM_N NVARCHAR(50),@VEN_ID INT) AS BEGIN DECLARE @R_COUNT INT,@ITM_ID INT SET @ITM_ID = (SELECT ITEM_ID FROM ITEMS WHERE ITEM_NAME = @ITM_N) SET @R_COUNT=(SELECT COUNT(*) FROM ITEMS_VENDORS WHERE VENDOR_ID = @VEN_ID AND ITEM_ID = @ITM_ID) IF @R_COUNT = 0 BEGIN INSERT INTO ITEMS_VENDORS(ITEM_ID,VENDOR_ID) VALUES(@ITM_ID,@VEN_ID) END END;"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " create function [dbo].[Is_Balance_Fit](@p_item_id int,@p_um_detail_id int,@p_quantity decimal(18,2),@P_stock_id int ,@P_Expired_date date) returns bit  as begin declare @v_b bit,@v_Equivalent_Quantity decimal(18,2),@v_r decimal(18,2),@v_balance decimal(18,2) select @v_Equivalent_Quantity=Equivalent_Quantity from Query_Items_Um where um_detail_id=@p_um_detail_id  and Item_Id =@p_item_id; select @v_balance=balance from Items_stocks where  item_id=@p_Item_Id and Expired_Date=@P_Expired_date and  Stock_Id=@P_stock_id set @v_r =@v_Equivalent_Quantity*@p_quantity if @v_r>@v_balance begin set @v_b=0; end else if @v_r<=@v_balance begin set @v_b=1; end return @v_b end"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Inventory_Log]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Doc_ID] [int] NULL, 	[Doc_Date] [date] NULL, 	[Doc_Type] [nvarchar](50) NULL, 	[Total_Doc] [decimal](18, 0) NULL, 	[Item_ID] [int] NULL, 	[Quantity] [decimal](18, 0) NULL, 	[Stock_ID] [int] NULL,  CONSTRAINT [PK_Inventory_Log] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE view  [dbo].[most_sal_category_items] as select count(l.doc_id)as total_bill,l.doc_type,i.item_name,sum(l.quantity) as total_items from inventory_log l ,items i where i.item_id=l.item_id  group by l.Doc_Type ,i.Item_Name"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " create function [dbo].[Get_Item_Last_Balance] (@p_date date,@p_Item_Id int ,@p_stock_ID int) returns decimal(18,5) as begin declare @net_balance decimal(18,5), @plus_Balance decimal(18,5), @minus_Balance decimal(18,5), @First_Balance decimal(18,5) set @First_Balance = (select isnull( sum (quantity),0) from inventory_log where doc_type = N'ارصدة اول المده'  and item_id=@p_Item_Id and stock_id= @p_stock_ID) set @plus_Balance = (select isnull( sum (quantity),0) from inventory_log where doc_Date <= @p_date and item_id=@p_Item_Id and stock_id= @p_stock_ID and doc_type in (N'فاتورة مشتريات',N'اذن تحويل - وارد',N'اذن ارتجاع عميل') ); set @minus_Balance  = (select isnull (sum (quantity),0) from inventory_log where doc_Date <= @p_date and item_id=@p_Item_Id and stock_id= @p_stock_ID and doc_type in (N'فاتورة مبيعات',N'اذن تحويل - صادر',N'اذن ارتجاع مورد',N'أمر اهلاك',N'هدايا و منح',N'اهلاك وجبات') ); set @net_balance = (@First_Balance + @plus_Balance) - @minus_Balance return @net_balance; end;"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE function [dbo].[Get_Item_first_Balance] (@p_date date,@p_Item_Id int ,@p_stock_ID int) returns decimal(18,5) as begin declare @net_balance decimal(18,5), @plus_Balance decimal(18,5), @minus_Balance decimal(18,5), @First_Balance decimal(18,5) set @First_Balance = (select isnull( sum (quantity),0) from inventory_log where doc_type = N'ارصدة اول المده'  and item_id=@p_Item_Id and stock_id= @p_stock_ID) set @plus_Balance = (select isnull( sum (quantity),0) from inventory_log where doc_Date < @p_date and item_id=@p_Item_Id and stock_id= @p_stock_ID and doc_type in (N'فاتورة مشتريات',N'اذن تحويل - وارد',N'اذن ارتجاع عميل') ); set @minus_Balance  = (select isnull (sum (quantity),0) from inventory_log where doc_Date < @p_date and item_id=@p_Item_Id and stock_id= @p_stock_ID and doc_type in (N'فاتورة مبيعات',N'اذن تحويل - صادر',N'اذن ارتجاع مورد',N'أمر اهلاك',N'هدايا و منح',N'اهلاك وجبات') ); set @net_balance = (@First_Balance + @plus_Balance) - @minus_Balance return @net_balance; end;"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE PROCEDURE [dbo].[Create_First_Balance] as begin DELETE FROM   Inventory_Log WHERE Doc_Type = N'ارصدة اول المده' INSERT INTO Inventory_Log(Stock_ID,Item_ID,Quantity,Doc_Type,Doc_Date,Total_Doc) SELECT Stock_ID,Item_ID,ISNULL(SUM(Balance),0) AS Quantity,N'ارصدة اول المده' AS Doc_Type ,GETDATE() AS Doc_Date , 0 AS Total_Doc FROM Items_Stocks GROUP BY Stock_ID , Item_ID end"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Countries]( 	[Country_ID] [int] IDENTITY(1,1) NOT NULL, 	[Country_Name] [nvarchar](50) NULL, 	[Continent] [nvarchar](20) NULL,  CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED  ( 	[Country_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Countries] UNIQUE NONCLUSTERED  ( 	[Country_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Cities]( 	[City_ID] [int] IDENTITY(1,1) NOT NULL, 	[City_Name] [nvarchar](50) NULL, 	[Country_ID] [int] NULL,  CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED  ( 	[City_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Cities] UNIQUE NONCLUSTERED  ( 	[City_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"


        cmd.ExecuteNonQuery()
        cmd.CommandText = " CREATE TABLE [dbo].[Regions]( 	[Region_ID] [int] IDENTITY(1,1) NOT NULL, 	[Region_Name] [nvarchar](50) NULL, 	[City_ID] [int] NULL, 	[Region_Photo] [image] NULL,  CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED  ( 	[Region_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Regions] UNIQUE NONCLUSTERED  ( 	[Region_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Locations]( 	[Location_ID] [int] IDENTITY(1,1) NOT NULL, 	[Location_Name] [nvarchar](50) NULL, 	[Street_Address] [nvarchar](3000) NULL, 	[Postal_Code] [nvarchar](50) NULL, 	[Region_ID] [int] NULL, 	[X_Pos] [int] NULL, 	[Y_Pos] [int] NULL,  CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED  ( 	[Location_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Companies]( 	[Company_ID] [int] IDENTITY(9000000,1) NOT NULL, 	[Company_Name] [nvarchar](50) NULL, 	[Company_Code] [nvarchar](50) NOT NULL, 	[Email] [nvarchar](50) NULL, 	[Web_Site] [nvarchar](50) NULL, 	[Contact_Person] [nvarchar](50) NULL, 	[Tele] [nvarchar](25) NULL, 	[Mobile] [nvarchar](25) NULL, 	[Fax] [nvarchar](50) NULL, 	[Nationality] [nvarchar](50) NULL,  CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED  ( 	[Company_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Companies] UNIQUE NONCLUSTERED  ( 	[Company_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Companies_1] UNIQUE NONCLUSTERED  ( 	[Company_Code] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Seq_Table]( 	[Seq_ID] [int] NOT NULL, 	[Curr_Val] [int] NULL,  CONSTRAINT [PK_Seq_Table] PRIMARY KEY CLUSTERED  ( 	[Seq_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Customers]( 	[Customer_Id] [int] IDENTITY(1,1) NOT NULL, 	[Customer_Name] [nvarchar](50) NULL, 	[Customer_Code] [nvarchar](50) NULL, 	[Birth_Date] [date] NULL, 	[Tele] [nvarchar](25) NULL, 	[Address] [nvarchar](150) NULL, 	[Email] [nvarchar](50) NULL, 	[Personal_Id] [nvarchar](15) NULL, 	[Comments] [nvarchar](100) NULL, 	[Web_Site] [nvarchar](50) NULL, 	[Rep_Person] [nvarchar](25) NULL, 	[Mobile] [nvarchar](25) NULL, 	[Photo] [image] NULL, 	[Job_ID] [int] NULL, 	[Age] [int] NULL, 	[Location_ID] [int] NULL, 	[Company_ID] [int] NULL,  CONSTRAINT [costomers_customer_id_pk] PRIMARY KEY CLUSTERED  ( 	[Customer_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [Customers_Customer_Name_Un] UNIQUE NONCLUSTERED  ( 	[Customer_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Customers] UNIQUE NONCLUSTERED  ( 	[Customer_Code] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Banks]( 	[Bank_ID] [int] IDENTITY(1,1) NOT NULL, 	[Bank_Name] [nvarchar](50) NULL, 	[Generic_Desc] [nvarchar](150) NULL, 	[Address] [nvarchar](250) NULL,  CONSTRAINT [PK_Banks] PRIMARY KEY CLUSTERED  ( 	[Bank_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Banks] UNIQUE NONCLUSTERED  ( 	[Bank_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Banks_Accounts]( 	[Account_ID] [int] IDENTITY(1,1) NOT NULL, 	[Account_Number] [nvarchar](50) NULL, 	[Generic_Desc] [nvarchar](150) NULL, 	[Created_Date] [date] NULL, 	[Balance] [decimal](18, 2) NULL, 	[Account_Status] [bit] NULL, 	[Bank_ID] [int] NULL,  CONSTRAINT [PK_Banks_Accounts] PRIMARY KEY CLUSTERED  ( 	[Account_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Banks_Accounts] UNIQUE NONCLUSTERED  ( 	[Account_Number] ASC, 	[Bank_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Cheques]( 	[Cheque_ID] [int] IDENTITY(1,1) NOT NULL, 	[Cheque_Number] [nvarchar](50) NULL, 	[Received_Date] [date] NULL, 	[Payed_Date] [date] NULL, 	[Cheque_Value] [decimal](18, 2) NULL, 	[Cheque_Status] [nvarchar](30) NULL, 	[Account_ID] [int] NULL, 	[Direction] [nvarchar](50) NULL,  CONSTRAINT [Cheques_Cheque_ID_PK] PRIMARY KEY CLUSTERED  ( 	[Cheque_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [Cheques_Cheque_Number_Un] UNIQUE NONCLUSTERED  ( 	[Cheque_Number] ASC, 	[Account_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Visa]( 	[Visa_ID] [int] IDENTITY(1,1) NOT NULL, 	[Visa_Number] [nvarchar](50) NULL, 	[Created_Date] [date] NULL, 	[Visa_Status] [bit] NULL, 	[Account_ID] [int] NULL,  CONSTRAINT [PK_Visa] PRIMARY KEY CLUSTERED  ( 	[Visa_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Visa] UNIQUE NONCLUSTERED  ( 	[Visa_Number] ASC, 	[Account_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Sales_Header]( 	[Bill_Id] [int] NOT NULL, 	[Bill_Date] [date] NULL, 	[Bill_Time] [nchar](10) NULL, 	[Customer_Id] [int] NULL, 	[Employee_Id] [int] NULL, 	[Total_Bill] [decimal](18, 2) NULL, 	[Stock_Id] [int] NULL, 	[Discount_Type] [nvarchar](50) NULL, 	[Discount_Value] [decimal](18, 2) NULL, 	[Cash_Value] [decimal](18, 2) NULL, 	[Credit_Value] [decimal](18, 2) NULL, 	[Pay_Type] [nvarchar](50) NULL, 	[Comments] [nvarchar](50) NULL, 	[Footer] [nvarchar](50) NULL, 	[Cheque_ID] [int] NULL, 	[Visa_ID] [int] NULL, 	[Tax] [decimal](5, 2) NULL,  CONSTRAINT [salas_header_Sales_id_pk] PRIMARY KEY CLUSTERED  ( 	[Bill_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " CREATE TABLE [dbo].[Sales_Details]( 	[Serial_Pk] [int] IDENTITY(1,1) NOT NULL, 	[Bill_Id] [int] NULL, 	[Item_Id] [int] NULL, 	[Trade_Name] [nvarchar](50) NULL, 	[Item_Type] [nvarchar](50) NULL, 	[Um_Detail_Id] [int] NULL, 	[Expired_Date] [date] NULL, 	[Quantity] [decimal](18, 2) NULL, 	[Price] [decimal](18, 2) NULL, 	[Discount_Type] [nvarchar](50) NULL, 	[Discount_Value] [decimal](18, 2) NULL, 	[Total_Item] [decimal](18, 2) NULL,  CONSTRAINT [PK_sales_details] PRIMARY KEY CLUSTERED  ( 	[Serial_Pk] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()



        cmd.CommandText = " CREATE procedure [dbo].[commit_sales_details](@P_bill_id int,@p_item_id int,@p_um_detail_id int,@p_quantity decimal(18,2),@p_price decimal(18,2),@p_discount_type nvarchar(50),@p_discount_value decimal(18,2),@p_total_item decimal(18,2),@p_stock_Id int,@p_expired_date date,@p_date date,@Trade_Name Nvarchar(50),@Item_Type nvarchar(50))as begin declare @v_equivalent_quantity  decimal(18,2),@v_r decimal(18,2),@y int,@r decimal(18,2)insert into sales_details(Bill_Id,Item_Id,Trade_Name,Item_Type,Um_Detail_Id,Expired_Date,Quantity,Price,Discount_Value,Discount_Type,Total_Item)values(@P_bill_id ,@p_item_id,@Trade_Name,@Item_Type,@p_um_detail_id ,@p_expired_date,@p_quantity, @p_price ,@p_discount_value ,@p_discount_type,@p_total_item) select @v_equivalent_quantity =equivalent_quantity  from report_items_stocks_balance where um_detail_id=@p_um_detail_id and Item_Id =@p_item_id and Expired_Date=@P_Expired_date and Stock_Id=@P_stock_id set @v_r= @v_equivalent_quantity*@p_quantity update Items_stocks set Balance=Balance-@v_r where item_id=@p_Item_Id and Expired_Date=@P_Expired_date and Stock_Id=@p_stock_id delete from Items_stocks where Balance <=0 insert into Inventory_Log(Doc_ID,Doc_Date,Doc_Type,Total_Doc,Item_ID,Quantity,Stock_ID)values (@P_bill_id,@p_date,N'فاتورة مبيعات',@p_total_item,@P_item_id,@P_quantity,@P_stock_id)end"
        cmd.ExecuteNonQuery()


        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Return_V_Header]( 	[Bill_ID] [int] NOT NULL, 	[Bill_Date] [datetime] NULL, 	[Bill_Time] [nvarchar](15) NULL, 	[Vendor_ID] [int] NULL, 	[Employee_ID] [int] NULL, 	[Stock_ID] [int] NULL, 	[Total_Bill] [decimal](18, 0) NULL, 	[Comments] [nvarchar](150) NULL, 	[Footer] [nvarchar](100) NULL, 	[Tax] [decimal](18, 2) NULL,  CONSTRAINT [PK_Return_V_Header] PRIMARY KEY CLUSTERED  ( 	[Bill_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Return_V_Details]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Bill_ID] [int] NULL, 	[Item_ID] [int] NULL, 	[Um_Detail_ID] [int] NULL, 	[Expired_Date] [date] NULL, 	[Quantity] [decimal](18, 0) NULL, 	[Price] [decimal](18, 0) NULL, 	[Total_Item] [decimal](18, 0) NULL,  CONSTRAINT [PK_Return_V_Details] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()



        cmd.CommandText = " create procedure [dbo].[commit_return_v_details] (@P_item_id int,@P_quantity decimal(18,2), @P_bill_id int,@P_price decimal(18,2),@P_um_detail_id int,@P_expired_date date, @P_total_item decimal(18,2),@P_stock_id int,@p_date date) as  begin declare @v_equivalent_quantity decimal(18,2),@v_s decimal(18,2) insert into return_v_details (bill_id,item_id,Um_Detail_ID,expired_date,quantity,price,total_item) values (@P_bill_id ,@P_item_id ,@P_um_detail_id ,@P_expired_date , @P_quantity,@P_price ,@P_total_item) select @v_Equivalent_Quantity=Equivalent_Quantity from report_items_stocks_balance where um_detail_id=@p_um_detail_id  and Item_Id =@p_item_id and Expired_Date=@P_expired_date and stock_id= @p_stock_id; set  @v_s = @v_Equivalent_Quantity*@p_quantity  update Items_stocks  set Balance=Balance -@v_s  where  item_id =@p_item_id and Expired_Date=@P_expired_date and stock_id= @p_stock_id; insert into Inventory_Log(Doc_ID,Doc_Date,Doc_Type,Total_Doc,Item_ID,Quantity,Stock_ID) values (@P_bill_id,@p_date,N'اذن ارتجاع مورد',@P_total_item,@P_item_id,@P_quantity,@P_stock_id) end"
        cmd.ExecuteNonQuery()



        cmd.CommandText = " CREATE TABLE [dbo].[Return_C_Header]( 	[Bill_ID] [int] NOT NULL, 	[Bill_Date] [date] NULL, 	[Bill_Time] [nvarchar](15) NULL, 	[Customer_ID] [int] NULL, 	[Employee_ID] [int] NULL, 	[Stock_ID] [int] NULL, 	[Total_Bill] [decimal](18, 0) NULL, 	[Comments] [nvarchar](150) NULL, 	[Footer] [nvarchar](100) NULL, 	[Tax] [decimal](5, 2) NULL,  CONSTRAINT [PK_Return_C_Header] PRIMARY KEY CLUSTERED  ( 	[Bill_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()



        cmd.CommandText = " CREATE TABLE [dbo].[Return_C_Details]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Bill_ID] [int] NULL, 	[Item_ID] [int] NULL, 	[Um_Detail_ID] [int] NULL, 	[Expired_Date] [date] NULL, 	[Quantity] [decimal](18, 0) NULL, 	[Price] [decimal](18, 0) NULL, 	[Total_Item] [decimal](18, 0) NULL,  CONSTRAINT [PK_Return_C_Details] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE procedure [dbo].[commit_return_c_details] (@P_item_id int,@P_quantity decimal(18,2),@P_bill_id int, @P_price decimal(18,2),@P_um_detail_id int,@P_expired_date date, @P_total_item decimal(18,2),@P_stock_id int,@p_date date) as  begin declare @v_equivalent_quantity decimal(18,2),@v_s decimal(18,2),@y decimal(18,2) insert into return_c_details (bill_id,item_id,Um_Detail_ID,expired_date,quantity,price,total_item) values (@P_bill_id ,@P_item_id ,@P_um_detail_id ,@P_expired_date , @P_quantity,@P_price ,@P_total_item) select @v_Equivalent_Quantity=Equivalent_Quantity from Query_Items_Um where um_detail_id=@p_um_detail_id  and Item_Id =@p_item_id; set  @v_s = @v_Equivalent_Quantity*@p_quantity set @y = (select COUNT(*) from Items_stocks where item_id=@p_Item_Id and Expired_Date=@P_Expired_date and  Stock_Id=@P_stock_id) if @y>0 begin update Items_stocks set Balance=Balance+@v_s  where item_id=@p_Item_Id and Expired_Date=@P_Expired_date and  Stock_Id=@p_stock_id end else   begin insert into Items_stocks(Stock_Id,Item_Id,Balance,Expired_Date) values (@P_stock_id,@p_Item_Id,@v_s,@P_Expired_date) end insert into Inventory_Log(Doc_ID,Doc_Date,Doc_Type,Total_Doc,Item_ID,Quantity,Stock_ID) values (@P_bill_id,@p_date,N'اذن ارتجاع عميل',@P_total_item,@P_item_id,@P_quantity,@P_stock_id) end"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Purchase_Header]( 	[Bill_Id] [int] NOT NULL, 	[Bill_Date] [date] NULL, 	[Bill_Time] [nvarchar](15) NULL, 	[Vendor_Id] [int] NOT NULL, 	[Total_Bill] [decimal](18, 2) NULL, 	[Discount_Type] [nvarchar](50) NULL, 	[Discount_Value] [decimal](18, 2) NULL, 	[Stock_Id] [int] NOT NULL, 	[Employee_Id] [int] NOT NULL, 	[Cash_Value] [decimal](18, 2) NULL, 	[Credit_Value] [decimal](18, 2) NULL, 	[Comments] [nvarchar](100) NULL, 	[Pay_Type] [nvarchar](50) NULL, 	[Footer] [nvarchar](100) NULL, 	[Cheque_ID] [int] NULL, 	[Tax] [decimal](5, 2) NULL,  CONSTRAINT [PK_purchase_header] PRIMARY KEY CLUSTERED  ( 	[Bill_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Purchase_Details]( 	[Serial_Pk] [int] IDENTITY(1,1) NOT NULL, 	[Bill_Id] [int] NOT NULL, 	[Item_Id] [int] NOT NULL, 	[Um_Detail_Id] [int] NOT NULL, 	[Expired_Date] [date] NULL, 	[Quantity] [decimal](18, 2) NOT NULL, 	[Price] [decimal](18, 2) NULL, 	[Discount_Type] [nvarchar](50) NULL, 	[Discount_Value] [decimal](18, 2) NULL, 	[Total_Item] [decimal](18, 2) NULL,  CONSTRAINT [PK_purchase_details] PRIMARY KEY CLUSTERED  ( 	[Serial_Pk] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE procedure [dbo].[commit_purchase_details](@P_bill_id int,@p_item_id int,@p_um_detail_id int,@p_quantity decimal(18,2), @p_price decimal(18,2),@p_discount_type nvarchar(50),@p_discount_value decimal(18,2),@p_total_item decimal(18,2),@p_stock_Id int,@p_expired_date date,@p_date date) as begin  declare  @v_equivalent_quantity  decimal(18,2),@v_r decimal(18,2),@y int insert into purchase_details(Bill_Id,Item_Id,Um_Detail_Id,Expired_date,Quantity,Price,Discount_Type,Discount_Value, Total_Item) values(@P_bill_id,@p_item_id,@p_um_detail_id,@p_expired_date,@p_quantity,@p_price ,@p_discount_type,@p_discount_value, @p_total_item) insert into Inventory_Log(Doc_ID,Doc_Date,Doc_Type,Total_Doc,Item_ID,Quantity,Stock_ID) values (@P_bill_id,@p_date,N'فاتورة مشتريات',@p_total_item,@P_item_id,@P_quantity,@P_stock_id) select @v_equivalent_quantity =equivalent_quantity  from Query_Items_Um where um_detail_id=@p_um_detail_id  and Item_Id =@p_item_id; set @v_r= @v_equivalent_quantity*@p_quantity set @y = (select COUNT(*) from Items_stocks where item_id=@p_Item_Id and Expired_Date=@P_Expired_date and  Stock_Id=@P_stock_id) if @y>0 begin update Items_stocks set Balance=Balance+@v_r  where item_id=@p_Item_Id and Expired_Date=@P_Expired_date and  Stock_Id=@p_stock_id end else   begin insert into Items_stocks(Stock_Id,Item_Id,Balance,Expired_Date,Price) values (@P_stock_id,@p_Item_Id,@V_r,@P_Expired_date,@p_price) end end"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " create PROCEDURE [dbo].[commit_dep_item_details] (@P_Item_ID INT,@P_Quantity DECIMAL(18,2),@P_stock_id INT,@p_Bill_ID INT,@Reason NVARCHAR(150),@P_Um_Detail_Id INT ,@P_Expired_date DATE ,@p_date DATE,@Total_Item DECIMAL(18,5),@Price Decimal(18,2)) AS BEGIN  declare  @v_equivalent_quantity  decimal(18,2),@v_r decimal(18,2),@y int INSERT INTO Dep_Details(Bill_ID,Item_ID,Um_Detail_Id,Quantity,Reason,Expired_date,Total_Item,Price)  VALUES(@p_Bill_ID,@P_Item_ID,@P_Um_Detail_Id,@P_Quantity,@Reason,@P_Expired_date,@Total_Item,@Price)  select @v_Equivalent_Quantity=Equivalent_Quantity from Query_Items_Um where um_detail_id=@P_Um_Detail_Id  and Item_Id =@p_item_id; set @v_r =@v_Equivalent_Quantity*@p_quantity; update Items_stocks set Balance=Balance-@v_r where item_id=@p_Item_Id and Expired_Date=@P_Expired_date and  Stock_Id=@P_stock_id; insert into Inventory_Log(Doc_ID,Doc_Date,Doc_Type,Total_Doc,Item_ID,Quantity,Stock_ID) values (@p_BILL_id,@p_date,N'امر اهلاك',0,@P_item_id,@v_r,@P_stock_id) END;"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Adjustment_Header]( 	[Adjustment_Id] [int] NOT NULL, 	[From_Stock_Id] [int] NOT NULL, 	[To_Stock_id] [int] NOT NULL, 	[Adjustment_Date] [date] NULL, 	[Adjustment_Time] [time](7) NULL, 	[Adjustment_Desc] [nvarchar](150) NULL, 	[Employee_Id] [int] NOT NULL,  CONSTRAINT [PK_adjustments_header] PRIMARY KEY CLUSTERED  ( 	[Adjustment_Id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Adjustment_Details]( 	[Serial_pk] [int] IDENTITY(1,1) NOT NULL, 	[Adjustment_Id] [int] NOT NULL, 	[Item_Id] [int] NOT NULL, 	[Um_Detail_Id] [int] NOT NULL, 	[Quantity] [decimal](18, 2) NULL, 	[Expired_Date] [date] NULL,  CONSTRAINT [adjustment_details_serial_pk_pk] PRIMARY KEY CLUSTERED  ( 	[Serial_pk] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE procedure [dbo].[commit_adjustment_details] (@p_Item_Id int,@p_Quantity decimal(18,2), @P_from_stock_id int,@P_to_stock_id int,@p_adjustment_id int,@p_Um_Detail_Id int, @P_Expired_date date,@p_date date,@p_Price Decimal(18,5)) as  begin declare  @v_equivalent_quantity  decimal(18,2),@v_r decimal(18,2),@y int insert into adjustment_details (adjustment_id,Item_Id,Um_Detail_Id,Quantity,expired_date) values (@p_adjustment_id,@p_Item_Id,@p_Um_Detail_Id,@p_Quantity,@P_Expired_date); select @v_Equivalent_Quantity=Equivalent_Quantity from Query_Items_Um where um_detail_id=@p_um_detail_id  and Item_Id =@p_item_id; set @v_r =@v_Equivalent_Quantity*@p_quantity; update Items_stocks set Balance=Balance-@v_r where item_id=@p_Item_Id and Expired_Date=@P_Expired_date and  Stock_Id=@P_from_stock_id; set @y = (select COUNT(*) from Items_stocks where item_id=@p_Item_Id and Expired_Date=@P_Expired_date and  Stock_Id=@P_to_stock_id) if @y>0 begin update Items_stocks set Balance=Balance+@v_r  where item_id=@p_Item_Id and Expired_Date=@P_Expired_date and  Stock_Id=@P_to_stock_id end else   begin insert into Items_stocks(Stock_Id,Item_Id,Balance,Expired_Date,Price) values (@P_to_stock_id,@p_Item_Id,@v_r,@P_Expired_date,@p_Price) end insert into Inventory_Log(Doc_ID,Doc_Date,Doc_Type,Total_Doc,Item_ID,Quantity,Stock_ID) values (@p_adjustment_id,@p_date,N'اذن تحويل - صادر',0,@P_item_id,@P_quantity,@P_from_stock_id) insert into Inventory_Log(Doc_ID,Doc_Date,Doc_Type,Total_Doc,Item_ID,Quantity,Stock_ID) values (@p_adjustment_id,@p_date,N'اذن تحويل - وارد',0,@P_item_id,@P_quantity,@P_to_stock_id) end"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Halls]( 	[Hall_ID] [int] IDENTITY(1,1) NOT NULL, 	[Hall_Name] [nvarchar](50) NULL, 	[Hall_Number] [nvarchar](50) NULL, 	[Description] [nvarchar](50) NULL,  CONSTRAINT [PK_Halls] PRIMARY KEY CLUSTERED  ( 	[Hall_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Halls] UNIQUE NONCLUSTERED  ( 	[Hall_Number] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Discount_Categories]( 	[Category_ID] [int] IDENTITY(1,1) NOT NULL, 	[Category_Name] [nvarchar](50) NOT NULL, 	[Generic_Desc] [nvarchar](50) NULL,  CONSTRAINT [PK_Expenses_Categories] PRIMARY KEY CLUSTERED  ( 	[Category_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Expenses_Categories] UNIQUE NONCLUSTERED  ( 	[Category_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Extra_Categories]( 	[Category_ID] [int] IDENTITY(1,1) NOT NULL, 	[Category_Name] [nvarchar](50) NULL, 	[Generic_Desc] [nvarchar](150) NULL,  CONSTRAINT [PK_Extra_Categories] PRIMARY KEY CLUSTERED  ( 	[Category_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Extra_Categories] UNIQUE NONCLUSTERED  ( 	[Category_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Expenses_Header]( 	[Expense_Category_ID] [int] IDENTITY(1,1) NOT NULL, 	[Expense_Category_Name] [nvarchar](50) NULL, 	[Expense_Category_Desc] [nvarchar](150) NULL,  CONSTRAINT [PK_Expenses_Header] PRIMARY KEY CLUSTERED  ( 	[Expense_Category_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Expenses_Header] UNIQUE NONCLUSTERED  ( 	[Expense_Category_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE VIEW [dbo].[Report_Items_Corporations] AS SELECT     dbo.Corporations.Corporation_Id, dbo.Corporations.Corporation_Name, dbo.Items.Item_Id, dbo.Items.Item_Name, dbo.Items.Purchase_price,                        dbo.Items.Sale_Price FROM         dbo.Corporations INNER JOIN                       dbo.Items ON dbo.Corporations.Corporation_Id = dbo.Items.Corporation_Id"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Customers_Evaluation]( 	[Evaluation_ID] [int] IDENTITY(1,1) NOT NULL, 	[Evaluation_Name] [nvarchar](50) NULL, 	[Generic_Desc] [nvarchar](150) NULL,  CONSTRAINT [PK_Customers_Evaluation] PRIMARY KEY CLUSTERED  ( 	[Evaluation_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Customers_Evaluation] UNIQUE NONCLUSTERED  ( 	[Evaluation_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TRIGGER [dbo].[TRIG_CREATE_ITEM] ON [dbo].[Items] FOR INSERT AS  BEGIN DECLARE @ITM_ID INT,@PREF BIT SET  @PREF=(SELECT Gen_Attach_Item_Stk FROM APP_PREFERENCES WHERE SERIAL_PK = 1)  IF @PREF=1 BEGIN SELECT @ITM_ID=ITEM_ID FROM INSERTED EXEC Attach_All_Stock_Item @ITM_ID END SET @PREF=(SELECT Gen_Attach_Item_Ven FROM APP_PREFERENCES WHERE SERIAL_PK = 1) IF @PREF=1 BEGIN SELECT @ITM_ID=ITEM_ID FROM INSERTED EXEC Attach_All_Vendor_Item @ITM_ID END END;"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE VIEW [dbo].[Query_All_Items] AS SELECT     dbo.Categories.Category_Id, dbo.Categories.Category_Name, dbo.Corporations.Corporation_Id, dbo.Corporations.Corporation_Name, dbo.Items.Item_Id,                        dbo.Items.Item_Name, dbo.Items.Barcode, dbo.Items.Purchase_price, dbo.Items.Sale_Price, dbo.Items.Sale_Total_Price, dbo.Um_Master.Um_Name,                        dbo.Um_Master.Um_Id FROM         dbo.Categories INNER JOIN                       dbo.Items ON dbo.Categories.Category_Id = dbo.Items.Category_Id INNER JOIN                       dbo.Corporations ON dbo.Items.Corporation_Id = dbo.Corporations.Corporation_Id INNER JOIN                       dbo.Um_Master ON dbo.Items.Um_id = dbo.Um_Master.Um_Id"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Rewards_Categories]( 	[Category_ID] [int] IDENTITY(1,1) NOT NULL, 	[Category_Name] [nvarchar](50) NOT NULL, 	[Generic_Desc] [nvarchar](50) NULL,  CONSTRAINT [PK_Rewards_Categories] PRIMARY KEY CLUSTERED  ( 	[Category_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Rewards_Categories] UNIQUE NONCLUSTERED  ( 	[Category_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Shifts]( 	[Shift_ID] [int] IDENTITY(1,1) NOT NULL, 	[Shift_Name] [nvarchar](50) NULL, 	[Generic_Desc] [nvarchar](150) NULL,  CONSTRAINT [PK_Shifts] PRIMARY KEY CLUSTERED  ( 	[Shift_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Shifts] UNIQUE NONCLUSTERED  ( 	[Shift_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE VIEW [dbo].[Vu_Stock_Value] AS SELECT I.ITEM_NAME,SI.BALANCE,I.PURCHASE_PRICE,I.PURCHASE_PRICE*SI.BALANCE AS PUR_TOTAL,I.Sale_Price,I.Sale_Price*SI.Balance AS SAL_TOTAL, I.Sale_Total_Price,I.Sale_Total_Price*SI.Balance AS SAL_ALL_TOTAL,SI.PRICE AS COST_PRICE,SI.Balance*SI.PRICE AS TOTAL_COST , s.Stock_Id , I.Item_ID FROM Items I , Items_Stocks SI, Stocks S WHERE I.Item_ID=SI.Item_ID AND S.Stock_ID=SI.Stock_ID"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " Create VIEW [dbo].[report_items_expired] AS SELECT s.Stock_Name, i.Item_Name, um.Um_Name, u.Equivalent_name, its.Expired_Date, i.Item_Id, s.Stock_Id FROM dbo.Items_stocks AS its INNER JOIN dbo.Items AS i ON its.Item_Id = i.Item_Id INNER JOIN dbo.Stocks AS s ON its.Stock_Id = s.Stock_Id INNER JOIN dbo.Um_Master AS um ON i.Um_id = um.Um_Id INNER JOIN dbo.Um_Details AS u ON um.Um_Id = u.Um_Id WHERE (its.Expired_Date <= GETDATE());"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE VIEW [dbo].[Report_Inventory_Log] AS SELECT     dbo.Inventory_Log.Doc_ID, dbo.Inventory_Log.Doc_Date, dbo.Inventory_Log.Doc_Type, dbo.Stocks.Stock_Name, dbo.Items.Item_Name,                        CASE dbo.Inventory_Log.Doc_Type WHEN N'فاتورة مشتريات' THEN dbo.Inventory_Log.Quantity WHEN N'اذن تحويل - وارد' THEN dbo.Inventory_Log.Quantity WHEN N'اذن ارتجاع عميل'                        THEN dbo.Inventory_Log.Quantity END AS Quantity,                        CASE dbo.Inventory_Log.Doc_Type WHEN N'اهلاك وجبات' THEN dbo.Inventory_Log.Quantity WHEN N'هدايا و منح' THEN dbo.Inventory_Log.Quantity WHEN N'أمر اهلاك' THEN                        dbo.Inventory_Log.Quantity WHEN N'اذن ارتجاع مورد' THEN dbo.Inventory_Log.Quantity WHEN N'اذن تحويل - صادر' THEN dbo.Inventory_Log.Quantity WHEN N'فاتورة مبيعات' THEN                        dbo.Inventory_Log.Quantity END AS To_Quantity, dbo.Stocks.Stock_ID, dbo.Items.Item_ID FROM         dbo.Inventory_Log INNER JOIN                       dbo.Stocks ON dbo.Inventory_Log.Stock_ID = dbo.Stocks.Stock_ID INNER JOIN                       dbo.Items ON dbo.Inventory_Log.Item_ID = dbo.Items.Item_ID"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Subscriptions_Categories]( 	[Category_ID] [int] IDENTITY(1,1) NOT NULL, 	[Category_Name] [nvarchar](50) NULL, 	[Generic_Desc] [nvarchar](150) NULL,  CONSTRAINT [PK_Subscriptions_Categories] PRIMARY KEY CLUSTERED  ( 	[Category_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Subscriptions_Categories] UNIQUE NONCLUSTERED  ( 	[Category_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Table_Columns]( 	[Serial_PK] [int] NOT NULL, 	[Physical_Name] [nvarchar](50) NULL, 	[Logical_Name] [nvarchar](50) NULL, 	[Table_ID] [nvarchar](50) NULL ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " create procedure [dbo].[commit_Items_sales_details](@P_bill_id int,@p_item_id int,@p_um_detail_id int,@p_quantity decimal(18,2), @p_price decimal(18,2),@p_total_item decimal(18,2),@p_stock_Id int ,@p_expired_date date,@p_date date,@P_Serial_PK int) as begin  declare  @v_equivalent_quantity  decimal(18,2),@v_r decimal(18,2),@y int,@r decimal(18,2) insert into items_sales_details(Serial_PK,Item_Id,Um_Detail_Id,Expired_Date,Quantity,Price,Total_Item) values(@P_Serial_PK,@p_item_id,@p_um_detail_id ,@p_expired_date,@p_quantity,@p_price,@p_total_item) begin select @v_equivalent_quantity =equivalent_quantity  from report_items_stocks_balance where um_detail_id=@p_um_detail_id  and Item_Id =@p_item_id and Expired_Date=@P_Expired_date and  Stock_Id=@P_stock_id set @v_r= @v_equivalent_quantity*@p_quantity update Items_stocks set Balance=Balance-@v_r  where item_id=@p_Item_Id and Expired_Date=@P_Expired_date and  Stock_Id=@p_stock_id delete from Items_stocks where Balance <=0  END insert into Inventory_Log(Doc_ID,Doc_Date,Doc_Type,Total_Doc,Item_ID,Quantity,Stock_ID) values (@P_bill_id,@p_date,N'فاتورة مبيعات - صنف تجاري',@p_total_item,@P_item_id,@P_quantity,@P_stock_id) end"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Money_Payables]( 	[Pay_ID] [int] NOT NULL, 	[To_Procedure_Master_ID] [int] NULL, 	[Pay_Date] [date] NULL, 	[Pay_Type] [nvarchar](50) NULL, 	[Pay_Value] [decimal](18, 2) NULL, 	[Pay_Desc] [nvarchar](150) NULL, 	[Cheque_Number] [nvarchar](50) NULL,  CONSTRAINT [PK_Money_Payables] PRIMARY KEY CLUSTERED  ( 	[Pay_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Procedure_Details]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[From_Procedure_Master_ID] [int] NULL, 	[To_Procedure_Master_ID] [int] NULL, 	[Procedure_Value] [decimal](18, 2) NULL, 	[Procedure_Date] [date] NULL, 	[Procedure_Desc] [nvarchar](150) NULL,  CONSTRAINT [PK_Procedure_Details] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Special_Categories]( 	[Special_Categories_ID] [int] NOT NULL, 	[Category_Name] [nvarchar](50) NULL, 	[Value] [decimal](18, 2) NULL, 	[Coach_Percent] [decimal](18, 2) NULL, 	[Generic_Desc] [nvarchar](150) NULL,  CONSTRAINT [PK_Special_Categories] PRIMARY KEY CLUSTERED  ( 	[Special_Categories_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TRIGGER [dbo].[TRIG_CREATE_DEP_PRO_DTLS] ON [dbo].[Procedure_Master]  AFTER INSERT  AS  BEGIN DECLARE @Daily_Procedure_Name NVARCHAR(50),@Procedure_Category NVARCHAR(50) SET @Procedure_Category=(SELECT Procedure_Category FROM INSERTED) IF @Procedure_Category=N'أصول ثابته' BEGIN SELECT @Daily_Procedure_Name=Daily_Procedure_Name FROM INSERTED INSERT INTO Procedure_Master(Daily_Procedure_Name,Reference_ID,Generic_Desc,Balance,Procedure_Category,Procedure_Type) VALUES(N'اهلاك ' + @Daily_Procedure_Name , 0 , N'حساب اهلاك الأصل',0,N'مصاريف اداريه',N'مدين') INSERT INTO Procedure_Master(Daily_Procedure_Name,Reference_ID,Generic_Desc,Balance,Procedure_Category,Procedure_Type) VALUES(N'مجمع اهلاك ' + @Daily_Procedure_Name , 0 , N'حساب مجمع اهلاك الأصل',0,N'مجمع اهلاكات',N'دائن') END END"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Subscriptions]( 	[Subscription_ID] [int] IDENTITY(1,1) NOT NULL, 	[Subscription_Name] [nvarchar](50) NULL, 	[Category_ID] [int] NULL, 	[Generic_Desc] [nvarchar](150) NULL, 	[No_Training] [int] NULL, 	[Months] [int] NULL, 	[Value_Group] [decimal](18, 2) NULL, 	[Value_Single] [decimal](18, 2) NULL,  CONSTRAINT [PK_Subscriptions] PRIMARY KEY CLUSTERED  ( 	[Subscription_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Subscriptions] UNIQUE NONCLUSTERED  ( 	[Subscription_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Money_Receivables]( 	[Rec_ID] [int] NOT NULL, 	[From_Procedure_Master_ID] [int] NULL, 	[Rec_Date] [date] NULL, 	[Rec_Type] [nvarchar](50) NULL, 	[Rec_Value] [decimal](18, 2) NULL, 	[Rec_Desc] [nvarchar](150) NULL, 	[Cheque_Number] [nvarchar](50) NULL,  CONSTRAINT [PK_Money_Receivables] PRIMARY KEY CLUSTERED  ( 	[Rec_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()
        CalcProgress()

        cmd.CommandText = " CREATE TABLE [dbo].[Shifts_Details]( 	[Shift_Details_ID] [int] NOT NULL, 	[Shift_Details_Name] [nvarchar](50) NULL, 	[From_Time] [time](7) NULL, 	[To_Time] [time](7) NULL, 	[Shift_ID] [int] NULL, 	[Generic_Desc] [nvarchar](150) NULL,  CONSTRAINT [PK_Shifts_Details] PRIMARY KEY CLUSTERED  ( 	[Shift_Details_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Shifts_Details] UNIQUE NONCLUSTERED  ( 	[Shift_Details_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE PROCEDURE [dbo].[APPLY_PREFERENCES](@PUR_ID INT,@SAL_ID INT,@RET_CUS_ID INT,@RET_VEN_ID INT, @DEP_ID INT,@ADJ_ID INT)   AS  BEGIN  UPDATE Seq_Table SET Curr_Val = @PUR_ID WHERE Seq_ID =1  UPDATE Seq_Table SET Curr_Val = @SAL_ID WHERE Seq_ID =2  UPDATE Seq_Table SET Curr_Val = @RET_CUS_ID WHERE Seq_ID =3  UPDATE Seq_Table SET Curr_Val = @RET_VEN_ID WHERE Seq_ID =4  UPDATE Seq_Table SET Curr_Val = @DEP_ID WHERE Seq_ID =6  UPDATE Seq_Table SET Curr_Val = @ADJ_ID WHERE Seq_ID =7 END"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Customers_Evaluation_Details]( 	[Evaluation_Detail_ID] [int] IDENTITY(1,1) NOT NULL, 	[Evaluation_Detail_Name] [nvarchar](50) NULL, 	[Generic_Desc] [nvarchar](150) NULL, 	[Evaluation_ID] [int] NULL,  CONSTRAINT [PK_Customers_Evaluation_Details] PRIMARY KEY CLUSTERED  ( 	[Evaluation_Detail_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Loans]( 	[Loan_ID] [int] IDENTITY(1,1) NOT NULL, 	[Loan_Name] [nvarchar](50) NULL, 	[Loan_Date] [date] NULL, 	[Finish_date] [date] NULL, 	[Loan_Value] [decimal](18, 2) NULL, 	[Loan_Type] [nvarchar](50) NULL, 	[Employee_ID] [int] NULL, 	[Stock_ID] [int] NULL,  CONSTRAINT [PK_Loans] PRIMARY KEY CLUSTERED  ( 	[Loan_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE trigger [dbo].[Trig_Customer_Loans] on [dbo].[Loans] AFTER INSERT  as begin declare  @chkexist decimal (18,2),@emp_Id int,@num_monthes decimal(18,2),@i int=1,@phaseValue decimal(18,2),  @Loan_Value decimal(18,2),@emp_Name nvarchar(50),@proceure_master_id int,@loan_ID int, @loan_date date,  @finish_date date,@restaurant_ID int,@Shift_detail_id int,@loan_type nvarchar(50)	,@pay_ID int   select @emp_Id=employee_ID,@Loan_Value=loan_Value,@loan_ID=loan_Id,@loan_date=loan_date,@finish_date = finish_Date, @restaurant_ID =STOCK_ID,@loan_type =loan_type from inserted set @emp_Name = ( select employee_Name from employees where employee_ID= @emp_Id ) set @chkexist = (select count(*) from procedure_master where reference_id = @emp_Id and procedure_Category=N'أرصده مدينه') set @Shift_detail_id = (select max(Shift_detail_id) from shift_Details where end_date is null and restaurant_ID=@restaurant_ID) if @loan_type=N'جدوله' begin if @chkexist =0  begin insert into procedure_master(Daily_Procedure_Name,Reference_ID,Balance,Procedure_Category,Procedure_Type) values(N'سلف عاملين - ' + @emp_Name,@emp_Id,0,N'أرصده مدينه',N'مدين') select @proceure_master_id =procedure_master_ID from procedure_Master where  Reference_ID =@emp_Id and Procedure_Category=N'أرصده مدينه' and Procedure_Type=N'مدين' end set @num_monthes = datediff (MM,@loan_date,@finish_date) set @phaseValue =@Loan_Value/@num_monthes while @i <= @num_monthes begin insert into loans_details(loan_id,Phase_Value,Phase_Status,Pay_Date) values(@loan_ID,@phaseValue,N'غير مدفوع',dateadd(month,@i,@loan_date))  set @i=@i+1   end  end    INSERT INTO Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc) VALUES(@proceure_master_id,4,@Loan_Value,GETDATE(),N'سلف عاملين')  set @pay_ID = (select isnull(max(pay_ID),1) from money_payables )  Set @pay_ID=@pay_ID+1  insert into money_payables(pay_ID,to_procedure_Master_ID,pay_Date,pay_type,pay_Value)    values(@pay_ID,4,@loan_date,N'نقدي',@Loan_Value) end"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Report_User_Log] AS SELECT dbo.App_Users.User_ID, dbo.App_Users.User_Name, dbo.Employees.Employee_Name, dbo.User_Log.Action, dbo.User_Log.Action_Date, dbo.User_Log.Action_Time FROM  dbo.App_Users INNER JOIN dbo.User_Log ON dbo.App_Users.User_ID = dbo.User_Log.User_ID INNER JOIN dbo.Employees ON dbo.App_Users.Employee_ID = dbo.Employees.Employee_ID"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE VIEW [dbo].[Report_Check_Items] AS SELECT     dbo.Check_Header.Check_ID, dbo.Check_Header.Check_Name, dbo.Items.Item_ID, dbo.Items.Item_Name, dbo.Stocks.Stock_Name,                        dbo.Stocks.Stock_ID, dbo.Check_Details.System_Quantity, dbo.Check_Details.User_Quantity, dbo.Check_Details.Price, dbo.Check_Details.Expired_Date,                        dbo.Employees.Employee_Name, dbo.Employees.Employee_ID FROM         dbo.Check_Header INNER JOIN                       dbo.Check_Details ON dbo.Check_Header.Check_ID = dbo.Check_Details.Check_ID INNER JOIN                       dbo.Stocks ON dbo.Check_Header.Stock_ID = dbo.Stocks.Stock_ID INNER JOIN                       dbo.Items ON dbo.Check_Details.Item_ID = dbo.Items.Item_ID INNER JOIN                       dbo.Employees ON dbo.Check_Header.Employee_ID = dbo.Employees.Employee_ID"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE VIEW [dbo].[Query_Loans] AS SELECT     dbo.Loans.Loan_ID, dbo.Loans.Loan_Name, dbo.Employees.Employee_ID, dbo.Employees.Employee_Name, dbo.Loans_Details.Phase_ID,                        dbo.Loans_Details.Phase_Value, dbo.Loans_Details.Phase_Status, dbo.Loans_Details.Pay_Date FROM         dbo.Loans INNER JOIN                       dbo.Loans_Details ON dbo.Loans.Loan_ID = dbo.Loans_Details.Loan_ID INNER JOIN                       dbo.Employees ON dbo.Loans.Employee_ID = dbo.Employees.Employee_ID"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE VIEW [dbo].[Emp_Security]   AS SELECT dbo.Employees.Employee_ID, dbo.Employees.Employee_Name, dbo.App_Users.User_ID, dbo.App_Users.User_Name, dbo.App_Users.User_Password,dbo.App_Users.Account_Status, dbo.Security_Group_Header.Group_ID, dbo.Security_Group_Header.Group_Name, dbo.Security_Group_Details.Privilege_ID,dbo.Security_Group_Details.Privilege_Name, dbo.Security_Group_Details.Granted, dbo.Security_Group_Details.Grant_Type  FROM dbo.Employees INNER JOIN dbo.App_Users ON dbo.Employees.Employee_ID = dbo.App_Users.Employee_ID INNER JOIN dbo.Security_Group_Header ON dbo.App_Users.Group_ID = dbo.Security_Group_Header.Group_ID INNER JOIN dbo.Security_Group_Details ON dbo.Security_Group_Header.Group_ID = dbo.Security_Group_Details.Group_ID"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Expenses_Details]( 	[Expense_Detail_ID] [int] IDENTITY(1,1) NOT NULL, 	[Expense_Category_ID] [int] NULL, 	[Expense_Name] [nvarchar](50) NULL, 	[Expense_Desc] [nvarchar](150) NULL,  CONSTRAINT [PK_Expenses_Details] PRIMARY KEY CLUSTERED  ( 	[Expense_Detail_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Expenses_Details] UNIQUE NONCLUSTERED  ( 	[Expense_Name] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " create PROCEDURE [dbo].[Update_Seq](@S_ID NUMERIC(3),@CURR_ID NUMERIC(8) OUTPUT) AS BEGIN TRAN DECLARE @C_ID NUMERIC SET @C_ID= (SELECT CURR_VAL FROM SEQ_TABLE WHERE SEQ_ID = @S_ID) UPDATE SEQ_TABLE SET CURR_VAL = CURR_VAL + 1 WHERE SEQ_ID = @S_ID COMMIT TRAN SET @CURR_ID = @C_ID"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " create FUNCTION [dbo].[TEST_DEP_PRO_ID](@DAILY_PROCEDURE_NAME NVARCHAR(50)) RETURNS INT AS BEGIN DECLARE @I INT=0 SET @I =(SELECT COUNT(*) FROM Procedure_Master WHERE Daily_Procedure_Name LIKE N'مجمع اهلاك ' +  @DAILY_PROCEDURE_NAME) IF @I=0 BEGIN SET @I=(SELECT COUNT(*) FROM Procedure_Master WHERE Daily_Procedure_Name LIKE N'اهلاك ' +  @DAILY_PROCEDURE_NAME) END RETURN @I END"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " create TRIGGER [dbo].[TRIG_Ven_ID] ON [dbo].[Vendors]  AFTER INSERT AS BEGIN DECLARE @VEN_ID INT,@VEN_NAME NVARCHAR(50)   SET @VEN_ID=(SELECT VENDOR_ID FROM INSERTED)   SET @VEN_NAME=(SELECT VENDOR_NAME FROM INSERTED)   INSERT INTO PROCEDURE_MASTER(Daily_Procedure_Name,Reference_ID,Balance,Procedure_Category,Procedure_Type)   VALUES(N'حساب موردين - ' + @VEN_NAME,@VEN_ID,0,N'موردين',N'دائن') END;"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Vendors_Transactions]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Doc_ID] [int] NULL, 	[Doc_Date] [date] NULL, 	[Doc_Type] [nvarchar](50) NULL, 	[Total_Doc] [decimal](18, 2) NULL, 	[Doc_Value] [decimal](18, 2) NULL, 	[Vendor_ID] [int] NULL,  CONSTRAINT [PK_Vendors_Transactions] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Vendors_Payments]( 	[Pay_V_ID] [int] IDENTITY(1,1) NOT NULL, 	[Bill_Date] [date] NULL, 	[Payed_Date] [date] NULL, 	[Vendor_ID] [int] NULL, 	[Pay_Value] [decimal](18, 0) NULL, 	[Status] [nvarchar](15) NULL,  CONSTRAINT [PK_Vendors_Payments] PRIMARY KEY CLUSTERED  ( 	[Pay_V_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " create trigger [dbo].[Insert_Pro_master] on [dbo].[Subscriptions] after insert as begin declare @Sub_ID as int,@DPN as nvarchar(50) select @sub_id=Subscription_ID,@dpn=Subscription_Name from inserted set @dpn= N'حساب اشتراك'+ ' - ' +@dpn insert into procedure_master(daily_Procedure_Name,reference_ID,Generic_Desc,Balance,Procedure_Category,Procedure_Type) values(@dpn,@sub_id,Null,0,N'ايرادات متنوعه',N'دائن') end"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " Create function [dbo].[get_shift_name](@time time(7),@Emp as integer) returns int begin declare @shift_ID int select @shift_id=sd.shift_Details_id from shifts_details sd,employees_shifts es where sd.shift_Details_id=es.shift_detail_id and Employee_id=@emp and @time between from_time and to_time return @shift_id end "
        cmd.ExecuteNonQuery()
        CalcProgress()

        cmd.CommandText = " create FUNCTION [dbo].[Get_Any_Previous_Balance](@Procedure_Master_ID int,@Before_Date Date) RETURNS DECIMAL(18,5) AS BEGIN DECLARE @PROCEDURE_TYPE NVARCHAR(5),@PROCEDURE_BALANCE DECIMAL(18,5),@TOTAL_DEBIT DECIMAL(18,5),@TOTAL_CREDIT DECIMAL(18,5), @FIRST_BALANCE DECIMAL(18,5) SELECT @PROCEDURE_TYPE=PROCEDURE_TYPE,@FIRST_BALANCE=BALANCE FROM PROCEDURE_MASTER WHERE PROCEDURE_MASTER_ID = @Procedure_Master_ID SET @TOTAL_DEBIT=(SELECT isnull(SUM(PROCEDURE_VALUE),0) FROM PROCEDURE_DETAILS WHERE FROM_PROCEDURE_MASTER_ID=@Procedure_Master_ID  AND PROCEDURE_DATE < @Before_DATE) SET @TOTAL_CREDIT=(SELECT ISNull(SUM(PROCEDURE_VALUE),0) FROM PROCEDURE_DETAILS WHERE TO_PROCEDURE_MASTER_ID=@Procedure_Master_ID AND PROCEDURE_DATE < @Before_DATE) IF @PROCEDURE_TYPE = N'مدين' BEGIN SET @PROCEDURE_BALANCE=(@FIRST_BALANCE+@TOTAL_DEBIT)-@TOTAL_CREDIT END ELSE IF @PROCEDURE_TYPE = N'دائن' BEGIN SET @PROCEDURE_BALANCE=(@FIRST_BALANCE+@TOTAL_CREDIT)-@TOTAL_DEBIT END RETURN @PROCEDURE_BALANCE END"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE FUNCTION [dbo].[Get_Any_Last_Balance](@Procedure_Master_ID int,@Before_Date Date) RETURNS DECIMAL(18,5) AS BEGIN DECLARE @PROCEDURE_TYPE NVARCHAR(5),@PROCEDURE_BALANCE DECIMAL(18,5),@TOTAL_DEBIT DECIMAL(18,5),@TOTAL_CREDIT DECIMAL(18,5), @FIRST_BALANCE DECIMAL(18,5) SELECT @PROCEDURE_TYPE=PROCEDURE_TYPE,@FIRST_BALANCE=BALANCE FROM PROCEDURE_MASTER WHERE PROCEDURE_MASTER_ID = @Procedure_Master_ID SET @TOTAL_DEBIT=(SELECT isnull(SUM(PROCEDURE_VALUE),0) FROM PROCEDURE_DETAILS WHERE FROM_PROCEDURE_MASTER_ID=@Procedure_Master_ID  AND PROCEDURE_DATE <= @Before_DATE) SET @TOTAL_CREDIT=(SELECT ISNull(SUM(PROCEDURE_VALUE),0) FROM PROCEDURE_DETAILS WHERE TO_PROCEDURE_MASTER_ID=@Procedure_Master_ID AND PROCEDURE_DATE <= @Before_DATE) IF @PROCEDURE_TYPE = N'مدين' BEGIN SET @PROCEDURE_BALANCE=(@FIRST_BALANCE+@TOTAL_DEBIT)-@TOTAL_CREDIT END ELSE IF @PROCEDURE_TYPE = N'دائن' BEGIN SET @PROCEDURE_BALANCE=(@FIRST_BALANCE+@TOTAL_CREDIT)-@TOTAL_DEBIT END RETURN @PROCEDURE_BALANCE END"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " Create FUNCTION [dbo].[Get_Any_Balance](@Procedure_Master_ID int,@From_Date Date,@To_Date Date) RETURNS DECIMAL(18,5) AS BEGIN DECLARE @PROCEDURE_TYPE NVARCHAR(5),@PROCEDURE_BALANCE DECIMAL(18,5),@TOTAL_DEBIT DECIMAL(18,5),@TOTAL_CREDIT DECIMAL(18,5), @FIRST_BALANCE DECIMAL(18,5) SELECT @PROCEDURE_TYPE=PROCEDURE_TYPE,@FIRST_BALANCE=BALANCE FROM PROCEDURE_MASTER WHERE PROCEDURE_MASTER_ID = @Procedure_Master_ID SET @TOTAL_DEBIT=(SELECT isnull(SUM(PROCEDURE_VALUE),0) FROM PROCEDURE_DETAILS WHERE FROM_PROCEDURE_MASTER_ID=@Procedure_Master_ID  AND PROCEDURE_DATE BETWEEN @FROM_DATE AND @TO_DATE) SET @TOTAL_CREDIT=(SELECT ISNull(SUM(PROCEDURE_VALUE),0) FROM PROCEDURE_DETAILS WHERE TO_PROCEDURE_MASTER_ID=@Procedure_Master_ID AND PROCEDURE_DATE BETWEEN @FROM_DATE AND @TO_DATE) IF @PROCEDURE_TYPE = N'مدين' BEGIN SET @PROCEDURE_BALANCE=(@FIRST_BALANCE+@TOTAL_DEBIT)-@TOTAL_CREDIT END ELSE IF @PROCEDURE_TYPE = N'دائن' BEGIN SET @PROCEDURE_BALANCE=(@FIRST_BALANCE+@TOTAL_CREDIT)-@TOTAL_DEBIT END RETURN @PROCEDURE_BALANCE END"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE VIEW [dbo].[report_dep_items] AS SELECT     dbo.Dep_Header.Bill_ID, dbo.Dep_Header.Bill_Date, dbo.Dep_Header.Stock_ID, dbo.Dep_Header.Employee_ID,                        dbo.Employees.Employee_Name, dbo.Stocks.Stock_Name, dbo.Dep_Details.Item_ID, dbo.Dep_Details.Quantity,                        dbo.Um_Details.Equivalent_name + ' ' + dbo.Items.Item_Name AS ITEM, dbo.Items.Barcode, dbo.Dep_Details.Price, dbo.Dep_Details.Expired_Date,                        dbo.Dep_Details.Total_Item, dbo.Dep_Header.Total_Bill, dbo.Dep_Header.Bill_Time, dbo.Stocks.Logo, dbo.Dep_Details.Reason FROM         dbo.Dep_Details INNER JOIN                       dbo.Um_Details ON dbo.Dep_Details.Um_Detail_ID = dbo.Um_Details.Um_Detail_Id INNER JOIN                       dbo.Items ON dbo.Dep_Details.Item_ID = dbo.Items.Item_ID INNER JOIN                       dbo.Dep_Header ON dbo.Dep_Details.Bill_ID = dbo.Dep_Header.Bill_ID INNER JOIN                       dbo.Stocks ON dbo.Stocks.Stock_ID = dbo.Dep_Header.Stock_ID INNER JOIN                       dbo.Employees ON dbo.Dep_Header.Employee_ID = dbo.Employees.Employee_ID"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE VIEW [dbo].[Query_Items_Dep]  AS SELECT dbo.Dep_Header.Bill_ID, dbo.Dep_Header.Bill_Date, dbo.Dep_Header.Bill_Time, dbo.Stocks.Stock_Name, dbo.Items.Item_Name, dbo.Items.Barcode, dbo.Dep_Details.Quantity, dbo.Dep_Details.Reason, dbo.Employees.Employee_Name FROM dbo.Items INNER JOIN dbo.Dep_Details ON dbo.Items.Item_ID = dbo.Dep_Details.Item_ID INNER JOIN dbo.Dep_Header ON dbo.Dep_Details.Bill_ID = dbo.Dep_Header.Bill_ID INNER JOIN dbo.Stocks ON dbo.Dep_Header.Stock_ID = dbo.Stocks.Stock_ID INNER JOIN dbo.Employees ON dbo.Dep_Header.Employee_ID = dbo.Employees.Employee_ID"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Employees_Added_Hours]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Employee_ID] [int] NULL, 	[Hours_Date] [date] NULL, 	[From_Time] [nvarchar](15) NULL, 	[To_Time] [nvarchar](15) NULL, 	[Reward_Value] [decimal](18, 0) NULL,  CONSTRAINT [PK_Employees_Added_Hours] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Employees_Vacations]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Employee_ID] [int] NULL, 	[From_Date] [date] NULL, 	[To_Date] [date] NULL,  CONSTRAINT [PK_Employees_Vacations] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Employees_Tasks]( 	[Task_ID] [int] IDENTITY(1,1) NOT NULL, 	[Task_Code] [nvarchar](50) NULL, 	[From_Employee] [int] NULL, 	[To_Employee] [int] NULL, 	[Title] [nvarchar](100) NULL, 	[Task_Desc] [nvarchar](200) NULL, 	[Task_Date] [date] NULL, 	[Approved] [bit] NULL,  CONSTRAINT [PK_Employees_Tasks] PRIMARY KEY CLUSTERED  ( 	[Task_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],  CONSTRAINT [IX_Employees_Tasks] UNIQUE NONCLUSTERED  ( 	[Task_Code] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Employees_Shifts]( 	[Employee_Shift_ID] [int] IDENTITY(1,1) NOT NULL, 	[Employee_ID] [int] NULL, 	[Shift_Detail_ID] [int] NULL, 	[Generic_Desc] [nvarchar](150) NULL,  CONSTRAINT [PK_Employees_Shifts] PRIMARY KEY CLUSTERED  ( 	[Employee_Shift_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()


        cmd.CommandText = " CREATE TABLE [dbo].[Employees_Rewards]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Employee_ID] [int] NULL, 	[Reward_Date] [datetime] NULL, 	[Reason] [nvarchar](150) NULL, 	[Reward_Value] [decimal](18, 0) NULL, 	[Category_ID] [int] NULL,  CONSTRAINT [PK_Employees_Rewards] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Employees_Extra]( 	[Serial_Pk] [int] IDENTITY(1,1) NOT NULL, 	[Employee_ID] [int] NULL, 	[Extra_Date] [date] NULL, 	[Extra_Value] [decimal](18, 2) NULL, 	[Reason] [nvarchar](150) NULL, 	[Category_ID] [int] NULL,  CONSTRAINT [PK_Employees_Extra] PRIMARY KEY CLUSTERED  ( 	[Serial_Pk] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Employees_Discounts]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Employee_ID] [int] NULL, 	[Discount_Date] [datetime] NULL, 	[Reason] [nvarchar](150) NULL, 	[Discount_Value] [decimal](18, 0) NULL, 	[Category_ID] [int] NULL,  CONSTRAINT [PK_Employees_Discounts] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE PROCEDURE [dbo].[Commit_Procedure_Tran](@From_Procedure_Master_ID INT,@To_Procedure_Master_ID INT,@PROCEDURE_VALUE DECIMAL(18,5),@PROCEDURE_DESC NVARCHAR(150)) AS BEGIN INSERT INTO Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc) VALUES(@From_Procedure_Master_ID,@To_Procedure_Master_ID,@Procedure_Value,GETDATE(),@Procedure_Desc) END"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE PROCEDURE [dbo].[Commit_Procedure_Dep](@DAILY_PROCEDURE_NAME NVARCHAR(50),@PROCEDURE_VALUE DECIMAL(18,5), @PROCEDURE_DATE DATE,@PROCEDURE_DESC NVARCHAR(150)) AS DECLARE @From_Procedure_Master_ID INT,@To_Procedure_Master_ID INT BEGIN SET @To_Procedure_Master_ID=(SELECT PROCEDURE_MASTER_ID FROM Procedure_Master WHERE Daily_Procedure_Name LIKE N'مجمع اهلاك ' +  @DAILY_PROCEDURE_NAME) SET @From_Procedure_Master_ID=(SELECT PROCEDURE_MASTER_ID FROM Procedure_Master WHERE Daily_Procedure_Name LIKE N'اهلاك ' +  @DAILY_PROCEDURE_NAME) INSERT INTO Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc) VALUES(@From_Procedure_Master_ID,@To_Procedure_Master_ID,@Procedure_Value,@PROCEDURE_DATE,@Procedure_Desc) END"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " create PROCEDURE [dbo].[Commit_Check_Tran](@Normal_Value Decimal(18,5),@Emp_Value Decimal(18,5),@Partner_Value Decimal(18,5), @Partner_Pro_ID Int,@Increase Decimal(18,5)) AS BEGIN IF @Normal_Value>0 	BEGIN 		INSERT INTO Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc)  		VALUES(16,8,@Normal_Value,GETDATE(),N'اهلاك جرد طبيعي') 	END ELSE IF @Emp_Value>0 	BEGIN 		INSERT INTO Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc)  		VALUES(19,7,@Emp_Value,GETDATE(),N'اهلاك جرد محمل علي موظف') 	END ELSE IF @Partner_Value>0 	BEGIN 		INSERT INTO Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc)  		VALUES(@Partner_Pro_ID,7,@Partner_Value,GETDATE(),N'اهلاك جرد محمل علي جاري الشريك') 	END ELSE IF @Increase>0 	BEGIN 		INSERT INTO Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc)  	VALUES(20,16,@Increase,GETDATE(),N'زياده مخزنيه') 	END END"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE TABLE [dbo].[Attendance]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Employee_ID] [int] NULL, 	[Attend_Date] [date] NULL, 	[Attend_Time] [time](7) NULL, 	[Attend_Type] [nvarchar](10) NULL, 	[Hall_ID] [int] NULL, 	[Shift_Detail_ID] [int] NULL,  CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Report_Adjustments] AS SELECT     AH.Adjustment_ID, AH.Adjustment_Date, AH.Adjustment_Time, S.Stock_Name AS FROM_Stock, S2.Stock_Name AS TO_Stock,AH.Adjustment_Desc, E.Employee_Name, I.Item_Name, I.Barcode, AD.Quantity, AD.Item_ID FROM         dbo.Adjustment_Header AS AH INNER JOIN                       dbo.Adjustment_Details AS AD ON AH.Adjustment_ID = AD.Adjustment_ID INNER JOIN                       dbo.Employees AS E ON AH.Employee_ID = E.Employee_ID INNER JOIN                       dbo.Items AS I ON AD.Item_ID = I.Item_ID INNER JOIN                       dbo.Stocks AS S ON AH.From_Stock_ID = S.Stock_ID INNER JOIN                       dbo.Stocks AS S2 ON AH.To_Stock_ID = S2.Stock_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[report_vendors_returns] AS SELECT     dbo.Return_V_Header.Bill_ID, dbo.Return_V_Header.Bill_Date, dbo.Return_V_Header.Bill_Time, dbo.Vendors.Vendor_Name, dbo.Employees.Employee_Name,                        dbo.Stocks.Stock_Name, dbo.Return_V_Header.Total_Bill, dbo.Return_V_Header.Comments, dbo.Return_V_Header.Footer,                        dbo.Items.Item_Name + '  ' + dbo.Um_Details.Equivalent_name AS item_name, dbo.Return_V_Details.Quantity, dbo.Return_V_Details.Price,                        dbo.Return_V_Details.Total_Item, dbo.Return_V_Details.Item_ID, dbo.Return_V_Header.Tax FROM         dbo.Return_V_Header INNER JOIN                       dbo.Return_V_Details ON dbo.Return_V_Header.Bill_ID = dbo.Return_V_Details.Bill_ID INNER JOIN                       dbo.Vendors ON dbo.Return_V_Header.Vendor_ID = dbo.Vendors.Vendor_Id INNER JOIN                       dbo.Um_Details ON dbo.Return_V_Details.Um_Detail_ID = dbo.Um_Details.Um_Detail_Id INNER JOIN                       dbo.Items ON dbo.Return_V_Details.Item_ID = dbo.Items.Item_Id INNER JOIN                       dbo.Stocks ON dbo.Return_V_Header.Stock_ID = dbo.Stocks.Stock_Id INNER JOIN                       dbo.Employees ON dbo.Return_V_Header.Employee_ID = dbo.Employees.Employee_Id"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE VIEW [dbo].[Report_Daily_Procedure] AS SELECT     M.Procedure_Master_ID AS FROM_PROCEDURE_ID, N' من ح/' + M.Daily_Procedure_Name AS FROM_PROCEDURE, M2.Procedure_Master_ID AS TO_PROCEDURE_ID,                        N' الي ح/' + M2.Daily_Procedure_Name AS TO_PROCEDURE, D.Procedure_Date, D.Procedure_Value, D.Procedure_Desc, M.Procedure_Category,                        M.Procedure_Type FROM         dbo.Procedure_Master AS M INNER JOIN                       dbo.Procedure_Details AS D ON M.Procedure_Master_ID = D.From_Procedure_Master_ID INNER JOIN                       dbo.Procedure_Master AS M2 ON D.To_Procedure_Master_ID = M2.Procedure_Master_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Query_Employees] AS SELECT     dbo.Employees.Employee_ID, dbo.Employees.Employee_Name, dbo.Jobs.Job_Title, dbo.Employees.Address, dbo.Employees.Tele, dbo.Employees.Mobile,                        dbo.Employees.Basic_Salary,dbo.Employees.Variable_Salary, dbo.Employees.Hire_Date, dbo.Employees.Education, dbo.Employees.Email FROM         dbo.Employees INNER JOIN                       dbo.Jobs ON dbo.Employees.Job_ID = dbo.Jobs.Job_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Report_Departments_Employees_Jobs] AS SELECT     dbo.Departments.Department_Id, dbo.Departments.Department_Name, dbo.Employees.Employee_Name, dbo.Jobs.Job_Id, dbo.Jobs.Job_Title,                        dbo.Employees.Basic_Salary, dbo.Employees.Variable_Salary, dbo.Employees.Employee_Id FROM         dbo.Departments INNER JOIN                       dbo.Employees ON dbo.Departments.Department_Id = dbo.Employees.Department_Id INNER JOIN                       dbo.Jobs ON dbo.Employees.Job_Id = dbo.Jobs.Job_Id"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Report_Subscriptions] AS SELECT     dbo.Subscriptions_Categories.Category_Name, dbo.Subscriptions.Subscription_Name, dbo.Subscriptions_Categories.Category_ID,                        dbo.Subscriptions.Subscription_ID, dbo.Subscriptions.No_Training, dbo.Subscriptions.Value_Group, dbo.Subscriptions.Value_Single FROM         dbo.Subscriptions INNER JOIN                       dbo.Subscriptions_Categories ON dbo.Subscriptions.Category_ID = dbo.Subscriptions_Categories.Category_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Sub_Stocks]( 	[Sub_Stock_ID] [int] NOT NULL, 	[Sub_Stock_Name] [nvarchar](50) NULL, 	[Employee_ID] [int] NULL, 	[Description] [nvarchar](150) NULL,  CONSTRAINT [PK_Sub_Stocks] PRIMARY KEY CLUSTERED  ( 	[Sub_Stock_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TRIGGER [dbo].[TRIG_Company_ID] ON [dbo].[Companies]  AFTER INSERT  AS   BEGIN   DECLARE @COMPANY_ID INT,@COMPANY_NAME NVARCHAR(50)  SELECT @COMPANY_ID=COMPANY_ID,@COMPANY_NAME=COMPANY_NAME FROM INSERTED INSERT INTO PROCEDURE_MASTER(Daily_Procedure_Name,Reference_ID,Balance,Procedure_Category,Procedure_Type)  VALUES(N'حساب شركات - ' + @COMPANY_NAME,@COMPANY_ID,0,N'عملاء',N'مدين') END;"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE TRIGGER [dbo].[TRIG_Bank_Accounts_ID] ON [dbo].[Banks_Accounts]  AFTER INSERT  AS  BEGIN  DECLARE @Acc_ID INT,@Acc_Num NVARCHAR(50)  select @Acc_ID = Account_ID,@Acc_Num = Account_Number from inserted INSERT INTO PROCEDURE_MASTER(Daily_Procedure_Name,Reference_ID,Balance,Procedure_Category,Procedure_Type)  VALUES (N'حساب بنك رقم - ' + @Acc_Num,@Acc_ID,0,N'بنوك',N'مدين')  END;"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TRIGGER [dbo].[TRIG_ACC_EXPENSES_DETAILS] ON  [dbo].[Expenses_Details]  AFTER INSERT  AS   BEGIN  DECLARE @EXPENSE_NAME NVARCHAR(50),@EXPENSE_DETAIL_ID INT  SELECT @EXPENSE_NAME=EXPENSE_NAME,@EXPENSE_DETAIL_ID=EXPENSE_DETAIL_ID FROM INSERTED INSERT INTO PROCEDURE_MASTER(Daily_Procedure_Name,Reference_ID,Balance,Procedure_Category,Procedure_Type)   VALUES(N'حساب مصروفات - ' + @EXPENSE_NAME,@EXPENSE_DETAIL_ID,0,N'مصاريف اداريه',N'مدين')  END"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " create trigger [dbo].[Special_Categ_Pro_Master] on [dbo].[Special_Categories] after insert as begin declare @Sub_ID as int,@DPN as nvarchar(50) select @sub_id=special_categories_id,@dpn=category_name from inserted set @dpn= N'حساب جلسه خاصه'+ ' - ' +@dpn insert into procedure_master(daily_Procedure_Name,reference_ID,Generic_Desc,Balance,Procedure_Category,Procedure_Type) values(@dpn,@sub_id,Null,0,N'ايرادات متنوعه',N'دائن') end"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Trainers_Details]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Trainer_ID] [int] NULL, 	[Subscription_ID] [int] NULL, 	[No_Customers] [int] NULL,  CONSTRAINT [PK_Trainers_Details] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Pay_Salary]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Employee_ID] [int] NULL, 	[Pay_Date] [date] NULL, 	[Basic_Salary] [decimal](18, 2) NULL, 	[Variable_Salary] [decimal](18, 2) NULL, 	[Extra_Subscription] [decimal](18, 2) NULL, 	[Emp_Rewards] [decimal](18, 2) NULL, 	[Emp_Discounts] [decimal](18, 2) NULL, 	[Emp_Discount_Vacation] [decimal](18, 2) NULL, 	[Loan_Value] [decimal](18, 2) NULL, 	[Added_Hours] [decimal](18, 2) NULL, 	[Extra_Value] [decimal](18, 2) NULL, 	[Attendance_Value] [decimal](18, 2) NULL, 	[Special_Subscriptions] [decimal](18, 2) NULL, 	[Subscriptions] [decimal](18, 2) NULL, 	[No_Subscriptions] [decimal](18, 2) NULL, 	[Net_Salary] [decimal](18, 2) NULL, 	[Notes] [nvarchar](1000) NULL,  CONSTRAINT [PK_Pay_Salary] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " Create view [dbo].[New_Report_Daily_Procedure] as SELECT     M.Procedure_Master_ID AS FROM_PROCEDURE_ID, N' من ح/' + M.Daily_Procedure_Name AS FROM_PROCEDURE, M2.Procedure_Master_ID AS TO_PROCEDURE_ID,                        N' الي ح/' + M2.Daily_Procedure_Name AS TO_PROCEDURE, D.Procedure_Date, D.Procedure_Value, D.Procedure_Desc, M.Procedure_Category,                        M2.Procedure_Category AS Procedure_Category2, M.Procedure_Type FROM         dbo.Procedure_Master AS M INNER JOIN                       dbo.Procedure_Details AS D ON M.Procedure_Master_ID = D.From_Procedure_Master_ID INNER JOIN                       dbo.Procedure_Master AS M2 ON M2.Procedure_Master_ID = D.To_Procedure_Master_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " create FUNCTION [dbo].[Is_Cheque_Valid](@CHEQUE_NUMBER NVARCHAR(50)) RETURNS INT AS BEGIN DECLARE @I INT,@CHEQUE_STATUS NVARCHAR(50) SET @I = (SELECT COUNT(*) FROM CHEQUES WHERE CHEQUE_NUMBER = @CHEQUE_NUMBER) IF @I > 0 BEGIN SET @CHEQUE_STATUS = (SELECT CHEQUE_STATUS FROM CHEQUES WHERE CHEQUE_NUMBER = @CHEQUE_NUMBER) 	IF @CHEQUE_STATUS <> N'جديد' 	BEGIN 		SET @I=0 	END 	else 	BEGIN 	SET @I=(SELECT CHEQUE_ID FROM CHEQUES WHERE CHEQUE_NUMBER = @CHEQUE_NUMBER) 	END 		 END RETURN @I END"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Query_Employees_Vacation] AS SELECT     dbo.Employees.Employee_ID, dbo.Employees.Employee_Name, dbo.Employees_Vacations.From_Date, dbo.Employees_Vacations.To_Date FROM         dbo.Employees_Vacations INNER JOIN                       dbo.Employees ON dbo.Employees_Vacations.Employee_ID = dbo.Employees.Employee_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Query_Employees_Tasks] AS SELECT     dbo.Employees_Tasks.Task_Code, dbo.Employees.Employee_Name, dbo.Employees_Tasks.To_Employee, dbo.Employees_Tasks.Title,                        dbo.Employees_Tasks.Task_Desc, dbo.Employees_Tasks.Task_Date, dbo.Employees_Tasks.Approved FROM         dbo.Employees_Tasks INNER JOIN                       dbo.Employees ON dbo.Employees_Tasks.From_Employee = dbo.Employees.Employee_ID"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " CREATE VIEW [dbo].[Query_Employees_Rewards] AS SELECT     dbo.Rewards_Categories.Category_Name, dbo.Employees.Employee_Name, dbo.Employees_Rewards.Reward_Date, dbo.Employees_Rewards.Reason,                        dbo.Employees_Rewards.Reward_Value, dbo.Employees.Employee_ID, dbo.Rewards_Categories.Category_ID FROM         dbo.Employees INNER JOIN                       dbo.Employees_Rewards ON dbo.Employees.Employee_ID = dbo.Employees_Rewards.Employee_ID INNER JOIN                       dbo.Rewards_Categories ON dbo.Employees_Rewards.Category_ID = dbo.Rewards_Categories.Category_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Query_Employees_Discounts] AS SELECT     dbo.Discount_Categories.Category_Name, dbo.Employees.Employee_Name, dbo.Employees_Discounts.Discount_Date, dbo.Employees_Discounts.Reason,                        dbo.Employees_Discounts.Discount_Value, dbo.Employees.Employee_ID, dbo.Discount_Categories.Category_ID FROM         dbo.Discount_Categories INNER JOIN                       dbo.Employees_Discounts ON dbo.Discount_Categories.Category_ID = dbo.Employees_Discounts.Category_ID INNER JOIN                       dbo.Employees ON dbo.Employees_Discounts.Employee_ID = dbo.Employees.Employee_ID"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE VIEW [dbo].[Query_Employees_Attendance] AS SELECT     dbo.Employees.Employee_ID, dbo.Employees.Employee_Name, dbo.Attendance.Attend_Date, dbo.Attendance.Attend_Time, dbo.Attendance.Attend_Type FROM         dbo.Attendance INNER JOIN                       dbo.Employees ON dbo.Attendance.Employee_ID = dbo.Employees.Employee_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Report_Purchase_Order] AS SELECT     dbo.Purchase_Header.Bill_ID, dbo.Purchase_Header.Bill_Date, dbo.Purchase_Header.Bill_Time, dbo.Stocks.Stock_Name, dbo.Vendors.Vendor_Name,                        dbo.Employees.Employee_Name, dbo.Purchase_Header.Total_Bill, dbo.Purchase_Header.Discount_Type, dbo.Purchase_Header.Discount_Value,                        dbo.Purchase_Header.Cash_Value, dbo.Purchase_Header.Credit_Value, dbo.Purchase_Header.Pay_Type, dbo.Purchase_Header.Comments,                        dbo.Purchase_Header.Footer, dbo.Items.Item_Name, dbo.Items.Barcode, dbo.Purchase_Details.Quantity, dbo.Purchase_Details.Price,                        dbo.Purchase_Details.Discount_Type AS Item_Discount, dbo.Purchase_Details.Discount_Value AS Item_Discount_Value, dbo.Purchase_Details.Total_Item FROM         dbo.Purchase_Header INNER JOIN                       dbo.Purchase_Details ON dbo.Purchase_Header.Bill_ID = dbo.Purchase_Details.Bill_ID INNER JOIN                       dbo.Items ON dbo.Purchase_Details.Item_ID = dbo.Items.Item_ID INNER JOIN                       dbo.Vendors ON dbo.Purchase_Header.Vendor_ID = dbo.Vendors.Vendor_ID INNER JOIN                       dbo.Employees ON dbo.Purchase_Header.Employee_ID = dbo.Employees.Employee_ID INNER JOIN                       dbo.Stocks  ON dbo.Purchase_Header.Stock_ID = dbo.Stocks.Stock_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[report_purchase] AS SELECT     dbo.Purchase_Header.Bill_Id, dbo.Purchase_Header.Bill_Time, dbo.Purchase_Header.Bill_Date, dbo.Purchase_Header.Discount_Type,                        dbo.Purchase_Header.Discount_Value, dbo.Purchase_Header.Cash_Value, dbo.Purchase_Header.Credit_Value, dbo.Purchase_Header.Pay_Type,                        dbo.Purchase_Header.Total_Bill, dbo.Stocks.Stock_Name, dbo.Employees.Employee_Name, dbo.Vendors.Vendor_Name,                        dbo.Items.Item_Name + ' ' + dbo.Um_Details.Equivalent_name AS Item_name, dbo.Items.Barcode, dbo.Purchase_Details.Quantity, dbo.Purchase_Details.Price,                        dbo.Purchase_Details.Discount_Type AS Item_Discount_type, dbo.Purchase_Details.Discount_Value AS Item_Discount_Value, dbo.Purchase_Details.Total_Item,                        dbo.Items.Item_Id, dbo.Purchase_Details.Expired_Date, dbo.Purchase_Header.Tax FROM         dbo.Purchase_Header INNER JOIN                       dbo.Purchase_Details ON dbo.Purchase_Header.Bill_Id = dbo.Purchase_Details.Bill_Id INNER JOIN                       dbo.Vendors ON dbo.Purchase_Header.Vendor_Id = dbo.Vendors.Vendor_Id INNER JOIN                       dbo.Stocks ON dbo.Purchase_Header.Stock_Id = dbo.Stocks.Stock_Id INNER JOIN                       dbo.Employees ON dbo.Purchase_Header.Employee_Id = dbo.Employees.Employee_Id INNER JOIN                       dbo.Um_Details ON dbo.Purchase_Details.Um_Detail_Id = dbo.Um_Details.Um_Detail_Id INNER JOIN                       dbo.Items ON dbo.Purchase_Details.Item_Id = dbo.Items.Item_Id"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE view  [dbo].[most_purchase_items]  as select C.category_name,i.item_name ,COUNT(h.bill_id)as total_bill ,sum(d.quantity) total_items,SUM(d.Total_Item) as total_money from Items i ,Purchase_Details d,Purchase_Header h,Categories c where h.Bill_ID=d.Bill_ID and i.Item_ID=d.Item_ID and c.Category_ID=i.Category_ID group by C.category_name,i.Item_Name,d.Price"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "create procedure [dbo].[commit_purchase_header] (@p_bill_id int ,@p_bill_date date ,@p_bill_time NVARCHAR(15),@p_vendor_id int,@p_total_bill decimal(18,2),@p_discount_type nvarchar(50),@P_discount_value decimal(18,2),@p_employee_id int ,@p_cash_value decimal(18,2),@p_credit_value decimal(18,2),@p_pay_type nvarchar(50),@p_comments nvarchar(150),@p_footer nvarchar(100),@p_stock_id int,@p_cheque_id int,@Tax Decimal(5,2))as begin declare @p_Procedure_id int,@Acc_Num nvarchar(50),@Cheque_Ref int,@Acc_ID int,@Vendor_Name nvarchar(50),@Employee_Name nvarchar(50)declare @P_Total_Discount_Value decimal(18,5),@P_Total_Discount_Percent decimal(18,5),@P_Total_Discount decimal(18,5),@T_Tax decimal(18,5)insert into Purchase_Header values(@p_bill_id,@p_bill_date,@p_bill_time,@p_vendor_id,@p_total_bill,@p_discount_type,@P_discount_value,@p_stock_id,@p_employee_id ,@p_cash_value ,@p_credit_value ,@p_comments,@p_pay_type ,@p_footer,@p_cheque_id,@Tax)SET @Employee_Name=(SELECT EMPLOYEE_NAME FROM Employees WHERE Employee_Id = @P_employee_id)SET @Vendor_Name=(SELECT VENDOR_NAME FROM Vendors WHERE Vendor_Id=@p_vendor_id)SET @P_Total_Discount_Percent=(SELECT ISNULL(SUM(QUANTITY*(PRICE*(DISCOUNT_VALUE/100))),0) FROM Purchase_Details WHERE Bill_Id=@p_bill_id AND Discount_Type=N'نسبة مئوية')SET @P_Total_Discount_Value=(SELECT ISNULL(SUM((PRICE-Discount_Value)*QUANTITY),0) FROM Purchase_Details WHERE Bill_Id=@p_bill_id AND Discount_Type=N'مبلغ ثابت')SET @P_Total_Discount=@P_Total_Discount_Percent+@P_Total_Discount_Value IF @P_Total_Discount > 0 BEGIN INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc) VALUES(1,14,@P_Total_Discount,N'خصم كميه من المورد ' + Convert(nvarchar(50),@Vendor_Name) + ' فاتوره رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name) END select @p_Procedure_id=Procedure_Master_ID from Procedure_Master where reference_id =@p_vendor_id and Procedure_Category=N'موردين'IF @P_PAY_TYPE = N'نقدي'BEGIN SET @T_Tax = @p_total_bill*(@tax/(100+@tax))INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc) VALUES(1,@p_Procedure_id,@p_total_bill-@T_Tax,N'فاتورة مشتريات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name) INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc) VALUES(29,@p_Procedure_id,@T_Tax,N'ضرائب مبيعات فاتورة مشتريات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name) INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@p_Procedure_id,4,@P_CASH_VALUE,N'فاتورة مشتريات نقديه رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name)  END  ELSE IF @P_PAY_TYPE = N'اجل' BEGIN SET @T_Tax = @p_total_bill*(@tax/(100+@Tax))INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc) VALUES(1,@p_Procedure_id,@P_CREDIT_VALUE-@T_Tax,N'فاتورة مشتريات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name) INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc) VALUES(29,@p_Procedure_id,@T_Tax,N'ضرائب مبيعات فاتورة مشتريات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name) END ELSE IF @P_PAY_TYPE = N'بشيك'  BEGIN  SET @T_Tax = @p_total_bill*(@tax/(100+@Tax)) INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc) VALUES(1,@p_Procedure_id,@p_total_bill-@T_Tax,N'فاتورة مشتريات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name) INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc) VALUES(29,@p_Procedure_id,@T_Tax,N'ضرائب مبيعات فاتورة مشتريات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name)  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@p_Procedure_id,24,@p_total_bill,N'فاتورة مشتريات بشيك رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name) UPDATE Cheques SET Cheque_Status=N'غير منصرف' WHERE Cheque_ID = @p_cheque_id END ELSE IF @P_PAY_TYPE = N'نقدي و اجل' BEGIN   SET @T_Tax = @p_total_bill*(@tax/(100+@Tax))INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc) VALUES(1,@p_Procedure_id,@p_total_bill-@T_Tax,N'فاتورة مشتريات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name) INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc) VALUES(29,@p_Procedure_id,@T_Tax,N'ضرائب مبيعات فاتورة مشتريات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name) INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc) VALUES(@p_Procedure_id,4,@P_CASH_VALUE,N'فاتورة مشتريات نقديه رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name) END ELSE IF @P_PAY_TYPE = N'شيك و اجل' BEGIN SET @T_Tax = @p_total_bill*(@tax/(100+@tax))INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc) VALUEs (1,@p_Procedure_id,@p_total_bill-@T_Tax,N'فاتورة مشتريات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name) INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc) VALUES(29,@p_Procedure_id,@T_Tax,N'ضرائب مبيعات فاتورة مشتريات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name)  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc) VALUES(@p_Procedure_id,24,@P_CASH_VALUE,N'فاتورة مشتريات بشيك رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name)UPDATE Cheques SET Cheque_Status=N'غير منصرف' WHERE Cheque_ID = @p_cheque_id END end"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Query_Banks_Visa] AS SELECT     dbo.Banks.Bank_Name, dbo.Banks_Accounts.Account_Number, dbo.Visa.Visa_Number, dbo.Visa.Created_Date, dbo.Visa.Visa_Status,                        dbo.Banks_Accounts.Account_ID, dbo.Visa.Visa_ID FROM         dbo.Banks INNER JOIN                       dbo.Banks_Accounts ON dbo.Banks.Bank_ID = dbo.Banks_Accounts.Bank_ID INNER JOIN                       dbo.Visa ON dbo.Banks_Accounts.Account_ID = dbo.Visa.Account_ID"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE VIEW [dbo].[Query_Banks_Accounts] AS SELECT     dbo.Banks.Bank_Name, dbo.Banks_Accounts.Account_Number, dbo.Cheques.Cheque_Number, dbo.Cheques.Received_Date, dbo.Cheques.Payed_Date,                        dbo.Cheques.Cheque_Value, dbo.Cheques.Cheque_Status, dbo.Cheques.Cheque_ID, dbo.Cheques.Direction FROM         dbo.Banks INNER JOIN                       dbo.Banks_Accounts ON dbo.Banks.Bank_ID = dbo.Banks_Accounts.Bank_ID INNER JOIN                       dbo.Cheques ON dbo.Banks_Accounts.Account_ID = dbo.Cheques.Account_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE view [dbo].[Report_trainer_Attendance] as select e.Employee_Name ,a.Attend_Date , a.attend_Time as actually_Attend_Time ,sd.From_Time  , datediff(mi,sd.From_Time ,a.attend_Time) as Time_difference, h.Hall_Name,s.Shift_Name,sd.Shift_Details_Name ,e.Employee_Id ,s.Shift_ID,sd.Shift_Details_ID,h.Hall_ID from Employees e ,Shifts s ,Shifts_details sd,Attendance a,Halls h where e.employee_ID=a.employee_ID and s.Shift_ID =sd.shift_ID and a.hall_ID=h.hall_ID and a.shift_Detail_ID=sd.shift_Details_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[report_pay_salary] AS SELECT     dbo.Departments.Department_Id, dbo.Departments.Department_Name, dbo.Employees.Employee_Id, dbo.Employees.Employee_Name, dbo.Pay_Salary.Pay_Date,                        dbo.Pay_Salary.Basic_Salary AS Salary, dbo.Pay_Salary.Emp_Rewards, dbo.Pay_Salary.Emp_Discounts, dbo.Pay_Salary.Net_Salary, dbo.Pay_Salary.Notes,                        dbo.Pay_Salary.Loan_Value, dbo.Pay_Salary.Emp_Discount_Vacation, dbo.Pay_Salary.Attendance_Value, dbo.Pay_Salary.Special_Subscriptions,                        dbo.Pay_Salary.Extra_Value FROM         dbo.Departments INNER JOIN                       dbo.Employees ON dbo.Departments.Department_Id = dbo.Employees.Department_Id INNER JOIN                       dbo.Pay_Salary ON dbo.Employees.Employee_Id = dbo.Pay_Salary.Employee_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Report_Employees_Vacations] AS SELECT     dbo.Employees.Employee_Id, dbo.Employees.Employee_Name, dbo.Employees_Vacations.From_Date, dbo.Employees_Vacations.To_Date FROM         dbo.Employees INNER JOIN                       dbo.Employees_Vacations ON dbo.Employees.Employee_Id = dbo.Employees_Vacations.Employee_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Report_Employees_Extra] AS SELECT     dbo.Employees.Employee_Id, dbo.Employees.Employee_Name, dbo.Employees_Extra.Extra_Date, dbo.Employees_Extra.Extra_Value,                        dbo.Extra_Categories.Category_ID, dbo.Extra_Categories.Category_Name, dbo.Employees_Extra.Reason FROM         dbo.Employees INNER JOIN                       dbo.Employees_Extra ON dbo.Employees.Employee_Id = dbo.Employees_Extra.Employee_ID INNER JOIN                       dbo.Extra_Categories ON dbo.Employees_Extra.Category_ID = dbo.Extra_Categories.Category_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Report_Employees_Attendance] AS SELECT     dbo.Employees.Employee_Id, dbo.Employees.Employee_Name, dbo.Attendance.Attend_Date, dbo.Attendance.Attend_Time, dbo.Attendance.Attend_Type,                        dbo.Halls.Hall_Name, dbo.Halls.Hall_ID FROM         dbo.Attendance INNER JOIN                       dbo.Employees ON dbo.Attendance.Employee_ID = dbo.Employees.Employee_Id INNER JOIN                       dbo.Halls ON dbo.Attendance.Hall_ID = dbo.Halls.Hall_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE procedure [dbo].[Salary_Loan](@emp as integer) as begin declare @N as decimal(18,2),@b as int ,@F_D as date,@L_D as date,@ID as int ,@Phase_ID int,@Dep_Name nvarchar(50) SELECT @l_d=DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,GETDATE())+1,0)) SELECT @f_D=DATEADD(month, DATEDIFF(month, -1, GETDATE()) - 1, 0) select @N=loan_value from Pay_Salary where Employee_ID=@emp and Pay_Date>@f_d and Pay_Date<@l_D select @ID=procedure_master_id from Procedure_Master where Reference_ID=@emp and Procedure_Category=N'أرصده مدينه'	 select @Dep_Name = d.Generic_Desc from Departments d,Employees e where d.Department_ID=e.Department_ID and e.Employee_ID = @emp if @Dep_Name = N'اداريه' begin insert into procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,procedure_Date,procedure_desc) values(12,@ID,@n,GETDATE(),N'سداد قسط سلفه') end else begin insert into procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,procedure_Date,procedure_desc) values(28,@ID,@n,GETDATE(),N'سداد قسط سلفه') end end"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " Create function [dbo].[CHECK_ATTENDANCE](@employee as int,@attendType as nvarchar(50),@AttendDate as date,@hall as int,@shift as int) returns int as begin declare @ret as int,@n as int if @attendtype=N'حضور' begin select @n=Count(*) from attendance where employee_id=@employee and convert(date,attend_Date,101)=convert(date,@attenddate,101) if @n%2=0 begin set @ret=0 end else begin set @ret=1 end end else begin select @n=Count(*) from attendance where employee_id=@employee and convert(date,attend_Date,101)=convert(date,@attenddate,101) and hall_id=@hall if @n%2=0 begin set @ret=0 end else begin set @ret=1 end end return @ret end "
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE view [dbo].[attend] as SELECT     COUNT(*) AS c, Hall_ID, Employee_ID, Attend_Date FROM         dbo.Attendance GROUP BY Employee_ID, Attend_Date, Hall_ID HAVING      (COUNT(*) % 2 <> 0)"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE PROCEDURE [dbo].[Commit_Dep_item_Header] (@B_ID INT,@B_DATE DATE,@B_TIME TIME ,@B_DESC NVARCHAR(150),@Rest_ID INT,@EMP_ID INT,@Total DECIMAL(18,5),@Dep_Type int, @Partner_Pro_ID INT=0,@Total_Bill DECIMAL(18,5)) AS  BEGIN  declare @Employee_Name Nvarchar(50) SET @Employee_Name=(SELECT EMPLOYEE_NAME FROM Employees WHERE Employee_Id = @emp_id) INSERT INTO Dep_Header VALUES(@B_ID,@B_DATE,@B_TIME,@Rest_ID,@EMP_ID,@B_DESC,@Total_Bill)  IF @Dep_Type=1 BEGIN INSERT INTO Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc)  VALUES(8,7,@Total,GETDATE(),N'اذن اهلاك اصناف رقم ' + Convert(nvarchar(50),@B_ID) + ' - ' + @Employee_Name) END ELSE IF @Dep_Type=2 BEGIN INSERT INTO Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc)  VALUES(19,7,@Total,GETDATE(),N'اذن اهلاك اصناف رقم ' + Convert(nvarchar(50),@B_ID) + ' - ' + @Employee_Name) END ELSE IF @Dep_Type=3 BEGIN INSERT INTO Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc)  VALUES(@Partner_Pro_ID,7,@Total,GETDATE(),N'اذن اهلاك اصناف رقم ' + Convert(nvarchar(50),@B_ID) + ' - ' + @Employee_Name) END END"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " create PROCEDURE [dbo].[Commit_Adjustment_Header] (@B_ID INT,@B_DATE DATE,@B_TIME TIME ,@B_DESC NVARCHAR(150), @F_STK_ID INT,@T_STK_ID INT,@EMP_ID INT) AS BEGIN  INSERT INTO Adjustment_Header  VALUES(@B_ID,@F_STK_ID,@T_STK_ID,@B_DATE,@B_TIME,@B_DESC,@EMP_ID) END"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " create function [dbo].[Check_Pay_Salary] (@p_Emp int ,@p_from_date  date,@p_to_date date) returns bit as begin declare @a bit ,@b int set @b=(select Count (*) from pay_salary where employee_ID = @p_Emp and pay_Date between @p_from_date and @p_to_date) if @b >0 begin set @a =1 end else begin set @a =0 end return @a end"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE procedure [dbo].[commit_return_v_header] (@p_bill_id int,@p_bill_date date,@p_bill_time time,@p_vendor_id int ,@p_total_bill decimal(18,2),@p_employee_id int,@p_comments nvarchar(150),@p_footer nvarchar(100),@p_stock_id int,@P_tax decimal(18,2)) as begin	 declare @p_Procedure_id int,@Vendor_Name nvarchar(50) insert into return_v_header values (@p_bill_id,@p_bill_date,@p_bill_time,@p_vendor_id,@p_employee_id,@p_stock_id, @p_total_bill,@p_comments,@p_footer,@P_tax) if @p_footer=N'نقدي' begin  select @Vendor_Name=Vendor_name from Vendors where Vendor_Id = @p_Vendor_id insert into Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc) values (4,10,@p_total_bill,getdate(),N'مرتجعات نقديه للمورد ' + @Vendor_Name) end else begin select @p_Procedure_id=Procedure_Master_ID from Procedure_Master where reference_id =@p_Vendor_id insert into Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc) values (@p_Procedure_id,10,@p_total_bill,getdate(),N'مرتجعات اجله للمورد ' + @Vendor_Name) end end"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE view [dbo].[Employee_Attendance_Hours] as SELECT     a.Employee_ID, a.Attend_Date, a.Attend_Time, MIN(b.Attend_Time) AS ATTEND_LEAVE, DATEDIFF(mi, a.Attend_Time, MIN(b.Attend_Time)) AS Time_difference FROM         dbo.Attendance AS a INNER JOIN                       dbo.Attendance AS b ON a.Attend_Time < b.Attend_Time AND a.Employee_ID = b.Employee_ID WHERE     a.Attend_Type = N'حضور' and a.Attend_Date=b.Attend_Date GROUP BY a.Attend_Time, a.Attend_Date, a.Employee_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE view [dbo].[Employees_Attend_hours]  as  select employee_id,attend_date,hall_id,DATEDIFF(minute,min(attend_time),MAX(attend_time)) as TotalTime  from Attendance  group by Employee_ID,attend_date,hall_id"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE PROCEDURE [dbo].[EMP_PAYMENTS](@Employee_ID INT,@Basic_Salary DECIMAL(18,5),@variable_Salary Decimal(18,5), @Ex_Subscriptions decimal(18,5),@Emp_Rewards DECIMAL(18,5),@Emp_Discounts DECIMAL(18,5),@Emp_Discount_Vacation DECIMAL(18,5),@Loan_Value DECIMAL(18,5),@Added_Hours decimal(18,5), @Attendance_Value DECIMAL(18,5), @Special_Subscriptions DECIMAL(18,5),@Extra_Value DECIMAL(18,5),@No_Subscriptions decimal(18,2),@Net_Salary DECIMAL(18,5),@Notes NVARCHAR(1000),@subsc decimal(18,5)) AS  BEGIN  INSERT INTO Pay_Salary(Employee_ID,Pay_Date,Basic_Salary,Variable_Salary,Extra_Subscription,Emp_Rewards, Emp_Discounts,Emp_Discount_Vacation,Loan_Value,Added_Hours,Extra_Value,Attendance_Value,Special_Subscriptions, No_Subscriptions,Net_Salary,Notes,subscriptions) VALUES (@Employee_ID,GETDATE(),@Basic_Salary,@Variable_Salary,@Ex_Subscriptions,@Emp_Rewards, @Emp_Discounts,@Emp_Discount_Vacation,@Loan_Value,@Added_Hours,@Extra_Value,@Attendance_Value,@Special_Subscriptions, @No_Subscriptions,@Net_Salary,@Notes,@subsc)  END"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " create FUNCTION [dbo].[Is_Visa_Valid](@VISA_NUMBER NVARCHAR(50)) RETURNS INT AS BEGIN DECLARE @I INT,@Visa_STATUS bit SET @I = (SELECT COUNT(*) FROM Visa WHERE Visa_NUMBER = @Visa_NUMBER) IF @I > 0 BEGIN SET @Visa_STATUS = (SELECT Visa_STATUS FROM Visa WHERE Visa_NUMBER = @Visa_NUMBER) 	IF @Visa_STATUS =0 	BEGIN 		SET @I=0 	END 	else 	BEGIN 	SET @I=(SELECT Visa_ID FROM Visa WHERE Visa_NUMBER = @Visa_NUMBER) 	END 		 END RETURN @I END"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " create FUNCTION [dbo].[Get_Bank_Procedure_ID](@Chq_NO NVARCHAR(50)) RETURNS INT AS BEGIN DECLARE @PRO_ID INT SET @PRO_ID=(SELECT P.PROCEDURE_MASTER_ID FROM PROCEDURE_MASTER P,BANKS_ACCOUNTS B,CHEQUES C WHERE C.CHEQUE_NUMBER=@CHQ_NO AND  C.ACCOUNT_ID=B.ACCOUNT_ID AND B.ACCOUNT_ID = P.REFERENCE_ID AND P.PROCEDURE_CATEGORY = N'بنوك') RETURN @PRO_ID END"
        cmd.ExecuteNonQuery()

        ''    cmd.CommandText = " create function [dbo].[Get_Attendance_Discount](@From Date,@To Date,@Emp INT) Returns Decimal as begin Declare @Disc Decimal,@Disc_Per_Hour decimal,@hours_Exp int,@Actual_hours int select @disc_per_hour=discount_value,@hours_exp=net_Hours from employees where employee_id=@emp select @actual_hours=sum(TotalTime) from Employees_Attend_hours where employee_id=@emp and attend_date between @from and @to set @actual_hours=@actual_hours/60 set @disc= (@Hours_Exp-@actual_hours)*@Disc_Per_Hour return @disc end"
        '''cmd.ExecuteNonQuery()

        cmd.CommandText = " create FUNCTION [dbo].[Check_Max_Discount](@CUST_ID INT,@DIS_VAL DECIMAL(18,0),@TYPE INT) RETURNS BIT   AS BEGIN  DECLARE @B BIT,@MAX_DIS DECIMAL(18,0)  IF @TYPE = 1  BEGIN SET @MAX_DIS = (SELECT L.Max_Discount_Cash FROM Customer_Discount_Level L,CUSTOMERS C WHERE C.DISCOUNT_LEVEL_ID = L.LEVEL_ID AND C.CUSTOMER_ID=@CUST_ID)  END  ELSE BEGIN SET @MAX_DIS = (SELECT L.Max_Discount_Percent FROM Customer_Discount_Level L,CUSTOMERS C WHERE C.DISCOUNT_LEVEL_ID = L.LEVEL_ID AND C.CUSTOMER_ID=@CUST_ID)  END IF @DIS_VAL > @MAX_DIS  BEGIN SET @B=0  END  ELSE  BEGIN  SET @B=1  END  RETURN  @B  END"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " create FUNCTION [dbo].[Check_Credit_Limit](@CUST_ID INT,@CRE DECIMAL(18,0)) RETURNS BIT AS BEGIN  DECLARE @B BIT,@CURR_CRE DECIMAL(18,0),@MAX_CRE DECIMAL(18,0)  SET @CURR_CRE=(SELECT isnull(SUM(PAY_VALUE),0) FROM Customers_Payments WHERE CUSTOMER_ID = @CUST_ID AND Status= N'مجدولة')   SET @MAX_CRE = (SELECT L.Max_Credit_Limit FROM CUSTOMER_LEVELS L ,CUSTOMERS C WHERE C.LEVEL_ID = L.LEVEL_ID AND C.CUSTOMER_ID=@CUST_ID and customer_id = @CUST_ID)   IF @CURR_CRE+@CRE > @MAX_CRE BEGIN SET @B=0 END ELSE BEGIN SET @B=1 END RETURN @B END"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Customers_Orders_Evaluation]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Customer_ID] [int] NULL, 	[Evaluation_Detail_ID] [int] NULL, 	[Grade] [int] NULL, 	[Evaluation_Date] [date] NULL,  CONSTRAINT [PK_Customers_Orders_Evaluation] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[report_sales] AS SELECT     dbo.Sales_Header.Bill_Id, dbo.Sales_Header.Bill_Date, dbo.Sales_Header.Bill_Time, dbo.Sales_Header.Pay_Type, dbo.Sales_Header.Credit_Value,                        dbo.Sales_Header.Cash_Value, dbo.Sales_Header.Discount_Type, dbo.Sales_Header.Discount_Value, dbo.Sales_Header.Total_Bill, dbo.Stocks.Stock_Name,                        dbo.Employees.Employee_Name, dbo.Customers.Customer_Name, dbo.Sales_Details.Trade_Name AS Item_Name, dbo.Sales_Details.Quantity,                        dbo.Sales_Details.Price, dbo.Sales_Details.Discount_Type AS Item_Discount_Type, dbo.Sales_Details.Discount_Value AS Item_Discount_value,                        dbo.Sales_Details.Total_Item, dbo.Sales_Header.Comments, dbo.Sales_Header.Tax FROM         dbo.Sales_Header INNER JOIN                       dbo.Sales_Details ON dbo.Sales_Header.Bill_Id = dbo.Sales_Details.Bill_Id INNER JOIN                       dbo.Employees ON dbo.Sales_Header.Employee_Id = dbo.Employees.Employee_Id INNER JOIN                       dbo.Customers ON dbo.Sales_Header.Customer_Id = dbo.Customers.Customer_Id INNER JOIN                       dbo.Items ON dbo.Sales_Details.Item_Id = dbo.Items.Item_Id INNER JOIN                       dbo.Um_Details ON dbo.Sales_Details.Um_Detail_Id = dbo.Um_Details.Um_Detail_Id INNER JOIN                       dbo.Stocks ON dbo.Sales_Header.Stock_Id = dbo.Stocks.Stock_Id"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE VIEW [dbo].[Most_Sales_One] AS SELECT     I.Item_Name , ISNULL(SUM(D.Total_Item), 0) AS TOTAL_SALES FROM         dbo.Items  AS I INNER JOIN                       dbo.Sales_Details AS D ON I.Item_ID  = D.Item_ID  INNER JOIN                       dbo.Sales_Header AS H ON D.Bill_ID = H.Bill_ID GROUP BY I.Item_Name"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE procedure [dbo].[commit_sales_header] (@P_bill_id int,@P_bill_date date,@P_bill_time nvarchar (15),@P_customer_id int, @P_total_bill decimal(18,2),@P_discount_type nvarchar(50),@P_discount_value decimal(18,2),@P_employee_id int, @P_cash_value decimal(18,2),@P_credit_value decimal (18,2),@P_pay_type nvarchar (30),@p_comments nvarchar(50), @p_footer nvarchar (150),@P_Stock_Id int, @p_cheque_id int,@p_visa_id int,@Tax Decimal(5,2))  as  begin  declare @p_Procedure_id int,@Acc_Num nvarchar(50),@Cheque_Ref int,@Acc_ID int,@Visa_Ref int,@Customer_Name nvarchar(50),@T_Tax decimal(18,5) declare @Visit_ID int,@P_Total_Discount_Value decimal(18,5),@P_Total_Discount_Percent decimal(18,5),@P_Total_Discount decimal(18,5),@Employee_Name Nvarchar(50) declare @T_Sales decimal(18,5) SET @T_Tax = (@p_total_bill/(100+@Tax))*100 SET @T_Sales = @T_Tax * @Tax set @visit_id=(select isnull(emp_reference_id,0) from Stocks where Stock_ID = @P_Stock_Id)    insert into Sales_Header values(@P_bill_id ,@P_bill_date ,@P_bill_time ,@P_customer_id ,@P_employee_id , @P_total_bill,@P_Stock_id ,@P_discount_type ,@P_discount_value,@P_cash_value,@P_credit_value , @P_pay_type ,@p_comments ,@p_footer ,@p_cheque_id,@p_visa_id,@Tax) SET @Employee_Name=(SELECT EMPLOYEE_NAME FROM Employees WHERE Employee_Id = @P_employee_id) SET @Customer_Name=(SELECT Customer_NAME FROM Customers WHERE Customer_Id=@p_Customer_id) SET @P_Total_Discount_Percent=(SELECT ISNULL(SUM(QUANTITY*(PRICE*(DISCOUNT_VALUE/100))),0) FROM Sales_Details WHERE Bill_Id=@p_bill_id AND Discount_Type=N'نسبة مئوية') SET @P_Total_Discount_Value=(SELECT ISNULL(SUM((PRICE-Discount_Value)*QUANTITY),0) FROM Sales_Details WHERE Bill_Id=@p_bill_id AND Discount_Type=N'مبلغ ثابت') SET @P_Total_Discount=@P_Total_Discount_Percent+@P_Total_Discount_Value  select @p_Procedure_id=Procedure_Master_ID from Procedure_Master where reference_id =@P_customer_id and Procedure_Category=N'عملاء' IF @P_PAY_TYPE = N'نقدي'  BEGIN  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@p_Procedure_id,7,@T_Tax,N'فاتورة مبيعات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name)  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(4,@p_Procedure_id,@P_CASH_VALUE,N'فاتورة مبيعات نقديه رقم ' + Convert(nvarchar(50),@p_bill_id)  + ' - ' + @Employee_Name) END  ELSE IF @P_PAY_TYPE = N'اجل'  BEGIN  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@p_Procedure_id,7,@T_Tax,N'فاتورة مبيعات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name)  END  ELSE IF @P_PAY_TYPE = N'بشيك'  BEGIN  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@p_Procedure_id,7,@T_Tax,N'فاتورة مبيعات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name)  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(23,@p_Procedure_id,@P_CASH_VALUE,N'فاتورة مبيعات بشيك رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name)  UPDATE Cheques SET Cheque_Status=N'غير محصل' WHERE Cheque_ID = @p_cheque_id END  ELSE IF @P_PAY_TYPE = N'نقدي و اجل'  BEGIN  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@p_Procedure_id,7,@T_Tax,N'فاتورة مبيعات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name)  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(4,@p_Procedure_id,@P_CASH_VALUE,N'فاتورة مبيعات نقديه رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name)  END  ELSE IF @P_PAY_TYPE = N'شيك و اجل'  BEGIN  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@p_Procedure_id,7,@T_Tax,N'فاتورة مبيعات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name)  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(23,@p_Procedure_id,@P_CASH_VALUE,N'فاتورة مبيعات بشيك رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name) UPDATE Cheques SET Cheque_Status=N'غير محصل' WHERE Cheque_ID = @p_cheque_id END  ELSE IF @P_PAY_TYPE = N'فيزا'  BEGIN  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@p_Procedure_id,7,@T_Tax,N'فاتورة مبيعات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name)  select @Visa_Ref=Procedure_Master_ID from Procedure_Master where reference_id =@p_visa_id and Procedure_Category=N'فيزا' INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@Visa_Ref,@p_Procedure_id,@P_CASH_VALUE,N'فاتورة مبيعات فيزا رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name) END  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@p_Procedure_id,29,@T_Sales,N'ضرائب مبيعات علي فاتورة مبيعات اجل رقم ' + Convert(nvarchar(50),@p_bill_id) + ' - ' + @Employee_Name)  end"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE VIEW [dbo].[report_customers_returns] AS SELECT     dbo.Return_C_Header.Bill_ID, dbo.Return_C_Header.Bill_Date, dbo.Return_C_Header.Bill_Time, dbo.Customers.Customer_Name, dbo.Employees.Employee_Name,                        dbo.Stocks.Stock_Name, dbo.Return_C_Header.Total_Bill, dbo.Return_C_Header.Footer,                        dbo.Items.Item_Name + '  ' + dbo.Um_Details.Equivalent_name AS Item_name, dbo.Return_C_Header.Comments, dbo.Return_C_Details.Quantity,                        dbo.Return_C_Details.Price, dbo.Return_C_Details.Total_Item, dbo.Items.Item_Id, dbo.Return_C_Header.Tax FROM         dbo.Return_C_Header INNER JOIN                       dbo.Return_C_Details ON dbo.Return_C_Header.Bill_ID = dbo.Return_C_Details.Bill_ID INNER JOIN                       dbo.Items ON dbo.Return_C_Details.Item_ID = dbo.Items.Item_Id INNER JOIN                       dbo.Customers ON dbo.Return_C_Header.Customer_ID = dbo.Customers.Customer_Id INNER JOIN                       dbo.Employees ON dbo.Return_C_Header.Employee_ID = dbo.Employees.Employee_Id INNER JOIN                       dbo.Um_Details ON dbo.Return_C_Details.Um_Detail_ID = dbo.Um_Details.Um_Detail_Id INNER JOIN                       dbo.Stocks ON dbo.Return_C_Header.Stock_ID = dbo.Stocks.Stock_Id"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Query_Customers] AS SELECT     dbo.Customers.Customer_Name, dbo.Customers.Address, dbo.Customers.Mobile, dbo.Customers.Tele, dbo.Customers.Email, dbo.Customers.Personal_ID,                        dbo.Jobs.Job_Title, dbo.Locations.Location_Name, dbo.Locations.Location_ID, dbo.Jobs.Job_ID, dbo.Customers.Age FROM         dbo.Customers INNER JOIN                       dbo.Jobs ON dbo.Customers.Job_ID = dbo.Jobs.Job_ID INNER JOIN                       dbo.Locations ON dbo.Customers.Location_ID = dbo.Locations.Location_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Special_Subscriptions]( 	[Special_Subscription_ID] [int] IDENTITY(1,1) NOT NULL, 	[Trainer_ID] [int] NULL, 	[Customer_ID] [int] NULL, 	[Value] [decimal](18, 2) NULL, 	[Percentage] [decimal](18, 2) NULL, 	[Special_Subscription_Date] [date] NULL, 	[Special_Categories_ID] [int] NULL,  CONSTRAINT [PK_Special_Subscriptions] PRIMARY KEY CLUSTERED  ( 	[Special_Subscription_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Subscriptions_Details]( 	[Subscription_Detail_ID] [int] IDENTITY(1,1) NOT NULL, 	[Customer_ID] [int] NULL, 	[Subscription_ID] [int] NULL, 	[Subscription_Type] [nvarchar](50) NULL, 	[Employee_id] [int] NULL, 	[Paid] [decimal](18, 2) NULL, 	[No_Subscriptions] [int] NULL, 	[No_Training] [int] NULL, 	[Remaining] [decimal](18, 2) NULL, 	[From_Time] [nvarchar](50) NULL, 	[To_Time] [nvarchar](50) NULL, 	[Start_Date] [date] NULL, 	[End_Date] [date] NULL, 	[Subscription_Status] [nvarchar](50) NULL, 	[Coach_ID] [int] NULL,  CONSTRAINT [PK_Subscriptions_Details] PRIMARY KEY CLUSTERED  ( 	[Subscription_Detail_ID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " create TRIGGER [dbo].[TRIG_Cust_ID_birth_Date_upd] ON [dbo].[Customers]  after update  AS  BEGIN  if update(birth_Date) begin DECLARE @CUST_ID INT,@CUST_NAME NVARCHAR(50) ,@birth_date date,@code nvarchar(50),@curr int,@cu as integer SET @CUST_ID=(SELECT CUSTOMER_ID FROM INSERTED)  SET @CUST_NAME=(SELECT CUSTOMER_NAME FROM INSERTED)  INSERT INTO PROCEDURE_MASTER(Daily_Procedure_Name,Reference_ID,Balance,Procedure_Category,Procedure_Type)  VALUES(N'حساب عملاء - ' + @CUST_NAME,@CUST_ID,0,N'عملاء',N'مدين') set @birth_date=(select Birth_Date from inserted) set @curr=(select max(curr_Val) from seq_table where seq_ID =15 ) select @cu=customer_id from inserted update seq_Table  set curr_val=@curr+1 where seq_ID=15 set @code= convert(nvarchar,@curr)+substring (convert(nvarchar(20),@birth_date,103),1,2)+ substring (convert(nvarchar(20),@birth_date,101),1,2)+substring (convert(nvarchar(20),@birth_date,103),7,11) update customers set customer_code=@code where customer_id=@cu end END;"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TRIGGER [dbo].[TRIG_Cust_ID] ON [dbo].[Customers]  AFTER INSERT  AS   BEGIN   DECLARE @CUST_ID INT,@CUST_NAME NVARCHAR(50) ,@birth_date date,@code nvarchar(50),@curr int,@cu as integer SET @CUST_ID=(SELECT CUSTOMER_ID FROM INSERTED)  SET @CUST_NAME=(SELECT CUSTOMER_NAME FROM INSERTED)  INSERT INTO PROCEDURE_MASTER(Daily_Procedure_Name,Reference_ID,Balance,Procedure_Category,Procedure_Type)  VALUES(N'حساب عملاء - ' + @CUST_NAME,@CUST_ID,0,N'عملاء',N'مدين') set @birth_date=(select Birth_Date from inserted) set @curr=(select max(curr_Val) from seq_table where seq_ID =15 ) select @cu=customer_id from inserted update seq_Table  set curr_val=@curr+1 where seq_ID=15 set @code= convert(nvarchar,@curr)+substring (convert(nvarchar(20),@birth_date,103),1,2)+ substring (convert(nvarchar(20),@birth_date,101),1,2)+substring (convert(nvarchar(20),@birth_date,103),7,11) update customers set customer_code=@code where customer_id=@cu END;"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE trigger [dbo].[update_subscription]   on [dbo].[Subscriptions_Details] after update  as if update(No_Training)   begin declare @notraining nvarchar(50), @sub_id int,@cust_id int select @sub_id=subscription_id ,@cust_id=customer_id from inserted  update Subscriptions_Details set Subscription_Status=N'مفتوحه' where customer_id=@cust_id and subscription_id=@sub_id end"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE trigger [dbo].[Trig_Special_Sub] on [dbo].[Special_Subscriptions] after insert as begin declare @Paid as decimal(18,2),@Ref as int,@PM_ID as int,@p_Procedure_id as int,@cust_ID as int select @paid = value,@ref=special_categories_ID,@cust_id=customer_id from inserted select @p_Procedure_id=Procedure_Master_ID  from Procedure_Master  where reference_id =@cust_id  and Procedure_Category=N'عملاء' select @pm_id=procedure_master_id from procedure_master where reference_id=@ref and procedure_category=N'ايرادات متنوعه' INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@p_Procedure_id,@pm_id,@paid,N'قيمة اشتراك نقدي')  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(4,@p_Procedure_id,@paid,N'قيمة اشتراك نقدي') end"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " create view [dbo].[most_count_subscription] as select  count(ds.Subscription_ID) as ss ,s.Subscription_Name from Subscriptions_Details ds ,Subscriptions s where ds.Subscription_ID=s.Subscription_ID group by s.Subscription_Name"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE VIEW [dbo].[Report_Subscriptions_Details] AS SELECT     dbo.Customers.Customer_Name, dbo.Customers.Customer_Id, dbo.Subscriptions.Subscription_Name, dbo.Subscriptions.Subscription_ID,                        dbo.Employees.Employee_Name, dbo.Subscriptions_Details.Start_Date, dbo.Subscriptions_Details.End_Date, dbo.Subscriptions_Details.Subscription_Status,                        dbo.Subscriptions_Categories.Category_Name, dbo.Subscriptions_Categories.Category_ID FROM         dbo.Subscriptions INNER JOIN                       dbo.Subscriptions_Details ON dbo.Subscriptions.Subscription_ID = dbo.Subscriptions_Details.Subscription_ID INNER JOIN                       dbo.Customers ON dbo.Subscriptions_Details.Customer_ID = dbo.Customers.Customer_Id INNER JOIN                       dbo.Employees ON dbo.Subscriptions_Details.COACH_ID = dbo.Employees.Employee_Id INNER JOIN                       dbo.Subscriptions_Categories ON dbo.Subscriptions.Category_ID = dbo.Subscriptions_Categories.Category_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE view [dbo].[Report_count_subscriptions] as select d.Category_Name,d.Category_ID,s.Subscription_ID,s.Subscription_Name,COUNT(ds.Customer_ID) as cstomer_count,ds.Start_Date,ds.End_Date from subscriptions s,subscriptions_categories d,subscriptions_details ds where d.Category_ID=s.Category_ID and ds.Subscription_ID=s.Subscription_ID group by d.Category_Name,d.Category_ID,s.Subscription_ID,s.Subscription_Name,ds.Start_Date,ds.End_Date"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " create view [dbo].[report_count_special_subscriptions] as select COUNT(sp.customer_id) as count_customer ,s.Special_Categories_ID as Subscription_ID ,s.Category_Name as Subscription_Name,sp.Special_Subscription_Date from Special_Subscriptions sp ,dbo.Special_Categories s where s.Special_Categories_ID=sp.Special_Categories_ID group by s.Special_Categories_ID ,s.Category_Name,sp.Special_Subscription_Date"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE view [dbo].[Report_Subscription_Print] as SELECT     dbo.Subscriptions_Details.Subscription_Detail_ID, dbo.Customers.Customer_Name, dbo.Subscriptions_Categories.Category_Name,                        dbo.Subscriptions.Subscription_Name, dbo.Employees.Employee_Name AS Coach, dbo.Subscriptions_Details.No_Subscriptions,                        dbo.Subscriptions_Details.No_Training, dbo.Subscriptions_Details.Paid, dbo.Subscriptions_Details.Remaining, Employees_1.Employee_Name AS Emp,                        dbo.Subscriptions_Details.Start_Date, dbo.Subscriptions_Details.End_Date, dbo.Subscriptions_Details.Subscription_Status, dbo.Subscriptions_Details.Coach_ID,                        dbo.Subscriptions_Details.Subscription_Type, dbo.Customers.Birth_Date, dbo.Customers.Tele, dbo.Customers.Email, dbo.Customers.Age,                        dbo.Companies.Company_Name, dbo.Jobs.Job_Title, dbo.Locations.Location_Name, dbo.Locations.Street_Address FROM         dbo.Subscriptions_Details INNER JOIN                       dbo.Customers ON dbo.Subscriptions_Details.Customer_ID = dbo.Customers.Customer_Id FULL OUTER JOIN                       dbo.Employees ON dbo.Subscriptions_Details.Coach_ID = dbo.Employees.Employee_Id INNER JOIN                       dbo.Employees AS Employees_1 ON dbo.Subscriptions_Details.Employee_id = Employees_1.Employee_Id INNER JOIN                       dbo.Subscriptions ON dbo.Subscriptions_Details.Subscription_ID = dbo.Subscriptions.Subscription_ID INNER JOIN                       dbo.Subscriptions_Categories ON dbo.Subscriptions.Category_ID = dbo.Subscriptions_Categories.Category_ID FULL OUTER JOIN                       dbo.Companies ON dbo.Customers.Company_ID = dbo.Companies.Company_ID FULL OUTER JOIN                       dbo.Jobs ON dbo.Customers.Job_ID = dbo.Jobs.Job_Id AND dbo.Employees.Job_Id = dbo.Jobs.Job_Id AND Employees_1.Job_Id = dbo.Jobs.Job_Id INNER JOIN                       dbo.Locations ON dbo.Customers.Location_ID = dbo.Locations.Location_ID"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE FUNCTION [dbo].[CHECK_SUBSCRIPTION_DATE] (@P_SUBSCRIPTION_ID INT ,@P_CUSTOMER_ID INT) RETURNS BIT AS BEGIN  DECLARE @DATE DATE,@B BIT  SET @DATE= ( SELECT END_DATE from Subscriptions_Details where subscription_ID=@P_SUBSCRIPTION_ID and Customer_ID=@P_CUSTOMER_ID and subscription_status = N'مفتوحه')   IF @DATE > GETDATE() BEGIN SET @B=1 END ELSE BEGIN SET @B=0 END RETURN @B END"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE function [dbo].[Is_Subscription_Exit] (@p_Subscription_Id int ,@p_Customer_Id int) returns bit begin declare @no int,@aa bit select @no=(Select count (*) from subscriptions_details where Customer_id=@p_Customer_Id and Subscription_Id=@p_Subscription_Id and subscription_status=N'مفتوحه') if @no > 0 begin set @aa=1 end else begin set @aa=0 end return @aa end"
        cmd.ExecuteNonQuery()

        ''     cmd.CommandText = " create FUNCTION [dbo].[Is_Master_Num_Exists](@MASTER_NO INT,@CHECK_TYPE INT) RETURNS INT AS BEGIN DECLARE @B INT,@COUNT INT set @B=3 IF @CHECK_TYPE = 1 BEGIN 	SET @COUNT = (SELECT COUNT(*) FROM REQUESTS_HEADER WHERE MASTER_NO = @MASTER_NO) 		IF @COUNT>=1 		BEGIN 			SET @B=1 		END 		 END ELSE IF @CHECK_TYPE = 2 BEGIN 	SET @COUNT = (SELECT COUNT(*) FROM SALES_OFFER_HEADER WHERE MASTER_NO = @MASTER_NO) 		IF @COUNT>=1 		BEGIN 			SET @B=1 		END 	SET @COUNT = (SELECT COUNT(*) FROM REQUESTS_HEADER WHERE MASTER_NO = @MASTER_NO) 	BEGIN 		SET @B = 0 	END END ELSE IF @CHECK_TYPE = 3 BEGIN 	SET @COUNT = (SELECT COUNT(*) FROM SALES_HEADER WHERE MASTER_NO = @MASTER_NO) 		IF @COUNT>=1 		BEGIN 			SET @B=1 		END 	SET @COUNT = (SELECT COUNT(*) FROM SALES_OFFER_HEADER WHERE MASTER_NO = @MASTER_NO) 	BEGIN 		SET @B = 0 	END END RETURN @B END"
        ''   cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE FUNCTION [dbo].[Get_Special_Sub_Value](@TRAINER_ID INT,@FROM_DATE DATE,@TO_DATE DATE) RETURNS DECIMAL(18,2) AS BEGIN DECLARE @TOTAL DECIMAL(18,2) SELECT @TOTAL=isnull(SUM(VALUE*percentage/100),0)  FROM dbo.Special_Subscriptions  WHERE TRAINER_ID = @TRAINER_ID AND  Special_Subscription_Date BETWEEN @FROM_DATE AND @TO_DATE RETURN @TOTAL END"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE trigger [dbo].[insert_Pro_Details] on [dbo].[Subscriptions_Details] after insert as begin declare @COMPANY_ID INT,@Paid as decimal(18,2),@Remaining as decimal(18,2),@Ref as int,@PM_ID as int,@p_Procedure_id as int,@Money as decimal(18,2),@cust_ID as int select @paid=paid,@remaining=remaining,@ref=Subscription_ID,@money=(paid+remaining),@cust_id=customer_id from inserted  SELECT @COMPANY_ID = COMPANY_ID FROM CUSTOMERS WHERE CUSTOMER_ID = @cust_id IF @COMPANY_ID > 0 BEGIN select @p_Procedure_id=Procedure_Master_ID  from Procedure_Master where reference_id =@COMPANY_ID and Procedure_Category=N'عملاء' END ELSE BEGIN select @p_Procedure_id=Procedure_Master_ID  from Procedure_Master where reference_id =@cust_id and Procedure_Category=N'عملاء' END  select @pm_id=procedure_master_id from procedure_master where reference_id=@ref and procedure_category=N'ايرادات متنوعه' if @remaining=0 begin INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@p_Procedure_id,@pm_id,@money,N'قيمة اشتراك آجل')  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(4,@p_Procedure_id,@money,N'قيمة اشتراك نقدي') end else if @paid=0 begin INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@p_Procedure_id,@pm_id,@remaining,N'قيمة اشتراك آجل')  end else if @remaining>0 and @paid>0 begin INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(@p_Procedure_id,@pm_id,@money,N'قيمة اشتراك نقدي و آجل')  INSERT INTO PROCEDURE_DETAILS(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Desc)  VALUES(4,@p_Procedure_id,@paid,N'قيمة اشتراك نقدي و آجل')  end end"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE VIEW [dbo].[Alert_subscriptions_Expired_Date] AS SELECT dbo.Customers.Customer_Name, dbo.Subscriptions.Subscription_Name, dbo.Subscriptions_Categories.Category_Name, dbo.Subscriptions_Details.End_Date FROM dbo.Subscriptions_Categories INNER JOIN dbo.Subscriptions ON dbo.Subscriptions_Categories.Category_ID = dbo.Subscriptions.Category_ID INNER JOIN dbo.Subscriptions_Details ON dbo.Subscriptions.Subscription_ID = dbo.Subscriptions_Details.Subscription_ID INNER JOIN dbo.Customers ON dbo.Subscriptions_Details.Customer_ID = dbo.Customers.Customer_Id"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE procedure [dbo].[commit_return_c_header] (@p_bill_id int,@p_bill_date date,@p_bill_time time,@p_customer_id int ,@p_total_bill decimal(18,2),@p_employee_id int,@p_comments nvarchar(150),@p_footer nvarchar(100),@p_stock_id int,@P_tax decimal(18,2)) as begin	 declare @p_Procedure_id int,@Customer_Name nvarchar(50) insert into return_c_header values (@p_bill_id,@p_bill_date,@p_bill_time,@p_customer_id,@p_employee_id,@p_stock_id, @p_total_bill,@p_comments,@p_footer,@P_tax) if @p_footer=N'نقدي' begin  select @Customer_Name=customer_name from Customers where Customer_Id = @p_customer_id insert into Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc) values (11,4,@p_total_bill,getdate(),N'مرتجعات نقديه للعميل ' + @Customer_Name) end else begin select @p_Procedure_id=Procedure_Master_ID from Procedure_Master where reference_id =@p_customer_id insert into Procedure_Details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date,Procedure_Desc) values (11,@p_Procedure_id,@p_total_bill,getdate(),N'مرتجعات اجله للعميل ' + @Customer_Name)  end end"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE TABLE [dbo].[Customers_Attendance]( 	[Serial_PK] [int] IDENTITY(1,1) NOT NULL, 	[Customer_ID] [int] NULL, 	[Attend_Date] [date] NULL, 	[Attend_Time] [nvarchar](50) NULL, 	[Subscription_ID] [int] NULL, 	[Hall_ID] [int] NULL, 	[Coach_ID] [int] NULL,  CONSTRAINT [PK_Customers_Attendance] PRIMARY KEY CLUSTERED  ( 	[Serial_PK] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " create view [dbo].[Alert_Customer_Expired_Date] as select C.customer_name,s.Subscription_Name,d.End_Date,c.Customer_ID from Subscriptions_Details d ,customers c ,Subscriptions s where c.Customer_Id=d.Customer_ID and s.Subscription_ID=d.Subscription_ID"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE trigger [dbo].[Check_Subscroption_Privilige] on [dbo].[Customers_Attendance]  after insert as begin declare  @count int,@cust_ID int,@subscription_ID int,@no_training int,@m as integer,@b as integer select @m=hall_id from inserted select @b=employee_id from attend  where Hall_ID=@m and attend_Date = (select attend_date from inserted) update Customers_Attendance set Coach_ID=@b where serial_pk=(select max(serial_pk) from customers_attendance) set @cust_ID =(select Customer_ID from inserted ) set @subscription_ID =(select subscription_ID from inserted ) set @count=(select Count(*) from Customers_Attendance where subscription_ID=@subscription_ID and Customer_ID=@cust_ID ) set @no_training=(select No_Training from Subscriptions_Details where subscription_ID=@subscription_ID and Customer_ID=@cust_ID and Subscription_Status=N'مفتوحه' ) if @count=@no_training begin update subscriptions_Details set Subscription_Status=N'مغلقه' where subscription_ID=@subscription_ID and Customer_ID=@cust_ID end end"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " create function [dbo].[CHECK_Customers_ATTENDANCE](@Customer as int,@AttendDate as date,@hall as int,@subscription_ID as int) returns int as begin declare @ret as int,@n as int set @n=(select Count(*) from Customers_attendance where Customer_ID=@Customer and attend_Date=@attenddate and hall_Id=@hall and subscription_ID=@subscription_ID) if @n>0 begin set @ret=1 end  else begin set @ret=0 end return @n end"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE view [dbo].[Alert_subscription] as select  distinct c.customer_NAme, s.Subscription_Name,sc.Category_Name from Customers c ,Subscriptions s ,Subscriptions_Categories sc  where 1 < = (select COUNT (*) from Customers_Attendance d  where c.Customer_Id=d.Customer_ID and s.Subscription_ID=d.Subscription_ID)"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE view [dbo].[alert_no_attend] as select C.customer_name,s.Subscription_Name,d.No_Training-COUNT(a.customer_id) as count_cust,c.Customer_Id from customers_attendance a ,customers c ,Subscriptions s,subscriptions_details d where c.Customer_Id=a.Customer_ID and s.Subscription_ID=a.Subscription_ID and d.Customer_ID=c.Customer_Id and d.Subscription_ID=s.Subscription_ID group by C.customer_name,s.Subscription_Name,c.Customer_Id,d.No_Training"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE trigger [dbo].[Insert_Coach_ID]   on [dbo].[Customers_Attendance] after insert as begin declare @m as integer,@b as integer select @m=hall_id from inserted select @b=employee_id from attend  where Hall_ID=@m and attend_Date=getdate() update Customers_Attendance set Coach_ID=@b where Coach_ID=NULL end"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE view [dbo].[Get_No_Cust_Attendance] as select a.Employee_id,c.attend_Date,COUNT(c.customer_id) as total_custs from employees a,Customers_Attendance c where c.coach_id=a.Employee_id group by a.Employee_ID,c.attend_Date"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE view [dbo].[Report_Trainer_Sal1] as  select e.Employee_Name,t.No_Customers,COUNT(ca.Customer_ID) as no_Cust_Attendd ,s.Subscription_Name,ca.Attend_Date,e.Basic_Salary, E.Variable_Salary ,e.Employee_Id,s.Subscription_ID from Employees e,Customers_Attendance ca,Attendance a ,Trainers_Details t,Subscriptions s ,Halls h  where e.Employee_Id=t.Trainer_ID  and h.Hall_ID=a.Hall_ID and h.Hall_ID=ca.Hall_ID and t.Subscription_ID=s.Subscription_ID and s.Subscription_ID=ca.Subscription_ID group by e.Employee_Name,t.No_Customers,s.Subscription_Name,ca.Attend_Date, e.Employee_Id,s.Subscription_ID,e.Basic_Salary, E.Variable_Salary"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " Create VIEW [dbo].[Report_Customers_Attendance] AS SELECT     dbo.Customers.Customer_Name, dbo.Customers.Customer_Code, dbo.Customers_Attendance.Attend_Date, dbo.Customers_Attendance.Attend_Time,dbo.Subscriptions.Subscription_Name, dbo.Halls.Hall_Name, dbo.Employees.Employee_Name, dbo.Employees.Employee_Id, dbo.Subscriptions.Subscription_ID,dbo.Halls.Hall_ID, dbo.Subscriptions_Categories.Category_Name, dbo.Subscriptions_Categories.Category_ID, dbo.Customers.Customer_Id FROM dbo.Customers INNER JOIN dbo.Customers_Attendance ON dbo.Customers.Customer_Id = dbo.Customers_Attendance.Customer_ID INNER JOIN dbo.Employees ON dbo.Customers_Attendance.Customer_ID = dbo.Employees.Employee_Id INNER JOIN dbo.Subscriptions ON dbo.Customers_Attendance.Subscription_ID = dbo.Subscriptions.Subscription_ID INNER JOIN dbo.Halls ON dbo.Customers_Attendance.Hall_ID = dbo.Halls.Hall_ID INNER JOIN dbo.Subscriptions_Categories ON dbo.Subscriptions.Category_ID = dbo.Subscriptions_Categories.Category_ID "
        cmd.ExecuteNonQuery()

        cmd.CommandText = " create view [dbo].[most_count_halls] as select h.Hall_ID,h.Hall_Name,COUNT(c.Customer_ID) as cstomer_count,c.attend_date from Customers_Attendance c,Halls h where c.Hall_ID=h.Hall_ID group by h.Hall_ID,h.Hall_Name,c.attend_date"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " create view [dbo].[most_no_cust_to_trainer] as select e.Employee_Name,COUNT(ca.Customer_ID) as vv,s.Subscription_ID,s.Subscription_Name ,ca.Attend_Date,e.Employee_Id from Employees e ,Subscriptions s,Customers_Attendance ca where e.Employee_Id=ca.coach_id and ca.Subscription_ID=s.Subscription_ID group by e.Employee_Name,s.Subscription_ID,s.Subscription_Name ,ca.Attend_Date,e.Employee_Id"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " CREATE function [dbo].[Get_Employee_Salary](@emp as integer,@TheMonth date,@type as nvarchar(30)) returns decimal(18,2) as begin  declare @Subsc as decimal(18,2),@return as decimal(18,2),@from_D as date,@to_D as date,@inner_vac as decimal(18,2),@early_vac as decimal(18,2),@late_vac as decimal(18,2),@basic_salary as decimal(18,2),@Total_Custs as decimal(18,2),@total_Work_Hours as decimal(18,2),@Final_Salary as decimal(18,5),@Min_H as decimal(18,2),@Work_H as decimal(18,2),@Extra_H as decimal(18,2),@Less_H as decimal(18,2),@Min_cust as decimal(18,2),@Extra_Cust as decimal(18,2),@Less_Cust as decimal(18,6),@Extra_Subsc as decimal(18,2) SELECT @from_D=CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@themonth)-1),@themonth),101) select @to_D=CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@themonth))),DATEADD(mm,1,@themonth)),101) select @min_h=min_hours,@work_h=work_hours,@extra_h=extra_hours,@less_h=less_hours,@min_Cust=min_customers,@extra_cust=extra_customers,@less_cust=less_Customers,@Extra_Subsc=extra_subsc from app_preferences select @inner_Vac=isnull(sum(DATEDIFF(DAY,from_Date,to_date))*6,0) from employees_vacations where employee_id=@emp and From_Date>=@from_d and To_Date<=@to_d select @early_vac=isnull(sum(datediff(day,@from_D,to_date))*6,0) from employees_vacations where employee_id=@emp and From_Date<@from_d and To_Date<=@to_d and to_Date>=@from_d select @late_vac=isnull((sum((DATEDIFF(DAY,from_Date,@to_d)))+1)*6,0) from employees_vacations where employee_id=@emp and From_Date>=@from_d and To_Date>@to_d and from_Date<=@to_d select @total_Work_Hours=((sum(Time_difference))/60)+@inner_vac+@early_vac+@late_vac from Employee_Attendance_Hours where employee_id=@emp  and attend_date>=@from_d and attend_Date<=@to_d select @final_salary=variable_salary,@basic_salary=basic_Salary   from employees where employee_id=@emp select @total_custs=sum(total_Custs) from get_no_cust_attendance where employee_id=@emp and attend_date>=@from_d and attend_Date<=@to_d if @total_Work_Hours<=@min_h begin set @final_salary=@final_salary-((@min_h-@total_Work_Hours)*@less_h) end else if @total_Work_Hours>=@work_h begin set @final_salary=@final_Salary+((@total_Work_Hours-@work_H)*@extra_h) end if @total_custs<=@min_cust begin set @final_salary=@final_salary-((@min_cust-@total_Custs)*@less_cust) end else  begin set @final_salary=@final_salary+((@total_Custs-@min_cust)*@extra_cust) end select @subsc=isnull((sum(paid+remaining)*@extra_subsc)/100,0) from subscriptions_Details where coach_id=@emp and Subscription_Type=N'خاص' and start_date>=@from_d and start_date<=@to_d if @final_salary is null or @total_work_hours is null begin set @final_salary=0 end set @final_salary=@final_salary+@basic_Salary if @type='final_salary' begin set @return=@final_salary end else if @type='subscriptions' begin set @return=@subsc end else if @type='attend_discounts' begin if @total_work_hours<=@min_h  begin set @return=((@min_h-@total_Work_Hours)*@less_h) end else begin set @return=0 end end else if @type='attend_percent' begin if @total_work_hours<=@min_h begin set @return=(@total_Work_Hours/@min_h)*100 end else if @total_work_hours between @min_h and @work_h begin set @return=100 end else begin set @return=(@total_Work_Hours/@work_h)*100 end end else if @type='no_custs' begin set @return=@total_Custs if @return is null begin set @return=0 end end else if @type='attend_rewards' begin if @total_Work_Hours>=@work_h begin set @return=((@total_Work_Hours-@work_H)*@extra_h) end else begin set @return=0 end end else if @type='custs_cash' begin if @total_custs<=@min_cust begin set @return=-((@min_cust-@total_Custs)*@less_cust) end else  begin set @return=((@total_Custs-@min_cust)*@extra_cust) end if @return is null begin set @return=0 end end if @return is null  begin set @return=0 end  return @return end"
        cmd.ExecuteNonQuery()

        cmd.CommandText = " CREATE function [dbo].[GEt_Net_Salary] (@p_start_date date ,@p_end_Date date,@p_emp_ID int ,@p_subscription_ID int ) returns decimal(18,2) as begin declare @a decimal(18,2),@b decimal(18,2),@sal decimal(18,2) set @a=(select avg(no_Cust_Attendd) as average from Report_Trainer_Sal1 where attend_Date   between @p_start_date and @p_end_Date) set @b=(select  distinct (variable_Salary/no_Customers) from Report_Trainer_Sal1  where employee_ID=@p_emp_ID and Subscription_ID=@p_subscription_ID) set @sal =(@b*@a) return @sal end"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Security_Group_Details] ADD  CONSTRAINT [DF_Security_Group_Details_Granted]  DEFAULT ((0)) FOR [Granted]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[User_Log] ADD  CONSTRAINT [DF_User_Log_Action_Date]  DEFAULT (getdate()) FOR [Action_Date]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[User_Log] ADD  CONSTRAINT [DF_User_Log_Action_Time]  DEFAULT (getdate()) FOR [Action_Time]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[App_Preferences] ADD  CONSTRAINT [DF_App_Preferences_Gen_Is_Send]  DEFAULT ((0)) FOR [Gen_Is_Send]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[App_Preferences] ADD  CONSTRAINT [DF_App_Preferences_Gen_SMS_Is_Send]  DEFAULT ((0)) FOR [Gen_SMS_Is_Send]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Procedure_Master] ADD  CONSTRAINT [DF_Procedure_Master_Reference_ID]  DEFAULT ((0)) FOR [Reference_ID]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Procedure_Details] ADD  CONSTRAINT [DF_Procedure_Details_Procedure_Date]  DEFAULT (getdate()) FOR [Procedure_Date]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Banks_Accounts] ADD  CONSTRAINT [DF_Banks_Accounts_Created_Date]  DEFAULT (getdate()) FOR [Created_Date]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[App_Users] ADD  CONSTRAINT [DF_App_Users_Account_Status]  DEFAULT ((0)) FOR [Account_Status]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Tasks] ADD  CONSTRAINT [DF_Employees_Tasks_Task_Date]  DEFAULT (getdate()) FOR [Task_Date]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Rewards] ADD  CONSTRAINT [DF_Employees_Rewards_Reward_Date]  DEFAULT (getdate()) FOR [Reward_Date]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Attendance] ADD  CONSTRAINT [DF_Attendance_Attend_Date]  DEFAULT (getdate()) FOR [Attend_Date]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Attendance] ADD  CONSTRAINT [DF_Attendance_Attend_Time]  DEFAULT (getdate()) FOR [Attend_Time]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Vendors_Payments] ADD  CONSTRAINT [DF_Vendors_Payments_Bill_Date]  DEFAULT (getdate()) FOR [Bill_Date]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Vendors_Payments] ADD  CONSTRAINT [DF_Vendors_Payments_Status]  DEFAULT (N'مدفوعة') FOR [Status]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_V_Header] ADD  CONSTRAINT [DF_Return_V_Header_Bill_Date]  DEFAULT (getdate()) FOR [Bill_Date]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Pay_Salary] ADD  CONSTRAINT [DF_Pay_Salary_Pay_Date]  DEFAULT (getdate()) FOR [Pay_Date]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_C_Header] ADD  CONSTRAINT [DF_Return_C_Header_Bill_Date]  DEFAULT (getdate()) FOR [Bill_Date]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Items_stocks]  WITH CHECK ADD  CONSTRAINT [FK_Items_stocks_items] FOREIGN KEY([Item_Id]) REFERENCES [dbo].[Items] ([Item_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Items_stocks] CHECK CONSTRAINT [FK_Items_stocks_items]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Items_Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Items_Vendors_Items] FOREIGN KEY([Item_ID]) REFERENCES [dbo].[Items] ([Item_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Items_Vendors] CHECK CONSTRAINT [FK_Items_Vendors_Items]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Items_Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Items_Vendors_Vendors] FOREIGN KEY([Vendor_ID]) REFERENCES [dbo].[Vendors] ([Vendor_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Items_Vendors] CHECK CONSTRAINT [FK_Items_Vendors_Vendors]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [items_category_id_fk] FOREIGN KEY([Category_Id]) REFERENCES [dbo].[Categories] ([Category_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [items_category_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [items_corporation_id_fk] FOREIGN KEY([Corporation_Id]) REFERENCES [dbo].[Corporations] ([Corporation_Id])"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [items_corporation_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [items_Um_id_fk] FOREIGN KEY([Um_id]) REFERENCES [dbo].[Um_Master] ([Um_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [items_Um_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Security_Group_Details]  WITH CHECK ADD  CONSTRAINT [FK_Security_Group_Details_Security_Group_Header] FOREIGN KEY([Group_ID]) REFERENCES [dbo].[Security_Group_Header] ([Group_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Security_Group_Details] CHECK CONSTRAINT [FK_Security_Group_Details_Security_Group_Header]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Um_Details]  WITH CHECK ADD  CONSTRAINT [Um_Details_Um_id_fk] FOREIGN KEY([Um_Id]) REFERENCES [dbo].[Um_Master] ([Um_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Um_Details] CHECK CONSTRAINT [Um_Details_Um_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[User_Log]  WITH CHECK ADD  CONSTRAINT [FK_User_Log_App_Users] FOREIGN KEY([User_ID]) REFERENCES [dbo].[App_Users] ([User_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[User_Log] CHECK CONSTRAINT [FK_User_Log_App_Users]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Check_Details]  WITH CHECK ADD  CONSTRAINT [FK_check_details_check_header] FOREIGN KEY([Check_Id]) REFERENCES [dbo].[Check_Header] ([Check_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Check_Details] CHECK CONSTRAINT [FK_check_details_check_header]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Check_Details]  WITH CHECK ADD  CONSTRAINT [FK_check_details_items] FOREIGN KEY([Item_Id]) REFERENCES [dbo].[Items] ([Item_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Check_Details] CHECK CONSTRAINT [FK_check_details_items]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Inventory_Log]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Log_Items] FOREIGN KEY([Item_ID]) REFERENCES [dbo].[Items] ([Item_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Inventory_Log] CHECK CONSTRAINT [FK_Inventory_Log_Items]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Inventory_Log]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Log_Stocks] FOREIGN KEY([Stock_ID]) REFERENCES [dbo].[Stocks] ([Stock_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Inventory_Log] CHECK CONSTRAINT [FK_Inventory_Log_Stocks]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Dep_Details]  WITH CHECK ADD  CONSTRAINT [dep_details_Dep_Id_fk] FOREIGN KEY([Bill_Id]) REFERENCES [dbo].[Dep_Header] ([Bill_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Dep_Details] CHECK CONSTRAINT [dep_details_Dep_Id_fk]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Dep_Details]  WITH CHECK ADD  CONSTRAINT [dep_details_um_detail_id_fk] FOREIGN KEY([Um_Detail_Id]) REFERENCES [dbo].[Um_Details] ([Um_Detail_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Dep_Details] CHECK CONSTRAINT [dep_details_um_detail_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Dep_Details]  WITH CHECK ADD  CONSTRAINT [FK_Dep_Details_Items] FOREIGN KEY([Item_Id]) REFERENCES [dbo].[Items] ([Item_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Dep_Details] CHECK CONSTRAINT [FK_Dep_Details_Items]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Loans_Details]  WITH CHECK ADD  CONSTRAINT [FK_Loans_Details_Loans] FOREIGN KEY([Loan_ID]) REFERENCES [dbo].[Loans] ([Loan_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Loans_Details] CHECK CONSTRAINT [FK_Loans_Details_Loans]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Details]  WITH CHECK ADD  CONSTRAINT [FK_sales_details_items] FOREIGN KEY([Item_Id]) REFERENCES [dbo].[Items] ([Item_Id])"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Details] CHECK CONSTRAINT [FK_sales_details_items]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Details]  WITH CHECK ADD  CONSTRAINT [FK_sales_details_salas_header] FOREIGN KEY([Bill_Id]) REFERENCES [dbo].[Sales_Header] ([Bill_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Details] CHECK CONSTRAINT [FK_sales_details_salas_header]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Details]  WITH CHECK ADD  CONSTRAINT [FK_sales_details_Um_Details] FOREIGN KEY([Um_Detail_Id]) REFERENCES [dbo].[Um_Details] ([Um_Detail_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Details] CHECK CONSTRAINT [FK_sales_details_Um_Details]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_V_Details]  WITH CHECK ADD  CONSTRAINT [FK_Return_V_Details_Items] FOREIGN KEY([Item_ID]) REFERENCES [dbo].[Items] ([Item_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_V_Details] CHECK CONSTRAINT [FK_Return_V_Details_Items]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_V_Details]  WITH CHECK ADD  CONSTRAINT [FK_Return_V_Details_Return_V_Header] FOREIGN KEY([Bill_ID]) REFERENCES [dbo].[Return_V_Header] ([Bill_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_V_Details] CHECK CONSTRAINT [FK_Return_V_Details_Return_V_Header]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_V_Details]  WITH CHECK ADD  CONSTRAINT [FK_Return_V_Details_Um_Details] FOREIGN KEY([Um_Detail_ID]) REFERENCES [dbo].[Um_Details] ([Um_Detail_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_V_Details] CHECK CONSTRAINT [FK_Return_V_Details_Um_Details]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_C_Details]  WITH CHECK ADD  CONSTRAINT [FK_Return_C_Details_Items] FOREIGN KEY([Item_ID]) REFERENCES [dbo].[Items] ([Item_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_C_Details] CHECK CONSTRAINT [FK_Return_C_Details_Items]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_C_Details]  WITH CHECK ADD  CONSTRAINT [FK_Return_C_Details_Return_C_Header] FOREIGN KEY([Bill_ID]) REFERENCES [dbo].[Return_C_Header] ([Bill_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_C_Details] CHECK CONSTRAINT [FK_Return_C_Details_Return_C_Header]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_C_Details]  WITH CHECK ADD  CONSTRAINT [FK_Return_C_Details_Um_Details] FOREIGN KEY([Um_Detail_ID]) REFERENCES [dbo].[Um_Details] ([Um_Detail_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_C_Details] CHECK CONSTRAINT [FK_Return_C_Details_Um_Details]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Details]  WITH CHECK ADD  CONSTRAINT [FK_purchase_details_items] FOREIGN KEY([Item_Id]) REFERENCES [dbo].[Items] ([Item_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Details] CHECK CONSTRAINT [FK_purchase_details_items]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Details]  WITH CHECK ADD  CONSTRAINT [FK_purchase_details_purchase_header] FOREIGN KEY([Bill_Id]) REFERENCES [dbo].[Purchase_Header] ([Bill_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Details] CHECK CONSTRAINT [FK_purchase_details_purchase_header]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Details]  WITH CHECK ADD  CONSTRAINT [FK_purchase_details_Um_Details] FOREIGN KEY([Um_Detail_Id]) REFERENCES [dbo].[Um_Details] ([Um_Detail_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Details] CHECK CONSTRAINT [FK_purchase_details_Um_Details]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Adjustment_Details]  WITH CHECK ADD  CONSTRAINT [adjustment_details_item_id_fk] FOREIGN KEY([Item_Id]) REFERENCES [dbo].[Items] ([Item_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Adjustment_Details] CHECK CONSTRAINT [adjustment_details_item_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Adjustment_Details]  WITH CHECK ADD  CONSTRAINT [adjustment_details_um_detail_id_fk] FOREIGN KEY([Um_Detail_Id]) REFERENCES [dbo].[Um_Details] ([Um_Detail_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Adjustment_Details] CHECK CONSTRAINT [adjustment_details_um_detail_id_fk]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Adjustment_Details]  WITH CHECK ADD  CONSTRAINT [FK_adjustment_details_adjustments_header] FOREIGN KEY([Adjustment_Id]) REFERENCES [dbo].[Adjustment_Header] ([Adjustment_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Adjustment_Details] CHECK CONSTRAINT [FK_adjustment_details_adjustments_header]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Money_Receivables]  WITH CHECK ADD  CONSTRAINT [FK_Money_Receivables_Procedure_Master] FOREIGN KEY([From_Procedure_Master_ID]) REFERENCES [dbo].[Procedure_Master] ([Procedure_Master_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Money_Receivables] CHECK CONSTRAINT [FK_Money_Receivables_Procedure_Master]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Procedure_Details]  WITH CHECK ADD  CONSTRAINT [FK_Procedure_Details_Procedure_Master] FOREIGN KEY([From_Procedure_Master_ID]) REFERENCES [dbo].[Procedure_Master] ([Procedure_Master_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Procedure_Details] CHECK CONSTRAINT [FK_Procedure_Details_Procedure_Master]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Procedure_Details]  WITH CHECK ADD  CONSTRAINT [FK_Procedure_Details_Procedure_Master1] FOREIGN KEY([To_Procedure_Master_ID]) REFERENCES [dbo].[Procedure_Master] ([Procedure_Master_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Procedure_Details] CHECK CONSTRAINT [FK_Procedure_Details_Procedure_Master1]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Shifts_Details]  WITH CHECK ADD  CONSTRAINT [FK_Shifts_Details_Shifts] FOREIGN KEY([Shift_ID]) REFERENCES [dbo].[Shifts] ([Shift_ID])"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Shifts_Details] CHECK CONSTRAINT [FK_Shifts_Details_Shifts]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Subscriptions]  WITH CHECK ADD  CONSTRAINT [FK_Subscriptions_Subscriptions_Categories] FOREIGN KEY([Category_ID]) REFERENCES [dbo].[Subscriptions_Categories] ([Category_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Subscriptions] CHECK CONSTRAINT [FK_Subscriptions_Subscriptions_Categories]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Banks_Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Banks_Accounts_Banks] FOREIGN KEY([Bank_ID]) REFERENCES [dbo].[Banks] ([Bank_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Banks_Accounts] CHECK CONSTRAINT [FK_Banks_Accounts_Banks]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Countries] FOREIGN KEY([Country_ID]) REFERENCES [dbo].[Countries] ([Country_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Countries]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [employees_department_id_fk] FOREIGN KEY([Department_Id]) REFERENCES [dbo].[Departments] ([Department_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [employees_department_id_fk]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [employees_job_id_fk] FOREIGN KEY([Job_Id]) REFERENCES [dbo].[Jobs] ([Job_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [employees_job_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[App_Users]  WITH CHECK ADD  CONSTRAINT [FK_App_Users_Employees] FOREIGN KEY([Employee_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[App_Users] CHECK CONSTRAINT [FK_App_Users_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[App_Users]  WITH CHECK ADD  CONSTRAINT [FK_App_Users_Security_Group_Header] FOREIGN KEY([Group_ID]) REFERENCES [dbo].[Security_Group_Header] ([Group_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[App_Users] CHECK CONSTRAINT [FK_App_Users_Security_Group_Header]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Check_Header]  WITH CHECK ADD  CONSTRAINT [FK_check_header_employees] FOREIGN KEY([Employee_Id]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Check_Header] CHECK CONSTRAINT [FK_check_header_employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Check_Header]  WITH CHECK ADD  CONSTRAINT [FK_check_header_stocks] FOREIGN KEY([Stock_Id]) REFERENCES [dbo].[Stocks] ([Stock_Id])"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Check_Header] CHECK CONSTRAINT [FK_check_header_stocks]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Loans]  WITH CHECK ADD  CONSTRAINT [FK_Loans_Employees] FOREIGN KEY([Employee_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Loans] CHECK CONSTRAINT [FK_Loans_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Loans]  WITH CHECK ADD  CONSTRAINT [FK_Loans_Stock] FOREIGN KEY([Stock_ID]) REFERENCES [dbo].[Stocks] ([Stock_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Loans] CHECK CONSTRAINT [FK_Loans_Stock]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Evaluation_Details]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Evaluation_Details_Customers_Evaluation] FOREIGN KEY([Evaluation_ID]) REFERENCES [dbo].[Customers_Evaluation] ([Evaluation_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Evaluation_Details] CHECK CONSTRAINT [FK_Customers_Evaluation_Details_Customers_Evaluation]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Expenses_Details]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_Details_Expenses_Header] FOREIGN KEY([Expense_Category_ID]) REFERENCES [dbo].[Expenses_Header] ([Expense_Category_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Expenses_Details] CHECK CONSTRAINT [FK_Expenses_Details_Expenses_Header]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Dep_Header]  WITH CHECK ADD  CONSTRAINT [dep_header_dep_id_fk] FOREIGN KEY([Employee_Id]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Dep_Header] CHECK CONSTRAINT [dep_header_dep_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Dep_Header]  WITH CHECK ADD  CONSTRAINT [FK_dep_header_Stock_id_fk] FOREIGN KEY([Stock_Id]) REFERENCES [dbo].[Stocks] ([Stock_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Dep_Header] CHECK CONSTRAINT [FK_dep_header_Stock_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Vacations]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Vacations_Employees] FOREIGN KEY([Employee_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Vacations] CHECK CONSTRAINT [FK_Employees_Vacations_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Tasks_Employees] FOREIGN KEY([To_Employee]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Tasks] CHECK CONSTRAINT [FK_Employees_Tasks_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Tasks_Employees1] FOREIGN KEY([From_Employee]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Tasks] CHECK CONSTRAINT [FK_Employees_Tasks_Employees1]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Shifts]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Shifts_Employees] FOREIGN KEY([Employee_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Shifts] CHECK CONSTRAINT [FK_Employees_Shifts_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Shifts]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Shifts_Shifts_Details] FOREIGN KEY([Shift_Detail_ID]) REFERENCES [dbo].[Shifts_Details] ([Shift_Details_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Shifts] CHECK CONSTRAINT [FK_Employees_Shifts_Shifts_Details]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Rewards]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Rewards_Employees] FOREIGN KEY([Employee_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Rewards] CHECK CONSTRAINT [FK_Employees_Rewards_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Rewards]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Rewards_Rewards_Categories] FOREIGN KEY([Category_ID]) REFERENCES [dbo].[Rewards_Categories] ([Category_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Rewards] CHECK CONSTRAINT [FK_Employees_Rewards_Rewards_Categories]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Extra]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Extra_Employees] FOREIGN KEY([Employee_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Extra] CHECK CONSTRAINT [FK_Employees_Extra_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Extra]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Extra_Extra_Categories] FOREIGN KEY([Category_ID]) REFERENCES [dbo].[Extra_Categories] ([Category_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Extra] CHECK CONSTRAINT [FK_Employees_Extra_Extra_Categories]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Discounts]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Discounts_Discount_Categories] FOREIGN KEY([Category_ID]) REFERENCES [dbo].[Discount_Categories] ([Category_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Discounts] CHECK CONSTRAINT [FK_Employees_Discounts_Discount_Categories]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Discounts]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Discounts_Employees] FOREIGN KEY([Employee_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Discounts] CHECK CONSTRAINT [FK_Employees_Discounts_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Cheques]  WITH CHECK ADD  CONSTRAINT [FK_Cheques_Banks_Accounts] FOREIGN KEY([Account_ID]) REFERENCES [dbo].[Banks_Accounts] ([Account_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Cheques] CHECK CONSTRAINT [FK_Cheques_Banks_Accounts]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Adjustment_Header]  WITH CHECK ADD  CONSTRAINT [adjustments_header_employee_id_fk] FOREIGN KEY([Employee_Id]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Adjustment_Header] CHECK CONSTRAINT [adjustments_header_employee_id_fk]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Adjustment_Header]  WITH CHECK ADD  CONSTRAINT [adjustments_header_form_stock_id_fk] FOREIGN KEY([From_Stock_Id]) REFERENCES [dbo].[Stocks] ([Stock_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Adjustment_Header] CHECK CONSTRAINT [adjustments_header_form_stock_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Adjustment_Header]  WITH CHECK ADD  CONSTRAINT [adjustments_header_to_stock_id_fk] FOREIGN KEY([To_Stock_id]) REFERENCES [dbo].[Stocks] ([Stock_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Adjustment_Header] CHECK CONSTRAINT [adjustments_header_to_stock_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Employees] FOREIGN KEY([Employee_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Halls] FOREIGN KEY([Hall_ID]) REFERENCES [dbo].[Halls] ([Hall_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Halls]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Shifts_Details] FOREIGN KEY([Shift_Detail_ID]) REFERENCES [dbo].[Shifts_Details] ([Shift_Details_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Shifts_Details]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Visa]  WITH CHECK ADD  CONSTRAINT [FK_Visa_Banks_Accounts] FOREIGN KEY([Account_ID]) REFERENCES [dbo].[Banks_Accounts] ([Account_ID])"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Visa] CHECK CONSTRAINT [FK_Visa_Banks_Accounts]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Vendors_Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Vendors_Transactions_Vendors] FOREIGN KEY([Vendor_ID]) REFERENCES [dbo].[Vendors] ([Vendor_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Vendors_Transactions] CHECK CONSTRAINT [FK_Vendors_Transactions_Vendors]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Vendors_Payments]  WITH CHECK ADD  CONSTRAINT [FK_Vendors_Payments_Vendors] FOREIGN KEY([Vendor_ID]) REFERENCES [dbo].[Vendors] ([Vendor_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Vendors_Payments] CHECK CONSTRAINT [FK_Vendors_Payments_Vendors]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sub_Stocks]  WITH CHECK ADD  CONSTRAINT [FK_Sub_Stocks_Employees] FOREIGN KEY([Employee_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sub_Stocks] CHECK CONSTRAINT [FK_Sub_Stocks_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Trainers_Details]  WITH CHECK ADD  CONSTRAINT [FK_Trainers_Details_Employees] FOREIGN KEY([Trainer_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Trainers_Details] CHECK CONSTRAINT [FK_Trainers_Details_Employees]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Trainers_Details]  WITH CHECK ADD  CONSTRAINT [FK_Trainers_Details_Subscriptions] FOREIGN KEY([Subscription_ID]) REFERENCES [dbo].[Subscriptions] ([Subscription_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Trainers_Details] CHECK CONSTRAINT [FK_Trainers_Details_Subscriptions]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_V_Header]  WITH CHECK ADD  CONSTRAINT [FK_Return_V_Header_Employees] FOREIGN KEY([Employee_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_V_Header] CHECK CONSTRAINT [FK_Return_V_Header_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_V_Header]  WITH CHECK ADD  CONSTRAINT [FK_Return_V_Header_Stocks] FOREIGN KEY([Stock_ID]) REFERENCES [dbo].[Stocks] ([Stock_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_V_Header] CHECK CONSTRAINT [FK_Return_V_Header_Stocks]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_V_Header]  WITH CHECK ADD  CONSTRAINT [FK_Return_V_Header_Vendors] FOREIGN KEY([Vendor_ID]) REFERENCES [dbo].[Vendors] ([Vendor_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_V_Header] CHECK CONSTRAINT [FK_Return_V_Header_Vendors]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Regions]  WITH CHECK ADD  CONSTRAINT [FK_Regions_Cities] FOREIGN KEY([City_ID]) REFERENCES [dbo].[Cities] ([City_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Regions] CHECK CONSTRAINT [FK_Regions_Cities]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Pay_Salary]  WITH CHECK ADD  CONSTRAINT [FK_Pay_Salary_Employees] FOREIGN KEY([Employee_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Pay_Salary] CHECK CONSTRAINT [FK_Pay_Salary_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Added_Hours]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Added_Hours_Employees] FOREIGN KEY([Employee_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Employees_Added_Hours] CHECK CONSTRAINT [FK_Employees_Added_Hours_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Header]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Header_Cheques] FOREIGN KEY([Cheque_ID]) REFERENCES [dbo].[Cheques] ([Cheque_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Header] CHECK CONSTRAINT [FK_Purchase_Header_Cheques]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Header]  WITH CHECK ADD  CONSTRAINT [FK_purchase_header_employees] FOREIGN KEY([Employee_Id]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Header] CHECK CONSTRAINT [FK_purchase_header_employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Header]  WITH CHECK ADD  CONSTRAINT [FK_purchase_header_stocks] FOREIGN KEY([Stock_Id]) REFERENCES [dbo].[Stocks] ([Stock_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Header] CHECK CONSTRAINT [FK_purchase_header_stocks]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Header]  WITH CHECK ADD  CONSTRAINT [FK_purchase_header_vendors] FOREIGN KEY([Vendor_Id]) REFERENCES [dbo].[Vendors] ([Vendor_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Purchase_Header] CHECK CONSTRAINT [FK_purchase_header_vendors]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Locations]  WITH CHECK ADD  CONSTRAINT [FK_Locations_Regions] FOREIGN KEY([Region_ID]) REFERENCES [dbo].[Regions] ([Region_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Locations] CHECK CONSTRAINT [FK_Locations_Regions]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Companies] FOREIGN KEY([Company_ID]) REFERENCES [dbo].[Companies] ([Company_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Companies]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Jobs] FOREIGN KEY([Job_ID]) REFERENCES [dbo].[Jobs] ([Job_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Jobs]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Locations] FOREIGN KEY([Location_ID]) REFERENCES [dbo].[Locations] ([Location_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Locations]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Subscriptions_Details]  WITH CHECK ADD  CONSTRAINT [FK_Subscriptions_Details_Customers] FOREIGN KEY([Customer_ID]) REFERENCES [dbo].[Customers] ([Customer_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Subscriptions_Details] CHECK CONSTRAINT [FK_Subscriptions_Details_Customers]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Subscriptions_Details]  WITH CHECK ADD  CONSTRAINT [FK_Subscriptions_Details_Employees] FOREIGN KEY([Coach_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Subscriptions_Details] CHECK CONSTRAINT [FK_Subscriptions_Details_Employees]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Subscriptions_Details]  WITH CHECK ADD  CONSTRAINT [FK_Subscriptions_Details_Employees1] FOREIGN KEY([Employee_id]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Subscriptions_Details] CHECK CONSTRAINT [FK_Subscriptions_Details_Employees1]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Subscriptions_Details]  WITH CHECK ADD  CONSTRAINT [FK_Subscriptions_Details_Subscriptions] FOREIGN KEY([Subscription_ID]) REFERENCES [dbo].[Subscriptions] ([Subscription_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Subscriptions_Details] CHECK CONSTRAINT [FK_Subscriptions_Details_Subscriptions]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Special_Subscriptions]  WITH CHECK ADD  CONSTRAINT [FK_Special_Subscriptions_Customers] FOREIGN KEY([Customer_ID]) REFERENCES [dbo].[Customers] ([Customer_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Special_Subscriptions] CHECK CONSTRAINT [FK_Special_Subscriptions_Customers]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Special_Subscriptions]  WITH CHECK ADD  CONSTRAINT [FK_Special_Subscriptions_Employees] FOREIGN KEY([Trainer_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Special_Subscriptions] CHECK CONSTRAINT [FK_Special_Subscriptions_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Special_Subscriptions]  WITH CHECK ADD  CONSTRAINT [FK_Special_Subscriptions_Special_Categories] FOREIGN KEY([Special_Categories_ID]) REFERENCES [dbo].[Special_Categories] ([Special_Categories_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Special_Subscriptions] CHECK CONSTRAINT [FK_Special_Subscriptions_Special_Categories]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Header]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Header_Cheques] FOREIGN KEY([Cheque_ID]) REFERENCES [dbo].[Cheques] ([Cheque_ID])"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Header] CHECK CONSTRAINT [FK_Sales_Header_Cheques]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Header]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Header_Visa] FOREIGN KEY([Visa_ID]) REFERENCES [dbo].[Visa] ([Visa_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Header] CHECK CONSTRAINT [FK_Sales_Header_Visa]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Header]  WITH CHECK ADD  CONSTRAINT [salas_header_customer_id_fk] FOREIGN KEY([Customer_Id]) REFERENCES [dbo].[Customers] ([Customer_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Header] CHECK CONSTRAINT [salas_header_customer_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Header]  WITH CHECK ADD  CONSTRAINT [salas_header_employee_id_fk] FOREIGN KEY([Employee_Id]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Header] CHECK CONSTRAINT [salas_header_employee_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Header]  WITH CHECK ADD  CONSTRAINT [salas_header_stock_id_fk] FOREIGN KEY([Stock_Id]) REFERENCES [dbo].[Stocks] ([Stock_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Sales_Header] CHECK CONSTRAINT [salas_header_stock_id_fk]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_C_Header]  WITH CHECK ADD  CONSTRAINT [FK_Return_C_Header_Customers] FOREIGN KEY([Customer_ID]) REFERENCES [dbo].[Customers] ([Customer_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_C_Header] CHECK CONSTRAINT [FK_Return_C_Header_Customers]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_C_Header]  WITH CHECK ADD  CONSTRAINT [FK_Return_C_Header_Employees] FOREIGN KEY([Employee_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_C_Header] CHECK CONSTRAINT [FK_Return_C_Header_Employees]"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_C_Header]  WITH CHECK ADD  CONSTRAINT [FK_Return_C_Header_Stocks] FOREIGN KEY([Stock_ID]) REFERENCES [dbo].[Stocks] ([Stock_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Return_C_Header] CHECK CONSTRAINT [FK_Return_C_Header_Stocks]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Orders_Evaluation]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Orders_Evaluation_Customers_Evaluation_Details] FOREIGN KEY([Evaluation_Detail_ID]) REFERENCES [dbo].[Customers_Evaluation_Details] ([Evaluation_Detail_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Orders_Evaluation] CHECK CONSTRAINT [FK_Customers_Orders_Evaluation_Customers_Evaluation_Details]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Orders_Evaluation]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Orders_Evaluation_Sales_Header] FOREIGN KEY([Customer_ID]) REFERENCES [dbo].[Customers] ([Customer_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Orders_Evaluation] CHECK CONSTRAINT [FK_Customers_Orders_Evaluation_Sales_Header]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Attendance_Customers] FOREIGN KEY([Customer_ID]) REFERENCES [dbo].[Customers] ([Customer_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Attendance] CHECK CONSTRAINT [FK_Customers_Attendance_Customers]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Attendance_Employees] FOREIGN KEY([Coach_ID]) REFERENCES [dbo].[Employees] ([Employee_Id])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Attendance] CHECK CONSTRAINT [FK_Customers_Attendance_Employees]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Attendance_Hall] FOREIGN KEY([Hall_ID]) REFERENCES [dbo].[Halls] ([Hall_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Attendance] CHECK CONSTRAINT [FK_Customers_Attendance_Hall]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Attendance_Subscriptions] FOREIGN KEY([Subscription_ID]) REFERENCES [dbo].[Subscriptions] ([Subscription_ID])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " ALTER TABLE [dbo].[Customers_Attendance] CHECK CONSTRAINT [FK_Customers_Attendance_Subscriptions]"
        cmd.ExecuteNonQuery()

        CalcProgress()







        cmd.CommandText = "SET IDENTITY_INSERT [dbo].[Shifts] ON INSERT [dbo].[Shifts] ([Shift_ID], [Shift_Name], [Generic_Desc]) VALUES (3, N'صباحيه', NULL)INSERT [dbo].[Shifts] ([Shift_ID], [Shift_Name], [Generic_Desc]) VALUES (4, N'مسائيه', NULL) SET IDENTITY_INSERT [dbo].[Shifts] OFF"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SET IDENTITY_INSERT [dbo].[Procedure_Master] ON INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (1, N'المشتريات', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'قائمة الدخل', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (2, N'خصم مكتسب', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'ايرادات متنوعه', N'دائن')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (3, N'خصم مسموح به', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'مصاريف تسويقيه', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (4, N'الخزينة', 0, NULL, CAST(20000.00 AS Decimal(18, 2)), N'أصول متداوله', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (7, N'المبيعات', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'قائمة الدخل', N'دائن')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (8, N'بضاعة تالفة', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'مصاريف تسويقيه', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (10, N'م/مشتريات', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'قائمة الدخل', N'دائن')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (11, N'م/مبيعات', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'قائمة الدخل', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (12, N'مرتبات اداريه', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'مصاريف اداريه', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (13, N'بضاعة أول المده', 0, NULL, CAST(250000.00 AS Decimal(18, 2)), N'قائمة الدخل', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (14, N'خصم كميه مشتريات', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'ايرادات متنوعه', N'دائن')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (15, N'خصم كميه مبيعات', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'مصاريف تسويقيه', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (16, N'عجز طبيعي', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'أرصده مدينه', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (19, N'عملاء عائلي', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'أرصده مدينه', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (20, N'زياده مخزنيه', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'ايرادات متنوعه', N'دائن')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (21, N'بضاعة اخر المده', 0, NULL, CAST(249860.00 AS Decimal(18, 2)), N'أصول متداوله', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (22, N'عمولات دائنه', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'ايرادات متنوعه', N'دائن')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (23, N'شيكات تحت التحصيل', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'أرصده مدينه', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (24, N'شيكات مؤجله', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'أرصده دائنه', N'دائن') INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (28, N'مرتبات تسويقيه', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'مصاريف تسويقيه', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (29, N'ضرائب المبيعات', 0, NULL, CAST(2500.00 AS Decimal(18, 2)), N'أرصده دائنه', N'دائن')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (30, N'هدايا و منح', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'مصاريف تسويقيه', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (31, N'حساب عملاء - عميل نقدي', 0, NULL, CAST(0.00 AS Decimal(18, 2)), N'عملاء', N'مدين')INSERT [dbo].[Procedure_Master] ([Procedure_Master_ID], [Daily_Procedure_Name], [Reference_ID], [Generic_Desc], [Balance], [Procedure_Category], [Procedure_Type]) VALUES (32, N'رأس المال', 0, NULL, CAST(300000.00 AS Decimal(18, 2)), N'حقوق ملكيه', N'دائن')SET IDENTITY_INSERT [dbo].[Procedure_Master] OFF"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SET IDENTITY_INSERT [dbo].[Banks] ON INSERT [dbo].[Banks] ([Bank_ID], [Bank_Name], [Generic_Desc], [Address]) VALUES (0, N'بنك افتراضي', NULL, NULL)SET IDENTITY_INSERT [dbo].[Banks] OFF"
        cmd.ExecuteNonQuery()
        CalcProgress()
        cmd.CommandText = "SET IDENTITY_INSERT [dbo].[Countries] ON INSERT [dbo].[Countries] ([Country_ID], [Country_Name], [Continent]) VALUES (1, N'مصر', N'أفريقيا') SET IDENTITY_INSERT [dbo].[Countries] OFF"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SET IDENTITY_INSERT [Jobs] ON INSERT [Jobs] ([Job_ID], [Job_Title], [JOB_Desc]) VALUES (1, N'مدرب', NULL) INSERT [Jobs] ([Job_ID], [Job_Title], [job_Desc]) VALUES (2, N'موظف استقبال', NULL)SET IDENTITY_INSERT [Jobs] OFF"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SET IDENTITY_INSERT [dbo].[DEPARTMENTS] ON INSERT INTO [GYM].[dbo].[Departments]([Department_ID],[Department_Name],[Generic_Desc])VALUES(1,N'عام','')SET IDENTITY_INSERT [dbo].[DEPARTMENTS] OFF"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SET IDENTITY_INSERT [dbo].[Employees] ON INSERT [dbo].[Employees] ([Employee_ID], [Employee_Name], [BarCode], [Department_ID], [Job_ID], [Address], [Tele], [Mobile], [basic_salary],[variable_salary], [Hire_Date], [Education], [Email], [Photo]) VALUES (1, N'أحمد', N'1', 1, 2, N'القاهره', N'111', N'111', CAST(0 AS Numeric(18, 2)),CAST(0 AS Numeric(18, 2)), CAST(0x0000A10500000000 AS DateTime), NULL, NULL, NULL)SET IDENTITY_INSERT [dbo].[Employees] OFF"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SET IDENTITY_INSERT [Banks_Accounts] ON INSERT [Banks_Accounts] ([Account_ID], [Account_Number], [Generic_Desc], [Created_Date], [Balance], [Account_Status], [Bank_ID]) VALUES (0, N'0', NULL, CAST(0x9F360B00 AS Date), CAST(0.00 AS Decimal(18, 2)), 0, 0)SET IDENTITY_INSERT [Banks_Accounts] OFF"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SET IDENTITY_INSERT [Cheques] ON INSERT [Cheques] ([Cheque_ID], [Cheque_Number], [Received_Date], [Payed_Date], [Cheque_Value], [Cheque_Status], [Account_ID], [Direction]) VALUES (0, N'0', CAST(0x50350B00 AS Date), CAST(0x50350B00 AS Date), CAST(0.00 AS Decimal(18, 2)), N'جديد', 0, NULL) SET IDENTITY_INSERT [Cheques] OFF"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SET IDENTITY_INSERT [security_Group_Header] ON INSERT INTO [GYM].[dbo].[Security_Group_Header]([Group_id],[Group_Name],[Generic_Desc])VALUES(1,N'مديرين','') SET IDENTITY_INSERT [security_Group_Header] OFF"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SET IDENTITY_INSERT [App_Users] ON INSERT [App_Users] ([User_ID], [User_Name], [User_Password], [Employee_ID], [Group_ID], [Account_Status]) VALUES (1, N'admin', N'admin123', 1, 1, 1)SET IDENTITY_INSERT [App_Users] OFF"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SET IDENTITY_INSERT [Visa] ON INSERT [Visa] ([Visa_ID], [Visa_Number], [Created_Date], [Visa_Status], [Account_ID]) VALUES (0, N'0', CAST(0xC1360B00 AS Date), 1, 0)SET IDENTITY_INSERT [Visa] OFF"
        cmd.ExecuteNonQuery()
        CalcProgress()

        cmd.CommandText = "INSERT [dbo].[App_Preferences] ([Serial_PK], [Gen_View_Alert], [Gen_Print_Barcode], [Gen_Attach_Item_Stk], [Gen_Attach_Item_Ven], [Gen_Print_Type], [Gen_View_Msg], [Gen_View_Before_Print], [Gen_Back_Photo], [Pur_Stk_ID], [Pur_Def_Qty], [Pur_Def_Style], [Pur_Def_Sch], [Pur_Def_Filter], [Sal_Def_Qty], [Sal_Def_Style], [Sal_Def_Sch], [Sal_Def_Filter], [Sal_Def_Ord_Type], [Sal_Edit_Emp_ID], [Sal_Edit_Date], [Ret_Cus_Def_Qty], [Ret_Cus_Def_Sch], [Ret_Ven_Def_Qty], [Ret_Ven_Def_Sch], [Dep_Def_Qty], [Dep_Def_Sch], [Req_Cus_Def_Qty], [Req_Cus_Def_Sch], [Adj_Def_Qty], [Adj_Def_Sch], [Gen_Sender_Email], [Gen_Sender_Pwd], [Gen_Is_Send], [Gen_Receipt_Email], [Gen_Send_Action], [Sal_Footer], [Gen_SMS_Is_Send], [Gen_SMS_URL], [Min_Hours], [Work_Hours], [Extra_Hours], [Less_Hours], [Min_Customers], [Extra_Customers], [Less_Customers], [Extra_Subsc]) VALUES (1, 0, N'48', 0, 0, N'شيك', 1, 1, NULL, 2, 1, N'عادية', N'الاسم', N'المقاس', 1, N'عادية', N'الاسم', N'اسم البند', N'قطاعي', 1, 1, 1, N'الاسم', 1, N'الباركود', 1, N'الاسم', 1, N'الباركود', 1, N'الاسم', N'hosam_hassan620@hotmail.com', N'123', 0, N'hosam_hassan620@yahoo.com', N'بدء البرنامج', N'تسعدنا زيارتكم دائما', 0, N'http://localhost', CAST(70.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(0.50 AS Decimal(18, 2)), CAST(0.25 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)))"
        cmd.ExecuteNonQuery()

        '------------------------------------------------------------

        cls.FillSelectedTable("select * from App_Preferences", "App_Preferences")

        ProgressBar1.Value = 100
        b = True
    End Sub

    Private Sub CreateDB_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If b = True Then
            e.Cancel = False
        Else

            e.Cancel = True
        End If
    End Sub
End Class