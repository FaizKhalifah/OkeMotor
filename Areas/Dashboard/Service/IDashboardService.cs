﻿using OkeMotor.Models.Entities;

namespace OkeMotor.Areas.Dashboard.Service
{
    public interface IDashboardService
    {
        Task<List<Motor>> GetMotorsBySellerAsync(string sellerId);
        Task<Motor> GetMotorByIdAsync(Guid id);
        Task AddMotorAsync(Motor motor);
        Task UpdateMotorAsync(Motor motor);
        Task DeleteMotorAsync(Guid id);
    }
}
