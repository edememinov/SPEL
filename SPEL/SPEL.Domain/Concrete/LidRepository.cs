using SPEL.Domain.Abstract;
using SPEL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEL.Domain.Concrete
{
    public class LidRepository : IRepository<Lid>
    {
        SPELContext _context;
        public LidRepository()
        {
            _context = new SPELContext();
        }

        public IEnumerable<Lid> List
        {
            get { return _context.Leden; }
        }

        public void Add(Lid entity)
        {
            _context.Leden.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Lid entity)
        {
            _context.Leden.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Lid entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public Lid FindById(int Id)
        {
            var result = (from r in _context.Leden where r.ID == Id select r).FirstOrDefault();
            return result;
        }

        public Lid GetById(int Id, params System.Linq.Expressions.Expression<Func<Lid, object>>[] includeExpressions)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Lid> GetAll(params System.Linq.Expressions.Expression<Func<Lid, object>>[] includeExpressions)
        {
            throw new NotImplementedException();
        }
    }
}
