using Dapper;
using DapperASPNetCore.Contracts;
using DapperASPNetCore.Context;
using DapperASPNetCore.Entities;

namespace DapperASPNetCore.Repository {
  public class ServiceRepository : IServiceRepository
  {
    private readonly DapperContext _context;
    public ServiceRepository(DapperContext context) {
     _context = context;
    }

    public async Task<IEnumerable<Service>> GetServices()
    {
      var query = "select * from app.service";
      using (var connection = _context.CreateConnection())
      {
        var services = await connection.QueryAsync<Service>(query);
        return services.ToList();
      }
    }
  }
}
