using SPEL.Domain.Abstract;
using SPEL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SPEL.Domain.Concrete
{
    public class SportklasseRepository : IRepository<Sportklasse>
    {
        SPELContext _context;
        public SportklasseRepository()
        {
            _context = new SPELContext();
        }

        public IEnumerable<Sportklasse> List
        {
            get { return _context.klasses; }
        }

        public void Add(Sportklasse entity)
        {
            _context.klasses.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Sportklasse entity)
        {
            _context.klasses.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Sportklasse entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public Sportklasse FindById(int Id)
        {
            var result = (from r in _context.klasses where r.ID == Id select r).FirstOrDefault();
            return result;
        }

        public Sportklasse GetById(int Id, params System.Linq.Expressions.Expression<Func<Sportklasse, object>>[] includeExpressions)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Sportklasse> GetAll(params System.Linq.Expressions.Expression<Func<Sportklasse, object>>[] includeExpressions)
        {
            return includeExpressions.Aggregate<Expression<Func<Sportklasse, object>>, IQueryable<Sportklasse>>
                (_context.klasses, (current, expression) => current.Include(expression)); throw new NotImplementedException();
        }
    }
}
