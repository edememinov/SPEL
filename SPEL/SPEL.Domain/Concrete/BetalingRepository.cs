using SPEL.Domain.Abstract;
using SPEL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SPEL.Domain.Concrete
{
    public class BetalingRepository : IRepository<Betaling>
    {
        private SPELContext _context;

        public BetalingRepository()
        {
            _context = new SPELContext();
        }

        public IEnumerable<Betaling> List
        {
            get { return _context.Betalingen; }
        }

        public void Add(Betaling entity)
        {
            _context.Betalingen.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Betaling entity)
        {
            _context.Betalingen.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Betaling entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public Betaling FindById(int Id)
        {
            var result = (from r in _context.Betalingen where r.ID == Id select r).FirstOrDefault();
            return result;
        }

        public Betaling GetById(int id, params Expression<Func<Betaling, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<Betaling, object>>, IQueryable<Betaling>>
                         (_context.Betalingen, (current, expression) => current.Include(expression));

                return set.SingleOrDefault(s => s.ID == id);
            }

            return _context.Betalingen.Find(id);
        }

        public IQueryable<Betaling> GetAll(params Expression<Func<Betaling, object>>[] includeExpressions)
        {
            return includeExpressions.Aggregate<Expression<Func<Betaling, object>>, IQueryable<Betaling>>
                (_context.Betalingen, (current, expression) => current.Include(expression));
        }
    }
}
