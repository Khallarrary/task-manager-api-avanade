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

        // Cria uma nova tarefa com status inicial "Pendente"
        // Retorna o Id gerado após persistência no banco
        public async Task<int> CreateAsync(string title, string description)
        {
            var task = new TaskItem(title, description);

            await _repository.AddAsync(task);

            return task.Id;
        }

        // Atualiza uma tarefa existente
        // Retorna false caso a tarefa não exista
        public async Task<bool> UpdateAsync(int id, string title, string description, string status)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task == null)
                return false;

            task.Update(title, description, status);

            await _repository.UpdateAsync(task);

            return true;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task == null)
                return false;

            await _repository.DeleteAsync(id);

            return true;    
        }
    }
}
