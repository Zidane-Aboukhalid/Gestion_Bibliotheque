using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Domain.Repository
{
	public interface IBaseRepository<T> where T : class
	{
		Task<ICollection<T>> GetAllAsyn();
		Task<T> FindAsync(Expression<Func<T, bool>> match);
		Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
		Task<T> GetByIdAsync(Guid id);
		Task<int> AddAsync(T t);
		Task<int> DeleteAsync(Guid Id,T entity);
		Task<T> UpdateAsyn(T t, Guid Id);

	}
}