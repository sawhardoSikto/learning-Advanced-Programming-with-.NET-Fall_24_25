using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepo<CLASS> : IgenericRepo<CLASS> where CLASS : class
    {
        UMSContext db;
        DbSet<CLASS> table;
        public GenericRepo(UMSContext db)
        {
            this.db = db;
            table = db.Set<CLASS>();
        }
        public bool Create(CLASS obj)
        {
            table.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var existing = table.Find(id);
            if (existing != null)
            {
                table.Remove(existing);
                return db.SaveChanges() > 0;
            }
            return false;

        }

        public List<CLASS> GetAll()
        {
            return table.ToList();

        }

        public CLASS GetById(int id)
        {
            var data = table.Find(id);
            return data;
        }

        public bool Update(CLASS obj)
        {
            table.Update(obj);
            return db.SaveChanges() > 0;
        }
    }
}
