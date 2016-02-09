﻿namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitartySystem.Models;

    public interface IPlatoonsService
    {
        IQueryable GetAll();

        Platoon GetById(int id);

        int Add(Platoon platoon);

        int Delete(int id);

        int Update(Platoon platoon);
    }
}