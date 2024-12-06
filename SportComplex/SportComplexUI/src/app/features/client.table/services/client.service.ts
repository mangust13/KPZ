import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ClientService {
  private apiUrl = 'https://localhost:5252/api/Clients'; // Замініть на ваш API URL

  constructor(private http: HttpClient) {}

  getClients(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  // Додавання нового клієнта
  addClient(client: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, client);
  }

  // Оновлення клієнта
  updateClient(client: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${client.id}`, client);
  }

  // Видалення клієнта
  deleteClient(clientId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${clientId}`);
  }
}