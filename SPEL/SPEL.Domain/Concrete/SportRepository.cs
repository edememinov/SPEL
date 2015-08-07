using SPEL.Domain.Abstract;
using SPEL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEL.Domain.Concrete
{
    public class SportRepository : IRepository<Sport>
    {
        SPELContext _context;
        public SportRepository()
        {
            _context = new SPELContext();
        }

        public IEnumerable<Sport> List
        {
            get { return _context.sporten; }
        }

        public void Add(Sport entity)
        {
            _context.sporten.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Sport entity)
        {
            _context.sporten.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Sport entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public Sport FindById(int Id)
        {
            var result = (from r in _context.sporten where r.ID == Id select r).FirstOrDefault();
            return result;
        }

        public Sport GetById(int Id, params System.Linq.Expressions.Expression<Func<Sport, object>>[] includeExpressions)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Sport> GetAll(params System.Linq.Expressions.Expression<Func<Sport, object>>[] includeExpressions)
        {
            throw new NotImplementedException();
        }
    }
}
