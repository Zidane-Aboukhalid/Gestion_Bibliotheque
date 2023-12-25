using Gestion_Bibliotheque.Domain.Repository;
using Gestion_Bibliotheque.Infra.data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Gestion_Bibliotheque.Infra.Repository
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		private readonly applicationDbContext context;

		public BaseRepository(applicationDbContext context)
        {
			this.context = context;
		}

        public async Task<int> AddAsync(T t)
		{
			await context.Set<T>().AddAsync(t);
			return await context.SaveChangesAsync();
		}

		public Task<int> DeleteAsync(Guid Id, T entity)
		{
			context.Set<T>().Remove(entity);
			return context.SaveChangesAsync();
		}

		public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
		{
			return await context.Set<T>().Where(match).ToListAsync();
		}

		public async Task<T> FindAsync(Expression<Func<T, bool>> match)
		{
			return await context.Set<T>().SingleOrDefaultAsync(match);
		}

		public async Task<ICollection<T>> GetAllAsyn()
		{
			return await context.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			return await context.Set<T>().FindAsync(id);
		}

		public async Task<T> UpdateAsyn(T t, Guid Id)
		{
			if (t == null)
				return null;
			T exist = await context.Set<T>().FindAsync(Id);
			if (exist != null)
			{
				context.Entry(exist).CurrentValues.SetValues(t);
				await context.SaveChangesAsync();
			}
			return exist;
		}
	}
}
