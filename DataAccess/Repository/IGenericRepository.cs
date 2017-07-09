namespace DataAccess.Repository
{
	public interface IGenericRepository<T>
	{
		T Insert(T objectToInsert);
	}
}