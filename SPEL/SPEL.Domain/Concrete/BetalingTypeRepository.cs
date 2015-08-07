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
    public class BetalingTypeRepository : IRepository<BetalingType>
    {
        private SPELContext _context;

        public BetalingTypeRepository()
        {
            _context = new SPELContext();
        }

        public IEnumerable<BetalingType> List
        {
            get { return _context.BetalingTypes; }
        }

        public void Add(BetalingType entity)
        {
            _context.BetalingTypes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(BetalingType entity)
        {
            _context.BetalingTypes.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(BetalingType entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public BetalingType FindById(int Id)
        {
            var result = (from r in _context.BetalingTypes where r.ID == Id select r).FirstOrDefault();
            return result;
        }

        public BetalingType GetById(int id, params Expression<Func<BetalingType, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<BetalingType, object>>, IQueryable<BetalingType>>
                         (_context.BetalingTypes, (current, expression) => current.Include(expression));

                return set.SingleOrDefault(s => s.ID == id);
            }

            return _context.BetalingTypes.Find(id);
        }

        public IQueryable<BetalingType> GetAll(params Expression<Func<BetalingType, object>>[] includeExpressions)
        {
            return includeExpressions.Aggregate<Expression<Func<BetalingType, object>>, IQueryable<BetalingType>>
                (_context.BetalingTypes, (current, expression) => current.Include(expression));
        }
    }
}
