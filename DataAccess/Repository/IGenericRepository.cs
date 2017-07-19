using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
	public interface IGenericRepository<T>
	{
		T GetById(params object[] primaryKeys);

		IQueryable<T> Get(Expression<Func<T, bool>> query);
		IQueryable<T> Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);

		T Insert(T objectToInsert);

		void Delete(params object[] primaryKeys);
		void Delete(T objectToDelete);
	}
}