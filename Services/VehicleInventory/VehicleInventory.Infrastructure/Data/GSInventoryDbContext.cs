using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain.VehicleAggregate;

namespace VehicleInventory.Infrastructure.Data
{
	public class GSInventoryDbContext : DbContext
	{
		public GSInventoryDbContext(DbContextOptions<GSInventoryDbContext> options) : base(options)
		{
		}
		public DbSet<GSVehicle> Vehicles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<GSVehicle>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.VehicleCode).IsRequired().HasMaxLength(50);
				entity.Property(e => e.LocationId).IsRequired();
				entity.Property(e => e.VehicleType).IsRequired();
				entity.Property(e => e.VehicleStatus).IsRequired();
			});
		}
	}
}
