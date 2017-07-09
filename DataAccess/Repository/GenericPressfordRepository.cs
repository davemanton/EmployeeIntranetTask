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

		public T Insert(T objectToInsert)
		{
			_dbSet.Add(objectToInsert);

			return objectToInsert;
		}
	}
}