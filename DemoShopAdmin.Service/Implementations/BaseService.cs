using DemoShopAdmin.Model.Models;
using DemoShopAdmin.Service.Data;
using DemoShopAdmin.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShopAdmin.Service.Implementations
{
	public class BaseService<T> : IBaseService<T> where T : BaseEntity
	{
		protected readonly DemoShopAdminContext _context;
		private readonly DbSet<T> _entity;

		public BaseService(DemoShopAdminContext context)
		{
			_context = context;
			_entity = _context.Set<T>();
		}

		public virtual async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _entity.ToListAsync();
		}
		public virtual async Task<T> GetAsync(int? id)
		{
			return await _entity.FirstOrDefaultAsync(x => x.Id == id);
		}

		public virtual async Task CreateAsync(T entity)
		{
			if (entity == null)
				throw new NotImplementedException();
			await _entity.AddAsync(entity);
			await SaveAsync();
		}

		public virtual async Task DeleteAsync(T entity)
		{
			if (entity == null)
				throw new NotImplementedException();
			_entity.Remove(entity);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		public virtual async Task UpdateAsync(T entity)
		{
			if (entity == null)
				throw new NotImplementedException();
			_entity.Update(entity);
			await SaveAsync();
		}
	}
}
