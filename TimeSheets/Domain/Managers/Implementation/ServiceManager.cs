using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Entities;
using TimeSheets.Models.Dto.Requests;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Domain.Implementation
{
	[ExcludeFromCodeCoverage]
	public class ServiceManager : IServiceManager
	{
		private readonly IServiceRepo _repo;

		public ServiceManager(IServiceRepo repo)
		{
			_repo = repo;
		}

		public async Task<ServiceAggregate> GetItem(Guid id)
		{
			return await _repo.GetItem(id);
		}

		public async Task<IEnumerable<ServiceAggregate>> GetItems()
		{
			return await _repo.GetItems();
		}

		public async Task<Guid> Create(ServiceRequest request)
		{
			var Service = ServiceAggregate.CreateFromRequest(request);

			await _repo.Add(Service);

			return Service.Id;
		}

		public async Task Update(Guid id, ServiceRequest request)
		{
			var item = await _repo.GetItem(id);
			if (item != null)
			{
				item.UpdateFromRequest(request);
			}
		}

		public async Task<bool> CheckServiceIsDeleted(Guid id)
		{
			return await _repo.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _repo.Delete(id);
		}
	}
}
