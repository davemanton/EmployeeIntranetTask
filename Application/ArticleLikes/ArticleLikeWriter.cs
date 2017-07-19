using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Application.Employees;
using DataAccess.Repository;
using DataAccess.Security.Migrations;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Application.ArticleLikes
{
	public class ArticleLikeWriter : IWriteArticleLikes
	{
		private readonly IReadEmployees _employeeReader;
		private readonly IGenericRepository<ArticleLike> _articleLikeRepo;
		private readonly IUnitOfWork _uow;

		public ArticleLikeWriter(
			IReadEmployees employeeReader,
			IGenericRepository<ArticleLike> articleLikeRepo, 
			IUnitOfWork uow
			)
		{
			_articleLikeRepo = articleLikeRepo;
			_uow = uow;
			_employeeReader = employeeReader;
		}

		public void Toggle(int articleId, string username)
		{
			var employee = _employeeReader.GetByUsername(username, true);
			
			var articleLike = _articleLikeRepo.Get(x => x.ArticleId == articleId && x.EmployeeId == employee.EmployeeId).SingleOrDefault();

			if (articleLike == null)
			{
				var now = DateTime.UtcNow;
				var employeeLikesThisMonth = employee.ArticleLikes.Count(x => x.CreatedDate > new DateTime(now.Year, now.Month, 1));

				if (employeeLikesThisMonth < employee.MaxLikesPerMonth)
					Create(articleId, employee.EmployeeId);
			}
			else
			{
				Delete(articleLike);						
			}
		}

		private void Create(int articleId, int employeeId)
		{
			var articleLike = new ArticleLike(articleId, employeeId);
			_articleLikeRepo.Insert(articleLike);
			_uow.Save();
		}

		private void Delete(ArticleLike articleLike)
		{
			_articleLikeRepo.Delete(articleLike);
			_uow.Save();
		}
	}
}