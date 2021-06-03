using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Infrastructure.Validation
{
	/// <summary>Валидатор запросов по счетам</summary>
	public class InvoiceRequestValidator : AbstractValidator<InvoiceCreateRequest>
	{
		public InvoiceRequestValidator()
		{
			RuleFor(x => x.ContractId)
				.NotEmpty();

			RuleFor(x => x.DateStart)
				.LessThanOrEqualTo(x => x.DateEnd)
				.WithMessage(ValidationsMessages.RequestDateStartError);

			RuleFor(x => x.DateEnd)
				.GreaterThanOrEqualTo(x => x.DateStart)
				.WithMessage(ValidationsMessages.RequestDateEndError);

		}
	}
}
