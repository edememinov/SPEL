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
    public class InschrijvingRepository : IRepository<Inschrijving>
    {
        private SPELContext _context;

        public InschrijvingRepository()
        {
            _context = new SPELContext();
        }

        public IEnumerable<Inschrijving> List
        {
            get { return _context.Inschrijvingen; }
        }

        public void Add(Inschrijving entity)
        {
            _context.Inschrijvingen.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Inschrijving entity)
        {
            _context.Inschrijvingen.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Inschrijving entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public Inschrijving FindById(int Id)
        {
            var result = (from r in _context.Inschrijvingen where r.ID == Id select r).FirstOrDefault();
            return result;
        }

        public Inschrijving GetById(int id, params Expression<Func<Inschrijving, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<Inschrijving, object>>, IQueryable<Inschrijving>>
                         (_context.Inschrijvingen, (current, expression) => current.Include(expression));

                return set.SingleOrDefault(s => s.ID == id);
            }

            return _context.Inschrijvingen.Find(id);
        }

        public IQueryable<Inschrijving> GetAll(params Expression<Func<Inschrijving, object>>[] includeExpressions)
        {
            return includeExpressions.Aggregate<Expression<Func<Inschrijving, object>>, IQueryable<Inschrijving>>
                (_context.Inschrijvingen, (current, expression) => current.Include(expression));
        }
    }
}
