using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models.Entities;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Domain.Interfaces
{
	public interface IInvoiceManager : IBaseManager<InvoiceAggregate, InvoiceCreateRequest>
	{
	}
}
