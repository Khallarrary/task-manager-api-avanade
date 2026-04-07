import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskService, Task } from './services/task.service';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class AppComponent implements OnInit {
  
  tasks: Task[] = []

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  newTask = {
    title: '',
    description: ''
  };

  createTask(form: any) {
  if (form.invalid) return;

  this.taskService.createTask(this.newTask).subscribe({
    next: (res: Task) => {
      console.log('SUCESSO:', res);

      this.tasks = [...this.tasks, res];

      form.resetForm(); // limpa o form corretamente
    },
    error: (err) => {
      console.error('Erro ao criar:', err);
    }
  });
}


  loadTasks(){
  this.taskService.getTasks().subscribe({
    next: (data: Task[]) => {
      console.log('GET OK:', data);
      this.tasks = data;
    },
    error: (err) => {
      console.error('ERRO NO GET:', err);
    }
  });
}
  
  deleteTask(id: number){
    this.taskService.deleteTask(id).subscribe(() => {
      this.loadTasks();
    })
  }

  updateStatus(task: Task, status: string){
  const update = { 
    title: task.title, 
    description: task.description, 
    status: status
  };

  this.taskService.updateTask(task.id, update).subscribe({
    next: () => {

      
      this.tasks = this.tasks.map(t =>
        t.id === task.id ? { ...t, status } : t
      );

    },
    error: (err) => {
      console.error('Erro ao atualizar:', err);
    }
  });
}

  filterStatus: string = '';

  get filteredTasks(): Task[] {
    if (!this.filterStatus) return this.tasks;
    return this.tasks.filter(t => t.status === this.filterStatus);
  }
  
  deleteAll(){
  this.taskService.deleteAll().subscribe(() => {
    this.tasks = [];
  });
}
  
  
}
  
