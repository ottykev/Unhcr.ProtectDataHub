using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Unhcr.ProtectDataHub.Countries;

namespace Unhcr.ProtectDataHub.Persons;

public class EfCorePersonRepository : EfCoreRepository<ProtectDataHubDbContext, Person, Guid>, IPersonRepository
{
    public EfCorePersonRepository(IDbContextProvider<ProtectDataHubDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    public async Task<Person> FindByFullNameAsync(string fullName)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(person => person.FullName == fullName);
    }
    public async Task<List<Person>> GetListAsync(
                      int skipCount,
                                           int maxResultCount,
                                                                       string sorting,
                                                                                                          string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(
                                      !filter.IsNullOrWhiteSpace(),
                                                                               person => person.FullName.Contains(filter)
                                                                                                                                   )
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}

