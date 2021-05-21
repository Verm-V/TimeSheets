using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
	/// <summary>Информация о контракте с клиентом</summary>
	public class Contract
	{
		/// <summary>Id контракта</summary>
		public Guid Id { get; set; }
		/// <summary>Наименование контракта</summary>
		public string Title { get; set; }
		/// <summary>Дата начала контракта</summary>
		public DateTime DateStart { get; set; }
		/// <summary>Дата окончания контракта</summary>
		public DateTime DateEnd { get; set; }
		/// <summary>Описание контракта</summary>
		public string Description { get; set; }
		/// <summary>Услуги предоставляемые в рамках контракта</summary>
		public List<Service> Services { get; set; }
	}
}
