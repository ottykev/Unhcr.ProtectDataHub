using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Unhcr.ProtectDataHub.Regions;

namespace Unhcr.ProtectDataHub.Countries;

public class EfCoreCountryRepository: EfCoreRepository<ProtectDataHubDbContext, Country, Guid>, ICountryRepository
{
    public EfCoreCountryRepository(IDbContextProvider<ProtectDataHubDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    public async Task<Country> FindByNameAsync(string name)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(country => country.Name == name);
    }
    public async Task<List<Country>> GetListAsync(
                             int skipCount,
                                                                       int maxResultCount,
                                                                                                                                             string sorting,
                                                                                                                                                                                                                                                      string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(
                                                 !filter.IsNullOrWhiteSpace(),
                                                                                                                               country => country.Name.Contains(filter)
                                                                                                                                                                                                                                                                 )
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}
