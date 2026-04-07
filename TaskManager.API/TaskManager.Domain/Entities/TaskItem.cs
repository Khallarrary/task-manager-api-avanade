using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Domain.Constants;

namespace TaskManager.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public TaskItem(string title, string description)
        {
            Title = title;
            Description = description;
            Status = TaskStatusConstants.Pendente;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string title, string description, string status)
        {
            Console.WriteLine($"UPDATE CHAMADO — status recebido: {status}");
            Title = title;
            Description = description;
            Status = status;
        }

        public void MarkAsCompleted()
        {
           Status = TaskStatusConstants.Concluida;
        }
    }
}
