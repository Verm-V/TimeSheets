using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Domain.ValueObjects;
using TimeSheets.Models.Entities;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Domain.Implementation
{
	public class InvoiceManager : IInvoiceManager
	{
		private readonly IInvoiceRepo _invoiceRepo;

		public InvoiceManager(IInvoiceRepo invoceRepo)
		{
			_invoiceRepo = invoceRepo;
		}
		
		public async Task<InvoiceAggregate> GetItem(Guid id)
		{
			return await _invoiceRepo.GetItem(id);
		}

		public async Task<IEnumerable<InvoiceAggregate>> GetItems()
		{
			return await _invoiceRepo.GetItems();
		}

		public async Task<Guid> Create(InvoiceCreateRequest request)
		{
			//Создаем новую сущность счета
			var invoice = InvoiceAggregate.Create(
				request.ContractId,
				request.DateStart,
				request.DateEnd);

			//Устанавливаем список карточек связанных со счетом и рассчитываем сумму
			var sheets = await _invoiceRepo.GetSheets(
				request.ContractId,
				request.DateStart,
				request.DateEnd);

			//Добавляем карточки к счету и рассчитываем сумму оплаты
			invoice.IncludeSheets(sheets);

			//Закидываем новый счет в базу
			await _invoiceRepo.Add(invoice);

			return invoice.Id;
		}
		public async Task Delete(Guid id)
		{
			await _invoiceRepo.Delete(id);
		}
	}
}
