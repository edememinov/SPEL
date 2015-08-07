using SPEL.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SPEL.Domain.Abstract
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int Id);
        T GetById(int Id, params Expression<Func<T, object>>[] includeExpressions);
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions);
    }
}
