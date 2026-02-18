using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Application.DTOs;
using VehicleInventory.Application.Interfaces;
using VehicleInventory.Domain.Enums;
using VehicleInventory.Domain.VehicleAggregate;

namespace VehicleInventory.Application.Services
{
	public class GSCreateVehicle
	{
		public IVehicleRepository _vehicleRepository;

		public GSCreateVehicle(IVehicleRepository vehicleRepository)
		{
			_vehicleRepository = vehicleRepository;
		}

		public async Task CreateVehicle(GSCreateVehicleDto dto)
		{

			var vehicle = new GSVehicle
			(
				dto.VehicleCode,
				dto.LocationId,
				dto.VehicleType,
				dto.VehicleStatus
			);

			await _vehicleRepository.Add(vehicle);
			await _vehicleRepository.SaveChanges();
		}

	}
}
