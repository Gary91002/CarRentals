using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Application.DTOs;
using VehicleInventory.Application.Interfaces;
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

			//await _vehicleRepository.Add(vehicle);
			//await _vehicleRepository.SaveChanges();
		}

	}
}
