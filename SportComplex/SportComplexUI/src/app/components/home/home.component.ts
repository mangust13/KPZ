import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api-service.service'; // Ваша служба

@Component({
  selector: 'app-home',
  template: `
    <h1>Home Component</h1>
    <div *ngIf="data">
      <p>{{ data }}</p>
    </div>
  `
})
export class HomeComponent implements OnInit {
  data: any;

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    // Виклик методу служби
    this.apiService.getData().subscribe(response => {
      this.data = response;
    });
  }
}
