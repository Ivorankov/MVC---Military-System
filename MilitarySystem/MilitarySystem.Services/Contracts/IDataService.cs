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

        T GetById(object id);

        int Add(T objectEntity);

        int Delete(T dbObject);

        int Update(T objectEntity);
    }
}
