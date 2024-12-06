import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContractService {
  private apiUrl = 'https://localhost:5252/api/Contracts'; // Замініть на ваш API URL

  constructor(private http: HttpClient) {}

  getContracts(): Observable<any[]> {
    return this.http.get<{ $id: string; $values: any[] }>(this.apiUrl).pipe(
      map(response => response.$values) // Розпаковуємо поле $values
    );
  }
}
