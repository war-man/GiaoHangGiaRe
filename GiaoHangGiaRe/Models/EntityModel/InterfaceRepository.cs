using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModel
{
    interface InterfaceRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T SelectById(object id);
        void Insert(T obj);

        void Update(T obj);

        void Delete(object id);



        //bool IsExists(object id);
        //void Save();
    }
}
