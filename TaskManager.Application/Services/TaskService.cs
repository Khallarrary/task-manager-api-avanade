using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task CreateAsync(string title, string description)
        {
            var task = new TaskItem(title, description);

            await _repository.AddAsync(task);
        }

        public async Task UpdateAsync(int id, string title, string description, string status)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task == null)
                throw new Exception("Task nao encontrada");

            task.Update(title, description, status);

            await _repository.UpdateAsync(task);

        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
