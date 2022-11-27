using System.Linq.Expressions;
using ElectricBike.Domain.Core.Aggregates;
using ElectricBike.Infrastructure.Data.Context.Base;
using Microsoft.EntityFrameworkCore;

namespace ElectricBike.Infrastructure.Data.Base
{
    public class BaseRepository<T> : IRepositoryBase<T> where T : class
    {
        private readonly IDbContextBase _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        private bool _disposedValue = false;

        public BaseRepository(IDbContextBase dbContext) => _dbContext = dbContext;

        public async Task<T> Add(T entity)
        {
            try
            {
                var newEntity = (await _dbContext.Set<T>().AddAsync(entity).ConfigureAwait(false)).Entity;
                _dbContext.Commit();
                return newEntity;
            }
            catch
            {
                throw new Exception("No se pudo hacer el insert en la BD");
            }
        }

        public async Task<List<T>> GetAll() => await _dbContext.Set<T>().ToListAsync();

        public async Task<T> GetById(Guid id) => await _dbContext.Set<T>().FindAsync(id);

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Set<T>().Remove(entity);
            _dbContext.Commit();
            return true;
        }

        public Task<bool> Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.Commit();
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<T>> SearchMatching(Expression<Func<T, bool>> predicate, int? skipRecords = 0, int? takeRecords = 0)
        {
            return skipRecords == 0 && takeRecords > 0
                ? await _dbContext.Set<T>().Where(predicate).Take(takeRecords.Value).ToListAsync()
                : skipRecords > 0 && takeRecords > 0
                ? await _dbContext.Set<T>().Where(predicate).Skip(skipRecords.Value).Take(takeRecords.Value).ToListAsync()
                : (IEnumerable<T>)await _dbContext.Set<T>().Where(predicate).Skip(skipRecords.Value).ToListAsync();
        }

        public async Task<IEnumerable<T>> SearchMatchingOrderBy<TResponseOrderBy>(Expression<Func<T, TResponseOrderBy>> predicateOrderBy,
            Expression<Func<T, bool>> predicate, int? skipRecords = 0, int? takeRecords = 0, string? orderByType = "desc")
        {
            return orderByType == "asc"
                ? skipRecords == 0 && takeRecords > 0
                ? await _dbContext.Set<T>().Where(predicate).OrderBy(predicateOrderBy).Take(takeRecords.Value).ToListAsync()
                : skipRecords > 0 && takeRecords > 0
                ? await _dbContext.Set<T>().Where(predicate).OrderBy(predicateOrderBy).Skip(skipRecords.Value).Take(takeRecords.Value).ToListAsync()
                : (IEnumerable<T>)await _dbContext.Set<T>().Where(predicate).OrderBy(predicateOrderBy).Skip(skipRecords.Value).ToListAsync()
                : skipRecords == 0 && takeRecords > 0
                ? await _dbContext.Set<T>().Where(predicate).OrderByDescending(predicateOrderBy).Take(takeRecords.Value).ToListAsync()
                : skipRecords > 0 && takeRecords > 0
                ? await _dbContext.Set<T>().Where(predicate).OrderByDescending(predicateOrderBy).Skip(skipRecords.Value).Take(takeRecords.Value).ToListAsync()
                : (IEnumerable<T>)await _dbContext.Set<T>().Where(predicate).OrderByDescending(predicateOrderBy).Skip(skipRecords.Value).ToListAsync();
        }

        public async Task<T> FirstBySearchMatching(Expression<Func<T, bool>> predicate) => 
            await _dbContext.Set<T>().Where(predicate).FirstOrDefaultAsync();

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                    _dbContext.Dispose();
                _disposedValue = true;
            }
        }

        public async Task<T> GetById(decimal id) => await _dbContext.Set<T>().FindAsync(id);

        public async Task<bool> Delete(decimal id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Set<T>().Remove(entity);
            _dbContext.Commit();
            return true;
        }

        ~BaseRepository() => Dispose(false);

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
