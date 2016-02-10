﻿namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface IPlatoonsService
    {
        IQueryable GetAll(int skip, int take);

        Platoon GetById(int id);

        int Add(Platoon platoon);

        int Delete(int id);

        int Update(Platoon platoon);
    }
}
