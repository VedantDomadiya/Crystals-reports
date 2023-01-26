using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Report
    {
        public class Report_Member
        {
            public string RegistrationNo { get; set; }

            public DateTime Start_Date { get; set; }
            public DateTime End_Date { get; set; }

            public string Present_CityCode { get; set; }
        }

    }

    public class VedantQuotation //here
    {
        public string QuotationNo { get; set; }
        public DateTime QuotationDate { get; set; }
        public string InquiryNo { get; set; }
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public string QuotationSubject { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string ProductName { get; set; }
    }

    public class ProductReport
    {
        public Int64 pkID { get; set; }
        public string ProductName { get; set; }
        public string ProductAlias { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductSpecification { get; set; }
        public DateTime LRDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal  OpeningSTK { get; set; }
        public decimal OutwardSTK { get; set; }
        public decimal ClosingSTK { get; set; }
        public decimal InwardSTK { get; set; }

    }
    public class CustomerReport
    {
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public string Area { get; set; }
        public Int64 CityCode { get; set; }
        public string EmailAddress { get; set; }
        public string CountryCode { get; set; }
        public Int64 PriceList { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }

    public class Employee
    {
        public Int64 Employee_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public Int64 Salary { get; set; }
        public DateTime Joining_date { get; set; }
        public string Department { get; set; }
        public Int64 ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
    }


    public class PettyCashReport
    {
        public Decimal Opening { get; set; }
        public String VoucherNo { get; set; } 
        public Decimal Expense { get; set; }
        public Decimal Income { get; set; }
        public Int64 DBCustomerID { get; set; }
        public Int64 CRCustomerID { get; set; }
        public string CRCustomerName { get; set; }
        public string DBCustomerName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime VoucherDate { get; set; }
        public string LoginUserID { get; set; }
    }
    public class ShiftReport
    {
        public string ShiftName { get; set; }
        public string BasicPer { get; set; }
        public string EmployeeName { get; set; }
    }
    public class VehicleList
    {
        public String RegistrationNo { get; set; }
        public String OwnerName { get; set; }
        public String ChasisNo { get; set; }
        public String Model { get; set; }
        public String OwnerAddress { get; set; }
        public String OwnerMobile { get; set; }
        public String InsuranceCompany { get; set; }
        public String InsurancePolicyNo { get; set; }
        public DateTime InsuranceExpiry { get; set; }
        public string LoginUserID { get; set; }
    }
    public class PurchaseReport
    {
        public Int64 BrandID { get; set; }
        public String BrandName { get; set; }
        public Int64 ProductGroupID { get; set; }
        public String ProductGroupName { get; set; }
        public Int64 pkID { get; set; }
        public String ProductName { get; set; }
        public String ProductAlias { get; set; }
        public Int64 CustomerID { get; set; }
        public String CustomerName { get; set; }
        public Int64 CityCode { get; set; }
        public String CityName { get; set; }
        public Int64 StateCode { get; set; }
        public String StateName { get; set; }
        public String OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal UnitRate { get; set; }
        public Decimal Amount { get; set; }
        public Decimal SGSTPer { get; set; }
        public Decimal CGSTPer { get; set; }
        public Decimal IGSTPer { get; set; }
        public Decimal SGSTAmt { get; set; }
        public Decimal CGSTAmt { get; set; }
        public Decimal IGSTAmt { get; set; }
        public Decimal TotSGST { get; set; }
        public Decimal TotCGST { get; set; }
        public Decimal TotIGST { get; set; }
        public Decimal TaxAmount { get; set; }
        public Decimal NetAmount { get; set; }
    }
    

    public class SalesReport
    {
        public Int64 BrandID { get; set; }
        public String BrandName { get; set; }
        public Int64 ProductGroupID { get; set; }
        public String ProductGroupName { get; set; }
        public Int64 pkID { get; set; }
        public String ProductName { get; set; }
        public String ProductAlias { get; set; }
        public Int64 CustomerID { get; set; }
        public String CustomerName { get; set; }
        public Int64 CityCode { get; set; }
        public String CityName { get; set; }
        public Int64 StateCode { get; set; }
        public String StateName { get; set; }
        public String OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal UnitRate { get; set; }
        public Decimal Amount { get; set; }
        public Decimal SGSTPer { get; set; }
        public Decimal CGSTPer { get; set; }
        public Decimal IGSTPer { get; set; }
        public Decimal SGSTAmt { get; set; }
        public Decimal CGSTAmt { get; set; }
        public Decimal IGSTAmt { get; set; }
        public Decimal TotSGST { get; set; }
        public Decimal TotCGST { get; set; }
        public Decimal TotIGST { get; set; }
        public Decimal TaxAmount { get; set; }
        public Decimal NetAmount { get; set; }
    }

    public class SODetailedReport
    {
        //SalesOrderDetailed_Report
        //public Int64 pkID { get; set; }
        public String OrderNo { get; set; }
        public String ReferenceNo { get; set; }
        public String ContactNo1 { get; set; }
        public String GSTNO { get; set; }
        public String EmailAddress { get; set; }
        public String DriverName { get; set; }
        public String DriverContact { get; set; }
        public DateTime ReferenceDate { get; set; }
        public Int64 CustomerID { get; set; }
        public String CustomerName { get; set; }
        public Int64 ProductID { get; set; }
        public String ProductName { get; set; }
        public String ProductAlias { get; set; }
        public String Spec { get; set; }
        public Int64 CityCode { get; set; }
        public String City { get; set; }
        public Int64 StateCode { get; set; }
        public String State { get; set; }
        public String CountryCode { get; set; }
        public String Country { get; set; }
        public String Address{ get; set; }
        public String LRNo { get; set; }
        public String FlightNo{ get; set; }
        public string MachineCommitioning { get; set; }
        public string RefferenceList { get; set; }
        public string PackageType { get; set; }
    }
    public class DispatchStatus
    {
        public Int64 pkID { get; set; }
        public String OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public Int64 CustomerID { get; set; }
        public String CustomerName { get; set; }
        public Int64 ProductID { get; set; }
        public String ProductName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public String Unit { get; set; }
        public String ProductNameLong { get; set; }
        public String ProductAlias { get; set; }
        public Decimal OrderQty { get; set; }
        public Decimal DispatchQty { get; set; }
        public Decimal PendingQty { get; set; }
        public String Status { get; set; }
        public string RequestStatus { get; set; }
        public String DeliveryStatus { get; set; }
        public String ApprovalStatus { get; set; }
    }

    public class MonthlySalesSummary
    {
        public Int64 ProductID { get; set; }
        public String ProductName { get; set; }
        public Decimal M1 { get; set; }
        public Decimal M2 { get; set; }
        public Decimal M3 { get; set; }
        public Decimal M4 { get; set; }
        public Decimal M5 { get; set; }
        public Decimal M6 { get; set; }
        public Decimal M7 { get; set; }
        public Decimal M8 { get; set; }
        public Decimal M9 { get; set; }
        public Decimal M10 { get; set; }
        public Decimal M11 { get; set; }
        public Decimal M12 { get; set; }

    }

    public class MonthlyPurchase
    {
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal M1 { get; set; }
        public decimal M2 { get; set; }
        public decimal M3 { get; set; }
        public decimal M4 { get; set; }
        public decimal M5 { get; set; }
        public decimal M6 { get; set; }
        public decimal M7 { get; set; }
        public decimal M8 { get; set; }
        public decimal M9 { get; set; }
        public decimal M10 { get; set; }
        public decimal M11 { get; set; }
        public decimal M12 { get; set; }
    }
    public class SalaryRegister
    {
        public Int64 EmployeeID { get; set; }
        public String EmployeeName { get; set; }
        public String Designation { get; set; }
        public DateTime PayDate { get; set; }
        public Int64 WDays { get; set; }
        public Int64 PDays { get; set; }
        public Int64 LDays { get; set; }
        public Int64 HDays { get; set; }
        public Int64 ODays { get; set; }
        public Decimal FixedSalary { get; set; }
        public Decimal Basic { get; set; }
        public Decimal Hra { get; set; }
        public Decimal Conveyance { get; set; }
        public Decimal OverTime { get; set; }
        public Decimal Medical { get; set; }
        public Decimal DA { get; set; }
        public Decimal Special { get; set; }
        public Decimal Total_Income { get; set; }
        public Decimal PF { get; set; }
        public Decimal ESI { get; set; }
        public Decimal PT { get; set; }
        public Decimal TDS { get; set; }
        public Decimal Loan { get; set; }
        public decimal Upad { get; set; }
        public Decimal Total_Deduct { get; set; }
        public Decimal NetSalary { get; set; }
        public String Gender { get; set; }

    }
    public class EmpWiseMatMovement
    {
        public Int64 pkID { get; set; }
        public Int64 EmployeeID { get; set; }
        public Int64 ProductID { get; set; }
        public String EmployeeName { get; set; }
        public String ProductName { get; set; }
        public Decimal Dispatched { get; set; }
        public Decimal Consumed { get; set; }
        public Decimal Returned { get; set; }
        public Decimal Surplus { get; set; }
        public string LoginUserID { get; set; }
    }
    public class CompliantReport
    {
        public Int64 pkID { get; set; }
        public string ComplaintNo { get; set; }
        public DateTime ComplaintDate { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactNo1 { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string CityName { get; set; }
        public string PinCode { get; set; }
        public string StateName { get; set; }
        public string OtherDetails { get; set; }
        public string ComplaintStatus { get; set; }
        public Int64 EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string AssignedTo { get; set; }
    }

    public class ReportWithSign
    {
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ContactNo1 { get; set; }
        public string KW { get; set; }
        public string NatureOFProblem { get; set; }
        public string ActionTaken { get; set; }

    }

    //======================================================
    //                  Outward Report Vardhman
    //======================================================

    public class OutwardReport
    {
       // public Int64 pkID { get; set; }
        public string ManualOutwardNo { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public string Remarks { get; set; }
        public DateTime OutwardDate { get; set; }
    }

    public class JobCardOutwardReport
    {
        public string OutwardNo { get; set; }
        public DateTime OutwardDate { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }

        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public string OrderNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }

    public class JobCardInwardReport
    {
        public string InwardNo { get; set; }
        public DateTime InwardDate { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }

        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public string OutwardNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
    public class MaterialMovementReport
    {
        public DateTime TransDate { get; set; }
        public string TransType { get; set; }
        public Int64 CustomerID { get; set; }
        public String CustomerName { get; set; }
        public String OrderNo { get; set; }
        public Int64 EmployeeID { get; set; }
        public String EmployeeName { get; set; }
        public String ProductName { get; set; }
        public decimal Quantity { get; set; }
        public String LoginUserID { get; set; }
    }
    public class JobCardStatus
    {
        public Int64 pkID { get; set; }
        public String OutwardNo { get; set; }
        public DateTime OutwardDate { get; set; }
        public Int64 CustomerID { get; set; }
        public String CustomerName { get; set; }
        public Int64 ProductID { get; set; }
        public String ProductName { get; set; }
        public String ProductNameLong { get; set; }
        public String ProductAlias { get; set; }
        public Decimal OutwardQty { get; set; }
        public Decimal InwardQty { get; set; }
        public Decimal RemainingQty { get; set; }
        public String Status { get; set; }
    }
    public class InstallFabricReport
    {
        public DateTime InspectionDate { get; set; }
        public string CustomerName { get; set; }
        public string CheckDesc { get; set; }
        public string CheckFlag { get; set; }
        public string CheckRemark { get; set; }
        public string EmployeeName { get; set; }
        public String LoginUserID { get; set; }
        public string InspectionType { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string CityName { get; set; }
        public string ContactNo { get; set; }
    }
    public class PackingListReport
    {
        public string OutwardNo { get; set; }
        public DateTime OutwardDate { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }

        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public string OrderNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string SerialNo { get; set; }
        public string BoxNo { get; set; }
        public Int64 LocationID { get; set; }
        public string LocationName { get; set; }
    }

    public class VisitorReport
    {
        public string InquiryNo { get; set; }
        public DateTime VisitDate { get; set; }
        public string VisitTime { get; set; }
        public string VisitorName { get; set; }
        public string CompanyName { get; set; }
        public string PurposeOfVisit { get; set; }
        public string VisitorContact { get; set; }
        public string Department { get; set; }
        public string MeetingTo { get; set; }
    }

    public class InwardReport
    {
        public string InwardNo { get; set; }
        public string ManuaLInwardNo { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public Int64 Quantity { get; set; }
        public string TransportRemark { get; set; }
        public DateTime InwardDate { get; set; }
    }

    public class InwardOutwardReport
    {
        public string ManuaLInwardNo { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public Int64 Quantity { get; set; }
        public string TransportRemark { get; set; }
        public DateTime InwardDate { get; set; }
        public string grp { get; set; }
    }

    public class PendingBillReport
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Int64 BillAmount { get; set; }
        public Int64 ReceivedAmount { get; set; }
        public Int64 DBAmount { get; set; }
        public Int64 CRAmount { get; set; }
        public Int64 BalanceAmount { get; set; }
        public string BillStatus { get; set; }
        public DateTime DueDate { get; set; }
        public Int64 OverdueDays { get; set; }
        public Int64 Slab1 { get; set; }
        public Int64 Slab2 { get; set; }
        public Int64 Slab3 { get; set; }
        public Int64 Slab4 { get; set; }
        public Int64 Slab5 { get; set; }
    }

    public class DebitCreditNoteReport
    {
        public string VoucherNo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public Int64 VoucherAmount { get; set; }
        public string DBC { get; set; }
        public Int64 CRCustomerID { get; set; }
        public Int64 DBCustomerID { get; set; }
        public string DBCustomerName { get; set; }
        public string CRCustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }

    public class ExternalLeadReport
    {
        public Int64 pkID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CustomerType { get; set; }
        public Int64 PerMonthSales { get; set; }
        public DateTime JoinAsDealer { get; set; }
        public string FirmName { get; set; }
        public string ContactPerson  { get; set; }
        public string PrimaryMobileNo { get; set; }
        public string City  { get; set; }
        public string State { get; set; }
        public string Address { get; set; } 
        public string Message { get; set; }
    }

    public class GRNReport
    {
        public string InwardNo { get; set; }
        public DateTime InwardDate { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }

        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public string OrderNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string LocationName { get; set; }
    }

    public class ExpenseVoucher_Report
    {
        public Int64 pkID { get; set; }
        public string VoucherNo{ get; set; }
        public DateTime VoucherDate { get; set; }
        public Int64 DBCustomerID { get; set; }
        public Int64 CRCustomerID { get; set; }
        public string VAccount{ get; set; }
        public string EAccount{ get; set; }
        public string EmployeeName { get; set; }
        public Decimal VoucherAmount { get; set; }
        public String Remarks { get; set; }
        public string LoginUserID { get; set; }
        public String CreatedBy { get; set; }
        public String CreatedEmployee { get; set; }
    }
    public class EmployeeActivity
    {
        public Int64 RowNum { get; set; }
        public Int64 pkID { get; set; }
        public string DocNo { get; set; }
        public DateTime DocDate { get; set; }
        public Int64 CustomerID { get; set; }
        public String Customer { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string grp { get; set; }
        public Decimal NetAmt { get; set; }
        public string MeetingNotes { get; set; }
        public String Action { get; set; }
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public String UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class JobCardReport
    {
        public Int64 ProductID { get; set; }
        public Int64 CustomerID { get; set; }

        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public Int64 Location1 { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }

        public string JobCardNo { get; set; }
        public DateTime JobCardDate { get; set; }
        public DateTime Vin { get; set; }
        public Int64 WheelNo { get; set; }
        public string TypeOfJob { get; set; }
        public string WheelMake { get; set; }
        public string RegNo { get; set; }
        public string ClaimNo { get; set; }


    }

    public class QuotationByProjectList
    {
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitQty { get; set; }
        public decimal Quantity { get; set; }
        public decimal Unit { get; set; }
        public decimal UnitRate { get; set; }
        public decimal NetAmount { get; set; }
        public decimal Amount { get; set; }
    }
    public class PurchaseOrderByProjectList
    {
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public Int64 ProductID { get; set; }
        public Int64 ProjectID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitQty { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public decimal UnitRate { get; set; }
        public decimal NetAmount { get; set; }
        public decimal Amount { get; set; }
    }
    public class SalesOrderByProjectList
    {
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitQty { get; set; }
        public decimal Quantity { get; set; }
        public decimal Unit { get; set; }
        public decimal UnitRate { get; set; }
        public decimal NetAmount { get; set; }
        public decimal Amount { get; set; }
    }

    public class USerLog_Report
    {
        public Int64 pkID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LogoutDate { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }

    }

    public class OrderToPurchaseOrderDetail
    {
        public Int64 pkID { get; set; }
        public string  OrderNo { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductAlias { get; set; }
        public string ProductNameLong { get; set; }
        public decimal OrderQty { get; set; }
        public decimal DispatchQty { get; set; }
        public decimal PendingQty { get; set; }
        public string RequestStatus { get; set; }
    }

    public class OrderToSalesOrderDetail
    {
        public Int64 pkID { get; set; }
        public string OrderNo { get; set; }
        public string ReferenceNo { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductAlias { get; set; }
        public string ProductNameLong { get; set; }
        public decimal OrderQty { get; set; }
        public decimal DispatchQty { get; set; }
        public decimal PendingQty { get; set; }
        public string RequestStatus { get; set; }
        
    }

    public class ProductionBySO_Report
    {
        public string pkID { get; set; }
        public Int64 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; }
        public string Remarks { get; set; }
        public string temp { get; set; }

    }


}
