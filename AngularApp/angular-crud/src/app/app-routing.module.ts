import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { OrdersOverviewComponent } from './orders/orders-overview/orders-overview.component';
import { OrderCreateComponent } from './orders/create-order/create-order.component';
import { OrderUpdateComponent } from './orders/edit-order/edit-order.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full'},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'orders', component: OrdersOverviewComponent },
  { path: 'create', component: OrderCreateComponent },
  { path: 'edit/:id', component: OrderUpdateComponent }

];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
