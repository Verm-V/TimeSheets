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
		private readonly IInvoiceRepo _invoiceRepo;
		private readonly ISheetRepo _sheetRepo;

		/// <summary>Часовая ставка</summary>
		private const int payRate = 100;

		public InvoiceManager(IInvoiceRepo invoceRepo, ISheetRepo sheetRepo)
		{
			_invoiceRepo = invoceRepo;
			_sheetRepo = sheetRepo;
		}
		
		public async Task<Invoice> GetItem(Guid id)
		{
			return await _invoiceRepo.GetItem(id);
		}

		public async Task<IEnumerable<Invoice>> GetItems()
		{
			return await _invoiceRepo.GetItems();
		}

		public async Task<Guid> Create(InvoiceCreateRequest request)
		{
			var invoice = new Invoice()
			{
				Id = Guid.NewGuid(),
				ContractId = request.ContractId,
				DateStart = request.DateStart,
				DateEnd = request.DateEnd,
			};

			//Устанавливаем список карточек связанных со счетом и рассчитываем сумму
			var sheets = await _sheetRepo.GetItemsForInvoice(
				request.ContractId,
				request.DateStart,
				request.DateEnd);

			invoice.Sheets.AddRange(sheets);
			invoice.Sum = invoice.Sheets.Sum(x => x.Amount * payRate);

			await _invoiceRepo.Add(invoice);

			return invoice.Id;
		}

		public async Task<bool> CheckInvoiceIsDeleted(Guid id)
		{
			return await _invoiceRepo.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _invoiceRepo.Delete(id);
		}
	}
}
