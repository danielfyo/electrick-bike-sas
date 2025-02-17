﻿using System.Linq.Expressions;

namespace ElectricBike.Domain.Core.Aggregates
{
    public interface IRepositoryBase<TGenericEntity> : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }

        Task<TGenericEntity> Add(TGenericEntity entity);

        Task<bool> Delete(Guid id);

        Task<bool> Update(TGenericEntity entity);

        Task<TGenericEntity?> GetById(Guid id);

        Task<List<TGenericEntity>> GetAll();

        Task<IEnumerable<TGenericEntity>> SearchMatching(Expression<Func<TGenericEntity, bool>> predicate, int? skipRecords = 0, int? takeRecords = 0);

        Task<IEnumerable<TGenericEntity>> SearchMatchingOrderBy<TResponseOrderBy>(Expression<Func<TGenericEntity, TResponseOrderBy>> predicateOrderBy,
            Expression<Func<TGenericEntity, bool>> predicate, int? skipRecords = 0, int? takeRecords = 0, string? orderByType = "asc");

        Task<TGenericEntity?> FirstBySearchMatching(Expression<Func<TGenericEntity, bool>> predicate);
    }
}