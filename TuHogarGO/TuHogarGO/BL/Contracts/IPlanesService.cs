﻿using TuHogarGO.Entities;

namespace TuHogarGO.BL.Contracts
{
    public interface IPlanesService: IServiceBase<Plan>
    {
        IList<Plan> GetAll();
    }
}