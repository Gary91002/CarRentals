using Maintenance.WebAPI.Models;

namespace Maintenance.WebAPI.Services
{
	public class FakeRepairHistoryService : IRepairHistoryService
	{
		public List<RepairHistoryDto> GetByVehicleId(int vehicleId)
		{
			return new List<RepairHistoryDto>
			{
				new RepairHistoryDto
				{
					Id = 1,
					VehicleId = vehicleId,
					RepairDate = DateTime.Now.AddDays(-10),
					Description = "Oil change and filter replacement",
					Cost = 79.99m,
					PerformedBy = "John's Auto Shop"
				},
				new RepairHistoryDto
				{
					Id = 2,
					VehicleId = vehicleId,
					RepairDate = DateTime.Now.AddDays(-40),
					Description = "Brake pad replacement",
					Cost = 199.99m,
					PerformedBy = "Speedy Repairs"
				},
				new RepairHistoryDto
				{
					Id = 3,
					VehicleId = vehicleId,
					RepairDate = DateTime.Now.AddDays(-90),
					Description = "Tire rotation and balance",
					Cost = 49.99m,
					PerformedBy = "Tire World"
				}
			};
		}
	}

}
