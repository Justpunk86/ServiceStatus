using DapperASPNetCore.Entities;

namespace DapperASPNetCore.Contracts {
  public interface IServiceRepository {
   public Task<IEnumerable<Service>> GetServices();
  }
}
