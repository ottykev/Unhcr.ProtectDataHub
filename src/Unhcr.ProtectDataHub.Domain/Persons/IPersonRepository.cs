using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Unhcr.ProtectDataHub.Persons;

public interface IPersonRepository: IRepository<Person, Guid>
{
    Task<Person> FindByFullNameAsync(string fullName);
    Task<List<Person>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
        );
}
