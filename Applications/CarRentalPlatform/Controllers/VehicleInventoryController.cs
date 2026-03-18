using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using CarRentalPlatform.Models;

namespace CarRentalPlatform.Controllers
{
	public class VehicleInventoryController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public VehicleInventoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		// Helper to get the Gateway Client (Configured in Program.cs)
		private HttpClient GetClient() => _httpClientFactory.CreateClient("ApiGateway");

		// GET: GSVehicles (List all)
		public async Task<IActionResult> Index()
		{
			var client = GetClient();
			// Path matches the YARP route: api/GSVehicles
			var vehicles = await client.GetFromJsonAsync<List<VehicleViewModel>>("api/GSVehicles");
			return View(vehicles ?? new List<VehicleViewModel>());
		}

		// GET: GSVehicles/Details/5
		public async Task<IActionResult> Details(int id)
		{
			var client = GetClient();
			var vehicle = await client.GetFromJsonAsync<VehicleViewModel>($"api/GSVehicles/{id}");

			if (vehicle == null) return NotFound();

			return View(vehicle);
		}

		// GET: GSVehicles/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: GSVehicles/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(VehicleViewModel model)
		{
			if (ModelState.IsValid)
			{
				var client = GetClient();
				// Matches POST api/GSVehicles
				var response = await client.PostAsJsonAsync("api/GSVehicles", model);

				if (response.IsSuccessStatusCode)
					return RedirectToAction(nameof(Index));
			}
			return View(model);
		}

		// GET: GSVehicles/Edit/5 (To Update Status)
		public async Task<IActionResult> Edit(int id)
		{
			var client = GetClient();
			var vehicle = await client.GetFromJsonAsync<VehicleViewModel>($"api/GSVehicles/{id}");
			if (vehicle == null) return NotFound();
			return View(vehicle);
		}

		// POST: GSVehicles/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, string newStatus)
		{
			var client = GetClient();
			// Matches PUT api/GSVehicles/{id}/status
			// We pass the status in the body as your backend API expects
			var response = await client.PutAsJsonAsync($"api/GSVehicles/{id}/status", newStatus);

			if (response.IsSuccessStatusCode)
				return RedirectToAction(nameof(Index));

			return View();
		}

		// GET: GSVehicles/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			var client = GetClient();
			var vehicle = await client.GetFromJsonAsync<VehicleViewModel>($"api/GSVehicles/{id}");
			if (vehicle == null) return NotFound();
			return View(vehicle);
		}

		// POST: GSVehicles/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var client = GetClient();
			await client.DeleteAsync($"api/GSVehicles/{id}");
			return RedirectToAction(nameof(Index));
		}
	}
}