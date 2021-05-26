using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
	public class EmployeeManager : IEmployeeManager
	{
		private readonly IEmployeeRepo _repo;

		public EmployeeManager(IEmployeeRepo repo)
		{
			_repo = repo;
		}

		public async Task<Employee> GetItem(Guid id)
		{
			return await _repo.GetItem(id);
		}

		public async Task<IEnumerable<Employee>> GetItems()
		{
			return await _repo.GetItems();
		}

		public async Task<Guid> Create(EmployeeRequest request)
		{
			var Employee = new Employee()
			{
				Id = Guid.NewGuid(),
				UserId = request.UserId,
				IsDeleted = false,
			};

			await _repo.Add(Employee);

			return Employee.Id;
		}

		public async Task Update(Guid id, EmployeeRequest request)
		{
			var item = await _repo.GetItem(id);
			if (item != null)
			{
				item.UserId = request.UserId;

				await _repo.Update(item);
			}
		}

		public async Task<bool> CheckEmployeeIsDeleted(Guid id)
		{
			return await _repo.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _repo.Delete(id);
		}
	}
}
