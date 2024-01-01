using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Unhcr.ProtectDataHub.Persons;

public class PersonAlreadyExistsException: BusinessException
{
    public PersonAlreadyExistsException(string fullName)
        : base(ProtectDataHubDomainErrorCodes.PersonAlreadyExists)
    {
        WithData("fullName", fullName);
    }
}

