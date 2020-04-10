using System;
using hero.aplication.DTOs.Inputs.Power;
using hero.domain.Entities;
using Netploy.Common.Application.Base;

namespace hero.aplication.Services.Interfaces
{
    public interface IPowerApplicationService : IApplicationService<Power,int,AddPowerInput,UpdatePowerInput>
    {
    }
}
