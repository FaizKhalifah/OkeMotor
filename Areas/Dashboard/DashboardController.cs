using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using OkeMotor.Areas.Dashboard.Service;
using OkeMotor.Models.Entities;

namespace OkeMotor.Areas.Dashboard
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var sellerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var motors = await _dashboardService.GetMotorsBySellerAsync(sellerId);
            return View(motors);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Motor motor)
        {
            if (!ModelState.IsValid) return View(motor);

            motor.SellerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _dashboardService.AddMotorAsync(motor);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var motor = await _dashboardService.GetMotorByIdAsync(id);
            if (motor == null || motor.SellerId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                return NotFound();

            return View(motor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Motor motor)
        {
            if (!ModelState.IsValid) return View(motor);

            var existingMotor = await _dashboardService.GetMotorByIdAsync(motor.Id);
            if (existingMotor == null || existingMotor.SellerId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                return NotFound();

            existingMotor.Brand = motor.Brand;
            existingMotor.Type = motor.Type;
            existingMotor.Name = motor.Name;
            existingMotor.PoliceNumber = motor.PoliceNumber;
            existingMotor.Quality = motor.Quality;
            existingMotor.Price = motor.Price;

            await _dashboardService.UpdateMotorAsync(existingMotor);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var motor = await _dashboardService.GetMotorByIdAsync(id);
            if (motor == null || motor.SellerId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                return NotFound();

            await _dashboardService.DeleteMotorAsync(id);
            return RedirectToAction("Index");
        }

    }
}
