
using App;

var repo = new VendorRepository(ConnectionString.Connection);

var vendorEnum = await repo.GetVendorByQueryble("Fresno");

foreach (var vendor in vendorEnum)
{
    Console.WriteLine(vendor.ToString());
}