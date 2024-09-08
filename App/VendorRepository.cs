using Dapper;
using Microsoft.Data.SqlClient;

namespace App;



public class VendorRepository : IRepository
{
    private readonly string _conncetionString;

    public VendorRepository(string conncetionString)
    {
        _conncetionString = conncetionString;

    }

    private string Query()
    {
        return @"SELECT   [VendorID],
                                [VendorName],
                                [VendorAddress1],
                                [VendorAddress2],
                                [VendorCity],
                                [VendorState],
                                [VendorZipCode],
                                [VendorPhone],
                                [VendorContactLName],
                                [VendorContactFName],
                                [DefaultTermsID],
                                [DefaultAccountNo]
                                FROM [AP].[dbo].[Vendors]";
    }

    public async Task<IEnumerable<Vendor>> GetVendorByEnumerable(string city = "")
    {
        IEnumerable<Vendor> vendors = await GetConnections();

        if (!string.IsNullOrWhiteSpace(city))
            return vendors.Where(x => x.VendorCity == city);

        return vendors;
    }

    private async Task<IEnumerable<Vendor>> GetConnections()
    {
        IEnumerable<Vendor> vendors;
        
        using (var _sqlConnection = new SqlConnection(_conncetionString))
        {
            _sqlConnection.Open();
            vendors = await _sqlConnection.QueryAsync<Vendor>(Query());
            _sqlConnection.Close();
        }

        return vendors;
    }

    public async Task<IQueryable<Vendor>> GetVendorByQueryble(string city = "")
    {
        IEnumerable<Vendor> vendors = await GetConnections();

        var resultVendors = vendors.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(city))
            return resultVendors.Where(x => x.VendorCity == city);

        return resultVendors;
    }
}