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
	public class InvoiceManager : IInvoiceManager
	{
		private readonly IInvoiceRepo _repo;

		public InvoiceManager(IInvoiceRepo repo)
		{
			_repo = repo;
		}

		public async Task<Invoice> GetItem(Guid id)
		{
			return await _repo.GetItem(id);
		}

		public async Task<IEnumerable<Invoice>> GetItems()
		{
			return await _repo.GetItems();
		}

		public async Task<Guid> Create(InvoiceRequest request)
		{
			var Invoice = new Invoice()
			{
				Id = Guid.NewGuid(),
				ContractId = request.ContractId,
				DateStart = request.DateStart,
				DateEnd = request.DateEnd,
				Sum = request.Sum,
				IsDeleted = false,
			};

			await _repo.Add(Invoice);

			return Invoice.Id;
		}

		public async Task Update(Guid id, InvoiceRequest request)
		{
			var item = await _repo.GetItem(id);
			if (item != null)
			{
				item.ContractId = request.ContractId;
				item.DateStart = request.DateStart;
				item.DateEnd = request.DateEnd;
				item.Sum = request.Sum;

				await _repo.Update(item);
			}
		}

		public async Task<bool> CheckInvoiceIsDeleted(Guid id)
		{
			return await _repo.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _repo.Delete(id);
		}
	}
}
