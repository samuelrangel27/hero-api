using System;
using hero.aplication.DTOs.Inputs.Power;
using hero.aplication.Services.Interfaces;
using hero.domain.Entities;
using Netploy.Common.Application.Base;
using Netploy.Common.Base.Repositories;

namespace hero.aplication.Services.Implementations
{
    public class PowerApplicationService : BaseApplicationService<Power, int, AddPowerInput, UpdatePowerInput>, IPowerApplicationService
    {
        public PowerApplicationService(IBaseRepository<Power, int> repository) : base(repository)
        {
        }
    }
}
