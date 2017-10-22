using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Models
{
    public class IdentityRepository<T> : InterfaceIdentityRepository<T> where T : class
    {
        protected ApplicationDbContext _db { get; set; }
        protected DbSet<T> _table = null;

        public IdentityRepository()
        {
            _db = new ApplicationDbContext();
            _table = _db.Set<T>();
        }

        public IdentityRepository(ApplicationDbContext db)
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
            _table.Add(obj); //Them khong the su dung duoc. LOI
            //_db.Roles.Add(obj);
            _db.SaveChanges();
            
        }
        public void InsertRole(IdentityRole obj)
        {
           
            _db.Roles.Add(obj);
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
