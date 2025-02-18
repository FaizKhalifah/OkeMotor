using Microsoft.EntityFrameworkCore;
using OkeMotor.Data;
using OkeMotor.Models.Entities;

namespace OkeMotor.Areas.Dashboard.Service
{
    public class DashboardService:IDashboardService
    {
        private readonly ApplicationDbContext _context;
        public DashboardService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<List<Motor>> GetMotorsBySellerAsync(string sellerId)
        {
            return await _context.motors.Where(m => m.SellerId == sellerId).ToListAsync();
        }

        public async Task<Motor> GetMotorByIdAsync(Guid id)
        {
            return await _context.motors.FindAsync(id);
        }

        public async Task AddMotorAsync(Motor motor)
        {
            _context.motors.Add(motor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMotorAsync(Motor motor)
        {
            _context.motors.Update(motor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMotorAsync(Guid id)
        {
            var motor = await _context.motors.FindAsync(id);
            if (motor != null)
            {
                _context.motors.Remove(motor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
