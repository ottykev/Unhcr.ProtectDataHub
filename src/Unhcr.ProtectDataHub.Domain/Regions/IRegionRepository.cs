using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Unhcr.ProtectDataHub.Regions;

public interface IRegionRepository: IRepository<Region, Guid>
{
    Task<Region> FindByNameAsync(string name);
    Task<List<Region>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
        );
}
