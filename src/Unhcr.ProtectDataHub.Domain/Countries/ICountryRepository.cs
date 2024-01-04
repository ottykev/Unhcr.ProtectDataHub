using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Unhcr.ProtectDataHub.Countries;

public interface ICountryRepository: IRepository<Country, Guid>
{
    Task<Country> FindByCountryNameAsync(string countryName);
    Task<List<Country>> GetListAsync(
               int skipCount,
                      int maxResultCount,
                             string sorting,
                                    string filter = null
               );
}
