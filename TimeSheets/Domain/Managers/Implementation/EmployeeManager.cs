﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Entities;
using TimeSheets.Models.Dto.Requests;
using System.Diagnostics.CodeAnalysis;

namespace TimeSheets.Domain.Implementation
{
	[ExcludeFromCodeCoverage]
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

		public async Task<Guid> Create(EmployeeCreateRequest request)
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