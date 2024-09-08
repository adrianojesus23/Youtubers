namespace App;

public interface IRepository
{
    Task<IEnumerable<Vendor>> GetVendorByEnumerable(string city = "");
    Task<IQueryable<Vendor>> GetVendorByQueryble(string city = "");
}