import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Task {
  id: number;
  title: string;
  description: string;
  status: string;
  createdAt: string;
}


@Injectable({
  providedIn: 'root',
})
export class TaskService {

  private apiUrl = 'https://localhost:5001/api/tasks';

  constructor(private http: HttpClient){}

  getTasks(): Observable<Task[]> {
  return this.http.get<Task[]>(this.apiUrl);
}

  createTask(task: { title: string; description: string }): Observable<Task> {
  return this.http.post<Task>(this.apiUrl, task);
}

  deleteTask(id: number){
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  updateTask(id: number, task: any){
    return this.http.put(`${this.apiUrl}/${id}`, task);
  }

  deleteAll() {
  return this.http.delete(`${this.apiUrl}/all`);
}
}
