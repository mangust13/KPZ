import { Routes } from '@angular/router';

export const routes: Routes = [{
    path:"clients",
    loadComponent: () => import('./features/client.table/client.table.component').then(
        (c)=> c.ClientTableComponent
    ),
},
{
    path:"purchases",
    loadComponent: () => import('./features/purchase.table/purchase.table.component').then(
        (c) => c.PurchaseTableComponent
    ),
},
{
    path:"contracts",
    loadComponent: () => import('./features/contract.table/contract.table.component').then(
        (c)=> c.ContractTableComponent
    ),
},
];
