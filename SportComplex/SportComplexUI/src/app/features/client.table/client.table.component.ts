import { Component, OnInit } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { ClientService } from './services/client.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';  // Імпортуємо FormsModule

@Component({
  selector: 'app-client-table',
  standalone: true,
  imports: [NgFor, NgIf, CommonModule, FormsModule], // Додаємо FormsModule
  templateUrl: './client.table.component.html',
  styleUrls: ['./client.table.component.css']
})

export class ClientTableComponent implements OnInit {
  clients: any[] = [];
  isLoading: boolean = true;
  errorMessage: string | null = null;
  newClient: any = { fullName: '', gender: '', phoneNumber: ''}; // Модель для нового клієнта
  showAddForm: boolean = false; // Змінна для контролю видимості форми
  showEditForm: boolean = false; // Змінна для контролю видимості форми редагування
  selectedClient: any = { fullName: '', gender: '', phoneNumber: ''}; // Клієнт для редагування

  constructor(
    private clientService: ClientService
  ) {}

  ngOnInit(): void {
    this.loadClients();
  }

  loadClients(): void {
    this.clientService.getClients().subscribe({
      next: (data) => {
        console.log('Отримані клієнти:', data);
        this.clients = data; // Присвоюємо дані без додаткової обробки
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Помилка:', error);
        this.errorMessage = 'Помилка завантаження даних.';
        this.isLoading = false;
      }
    });
  }

  onAdd(): void {
    this.showAddForm = !this.showAddForm; // Перемикаємо видимість форми
  }

  // Логіка для додавання клієнта через форму
  addClient(): void {
    if (this.newClient.fullName && this.newClient.gender && this.newClient.phoneNumber) {
      this.clientService.addClient(this.newClient).subscribe({
        next: (data) => {
          console.log('Клієнт доданий:', data);
          this.clients.push(data); // Додаємо нового клієнта в масив
          this.newClient = { fullName: '', gender: '', phoneNumber: ''}; // Очищаємо форму
          this.showAddForm = false; // Приховуємо форму після додавання
        },
        error: (error) => {
          console.error('Помилка при додаванні клієнта:', error);
          this.errorMessage = 'Не вдалося додати клієнта.';
        }
      });
    } else {
      this.errorMessage = 'Заповніть всі поля.';
    }
  }

  // Логіка для редагування клієнта
  onEdit(client: any): void {
    this.selectedClient = { ...client }; // Копіюємо дані клієнта для редагування
    this.showEditForm = true; // Відображаємо форму редагування
  }

  // Логіка для оновлення клієнта
  updateClient(): void {
    this.clientService.updateClient(this.selectedClient).subscribe({
      next: (data) => {
        console.log('Клієнт оновлений:', data);
        this.loadClients()
        this.showEditForm = false; // Приховуємо форму після редагування
      },
      error: (error) => {
        console.error('Помилка при оновленні клієнта:', error);
        this.errorMessage = 'Не вдалося оновити клієнта.';
      }
      
    });
  }

  // Логіка для скасування редагування
  cancelEdit(): void {
    this.showEditForm = false; // Приховуємо форму без збереження змін
  }

  // Логіка для видалення клієнта
  onDelete(clientId: number): void {
    this.clientService.deleteClient(clientId).subscribe({
      next: () => {
        console.log('Клієнт видалений');
        this.clients = this.clients.filter(client => client.id !== clientId);
      },
      error: (error) => {
        console.error('Помилка при видаленні клієнта:', error);
        this.errorMessage = 'Не вдалося видалити клієнта.';
      }
    });
  }
}
