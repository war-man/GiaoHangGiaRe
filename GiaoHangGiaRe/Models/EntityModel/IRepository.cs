using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModel
{
    public class IRepository<T> : InterfaceRepository<T> where T : class 
    {
        protected GiaoHangGiaReDbContext _db { get; set; }
        protected DbSet<T> _table = null;

        public IRepository()
        {
            _db = new GiaoHangGiaReDbContext();
            _table = _db.Set<T>();
        }

        public IRepository(GiaoHangGiaReDbContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T SelectById(object id)
        {
            try
            {
                return _table.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
            _db.SaveChanges();
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
            _db.SaveChanges();
        }

        //public bool IsExists(object id)
        //{
        //    if (_table.Find(id) == null)
        //        return false;
        //    return true;
        //}
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

    }
}
