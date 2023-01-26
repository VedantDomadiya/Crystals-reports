using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace DAL
{
    public class ReportSQL : BaseSqlManager
    {
        // ==================================================================================================
        // Report : Expense Ledger Report
        // ==================================================================================================
        public virtual List<Entity.OrganizationEmployee> Report_ExpLedger(DateTime FromDate, DateTime ToDate, Int64 ExpenseTypeID, Int64 EmployeeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ExpLedger_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@ExpenseTypeID", ExpenseTypeID);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.OrganizationEmployee> lstObject = new List<Entity.OrganizationEmployee>();
            while (dr.Read())
            {
                Entity.OrganizationEmployee objEntity = new Entity.OrganizationEmployee();
                objEntity.pkID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.TransDate = GetDateTime(dr, "ExpenseDate");
                objEntity.ExpenseNotes = GetTextVale(dr, "ExpenseNotes");
                objEntity.Category = GetTextVale(dr, "Category");
                objEntity.ExpenseTypeName = GetTextVale(dr, "ExpenseTypeName");
                objEntity.DebitAmount = GetDecimal(dr, "DebitAmount");
                objEntity.CreditAmount = GetDecimal(dr, "CreditAmount");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        //--------------------------------------------------------------------------------------------------------------
        //MST_Product list report by vedant
        //--------------------------------------------------------------------------------------------------------------
        //here
        public virtual List<Entity.ProductReport> Report_ProductList(string pLoginUserID, Int64 CustomerID, DateTime pFromDate, DateTime pToDate, string CustomerStatus, string CustomerType, Int64 StateCode, Int64 CityCode)
        {

            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "ProdList_Report";
            cmdAdd.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdAdd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdAdd.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdAdd.Parameters.AddWithValue("@ToDate", pToDate);
            cmdAdd.Parameters.AddWithValue("@Status", CustomerStatus);
            cmdAdd.Parameters.AddWithValue("@CustomerType", CustomerType);
            cmdAdd.Parameters.AddWithValue("@StateCode", StateCode);
            cmdAdd.Parameters.AddWithValue("@CityCode", CityCode);


            SqlDataReader dr = ExecuteDataReader(cmdAdd);

            List<Entity.ProductReport> lstEntity = new List<Entity.ProductReport>();
            while (dr.Read())
            {
                // -------------------------------------------------------------------
                Entity.ProductReport objEntity = new Entity.ProductReport();

                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                objEntity.UnitPrice = GetDecimal(dr, "UnitPrice");
                objEntity.ProductSpecification = GetTextVale(dr, "ProductSpecification");
                objEntity.LRDate = GetDateTime(dr, "LRDate");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                objEntity.OpeningSTK = GetDecimal(dr, "OpeningSTK");
                objEntity.OutwardSTK = GetDecimal(dr, "OutwardSTK");
                objEntity.ClosingSTK = GetDecimal(dr, "ClosingSTK");
                objEntity.InwardSTK = GetDecimal(dr, "InwardSTK");

                //--------------------------------------------------------------------
                lstEntity.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstEntity;
        }


        //--------------------------------------------------------------------------------------------------------------
        //MST_Customer list report by vedant
        //--------------------------------------------------------------------------------------------------------------
        public virtual List<Entity.CustomerReport> Report_CustomerList(string pLoginUserID, Int64 CustomerID, DateTime pFromDate, DateTime pToDate, string CustomerStatus, string CustomerType, Int64 StateCode, Int64 CityCode)//here
        {

            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "CustList_Report";
            cmdAdd.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdAdd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdAdd.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdAdd.Parameters.AddWithValue("@ToDate", pToDate);
            cmdAdd.Parameters.AddWithValue("@Status", CustomerStatus);
            cmdAdd.Parameters.AddWithValue("@CustomerType", CustomerType);
            cmdAdd.Parameters.AddWithValue("@StateCode", StateCode);
            cmdAdd.Parameters.AddWithValue("@CityCode", CityCode);


            SqlDataReader dr = ExecuteDataReader(cmdAdd);

            List<Entity.CustomerReport> lstEntity = new List<Entity.CustomerReport>();
            while (dr.Read())
            {
                // -------------------------------------------------------------------
                Entity.CustomerReport objEntity = new Entity.CustomerReport();

                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.CustomerType = GetTextVale(dr, "CustomerType");
                objEntity.Area = GetTextVale(dr, "Area");
                objEntity.CityCode = GetInt64(dr, "CityCode");
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.CountryCode = GetTextVale(dr, "CountryCode");
                objEntity.PriceList = GetInt64(dr, "PriceList");
                objEntity.BirthDate = GetDateTime(dr, "BirthDate");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                //--------------------------------------------------------------------
                lstEntity.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstEntity;
        }

        //--------------------------------------------------------------------------------------------------------------
        //Employee list report
        //--------------------------------------------------------------------------------------------------------------
        /*
        public virtual List<Entity.Report> GetEmployeeList()
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "Employee_list";

            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.Report> lstObject = new List<Entity.Report>();
            while (dr.Read())
            {
                Entity.Employee objEntity = new Entity.Employee();

                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }
        */
        // ==================================================================================================
        // Report : Inquiry Followup Report
        // ==================================================================================================
        public virtual List<Entity.InquiryInfo_Report> Report_InqFollow(DateTime FromDate, DateTime ToDate, string Priority, string LeadStatus, Int64 CustomerID, Int64 EmployeeID, string ProductGroup, Int64 ProductID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "InquiryFollowup_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@Priority", Priority);
            cmdGet.Parameters.AddWithValue("@InquiryStatus", LeadStatus);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@ProductGroup", ProductGroup);
            cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.InquiryInfo_Report> lstObject = new List<Entity.InquiryInfo_Report>();
            while (dr.Read())
            {
                Entity.InquiryInfo_Report objEntity = new Entity.InquiryInfo_Report();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                objEntity.InquirySource = GetTextVale(dr, "InquirySource");
                objEntity.InquiryDate = GetDateTime(dr, "InquiryDate");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.FollowupNotes = GetTextVale(dr, "FollowupNotes");
                objEntity.FollowupDate = GetDateTime(dr, "FollowupDate");
                objEntity.NextFollowupDate = GetDateTime(dr, "NextFollowupDate");
                objEntity.MeetingNotes = GetTextVale(dr, "MeetingNotes");
                objEntity.InquiryStatus = GetTextVale(dr, "InquiryStatus");
                objEntity.Priority = GetTextVale(dr, "Priority");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // ==================================================================================================
        // Report : Stock Report
        // ==================================================================================================
        public virtual List<Entity.ProductStockReport> Report_Stock_New(string pLoginUserID, DateTime FromDate, DateTime ToDate)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "New_Stock_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.ProductStockReport> lstObject = new List<Entity.ProductStockReport>();
            while (dr.Read())
            {
                Entity.ProductStockReport objEntity = new Entity.ProductStockReport();
                //objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                //objEntity.TranDate = GetDateTime(dr, "TranDate");
                objEntity.OpeningSTK = GetDecimal(dr, "OpeningSTK");
                objEntity.InwardSTK = GetDecimal(dr, "InwardSTK");
                objEntity.OutwardSTK = GetDecimal(dr, "OutwardSTK");
                objEntity.ClosingSTK = GetDecimal(dr, "ClosingSTK");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }
        
            public virtual List<Entity.MonthlyTourPlan> Report_MonthlyTourPlan(DateTime FromDate, DateTime ToDate, Int64 pCustomerID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "MonthlyTourPlan_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@Todate", ToDate);
            cmdGet.Parameters.AddWithValue("@CustomerID", pCustomerID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.MonthlyTourPlan> lstObject = new List<Entity.MonthlyTourPlan>();
            while (dr.Read())
            {
                Entity.MonthlyTourPlan objEntity = new Entity.MonthlyTourPlan();
                
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.Remark = GetTextVale(dr, "Remark");
                objEntity.Area = GetTextVale(dr, "Area");
                objEntity.TourDate = GetDateTime(dr, "TourDate");
                objEntity.TourDay = GetTextVale(dr, "TourDay");
                objEntity.MeetingStartTime = GetTextVale(dr, "MeetingStartTime");
                objEntity.MeetingEndTime = GetTextVale(dr, "MeetingEndTime");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }
        //--------------------------------EmployeeActivity------------------------
        public virtual List<Entity.EmployeeActivity> Report_EmployeeActivity(Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, Int64 EmployeeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "EmployeeActivity_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@ToDate", Todate);
            cmdGet.Parameters.AddWithValue("@EmpID", EmployeeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.EmployeeActivity> lstObject = new List<Entity.EmployeeActivity>();
            while (dr.Read())
            {
                Entity.EmployeeActivity objEntity = new Entity.EmployeeActivity();
                objEntity.RowNum = GetInt64(dr, "RowNum");
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.DocNo = GetTextVale(dr, "DocNo");
                objEntity.DocDate = GetDateTime(dr, "DocDate");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.Customer = GetTextVale(dr, "Customer");
                objEntity.CityName = GetTextVale(dr, "CityName");
                objEntity.StateName = GetTextVale(dr, "StateName");
                objEntity.NetAmt = GetDecimal(dr, "NetAmt");
                objEntity.MeetingNotes = GetTextVale(dr, "MeetingNotes");
                objEntity.grp = GetTextVale(dr, "grp");
                objEntity.Action = GetTextVale(dr, "Action");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");
                objEntity.UpdatedDate = GetDateTime(dr, "UpdatedDate");
                
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        //--------------------------------EmployeeActivity------------------------
        public virtual List<Entity.OrderToSalesOrderDetail> Report_SOSummary(DateTime Fromdate, DateTime Todate, Int64 CustomerID, string SONo)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SalesOrderSummary_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@ToDate", Todate);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@SONo", SONo);
            cmdGet.Parameters.AddWithValue("@SerialKey", System.Web.HttpContext.Current.Session["SerialKey"].ToString());
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.OrderToSalesOrderDetail> lstObject = new List<Entity.OrderToSalesOrderDetail>();
            while (dr.Read())
            {
                Entity.OrderToSalesOrderDetail objEntity = new Entity.OrderToSalesOrderDetail();
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.ReferenceNo = GetTextVale(dr, "ReferenceNo");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                
                objEntity.OrderQty = GetDecimal(dr, "OrderQty");
                objEntity.DispatchQty = GetDecimal(dr, "DispatchQty");
                objEntity.PendingQty = GetDecimal(dr, "PendingQty");
                
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        //--------------------------------Overtime------------------------
        public virtual List<Entity.OverTime> Report_GetOverTimeListByUser(string pLoginUserID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, Int64 EmployeeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "LeaveRequestListByUser_Report";
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@ToDate", Todate);
            //cmdGet.Parameters.AddWithValue("@Month", pMonth);
            //cmdGet.Parameters.AddWithValue("@Year", pYear);
            cmdGet.Parameters.AddWithValue("@EmpID", EmployeeID);
            //cmdGet.Parameters.AddWithValue("@Status", LeaveStatus);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.OverTime> lstObject = new List<Entity.OverTime>();
            while (dr.Read())
            {
                Entity.OverTime objEntity = new Entity.OverTime();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.FromDate = GetDateTime(dr, "FromDate");
                objEntity.ToDate = GetDateTime(dr, "ToDate");
                objEntity.ReasonForOT = GetTextVale(dr, "ReasonForOT");
                objEntity.ApprovalStatus = GetTextVale(dr, "ApprovalStatus");
                objEntity.ApprovedEmployeeName = GetTextVale(dr, "ApprovedEmployeeName");
                objEntity.ApprovedBy = GetTextVale(dr, "ApprovedBy");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");
                objEntity.UpdatedDate = GetDateTime(dr, "UpdatedDate");
                objEntity.ApprovedDate = GetDateTime(dr, "ApprovedDate");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }


        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // GRN Report
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.GRNReport> GRNReport(Int64 ProductID, Int64 CustomerID, DateTime FromDate, DateTime ToDate, string pLoginUserID)
        {
            List<Entity.GRNReport> lstLocation = new List<Entity.GRNReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "GRNReport";
            cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.GRNReport objEntity = new Entity.GRNReport();
                objEntity.InwardNo = GetTextVale(dr, "InwardNo");
                objEntity.InwardDate = GetDateTime(dr, "InwardDate");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.Unit = GetTextVale(dr, "Unit");
                objEntity.OrderNo= GetTextVale(dr, "OrderNo");
                objEntity.LocationName= GetTextVale(dr, "LocationName");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Packing Report
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.PackingListReport> PackingListReport(Int64 ProductID, Int64 CustomerID, DateTime FromDate, DateTime ToDate, string pLoginUserID)
        {
            List<Entity.PackingListReport> lstLocation = new List<Entity.PackingListReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "PackingListReport";
            cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.PackingListReport objEntity = new Entity.PackingListReport();
                objEntity.OutwardNo = GetTextVale(dr, "OutwardNo");
                objEntity.OutwardDate = GetDateTime(dr, "OutwardDate");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.Unit = GetTextVale(dr, "Unit");
                objEntity.SerialNo = GetTextVale(dr, "SerialNo");
                objEntity.BoxNo= GetTextVale(dr, "BoxNo");
                objEntity.LocationName= GetTextVale(dr, "LocationName");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Outward Report
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.OutwardReport> OutwardReportList(Int64 pkID,Int64 CustomerID, string LoginUserID, DateTime FromDate, DateTime ToDate, Int64 PageNo, Int64 PageSize)
        {
            List<Entity.OutwardReport> lstLocation = new List<Entity.OutwardReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "OutwardReport";
            cmdGet.Parameters.AddWithValue("@pkID", pkID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@PageNo", PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", PageSize);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.OutwardReport objEntity = new Entity.OutwardReport();
                objEntity.ManualOutwardNo = GetTextVale(dr, "ManualOutwardNo");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.OutwardDate = GetDateTime(dr, "OutwardDate");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.Remarks = GetTextVale(dr, "Remarks");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }


        // ===========================================================================================================
        // Report Method Signature : JobCard Report
        // ===========================================================================================================
        public virtual List<Entity.JobCardReport> JobCardList(Int64 ProductID, Int64 CustomerID, Int64 Location, DateTime FromDate, DateTime ToDate, string pLoginUserID)
        {
            List<Entity.JobCardReport> lstLocation = new List<Entity.JobCardReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "JobCardReport";
            cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@Location", Location);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.JobCardReport objEntity = new Entity.JobCardReport();
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.Location = GetTextVale(dr, "Location");
                objEntity.ToDate = GetDateTime(dr, "ToDate");
                objEntity.FromDate = GetDateTime(dr, "FromDate");

                objEntity.JobCardNo = GetTextVale(dr, "JobCardNo");
                objEntity.JobCardDate = GetDateTime(dr, "JobCardDate");
                objEntity.Vin = GetDateTime(dr, "VIn");
                objEntity.WheelNo = GetInt64(dr, "WheelNo");
                objEntity.TypeOfJob = GetTextVale(dr, "TypeOfJob");
                objEntity.WheelMake = GetTextVale(dr, "WheelMake");
                objEntity.RegNo = GetTextVale(dr, "RegNo");
                objEntity.ClaimNo = GetTextVale(dr, "ClaimNo");

                lstLocation.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //                                          Debit Credit Note Report
        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        public virtual List<Entity.DebitCreditNoteReport> DebitCreditNote(string LoginUserID, Int64 CustomerID,DateTime FromDate, DateTime ToDate, Int64 PageNo, Int64 PageSize)
        {
            List<Entity.DebitCreditNoteReport> lstLocation = new List<Entity.DebitCreditNoteReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "DBNoteReport1";
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@PageNo", PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", PageSize);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.DebitCreditNoteReport objEntity = new Entity.DebitCreditNoteReport();
                objEntity.VoucherNo = GetTextVale(dr, "VoucherNo");
                objEntity.InvoiceNo = GetTextVale(dr, "InvoiceNo");
                objEntity.VoucherDate = GetDateTime(dr, "VoucherDate");
                objEntity.VoucherAmount = GetInt64(dr, "VoucherAmount");
                objEntity.DBC = GetTextVale(dr, "DBC");
                objEntity.DBCustomerID = GetInt64(dr, "DBCustomerID");
                objEntity.CRCustomerID = GetInt64(dr, "CRCustomerID");
                objEntity.DBCustomerName = GetTextVale(dr, "DBCustomerName");
                objEntity.CRCustomerName = GetTextVale(dr, "CRCustomerName");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");

                lstLocation.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        //                                        Visitor Management Report
        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        public virtual List<Entity.VisitorReport> VisitorReportList(Int64 pkID, string LoginUserID, string SearchKey, Int64 PageNo, Int64 PageSize, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.VisitorReport> lstLocation = new List<Entity.VisitorReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "VisitorInfo_Report";
            cmdGet.Parameters.AddWithValue("@pkID", pkID);
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@SearchKey", SearchKey);
            cmdGet.Parameters.AddWithValue("@PageNo", PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", PageSize);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.VisitorReport objEntity = new Entity.VisitorReport();
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                objEntity.VisitDate = GetDateTime(dr, "VisitDate");
                objEntity.VisitTime = GetTextVale(dr, "VisitTime");
                objEntity.VisitorName = GetTextVale(dr, "VisitorName");
                objEntity.CompanyName = GetTextVale(dr, "CompanyName");
                objEntity.PurposeOfVisit = GetTextVale(dr, "PurposeOfVisit");
                objEntity.VisitorContact = GetTextVale(dr, "VisitorContact");
                objEntity.Department = GetTextVale(dr, "Department");
                objEntity.MeetingTo = GetTextVale(dr, "MeetingTo");

                lstLocation.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        //                                        Inward Report For Vardhman
        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        public virtual List<Entity.InwardReport> InwardReportList (Int64 pkID, string LoginUserID, Int64 CustomerID, DateTime FromDate, DateTime ToDate,Int64 PageNo, Int64 PageSize )
        {
            List<Entity.InwardReport> lstLocation = new List<Entity.InwardReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "InwardReport";
            cmdGet.Parameters.AddWithValue("@pkID", pkID);
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@PageNo", PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", PageSize);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.InwardReport objEntity = new Entity.InwardReport();
                objEntity.InwardNo = GetTextVale(dr, "InwardNo");
                objEntity.ManuaLInwardNo = GetTextVale(dr, "ManuaLInwardNo");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Quantity = GetInt64(dr, "Quantity");
                objEntity.TransportRemark = GetTextVale(dr, "TransportRemark");
                objEntity.InwardDate = GetDateTime(dr, "InwardDate");

                lstLocation.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.Attendance_Report> GetEmployeeTracking_Report(Int64 EmployeeID, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate)
        {
            List<Entity.Attendance_Report> lstLocation = new List<Entity.Attendance_Report>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "EmployeeTrackingReport";
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.Attendance_Report objEntity = new Entity.Attendance_Report();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.PresenceDate = GetDateTime(dr, "PresenceDate");
                objEntity.TimeIn = GetTextVale(dr, "TimeIn");
                objEntity.TimeOut = GetTextVale(dr, "TimeOut");
                objEntity.LocationAddress_IN = GetTextVale(dr, "LocationAddress_IN");
                objEntity.LocationAddress_OUT = GetTextVale(dr, "LocationAddress_OUT");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.InwardOutwardReport> InwardOutwardReportList(Int64 pkID, string LoginUserID, Int64 CustomerID, DateTime FromDate, DateTime ToDate, Int64 PageNo, Int64 PageSize)
        {
            List<Entity.InwardOutwardReport> lstLocation = new List<Entity.InwardOutwardReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "InwardOutwardReport";
            cmdGet.Parameters.AddWithValue("@pkID", pkID);
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@PageNo", PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", PageSize);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.InwardOutwardReport objEntity = new Entity.InwardOutwardReport();
                objEntity.ManuaLInwardNo = GetTextVale(dr, "ManuaLInwardNo");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Quantity = GetInt64(dr, "Quantity");
                objEntity.TransportRemark = GetTextVale(dr, "TransportRemark");
                objEntity.InwardDate = GetDateTime(dr, "InwardDate");
                objEntity.grp = GetTextVale(dr, "grp");

                lstLocation.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        //-------------------------------------------------------------------------------------------
        //  Report : For Pending Bill List.
        //-------------------------------------------------------------------------------------------

        public virtual List<Entity.PendingBillReport> PendingBillList(string BillingCategory, string BillingStatus, string ByDateType, string AsOnDate, Int64 LM1, Int64 LM2, Int64 LM3, Int64 LM4, Int64 LM5, Int64 LM6)
        {
            List<Entity.PendingBillReport> lstLocation = new List<Entity.PendingBillReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "PendingBillList_Report";
            cmdGet.Parameters.AddWithValue("@BillingCategory", BillingCategory);
            cmdGet.Parameters.AddWithValue("@BillingStatus", BillingStatus);
            cmdGet.Parameters.AddWithValue("@ByDateType", ByDateType);
            cmdGet.Parameters.AddWithValue("@AsOnDate", AsOnDate);
            cmdGet.Parameters.AddWithValue("@LM1", LM1);
            cmdGet.Parameters.AddWithValue("@LM2", LM2);
            cmdGet.Parameters.AddWithValue("@LM3", LM3);
            cmdGet.Parameters.AddWithValue("@LM4", LM4);
            cmdGet.Parameters.AddWithValue("@LM5", LM5);
            cmdGet.Parameters.AddWithValue("@LM6", LM6);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.PendingBillReport objEntity = new Entity.PendingBillReport();
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.Slab1 = GetInt64(dr, "Slab1");
                objEntity.Slab2 = GetInt64(dr, "Slab2");
                objEntity.Slab3 = GetInt64(dr, "Slab3");
                objEntity.Slab4 = GetInt64(dr, "Slab4");
                objEntity.Slab5 = GetInt64(dr, "Slab5");

                lstLocation.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }


        public virtual List<Entity.InstallFabricReport> InstallFabricReport(Int64 CustomerID, string InspectType, string LoginUserID)
        {
            List<Entity.InstallFabricReport> lstLocation = new List<Entity.InstallFabricReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "InstallFabricReport";
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@InspectType", InspectType);
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.InstallFabricReport objEntity = new Entity.InstallFabricReport();
                objEntity.InspectionDate = GetDateTime(dr, "InspectionDate");
                objEntity.InspectionType= GetTextVale(dr, "InspectionType");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.CheckDesc = GetTextVale(dr, "CheckDesc");
                objEntity.CheckFlag = GetTextVale(dr, "CheckFlag");
                objEntity.CheckRemark = GetTextVale(dr, "CheckRemark");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.ContactNo = GetTextVale(dr, "ContactNo1");
                objEntity.Area = GetTextVale(dr, "Area");
                objEntity.CityName = GetTextVale(dr, "CityName");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        // ===========================================================================================================
        // Report Method Signature : JobCard Inward Against Outward
        // ===========================================================================================================
        public virtual List<Entity.JobCardStatus> JobCardStatusList(string pViewType, Int64 pMonth, Int64 pYear, string pLoginUserID)
        {
            List<Entity.JobCardStatus> lstLocation = new List<Entity.JobCardStatus>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "JobCardStatusList";
            cmdGet.Parameters.AddWithValue("@ViewType", pViewType);
            cmdGet.Parameters.AddWithValue("@Month", pMonth);
            cmdGet.Parameters.AddWithValue("@Year", pYear);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.JobCardStatus objEntity = new Entity.JobCardStatus();
                if (pViewType.ToLower() != "summary")
                {
                    objEntity.pkID = GetInt64(dr, "pkID");
                    objEntity.OutwardNo = GetTextVale(dr, "OutwardNo");
                    objEntity.OutwardDate = GetDateTime(dr, "OutwardDate");
                    objEntity.CustomerID = GetInt64(dr, "CustomerID");
                    objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                }
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                objEntity.ProductNameLong = GetTextVale(dr, "ProductNameLong");
                objEntity.OutwardQty = GetDecimal(dr, "OutwardQty");
                objEntity.InwardQty = GetDecimal(dr, "InwardQty");
                objEntity.RemainingQty = GetDecimal(dr, "RemainingQty");
                objEntity.Status = GetTextVale(dr, "RequestStatus");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // MaterialMovement Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.MaterialMovementReport> MaterialMovementReport(Int64 ProductID, Int64 CustomerID, string TransType, DateTime FromDate, DateTime ToDate, string LoginUserID)
        {
            List<Entity.MaterialMovementReport> lstLocation = new List<Entity.MaterialMovementReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "MaterialMovInwardReport";
            cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@TransType", TransType);
            cmdGet.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate).ToString("yyyy-MM-dd"));
            cmdGet.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate).ToString("yyyy-MM-dd"));
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.MaterialMovementReport objEntity = new Entity.MaterialMovementReport();
                objEntity.TransDate = GetDateTime(dr, "TransDate");

                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                //objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // JobCardInward Report
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.JobCardInwardReport> JobCardInwardReport(Int64 ProductID, Int64 CustomerID, DateTime FromDate, DateTime ToDate, string pLoginUserID)
        {
            List<Entity.JobCardInwardReport> lstLocation = new List<Entity.JobCardInwardReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "JobCardInwardReport";
            cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.JobCardInwardReport objEntity = new Entity.JobCardInwardReport();
                objEntity.InwardNo = GetTextVale(dr, "InwardNo");
                objEntity.InwardDate = GetDateTime(dr, "InwardDate");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.Unit = GetTextVale(dr, "Unit");
                objEntity.OutwardNo = GetTextVale(dr, "OutwardNo");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }


        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // JobCardOutward Report
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.JobCardOutwardReport> JobCardOutwardReport(Int64 ProductID, Int64 CustomerID,DateTime FromDate,DateTime ToDate, string pLoginUserID)
        {
            List<Entity.JobCardOutwardReport> lstLocation = new List<Entity.JobCardOutwardReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "JobCardOutwardReport";
            cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.JobCardOutwardReport objEntity = new Entity.JobCardOutwardReport();
                objEntity.OutwardNo = GetTextVale(dr, "OutwardNo");
                objEntity.OutwardDate= GetDateTime(dr, "OutwardDate");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductName= GetTextVale(dr, "ProductName");
                objEntity.Quantity= GetDecimal(dr, "Quantity");
                objEntity.Unit = GetTextVale(dr, "Unit");
                objEntity.OrderNo= GetTextVale(dr, "OrderNo");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Complaint Report with Customer Signature for Abhishek Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.ReportWithSign> ComplainWithSign(Int64 CustomerID,string pLoginUserID)
        {
            List<Entity.ReportWithSign> lstLocation = new List<Entity.ReportWithSign>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ComplaintReportWithSign";
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.ReportWithSign objEntity = new Entity.ReportWithSign();
                //objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.ContactNo1 = GetTextVale(dr, "ContactNo1");
                objEntity.KW = GetTextVale(dr, "KW");
                objEntity.NatureOFProblem = GetTextVale(dr, "NatureOFProblem");
                objEntity.ActionTaken = GetTextVale(dr, "ActionTaken");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }


        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // TODO Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.ToDo> TODoList(DateTime FromDate, DateTime ToDate,Int64 EmployeeID,string TaskStatus, string pLoginUserID, Int64 PageNo, Int64 PageSize, string Priority)
        {
            List<Entity.ToDo> lstLocation = new List<Entity.ToDo>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "TodoReport";
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@EmpID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@TaskStatus", TaskStatus);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@Priority", Priority);
            cmdGet.Parameters.AddWithValue("@PageNo", PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.ToDo objEntity = new Entity.ToDo();
                objEntity.TaskDescription = GetTextVale(dr, "TaskDescription");
                objEntity.TaskCategory = GetTextVale(dr, "TaskCategory");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.Priority = GetTextVale(dr, "Priority");
                objEntity.CompletionDate = GetDateTime(dr, "CompletionDate");
                objEntity.TaskStatus = GetTextVale(dr, "TaskStatus");
                objEntity.ClosingRemarks = GetTextVale(dr, "ClosingRemarks");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Complaint Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.CompliantReport> Complaint(string ComplaintStatus, Int64 EmplyeeID, DateTime FromDate, DateTime ToDate, string pLoginUserID)
        {
            List<Entity.CompliantReport> lstLocation = new List<Entity.CompliantReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ComplaintReport";
            cmdGet.Parameters.AddWithValue("@ComplaintSatatus", ComplaintStatus);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmplyeeID);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.CompliantReport objEntity = new Entity.CompliantReport();
                objEntity.ComplaintDate = GetDateTime(dr, "ComplaintDate");
                objEntity.ComplaintNo = GetTextVale(dr, "ComplaintNo");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ContactNo1 = GetTextVale(dr, "ContactNo1");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.Area = GetTextVale(dr, "Area");
                objEntity.CityName = GetTextVale(dr, "CityName");
                objEntity.PinCode = GetTextVale(dr, "PinCode");
                objEntity.StateName = GetTextVale(dr, "StateName");
                objEntity.OtherDetails = GetTextVale(dr, "OtherDetails");
                objEntity.ComplaintStatus = GetTextVale(dr, "ComplaintStatus");
                objEntity.AssignedTo = GetTextVale(dr, "AssignedTo");
                //objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Salary Register Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        public virtual List<Entity.SalaryRegister> SalaryRegister(Int64 EmployeeID,string Month,string Year,string pLoginUserID)
        {
            List<Entity.SalaryRegister> lstLocation = new List<Entity.SalaryRegister>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SalaryRegister";
            cmdGet.Parameters.AddWithValue("@EmpID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@Month", Month);
            cmdGet.Parameters.AddWithValue("@YEAR", Year);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@SerialKey", System.Web.HttpContext.Current.Session["SerialKey"].ToString());
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.SalaryRegister objEntity = new Entity.SalaryRegister();
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.PayDate = GetDateTime(dr, "PayDate");
                objEntity.WDays = GetInt64(dr, "WDays");
                objEntity.PDays = GetInt64(dr, "PDays");
                objEntity.ODays = GetInt64(dr, "ODays");
                objEntity.LDays = GetInt64(dr, "LDays");
                objEntity.HDays = GetInt64(dr, "HDays");
                objEntity.FixedSalary = GetDecimal(dr, "FixedSalary");
                objEntity.Basic = GetDecimal(dr, "Basic");
                objEntity.Conveyance = GetDecimal(dr, "Conveyance");
                objEntity.OverTime = GetDecimal(dr, "OverTime");
                objEntity.Medical = GetDecimal(dr, "Medical");
                objEntity.DA = GetDecimal(dr, "DA");
                objEntity.Special = GetDecimal(dr, "Special");
                objEntity.Total_Income = GetDecimal(dr, "Total_Income");
                objEntity.PF = GetDecimal(dr, "PF");
                objEntity.ESI = GetDecimal(dr, "ESI");
                objEntity.PT = GetDecimal(dr, "PT");
                objEntity.TDS = GetDecimal(dr, "TDS");
                objEntity.Loan = GetDecimal(dr, "Loan");
                objEntity.Upad = GetDecimal(dr, "Upad");
                objEntity.Total_Deduct = GetDecimal(dr, "Total_Deduct");
                objEntity.NetSalary = GetDecimal(dr, "NetSalary");
                objEntity.Designation = GetTextVale(dr, "Designation");
                objEntity.Gender = GetTextVale(dr, "Gender");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }


            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            // Monthly Purchase Reports
            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            public virtual List<Entity.MonthlyPurchase> MonthlyPurchaseList(string Type, DateTime FromDt, DateTime ToDt, string pLoginUserID)
        {
            List<Entity.MonthlyPurchase> lstLocation = new List<Entity.MonthlyPurchase>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "MontlyPurchase";
            cmdGet.Parameters.AddWithValue("@Type", Type);
            cmdGet.Parameters.AddWithValue("@FromDt", FromDt);
            cmdGet.Parameters.AddWithValue("@ToDt", ToDt);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.MonthlyPurchase objEntity = new Entity.MonthlyPurchase();
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.M1 = GetDecimal(dr, "M1");
                objEntity.M2 = GetDecimal(dr, "M2");
                objEntity.M3 = GetDecimal(dr, "M3");
                objEntity.M4 = GetDecimal(dr, "M4");
                objEntity.M5 = GetDecimal(dr, "M5");
                objEntity.M6 = GetDecimal(dr, "M6");
                objEntity.M7 = GetDecimal(dr, "M7");
                objEntity.M8 = GetDecimal(dr, "M8");
                objEntity.M9 = GetDecimal(dr, "M9");
                objEntity.M10 = GetDecimal(dr, "M10");
                objEntity.M11 = GetDecimal(dr, "M11");
                objEntity.M12 = GetDecimal(dr, "M12");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        // ===========================================================================================================
        // Report Method Signature : Monthly Sales Summary
        // ===========================================================================================================
        public virtual List<Entity.MonthlySalesSummary> Report_MonthlySalesSummary(String Type,DateTime d3,DateTime d4, String pLoginUserID)
        {
            List<Entity.MonthlySalesSummary> lstLocation = new List<Entity.MonthlySalesSummary>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "MontlySales";
            cmdGet.Parameters.AddWithValue("@Type", Type);
            cmdGet.Parameters.AddWithValue("@FromDt", d3);
            cmdGet.Parameters.AddWithValue("@ToDt", d4);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.MonthlySalesSummary objEntity = new Entity.MonthlySalesSummary();
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.M1 = GetDecimal(dr, "M1");
                objEntity.M2 = GetDecimal(dr, "M2");
                objEntity.M3 = GetDecimal(dr, "M3");
                objEntity.M4 = GetDecimal(dr, "M4");
                objEntity.M5 = GetDecimal(dr, "M5");
                objEntity.M6 = GetDecimal(dr, "M6");
                objEntity.M7 = GetDecimal(dr, "M7");
                objEntity.M8 = GetDecimal(dr, "M8");
                objEntity.M9 = GetDecimal(dr, "M9");
                objEntity.M10 = GetDecimal(dr, "M10");
                objEntity.M11 = GetDecimal(dr, "M11");
                objEntity.M12 = GetDecimal(dr, "M12");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }
        // ===========================================================================================================
        // Report Method Signature : Purchase Order (Material Receive Against our PO) Material Recived Status Report
        // ===========================================================================================================
        public virtual List<Entity.Location> LocationProductStockList(string pViewType, Int64 LocationID, Int64 ProductID, string pLoginUserID)
        {
            List<Entity.Location> lstLocation = new List<Entity.Location>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "LocationProductStockList";
            cmdGet.Parameters.AddWithValue("@ViewType", pViewType);
            cmdGet.Parameters.AddWithValue("@LocationID", LocationID);
            cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.Location objEntity = new Entity.Location();
                //if (pViewType.ToLower() != "summary")
                //{
                //    objEntity.pkID = GetInt64(dr, "pkID");
                //    objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                //    objEntity.CustomerID = GetInt64(dr, "CustomerID");
                //    objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                //}
                objEntity.pkID = GetInt64(dr, "LocationID");
                objEntity.LocationName = GetTextVale(dr, "LocationName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                if (pViewType.ToLower() == "summary")
                {
                    objEntity.OpeningSTK = GetDecimal(dr, "OpeningSTK");
                    objEntity.InwardSTK = GetDecimal(dr, "InwardSTK");
                    objEntity.OutwardSTK = GetDecimal(dr, "OutwardSTK");
                    objEntity.ClosingSTK = GetDecimal(dr, "ClosingSTK");
                }
                else
                {
                    objEntity.Module = GetTextVale(dr, "Module");
                    objEntity.TransType = GetTextVale(dr, "TransType");
                    objEntity.InvoiceNo = GetTextVale(dr, "InvoiceNo");
                    objEntity.InvoiceDate = GetDateTime(dr, "InvoiceDate");
                    objEntity.Quantity = GetDecimal(dr, "Quantity");
                }
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        // ===========================================================================================================
        // Report Method Signature : Purchase Order (Material Receive Against our PO) Material Recived Status Report
        // ===========================================================================================================
        public virtual List<Entity.DispatchStatus> SupplierMaterialStatusList(string pViewType, Int64 pMonth, Int64 pYear, string pLoginUserID)
        {
            List<Entity.DispatchStatus> lstLocation = new List<Entity.DispatchStatus>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SupplierMaterialStatusList";
            cmdGet.Parameters.AddWithValue("@ViewType", pViewType);
            cmdGet.Parameters.AddWithValue("@Month", pMonth);
            cmdGet.Parameters.AddWithValue("@Year", pYear);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.DispatchStatus objEntity = new Entity.DispatchStatus();
                if (pViewType.ToLower() != "summary")
                {
                    objEntity.pkID = GetInt64(dr, "pkID");
                    objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                    objEntity.OrderDate = GetDateTime(dr, "OrderDate");
                    objEntity.CustomerID = GetInt64(dr, "CustomerID");
                    objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                    objEntity.Unit = GetTextVale(dr, "Unit");
                    objEntity.ProductID = GetInt64(dr, "ProductID");
                    objEntity.ProductName = GetTextVale(dr, "ProductName");
                    objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                    objEntity.ProductNameLong = GetTextVale(dr, "ProductNameLong");
                    objEntity.DeliveryDate = GetDateTime(dr, "DDate");
                    objEntity.OrderQty = GetDecimal(dr, "OrderQty");
                    objEntity.DispatchQty = GetDecimal(dr, "DispatchQty");
                    objEntity.PendingQty = GetDecimal(dr, "OrderQty") - GetDecimal(dr, "DispatchQty");
                    objEntity.DeliveryStatus = GetTextVale(dr, "DeliveryStatus");
                    objEntity.RequestStatus = GetTextVale(dr, "RequestStatus");
                }
                else
                {
                    objEntity.ProductID = GetInt64(dr, "ProductID");
                    objEntity.ProductName = GetTextVale(dr, "ProductName");
                    objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                    objEntity.ProductNameLong = GetTextVale(dr, "ProductNameLong");
                    objEntity.OrderQty = GetDecimal(dr, "OrderQty");
                    objEntity.DispatchQty = GetDecimal(dr, "DispatchQty");
                    objEntity.PendingQty = GetDecimal(dr, "OrderQty") - GetDecimal(dr, "DispatchQty");
                    objEntity.RequestStatus = GetTextVale(dr, "RequestStatus");
                    objEntity.ApprovalStatus = GetTextVale(dr, "ApprovalStatus");
                }

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }


        public virtual List<Entity.DispatchStatus> SupplierMaterialStatusPDF(string pViewType, Int64 pMonth, Int64 pYear, string pLoginUserID)
        {
            List<Entity.DispatchStatus> lstLocation = new List<Entity.DispatchStatus>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SupplierMaterialStatusList";
            cmdGet.Parameters.AddWithValue("@ViewType", pViewType);
            cmdGet.Parameters.AddWithValue("@Month", pMonth);
            cmdGet.Parameters.AddWithValue("@Year", pYear);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.DispatchStatus objEntity = new Entity.DispatchStatus();
                if (pViewType.ToLower() != "summary")
                {
                    objEntity.pkID = GetInt64(dr, "pkID");
                    objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                    objEntity.CustomerID = GetInt64(dr, "CustomerID");
                    objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                    objEntity.ProductID = GetInt64(dr, "ProductID");
                    objEntity.ProductName = GetTextVale(dr, "ProductName");
                    objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                    objEntity.ProductNameLong = GetTextVale(dr, "ProductNameLong");
                    objEntity.OrderQty = GetDecimal(dr, "OrderQty");
                    objEntity.DispatchQty = GetDecimal(dr, "DispatchQty");
                    objEntity.PendingQty = GetDecimal(dr, "OrderQty") - GetDecimal(dr, "DispatchQty");
                    objEntity.DeliveryStatus = GetTextVale(dr, "DeliveryStatus");
                    objEntity.RequestStatus = GetTextVale(dr, "RequestStatus");
                }
                else
                {
                    objEntity.ProductID = GetInt64(dr, "ProductID");
                    objEntity.ProductName = GetTextVale(dr, "ProductName");
                    objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                    objEntity.ProductNameLong = GetTextVale(dr, "ProductNameLong");
                    objEntity.OrderQty = GetDecimal(dr, "OrderQty");
                    objEntity.DispatchQty = GetDecimal(dr, "DispatchQty");
                    objEntity.PendingQty = GetDecimal(dr, "OrderQty") - GetDecimal(dr, "DispatchQty");
                    objEntity.RequestStatus = GetTextVale(dr, "RequestStatus");
                    objEntity.ApprovalStatus = GetTextVale(dr, "ApprovalStatus");
                }

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }
        // ===============================================================================================
        // Report Method Signature : Material Dispatch Status List
        // ===============================================================================================
        public virtual List<Entity.DispatchStatus> DispatchStatusList(string pViewType, Int64 pMonth, Int64 pYear, string pLoginUserID)
        {
            List<Entity.DispatchStatus> lstLocation = new List<Entity.DispatchStatus>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "DispatchStatusList";
            cmdGet.Parameters.AddWithValue("@ViewType", pViewType);
            cmdGet.Parameters.AddWithValue("@Month", pMonth);
            cmdGet.Parameters.AddWithValue("@Year", pYear);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID); 
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.DispatchStatus objEntity = new Entity.DispatchStatus();
                if (pViewType.ToLower() != "summary")
                {
                    objEntity.pkID = GetInt64(dr, "pkID");
                    objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                    objEntity.OrderDate = GetDateTime(dr, "OrderDate");
                    objEntity.CustomerID = GetInt64(dr, "CustomerID");
                    objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                    objEntity.ProductID = GetInt64(dr, "ProductID");
                    objEntity.ProductName = GetTextVale(dr, "ProductName");
                    objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                    objEntity.ProductNameLong = GetTextVale(dr, "ProductNameLong");
                    objEntity.DeliveryDate = GetDateTime(dr, "DeliveryDate");
                    objEntity.OrderQty = GetDecimal(dr, "OrderQty");
                    objEntity.DispatchQty = GetDecimal(dr, "DispatchQty");
                    objEntity.PendingQty = GetDecimal(dr, "OrderQty") - GetDecimal(dr, "DispatchQty");
                    objEntity.DeliveryStatus = GetTextVale(dr, "DeliveryStatus");
                    objEntity.RequestStatus = GetTextVale(dr, "RequestStatus");
                }
                else
                {
                    objEntity.ProductID = GetInt64(dr, "ProductID");
                    objEntity.ProductName = GetTextVale(dr, "ProductName");
                    objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                    objEntity.ProductNameLong = GetTextVale(dr, "ProductNameLong");
                    objEntity.OrderQty = GetDecimal(dr, "OrderQty");
                    objEntity.DispatchQty = GetDecimal(dr, "DispatchQty");
                    objEntity.PendingQty = GetDecimal(dr, "OrderQty") - GetDecimal(dr, "DispatchQty");
                    objEntity.RequestStatus = GetTextVale(dr, "RequestStatus");
                    objEntity.ApprovalStatus = GetTextVale(dr, "ApprovalStatus");
                }

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        // ===============================================================================================
        // Report Method Signature : Product Min.Stock
        // ===============================================================================================
        public virtual List<Entity.Products> ProductMinStockList(string BrandID, string ProductGroupID, string pLoginUserID)
        {
            List<Entity.Products> lstLocation = new List<Entity.Products>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ProductMinStockList";
            cmdGet.Parameters.AddWithValue("@BrandID", BrandID);
            cmdGet.Parameters.AddWithValue("@ProductGroupID", ProductGroupID);
            //cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.Products objEntity = new Entity.Products();
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                objEntity.BrandName = GetTextVale(dr, "BrandName");
                objEntity.MinQuantity = GetDecimal(dr, "MinQuantity");
                objEntity.ClosingSTK = GetDecimal(dr, "ClosingSTK");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Sales Register
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        public virtual List<Entity.SalesReport> Report_SalesReg(String pLoginUserID, String pBrand, String pProductGroup, Int64 CustomerId, DateTime pFromDate, DateTime pToDate)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SalesRegister_Report";
            cmdGet.Parameters.AddWithValue("@LogInUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@BrandId", pBrand);
            cmdGet.Parameters.AddWithValue("@ProductGroupId", pProductGroup);
            cmdGet.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmdGet.Parameters.AddWithValue("@CityCode", 0);
            cmdGet.Parameters.AddWithValue("@StateCode", 0);
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.SalesReport> lstObject = new List<Entity.SalesReport>();
            while (dr.Read())
            {
                Entity.SalesReport objEntity = new Entity.SalesReport();
                objEntity.BrandID = GetInt64(dr, "BrandID");
                objEntity.BrandName = GetTextVale(dr, "BrandName");
                objEntity.ProductGroupID = GetInt64(dr, "ProductGroupID");
                objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.CityCode = GetInt64(dr, "CityCode");
                objEntity.CityName = GetTextVale(dr, "CityName");
                objEntity.StateCode = GetInt64(dr, "StateCode");
                objEntity.StateName = GetTextVale(dr, "StateName");
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.OrderDate = GetDateTime(dr, "OrderDate");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.UnitRate = GetDecimal(dr, "UnitRate");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.SGSTPer = GetDecimal(dr, "SGSTPer");
                objEntity.CGSTPer = GetDecimal(dr, "CGSTPer");
                objEntity.IGSTPer = GetDecimal(dr, "IGSTPer");
                objEntity.SGSTAmt = GetDecimal(dr, "SGSTAmt");
                objEntity.CGSTAmt = GetDecimal(dr, "CGSTAmt");
                objEntity.IGSTAmt = GetDecimal(dr, "IGSTAmt");
                objEntity.TotSGST = GetDecimal(dr, "TotSGST");
                objEntity.TotCGST = GetDecimal(dr, "TotCGST");
                objEntity.TotIGST = GetDecimal(dr, "TotIGST");
                objEntity.TaxAmount = GetDecimal(dr, "TaxAmount");
                objEntity.NetAmount = GetDecimal(dr, "NetAmount");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Sales Order Detailed Report
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        public virtual List<Entity.SODetailedReport> Report_SODetailed(String pLoginUserID, Int64 ProductID, Int64 CustomerId, DateTime pFromDate, DateTime pToDate)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SalesOrderDetailed_Report";
            cmdGet.Parameters.AddWithValue("@LogInUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.SODetailedReport> lstObject = new List<Entity.SODetailedReport>();
            while (dr.Read())
            {
                Entity.SODetailedReport objEntity = new Entity.SODetailedReport();
                //objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Spec = GetTextVale(dr, "Spec");
                //objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ContactNo1 = GetTextVale(dr, "ContactNo1");
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.GSTNO = GetTextVale(dr, "GSTNO");
                objEntity.Address = GetTextVale(dr, "Address");
                //objEntity.CityCode = GetInt64(dr, "CityCode");
                objEntity.City = GetTextVale(dr, "City");
                //objEntity.StateCode = GetInt64(dr, "StateCode");
                objEntity.State = GetTextVale(dr, "State");
                //objEntity.CountryCode= GetTextVale(dr, "CountryCode");
                objEntity.Country= GetTextVale(dr, "Country");
                objEntity.ReferenceDate= GetDateTime(dr, "ReferenceDate");
                objEntity.ReferenceNo = GetTextVale(dr, "ReferenceNo");
                objEntity.PackageType = GetTextVale(dr, "PackageType");
                objEntity.LRNo= GetTextVale(dr, "LRNo");
                objEntity.FlightNo= GetTextVale(dr, "FlightNo");
                objEntity.MachineCommitioning = GetTextVale(dr, "MachineCommitioning");
                objEntity.RefferenceList = GetTextVale(dr, "RefferenceList");
                objEntity.DriverName = GetTextVale(dr, "DriverName");
                objEntity.DriverContact = GetTextVale(dr, "DriverContact");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }


        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // StateWise Sales Register
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*


        public virtual List<Entity.SalesReport> Report_StateWiseSalesReg(String pLoginUserID, Int64 City, Int64 State, Int64 CustomerId, DateTime pFromDate, DateTime pToDate)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SalesRegister_Report";
            cmdGet.Parameters.AddWithValue("@LogInUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@BrandId", 0);
            cmdGet.Parameters.AddWithValue("@ProductGroupId", 0);
            cmdGet.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmdGet.Parameters.AddWithValue("@CityCode", City);
            cmdGet.Parameters.AddWithValue("@StateCode", State);
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.SalesReport> lstObject = new List<Entity.SalesReport>();
            while (dr.Read())
            {
                Entity.SalesReport objEntity = new Entity.SalesReport();
                objEntity.BrandID = GetInt64(dr, "BrandID");
                objEntity.BrandName = GetTextVale(dr, "BrandName");
                objEntity.ProductGroupID = GetInt64(dr, "ProductGroupID");
                objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.CityCode = GetInt64(dr, "CityCode");
                objEntity.CityName = GetTextVale(dr, "CityName");
                objEntity.StateCode = GetInt64(dr, "StateCode");
                objEntity.StateName = GetTextVale(dr, "StateName");
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.OrderDate = GetDateTime(dr, "OrderDate");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.UnitRate = GetDecimal(dr, "UnitRate");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.SGSTPer = GetDecimal(dr, "SGSTPer");
                objEntity.CGSTPer = GetDecimal(dr, "CGSTPer");
                objEntity.IGSTPer = GetDecimal(dr, "IGSTPer");
                objEntity.SGSTAmt = GetDecimal(dr, "SGSTAmt");
                objEntity.CGSTAmt = GetDecimal(dr, "CGSTAmt");
                objEntity.IGSTAmt = GetDecimal(dr, "IGSTAmt");
                objEntity.TotSGST = GetDecimal(dr, "TotSGST");
                objEntity.TotCGST = GetDecimal(dr, "TotCGST");
                objEntity.TotIGST = GetDecimal(dr, "TotIGST");
                objEntity.TaxAmount = GetDecimal(dr, "TaxAmount");
                objEntity.NetAmount = GetDecimal(dr, "NetAmount");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // State wise Purchase Register Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        public virtual List<Entity.PurchaseReport> Report_StateWisePurReg(String pLoginUserID, Int64 City, Int64 State, Int64 CustomerId, DateTime pFromDate, DateTime pToDate)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "PurchaseRegister_Report";
            cmdGet.Parameters.AddWithValue("@LogInUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@BrandId", 0);
            cmdGet.Parameters.AddWithValue("@ProductGroupId", 0);
            cmdGet.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmdGet.Parameters.AddWithValue("@CityCode", City);
            cmdGet.Parameters.AddWithValue("@StateCode", State);
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.PurchaseReport> lstObject = new List<Entity.PurchaseReport>();
            while (dr.Read())
            {
                Entity.PurchaseReport objEntity = new Entity.PurchaseReport();
                objEntity.BrandID = GetInt64(dr, "BrandID");
                objEntity.BrandName = GetTextVale(dr, "BrandName");
                objEntity.ProductGroupID = GetInt64(dr, "ProductGroupID");
                objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.CityCode = GetInt64(dr, "CityCode");
                objEntity.CityName = GetTextVale(dr, "CityName");
                objEntity.StateCode = GetInt64(dr, "StateCode");
                objEntity.StateName = GetTextVale(dr, "StateName");
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.OrderDate = GetDateTime(dr, "OrderDate");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.UnitRate = GetDecimal(dr, "UnitRate");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.SGSTPer = GetDecimal(dr, "SGSTPer");
                objEntity.CGSTPer = GetDecimal(dr, "CGSTPer");
                objEntity.IGSTPer = GetDecimal(dr, "IGSTPer");
                objEntity.SGSTAmt = GetDecimal(dr, "SGSTAmt");
                objEntity.CGSTAmt = GetDecimal(dr, "CGSTAmt");
                objEntity.IGSTAmt = GetDecimal(dr, "IGSTAmt");
                objEntity.TotSGST = GetDecimal(dr, "TotSGST");
                objEntity.TotCGST = GetDecimal(dr, "TotCGST");
                objEntity.TotIGST = GetDecimal(dr, "TotIGST");
                objEntity.TaxAmount = GetDecimal(dr, "TaxAmount");
                objEntity.NetAmount = GetDecimal(dr, "NetAmount");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Product Purchase Register Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.PurchaseReport> PurchaseReportList(string pLoginUserID, string BrandID, string ProductGroupId, Int64 CustomerId, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.PurchaseReport> lstLocation = new List<Entity.PurchaseReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "PurchaseRegister_Report";
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@BrandID", BrandID);
            cmdGet.Parameters.AddWithValue("@ProductGroupId", ProductGroupId);
            cmdGet.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.PurchaseReport objEntity = new Entity.PurchaseReport();
                objEntity.BrandID = GetInt64(dr, "BrandID");
                objEntity.BrandName = GetTextVale(dr, "BrandName");
                objEntity.ProductGroupID = GetInt64(dr, "ProductGroupID");
                objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.CityCode = GetInt64(dr, "CityCode");
                objEntity.CityName = GetTextVale(dr, "CityName");
                objEntity.StateCode = GetInt64(dr, "StateCode");
                objEntity.StateName = GetTextVale(dr, "StateName");
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.OrderDate = GetDateTime(dr, "OrderDate");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.UnitRate = GetDecimal(dr, "UnitRate");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.SGSTPer = GetDecimal(dr, "SGSTPer");
                objEntity.CGSTPer = GetDecimal(dr, "CGSTPer");
                objEntity.IGSTPer = GetDecimal(dr, "IGSTPer");
                objEntity.SGSTAmt = GetDecimal(dr, "IGSTPer");
                objEntity.CGSTAmt = GetDecimal(dr, "CGSTAmt");
                objEntity.IGSTAmt = GetDecimal(dr, "IGSTAmt");
                objEntity.TotSGST = GetDecimal(dr, "TotSGST");
                objEntity.TotCGST = GetDecimal(dr, "TotCGST");
                objEntity.TotIGST = GetDecimal(dr, "TotIGST");
                objEntity.TaxAmount = GetDecimal(dr, "TaxAmount");
                objEntity.NetAmount = GetDecimal(dr, "NetAmount");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }


        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Product Vehicle Master Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.VehicleList> VehicleList(string pLoginUserID)
        {
            List<Entity.VehicleList> lstLocation = new List<Entity.VehicleList>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "VehicleReport";
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.VehicleList objEntity = new Entity.VehicleList();
                objEntity.RegistrationNo = GetTextVale(dr, "RegistrationNo");
                objEntity.OwnerName = GetTextVale(dr, "OwnerName");
                objEntity.ChasisNo = GetTextVale(dr, "ChasisNo");
                objEntity.Model = GetTextVale(dr, "Model");
                objEntity.OwnerAddress = GetTextVale(dr, "OwnerAddress");
                objEntity.OwnerMobile = GetTextVale(dr, "OwnerMobile");
                objEntity.InsuranceCompany = GetTextVale(dr, "InsuranceCompany");
                objEntity.InsurancePolicyNo = GetTextVale(dr, "InsurancePolicyNo");
                objEntity.InsuranceExpiry = GetDateTime(dr, "InsuranceExpiry");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Shift Master Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        public virtual List<Entity.ShiftReport> ShiftReportList(Int64 ShiftCode, string BasicPer, string pLoginUserID)
        {
            List<Entity.ShiftReport> lstLocation = new List<Entity.ShiftReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ShiftReport";
            cmdGet.Parameters.AddWithValue("@ShiftCode", ShiftCode);
            cmdGet.Parameters.AddWithValue("@BasicPer", BasicPer);
            //cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.ShiftReport objEntity = new Entity.ShiftReport();
                objEntity.ShiftName = GetTextVale(dr, "ShiftName");
                objEntity.BasicPer = GetTextVale(dr, "BasicPer");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // CashBook Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.CashBook> Report_CashBook(String pLoginUserID, DateTime pFromDate, DateTime pToDate, Int64 Ac, String nt)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "CashBook_Report";
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@CustID", Ac);
            cmdGet.Parameters.AddWithValue("@NT", nt);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.CashBook> lstObject = new List<Entity.CashBook>();
            while (dr.Read())
            {
                Entity.CashBook objEntity = new Entity.CashBook();
                objEntity.VoucherDate = GetDateTime(dr, "VoucherDate");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.Receivable = GetDecimal(dr, "Receivable");
                objEntity.Payable = GetDecimal(dr, "Payable");

                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // BankBook Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.BankBook> Report_BankBook(String pLoginUserID, DateTime pFromDate, DateTime pToDate, Int64 Ac, String nt)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "CashBook_Report";
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate.ToString("yyyy/MM/dd"));
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate.ToString("yyyy/MM/dd"));
            cmdGet.Parameters.AddWithValue("@CustID", Ac);
            cmdGet.Parameters.AddWithValue("@NT", nt);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.BankBook> lstObject = new List<Entity.BankBook>();
            while (dr.Read())
            {
                Entity.BankBook objEntity = new Entity.BankBook();
                objEntity.VoucherDate = GetDateTime(dr, "VoucherDate");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.Receivable = GetDecimal(dr, "Receivable");
                objEntity.Payable = GetDecimal(dr, "Payable");

                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // BankVoucher Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.BankVoucher> GetBankVoucher(string LoginUserID, Int64 CustomerID,Int64 Credit,DateTime FromDate, DateTime ToDate)
        {
            List<Entity.BankVoucher> lstLocation = new List<Entity.BankVoucher>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "BankVouherList_Report";
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@Credit", Credit);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.BankVoucher objEntity = new Entity.BankVoucher();
                objEntity.InvoiceNo = GetTextVale(dr, "InvoiceNo");
                objEntity.InvoiceDate = GetDateTime(dr, "InvoiceDate");
                objEntity.NoOfWheels = GetTextVale(dr, "NoOfWheels");
                objEntity.ClaimNo = GetTextVale(dr, "ClaimNo");
                objEntity.RegNo = GetTextVale(dr, "RegNo");
                objEntity.Surveyor = GetTextVale(dr, "Surveyor");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.Debit = GetDecimal(dr, "Debit");
                objEntity.Credit = GetDecimal(dr, "Credit");
                objEntity.TDSAmount = GetDecimal(dr, "TDSAmount");
                objEntity.PayableAmt = GetDecimal(dr, "PayableAmt");
                objEntity.LocationName = GetTextVale(dr, "LocationName");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // JV Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.JournalVoucherReport> Report_JV(String pLoginUserID, DateTime pFromDate, DateTime pToDate)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "JournalVoucher_Report";
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.JournalVoucherReport> lstObject = new List<Entity.JournalVoucherReport>();
            while (dr.Read())
            {
                Entity.JournalVoucherReport objEntity = new Entity.JournalVoucherReport();
                objEntity.VoucherDate = GetDateTime(dr, "VoucherDate");
                objEntity.CRCustomerID = GetInt64(dr, "CRCustomerID");
                objEntity.CRCustomerName = GetTextVale(dr, "CRCustomerName");
                objEntity.DBCustomerID = GetInt64(dr, "DBCustomerID");
                objEntity.DBCustomerName = GetTextVale(dr, "DBCustomerName");
                objEntity.VoucherType = GetTextVale(dr, "VoucherType");
                objEntity.VoucherNo = GetTextVale(dr, "VoucherNo");
                objEntity.TransType = GetTextVale(dr, "TransType");
                objEntity.DebitAmt = GetDecimal(dr, "DebitAmt");
                objEntity.CreditAmt = GetDecimal(dr, "CreditAmt");

                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // DBNote Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.DBNote> DBNote(string pLoginUserID, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.DBNote> lstLocation = new List<Entity.DBNote>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "DBNoteReport";
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.DBNote objEntity = new Entity.DBNote();
                objEntity.VoucherNo = GetTextVale(dr, "VoucherNo");
                objEntity.CRCustomerName = GetTextVale(dr, "CRCustomerName");
                objEntity.DBCustomerName = GetTextVale(dr, "DBCustomerName");
                //objEntity.CRCustomerID = GetInt64(dr, "CRCustomerID");
                //objEntity.DBCustomerID = GetInt64(dr, "DBCustomerID");
                objEntity.VoucherAmount = GetDecimal(dr, "VoucherAmount");
                objEntity.VoucherDate = GetDateTime(dr, "VoucherDate");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // CRNote Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.CRNote> CRNote(string pLoginUserID, DateTime FromDate, DateTime ToDate, Int64 PageNo, Int64 PageSize)
        {
            List<Entity.CRNote> lstLocation = new List<Entity.CRNote>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "CRNoteReport";
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@PageNo", PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", PageSize);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.CRNote objEntity = new Entity.CRNote();
                objEntity.VoucherNo = GetTextVale(dr, "VoucherNo");
                objEntity.CRCustomerName = GetTextVale(dr, "CRCustomerName");
                objEntity.DBCustomerName = GetTextVale(dr, "DBCustomerName");
                //objEntity.CRCustomerID = GetInt64(dr, "CRCustomerID");
                //objEntity.DBCustomerID = GetInt64(dr, "DBCustomerID");
                objEntity.VoucherAmount = GetDecimal(dr, "VoucherAmount");
                objEntity.VoucherDate = GetDateTime(dr, "VoucherDate");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.PettyCashReport> PettyCashReport(DateTime pFromDate, DateTime pToDate, String pLoginUserID, Int64 FixedLedger)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "PettyCashReport";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@CustomerID", FixedLedger);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.PettyCashReport> lstObject = new List<Entity.PettyCashReport>();
            while (dr.Read())
            {
                Entity.PettyCashReport objEntity = new Entity.PettyCashReport();
                //objEntity.Opening = GetDecimal(dr, "Opening");
                objEntity.VoucherNo = GetTextVale(dr, "VoucherNo");
                objEntity.Expense = GetDecimal(dr, "Expense");
                objEntity.Income = GetDecimal(dr, "Income");
                objEntity.CRCustomerName = GetTextVale(dr, "CRCustomerName");
                objEntity.DBCustomerName = GetTextVale(dr, "DBCustomerName");
                objEntity.VoucherDate = GetDateTime(dr, "VoucherDate");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        public virtual List<Entity.TrialBalanceReport> TrialBalanceReportList(string DBCR, string pLoginUserID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "TrialBalanceList";
            cmdGet.Parameters.AddWithValue("@DBCR", DBCR);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.TrialBalanceReport> lstObject = new List<Entity.TrialBalanceReport>();
            while (dr.Read())
            {
                Entity.TrialBalanceReport objEntity = new Entity.TrialBalanceReport();
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.Opening = GetDecimal(dr, "Opening");
                objEntity.Debit = GetDecimal(dr, "Debit");
                objEntity.Credit = GetDecimal(dr, "Credit");
                objEntity.Closing = GetDecimal(dr, "Closing");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // ==================================================================================================
        // Product Stock Report
        // ==================================================================================================
        public virtual List<Entity.ProductStockReport> ProductStockReportList(string pLoginUserID,string ProductGroupName,string BrandName, Int64 ProductID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ProductStockList";
            cmdGet.Parameters.AddWithValue("@ProductGroupName", ProductGroupName);
            cmdGet.Parameters.AddWithValue("@BrandName", BrandName);
            cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.ProductStockReport> lstObject = new List<Entity.ProductStockReport>();
            while (dr.Read())
            {
                Entity.ProductStockReport objEntity = new Entity.ProductStockReport();
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                objEntity.BrandName = GetTextVale(dr, "BrandName");
                objEntity.OpeningSTK = GetDecimal(dr, "OpeningSTK");
                objEntity.InwardSTK = GetDecimal(dr, "InwardSTK");
                objEntity.OutwardSTK = GetDecimal(dr, "OutwardSTK");
                objEntity.ClosingSTK = GetDecimal(dr, "ClosingSTK");

                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // ==================================================================================================
        // Report : Rojmel Report
        // ==================================================================================================
        public virtual List<Entity.Rojmel> Report_Rojmel(DateTime pFromDate, DateTime pToDate, string pLoginUserID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "Rojmel_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.Rojmel> lstObject = new List<Entity.Rojmel>();
            while (dr.Read())
            {
                Entity.Rojmel objEntity = new Entity.Rojmel();
                objEntity.Rownum = GetInt64(dr, "Rownum");
                objEntity.Opening = GetDecimal(dr, "Opening");
                objEntity.IncomeRs = GetDecimal(dr, "IncomeRs");
                objEntity.IncomeCustCode = GetInt64(dr, "IncomeCustCode");
                objEntity.Income = GetTextVale(dr, "Income");
                objEntity.IncomeClosing = GetDecimal(dr, "IncomeClosing");
                objEntity.IncomeRemark = GetTextVale(dr, "IncomeRemark");
                objEntity.ExpenseRs = GetDecimal(dr, "ExpenseRs");
                objEntity.ExpenseCustCode = GetInt64(dr, "ExpenseCustCode");
                objEntity.Expense = GetTextVale(dr, "Expense");
                objEntity.ExpenseClosing = GetDecimal(dr, "ExpenseClosing");
                objEntity.ExpenseRemark = GetTextVale(dr, "ExpenseRemark");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }
        
        // ==================================================================================================
        // Report : Stock Report
        // ==================================================================================================
        public virtual List<Entity.ProductStockReport> Report_Stock(string pLoginUserID, DateTime pToDate)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "Stock_Report";
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@dtDate", pToDate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.ProductStockReport> lstObject = new List<Entity.ProductStockReport>();
            while (dr.Read())
            {
                Entity.ProductStockReport objEntity = new Entity.ProductStockReport();
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.TranDate = GetDateTime(dr, "TranDate");
                objEntity.OpeningSTK = GetDecimal(dr, "OpeningSTK");
                objEntity.InwardSTK = GetDecimal(dr, "InwardSTK");
                objEntity.OutwardSTK = GetDecimal(dr, "OutwardSTK");
                objEntity.ClosingSTK = GetDecimal(dr, "ClosingSTK");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // Fleet Management Reports - trip by vehical
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.VehicleTrip> Report_Trip(DateTime pFromDate, DateTime pToDate, string pLoginUserID, Int64 EmployeeID, Int64 VehicleID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "VehicleKilometerReading_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(pFromDate).ToString("yyyy-MM-dd"));
            cmdGet.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(pToDate).ToString("yyyy-MM-dd"));
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@VehicleID", VehicleID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.VehicleTrip> lstObject = new List<Entity.VehicleTrip>();
            while (dr.Read())
            {
                Entity.VehicleTrip objEntity = new Entity.VehicleTrip();
                objEntity.TripDate = GetDateTime(dr, "TripDate");
                objEntity.Reading1 = GetInt64(dr, "Reading1");
                objEntity.Reading2 = GetInt64(dr, "Reading2");
                objEntity.Kilometers = GetInt64(dr, "Kilometers");
                objEntity.DieselCharge = GetDecimal(dr, "DieselCharge");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.AvgKmPerLtr = GetDecimal(dr, "AvgKmPerLtr");
                objEntity.FuelCostPerKM = GetDecimal(dr, "FuelCostPerKM");
                objEntity.DriverName = GetTextVale(dr, "DriverName");
                objEntity.From_Station = GetTextVale(dr, "From_Station");
                objEntity.To_Station = GetTextVale(dr, "To_Station");
                objEntity.VehicleID = GetInt64(dr, "VehicleID");
                objEntity.RegistrationNo = GetTextVale(dr, "RegistrationNo");
                objEntity.RateOfKMAllowance = GetDecimal(dr, "RateOfKMAllowance");
                objEntity.DriwingAllowance = GetDecimal(dr, "DriwingAllowance");
                objEntity.Toll = GetDecimal(dr, "Toll");
                objEntity.Bhatthu = GetDecimal(dr, "Bhatthu");
                objEntity.DriverAllowance = GetDecimal(dr, "DriverAllowance");
                objEntity.Remarks = GetTextVale(dr, "Remarks");

                //------------Newly Added--------------------------
                objEntity.InsuranceAmount = GetDecimal(dr, "InsuranceAmount");
                objEntity.InsurancePerTrip = GetDecimal(dr, "InsurancePerTrip");
                objEntity.GovernmentTax = GetDecimal(dr, "GovernmentTax");
                objEntity.ExplosiveTax = GetDecimal(dr, "ExplosiveTax");
                objEntity.VehicleAmount = GetDecimal(dr, "VehicleAmount");
                objEntity.DepreciationPerDay = GetDecimal(dr, "DepreciationPerDay");
                objEntity.WeightKgPerCylinderQty = GetDecimal(dr, "WeightKgPerCylinderQty");
                objEntity.MaterialName = GetTextVale(dr, "MaterialName");
                //----------------------------------------------------

                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Fleet Management Reports - trip by Driver
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.VehicleTrip> Report_TripByDriver(DateTime pFromDate, DateTime pToDate, string pLoginUserID, Int64 EmployeeID, Int64 VehicleID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "VehicleKilometerReading_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(pFromDate).ToString("yyyy-MM-dd"));
            cmdGet.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(pToDate).ToString("yyyy-MM-dd"));
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@VehicleID", VehicleID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.VehicleTrip> lstObject = new List<Entity.VehicleTrip>();
            while (dr.Read())
            {
                Entity.VehicleTrip objEntity = new Entity.VehicleTrip();
                objEntity.TripDate = GetDateTime(dr, "TripDate");
                objEntity.Reading1 = GetInt64(dr, "Reading1");
                objEntity.Reading2 = GetInt64(dr, "Reading2");
                objEntity.Kilometers = GetInt64(dr, "Kilometers");
                objEntity.DieselCharge = GetDecimal(dr, "DieselCharge");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.AvgKmPerLtr = GetDecimal(dr, "AvgKmPerLtr");
                objEntity.FuelCostPerKM = GetDecimal(dr, "FuelCostPerKM");
                objEntity.DriverName = GetTextVale(dr, "DriverName");
                objEntity.From_Station = GetTextVale(dr, "From_Station");
                objEntity.To_Station = GetTextVale(dr, "To_Station");
                objEntity.VehicleID = GetInt64(dr, "VehicleID");
                objEntity.RegistrationNo = GetTextVale(dr, "RegistrationNo");
                objEntity.RateOfKMAllowance = GetDecimal(dr, "RateOfKMAllowance");
                objEntity.DriwingAllowance = GetDecimal(dr, "DriwingAllowance");
                objEntity.Toll = GetDecimal(dr, "Toll");
                objEntity.Bhatthu = GetDecimal(dr, "Bhatthu");
                objEntity.Salary = GetDecimal(dr, "Salary");
                objEntity.TotalExpense = GetDecimal(dr, "TotalExpense");
                objEntity.DriverAllowance = GetDecimal(dr, "DriverAllowance");
                objEntity.Remarks = GetTextVale(dr, "Remarks");

                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        //// *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //// Fleet Management Reports
        //// *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //public virtual List<Entity.VehicleTrip> Report_Trip(DateTime pFromDate, DateTime pToDate, string pLoginUserID)
        //{
        //    SqlCommand cmdGet = new SqlCommand();
        //    cmdGet.CommandType = CommandType.StoredProcedure;
        //    cmdGet.CommandText = "VehicleKilometerReading_Report";
        //    cmdGet.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(pFromDate).ToString("yyyy-MM-dd"));
        //    cmdGet.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(pToDate).ToString("yyyy-MM-dd"));
        //    cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
        //    SqlDataReader dr = ExecuteDataReader(cmdGet);
        //    List<Entity.VehicleTrip> lstObject = new List<Entity.VehicleTrip>();
        //    while (dr.Read())
        //    {
        //        Entity.VehicleTrip objEntity = new Entity.VehicleTrip();
        //        objEntity.TripDate = GetDateTime(dr, "TripDate");
        //        objEntity.Reading1 = GetInt64(dr, "Reading1");
        //        objEntity.Reading2 = GetInt64(dr, "Reading2");
        //        objEntity.Kilometers = GetInt64(dr, "Kilometers");
        //        objEntity.DieselCharge = GetDecimal(dr, "DieselCharge");
        //        objEntity.Amount = GetDecimal(dr, "Amount");
        //        objEntity.AvgKmPerLtr = GetDecimal(dr, "AvgKmPerLtr");
        //        objEntity.FuelCostPerKM = GetDecimal(dr, "FuelCostPerKM");
        //        objEntity.DriverName = GetTextVale(dr, "DriverName");
        //        objEntity.From_Station = GetTextVale(dr, "From_Station");
        //        objEntity.To_Station = GetTextVale(dr, "To_Station");
        //        objEntity.VehicleID = GetInt64(dr, "VehicleID");
        //        objEntity.RegistrationNo = GetTextVale(dr, "RegistrationNo");
        //        objEntity.RateOfKMAllowance = GetDecimal(dr, "RateOfKMAllowance");
        //        objEntity.DriwingAllowance = GetDecimal(dr, "DriwingAllowance");

        //        lstObject.Add(objEntity);
        //    }
        //    dr.Close();
        //    ForceCloseConncetion();
        //    return lstObject;
        //}

        // ==================================================================================================
        // Report : Inquiry List (Periodical)
        // ==================================================================================================
        public virtual List<Entity.InquiryInfo> Report_InquiryList(String pReportType, DateTime pFromDate, DateTime pToDate, string pLoginUserID, string pInquirySource, string pInquiryStatus)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "InquiryListByPeriod";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@InquirySource", pInquirySource);
            cmdGet.Parameters.AddWithValue("@InquiryStatus", pInquiryStatus);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@ReportType", pReportType);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.InquiryInfo> lstObject = new List<Entity.InquiryInfo>();
            while (dr.Read())
            {
                Entity.InquiryInfo objEntity = new Entity.InquiryInfo();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                objEntity.InquiryDate = GetDateTime(dr, "InquiryDate");
                objEntity.ReferenceName = GetTextVale(dr, "ReferenceName");
                objEntity.InquirySource = GetTextVale(dr, "InquirySource");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.Designation = GetTextVale(dr, "Designation");


                objEntity.MeetingNotes = GetTextVale(dr, "MeetingNotes");
                objEntity.FollowupNotes = GetTextVale(dr, "FollowupNotes");
                objEntity.FollowupDate = GetDateTime(dr, "FollowupDate");
                objEntity.InquiryStatusID = GetInt64(dr, "InquiryStatusID");
                objEntity.InquiryStatus = GetTextVale(dr, "InquiryStatus");
                objEntity.TotalAmount = GetDecimal(dr, "TotalAmount");
                if (pReportType == "inquirydetail")
                {
                    objEntity.ProductName = GetTextVale(dr, "ProductName");
                    objEntity.BrandName = GetTextVale(dr, "BrandName");
                    objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                    objEntity.Quantity = GetDecimal(dr, "Quantity");
                    objEntity.UnitPrice = GetDecimal(dr, "UnitPrice");
                    objEntity.TaxRate = GetDecimal(dr, "TaxRate");
                    objEntity.TotalAmount = GetDecimal(dr, "TotalAmount");
                }
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        public virtual List<Entity.InquiryInfo_Report> Report_InquiryList_Report(String pReportType, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string pLoginUserID, string pInquirySource, string pInquiryStatus, int EmployeeID, Int64 CustomerID, string pStateCode, string pCityCode, Int64 ProductID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "InquiryList_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@InquirySource", pInquirySource);
            cmdGet.Parameters.AddWithValue("@InquiryStatus", pInquiryStatus);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@ReportType", pReportType);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@StateCode", pStateCode);
            cmdGet.Parameters.AddWithValue("@CityCode", pCityCode);
            cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.InquiryInfo_Report> lstObject = new List<Entity.InquiryInfo_Report>();
            while (dr.Read())
            {
                Entity.InquiryInfo_Report objEntity = new Entity.InquiryInfo_Report();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                objEntity.InquiryDate = GetDateTime(dr, "InquiryDate");
                objEntity.ReferenceName = GetTextVale(dr, "ReferenceName");
                objEntity.InquirySource = GetTextVale(dr, "InquirySource");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.CustAddress = GetTextVale(dr, "CustAddress");
                objEntity.GSTNO = GetTextVale(dr, "GSTNO");
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.Designation = GetTextVale(dr, "Designation");
                objEntity.ContactNo1 = GetTextVale(dr, "ContactNo1");
                objEntity.MeetingNotes = GetTextVale(dr, "MeetingNotes");
                objEntity.FollowupNotes = GetTextVale(dr, "FollowupNotes");
                objEntity.FollowupDate = GetDateTime(dr, "FollowupDate");
                objEntity.InquiryStatusID = GetInt64(dr, "InquiryStatusID");
                objEntity.InquiryStatus = GetTextVale(dr, "InquiryStatus");
                objEntity.TotalAmount = GetDecimal(dr, "TotalAmount");
                objEntity.ClosureDate = GetDateTime(dr, "ClosureDate");
                if (pReportType == "inquirydetail")
                {
                    objEntity.ProductName = GetTextVale(dr, "ProductName");
                    objEntity.BrandName = GetTextVale(dr, "BrandName");
                    objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                    objEntity.Quantity = GetDecimal(dr, "Quantity");
                    objEntity.UnitPrice = GetDecimal(dr, "UnitPrice");
                    objEntity.TaxRate = GetDecimal(dr, "TaxRate");
                    objEntity.TotalAmount = GetDecimal(dr, "TotalAmount");
                }
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        //==================================================================================================
        //Report : Quotation List (Periodical)
        //==================================================================================================
        public virtual List<Entity.Quotation> Report_QuotationList(String pReportType, DateTime pFromDate, DateTime pToDate, string pLoginUserID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "QuotationListByPeriod";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@ReportType", pReportType);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.Quotation> lstObject = new List<Entity.Quotation>();
            while (dr.Read())
            {
                Entity.Quotation objEntity = new Entity.Quotation();

                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                objEntity.QuotationNo = GetTextVale(dr, "QuotationNo");
                objEntity.QuotationDate = GetDateTime(dr, "QuotationDate");
                objEntity.QuotationSubject = GetTextVale(dr, "QuotationSubject");
                objEntity.QuotationKindAttn = GetTextVale(dr, "QuotationKindAttn");
                objEntity.ProjectName = GetTextVale(dr, "ProjectName");
                objEntity.QuotationHeader = GetTextVale(dr, "QuotationHeader");
                objEntity.QuotationFooter = GetTextVale(dr, "QuotationFooter");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.Area = GetTextVale(dr, "Area");
                objEntity.City = GetTextVale(dr, "City");
                objEntity.PinCode = GetTextVale(dr, "Pincode");
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.ContactNo1 = GetTextVale(dr, "ContactNo1");
                objEntity.ContactNo2 = GetTextVale(dr, "ContactNo2");
                objEntity.QuotationAmount = GetDecimal(dr, "QuotationAmount");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");
                objEntity.CreatedEmployeeName = GetTextVale(dr, "CreatedEmployeeName");
                objEntity.UpdatedEmployeeName = GetTextVale(dr, "UpdatedEmployeeName");
                if (pReportType == "quotationdetail")
                {
                    objEntity.ProductName = GetTextVale(dr, "ProductName");
                    objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                    objEntity.BrandName = GetTextVale(dr, "BrandName");
                    objEntity.Quantity = GetDecimal(dr, "Quantity");
                    objEntity.Unit = GetTextVale(dr, "Unit");
                    objEntity.UnitRate = GetDecimal(dr, "UnitRate");
                    objEntity.DiscountPercent = GetDecimal(dr, "DiscountPercent");
                    objEntity.NetRate = GetDecimal(dr, "NetRate");
                    objEntity.Amount = GetDecimal(dr, "Amount");
                    objEntity.TaxRate = GetDecimal(dr, "TaxRate");
                    objEntity.TaxAmount = GetDecimal(dr, "TaxAmount");
                    objEntity.NetAmount = GetDecimal(dr, "NetAmount");
                }
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        public virtual List<Entity.Quotation> Report_QuotationList_Report(String pReportType, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string pLoginUserID, int EmployeeID, Int64 pCustomerID, String BasedCountry)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "QuotationListByPeriod_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@ReportType", pReportType);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@CustomerID", pCustomerID);
            cmdGet.Parameters.AddWithValue("@BasedOnCountry", BasedCountry);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.Quotation> lstObject = new List<Entity.Quotation>();
            while (dr.Read())
            {
                Entity.Quotation objEntity = new Entity.Quotation();

                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                objEntity.QuotationNo = GetTextVale(dr, "QuotationNo");
                objEntity.QuotationDate = GetDateTime(dr, "QuotationDate");
                objEntity.QuotationSubject = GetTextVale(dr, "QuotationSubject");
                objEntity.QuotationKindAttn = GetTextVale(dr, "QuotationKindAttn");
                objEntity.ProjectName = GetTextVale(dr, "ProjectName");
                objEntity.QuotationHeader = GetTextVale(dr, "QuotationHeader");
                objEntity.QuotationFooter = GetTextVale(dr, "QuotationFooter");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.Area = GetTextVale(dr, "Area");
                objEntity.City = GetTextVale(dr, "City");
                objEntity.Country = GetTextVale(dr, "Country");
                objEntity.PinCode = GetTextVale(dr, "Pincode");
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.ContactNo1 = GetTextVale(dr, "ContactNo1");
                objEntity.ContactNo2 = GetTextVale(dr, "ContactNo2");
                objEntity.QuotationAmount = GetDecimal(dr, "QuotationAmount");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");
                objEntity.CreatedEmployeeName = GetTextVale(dr, "CreatedEmployeeName");
                objEntity.UpdatedEmployeeName = GetTextVale(dr, "UpdatedEmployeeName");
                if (pReportType == "quotationdetail")
                {
                    objEntity.ProductName = GetTextVale(dr, "ProductName");
                    objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                    objEntity.BrandName = GetTextVale(dr, "BrandName");
                    objEntity.Quantity = GetDecimal(dr, "Quantity");
                    objEntity.Unit = GetTextVale(dr, "Unit");
                    objEntity.UnitRate = GetDecimal(dr, "UnitRate");
                    objEntity.DiscountPercent = GetDecimal(dr, "DiscountPercent");
                    objEntity.NetRate = GetDecimal(dr, "NetRate");
                    objEntity.Amount = GetDecimal(dr, "Amount");
                    objEntity.TaxRate = GetDecimal(dr, "TaxRate");
                    objEntity.TaxAmount = GetDecimal(dr, "TaxAmount");
                    objEntity.NetAmount = GetDecimal(dr, "NetAmount");
                }
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        //==================================================================================================
        //Report : Vedant Quotation
        //==================================================================================================
        
        // Here
        public virtual List<Entity.VedantQuotation> VedantQuotationList_Report(DateTime pFromDate, DateTime pToDate, string pLoginUserID, String BasedCountry)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "VedantQuotation_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@BasedOnCountry", BasedCountry);
            SqlDataReader dr = ExecuteDataReader(cmdGet);

            List<Entity.VedantQuotation> lstObject = new List<Entity.VedantQuotation>();
            while (dr.Read())
            {
                Entity.VedantQuotation objEntity = new Entity.VedantQuotation();

                objEntity.QuotationNo = GetTextVale(dr, "QuotationNo");
                objEntity.QuotationDate = GetDateTime(dr, "QuotationDate");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProjectName = GetTextVale(dr, "ProjectName");
                objEntity.QuotationSubject = GetTextVale(dr, "QuotationSubject");
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.ContactNo1 = GetTextVale(dr, "ContactNo1");
                objEntity.ContactNo2 = GetTextVale(dr, "ContactNo2");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }



        //==================================================================================================
        //Report : Sales Order List (Periodical)
        //==================================================================================================

        public virtual List<Entity.SalesOrder> Report_SalesOrderList(String pReportType, DateTime pFromDate, DateTime pToDate, string pLoginUserID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SalesOrderListByPeriod";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@ReportType", pReportType);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.SalesOrder> lstObject = new List<Entity.SalesOrder>();
            while (dr.Read())
            {
                Entity.SalesOrder objEntity = new Entity.SalesOrder();

                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.OrderDate = GetDateTime(dr, "OrderDate");
                objEntity.QuotationNo = GetTextVale(dr, "QuotationNo");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.Area = GetTextVale(dr, "Area");
                objEntity.City = GetTextVale(dr, "City");
                objEntity.PinCode = GetTextVale(dr, "Pincode");
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.ContactNo1 = GetTextVale(dr, "ContactNo1");
                objEntity.ContactNo2 = GetTextVale(dr, "ContactNo2");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.TermsCondition = GetTextVale(dr, "TermsCondition");
                objEntity.OrderAmount = GetDecimal(dr, "OrderAmount");
                objEntity.ApprovalStatus = GetTextVale(dr, "ApprovalStatus");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");

                if (pReportType == "salesorderdetail")
                {
                    objEntity.ProductName = GetTextVale(dr, "ProductName");
                    objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                    objEntity.BrandName = GetTextVale(dr, "BrandName");
                    objEntity.Quantity = GetDecimal(dr, "Quantity");
                    objEntity.Unit = GetTextVale(dr, "Unit");
                    objEntity.UnitRate = GetDecimal(dr, "UnitRate");
                    objEntity.DiscountPercent = GetDecimal(dr, "DiscountPercent");
                    objEntity.NetRate = GetDecimal(dr, "NetRate");
                    objEntity.Amount = GetDecimal(dr, "Amount");
                    objEntity.TaxRate = GetDecimal(dr, "TaxRate");
                    objEntity.TaxAmount = GetDecimal(dr, "TaxAmount");
                    objEntity.NetAmount = GetDecimal(dr, "NetAmount");
                }

                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        public virtual List<Entity.SalesOrder> Report_SalesOrderList_Report(String pReportType, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string pLoginUserID, int EmployeeID, Int64 pCustomerID, string ApprovalStatus)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SalesOrderListByPeriod_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@ReportType", pReportType);
            cmdGet.Parameters.AddWithValue("@EmpID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@CustomerID", pCustomerID);
            cmdGet.Parameters.AddWithValue("@ApprovalStatus", ApprovalStatus);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.SalesOrder> lstObject = new List<Entity.SalesOrder>();
            while (dr.Read())
            {
                Entity.SalesOrder objEntity = new Entity.SalesOrder();

                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.OrderDate = GetDateTime(dr, "OrderDate");
                objEntity.QuotationNo = GetTextVale(dr, "QuotationNo");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.Area = GetTextVale(dr, "Area");
                objEntity.City = GetTextVale(dr, "City");
                objEntity.PinCode = GetTextVale(dr, "Pincode");
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.ContactNo1 = GetTextVale(dr, "ContactNo1");
                objEntity.ContactNo2 = GetTextVale(dr, "ContactNo2");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.TermsCondition = GetTextVale(dr, "TermsCondition");
                objEntity.OrderAmount = GetDecimal(dr, "OrderAmount");
                objEntity.ApprovalStatus = GetTextVale(dr, "ApprovalStatus");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");

                if (pReportType == "salesorderdetail")
                {
                    objEntity.ProductName = GetTextVale(dr, "ProductName");
                    objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                    objEntity.BrandName = GetTextVale(dr, "BrandName");
                    objEntity.Quantity = GetDecimal(dr, "Quantity");
                    objEntity.Unit = GetTextVale(dr, "Unit");
                    objEntity.UnitRate = GetDecimal(dr, "UnitRate");
                    objEntity.DiscountPercent = GetDecimal(dr, "DiscountPercent");
                    objEntity.NetRate = GetDecimal(dr, "NetRate");
                    objEntity.Amount = GetDecimal(dr, "Amount");
                    objEntity.TaxRate = GetDecimal(dr, "TaxRate");
                    objEntity.TaxAmount = GetDecimal(dr, "TaxAmount");
                    objEntity.NetAmount = GetDecimal(dr, "NetAmount");
                }

                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // ==================================================================================================
        // Purchase Order List Remove ProjectID On 16-03-2022
        // ==================================================================================================
        public virtual List<Entity.PurchaseOrder> Report_PurchaseOrderList_Report(String pReportType, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string pLoginUserID, int EmployeeID, Int64 pCustomerID, string ApprovalStatus) //Int64 ProjectID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "PurchaseOrderListByPeriod_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@ReportType", pReportType);
            cmdGet.Parameters.AddWithValue("@EmpID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@CustomerID", pCustomerID);
            cmdGet.Parameters.AddWithValue("@ApprovalStatus", ApprovalStatus);
            //cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.PurchaseOrder> lstObject = new List<Entity.PurchaseOrder>();
            while (dr.Read())
            {
                Entity.PurchaseOrder objEntity = new Entity.PurchaseOrder();

                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.OrderDate = GetDateTime(dr, "OrderDate");
                objEntity.QuotationNo = GetTextVale(dr, "QuotationNo");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.Area = GetTextVale(dr, "Area");
                objEntity.City = GetTextVale(dr, "City");
                objEntity.PinCode = GetTextVale(dr, "Pincode");
                objEntity.ProjectName = GetTextVale(dr, "ProjectName"); // Change By Sahil
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.ContactNo1 = GetTextVale(dr, "ContactNo1");
                objEntity.ContactNo2 = GetTextVale(dr, "ContactNo2");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.TermsCondition = GetTextVale(dr, "TermsCondition");
                objEntity.OrderAmount = GetDecimal(dr, "OrderAmount");
                objEntity.ApprovalStatus = GetTextVale(dr, "ApprovalStatus");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");

                if (pReportType == "purchaseorderdetail")
                {
                    objEntity.ProductName = GetTextVale(dr, "ProductName");
                    objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                    objEntity.BrandName = GetTextVale(dr, "BrandName");
                    objEntity.Quantity = GetDecimal(dr, "Quantity");
                    objEntity.Unit = GetTextVale(dr, "Unit");
                    objEntity.UnitRate = GetDecimal(dr, "UnitRate");
                    objEntity.DiscountPercent = GetDecimal(dr, "DiscountPercent");
                    objEntity.NetRate = GetDecimal(dr, "NetRate");
                    objEntity.Amount = GetDecimal(dr, "Amount");
                    objEntity.TaxRate = GetDecimal(dr, "TaxRate");
                    objEntity.TaxAmount = GetDecimal(dr, "TaxAmount");
                    objEntity.NetAmount = GetDecimal(dr, "NetAmount");
                }

                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }
        // ==================================================================================================
        // Report : City Master List
        // ==================================================================================================
        public virtual List<Entity.City> Report_CityMasterList()
        {

            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "CityList";
            cmdAdd.Parameters.AddWithValue("@CityCode", "");
            cmdAdd.Parameters.AddWithValue("@ListMode", "L");
            SqlDataReader dr = ExecuteDataReader(cmdAdd);
            // ---------------------------------------------------------
            List<Entity.City> lstEntity = new List<Entity.City>();
            while (dr.Read())
            {
                Entity.City objEntity = new Entity.City();

                objEntity.CityCode = GetInt64(dr, "CityCode");
                objEntity.CityName = GetTextVale(dr, "CityName");
                objEntity.StateCode = GetInt64(dr, "StateCode");
                objEntity.StateName = GetTextVale(dr, "StateName");
                //--------------------------------------------------------------------
                lstEntity.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstEntity;
        }

        //-----------------------------------------------------------------------------
        // Report : Customer Master List1 Report By Sahil
        //-----------------------------------------------------------------------------

        public virtual List<Entity.CustomerMasterList> Report_CustomerMasterList1(string pLoginUserID, Int64 CustomerID, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string CustomerStatus, string CustomerType, Int64 StateCode, Int64 CityCode)
        {

            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "CustomerList1_Report";
            cmdAdd.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdAdd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdAdd.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdAdd.Parameters.AddWithValue("@ToDate", pToDate);
            cmdAdd.Parameters.AddWithValue("@Status", CustomerStatus);
            cmdAdd.Parameters.AddWithValue("@CustomerType", CustomerType);
            cmdAdd.Parameters.AddWithValue("@StateCode", StateCode);
            cmdAdd.Parameters.AddWithValue("@CityCode", CityCode);


            SqlDataReader dr = ExecuteDataReader(cmdAdd);

            List<Entity.CustomerMasterList> lstEntity = new List<Entity.CustomerMasterList>();
            while (dr.Read())
            {
                // -------------------------------------------------------------------
                Entity.CustomerMasterList objEntity = new Entity.CustomerMasterList();

                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CompanyName = GetTextVale(dr, "CompanyName");
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.CityName = GetTextVale(dr, "CityName");
                objEntity.CompanyType = GetTextVale(dr, "CompanyType");
                objEntity.StateName = GetTextVale(dr, "StateName");
                objEntity.PrimaryContactNo1 = GetTextVale(dr, "PrimaryContactNo1");
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.WebsiteAddress = GetTextVale(dr, "WebsiteAddress");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.BlockCustomerStatus = GetTextVale(dr, "BlockCustomerStatus");
                objEntity.GSTNo = GetTextVale(dr, "GSTNO");
                objEntity.PANNo = GetTextVale(dr, "PANNO");
                objEntity.JoinAsDealer = GetDateTime(dr, "JoinAsDealer");
                objEntity.MonthlySales = GetTextVale(dr, "MonthlySales");
                //--------------------------------------------------------------------
                lstEntity.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstEntity;
        }


        // ==================================================================================================
        // Report : Customer Master List
        // ==================================================================================================
        public virtual List<Entity.Customer> Report_CustomerMasterList(string pLoginUserID, Int64 CustomerID, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string CustomerStatus, string CustomerType, Int64 StateCode, Int64 CityCode)
        {

            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "CustomerList_Report";
            cmdAdd.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdAdd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdAdd.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdAdd.Parameters.AddWithValue("@ToDate", pToDate);
            cmdAdd.Parameters.AddWithValue("@Status", CustomerStatus);
            cmdAdd.Parameters.AddWithValue("@CustomerType", CustomerType);
            cmdAdd.Parameters.AddWithValue("@StateCode", StateCode);
            cmdAdd.Parameters.AddWithValue("@CityCode", CityCode);


            SqlDataReader dr = ExecuteDataReader(cmdAdd);

            List<Entity.Customer> lstEntity = new List<Entity.Customer>();
            while (dr.Read())
            {
                // -------------------------------------------------------------------
                Entity.Customer objEntity = new Entity.Customer();

                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.CityName = GetTextVale(dr, "CityName");
                objEntity.CustomerType = GetTextVale(dr, "CustomerType");
                objEntity.StateName = GetTextVale(dr, "StateName");
                objEntity.ContactNo1 = GetTextVale(dr, "ContactNo1");
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.WebsiteAddress = GetTextVale(dr, "WebsiteAddress");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.BlockCustomerStatus = GetTextVale(dr, "BlockCustomerStatus");
                objEntity.GSTNo = GetTextVale(dr, "GSTNO");
                objEntity.PANNo = GetTextVale(dr, "PANNO");
                objEntity.CINNo = GetTextVale(dr, "CINNO");
                //--------------------------------------------------------------------
                lstEntity.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstEntity;
        }
        // ==================================================================================================
        // Report : Customer Ledger 
        // ==================================================================================================
        public virtual List<Entity.FinancialTrans> Report_CustomerLedger(string TransCategory, string LoginUserID)
        {

            List<Entity.FinancialTrans> lstLocation = new List<Entity.FinancialTrans>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "FinancialTransList";
            cmdGet.Parameters.AddWithValue("@pkID", 0);
            cmdGet.Parameters.AddWithValue("@TransCategory", TransCategory);
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@PageNo", 0);
            cmdGet.Parameters.AddWithValue("@PageSize", 0);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.FinancialTrans objEntity = new Entity.FinancialTrans();
                //objEntity.pkID = GetInt64(dr, "pkID");
                //objEntity.TransCategory = GetTextVale(dr, "TransCategory");
                //objEntity.TransType = GetTextVale(dr, "TransType");
                //objEntity.TransDate = GetDateTime(dr, "TransDate");
                //objEntity.CustomerID = GetInt64(dr, "CustomerID");
                //objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                //objEntity.TransMode = GetTextVale(dr, "TransMode");
                //objEntity.TransAmount = GetDecimal(dr, "TransAmount");
                //objEntity.TransFrom = GetTextVale(dr, "TransFrom");
                //objEntity.TransID = GetTextVale(dr, "TransID");
                //objEntity.TransNotes = GetTextVale(dr, "TransNotes");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            //TotalRecord = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.FinancialTrans> Report_GetFinancialTransection(string TransCategory, string LoginUserID, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate)
        {

            List<Entity.FinancialTrans> lstLocation = new List<Entity.FinancialTrans>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "FinancialTransList_Report";
            cmdGet.Parameters.AddWithValue("@pkID", 0);
            cmdGet.Parameters.AddWithValue("@ListMode", "L");
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@TransCategory", TransCategory);
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@PageNo", 1);
            cmdGet.Parameters.AddWithValue("@PageSize", 1000);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.FinancialTrans objEntity = new Entity.FinancialTrans();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.VoucherType = GetTextVale(dr, "VoucherType");
                objEntity.TransType = GetTextVale(dr, "TransType");
                objEntity.TransDate = GetDateTime(dr, "TransDate");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.TransModeName = GetTextVale(dr, "TransModeName");
                objEntity.TransID = GetTextVale(dr, "TransID");
                objEntity.VoucherAmount = GetDecimal(dr, "VoucherAmount");
                objEntity.AccountName = GetTextVale(dr, "AccountName");
                objEntity.VoucherNo = GetTextVale(dr, "VoucherNo");
                objEntity.Remark = GetTextVale(dr, "Remark");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            //TotalRecord = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConncetion();
            return lstLocation;
        }

        // ==================================================================================================
        // Report : Designations Master List
        // ==================================================================================================
        public virtual List<Entity.Designations> Report_DesignationsMasterList()
        {

            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "DesignationList";
            cmdAdd.Parameters.AddWithValue("@DesigCode", "");
            cmdAdd.Parameters.AddWithValue("@ListMode", "L");
            SqlDataReader dr = ExecuteDataReader(cmdAdd);
            // ---------------------------------------------------------
            List<Entity.Designations> lstEntity = new List<Entity.Designations>();
            while (dr.Read())
            {
                Entity.Designations objEntity = new Entity.Designations();

                objEntity.DesigCode = GetTextVale(dr, "DesigCode");
                objEntity.Designation = GetTextVale(dr, "Designation");
                objEntity.ActiveFlag = GetBoolean(dr, "ActiveFlag");
                //--------------------------------------------------------------------
                lstEntity.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstEntity;
        }

        // ==================================================================================================
        // Report : EmailTemplate Master List
        // ==================================================================================================
        public virtual List<Entity.EmailTemplate> Report_EmailTemplateMasterList()
        {

            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "EmailTemplateList";
            cmdAdd.Parameters.AddWithValue("@TemplateID", "");
            cmdAdd.Parameters.AddWithValue("@Category", "");
            cmdAdd.Parameters.AddWithValue("@ListMode", "L");
            SqlDataReader dr = ExecuteDataReader(cmdAdd);
            // ---------------------------------------------------------
            List<Entity.EmailTemplate> lstEntity = new List<Entity.EmailTemplate>();
            while (dr.Read())
            {
                Entity.EmailTemplate objEntity = new Entity.EmailTemplate();

                objEntity.TemplateID = GetTextVale(dr, "TemplateID");
                objEntity.Description = GetTextVale(dr, "Description");
                objEntity.Subject = GetTextVale(dr, "Subject");
                objEntity.ContentData = GetTextVale(dr, "ContentData");
                objEntity.ActivityCode = GetTextVale(dr, "ActivityCode");
                objEntity.ActivityName = GetTextVale(dr, "ActivityName");
                objEntity.ActiveFlag = GetBoolean(dr, "ActiveFlag");
                // --------------------------------------------------------------------
                lstEntity.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstEntity;
        }

        // ==================================================================================================
        // Report : OrganizationStructure Master List
        // ==================================================================================================
        public virtual List<Entity.OrganizationStructure> Report_OrganizationStructureMasterList()
        {

            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "OrganizationStructureList";
            cmdAdd.Parameters.AddWithValue("@OrgCode", "");
            cmdAdd.Parameters.AddWithValue("@ListMode", "L");
            SqlDataReader dr = ExecuteDataReader(cmdAdd);
            // ---------------------------------------------------------
            List<Entity.OrganizationStructure> lstEntity = new List<Entity.OrganizationStructure>();
            while (dr.Read())
            {
                Entity.OrganizationStructure objEntity = new Entity.OrganizationStructure();

                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.OrgCode = GetTextVale(dr, "OrgCode");
                objEntity.OrgName = GetTextVale(dr, "OrgName");
                objEntity.OrgType = GetTextVale(dr, "OrgType");
                objEntity.OrgTypeCode = GetInt64(dr, "OrgTypeCode");


                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.Landline1 = GetTextVale(dr, "Landline1");
                objEntity.Landline2 = GetTextVale(dr, "Landline2");
                objEntity.Fax1 = GetTextVale(dr, "Fax1");

                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");
                objEntity.ReportTo_OrgCode = GetTextVale(dr, "ReportTo_OrgCode");
                objEntity.ReportTo_OrgName = GetTextVale(dr, "ReportTo_OrgName");

                objEntity.CityCode = GetTextVale(dr, "CityCode");
                objEntity.CityName = GetTextVale(dr, "CityName");


                objEntity.ActiveFlag = GetBoolean(dr, "ActiveFlag");
                objEntity.ActiveFlagDesc = GetTextVale(dr, "ActiveFlagDesc");
                //--------------------------------------------------------------------
                lstEntity.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstEntity;
        }

        // ==================================================================================================
        // Report : OrganizationEmployee Master List
        // ==================================================================================================
        public virtual List<Entity.OrganizationEmployee> Report_OrganizationEmployeeMasterList(DateTime FromDate, DateTime ToDate, Int32 EmployeeID)//string LoginUserID,Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate
        {

            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.Text;
            cmdAdd.CommandText = "OrgEmployeeList_Report";
            
            cmdAdd.Parameters.AddWithValue("@pkID", "");
            cmdAdd.Parameters.AddWithValue("@ListMode", "L");
            cmdAdd.Parameters.AddWithValue("@FromDate", FromDate);
            cmdAdd.Parameters.AddWithValue("@ToDate", ToDate);
            cmdAdd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            SqlDataReader dr = ExecuteDataReader(cmdAdd);
            // ---------------------------------------------------------
            List<Entity.OrganizationEmployee> lstEntity = new List<Entity.OrganizationEmployee>();
            while (dr.Read())
            {
                Entity.OrganizationEmployee objEntity = new Entity.OrganizationEmployee();

                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.Landline = GetTextVale(dr, "Landline");
                objEntity.MobileNo = GetTextVale(dr, "MobileNo");
                objEntity.EmailAddress = GetTextVale(dr, "EmailAddress");

                objEntity.DesigCode = GetTextVale(dr, "DesigCode");
                objEntity.Designation = GetTextVale(dr, "Designation");

                objEntity.OrgCode = GetTextVale(dr, "OrgCode");
                objEntity.OrgName = GetTextVale(dr, "OrgName");
                objEntity.ReportToEmployeeName = GetTextVale(dr, "ReportToEmployeeName");
                objEntity.BirthDate = GetDateTime(dr, "BirthDate");
                objEntity.ConfirmationDate = GetDateTime(dr, "ConfirmationDate");
                objEntity.JoiningDate = GetDateTime(dr, "JoiningDate");
                objEntity.ReleaseDate = GetDateTime(dr, "ReleaseDate");
                //objEntity.ActiveFlagDesc = GetTextVale(dr, "ActiveFlagDesc");
                //--------------------------------------------------------------------
                lstEntity.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstEntity;
        }

        // ==================================================================================================
        // Report : OrgTypes Master List
        // ==================================================================================================
        public virtual List<Entity.OrgTypes> Report_OrgTypesMasterList()
        {

            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "OrgTypeList";
            cmdAdd.Parameters.AddWithValue("@pkID", 0);
            cmdAdd.Parameters.AddWithValue("@ListMode", "L");
            SqlDataReader dr = ExecuteDataReader(cmdAdd);
            // ---------------------------------------------------------
            List<Entity.OrgTypes> lstEntity = new List<Entity.OrgTypes>();
            while (dr.Read())
            {
                Entity.OrgTypes objEntity = new Entity.OrgTypes();

                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.OrgType = GetTextVale(dr, "OrgType");
                objEntity.ActiveFlag = GetBoolean(dr, "ActiveFlag");
                //--------------------------------------------------------------------
                lstEntity.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstEntity;
        }

        // ==================================================================================================
        // Report : Roles Master List
        // ==================================================================================================
        public virtual List<Entity.Roles> Report_RolesMasterList()
        {

            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "RolesList";
            cmdAdd.Parameters.AddWithValue("@RoleCode", "");
            cmdAdd.Parameters.AddWithValue("@ListMode", "L");
            SqlDataReader dr = ExecuteDataReader(cmdAdd);
            // ---------------------------------------------------------
            List<Entity.Roles> lstEntity = new List<Entity.Roles>();
            while (dr.Read())
            {
                Entity.Roles objEntity = new Entity.Roles();

                objEntity.RoleCode = GetTextVale(dr, "RoleCode");
                objEntity.Description = GetTextVale(dr, "Description");
                objEntity.Comments = GetTextVale(dr, "Comments");
                objEntity.ActiveFlag = GetBoolean(dr, "ActiveFlag");
                //--------------------------------------------------------------------
                lstEntity.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstEntity;
        }

        // ==================================================================================================
        // Report : State Master List
        // ==================================================================================================
        public virtual List<Entity.State> Report_StateMasterList()
        {

            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "StateList";
            cmdAdd.Parameters.AddWithValue("@StateCode", "");
            cmdAdd.Parameters.AddWithValue("@ListMode", "L");
            SqlDataReader dr = ExecuteDataReader(cmdAdd);
            // ---------------------------------------------------------
            List<Entity.State> lstEntity = new List<Entity.State>();
            while (dr.Read())
            {
                Entity.State objEntity = new Entity.State();

                objEntity.StateCode = GetInt64(dr, "StateCode");
                objEntity.StateName = GetTextVale(dr, "StateName");
                objEntity.CountryCode = GetTextVale(dr, "CountryCode");
                objEntity.CountryName = GetTextVale(dr, "CountryName");
                //--------------------------------------------------------------------
                lstEntity.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstEntity;
        }

        // ==================================================================================================
        // Report : Users Master List
        // ==================================================================================================
        public virtual List<Entity.Users_Report> Report_UsersMasterList(Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string pLoginUserID)
        {

            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "UserList_Report";
            cmdAdd.Parameters.AddWithValue("@UserID", pLoginUserID);
            cmdAdd.Parameters.AddWithValue("@ListMode", "L");
            cmdAdd.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdAdd.Parameters.AddWithValue("@ToDate", pToDate);
            SqlDataReader dr = ExecuteDataReader(cmdAdd);
            // ---------------------------------------------------------
            List<Entity.Users_Report> lstEntity = new List<Entity.Users_Report>();
            while (dr.Read())
            {
                Entity.Users_Report objEntity = new Entity.Users_Report();

                objEntity.UserID = GetTextVale(dr, "UserID");
                objEntity.UserPassword = GetTextVale(dr, "UserPassword");
                objEntity.ScreenFullName = GetTextVale(dr, "ScreenFullName");
                objEntity.OrgCode = GetTextVale(dr, "OrgCode");
                objEntity.OrgName = GetTextVale(dr, "OrgName");
                objEntity.OrgTypeCode = GetInt64(dr, "OrgTypeCode");
                objEntity.OrgType = GetTextVale(dr, "OrgType");
                objEntity.RoleCode = GetTextVale(dr, "RoleCode");
                objEntity.RoleName = GetTextVale(dr, "RoleName");
                objEntity.ActiveFlag = GetBoolean(dr, "ActiveFlag");
                objEntity.ActiveFlagDesc = GetTextVale(dr, "ActiveFlagDesc");
                objEntity.UserID_CreatedDate = GetDateTime(dr, "UserID_CreatedDate");
                objEntity.ReleaseDate = GetDateTime(dr, "ReleaseDate");
                //--------------------------------------------------------------------
                lstEntity.Add(objEntity);
            }

            dr.Close();
            ForceCloseConncetion();
            return lstEntity;
        }

        // ==================================================================================================
        // Report : Brand Master List
        // ==================================================================================================
        public virtual List<Entity.Brand> GetBrandList()
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "BrandList_Report";
            cmdGet.Parameters.AddWithValue("@pkID", 0);
            cmdGet.Parameters.AddWithValue("@ListMode", "L");
            cmdGet.Parameters.AddWithValue("@PageNo", 0);
            cmdGet.Parameters.AddWithValue("@PageSize", 0);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.Brand> lstObject = new List<Entity.Brand>();
            while (dr.Read())
            {
                Entity.Brand objEntity = new Entity.Brand();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.BrandName = GetTextVale(dr, "BrandName");
                objEntity.BrandAlias = GetTextVale(dr, "BrandAlias");
                objEntity.ActiveFlag = GetBoolean(dr, "ActiveFlag");
                objEntity.ActiveFlagDesc = GetTextVale(dr, "ActiveFlagDesc");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // ==================================================================================================
        // Report : Product List
        // ==================================================================================================
        public virtual List<Entity.Products> GetProductList()
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ProductList";
            cmdGet.Parameters.AddWithValue("@pkID", 0);
            cmdGet.Parameters.AddWithValue("@ListMode", "L");
            cmdGet.Parameters.AddWithValue("@PageNo", 1);
            cmdGet.Parameters.AddWithValue("@PageSize", 10000);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.Products> lstObject = new List<Entity.Products>();
            while (dr.Read())
            {
                Entity.Products objEntity = new Entity.Products();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductNameLong = GetTextVale(dr, "ProductNameLong");
                objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                objEntity.Unit = GetTextVale(dr, "Unit");
                objEntity.UnitPrice = GetDecimal(dr, "UnitPrice");
                objEntity.TaxRate = GetDecimal(dr, "TaxRate");
                objEntity.ProductSpecification = GetTextVale(dr, "ProductSpecification");
                objEntity.ProductGroupID = GetInt64(dr, "ProductGroupID");
                objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                objEntity.BrandID = GetInt64(dr, "BrandID");
                objEntity.BrandName = GetTextVale(dr, "BrandName");
                objEntity.ProductImage = (!String.IsNullOrEmpty(GetTextVale(dr, "ProductImage"))) ? GetTextVale(dr, "ProductImage") : "~/images/no-figure.png";
                objEntity.ActiveFlag = GetBoolean(dr, "ActiveFlag");
                objEntity.ActiveFlagDesc = GetTextVale(dr, "ActiveFlagDesc");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // ==================================================================================================
        // Report : Product Group List
        // ==================================================================================================
        public virtual List<Entity.ProductGroup> GetProductGroupList()
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ProductGroupList";
            cmdGet.Parameters.AddWithValue("@pkID", 0);
            cmdGet.Parameters.AddWithValue("@ListMode", "L");
            cmdGet.Parameters.AddWithValue("@PageNo", 0);
            cmdGet.Parameters.AddWithValue("@PageSize", 0);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.ProductGroup> lstObject = new List<Entity.ProductGroup>();
            while (dr.Read())
            {
                Entity.ProductGroup objEntity = new Entity.ProductGroup();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                objEntity.ActiveFlag = GetBoolean(dr, "ActiveFlag");
                objEntity.ActiveFlagDesc = GetTextVale(dr, "ActiveFlagDesc");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        // ==================================================================================================
        // Report : Brand Wise ProductGroup Wise Product List 
        // ==================================================================================================
        public virtual List<Entity.Products> GetBrandWiseProductGroupWiseProductList(string pProductGroupId, string pBrandId)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "BrandWiseProductGroupWiseProductList";
            cmdGet.Parameters.AddWithValue("@ProductGroupId", pProductGroupId);
            cmdGet.Parameters.AddWithValue("@BrandId", pBrandId);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.Products> lstObject = new List<Entity.Products>();
            while (dr.Read())
            {
                Entity.Products objEntity = new Entity.Products();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductNameLong = GetTextVale(dr, "ProductNameLong");
                objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                objEntity.Unit = GetTextVale(dr, "Unit");
                objEntity.UnitPrice = GetDecimal(dr, "UnitPrice");
                objEntity.TaxRate = GetDecimal(dr, "TaxRate");
                objEntity.ProductSpecification = GetTextVale(dr, "ProductSpecification");
                objEntity.ProductGroupID = GetInt64(dr, "ProductGroupID");
                objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                objEntity.BrandID = GetInt64(dr, "BrandID");
                objEntity.BrandName = GetTextVale(dr, "BrandName");
                objEntity.ProductImage = (!String.IsNullOrEmpty(GetTextVale(dr, "ProductImage"))) ? GetTextVale(dr, "ProductImage") : "~/images/no-figure.png";
                objEntity.ActiveFlag = GetBoolean(dr, "ActiveFlag");
                objEntity.ActiveFlagDesc = GetTextVale(dr, "ActiveFlagDesc");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        public virtual List<Entity.Followup> GetFollowupList(String pReportType, DateTime pFromDate, DateTime pToDate, string pLoginUserID, string pCustomerID, string pEmployeeID)
        {
            List<Entity.Followup> lstLocation = new List<Entity.Followup>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "InquiryFollowupByPeriod_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@CustomerID", pCustomerID);
            cmdGet.Parameters.AddWithValue("@EmployeeID", pEmployeeID);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@ReportType", pReportType);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.Followup objEntity = new Entity.Followup();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                //objEntity.InquiryDate = GetDateTime(dr, "InquiryDate");
                objEntity.MeetingNotes = GetTextVale(dr, "MeetingNotes");
                objEntity.FollowupDate = GetDateTime(dr, "FollowupDate");
                objEntity.NextFollowupDate = GetDateTime(dr, "NextFollowupDate");
                objEntity.Rating = GetInt64(dr, "Rating");
                objEntity.InquiryStatusID = GetInt64(dr, "InquiryStatusID");
                objEntity.InquiryStatus = GetTextVale(dr, "InquiryStatus");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.InquirySource = GetTextVale(dr, "InquirySource");
                if (!String.IsNullOrEmpty(dr["Latitude"].ToString()) && dr["Latitude"].ToString() != "0")
                {
                    objEntity.Latitude = GetDecimal(dr, "Latitude");
                    objEntity.Longitude = GetDecimal(dr, "Longitude");
                }
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                lstLocation.Add(objEntity);
            }
            dr.Close();

            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.Followup> GetFollowupList_Report(String pReportType, DateTime pFromDate, DateTime pToDate, string pLoginUserID, string pCustomerID, string pEmployeeID, string pInquirySource, string pInquiryStatus, string InqTele)
        {
            List<Entity.Followup> lstLocation = new List<Entity.Followup>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "InquiryFollowupByPeriod_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@CustomerID", pCustomerID);
            cmdGet.Parameters.AddWithValue("@EmployeeID", pEmployeeID);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@ReportType", pReportType);
            cmdGet.Parameters.AddWithValue("@InquirySource", pInquirySource);
            cmdGet.Parameters.AddWithValue("@InquiryStatus", pInquiryStatus);
            cmdGet.Parameters.AddWithValue("@Type", InqTele);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.Followup objEntity = new Entity.Followup();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ContactNo1 = GetTextVale(dr, "ContactNo1");
                objEntity.ContactNo2 = GetTextVale(dr, "ContactNo2");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                //objEntity.InquiryDate = GetDateTime(dr, "InquiryDate");
                objEntity.MeetingNotes = GetTextVale(dr, "MeetingNotes");
                objEntity.FollowupDate = GetDateTime(dr, "FollowupDate");
                objEntity.NextFollowupDate = GetDateTime(dr, "NextFollowupDate");
                objEntity.Rating = GetInt64(dr, "Rating");
                objEntity.InquiryStatusID = GetInt64(dr, "InquiryStatusID");
                objEntity.InquiryStatus = GetTextVale(dr, "InquiryStatus");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.InquirySource = GetTextVale(dr, "InquirySource");
                if (!String.IsNullOrEmpty(dr["Latitude"].ToString()) && dr["Latitude"].ToString() != "0")
                {
                    objEntity.Latitude = GetDecimal(dr, "Latitude");
                    objEntity.Longitude = GetDecimal(dr, "Longitude");
                }
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");

                lstLocation.Add(objEntity);
            }
            dr.Close();

            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.PurchaseOrderByProjectList> GetProjectWise_Report(String ReportType, Int64 ProjectName, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.PurchaseOrderByProjectList> lstLocation = new List<Entity.PurchaseOrderByProjectList>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ProjectWise_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@ReportType", ReportType);
            cmdGet.Parameters.AddWithValue("@ProjectName", ProjectName);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.PurchaseOrderByProjectList objEntity = new Entity.PurchaseOrderByProjectList();
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.OrderDate = GetDateTime(dr, "OrderDate");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProjectID = GetInt64(dr, "ProjectID");
                objEntity.ProjectName = GetTextVale(dr, "ProjectName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.Unit = GetTextVale(dr, "Unit");
                objEntity.UnitRate = GetDecimal(dr, "UnitRate");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.NetAmount = GetDecimal(dr, "NetAmount");

                lstLocation.Add(objEntity);
            }
            dr.Close();

            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.SalesTarget> GetSalesTargetList(DateTime pFromDate, DateTime pToDate, string pLoginUserID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SalesTargetListByPeriod";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.SalesTarget> lstObject = new List<Entity.SalesTarget>();
            while (dr.Read())
            {
                Entity.SalesTarget objEntity = new Entity.SalesTarget();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.FromDate = GetDateTime(dr, "FromDate");
                objEntity.ToDate = GetDateTime(dr, "ToDate");
                objEntity.TargetAmount = GetDecimal(dr, "TargetAmount");
                objEntity.TargetType = GetTextVale(dr, "TargetType");
                objEntity.BrandID = GetInt64(dr, "BrandID");
                objEntity.ProductGroupID = GetInt64(dr, "ProductGroupID");
                objEntity.BrandName = GetTextVale(dr, "BrandName");
                objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        public virtual List<Entity.SalesTarget> GetSalesTargetList_Report(Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, string pLoginUserID, int EmployeeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SalesTargetListByPeriod_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.SalesTarget> lstObject = new List<Entity.SalesTarget>();
            while (dr.Read())
            {
                Entity.SalesTarget objEntity = new Entity.SalesTarget();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.FromDate = GetDateTime(dr, "FromDate");
                objEntity.ToDate = GetDateTime(dr, "ToDate");
                objEntity.TargetAmount = GetDecimal(dr, "TargetAmount");
                objEntity.TargetType = GetTextVale(dr, "TargetType");
                objEntity.BrandID = GetInt64(dr, "BrandID");
                objEntity.ProductGroupID = GetInt64(dr, "ProductGroupID");
                objEntity.BrandName = GetTextVale(dr, "BrandName");
                objEntity.ProductGroupName = GetTextVale(dr, "ProductGroupName");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.AchievedAmount = GetDecimal(dr, "AchievedAmount");
                objEntity.Percentage = GetDecimal(dr, "Percentage");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        public virtual List<Entity.Attendance_Report> GetAttendanceList_Report(Int64 pkID, string UserID, Int64 EmployeeID, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate)
        {
            List<Entity.Attendance_Report> lstLocation = new List<Entity.Attendance_Report>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "DailyAttendanceList_Report";
            cmdGet.Parameters.AddWithValue("@pkID", pkID);
            cmdGet.Parameters.AddWithValue("@LogInUserID", UserID);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.Attendance_Report objEntity = new Entity.Attendance_Report();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.PresenceDate = GetDateTime(dr, "PresenceDate");
                objEntity.TimeIn = GetTextVale(dr, "TimeIn");
                objEntity.TimeOut = GetTextVale(dr, "TimeOut");
                objEntity.WorkingHrs = GetTextVale(dr, "WorkingHrs");
                objEntity.PresenceStatus = GetTextVale(dr, "PresenceStatus");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.Attendance_Report> GetAttendanceList_Report_New(Int64 pkID, string UserID, Int64 EmployeeID, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, String SerialKey)
        {
            List<Entity.Attendance_Report> lstLocation = new List<Entity.Attendance_Report>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "DailyAttendanceList_Report_PRI";
            cmdGet.Parameters.AddWithValue("@pkID", pkID);
            cmdGet.Parameters.AddWithValue("@LogInUserID", UserID);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@SerialKey", SerialKey);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.Attendance_Report objEntity = new Entity.Attendance_Report();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.PresenceDate = GetDateTime(dr, "PresenceDate");
                objEntity.TimeIn = GetTextVale(dr, "TimeIn");
                objEntity.TimeOut = GetTextVale(dr, "TimeOut");
                objEntity.WorkingHrs = GetTextVale(dr, "WorkingHrs");
                objEntity.PresenceStatus = GetTextVale(dr, "PresenceStatus");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }
        public virtual List<Entity.DailyActivity> Report_GetDailyActivityListByUser(string LoginUserID, Int64 EmployeeID, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, Int64 TaskCategory)
        {
            List<Entity.DailyActivity> lstLocation = new List<Entity.DailyActivity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "DailyActivityListByUserandEmployee_Report";
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            //cmdGet.Parameters.AddWithValue("@ActivityDate", ActivityDate);
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@TaskCategoryID", TaskCategory);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.DailyActivity objEntity = new Entity.DailyActivity();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.TaskDescription = GetTextVale(dr, "TaskDescription");
                objEntity.TaskCategoryID = GetInt64(dr, "TaskCategoryID");
                objEntity.TaskDuration = GetDecimal(dr, "TaskDuration");
                objEntity.ActivityDate = GetDateTime(dr, "ActivityDate");
                objEntity.TaskCategoryName = GetTextVale(dr, "TaskCategoryName");
                objEntity.CreatedEmployeeName = GetTextVale(dr, "CreatedEmployeeName");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.Complaint_Report> Report_GetComplaintList(Int64 pkID, Int64 CustomerID, string ComplaintStatus, string LoginUserID, Nullable<DateTime> pFromDate, Nullable<DateTime> pToDate, Int64 EmployeeID, Int64 AssignToEmployeeID)
        {
            List<Entity.Complaint_Report> lstLocation = new List<Entity.Complaint_Report>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ComplaintList_Report";
            cmdGet.Parameters.AddWithValue("@pkID", pkID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@ComplaintStatus", ComplaintStatus);
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", pFromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", pToDate);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@AssignTO", AssignToEmployeeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.Complaint_Report objEntity = new Entity.Complaint_Report();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.ComplaintNoString = "Complaint # : " + GetInt64(dr, "pkID").ToString();
                objEntity.ComplaintDate = GetDateTime(dr, "ComplaintDate");
                objEntity.ReferenceNo = GetTextVale(dr, "ReferenceNo");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ComplaintNotes = GetTextVale(dr, "ComplaintNotes");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.PreferredDate = GetDateTime(dr, "PreferredDate");
                objEntity.TimeFrom = GetTextVale(dr, "TimeFrom");
                objEntity.TimeTo = GetTextVale(dr, "TimeTo");
                objEntity.ComplaintStatus = GetTextVale(dr, "ComplaintStatus");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.VisitDate = GetDateTime(dr, "VisitDate");
                objEntity.VisitFromtime = GetTextVale(dr, "VisitFromtime");
                objEntity.VisitTotime = GetTextVale(dr, "VisitTotime");
                objEntity.VisitType = GetTextVale(dr, "VisitType");
                objEntity.VisitNotes = GetTextVale(dr, "VisitNotes");
                objEntity.VisitCharge = GetDecimal(dr, "VisitCharge");
                objEntity.VisitChargeType = GetTextVale(dr, "VisitChargeType");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.LeaveRequest> Report_GetLeaveRequestListByUser(string pLoginUserID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, Int64 EmployeeID, string LeaveStatus)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "LeaveRequestListByUser_Report";
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@ToDate", Todate);
            //cmdGet.Parameters.AddWithValue("@Month", pMonth);
            //cmdGet.Parameters.AddWithValue("@Year", pYear);
            cmdGet.Parameters.AddWithValue("@EmpID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@Status", LeaveStatus);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.LeaveRequest> lstObject = new List<Entity.LeaveRequest>();
            while (dr.Read())
            {
                Entity.LeaveRequest objEntity = new Entity.LeaveRequest();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.FromDate = GetDateTime(dr, "FromDate");
                objEntity.ToDate = GetDateTime(dr, "ToDate");
                objEntity.ReasonForLeave = GetTextVale(dr, "ReasonForLeave");
                objEntity.ApprovalStatus = GetTextVale(dr, "ApprovalStatus");
                objEntity.ApprovedEmployeeName = GetTextVale(dr, "ApprovedEmployeeName");
                objEntity.ApprovedBy = GetTextVale(dr, "ApprovedBy");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");
                objEntity.UpdatedDate = GetDateTime(dr, "UpdatedDate");
                objEntity.ApprovedDate = GetDateTime(dr, "ApprovedDate");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        public virtual List<Entity.Expense_Report> Report_GetExpenseList(string LoginUserID, Int64 EmployeeID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, Int64 ExpenseTypeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ExpenseList_Report";
            cmdGet.Parameters.AddWithValue("@pkID", 0);
            cmdGet.Parameters.AddWithValue("@ListMode", "");
            cmdGet.Parameters.AddWithValue("@PageNo", 1);
            cmdGet.Parameters.AddWithValue("@PageSize", 50000);
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@ToDate", Todate);
            cmdGet.Parameters.AddWithValue("@ExpenseTypeId", ExpenseTypeID);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.Expense_Report> lstObject = new List<Entity.Expense_Report>();
            while (dr.Read())
            {
                Entity.Expense_Report objEntity = new Entity.Expense_Report();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.ExpenseDate = GetDateTime(dr, "ExpenseDate");
                objEntity.ExpenseTypeId = GetInt64(dr, "ExpenseTypeId");
                objEntity.ExpenseTypeName = GetTextVale(dr, "ExpenseTypeName");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.ExpenseNotes = GetTextVale(dr, "ExpenseNotes");
                objEntity.ExpenseImage = GetTextVale(dr, "ExpenseImage");
                objEntity.FromLocation = GetTextVale(dr, "FromLocation");
                objEntity.ToLocation = GetTextVale(dr, "ToLocation");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.CreatedEmployee = GetTextVale(dr, "CreatedEmployee");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        public virtual List<Entity.ExpenseVoucher_Report> Report_GetExpenseVoucherList(string LoginUserID, Int64 EmployeeID, DateTime Fromdate, DateTime Todate)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ExpenseVoucherList_Report";
            cmdGet.Parameters.AddWithValue("@pkID", 0);
            cmdGet.Parameters.AddWithValue("@ListMode", "");
            cmdGet.Parameters.AddWithValue("@PageNo", 1);
            cmdGet.Parameters.AddWithValue("@PageSize", 50000);
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@ToDate", Todate);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.ExpenseVoucher_Report> lstObject = new List<Entity.ExpenseVoucher_Report>();
            while (dr.Read())
            {
                Entity.ExpenseVoucher_Report objEntity = new Entity.ExpenseVoucher_Report();
                //objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.VoucherNo= GetTextVale(dr, "VoucherNo");
                objEntity.VoucherDate = GetDateTime(dr, "VoucherDate");
                objEntity.DBCustomerID= GetInt64(dr, "DBCustomerID");
                objEntity.CRCustomerID= GetInt64(dr, "CRCustomerID");
                objEntity.VAccount= GetTextVale(dr, "VAccount");
                objEntity.EAccount= GetTextVale(dr, "EAccount");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.VoucherAmount = GetInt64(dr, "VoucherAmount");
                objEntity.Remarks= GetTextVale(dr, "Remarks");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }


        public virtual List<Entity.ExternalLeads_Report> Report_GetExternalLeadList(int PageNo, int PageSize, out int TotalRecord, Nullable<DateTime> Todate, Nullable<DateTime> Fromdate, Int64 EmployeeID, string LeadStatus, Int64 Reason, Int64 DurationType)
        {
            List<Entity.ExternalLeads_Report> lstLead = new List<Entity.ExternalLeads_Report>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ExternalLeadList_Report";
            //cmdGet.CommandText = "ExternalLeadListQualified_Report";
            // cmdGet.Parameters.AddWithValue("@pkId", pkId);
            cmdGet.Parameters.AddWithValue("@PageNo", PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            cmdGet.Parameters.AddWithValue("@Todate", Todate);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@EmpID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@LeadStatus", LeadStatus);
            cmdGet.Parameters.AddWithValue("@Reason", Reason);
            cmdGet.Parameters.AddWithValue("@DurationType", DurationType);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.ExternalLeads_Report objEntity = new Entity.ExternalLeads_Report();

                objEntity.pkID = GetInt64(dr, "pkID");
               // objEntity.LeadID = GetTextVale(dr, "LeadID");
                objEntity.LeadSource = GetTextVale(dr, "LeadSource");
                //objEntity.ACID = GetTextVale(dr, "ACID");
                objEntity.QueryDatetime = GetDateTime(dr, "QueryDatetime");
                objEntity.SenderName = GetTextVale(dr, "SenderName");
                objEntity.SenderMail = GetTextVale(dr, "SenderMail");
                objEntity.CompanyName = GetTextVale(dr, "CompanyName");
                objEntity.CountryFlagURL = GetTextVale(dr, "CountryFlagURL");
                objEntity.Message = GetTextVale(dr, "Message");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.City = GetTextVale(dr, "City");
                objEntity.Pincode = GetTextVale(dr, "Pincode");
                objEntity.State = GetTextVale(dr, "State");
                objEntity.PrimaryMobileNo = GetTextVale(dr, "PrimaryMobileNo");
                objEntity.SecondaryMobileNo = GetTextVale(dr, "SecondaryMobileNo");
                objEntity.ForProduct = GetTextVale(dr, "ForProduct");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.LeadStatus = GetTextVale(dr, "LeadStatus");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.StateCode = GetInt64(dr, "StateCode");
                objEntity.CityCode = GetInt64(dr, "CityCode");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                objEntity.ExLeadClosure = GetInt64(dr, "ExLeadClosure");
                objEntity.ExLeadClosureStatus = GetTextVale(dr, "ExLeadClosureStatus");

                lstLead.Add(objEntity);
            }
            dr.Close();
            TotalRecord = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConncetion();
            return lstLead;
        }

        public virtual List<Entity.ExternalLeads_Report> Report_GetTelecallerInquiryList(int PageNo, int PageSize, out int TotalRecord, Nullable<DateTime> Todate, Nullable<DateTime> Fromdate, Int64 EmployeeID, string LeadStatus, Int64 Reason, string InqTele)
        {
            List<Entity.ExternalLeads_Report> lstLead = new List<Entity.ExternalLeads_Report>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "TelecallerInquiry_Report";
            //cmdGet.CommandText = "ExternalLeadListQualified_Report";
            // cmdGet.Parameters.AddWithValue("@pkId", pkId);
            cmdGet.Parameters.AddWithValue("@PageNo", PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            cmdGet.Parameters.AddWithValue("@Todate", Todate);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@EmpID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@LeadStatus", LeadStatus);
            cmdGet.Parameters.AddWithValue("@Reason", Reason);
            cmdGet.Parameters.AddWithValue("@Type", InqTele);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.ExternalLeads_Report objEntity = new Entity.ExternalLeads_Report();

                objEntity.pkID = GetInt64(dr, "pkID");
                // objEntity.LeadID = GetTextVale(dr, "LeadID");
                objEntity.LeadSource = GetTextVale(dr, "LeadSource");
                //objEntity.ACID = GetTextVale(dr, "ACID");
                objEntity.QueryDatetime = GetDateTime(dr, "QueryDatetime");
                objEntity.SenderName = GetTextVale(dr, "SenderName");
                objEntity.SenderMail = GetTextVale(dr, "SenderMail");
                objEntity.CompanyName = GetTextVale(dr, "CompanyName");
                objEntity.CountryFlagURL = GetTextVale(dr, "CountryFlagURL");
                objEntity.Message = GetTextVale(dr, "Message");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.City = GetTextVale(dr, "City");
                objEntity.Pincode = GetTextVale(dr, "Pincode");
                objEntity.State = GetTextVale(dr, "State");
                objEntity.PrimaryMobileNo = GetTextVale(dr, "PrimaryMobileNo");
                objEntity.SecondaryMobileNo = GetTextVale(dr, "SecondaryMobileNo");
                objEntity.ForProduct = GetTextVale(dr, "ForProduct");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.LeadStatus = GetTextVale(dr, "LeadStatus");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.StateCode = GetInt64(dr, "StateCode");
                objEntity.CityCode = GetInt64(dr, "CityCode");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                objEntity.ExLeadClosure = GetInt64(dr, "ExLeadClosure");
                objEntity.ExLeadClosureStatus = GetTextVale(dr, "ExLeadClosureStatus");

                lstLead.Add(objEntity);
            }
            dr.Close();
            TotalRecord = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConncetion();
            return lstLead;
        }

        public virtual List<Entity.ExternalLeads_Report> Report_MonthlyWorking(int PageNo, int PageSize, out int TotalRecord, Nullable<DateTime> Todate, Nullable<DateTime> Fromdate, Int64 EmployeeID, string LeadStatus, Int64 Reason, string InqTele)
        {
            List<Entity.ExternalLeads_Report> lstLead = new List<Entity.ExternalLeads_Report>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "MonthlyWorking_Report";
            //cmdGet.CommandText = "ExternalLeadListQualified_Report";
            // cmdGet.Parameters.AddWithValue("@pkId", pkId);
            cmdGet.Parameters.AddWithValue("@PageNo", PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            cmdGet.Parameters.AddWithValue("@Todate", Todate);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@EmpID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@LeadStatus", LeadStatus);
            cmdGet.Parameters.AddWithValue("@Reason", Reason);
            cmdGet.Parameters.AddWithValue("@Type", InqTele);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.ExternalLeads_Report objEntity = new Entity.ExternalLeads_Report();

                objEntity.pkID = GetInt64(dr, "pkID");
                // objEntity.LeadID = GetTextVale(dr, "LeadID");
                objEntity.LeadSource = GetTextVale(dr, "LeadSource");
                //objEntity.ACID = GetTextVale(dr, "ACID");
                objEntity.QueryDatetime = GetDateTime(dr, "QueryDatetime");
                objEntity.SenderName = GetTextVale(dr, "SenderName");
                objEntity.SenderMail = GetTextVale(dr, "SenderMail");
                objEntity.CompanyName = GetTextVale(dr, "CompanyName");
                objEntity.CountryFlagURL = GetTextVale(dr, "CountryFlagURL");
                objEntity.Message = GetTextVale(dr, "Message");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.City = GetTextVale(dr, "City");
                objEntity.Pincode = GetTextVale(dr, "Pincode");
                objEntity.State = GetTextVale(dr, "State");
                objEntity.PrimaryMobileNo = GetTextVale(dr, "PrimaryMobileNo");
                objEntity.SecondaryMobileNo = GetTextVale(dr, "SecondaryMobileNo");
                objEntity.ForProduct = GetTextVale(dr, "ForProduct");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.LeadStatus = GetTextVale(dr, "LeadStatus");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.StateCode = GetInt64(dr, "StateCode");
                objEntity.CityCode = GetInt64(dr, "CityCode");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                objEntity.ExLeadClosure = GetInt64(dr, "ExLeadClosure");
                objEntity.ExLeadClosureStatus = GetTextVale(dr, "ExLeadClosureStatus");
                objEntity.ActiveType = GetTextVale(dr, "ActiveType");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");
                objEntity.UpdatedDate = GetDateTime(dr, "UpdatedDate");
                objEntity.FollowupCreatedBy = GetTextVale(dr, "FollowupCreatedBy");
                objEntity.FollowupCreatedDate = GetDateTime(dr, "FollowupCreatedDate");
                objEntity.FollowupTypeID = GetInt64(dr, "FollowupTypeID");
                objEntity.FollowupType = GetTextVale(dr, "FollowupType");

                lstLead.Add(objEntity);
            }
            dr.Close();
            TotalRecord = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConncetion();
            return lstLead;
        }

        //===================================================================================================================
        // Report : Telecaller Report
        //===================================================================================================================

        public virtual List<Entity.ExternalLeads_Report> Report_TelecallerList(Int64 PageNo, Int64 PageSize, out int TotalRecord, Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, Int64 ProductID, Int64 EmployeeID)
        {
            List<Entity.ExternalLeads_Report> lstLead = new List<Entity.ExternalLeads_Report>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "TelecallerList_Report";
            //cmdGet.CommandText = "ExternalLeadListQualified_Report";
            // cmdGet.Parameters.AddWithValue("@pkId", pkId);
            cmdGet.Parameters.AddWithValue("@PageNo", PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            cmdGet.Parameters.AddWithValue("@Fromdate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@ProductID", ProductID);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);

            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.ExternalLeads_Report objEntity = new Entity.ExternalLeads_Report();

                objEntity.pkID = GetInt64(dr, "pkID");
                // objEntity.LeadID = GetTextVale(dr, "LeadID");
                objEntity.LeadSource = GetTextVale(dr, "LeadSource");
                //objEntity.ACID = GetTextVale(dr, "ACID");
                objEntity.QueryDatetime = GetDateTime(dr, "QueryDatetime");
                objEntity.SenderName = GetTextVale(dr, "SenderName");
                objEntity.SenderMail = GetTextVale(dr, "SenderMail");
                objEntity.CompanyName = GetTextVale(dr, "CompanyName");
                objEntity.CountryFlagURL = GetTextVale(dr, "CountryFlagURL");
                objEntity.Message = GetTextVale(dr, "Message");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.City = GetTextVale(dr, "City");
                objEntity.Pincode = GetTextVale(dr, "Pincode");
                objEntity.State = GetTextVale(dr, "State");
                objEntity.PrimaryMobileNo = GetTextVale(dr, "PrimaryMobileNo");
                objEntity.SecondaryMobileNo = GetTextVale(dr, "SecondaryMobileNo");
                objEntity.ForProduct = GetTextVale(dr, "ForProduct");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.LeadStatus = GetTextVale(dr, "LeadStatus");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.StateCode = GetInt64(dr, "StateCode");
                objEntity.CityCode = GetInt64(dr, "CityCode");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                objEntity.ExLeadClosure = GetInt64(dr, "ExLeadClosure");
                objEntity.ExLeadClosureStatus = GetTextVale(dr, "ExLeadClosureStatus");
                objEntity.ActiveType = GetTextVale(dr, "ActiveType");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");
                objEntity.UpdatedDate = GetDateTime(dr, "UpdatedDate");
                objEntity.FollowupCreatedBy = GetTextVale(dr, "FollowupCreatedBy");
                objEntity.FollowupCreatedDate = GetDateTime(dr, "FollowupCreatedDate");
                objEntity.FollowupTypeID = GetInt64(dr, "FollowupTypeID");
                objEntity.FollowupType = GetTextVale(dr, "FollowupType");

                lstLead.Add(objEntity);
            }
            dr.Close();
            TotalRecord = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConncetion();
            return lstLead;
        }

        //===================================================================================================================
        // Report : DailyVisitReport Sahil
        //===================================================================================================================

        public virtual List<Entity.ExternalLeadReport> Report_GetDailyVisiList(Int64 PageNo, Int64 PageSize, out int TotalRecord, Nullable<DateTime> Todate, Nullable<DateTime> Fromdate, Int64 EmpID, string LeadStatus, Int64 Reason, Int64 DurationType)
        {
            List<Entity.ExternalLeadReport> lstLead = new List<Entity.ExternalLeadReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "DailyVisitList_Report";
            //cmdGet.CommandText = "ExternalLeadListQualified_Report";
            // cmdGet.Parameters.AddWithValue("@pkId", pkId);
            cmdGet.Parameters.AddWithValue("@PageNo", PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            cmdGet.Parameters.AddWithValue("@Todate", Todate);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@EmpID", EmpID);
            cmdGet.Parameters.AddWithValue("@LeadStatus", LeadStatus);
            cmdGet.Parameters.AddWithValue("@Reason", Reason);
            cmdGet.Parameters.AddWithValue("@DurationType", DurationType);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.ExternalLeadReport objEntity = new Entity.ExternalLeadReport();

                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.FirmName = GetTextVale(dr, "FirmName");
                objEntity.CustomerType = GetTextVale(dr, "CustomerType");
                objEntity.PerMonthSales = GetInt64(dr, "PerMonthSales");
                objEntity.JoinAsDealer = GetDateTime(dr, "JoinAsDealer");
                objEntity.ContactPerson = GetTextVale(dr, "ContactPerson");
                objEntity.PrimaryMobileNo = GetTextVale(dr, "PrimaryMobileNo");
                objEntity.City = GetTextVale(dr, "City");
                objEntity.State = GetTextVale(dr, "State");
                objEntity.Address = GetTextVale(dr, "Address");
                objEntity.Message = GetTextVale(dr, "Message");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");

                lstLead.Add(objEntity);
            }
            dr.Close();
            TotalRecord = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConncetion();
            return lstLead;
        }


        public virtual String GetUserIDByEmployeeID(Int64 EmployeeID)
        {

            string UserId = "";

            using (SqlConnection connect = new SqlConnection(BaseSqlManager.ConncetionString()))
            {
                using (SqlCommand cmdGet = new SqlCommand("SELECT dbo.fnUserByEmployeeID(@EmployeeID)", connect))
                {
                    cmdGet.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    connect.Open();
                    UserId = (string)(cmdGet.ExecuteScalar());
                }
            }
            return UserId;
        }

        public virtual List<Entity.SalesBillReport> Report_GetSalesBillList(Int64 pkID, string LoginUserID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, string CustomerID, string LocationID, int PageNo, int PageSize, out int TotalRecord)
        {
            List<Entity.SalesBillReport> lstLocation = new List<Entity.SalesBillReport>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SalesBillList_Report";
            cmdGet.Parameters.AddWithValue("@pkID", pkID);
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@ToDate", Todate);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@LocationID", LocationID);
            cmdGet.Parameters.AddWithValue("@PageNo", PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.SalesBillReport objEntity = new Entity.SalesBillReport();
                objEntity.pkID = GetInt64(dr, "pkId");
                objEntity.InvoiceNo = GetTextVale(dr, "InvoiceNo");
                objEntity.InvoiceDate = GetDateTime(dr, "InvoiceDate");
                objEntity.CustomerID = GetInt64(dr, "CustomerId");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.TerminationOfDeliery = GetInt64(dr, "TerminationOfDeliery");
                objEntity.TerminationOfDelieryName = GetTextVale(dr, "TerminationOfDelieryName");
                //objEntity.InquiryNo =  GetTextVale(dr, "InquiryNo");
                //objEntity.OrderNo = GetTextVale(dr, "OrderNo");

                objEntity.QuotationNo = GetTextVale(dr, "QuotationNo");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.RefNo = GetTextVale(dr, "RefNo");
                objEntity.RefType = GetTextVale(dr, "RefType");

                objEntity.PatientName = GetTextVale(dr, "PatientName");
                objEntity.PatientType = GetTextVale(dr, "PatientType");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.Percentage = GetDecimal(dr, "Percentage");
                objEntity.EstimatedAmt = GetDecimal(dr, "EstimatedAmt");

                objEntity.BasicAmt = GetDecimal(dr, "BasicAmt");
                objEntity.DiscountAmt = GetDecimal(dr, "DiscountAmt");
                objEntity.TaxAmt = GetDecimal(dr, "TaxAmt");
                objEntity.ROffAmt = GetDecimal(dr, "ROffAmt");

                objEntity.SGSTAmt = GetDecimal(dr, "SGSTAmt");
                objEntity.CGSTAmt = GetDecimal(dr, "CGSTAmt");
                objEntity.IGSTAmt = GetDecimal(dr, "IGSTAmt");

                objEntity.ChargeName1 = GetTextVale(dr, "ChargeName1");
                objEntity.ChargeName2 = GetTextVale(dr, "ChargeName2");
                objEntity.ChargeName3 = GetTextVale(dr, "ChargeName3");
                objEntity.ChargeName4 = GetTextVale(dr, "ChargeName4");
                objEntity.ChargeName5 = GetTextVale(dr, "ChargeName5");

                objEntity.ChargeID1 = GetInt64(dr, "ChargeID1");
                objEntity.ChargeAmt1 = GetDecimal(dr, "ChargeAmt1");
                objEntity.ChargeBasicAmt1 = GetDecimal(dr, "ChargeBasicAmt1");
                objEntity.ChargeGSTAmt1 = GetDecimal(dr, "ChargeGSTAmt1");

                objEntity.ChargeID2 = GetInt64(dr, "ChargeID2");
                objEntity.ChargeAmt2 = GetDecimal(dr, "ChargeAmt2");
                objEntity.ChargeBasicAmt2 = GetDecimal(dr, "ChargeBasicAmt2");
                objEntity.ChargeGSTAmt2 = GetDecimal(dr, "ChargeGSTAmt2");

                objEntity.ChargeID3 = GetInt64(dr, "ChargeID3");
                objEntity.ChargeAmt3 = GetDecimal(dr, "ChargeAmt3");
                objEntity.ChargeBasicAmt3 = GetDecimal(dr, "ChargeBasicAmt3");
                objEntity.ChargeGSTAmt3 = GetDecimal(dr, "ChargeGSTAmt3");

                objEntity.ChargeID4 = GetInt64(dr, "ChargeID4");
                objEntity.ChargeAmt4 = GetDecimal(dr, "ChargeAmt4");
                objEntity.ChargeBasicAmt4 = GetDecimal(dr, "ChargeBasicAmt4");
                objEntity.ChargeGSTAmt4 = GetDecimal(dr, "ChargeGSTAmt4");

                objEntity.ChargeID5 = GetInt64(dr, "ChargeID5");
                objEntity.ChargeAmt5 = GetDecimal(dr, "ChargeAmt5");
                objEntity.ChargeBasicAmt5 = GetDecimal(dr, "ChargeBasicAmt5");
                objEntity.ChargeGSTAmt5 = GetDecimal(dr, "ChargeGSTAmt5");

                objEntity.NetAmt = GetDecimal(dr, "NetAmt");
                objEntity.ModeOfTransport = GetTextVale(dr, "ModeOfTransport");
                objEntity.TransporterName = GetTextVale(dr, "TransporterName");
                objEntity.VehicleNo = GetTextVale(dr, "VehicleNo");
                objEntity.LRNo = GetTextVale(dr, "LRNo");
                //objEntity.LRDate = GetDateTime(dr, "LRDate");
                objEntity.TransportRemark = GetTextVale(dr, "TransportRemark");
                objEntity.TermsCondition = GetTextVale(dr, "TermsCondition");
                objEntity.CurrencySymbol = "";
                objEntity.CurrencyName = "";
                objEntity.ExchangeRate = 0;

                objEntity.GSTNo = GetTextVale(dr, "GSTNO");

                objEntity.LocationName = GetTextVale(dr, "LocationName");

                bool hasColumn = false;
                var columns = Enumerable.Range(0, dr.FieldCount).Select(dr.GetName).ToList();
                hasColumn = columns.Any(s => s == "VoucherAmount") ? true : false;
                if (hasColumn)
                    objEntity.VoucherAmount = GetDecimal(dr, "VoucherAmount");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            TotalRecord = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.SalesBillDetail_Report> Report_GetSalesBillDetailList(string LoginUserID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, string pCustomerID)
        {
            List<Entity.SalesBillDetail_Report> lstLocation = new List<Entity.SalesBillDetail_Report>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SalesBillDetailList_Report";
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@ToDate", Todate);
            cmdGet.Parameters.AddWithValue("@CustomerID", pCustomerID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.SalesBillDetail_Report objEntity = new Entity.SalesBillDetail_Report();
                objEntity.pkID = GetInt64(dr, "pkId");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Rate = GetDecimal(dr, "Rate");
                objEntity.Unit = GetTextVale(dr, "Unit");
                objEntity.DiscountPer = GetDecimal(dr, "DiscountPer");
                objEntity.DiscountAmt = GetDecimal(dr, "DiscountAmt");
                objEntity.HeaderDiscAmt = GetDecimal(dr, "HeaderDiscAmt");
                objEntity.NetRate = GetDecimal(dr, "NetRate");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.AddTaxPer = GetDecimal(dr, "AddTaxPer");
                objEntity.AddTaxAmt = GetDecimal(dr, "AddTaxAmt");
                objEntity.Qty = GetDecimal(dr, "Qty");
                objEntity.SGSTPer = GetDecimal(dr, "SGSTPer");
                objEntity.CGSTPer = GetDecimal(dr, "CGSTPer");
                objEntity.IGSTPer = GetDecimal(dr, "IGSTPer");

                objEntity.SGSTAmt = GetDecimal(dr, "SGSTAmt");
                objEntity.CGSTAmt = GetDecimal(dr, "CGSTAmt");
                objEntity.IGSTAmt = GetDecimal(dr, "IGSTAmt");

                objEntity.NetAmt = GetDecimal(dr, "NetAmt");
                objEntity.ROffAmt = GetDecimal(dr, "ROffAmt");
                objEntity.TaxType = GetInt64(dr, "TaxType");

                objEntity.InvoiceNo = GetTextVale(dr, "InvoiceNo");
                objEntity.InvoiceDate = GetDateTime(dr, "InvoiceDate");
                objEntity.HeaderNetAmount = GetDecimal(dr, "HeaderNetAmount");
                objEntity.HeaderBasicAmount = GetDecimal(dr, "HeaderBasicAmount");
                objEntity.TotalDisountAmount = GetDecimal(dr, "TotalDisountAmount");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.InquiryNo = GetTextVale(dr, "InquiryNo");
                objEntity.QuotationNo = GetTextVale(dr, "QuotationNo");
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");

                objEntity.ChargeName1 = GetTextVale(dr, "ChargeName1");
                objEntity.ChargeName2 = GetTextVale(dr, "ChargeName2");
                objEntity.ChargeName3 = GetTextVale(dr, "ChargeName3");
                objEntity.ChargeName4 = GetTextVale(dr, "ChargeName4");
                objEntity.ChargeName5 = GetTextVale(dr, "ChargeName5");
                objEntity.ChargeTotalAmt1 = GetDecimal(dr, "ChargeTotalAmt1");
                objEntity.ChargeTotalAmt2 = GetDecimal(dr, "ChargeTotalAmt2");
                objEntity.ChargeTotalAmt3 = GetDecimal(dr, "ChargeTotalAmt3");
                objEntity.ChargeTotalAmt4 = GetDecimal(dr, "ChargeTotalAmt4");
                objEntity.ChargeTotalAmt5 = GetDecimal(dr, "ChargeTotalAmt5");
                objEntity.TerminationOfDelieryName = GetTextVale(dr, "TerminationOfDelieryName");
                objEntity.RefNo = GetTextVale(dr, "RefNo");
                objEntity.CreatedEmployeeName = GetTextVale(dr, "CreatedEmployeeName");
                objEntity.UpdatedEmployeeName = GetTextVale(dr, "UpdatedEmployeeName");
                objEntity.TaxAmt = GetDecimal(dr, "TaxAmt");

                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");
                objEntity.UpdatedDate = GetDateTime(dr, "UpdatedDate");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.PurchaseBill> Report_GetPurchaseBillList(String LoginUserID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, Int64 CustomerID,String EmployeeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "PurchaseBillList_Report";
            cmdGet.Parameters.AddWithValue("@pkID", 0);
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@ToDate", Todate);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@EmpID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@PageNo", 1);
            cmdGet.Parameters.AddWithValue("@PageSize", 10000);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.PurchaseBill> lstObject = new List<Entity.PurchaseBill>();
            while (dr.Read())
            {
                Entity.PurchaseBill objEntity = new Entity.PurchaseBill();
                objEntity.pkID = GetInt64(dr, "pkId");
                objEntity.InvoiceNo = GetTextVale(dr, "InvoiceNo");
                objEntity.InvoiceDate = GetDateTime(dr, "InvoiceDate");
                objEntity.CustomerID = GetInt64(dr, "CustomerId");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.TerminationOfDeliery = GetInt64(dr, "TerminationOfDeliery");
                objEntity.BasicAmt = GetDecimal(dr, "BasicAmt");
                objEntity.DiscountAmt = GetDecimal(dr, "DiscountAmt");
                objEntity.TaxAmt = GetDecimal(dr, "TaxAmt");
                objEntity.ROffAmt = GetDecimal(dr, "ROffAmt");

                objEntity.ChargeID1 = GetInt64(dr, "ChargeID1");
                objEntity.ChargeAmt1 = GetDecimal(dr, "ChargeAmt1");
                objEntity.ChargeBasicAmt1 = GetDecimal(dr, "ChargeBasicAmt1");
                objEntity.ChargeGSTAmt1 = GetDecimal(dr, "ChargeGSTAmt1");

                objEntity.ChargeID2 = GetInt64(dr, "ChargeID2");
                objEntity.ChargeAmt2 = GetDecimal(dr, "ChargeAmt2");
                objEntity.ChargeBasicAmt2 = GetDecimal(dr, "ChargeBasicAmt2");
                objEntity.ChargeGSTAmt2 = GetDecimal(dr, "ChargeGSTAmt2");

                objEntity.ChargeID3 = GetInt64(dr, "ChargeID3");
                objEntity.ChargeAmt3 = GetDecimal(dr, "ChargeAmt3");
                objEntity.ChargeBasicAmt3 = GetDecimal(dr, "ChargeBasicAmt3");
                objEntity.ChargeGSTAmt3 = GetDecimal(dr, "ChargeGSTAmt3");

                objEntity.ChargeID4 = GetInt64(dr, "ChargeID4");
                objEntity.ChargeAmt4 = GetDecimal(dr, "ChargeAmt4");
                objEntity.ChargeBasicAmt4 = GetDecimal(dr, "ChargeBasicAmt4");
                objEntity.ChargeGSTAmt4 = GetDecimal(dr, "ChargeGSTAmt4");

                objEntity.ChargeID5 = GetInt64(dr, "ChargeID5");
                objEntity.ChargeAmt5 = GetDecimal(dr, "ChargeAmt5");
                objEntity.ChargeBasicAmt5 = GetDecimal(dr, "ChargeBasicAmt5");
                objEntity.ChargeGSTAmt5 = GetDecimal(dr, "ChargeGSTAmt5");
                objEntity.CreatedEmployeeName = GetTextVale(dr, "CreatedEmployeeName");
                objEntity.NetAmt = GetDecimal(dr, "NetAmt");
                //objEntity.ModeOfTransport = GetTextVale(dr, "ModeOfTransport");
                //objEntity.TransporterName = GetTextVale(dr, "TransporterName");
                //objEntity.VehicleNo = GetTextVale(dr, "VehicleNo");
                //objEntity.LRNo = GetTextVale(dr, "LRNo");
                //objEntity.LRDate = GetDateTime(dr, "LRDate");
                //objEntity.TransportRemark = GetTextVale(dr, "TransportRemark");
                lstObject.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstObject;
        }

        public virtual List<Entity.PurchaseBillDetail_Report> Report_GetPurchaseBillDetailList(string LoginUserID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate, Int64 CustomerID,Int64 EmployeeID)
        {
            List<Entity.PurchaseBillDetail_Report> lstLocation = new List<Entity.PurchaseBillDetail_Report>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "PurchaseBillDetailList_Report";
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(Fromdate).ToString("yyyy-MM-dd"));
            cmdGet.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(Todate).ToString("yyyy-MM-dd"));
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.PurchaseBillDetail_Report objEntity = new Entity.PurchaseBillDetail_Report();
                objEntity.pkID = GetInt64(dr, "pkId");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Rate = GetDecimal(dr, "Rate");
                objEntity.Unit = GetTextVale(dr, "Unit");
                objEntity.DiscountPer = GetDecimal(dr, "DiscountPer");
                objEntity.DiscountAmt = GetDecimal(dr, "DiscountAmt");
                objEntity.HeaderDiscAmt = GetDecimal(dr, "HeaderDiscAmt");
                objEntity.NetRate = GetDecimal(dr, "NetRate");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.AddTaxPer = GetDecimal(dr, "AddTaxPer");
                objEntity.AddTaxAmt = GetDecimal(dr, "AddTaxAmt");
                objEntity.Qty = GetDecimal(dr, "Qty");
                objEntity.SGSTPer = GetDecimal(dr, "SGSTPer");
                objEntity.CGSTPer = GetDecimal(dr, "CGSTPer");
                objEntity.IGSTPer = GetDecimal(dr, "IGSTPer");

                objEntity.SGSTAmt = GetDecimal(dr, "SGSTAmt");
                objEntity.CGSTAmt = GetDecimal(dr, "CGSTAmt");
                objEntity.IGSTAmt = GetDecimal(dr, "IGSTAmt");

                objEntity.NetAmt = GetDecimal(dr, "NetAmt");
                objEntity.ROffAmt = GetDecimal(dr, "ROffAmt");
                objEntity.TaxType = GetInt64(dr, "TaxType");

                objEntity.InvoiceNo = GetTextVale(dr, "InvoiceNo");
                objEntity.InvoiceDate = GetDateTime(dr, "InvoiceDate");

                objEntity.HeaderNetAmount = GetDecimal(dr, "HeaderNetAmount");
                objEntity.HeaderBasicAmount = GetDecimal(dr, "HeaderBasicAmount");
                objEntity.HeaderDisountAmount = GetDecimal(dr, "HeaderDiscountAmount");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");

                objEntity.ChargeTotalAmt1 = GetDecimal(dr, "ChargeTotalAmt1");
                objEntity.ChargeTotalAmt2 = GetDecimal(dr, "ChargeTotalAmt2");
                objEntity.ChargeTotalAmt3 = GetDecimal(dr, "ChargeTotalAmt3");
                objEntity.ChargeTotalAmt4 = GetDecimal(dr, "ChargeTotalAmt4");
                objEntity.ChargeTotalAmt5 = GetDecimal(dr, "ChargeTotalAmt5");
                objEntity.TerminationOfDelieryName = GetTextVale(dr, "TerminationOfDeliery");

                objEntity.CreatedEmployeeName = GetTextVale(dr, "CreatedEmployeeName");
                objEntity.UpdatedEmployeeName = GetTextVale(dr, "UpdatedEmployeeName");
                objEntity.TaxAmt = GetDecimal(dr, "TaxAmt");

                objEntity.CreatedBy = GetTextVale(dr, "CreatedBy");
                objEntity.CreatedDate = GetDateTime(dr, "CreatedDate");
                objEntity.UpdatedBy = GetTextVale(dr, "UpdatedBy");
                objEntity.UpdatedDate = GetDateTime(dr, "UpdatedDate");

                lstLocation.Add(objEntity);
            }
            dr.Close();

            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.Customer> Report_GetCustomerDetailLedgerList(Int64 pCustomerID, string pLoginUserID, Nullable<DateTime> Fromdate, Nullable<DateTime> Todate)
        {
            List<Entity.Customer> lstLocation = new List<Entity.Customer>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "CustomerDetailLedger_Report";
            cmdGet.Parameters.AddWithValue("@CustomerID", pCustomerID);
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@ToDate", Todate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.Customer objEntity = new Entity.Customer();
                objEntity.KeyID = GetInt64(dr, "pkID");
                objEntity.TransDate = GetDateTime(dr, "TransDate");
                objEntity.Description = GetTextVale(dr, "Description");
                objEntity.TransCategory = GetTextVale(dr, "TransCategory");
                objEntity.TransType = GetTextVale(dr, "TransType");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.DebitAmount = GetDecimal(dr, "DebitAmount");
                objEntity.CreditAmount = GetDecimal(dr, "CreditAmount");
                objEntity.OpeningAmount = GetDecimal(dr, "OpeningAmount");
                objEntity.ClosingAmount = GetDecimal(dr, "ClosingAmount");

                lstLocation.Add(objEntity);
            }
            dr.Close();

            ForceCloseConncetion();
            return lstLocation;
        }

        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //  REPORT : Method Signature For Quotation List By ProjectList
        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        public virtual List<Entity.PurchaseOrderByProjectList> Report_QuotationFromProjectList(Int64 Project, DateTime Fromdate, DateTime Todate)
        {
            List<Entity.PurchaseOrderByProjectList> lstLocation = new List<Entity.PurchaseOrderByProjectList>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "QuotationListByProjectList_Report";
            cmdGet.Parameters.AddWithValue("@ProjectName", Project);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@ToDate", Todate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.PurchaseOrderByProjectList objEntity = new Entity.PurchaseOrderByProjectList();
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.OrderDate = GetDateTime(dr, "OrderDate");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProjectID = GetInt64(dr, "ProjectID");
                objEntity.ProjectName = GetTextVale(dr, "ProjectName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.Unit = GetTextVale(dr, "Unit");
                objEntity.UnitRate = GetDecimal(dr, "UnitRate");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.NetAmount = GetDecimal(dr, "NetAmount");

                lstLocation.Add(objEntity);
            }
            dr.Close();

            ForceCloseConncetion();
            return lstLocation;
        }

        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //  REPORT : Method Signature For Sales Order List By ProjectList
        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        public virtual List<Entity.PurchaseOrderByProjectList> Report_SalesOrderFromProjectList(Int64 Project, DateTime Fromdate, DateTime Todate)
        {
            List<Entity.PurchaseOrderByProjectList> lstLocation = new List<Entity.PurchaseOrderByProjectList>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SalesOrderListByProjectList_Report";
            cmdGet.Parameters.AddWithValue("@ProjectName", Project);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@ToDate", Todate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.PurchaseOrderByProjectList objEntity = new Entity.PurchaseOrderByProjectList();
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.OrderDate = GetDateTime(dr, "OrderDate");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProjectID = GetInt64(dr, "ProjectID");
                objEntity.ProjectName = GetTextVale(dr, "ProjectName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.Unit = GetTextVale(dr, "Unit");
                objEntity.UnitRate = GetDecimal(dr, "UnitRate");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.NetAmount = GetDecimal(dr, "NetAmount");

                lstLocation.Add(objEntity);
            }
            dr.Close();

            ForceCloseConncetion();
            return lstLocation;
        }

        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //  REPORT : Method Signature For Purchase Order List By ProjectList
        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        public virtual List<Entity.PurchaseOrderByProjectList> Report_PurchaseOrderFromProjectList(Int64 ProjectName, DateTime Fromdate, DateTime Todate)
        {
            List<Entity.PurchaseOrderByProjectList> lstLocation = new List<Entity.PurchaseOrderByProjectList>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "PurchaseOrderListByProjectList_Report";
            cmdGet.Parameters.AddWithValue("@ProjectName",ProjectName);
            cmdGet.Parameters.AddWithValue("@FromDate", Fromdate);
            cmdGet.Parameters.AddWithValue("@ToDate", Todate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.PurchaseOrderByProjectList objEntity = new Entity.PurchaseOrderByProjectList();
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.OrderDate = GetDateTime(dr, "OrderDate");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProjectID = GetInt64(dr, "ProjectID");
                objEntity.ProjectName = GetTextVale(dr, "ProjectName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.Unit = GetTextVale(dr, "Unit");
                objEntity.UnitRate = GetDecimal(dr, "UnitRate");
                objEntity.Amount = GetDecimal(dr, "Amount");
                objEntity.NetAmount = GetDecimal(dr, "NetAmount");

                lstLocation.Add(objEntity);
            }
            dr.Close();

            ForceCloseConncetion();
            return lstLocation;
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Employee wise material Movement Reports
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        public virtual List<Entity.EmpWiseMatMovement> EmpMovementRegister(string pLoginUserID, DateTime FromDate, DateTime ToDate,Int64 EmployeeID)
        {
            List<Entity.EmpWiseMatMovement> lstLocation = new List<Entity.EmpWiseMatMovement>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "EmpWiseMovement_Report";
            cmdGet.Parameters.AddWithValue("@LoginUserID", pLoginUserID);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.EmpWiseMatMovement objEntity = new Entity.EmpWiseMatMovement();

                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                //objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.EmployeeName = GetTextVale(dr, "EmployeeName");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Dispatched = GetDecimal(dr, "Dispatched");
                objEntity.Consumed = GetDecimal(dr, "Consumed");
                objEntity.Returned = GetDecimal(dr, "Returned");
                objEntity.Surplus = GetDecimal(dr, "Surplus");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        //*******************************************************************************************************************
        //  REPORT: METHOD FOR SIGNATURE USER LOG REPORT
        //*******************************************************************************************************************

        public virtual List<Entity.USerLog_Report> UserLog_Report(DateTime FromDate, DateTime ToDate,Int64 UserID)
        {
            List<Entity.USerLog_Report> lstLocation = new List<Entity.USerLog_Report>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "UserLOg_Report";
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            cmdGet.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.USerLog_Report objEntity = new Entity.USerLog_Report();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.UserID = GetTextVale(dr, "UserID");
                objEntity.UserName = GetTextVale(dr, "UserName");
                objEntity.LoginDate = GetDateTime(dr, "LoginDate");
                objEntity.LogoutDate = GetDateTime(dr, "LogoutDate");
                objEntity.LoginTime = GetDateTime(dr, "LoginTime");
                objEntity.LogoutTime = GetDateTime(dr, "LogoutTime");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        // ====================================================================================================================================================================
        // REPORT METHOD SIGNATURE FOR : Order Against Inward Report
        // ====================================================================================================================================================================

        public virtual List<Entity.OrderToPurchaseOrderDetail> OrderAgainstPurchase_Report(string ViewType, Int64 Month, Int64 Year, string LoginUserID, Int64 CustomerID, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.OrderToPurchaseOrderDetail> lstLocation = new List<Entity.OrderToPurchaseOrderDetail>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "PoAgainstOutward_Report";
            cmdGet.Parameters.AddWithValue("@ViewType", ViewType);
            cmdGet.Parameters.AddWithValue("@Month", Month);
            cmdGet.Parameters.AddWithValue("@Year", Year);
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.OrderToPurchaseOrderDetail objEntity = new Entity.OrderToPurchaseOrderDetail();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                objEntity.ProductNameLong = GetTextVale(dr, "ProductNameLong");
                objEntity.OrderQty = GetDecimal(dr, "OrderQty");
                objEntity.DispatchQty = GetDecimal(dr, "DispatchQty");
                objEntity.PendingQty = GetDecimal(dr, "PendingQty");
                objEntity.RequestStatus = GetTextVale(dr, "RequestStatus");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        // ====================================================================================================================================================================
        // REPORT METHOD SIGNATURE FOR : Order Against Outward Report
        // ====================================================================================================================================================================

        public virtual List<Entity.OrderToSalesOrderDetail> OrderAgainstSales_Report(string ViewType, Int64 Month, Int64 Year, string LoginUserID, Int64 CustomerID, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.OrderToSalesOrderDetail> lstLocation = new List<Entity.OrderToSalesOrderDetail>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "DispatchStatusList_Report";
            cmdGet.Parameters.AddWithValue("@ViewType", ViewType);
            cmdGet.Parameters.AddWithValue("@Month", Month);
            cmdGet.Parameters.AddWithValue("@Year", Year);
            cmdGet.Parameters.AddWithValue("@LoginUserID", LoginUserID);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.OrderToSalesOrderDetail objEntity = new Entity.OrderToSalesOrderDetail();
                objEntity.pkID = GetInt64(dr, "pkID");
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.ProductAlias = GetTextVale(dr, "ProductAlias");
                objEntity.ProductNameLong = GetTextVale(dr, "ProductNameLong");
                objEntity.OrderQty = GetDecimal(dr, "OrderQty");
                objEntity.DispatchQty = GetDecimal(dr, "DispatchQty");
                objEntity.PendingQty = GetDecimal(dr, "PendingQty");
                objEntity.RequestStatus = GetTextVale(dr, "RequestStatus");
                //objEntity.DeliveryStatus = GetTextVale(dr, "DeliveryStatus");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        // ====================================================================================================================================================================
        // REPORT METHOD SIGNATURE FOR : Production By SO Report
        // ====================================================================================================================================================================

        public virtual List<Entity.ProductionBySO_Report> ProductionBySO_Report( Int64 CustomerID, DateTime FromDate, DateTime ToDate)
        {
            List<Entity.ProductionBySO_Report> lstLocation = new List<Entity.ProductionBySO_Report>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "ProducttionAssembly_Report";
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@FromDate", FromDate);
            cmdGet.Parameters.AddWithValue("@ToDate", ToDate);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.ProductionBySO_Report objEntity = new Entity.ProductionBySO_Report();
                objEntity.pkID = GetTextVale(dr, "pkID");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.Date = GetDateTime(dr, "Date");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.temp = GetTextVale(dr, "temp");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.MoldingDetail> DieList()
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.Text;
            cmdGet.CommandText = "Select Distinct DieNo, Die, Cavity, Material, Hardness, Quantity, ClientID, " +
                                " dbo.fnGetCustomerName(ClientID) As CustomerName " +
                                " From Molding_Details ";
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<Entity.MoldingDetail> lstLocation = new List<Entity.MoldingDetail>();
            while (dr.Read())
            {
                Entity.MoldingDetail objEntity = new Entity.MoldingDetail();
                objEntity.DieNo = GetTextVale(dr, "DieNo");
                objEntity.Die = GetDecimal(dr, "Die");
                objEntity.Cavity = GetDecimal(dr, "Cavity");
                objEntity.Material = GetTextVale(dr, "Material");
                objEntity.Hardness = GetTextVale(dr, "Hardness");
                objEntity.Quantity = GetDecimal(dr, "Quantity");
                objEntity.ClientID = GetInt64(dr, "ClientID");
                objEntity.CustomerName = GetTextVale(dr, "CustomerName");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }

        public virtual List<Entity.MoldingFinishingQty> MoldingFinishingQtyList()
        {
            List<Entity.MoldingFinishingQty> lstLocation = new List<Entity.MoldingFinishingQty>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "MoldingFinishedQty";
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                Entity.MoldingFinishingQty objEntity = new Entity.MoldingFinishingQty();
                objEntity.OrderNo = GetTextVale(dr, "OrderNo");
                objEntity.ProductID = GetInt64(dr, "ProductID");
                objEntity.ProductName = GetTextVale(dr, "ProductName");
                objEntity.SOQty = GetDecimal(dr, "SOQty");
                objEntity.MoldingQty = GetDecimal(dr, "MoldingQty");
                objEntity.RemainingMoldingQty = GetDecimal(dr, "RemainingMoldingQty");
                objEntity.FinishingQty = GetDecimal(dr, "FinishingQty");
                objEntity.RemainingFinishingQty = GetDecimal(dr, "RemainingFinishingQty");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConncetion();
            return lstLocation;
        }
    }
}
