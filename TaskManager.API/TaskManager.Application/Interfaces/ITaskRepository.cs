using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(int id);
        Task DeleteAllAsync();
    }
}
