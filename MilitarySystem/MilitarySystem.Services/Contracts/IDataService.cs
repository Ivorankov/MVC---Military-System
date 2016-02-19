using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitarySystem.Services.Contracts
{
    public interface IDataService<T>
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        int Add(T objectEntity);

        int Delete(object id);

        int Update(T objectEntity);
    }
}
