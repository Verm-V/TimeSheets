using TimeSheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Data
{
	/// <summary>
	/// Статическая коллекция содержащая сгенерированные данные для задания
	/// </summary>
	public static class GeneratedData
	{
		/// <summary>Список содержащий набор карточек учета времени</summary>
		public static List<Sheet> sheets = new List<Sheet>() 
		{
			new Sheet() { Id = Guid.Parse("F5FFBF88-D24F-8268-36DA-18D426B51736"), Date = DateTime.Parse("2022-02-20T01:12:16-08:00"), EmployeeId = Guid.Parse("4C2CDEB2-4E3E-9C4C-907D-5715F8E2A3B4"), ContractId = Guid.Parse("FE200E47-7EAB-4177-548B-0806B5BEA8D8"), ServiceId = Guid.Parse("11C627F4-2D9C-1871-CDC5-D1B4C91EB419"), Amount = 10 },
			new Sheet() { Id = Guid.Parse("EB4BAB0B-407D-5818-1AF9-C2D21FF7AC49"), Date = DateTime.Parse("2021-05-03T15:51:26-07:00"), EmployeeId = Guid.Parse("9085606E-F374-684D-E759-E57DAEC055B8"), ContractId = Guid.Parse("6CF97DE9-A2B8-EA37-D6DA-8E0FE8D45AEC"), ServiceId = Guid.Parse("B9CFEB19-4E65-2D92-04A0-E4CBDEFE8EB1"), Amount = 5 },
			new Sheet() { Id = Guid.Parse("25874A01-34CF-107B-25A9-2E53075B1561"), Date = DateTime.Parse("2022-02-25T12:40:08-08:00"), EmployeeId = Guid.Parse("9AA588C2-1223-3451-C20F-9A89905E61F2"), ContractId = Guid.Parse("BE4277E8-1496-C60D-2AC2-4D498E0C0A1C"), ServiceId = Guid.Parse("92C98DB5-BBB3-A387-FFCA-B5F79268A591"), Amount = 4 },
			new Sheet() { Id = Guid.Parse("50E7171D-F908-7385-ED53-1516FD562118"), Date = DateTime.Parse("2021-11-28T00:45:27-08:00"), EmployeeId = Guid.Parse("B2094095-FC24-029B-D3DD-D2A0C7791C3A"), ContractId = Guid.Parse("0FE097CF-3672-8A48-97E8-0FF66703713D"), ServiceId = Guid.Parse("2A357E8D-F898-EF5E-9024-CFDBFA09CFDA"), Amount = 1 },
			new Sheet() { Id = Guid.Parse("A17EB741-B181-4C48-F9FA-72E03E5631B3"), Date = DateTime.Parse("2020-11-15T23:25:15-08:00"), EmployeeId = Guid.Parse("7B8A1872-AD94-D830-AC34-EA48FCE1168E"), ContractId = Guid.Parse("382336CC-DF78-28E3-0AA8-7E1DD5BACD80"), ServiceId = Guid.Parse("CC54B223-848F-4F22-A184-5BA0D7BE6B4D"), Amount = 10 },
			new Sheet() { Id = Guid.Parse("8B5D3D32-A1B4-42EA-E146-2EA020D704A1"), Date = DateTime.Parse("2021-06-16T11:01:36-07:00"), EmployeeId = Guid.Parse("ADF5AD90-C1C6-1A07-18F1-B5D681A1A113"), ContractId = Guid.Parse("7E476614-6A2E-167B-2E6A-B3FED5BD6183"), ServiceId = Guid.Parse("14D05294-DF68-7825-5DDC-3DA82642C7A8"), Amount = 10 },
			new Sheet() { Id = Guid.Parse("08EC3228-07D9-9391-DE47-B3580388B9C3"), Date = DateTime.Parse("2021-07-20T19:47:17-07:00"), EmployeeId = Guid.Parse("37EDF8B0-B940-5B36-6E5B-D98E272FDAE1"), ContractId = Guid.Parse("6DCCC417-C4AF-9A24-1C89-D57AF6858CFD"), ServiceId = Guid.Parse("5C69A2D4-F0FD-0940-0DE5-D7AAF54A9615"), Amount = 1 },
			new Sheet() { Id = Guid.Parse("0E09EC3B-A588-71A6-703D-075781F867C4"), Date = DateTime.Parse("2020-06-07T03:33:44-07:00"), EmployeeId = Guid.Parse("CBB5C253-BD26-C5DA-17DE-743E329C1F5B"), ContractId = Guid.Parse("4585137A-601F-06D3-542C-8BBABDC02C20"), ServiceId = Guid.Parse("6F369075-3DAC-F41E-AA78-7B4269D61152"), Amount = 10 },
			new Sheet() { Id = Guid.Parse("05FCA9B4-BB1F-D1A5-7973-760BCE889E61"), Date = DateTime.Parse("2022-01-14T00:33:42-08:00"), EmployeeId = Guid.Parse("E56517BC-45FB-83E8-8C5B-C5317713E2C8"), ContractId = Guid.Parse("B28C74F4-9987-8B5A-E87F-FF45D2CA0E6B"), ServiceId = Guid.Parse("B0480122-C18D-754E-C34E-754CF8A1B257"), Amount = 1 },
			new Sheet() { Id = Guid.Parse("51FA804E-6D54-84A3-399E-788D43B208A9"), Date = DateTime.Parse("2022-02-16T21:20:37-08:00"), EmployeeId = Guid.Parse("EB6F4421-CA31-F552-0A07-01D8B27F59D4"), ContractId = Guid.Parse("C31FE6BB-8D92-4222-D464-50473A4243C7"), ServiceId = Guid.Parse("1EFA22D0-1F12-DAF2-84B5-D874E32E5351"), Amount = 7 },
			new Sheet() { Id = Guid.Parse("0D126B41-5AED-B47E-FDA9-E6EC3E2E984C"), Date = DateTime.Parse("2021-12-20T23:39:24-08:00"), EmployeeId = Guid.Parse("B9102496-3F73-AF82-C2D0-CDCD5DDA8DB7"), ContractId = Guid.Parse("214A6D3D-D1F1-D993-D660-25B5FEAE65D4"), ServiceId = Guid.Parse("C3536C4D-66A9-596C-061B-6B3B5BE83726"), Amount = 10 },
		};
	}
}
