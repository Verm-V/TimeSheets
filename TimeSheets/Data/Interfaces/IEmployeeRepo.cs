using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Interfaces
{
	public interface IEmployeeRepo : IRepoBase<EmployeeAggregate>
	{
	}
}
