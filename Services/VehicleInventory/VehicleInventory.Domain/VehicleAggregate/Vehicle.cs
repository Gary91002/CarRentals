using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain.Enums;
using VehicleInventory.Domain.Exceptions;

namespace VehicleInventory.Domain.VehicleAggregate
{
	public class Vehicle
	{
		public int Id { get; set; }
		public string VehicleCode { get; set; } = string.Empty;
		public int LocationId { get; set; }
		public VehicleType VehicleType { get; set; }
		public VehicleStatus VehicleStatus { get; set; }

		public Vehicle(int Id, string vehicleCode, int locationId, VehicleType vehicleType, VehicleStatus vehicleStatus)
		{
			this.Id = Id;
			this.VehicleCode = vehicleCode;
			this.LocationId = locationId;
			this.VehicleType = vehicleType;
			this.VehicleStatus = vehicleStatus;
		}

		public void MarkAvailable()
		{
			if (this.VehicleStatus == VehicleStatus.Reserved)
			{
				throw new InvalidVehicleStatusChangeException("Cannot mark a reserved vehicle as available.");
			}
			else
			{
				this.VehicleStatus = VehicleStatus.Available;
			}

		}

		public void MarkRented()
		{
			if (this.VehicleStatus == VehicleStatus.Rented)
			{
				throw new InvalidVehicleStatusChangeException("Vehicle is already rented.");
			}

			if (this.VehicleStatus == VehicleStatus.Reserved)
			{
				throw new InvalidVehicleStatusChangeException("Cannot mark a reserved vehicle as rented.");
			}

			if (this.VehicleStatus == VehicleStatus.Maintenance)
			{
				throw new InvalidVehicleStatusChangeException("Cannot mark a vehicle under maintenance as rented.");
			}

			this.VehicleStatus = VehicleStatus.Rented;

		}

		public void MarkReserved()
		{
			if (this.VehicleStatus == VehicleStatus.Rented)
			{
				throw new InvalidVehicleStatusChangeException("Cannot mark a rented vehicle as reserved.");
			}
			if (this.VehicleStatus == VehicleStatus.Maintenance)
			{
				throw new InvalidVehicleStatusChangeException("Cannot mark a vehicle under maintenance as reserved.");
			}
			if (this.VehicleStatus == VehicleStatus.Reserved)
			{
				throw new InvalidVehicleStatusChangeException("Vehicle is already reserved.");
			}
			this.VehicleStatus = VehicleStatus.Reserved;
		}

		public void MarkServiced()
		{
			if (this.VehicleStatus == VehicleStatus.Rented)
			{
				throw new InvalidVehicleStatusChangeException("Cannot mark a rented vehicle as under maintenance.");
			}
			if (this.VehicleStatus == VehicleStatus.Reserved)
			{
				throw new InvalidVehicleStatusChangeException("Cannot mark a reserved vehicle as under maintenance.");
			}
			this.VehicleStatus = VehicleStatus.Maintenance;
		}




	}
}
