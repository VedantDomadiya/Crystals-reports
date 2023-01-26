using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BAL
{
    public class ReportMgmt
    {

        // ===============================================================================================
        // Report Method Signature : Stock
        // ===============================================================================================
        public static List<Entity.OrganizationEmployee> Report_ExpLedger(DateTime FromDate, DateTime ToDate, Int64 ExpenseTypeID, Int64 EmployeeID)
        {
            List<Entity.OrganizationEmployee> lstObject = new List<Entity.OrganizationEmployee>();
            lstObject = new DAL.ReportSQL().Report_ExpLedger(FromDate, ToDate, ExpenseTypeID, EmployeeID);
            return lstObject;
        }
        public static List<Entity.InquiryInfo_Report> Report_InqFollow(DateTime FromDate, DateTime ToDate, string Priority, string LeadStatus, Int64 CustomerID, Int64 EmployeeID, string ProductGroup, Int64 ProductID)
        {
            List<Entity.InquiryInfo_Report> lstObject = new List<Entity.InquiryInfo_Report>();
            lstObject = new DAL.ReportSQL().Report_InqFollow(FromDate, ToDate, Priority, LeadStatus, CustomerID, EmployeeID, ProductGroup, ProductID);
            return lstObject;
        }
        public static List<Entity.ProductStockReport> Report_Stock_New(String pLoginUserID, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.ProductStockReport> lstObject = new List<Entity.ProductStockReport>();
            lstObject = new DAL.ReportSQL().Report_Stock_New(pLoginUserID, FromDate,ToDate);
            return lstObject;
        }
        
            public static List<Entity.MonthlyTourPlan> Report_MonthlyTourPlan(DateTime FromDate, DateTime ToDate, Int64 pCustomerID)
        {
            List<Entity.MonthlyTourPlan> lstObject = new List<Entity.MonthlyTourPlan>();
            lstObject = new DAL.ReportSQL().Report_MonthlyTourPlan(FromDate, ToDate, pCustomerID);
            return lstObject;
        }
        public static List<Entity.EmployeeActivity> Report_EmployeeActivity(Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, Int64 EmployeeID)
        {
            List<Entity.EmployeeActivity> lstObject = new List<Entity.EmployeeActivity>();
            lstObject = new DAL.ReportSQL().Report_EmployeeActivity(pFromDate, pToDate, EmployeeID);
            return lstObject;
        }
        public static List<Entity.OrderToSalesOrderDetail> Report_SOSummary(DateTime pFromDate, DateTime pToDate, Int64 CustomerID, string SONo)
        {
            List<Entity.OrderToSalesOrderDetail> lstObject = new List<Entity.OrderToSalesOrderDetail>();
            lstObject = new DAL.ReportSQL().Report_SOSummary(pFromDate, pToDate, CustomerID, SONo);
            return lstObject;
        }
        public static List<Entity.OverTime> Report_GetOverTimeListByUser(string pLoginUserID, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, Int64 EmployeeID)
        {
            List<Entity.OverTime> lstObject = new List<Entity.OverTime>();
            lstObject = new DAL.ReportSQL().Report_GetOverTimeListByUser(pLoginUserID, pFromDate, pToDate, EmployeeID);
            return lstObject;
        }

        //--------------------------------------------------------------------------------------------------------------
        //Report Employee list 
        //--------------------------------------------------------------------------------------------------------------
        /*public static  GetEmployeeList()
        {
            new DAL.EmployeeSQL().GetEmployeeList();
        }*/

        /*public static List<Entity.Report> GetEmployeeList()
        {
            List<Entity.Report> lstObject = new List<Entity.Report>();
            lstObject = new DAL.ReportSQL().GetEmployeeList();
            return lstObject;
        }*/


        //==============================================================================================================
        // Report Method Signature : :) by vedant
        //==============================================================================================================
        
        public static List<Entity.ProductReport> Report_ProductList(string pLoginUserID, Int64 CustomerID, DateTime pFromDate, DateTime pToDate, string CustomerStatus, string CustomerType, Int64 StateCode, Int64 CityCode)
        {
            List<Entity.ProductReport> lstObject = new List<Entity.ProductReport>();
            lstObject = new DAL.ReportSQL().Report_ProductList(pLoginUserID, CustomerID, pFromDate, pToDate, CustomerStatus, CustomerType, StateCode, CityCode);
            return lstObject;
        }

        //==============================================================================================================
        // Report Method Signature : Visitor Management Report
        //==============================================================================================================

        public static List<Entity.CustomerReport> Report_CustomerList(string pLoginUserID, Int64 CustomerID, DateTime pFromDate, DateTime pToDate, string CustomerStatus, string CustomerType, Int64 StateCode, Int64 CityCode)
        {
            List<Entity.CustomerReport> lstObject = new List<Entity.CustomerReport>();
            lstObject = new DAL.ReportSQL().Report_CustomerList( pLoginUserID,  CustomerID,  pFromDate,  pToDate,  CustomerStatus,  CustomerType,  StateCode,  CityCode);
            return lstObject;
        }




        //===========================================================================================================
        // Report Method Signature : Inward Report
        // ===========================================================================================================
        public static List<Entity.GRNReport> GRNReport(Int64 ProductID, Int64 CustomerID, DateTime FromDate, DateTime ToDate, string pLoginUserID)
        {
            List<Entity.GRNReport> lstObject = new List<Entity.GRNReport>();
            lstObject = new DAL.ReportSQL().GRNReport(ProductID, CustomerID, FromDate, ToDate, pLoginUserID);
            return lstObject;
        }

        //===========================================================================================================
        // Report Method Signature : Inward Report Vardhman
        // ===========================================================================================================

        //public static List<Entity.GRNReport> GRNReport(Int64 ProductID, Int64 CustomerID, DateTime FromDate, DateTime ToDate, string pLoginUserID)
        //{
        //    List<Entity.GRNReport> lstObject = new List<Entity.GRNReport>();
        //    lstObject = new DAL.ReportSQL().GRNReport(ProductID, CustomerID, FromDate, ToDate, pLoginUserID);
        //    return lstObject;
        //}

        //===========================================================================================================
        // Report Method Signature : JobCardOutward Report
        // ===========================================================================================================
        public static List<Entity.PackingListReport> PackingListReport(Int64 ProductID, Int64 CustomerID, DateTime FromDate, DateTime ToDate, string pLoginUserID)
        {
            List<Entity.PackingListReport> lstObject = new List<Entity.PackingListReport>();
            lstObject = new DAL.ReportSQL().PackingListReport(ProductID, CustomerID, FromDate, ToDate, pLoginUserID);
            return lstObject;
        }
        //===========================================================================================================
        // Report Method Signature : JobCard Report
        // ===========================================================================================================
        public static List<Entity.JobCardReport> JobcardList(Int64 ProductID, Int64 CustomerID, DateTime FromDate, Int64 Location, DateTime ToDate, string pLoginUserID)
        {
            List<Entity.JobCardReport> lstObject = new List<Entity.JobCardReport>();
            lstObject = new DAL.ReportSQL().JobCardList(ProductID, CustomerID, Location, FromDate, ToDate, pLoginUserID);
            return lstObject;
        }

        //==============================================================================================================
        // Report Method Signature : Visitor Management Report
        //==============================================================================================================

        public static List<Entity.VisitorReport> VisitorReport(Int64 pkID, string LoginUserID, string SearchKey, Int64 PageNo, Int64 PageSize, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.VisitorReport> lstObject = new List<Entity.VisitorReport>();
            lstObject = new DAL.ReportSQL().VisitorReportList(pkID, LoginUserID, SearchKey, PageNo, PageSize, FromDate, ToDate);
            return lstObject;
        }

        //==============================================================================================================
        // Report Method Signature : Inward Report For Vardhman
        //==============================================================================================================

        public static List<Entity.InwardReport> InwardReport(Int64 pkID, string LoginUserID, Int64 CustomerID, DateTime FromDate, DateTime ToDate, Int64 PageNo, Int64 PageSize)
        {
            List<Entity.InwardReport> lstObject = new List<Entity.InwardReport>();
            lstObject = new DAL.ReportSQL().InwardReportList(pkID, LoginUserID, CustomerID, FromDate, ToDate, PageNo, PageSize);
            return lstObject;
        }

        public static List<Entity.InwardOutwardReport> InwardOutwardReport(Int64 pkID, string LoginUserID, Int64 CustomerID, DateTime FromDate, DateTime ToDate, Int64 PageNo, Int64 PageSize)
        {
            List<Entity.InwardOutwardReport> lstObject = new List<Entity.InwardOutwardReport>();
            lstObject = new DAL.ReportSQL().InwardOutwardReportList(pkID, LoginUserID, CustomerID, FromDate, ToDate, PageNo, PageSize);
            return lstObject;
        }

        //====================================================================================================================
        //  Report Method Signature : Pending Bill Status
        //====================================================================================================================

        public static List<Entity.PendingBillReport> PendingBillListReport(string BillingCategory, string BillingStatus, string ByDateType, string AsOnDate, Int64 LM1, Int64 LM2, Int64 LM3, Int64 LM4, Int64 LM5, Int64 LM6)
        {
            List<Entity.PendingBillReport> lstObject = new List<Entity.PendingBillReport>();
            lstObject = new DAL.ReportSQL().PendingBillList(BillingCategory, BillingStatus, ByDateType, AsOnDate, LM1, LM2, LM3, LM4, LM5, LM6);
            return lstObject;
        }

        //====================================================================================================================
        // Report Methid Signature : Debit - Credit Note
        //====================================================================================================================

        public static List<Entity.DebitCreditNoteReport> DebitCreditNoteReport(string LoginUserID, Int64 CustomerID,DateTime FromDate, DateTime ToDate, Int64 PageNo, Int64 PageSize)
        {
            List<Entity.DebitCreditNoteReport> lstObject = new List<Entity.DebitCreditNoteReport>();
            lstObject = new DAL.ReportSQL().DebitCreditNote(LoginUserID, CustomerID,FromDate, ToDate, PageNo, PageSize);
            return lstObject;
        }

        //============================================================================================================
        // Report Method Signature : Telecaller Report
        //============================================================================================================

        public static List<Entity.ExternalLeads_Report> Report_TelecallerList(Int64 PageNo, Int64 PageSize, out int TotalRecord, DateTime FromDate, DateTime ToDate, Int64 ProductID, Int64 EmployeeID)
        {
            List<Entity.ExternalLeads_Report> lstObject = new List<Entity.ExternalLeads_Report>();
            lstObject = new DAL.ReportSQL().Report_TelecallerList(PageNo, PageSize, out TotalRecord, FromDate, ToDate, ProductID, EmployeeID);
            return lstObject;
        }

        //============================================================================================================
        // Report Method Signature : Daily Visitr Report
        //============================================================================================================

        public static List<Entity.ExternalLeadReport> ExternalLeadReport(Int64 PageNo, Int64 PageSize, out int TotalRecord, DateTime ToDate, DateTime FromDate, Int64 EmpID, string LeadStatus, Int64 Reason, Int64 DurationType)
        {
            List<Entity.ExternalLeadReport> lstObject = new List<Entity.ExternalLeadReport>();
            lstObject = new DAL.ReportSQL().Report_GetDailyVisiList(PageNo, PageSize, out TotalRecord,FromDate, ToDate, EmpID, LeadStatus, Reason, DurationType);
            return lstObject;   
        }

        //===========================================================================================================
        // Report Method Signature :  InstallFabric Report
        // ===========================================================================================================
        public static List<Entity.InstallFabricReport> InstallFabricReport(Int64 CustomerID, string InspectType, string LoginUserID)
        {
            List<Entity.InstallFabricReport> lstObject = new List<Entity.InstallFabricReport>();
            lstObject = new DAL.ReportSQL().InstallFabricReport(CustomerID, InspectType, LoginUserID);
            return lstObject;
        }
        // ===========================================================================================================
        // Report Method Signature : JobCard Inward Against Outward
        // ===========================================================================================================
        public static List<Entity.JobCardStatus> JobCardStatusList(string pViewType, Int64 pMonth, Int64 pYear, string pLoginUserID)
        {
            List<Entity.JobCardStatus> lstObject = new List<Entity.JobCardStatus>();
            lstObject = new DAL.ReportSQL().JobCardStatusList(pViewType, pMonth, pYear, pLoginUserID);
            return lstObject;
        }

        // ===========================================================================================================
        // Report Method Signature : Outward Report Vardhman
        // ===========================================================================================================

        public static List<Entity.OutwardReport> OutwardReport(Int64 pkID, Int64 CustomerID, string LoginUserID, DateTime FromDate, DateTime ToDate, Int64 PageNo, Int64 PageSize)
        {
            List<Entity.OutwardReport> lstObject = new List<Entity.OutwardReport>();
            lstObject = new DAL.ReportSQL().OutwardReportList(pkID,CustomerID, LoginUserID, FromDate, ToDate, PageNo, PageSize);
            return lstObject;
        }

        //===========================================================================================================
        // Report Method Signature : Material Movement Report
        // ===========================================================================================================
        public static List<Entity.MaterialMovementReport> MaterialMovementReport(Int64 ProductID, Int64 CustomerID, string TransType, DateTime FromDate, DateTime ToDate, string LoginUserID)
        {
            List<Entity.MaterialMovementReport> lstObject = new List<Entity.MaterialMovementReport>();
            lstObject = new DAL.ReportSQL().MaterialMovementReport(ProductID, CustomerID, TransType, FromDate, ToDate, LoginUserID);
            return lstObject;
        }
        //===========================================================================================================
        // Report Method Signature : JobCardOutward Report
        // ===========================================================================================================
        public static List<Entity.JobCardInwardReport> JobCardInwardReport(Int64 ProductID, Int64 CustomerID, DateTime FromDate, DateTime ToDate, string pLoginUserID)
        {
            List<Entity.JobCardInwardReport> lstObject = new List<Entity.JobCardInwardReport>();
            lstObject = new DAL.ReportSQL().JobCardInwardReport(ProductID, CustomerID, FromDate, ToDate, pLoginUserID);
            return lstObject;
        }


        //===========================================================================================================
        // Report Method Signature : JobCardOutward Report
        // ===========================================================================================================
        public static List<Entity.JobCardOutwardReport> JobCardOutwardReport(Int64 ProductID,Int64 CustomerID,DateTime FromDate,DateTime ToDate, string pLoginUserID)
        {
            List<Entity.JobCardOutwardReport> lstObject = new List<Entity.JobCardOutwardReport>();
            lstObject = new DAL.ReportSQL().JobCardOutwardReport(ProductID,CustomerID,FromDate,ToDate, pLoginUserID);
            return lstObject;
        }

        // ===========================================================================================================
        // Report Method Signature : Complaint Report For ABhishek
        // ===========================================================================================================
        public static List<Entity.ReportWithSign> ComplainWithSign(Int64 CustomerID,string pLoginUserID)
        {
            List<Entity.ReportWithSign> lstObject = new List<Entity.ReportWithSign>();
            lstObject = new DAL.ReportSQL().ComplainWithSign(CustomerID,pLoginUserID);
            return lstObject;
        }

        // ===========================================================================================================
        // Report Method Signature : TODO Report
        // ===========================================================================================================
        public static List<Entity.ToDo> ToDoReport(DateTime FromDate, DateTime ToDate,Int64 EmployeeID,string TaskStatus, string pLoginUserID, Int64 PageNo, Int64 PageSize,string Priority)
        {
            List<Entity.ToDo> lstObject = new List<Entity.ToDo>();
            lstObject = new DAL.ReportSQL().TODoList(FromDate, ToDate,EmployeeID,TaskStatus, pLoginUserID, PageNo, PageSize, Priority);
            return lstObject;
        }

        // ===========================================================================================================
        // Report Method Signature : Complaint Report
        // ===========================================================================================================
        public static List<Entity.CompliantReport> ComplaintReport(string ComplaintStatus, Int64 EmplyeeID, DateTime FromDate, DateTime ToDate, string pLoginUserID)
        {
            List<Entity.CompliantReport> lstObject = new List<Entity.CompliantReport>();
            lstObject = new DAL.ReportSQL().Complaint(ComplaintStatus, EmplyeeID, FromDate, ToDate, pLoginUserID);
            return lstObject;
        }


        // ===========================================================================================================
        // Report Method Signature : Salary Register Report
        // ===========================================================================================================
        public static List<Entity.SalaryRegister> SalaryRegister(Int64 EmployeeID,string Month, string Year, string pLoginUserID)
        {
            List<Entity.SalaryRegister> lstObject = new List<Entity.SalaryRegister>();
            lstObject = new DAL.ReportSQL().SalaryRegister(EmployeeID,Month, Year,pLoginUserID);
            return lstObject;
        }


        // ===============================================================================================
        // Report Method Signature : Purchase Monthly Report
        // ===============================================================================================
        public static List<Entity.MonthlyPurchase> MonthlyPurchaseList(string Type, DateTime FromDt, DateTime ToDt, string pLoginUserID)
        {
            List<Entity.MonthlyPurchase> lstObject = new List<Entity.MonthlyPurchase>();
            lstObject = new DAL.ReportSQL().MonthlyPurchaseList(Type, FromDt, ToDt, pLoginUserID);
            return lstObject;
        }

        // ===========================================================================================================
        // Report Method Signature : Monthly Sales Report
        // ===========================================================================================================
        public static List<Entity.MonthlySalesSummary> Report_MonthlySalesSummary(String Type, DateTime d3, DateTime d4, String LoginUserID)
        {
            List<Entity.MonthlySalesSummary> lstObject = new List<Entity.MonthlySalesSummary>();
            lstObject = new DAL.ReportSQL().Report_MonthlySalesSummary(Type, d3, d4, LoginUserID);
            return lstObject;
        }

        // ===========================================================================================================
        // Report Method Signature : Location / Product Wise Stock 
        // ===========================================================================================================
        public static List<Entity.Location> LocationProductStockList(string pViewType, Int64 LocationID, Int64 ProductID, string pLoginUserID)
        {
            List<Entity.Location> lstObject = new List<Entity.Location>();
            lstObject = new DAL.ReportSQL().LocationProductStockList(pViewType, LocationID, ProductID, pLoginUserID);
            return lstObject;
        }

        // ===========================================================================================================
        // Report Method Signature : Purchase Order (Material Receive Against our PO) Material Recived Status Report
        // ===========================================================================================================
        public static List<Entity.DispatchStatus> SupplierMaterialStatusList(string pViewType, Int64 pMonth, Int64 pYear, string pLoginUserID)
        {
            List<Entity.DispatchStatus> lstObject = new List<Entity.DispatchStatus>();
            lstObject = new DAL.ReportSQL().SupplierMaterialStatusList(pViewType,pMonth, pYear, pLoginUserID);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : Dispatch Status Report
        // ===============================================================================================
        public static List<Entity.DispatchStatus> DispatchStatusList(string pViewType, Int64 pMonth, Int64 pYear, string pLoginUserID)
        {
            List<Entity.DispatchStatus> lstObject = new List<Entity.DispatchStatus>();
            lstObject = new DAL.ReportSQL().DispatchStatusList(pViewType, pMonth, pYear, pLoginUserID);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : Product Min.Stock
        // ===============================================================================================
        public static List<Entity.Products> ProductMinStockList(string BrandID, string ProductGroupID, string pLoginUserID)
        {
            List<Entity.Products> lstObject = new List<Entity.Products>();
            lstObject = new DAL.ReportSQL().ProductMinStockList(BrandID, ProductGroupID, pLoginUserID);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : Sales Register
        // ===============================================================================================
        public static List<Entity.SalesReport> Report_SalesReg(String pLoginUserID, String pBrand, String pProductGroup, Int64 CustomerId, DateTime pFromDate, DateTime pToDate)
        {
            List<Entity.SalesReport> lstObject = new List<Entity.SalesReport>();
            lstObject = new DAL.ReportSQL().Report_SalesReg(pLoginUserID, pBrand, pProductGroup, CustomerId, pFromDate, pToDate);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : Sales Order Detailed Report
        // ===============================================================================================
        public static List<Entity.SODetailedReport> Report_SODetailed(String pLoginUserID, Int64 ProductID, Int64 CustomerId, DateTime pFromDate, DateTime pToDate)
        {
            List<Entity.SODetailedReport> lstObject = new List<Entity.SODetailedReport>();
            lstObject = new DAL.ReportSQL().Report_SODetailed(pLoginUserID, ProductID, CustomerId, pFromDate, pToDate);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : StateWise Sales Register
        // ===============================================================================================
        public static List<Entity.SalesReport> Report_StateWiseSalesReg(String pLoginUserID, Int64 City, Int64 State, Int64 CustomerId, DateTime pFromDate, DateTime pToDate)
        {
            List<Entity.SalesReport> lstObject = new List<Entity.SalesReport>();
            lstObject = new DAL.ReportSQL().Report_StateWiseSalesReg(pLoginUserID, City, State, CustomerId, pFromDate, pToDate);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : state wise Purchase Register Report
        // ===============================================================================================
        public static List<Entity.PurchaseReport> Report_StateWisePurReg(String pLoginUserID, Int64 City, Int64 State, Int64 CustomerId, DateTime pFromDate, DateTime pToDate)
        {
            List<Entity.PurchaseReport> lstObject = new List<Entity.PurchaseReport>();
            lstObject = new DAL.ReportSQL().Report_StateWisePurReg(pLoginUserID, City, State, CustomerId, pFromDate, pToDate);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : Purchase Register Report
        // ===============================================================================================
        public static List<Entity.PurchaseReport> PurchaseReportList(string pLoginUserID, string BrandID, string ProductGroupId, Int64 CustomerId,DateTime FromDate,DateTime ToDate)
        {
            List<Entity.PurchaseReport> lstObject = new List<Entity.PurchaseReport>();
            lstObject = new DAL.ReportSQL().PurchaseReportList(pLoginUserID, BrandID, ProductGroupId, CustomerId,FromDate,ToDate);
            return lstObject;
        }
        // ===============================================================================================
        // Report Method Signature : Vehicle Master Report
        // ===============================================================================================
        public static List<Entity.VehicleList> VehicleList(string pLoginUserID)
        {
            List<Entity.VehicleList> lstObject = new List<Entity.VehicleList>();
            lstObject = new DAL.ReportSQL().VehicleList(pLoginUserID);
            return lstObject;
        }
        // ===============================================================================================
        // Report Method Signature : Shift Report
        // ===============================================================================================
        public static List<Entity.ShiftReport> ShiftReportList(Int64 ShiftCode, string BasicPer, string pLoginUserID)
        {
            List<Entity.ShiftReport> lstObject = new List<Entity.ShiftReport>();
            lstObject = new DAL.ReportSQL().ShiftReportList(ShiftCode, BasicPer, pLoginUserID);
            return lstObject;
        }
        // ===============================================================================================
        // Report Method Signature : CashBook Report
        // ===============================================================================================
        public static List<Entity.CashBook> Report_CashBook(String pLoginUserID, DateTime pFromDate, DateTime pToDate, Int64 Ac, String nt)
        {
            List<Entity.CashBook> lstObject = new List<Entity.CashBook>();
            lstObject = new DAL.ReportSQL().Report_CashBook(pLoginUserID, pFromDate, pToDate, Ac, nt);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : BankBook Report
        // ===============================================================================================
        public static List<Entity.BankBook> Report_BankBook(String pLoginUserID, DateTime pFromDate, DateTime pToDate, Int64 Ac, String nt)
        {
            List<Entity.BankBook> lstObject = new List<Entity.BankBook>();
            lstObject = new DAL.ReportSQL().Report_BankBook(pLoginUserID, pFromDate, pToDate, Ac, nt);
            return lstObject;
        }
        //====================================================================
        //Report Method Signature : BankVoucher Report
        //====================================================================

        public static List<Entity.BankVoucher> Report_BankVoucher(string LoginUserID, Int64 CustomerID,Int64 Credit,DateTime FromDate, DateTime ToDate)
        {
            List<Entity.BankVoucher> lstObject = new List<Entity.BankVoucher>();
            lstObject = new DAL.ReportSQL().GetBankVoucher(LoginUserID, CustomerID, Credit, FromDate, ToDate);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : JV Report
        // ===============================================================================================
        public static List<Entity.JournalVoucherReport> Report_JV(String pLoginUserID, DateTime pFromDate, DateTime pToDate)
        {
            List<Entity.JournalVoucherReport> lstObject = new List<Entity.JournalVoucherReport>();
            lstObject = new DAL.ReportSQL().Report_JV(pLoginUserID, pFromDate, pToDate);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : DBNote Report
        // ===============================================================================================
        public static List<Entity.DBNote> DBNote(string pLoginUserID, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.DBNote> lstObject = new List<Entity.DBNote>();
            lstObject = new DAL.ReportSQL().DBNote(pLoginUserID, FromDate, ToDate);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : CRNote Report
        // ===============================================================================================
        public static List<Entity.CRNote> CRNote(string pLoginUserID, DateTime FromDate, DateTime ToDate, Int64 PageNo, Int64 PageSize)
        {
            List<Entity.CRNote> lstObject = new List<Entity.CRNote>();
            lstObject = new DAL.ReportSQL().CRNote(pLoginUserID, FromDate, ToDate, PageNo, PageSize);
            return lstObject;
        }
        public static List<Entity.PettyCashReport> PettyCashReportList(string pLoginUserID, DateTime FromDate, DateTime ToDate, Int64 FixedLedger)
        {
            List<Entity.PettyCashReport> lstObject = new List<Entity.PettyCashReport>();
            lstObject = new DAL.ReportSQL().PettyCashReport(FromDate, ToDate, pLoginUserID, FixedLedger);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : Trial Balance Report
        // ===============================================================================================
        public static List<Entity.TrialBalanceReport> TrialBalanceReportList(string DBCR, string pLoginUserID)
        {
            List<Entity.TrialBalanceReport> lstObject = new List<Entity.TrialBalanceReport>();
            lstObject = new DAL.ReportSQL().TrialBalanceReportList(DBCR, pLoginUserID);
            return lstObject;
        }


        // ===============================================================================================
        // Report Method Signature : Product Stock Report
        // ===============================================================================================
        public static List<Entity.ProductStockReport> ProductStockReportList(string pLoginUserID, string ProductGroupName, string BrandName, Int64 ProductID)
        {
            List<Entity.ProductStockReport> lstObject = new List<Entity.ProductStockReport>();
            lstObject = new DAL.ReportSQL().ProductStockReportList(pLoginUserID, ProductGroupName, BrandName, ProductID);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : Rojmel
        // ===============================================================================================
        public static List<Entity.Rojmel> Report_Rojmel(DateTime pFronmDate, DateTime pToDate, String pLoginUserID)
        {
            List<Entity.Rojmel> lstObject = new List<Entity.Rojmel>();
            lstObject = new DAL.ReportSQL().Report_Rojmel(pFronmDate, pToDate, pLoginUserID);
            return lstObject;
        }
        
        // ===============================================================================================
        // Report Method Signature : Stock
        // ===============================================================================================
        public static List<Entity.ProductStockReport> Report_Stock( String pLoginUserID, DateTime pToDate)
        {
            List<Entity.ProductStockReport> lstObject = new List<Entity.ProductStockReport>();
            lstObject = new DAL.ReportSQL().Report_Stock(pLoginUserID, pToDate);
            return lstObject;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Fleet Management Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public static List<Entity.VehicleTrip> Report_Trip(DateTime pFromDate, DateTime pToDate, String pLoginUserID, Int64 EmployeeID, Int64 VehicleID)
        {
            List<Entity.VehicleTrip> lstObject = new List<Entity.VehicleTrip>();
            lstObject = new DAL.ReportSQL().Report_Trip(pFromDate, pToDate, pLoginUserID, EmployeeID, VehicleID);
            return lstObject;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // METHOD SIGNATURE FOR : Trip By Driver Report 
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public static List<Entity.VehicleTrip> Report_TripByDriver(DateTime pFromDate, DateTime pToDate, String pLoginUserID, Int64 EmployeeID, Int64 VehicleID)
        {
            List<Entity.VehicleTrip> lstObject = new List<Entity.VehicleTrip>();
            lstObject = new DAL.ReportSQL().Report_Trip(pFromDate, pToDate, pLoginUserID, EmployeeID, VehicleID);
            return lstObject;
        }

        //// *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //// Fleet Management Reports
        //// *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //public static List<Entity.VehicleTrip> Report_Trip(DateTime pFromDate, DateTime pToDate, String pLoginUserID)
        //{
        //    List<Entity.VehicleTrip> lstObject = new List<Entity.VehicleTrip>();
        //    lstObject = new DAL.ReportSQL().Report_Trip(pFromDate, pToDate, pLoginUserID);
        //    return lstObject;
        //}

        // ===============================================================================================
        // Report Method Signature : Inquiry Master List 
        // ===============================================================================================
        public static List<Entity.InquiryInfo> Report_InquiryList(String pReportType, DateTime pFromDate, DateTime pToDate, string pLoginUserID, string pInquirySource, string pInquiryStatus)
        {
            List<Entity.InquiryInfo> lstObject = new List<Entity.InquiryInfo>();
            lstObject = new DAL.ReportSQL().Report_InquiryList(pReportType, pFromDate, pToDate, pLoginUserID, pInquirySource, pInquiryStatus);
            return lstObject;
        }
        public static List<Entity.InquiryInfo_Report> Report_InquiryList_Report(String pReportType, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string pLoginUserID, string pInquirySource, string pInquiryStatus, int EmployeeID, Int64 CustomerID,string pStateCode, string pCityCode, Int64 ProductID)
        {
            List<Entity.InquiryInfo_Report> lstObject = new List<Entity.InquiryInfo_Report>();
            lstObject = new DAL.ReportSQL().Report_InquiryList_Report(pReportType, pFromDate, pToDate, pLoginUserID, pInquirySource, pInquiryStatus, EmployeeID,CustomerID, pStateCode, pCityCode, ProductID);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : Inquiry Master List 
        // ===============================================================================================
        public static List<Entity.Quotation> Report_QuotationList(String pReportType, DateTime pFromDate, DateTime pToDate, string pLoginUserID)
        {
            List<Entity.Quotation> lstObject = new List<Entity.Quotation>();
            lstObject = new DAL.ReportSQL().Report_QuotationList(pReportType, pFromDate, pToDate, pLoginUserID);
            return lstObject;
        }
        public static List<Entity.Quotation> Report_QuotationList_Report(String pReportType, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string pLoginUserID, int EmployeeID, Int64 pCustomerID, String BasedCountry)
        {
            List<Entity.Quotation> lstObject = new List<Entity.Quotation>();
            lstObject = new DAL.ReportSQL().Report_QuotationList_Report(pReportType, pFromDate, pToDate, pLoginUserID, EmployeeID,pCustomerID, BasedCountry);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : Inquiry Master List // here
        // ===============================================================================================
        public static List<Entity.VedantQuotation> VedantQuotationList_Report(DateTime pFromDate, DateTime pToDate, string pLoginUserID, String BasedCountry)
        {
            List<Entity.VedantQuotation> lstObject = new List<Entity.VedantQuotation>();
            lstObject = new DAL.ReportSQL().VedantQuotationList_Report(pFromDate, pToDate, pLoginUserID,BasedCountry);
            return lstObject;
        }
        // ===============================================================================================
        // Report Method Signature : Inquiry Master List 
        // ===============================================================================================
        public static List<Entity.SalesOrder> Report_SalesOrderList(String pReportType, DateTime pFromDate, DateTime pToDate, string pLoginUserID)
        {
            List<Entity.SalesOrder> lstObject = new List<Entity.SalesOrder>();
            lstObject = new DAL.ReportSQL().Report_SalesOrderList(pReportType, pFromDate, pToDate, pLoginUserID);
            return lstObject;
        }
        public static List<Entity.SalesOrder> Report_SalesOrderList_Report(String pReportType, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string pLoginUserID, int EmployeeID, Int64 pCustomerID, string ApprovalStatus)
        {
            List<Entity.SalesOrder> lstObject = new List<Entity.SalesOrder>();
            lstObject = new DAL.ReportSQL().Report_SalesOrderList_Report(pReportType, pFromDate, pToDate, pLoginUserID, EmployeeID,pCustomerID,ApprovalStatus);
            return lstObject;
        }
        // ===============================================================================================
        // Report Method Signature : Purchase Order List 
        // ===============================================================================================
        public static List<Entity.PurchaseOrder> Report_PurchaseOrderList_Report(String pReportType, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string pLoginUserID, int EmployeeID, Int64 pCustomerID, string ApprovalStatus)//,Int64 ProjectName)
        {
            List<Entity.PurchaseOrder> lstObject = new List<Entity.PurchaseOrder>();
            lstObject = new DAL.ReportSQL().Report_PurchaseOrderList_Report(pReportType, pFromDate, pToDate, pLoginUserID, EmployeeID, pCustomerID, ApprovalStatus);//, ProjectName);
            return lstObject;
        }
        // ===============================================================================================
        // Report Method Signature : City Master List 
        // ===============================================================================================

        public static List<Entity.City> Report_CityMasterList()
        {
            List<Entity.City> lstObject = new List<Entity.City>();
            lstObject = new DAL.ReportSQL().Report_CityMasterList();
            return lstObject;
        }
        public static List<Entity.Attendance_Report> GetEmployeeTracking_Report(Int64 EmployeeID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate)
        {
            List<Entity.Attendance_Report> lstObject = new List<Entity.Attendance_Report>();
            lstObject = new DAL.ReportSQL().GetEmployeeTracking_Report(EmployeeID, Fromdate, Todate);
            return lstObject;
        }
        // ===============================================================================================
        // Report Method Signature : Client Master List 
        // ===============================================================================================
        public static List<Entity.Customer> Report_CustomerMasterList(string pLoginUserID, Int64 EmployeeID, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string CustomerStatus, string CustomerType, Int64 StateCode, Int64 CityCode)
        {
            List<Entity.Customer> lstObject = new List<Entity.Customer>();
            lstObject = new DAL.ReportSQL().Report_CustomerMasterList(pLoginUserID,EmployeeID,pFromDate,pToDate,CustomerStatus,CustomerType,StateCode,CityCode);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : Customer Ledger
        // ===============================================================================================
        public static List<Entity.FinancialTrans> Report_CustomerLedger(string TransCategory, string LoginUserID)
        {
            List<Entity.FinancialTrans> lstObject = new List<Entity.FinancialTrans>();
            lstObject = new DAL.ReportSQL().Report_CustomerLedger(TransCategory, LoginUserID);
            return lstObject;
        }

        public static List<Entity.FinancialTrans> Report_CustomerLedger_Rpt(string TransCategory, string LoginUserID)
        {
            List<Entity.FinancialTrans> lstObject = new List<Entity.FinancialTrans>();
            lstObject = new DAL.ReportSQL().Report_CustomerLedger(TransCategory, LoginUserID);
            return lstObject;
        }

        public static List<Entity.FinancialTrans> Report_GetFinancialTransection(string TransCategory, string LoginUserID,Nullable<DateTime> pFromDate,Nullable<DateTime> pToDate)
        {
            List<Entity.FinancialTrans> lstObject = new List<Entity.FinancialTrans>();
            lstObject = new DAL.ReportSQL().Report_GetFinancialTransection(TransCategory, LoginUserID,pFromDate,pToDate);
            return lstObject;
        }
        // ===============================================================================================
        // Report Method Signature : Designations Master List 
        // ===============================================================================================
        public static List<Entity.Designations> Report_DesignationsMasterList()
        {
            List<Entity.Designations> lstObject = new List<Entity.Designations>();
            lstObject = new DAL.ReportSQL().Report_DesignationsMasterList();
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : OrganizationStructure Master List 
        // ===============================================================================================
        public static List<Entity.OrganizationStructure> Report_OrganizationStructureMasterList()
        {
            List<Entity.OrganizationStructure> lstObject = new List<Entity.OrganizationStructure>();
            lstObject = new DAL.ReportSQL().Report_OrganizationStructureMasterList();
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : OrganizationEmployee Master List 
        // ===============================================================================================
        public static List<Entity.OrganizationEmployee> Report_OrganizationEmployeeMasterList(DateTime FromDate, DateTime ToDate, Int32 EmployeeID)
        {
            List<Entity.OrganizationEmployee> lstObject = new List<Entity.OrganizationEmployee>();
            lstObject = new DAL.ReportSQL().Report_OrganizationEmployeeMasterList(FromDate, ToDate, EmployeeID);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : OrgTypes Master List 
        // ===============================================================================================
        public static List<Entity.OrgTypes> Report_OrgTypesMasterList()
        {
            List<Entity.OrgTypes> lstObject = new List<Entity.OrgTypes>();
            lstObject = new DAL.ReportSQL().Report_OrgTypesMasterList();
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : State Master List 
        // ===============================================================================================
        public static List<Entity.State> Report_StateMasterList()
        {
            List<Entity.State> lstObject = new List<Entity.State>();
            lstObject = new DAL.ReportSQL().Report_StateMasterList();
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : Users Master List 
        // ===============================================================================================
        public static List<Entity.Users_Report> Report_UsersMasterList(Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string pLoginUserID)
        {
            List<Entity.Users_Report> lstObject = new List<Entity.Users_Report>();
            lstObject = new DAL.ReportSQL().Report_UsersMasterList(pFromDate, pToDate,pLoginUserID);
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : Roles Master List 
        // ===============================================================================================
        public static List<Entity.Roles> Report_RolesMasterList()
        {
            List<Entity.Roles> lstObject = new List<Entity.Roles>();
            lstObject = new DAL.ReportSQL().Report_RolesMasterList();
            return lstObject;
        }

        // ===============================================================================================
        // Report Method Signature : Brand Master List 
        // ===============================================================================================
        public static List<Entity.Brand> Report_GetBrandList()
        {
            List<Entity.Brand> lstEntity = new List<Entity.Brand>();
            lstEntity = new DAL.ReportSQL().GetBrandList();
            return lstEntity;
        }

        // ===============================================================================================
        // Report Method Signature : product Master List 
        // ===============================================================================================
        public static List<Entity.Products> Report_GetProductList()
        {
            List<Entity.Products> lstEntity = new List<Entity.Products>();
            lstEntity = new DAL.ReportSQL().GetProductList();
            return lstEntity;
        }

        // ===============================================================================================
        // Report Method Signature : Product Group Master List 
        // ===============================================================================================
        public static List<Entity.ProductGroup> Report_GetProductGroupList()
        {
            List<Entity.ProductGroup> lstEntity = new List<Entity.ProductGroup>();
            lstEntity = new DAL.ReportSQL().GetProductGroupList();
            return lstEntity;
        }

        // ===============================================================================================
        // Report Method Signature : Brand Wise ProductGroup Wise Product List 
        // ===============================================================================================
        public static List<Entity.Products> Report_GetBrandWiseProductGroupWiseProductList(string pProductGroupId, string pBrandId)
        {
            List<Entity.Products> lstEntity = new List<Entity.Products>();
            lstEntity = new DAL.ReportSQL().GetBrandWiseProductGroupWiseProductList(pProductGroupId, pBrandId);
            return lstEntity;
        }

        // ===============================================================================================
        // Report Method Signature : FollowUp Master List 
        // ===============================================================================================
        public static List<Entity.Followup> Report_followup(String pReportType, DateTime pFromDate,DateTime pToDate, string pLoginUserID, string pCustomerID, string pEmployeeID)
        {
            List<Entity.Followup> lstObject = new List<Entity.Followup>();
            lstObject = new DAL.ReportSQL().GetFollowupList(pReportType, pFromDate, pToDate, pLoginUserID, pCustomerID, pEmployeeID);
            return lstObject;
        }

        public static List<Entity.Followup> Report_Getfollowup(String pReportType, DateTime pFromDate, DateTime pToDate, string pLoginUserID, string pCustomerID, string pEmployeeID, string pInquirySource, string pInquiryStatus, string InqTele)
        {
            List<Entity.Followup> lstObject = new List<Entity.Followup>();
            lstObject = new DAL.ReportSQL().GetFollowupList_Report(pReportType, pFromDate, pToDate, pLoginUserID, pCustomerID, pEmployeeID, pInquirySource, pInquiryStatus, InqTele);
            return lstObject;
        }

        public static List<Entity.PurchaseOrderByProjectList> ProjectWise_Report(String ReportType, Int64 ProjectName, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.PurchaseOrderByProjectList> lstobject = new List<Entity.PurchaseOrderByProjectList>();
            lstobject = new DAL.ReportSQL().GetProjectWise_Report(ReportType, ProjectName, FromDate, ToDate);
            return lstobject;
        }

        // ===============================================================================================
        // Report Method Signature : SalesTarget List 
        // ===============================================================================================
        public static List<Entity.SalesTarget> Report_SalesTarget(DateTime pFromDate, DateTime pToDate, string pLoginUserID)
        {
            List<Entity.SalesTarget> lstObject = new List<Entity.SalesTarget>();
            lstObject = new DAL.ReportSQL().GetSalesTargetList(pFromDate, pToDate, pLoginUserID);
            return lstObject;
        }

        public static List<Entity.SalesTarget> Report_SalesTarget_Report(Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string pLoginUserID, int pEmployeeID)
        {
            List<Entity.SalesTarget> lstObject = new List<Entity.SalesTarget>();
            lstObject = new DAL.ReportSQL().GetSalesTargetList_Report(pFromDate, pToDate, pLoginUserID, pEmployeeID);
            return lstObject;
        }
        //public static List<Entity.Roles> Report_RolesMasterList()
        //{
        //    List<Entity.Roles> lstObject = new List<Entity.Roles>();
        //    lstObject = new DAL.ReportSQL().Report_RolesMasterList();
        //    return lstObject;
        //}

        public static List<Entity.Attendance_Report> GetAttendanceList_Report(Int64 pkID, string UserID, Int64 EmployeeID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate)
        {
            List<Entity.Attendance_Report> lstObject = new List<Entity.Attendance_Report>();
            lstObject = new DAL.ReportSQL().GetAttendanceList_Report(pkID, UserID, EmployeeID, Fromdate, Todate);
            return lstObject;
        }
        public static List<Entity.Attendance_Report> GetAttendanceList_Report_New(Int64 pkID, string UserID, Int64 EmployeeID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate,String SerialKey)
        {
            List<Entity.Attendance_Report> lstObject = new List<Entity.Attendance_Report>();
            lstObject = new DAL.ReportSQL().GetAttendanceList_Report_New(pkID, UserID, EmployeeID, Fromdate, Todate,SerialKey);
            return lstObject;
        }


        public static List<Entity.DailyActivity> Report_GetDailyActivityListByUser(string LoginUserID, Int64 EmployeeID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, Int64 TaskCategory)
        {
            List<Entity.DailyActivity> lstObject = new List<Entity.DailyActivity>();
            lstObject = new DAL.ReportSQL().Report_GetDailyActivityListByUser(LoginUserID, EmployeeID, Fromdate, Todate, TaskCategory);
            return lstObject;
        }

        public static List<Entity.Complaint_Report> Report_GetComplaintList(Int64 pkID, Int64 CustomerID, string ComplaintStatus, string LoginUserID, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, Int64 EmployeeID, Int64 AssignToEmployeeID)
        {
            List<Entity.Complaint_Report> lstObject = new List<Entity.Complaint_Report>();
            lstObject = new DAL.ReportSQL().Report_GetComplaintList(pkID, CustomerID, ComplaintStatus, LoginUserID,pFromDate,pToDate,EmployeeID,AssignToEmployeeID);
            return lstObject;

        }

        public static List<Entity.LeaveRequest> Report_GetLeaveRequestListByUser(string pLoginUserID, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, Int64 EmployeeID, string LeaveStatus)
        {
            List<Entity.LeaveRequest> lstObject = new List<Entity.LeaveRequest>();
            lstObject = new DAL.ReportSQL().Report_GetLeaveRequestListByUser(pLoginUserID, pFromDate, pToDate, EmployeeID,LeaveStatus);
            return lstObject;
        }

        public static List<Entity.Expense_Report> Report_GetExpenseList(string LoginUserID, Int64 EmployeeID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, Int64 ExpenseTypeID)
        {
            List<Entity.Expense_Report> lstObject = new List<Entity.Expense_Report>();
            lstObject = new DAL.ReportSQL().Report_GetExpenseList(LoginUserID, EmployeeID,Fromdate,Todate,ExpenseTypeID);
            return lstObject;
        }

        public static List<Entity.ExpenseVoucher_Report> Report_GetExpenseVoucherList(string LoginUserID, Int64 EmployeeID, DateTime Fromdate, DateTime Todate)
        {
            List<Entity.ExpenseVoucher_Report> lstObject = new List<Entity.ExpenseVoucher_Report>();
            lstObject = new DAL.ReportSQL().Report_GetExpenseVoucherList(LoginUserID, EmployeeID, Fromdate, Todate);
            return lstObject;
        }

        public static List<Entity.ExternalLeads_Report> Report_GetExternalLeadList(int PageNo, int PageSize, out int TotalRecord, Nullable<DateTime> Todate, Nullable<DateTime> Fromdate, Int64 EmployeeID, string LeadStatus, Int64 Reason, Int64 DurationType)
        {
            List<Entity.ExternalLeads_Report> lstObject = new List<Entity.ExternalLeads_Report>();
            lstObject = new DAL.ReportSQL().Report_GetExternalLeadList( PageNo, PageSize, out TotalRecord, Todate, Fromdate, EmployeeID, LeadStatus, Reason,DurationType);
            return lstObject;
        }
        public static List<Entity.ExternalLeads_Report> Report_GetTelecallerInquiryList(int PageNo, int PageSize, out int TotalRecord, Nullable<DateTime> Todate, Nullable<DateTime> Fromdate, Int64 EmployeeID, string LeadStatus, Int64 Reason, string InqTele)
        {
            List<Entity.ExternalLeads_Report> lstObject = new List<Entity.ExternalLeads_Report>();
            lstObject = new DAL.ReportSQL().Report_GetTelecallerInquiryList(PageNo, PageSize, out TotalRecord, Todate, Fromdate, EmployeeID, LeadStatus, Reason, InqTele);
            return lstObject;
        }
        public static List<Entity.ExternalLeads_Report> Report_MonthlyWorking(int PageNo, int PageSize, out int TotalRecord, Nullable<DateTime> Todate, Nullable<DateTime> Fromdate, Int64 EmployeeID, string LeadStatus, Int64 Reason, string InqTele)
        {
            List<Entity.ExternalLeads_Report> lstObject = new List<Entity.ExternalLeads_Report>();
            lstObject = new DAL.ReportSQL().Report_MonthlyWorking(PageNo, PageSize, out TotalRecord, Todate, Fromdate, EmployeeID, LeadStatus, Reason, InqTele);
            return lstObject;
        }

        public static String GetUserIDByEmployeeID(Int64 EmployeeID)
        {
            string UserID = "";
            UserID = new DAL.ReportSQL().GetUserIDByEmployeeID(EmployeeID);
            return UserID;
        }

        public static List<Entity.SalesBillReport> Report_GetSalesBillList(Int64 pkID, string LoginUserID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, string CustomerID, string LocationID, int PageNo, int PageSize, out int TotalRecord)
        {
            List<Entity.SalesBillReport> lstObject = new List<Entity.SalesBillReport>();
            lstObject = new DAL.ReportSQL().Report_GetSalesBillList(pkID, LoginUserID, Fromdate, Todate, CustomerID, LocationID, PageNo, PageSize, out TotalRecord);
            return lstObject;
        }

        public static List<Entity.SalesBillDetail_Report> Report_GetSalesBillDetailList(string LoginUserID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, string pCustomerID)
        {
            List<Entity.SalesBillDetail_Report> lstObject = new List<Entity.SalesBillDetail_Report>();
            lstObject = new DAL.ReportSQL().Report_GetSalesBillDetailList(LoginUserID, Fromdate, Todate, pCustomerID);
            return lstObject;
        }

        public static List<Entity.PurchaseBill> Report_GetPurchaseBillList(String LoginUserID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, Int64 CustomerID,String EmployeeID)
        {
            List<Entity.PurchaseBill> lstObject = new List<Entity.PurchaseBill>();
            lstObject = new DAL.ReportSQL().Report_GetPurchaseBillList(LoginUserID, Fromdate, Todate, CustomerID,EmployeeID);
            return lstObject;
        }
       
        public static List<Entity.PurchaseBillDetail_Report> Report_GetPurchaseBillDetailList(string LoginUserID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, Int64 CustomerID,Int64 EmployeeID) 
        {
            List<Entity.PurchaseBillDetail_Report> lstObject = new List<Entity.PurchaseBillDetail_Report>();
            lstObject = new DAL.ReportSQL().Report_GetPurchaseBillDetailList(LoginUserID, Fromdate, Todate, CustomerID,EmployeeID);
            return lstObject;
        }
       
        public static List<Entity.Customer> Report_GetCustomerDetailLedgerList(Int64 CustomerID, string pLoginUserID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate)
        {
            List<Entity.Customer> lstObject = new List<Entity.Customer>();
            lstObject = new DAL.ReportSQL().Report_GetCustomerDetailLedgerList(CustomerID, pLoginUserID, Fromdate, Todate);
            return lstObject;
        }
        // ===========================================================================================================
        // Report Method Signature : Employee wise material Movement Report
        // ===========================================================================================================
        public static List<Entity.EmpWiseMatMovement> EmpMovementRegister(string pLoginUserID, DateTime FromDate, DateTime ToDate,Int64 EmployeeID)
        {
            List<Entity.EmpWiseMatMovement> lstObject = new List<Entity.EmpWiseMatMovement>();
            lstObject = new DAL.ReportSQL().EmpMovementRegister(pLoginUserID, FromDate, ToDate, EmployeeID);
            return lstObject;
        }

        // ===========================================================================================================
        // Report Method Signature : Quotation List By Project List Report
        // ===========================================================================================================
        public static List<Entity.PurchaseOrderByProjectList> QuotationByProjectlist(Int64 Project, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.PurchaseOrderByProjectList> lstObject = new List<Entity.PurchaseOrderByProjectList>();
            lstObject = new DAL.ReportSQL().Report_QuotationFromProjectList(Project, FromDate, ToDate);
            return lstObject;
        }
        // ===========================================================================================================
        // Report Method Signature : SalesOrder List By Project List Report
        // ===========================================================================================================
        public static List<Entity.PurchaseOrderByProjectList> SalesOrderByProjectList(Int64 Project, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.PurchaseOrderByProjectList> lstObject = new List<Entity.PurchaseOrderByProjectList>();
            lstObject = new DAL.ReportSQL().Report_SalesOrderFromProjectList(Project, FromDate, ToDate);
            return lstObject;
        }
        // ===========================================================================================================
        // Report Method Signature : Purchase Order List By Project List Report
        // ===========================================================================================================
        public static List<Entity.PurchaseOrderByProjectList> PurchaseOrderByProjectList(Int64 Project, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.PurchaseOrderByProjectList> lstObject = new List<Entity.PurchaseOrderByProjectList>();
            lstObject = new DAL.ReportSQL().Report_PurchaseOrderFromProjectList(Project, FromDate, ToDate);
            return lstObject;
        }

        //*********************************************************************************************************************
        //  REPORT METHOD: SIGNATURE FOR USER LOG REPORT UserLog_Report
        //*********************************************************************************************************************

        public static List<Entity.USerLog_Report> UserLog_Report(DateTime FromDate, DateTime ToDate,Int64 UserID)
        {
            List<Entity.USerLog_Report> lstObject = new List<Entity.USerLog_Report>();
            lstObject = new DAL.ReportSQL().UserLog_Report(FromDate, ToDate, UserID);
            return lstObject;
        }

        //*********************************************************************************************************************
        //  REPORT METHOD: SIGNATURE FOR Order Against Purchase Order Report
        //*********************************************************************************************************************

        public static List<Entity.OrderToPurchaseOrderDetail> OrderAgainstPurchase_Report(string ViewType, Int64 Month, Int64 Year, string LoginUserID, Int64 CustomerID, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.OrderToPurchaseOrderDetail> lstObject = new List<Entity.OrderToPurchaseOrderDetail>();
            lstObject = new DAL.ReportSQL().OrderAgainstPurchase_Report(ViewType, Month, Year, LoginUserID, CustomerID, FromDate, ToDate);
            return lstObject;
        }
        //*********************************************************************************************************************
        //  REPORT METHOD: SIGNATURE FOR Order Against Sales Order Report
        //*********************************************************************************************************************

        public static List<Entity.OrderToSalesOrderDetail> OrderAgainstSales_Report(string ViewType, Int64 Month, Int64 Year, string LoginUserID, Int64 CustomerID, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.OrderToSalesOrderDetail> lstObject = new List<Entity.OrderToSalesOrderDetail>();
            lstObject = new DAL.ReportSQL().OrderAgainstSales_Report(ViewType, Month, Year, LoginUserID, CustomerID, FromDate, ToDate);
            return lstObject;
        }

        //*********************************************************************************************************************
        //  REPORT METHOD: SIGNATURE FOR Production By SO Report
        //*********************************************************************************************************************

        public static List<Entity.ProductionBySO_Report> ProductionBySO_Report(Int64 CustomerID, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.ProductionBySO_Report> lstObject = new List<Entity.ProductionBySO_Report>();
            lstObject = new DAL.ReportSQL().ProductionBySO_Report(CustomerID, FromDate, ToDate);
            return lstObject;
        }

        //*********************************************************************************************************************
        //  REPORT METHOD: SIGNATURE FOR Production By SO Report
        //*********************************************************************************************************************

        public static List<Entity.MoldingDetail> DieList()
        {
            List<Entity.MoldingDetail> lstObject = new List<Entity.MoldingDetail>();
            lstObject = new DAL.ReportSQL().DieList();
            return lstObject;
        }


        //*********************************************************************************************************************
        //  REPORT METHOD: MoldingFinishingQtyList
        //*********************************************************************************************************************

        public static List<Entity.MoldingFinishingQty> MoldingFinishingQtyList()
        {
            List<Entity.MoldingFinishingQty> lstObject = new List<Entity.MoldingFinishingQty>();
            lstObject = new DAL.ReportSQL().MoldingFinishingQtyList();
            return lstObject;
        }
    }
}
