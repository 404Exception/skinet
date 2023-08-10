﻿using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositoies
{
    public class SpecificationEvaluator<TEntity> where TEntity : BasicEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            var query = inputQuery.AsQueryable();
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return query;
        }
    }
}
