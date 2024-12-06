import { Component, NgModule, OnInit } from '@angular/core';
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { ContractService } from '../contract.table/services/contract.service';

@Component({
  selector: 'app-contract-table',
  standalone: true,
  imports: [NgFor, NgIf, CommonModule],
  templateUrl: './contract.table.component.html',
  styleUrls: ['./contract.table.component.css']
})
export class ContractTableComponent implements OnInit {
  contracts: any[] = [];
  isLoading: boolean = true;
  errorMessage: string | null = null;

  constructor(private contractService: ContractService) {}

  ngOnInit(): void {
    this.loadContracts();
  }

  loadContracts(): void {
    this.contractService.getContracts().subscribe({
      next: (data) => {
        this.contracts = data; // Отримані розпаковані дані
        this.isLoading = false;
      },
      error: (error) => {
        this.errorMessage = 'Помилка завантаження даних.';
        this.isLoading = false;
      }
    });
  }

  // Логіка для додавання нового контракту
  onAdd(): void {
    console.log('Додати контракт');
  }

  // Логіка для редагування контракту
  onEdit(contract: any): void {
    console.log('Редагувати контракт:', contract);
  }

  // Логіка для видалення контракту
  onDelete(contractId: number): void {
    console.log('Видалення контракту з ID:', contractId);
    this.contracts = this.contracts.filter(contract => contract.contractId !== contractId);
  }
}
@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule, // Загальний модуль
        //SharedModule // Імпортуємо SharedModule для пайпи
    ]
})
export class ClientTableModule {
}

