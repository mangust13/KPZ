import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientTableComponent } from './features/client.table/client.table.component';
import { PurchaseTableComponent } from './features/purchase.table/purchase.table.component';

const routes: Routes = [
  { path: 'clients', component: ClientTableComponent },
  { path: 'purchases', component: PurchaseTableComponent },
  { path: '', redirectTo: '/clients', pathMatch: 'full' }, // Перенаправлення на "Clients" за замовчуванням
  { path: '**', redirectTo: '/clients' }, // Обробка невідомих шляхів
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
