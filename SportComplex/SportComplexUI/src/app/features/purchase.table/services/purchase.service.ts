import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class PurchaseService {
  private apiUrl = 'https://localhost:5252/api/Purchases';

  constructor(private http: HttpClient) {}

  getPurchases(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  addPurchase(client: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, client);
  }

  updatePurchase(client: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${client.id}`, client);
  }

  deletePurchase(clientId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${clientId}`);
  }
}