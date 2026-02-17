using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain.Enums;

namespace VehicleInventory.Domain.VehicleAggregate
{
	public class Vehicle
	{
		public int id { get; set; }
		public string VehicleCode { get; set; } = string.Empty;
		public int LocationId { get; set; }
		public VehicleType VehicleType { get; set; }
		public VehicleStatus VehicleStatus { get; set; }

		public Vehicle(int id, string vehicleCode, int locationId, VehicleType vehicleType, VehicleStatus vehicleStatus)
		{
			this.id = id;
			this.VehicleCode = vehicleCode;
			this.LocationId = locationId;
			this.VehicleType = vehicleType;
			this.VehicleStatus = vehicleStatus;
		}


	}
}
