using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Unhcr.ProtectDataHub.Regions;

public class EfCoreRegionRepository: EfCoreRepository<ProtectDataHubDbContext, Region, Guid>, IRegionRepository
{
    public EfCoreRegionRepository(IDbContextProvider<ProtectDataHubDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    public async Task<Region> FindByNameAsync(string name)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(region => region.Name == name);
    }
    public async Task<List<Region>> GetListAsync(
               int skipCount,
                      int maxResultCount,
                             string sorting,
                                    string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(
                           !filter.IsNullOrWhiteSpace(),
                                          region => region.Name.Contains(filter)
                                                     )
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}

