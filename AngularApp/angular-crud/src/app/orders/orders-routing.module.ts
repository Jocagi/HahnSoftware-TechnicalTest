import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OrdersComponent } from './orders.component';
import { OrderCreateComponent } from './create-order/create-order.component';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { OrderUpdateComponent } from './edit-order/edit-order.component';
import { DeleteOrderComponent } from './delete-order/delete-order.component';
import { AuthGuardService } from '../shared/services/auth-guard.service';

const routes: Routes = [
  { path: '', component: OrdersComponent, canActivate: [AuthGuardService] },
  { path: 'create', component: OrderCreateComponent, canActivate: [AuthGuardService] },
  { path: ':id', component: OrderDetailsComponent, canActivate: [AuthGuardService] },
  { path: 'edit/:id', component: OrderUpdateComponent, canActivate: [AuthGuardService] },
  { path: 'delete/:id', component: DeleteOrderComponent, canActivate: [AuthGuardService] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
