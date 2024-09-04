// See https://aka.ms/new-console-template for more information
public class Vendor
{
    public int VendorID { get; set; }
    public string VendorName { get; set; }
    public string VendorAddress1 { get; set; }
    public string VendorAddress2 { get; set; }
    public string VendorCity { get; set; }
    public string VendorState { get; set; }
    public string VendorZipCode { get; set; }
    public string VendorPhone { get; set; }
    public string VendorContactLName { get; set; }
    public string VendorContactFName { get; set; }
    public int DefaultTermsID { get; set; }
    public int DefaultAccountNo { get; set; }
    public string InvoiceNumber { get; set; }

    public override string ToString()
    {
        return $"VendorID: {VendorID}, " +
               $"VendorName: {VendorName}, " +
               $"City: {VendorCity}, " +
               $"Phone: {VendorPhone}, " +
               $"Invoice Number: {InvoiceNumber}";
    }
}