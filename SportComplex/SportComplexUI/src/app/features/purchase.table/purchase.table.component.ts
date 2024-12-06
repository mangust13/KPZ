import { Component, OnInit } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { PurchaseService } from './services/purchase.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';  // Імпортуємо FormsModule

@Component({
  selector: 'app-purchase-table',
  standalone: true,
  imports: [NgFor, NgIf, CommonModule, FormsModule], // Додаємо FormsModule
  templateUrl: './purchase.table.component.html',
  styleUrls: ['./purchase.table.component.css']
})

export class PurchaseTableComponent implements OnInit {
  purchases: any[] = [];
  isLoading: boolean = true;
  errorMessage: string | null = null;
  newPurchase: any = { clientFullName: '', paymentMethodName: '', purchaseDate: '', purchaseNumber: '', subscriptionId: null };
  showAddForm: boolean = false; // Змінна для контролю видимості форми
  showEditForm: boolean = false; // Змінна для контролю видимості форми редагування
  selectedPurchase: any = { clientFullName: '', paymentMethodName: '', purchaseDate: '', purchaseNumber: '', subscriptionId: null };

  constructor(
    private purchaseService: PurchaseService
  ) {}

  ngOnInit(): void {
    this.loadPurchases();
  }

  loadPurchases(): void {
    this.purchaseService.getPurchases().subscribe({
      next: (data) => {
        console.log('Отримані покупки:', data);
        this.purchases = data; // Присвоюємо дані без додаткової обробки
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

  addPurchase(): void {
    if (this.newPurchase.clientFullName && this.newPurchase.paymentMethodName && 
      this.newPurchase.purchaseDate && this.newPurchase.purchaseNumber && this.newPurchase.subscriptionId) 
      {
      this.purchaseService.addPurchase(this.newPurchase).subscribe({
        next: (data) => {
          console.log('Покупка додана:', data);
          this.purchases.push(data);
          this.newPurchase = { clientFullName: '', paymentMethodName: '', 
            purchaseDate: '', purchaseNumber: '', subscriptionId: null };
          this.showAddForm = false;
        },
        error: (error) => {
          console.error('Помилка при додаванні покупки:', error);
          this.errorMessage = 'Не вдалося додати покупку.';
        }
      });
    } else {
      this.errorMessage = 'Заповніть всі поля.';
    }
  }

  onEdit(purchase: any): void {
    this.selectedPurchase = { ...purchase };
    this.showEditForm = true; // Відображаємо форму редагування
  }

  updatePurchase(): void {
    this.purchaseService.updatePurchase(this.selectedPurchase).subscribe({
      next: (data) => {
        console.log('Покупка оновлена:', data);
        this.loadPurchases()
        this.showEditForm = false; // Приховуємо форму після редагування
      },
      error: (error) => {
        console.error('Помилка при оновленні покупки:', error);
        this.errorMessage = 'Не вдалося оновити покупку.';
      }
      
    });
  }

  // Логіка для скасування редагування
  cancelEdit(): void {
    this.showEditForm = false; // Приховуємо форму без збереження змін
  }

  onDelete(purchaseId: number): void {
    this.purchaseService.deletePurchase(purchaseId).subscribe({
      next: () => {
        console.log('Покупка видалена');
        this.purchases = this.purchases.filter(purchase => purchase.id !== purchaseId);
      },
      error: (error) => {
        console.error('Помилка при видаленні покупки:', error);
        this.errorMessage = 'Не вдалося видалити покупку.';
      }
    });
  }
}
