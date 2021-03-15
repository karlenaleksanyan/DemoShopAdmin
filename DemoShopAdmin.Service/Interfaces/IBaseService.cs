using DemoShopAdmin.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoShopAdmin.Service.Interfaces
{
	public interface IBaseService<T> where T:BaseEntity
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetAsync(int? id);
		Task CreateAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task SaveAsync();
	}
}
