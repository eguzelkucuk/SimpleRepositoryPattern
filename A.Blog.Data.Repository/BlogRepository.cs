using A.Blog.Data.Repository;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace A.Blog.Data.Test
{
    public class BlogRepository : IRepository
    {
        private readonly BlogEntityContext _context;
        public BlogRepository() {
            _context = new BlogEntityContext();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return _context.Set<T>();
        }

        public IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] include) where T : class
        {
            IQueryable<T> retVal = _context.Set<T>();

            foreach (var item in include)
            {
                retVal = retVal.Include(item);
            }

            return retVal;
        }

        public void Dispose()
        {
            if (_context != null) _context.Dispose();
        }
    }
}