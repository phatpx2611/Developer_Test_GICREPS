﻿using Developer_Test_GICREPS.Application.Common.Entities;

namespace Developer_Test_GICREPS.Application.Common.Interfaces.Infratructure
{
    public interface IEstimateDataService
    {
         Task<List<Estimate>> GetByState(double state);
    }
}
