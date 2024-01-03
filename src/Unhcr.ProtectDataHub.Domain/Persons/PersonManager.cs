using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Countries;
using Unhcr.ProtectDataHub.Regions;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Unhcr.ProtectDataHub.Persons;

public class PersonManager: DomainService
{
    private readonly IPersonRepository _personRepository;

    public PersonManager(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Person> CreateAsync(
                      string fullName, 
                      string email,
                      string phoneNumber, 
                      ClusterAor aor, 
                      Cordination levelofCordination, 
                      string dutyStation, 
                      bool workingfromDutyStation, 
                      OrgType organization_Type, 
                      string organizationName, 
                      Position position, 
                      StaffLevel staff,
                      DoubleHattingLevel doubleHatting, 
                      StaffGrade staffGrade, 
                      ContractType contractType, 
                      DateTime startDate, 
                      DateTime endDate,
                      bool isActive
                      )
    {
        Check.NotNullOrWhiteSpace(fullName, nameof(fullName));

        var existingPerson = await _personRepository.FindByFullNameAsync(fullName);
        if (existingPerson != null)
        {
            throw new PersonAlreadyExistsException(fullName);
        }

        return new Person(
               GuidGenerator.Create(),
                   fullName,
                   email,
                   phoneNumber,
                   aor,
                   levelofCordination,
                   dutyStation,
                   workingfromDutyStation,
                   organization_Type,
                   organizationName,
                   position,
                   staff,
                   doubleHatting,
                   staffGrade,
                   contractType,
                   startDate,
                   endDate,
                   isActive
               );
    }

    public async Task ChangeNameAsync(
                      Person person,
                                           string fullName
                      )
    {
        Check.NotNull(person, nameof(person));
        Check.NotNullOrWhiteSpace(fullName, nameof(fullName));
        var existingPerson = await _personRepository.FindByFullNameAsync(fullName);
        if (existingPerson != null && existingPerson.Id != person.Id)
        {
            throw new PersonAlreadyExistsException(fullName);
        }

        person.ChangeName(fullName);
    }
}
