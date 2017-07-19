using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
	public class GenericPressfordRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly DbSet<T> _dbSet;

		public GenericPressfordRepository(PressfordDbContext context)
		{
			_dbSet = context.Set<T>();
		}

		public T GetById(params object[] primaryKeys)
		{
			return _dbSet.Find(primaryKeys);
		}

		public IQueryable<T> Get(Expression<Func<T, bool>> filter)
		{
			return Get(filter, null);
		}

		public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
		{
			var query = _dbSet.AsQueryable();

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (includeProperties != null && includeProperties.Any())
			{
				foreach (var includeProperty in includeProperties)
				{
					query = query.Include(includeProperty);
				}
			}

			return query;
		}

		public T Insert(T objectToInsert)
		{
			_dbSet.Add(objectToInsert);

			return objectToInsert;
		}

		public void Delete(params object[] primaryKeys)
		{
			var itemToDelete = GetById(primaryKeys);

			_dbSet.Remove(itemToDelete);
		}

		public void Delete(T itemToBeRemoved)
		{
			_dbSet.Remove(itemToBeRemoved);			
		}
	}
}