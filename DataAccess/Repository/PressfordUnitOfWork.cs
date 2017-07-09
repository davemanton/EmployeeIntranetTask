using DataAccess.Context;

namespace DataAccess.Repository
{
	public class PressfordUnitOfWork : IUnitOfWork
	{
		private readonly PressfordDbContext _context;

		public PressfordUnitOfWork(PressfordDbContext context)
		{
			_context = context;
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}