using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
	public class PressfordDbContext : DbContext
	{
		private PressfordDbContext() { }

		public PressfordDbContext(DbContextOptions<PressfordDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Article> Articles { get; set; }
		public virtual DbSet<ArticleLike> ArticleLikes { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Article>(e =>
			{
				e.HasKey(x => x.ArticleId);

				e.Property(x => x.CreatedDate)
					.IsRequired();			
				e.Property(x => x.AuthorId)
					.IsRequired();
				e.Property(x => x.Title)
					.IsRequired()
					.HasMaxLength(255);
				e.Property(x => x.Summary)
					.IsRequired()
					.HasMaxLength(255);
				e.Property(x => x.Body)
					.IsRequired();
				e.Property(x => x.PublishedDate);

				e.HasOne(x => x.Author)
					.WithMany(x => x.Articles)
					.HasForeignKey(x => x.AuthorId);
				e.HasMany(x => x.Likes)
					.WithOne(x => x.Article);
			});

			modelBuilder.Entity<ArticleLike>(e =>
			{
				e.HasKey(x => new
				{
					x.EmployeeId,
					x.ArticleId
				});

				e.Property(x => x.EmployeeId)
					.IsRequired();
				e.Property(x => x.ArticleId)
					.IsRequired();
				e.Property(x => x.CreatedDate)
					.IsRequired();

				e.HasOne(x => x.Employee)
					.WithMany(x => x.ArticleLikes)
					.HasForeignKey(x => x.EmployeeId);
				e.HasOne(x => x.Article)
					.WithMany(x => x.Likes)
					.HasForeignKey(x => x.ArticleId);
			});

			modelBuilder.Entity<Employee>(e =>
			{
				e.HasKey(x => x.EmployeeId);

				e.Property(x => x.Username)
					.IsRequired()
					.HasMaxLength(256)
					.IsUnicode();
				e.Property(x => x.FirstName)
					.IsRequired()
					.HasMaxLength(50);
				e.Property(x => x.LastName)
					.IsRequired()
					.HasMaxLength(50);
				e.Property(x => x.MaxLikesPerMonth)
					.IsRequired()
					.HasDefaultValue(5);

				e.HasMany(x => x.Articles)
					.WithOne(x => x.Author);
				e.HasMany(x => x.ArticleLikes)
					.WithOne(x => x.Employee);
			});
		}
	}
}