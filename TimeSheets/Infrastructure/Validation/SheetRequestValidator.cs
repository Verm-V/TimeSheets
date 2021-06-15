using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Infrastructure.Validation
{
	/// <summary>Валидатор запросов по карточкам</summary>
	[ExcludeFromCodeCoverage]
	public class SheetRequestValidator : AbstractValidator<SheetCreateRequest>
	{
		public SheetRequestValidator()
		{
			RuleFor(x => x.Amount)
				.InclusiveBetween(1, 8)
				.WithMessage(ValidationsMessages.SheetAmountError);

			RuleFor(x => x.ContractId)
				.NotEmpty()
				.WithMessage(ValidationsMessages.InvalidValue);

		}
	}
}
