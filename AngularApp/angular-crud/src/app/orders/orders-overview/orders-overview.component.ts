import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/shared/models/order.model';
import { AuthService } from 'src/app/shared/services/auth.service';
import { OrdersService } from 'src/app/shared/services/order.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-orders-overview',
  templateUrl: './orders-overview.component.html',
  styleUrls: ['./orders-overview.component.css']
})
export class OrdersOverviewComponent implements OnInit {

  orders: Order[] = [];
  filteredOrders: Order[] = [];
  searchText = '';

  constructor(
    private ordersService: OrdersService,
    private router: Router) { }

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders(): void {
    var request = this.ordersService.getOrders(AuthService.token).subscribe(orders => {
      this.orders = orders;
      this.applyFilters();
    });
    console.log('OrdersOverviewComponent.ngOnInit(): request:', request);
  }

  logout() {
    this.router.navigateByUrl('/login');
  }

  applyFilters(): void {
    this.filteredOrders = this.orders.filter(order => 
      order.customerName.toLowerCase().includes(this.searchText.toLowerCase()));
  }

  clearFilters(): void {
    this.searchText = '';
    this.applyFilters();
  }

  editOrder(order: Order): void {
    // TODO: Implement edit functionality
  }

  deleteOrder(order: Order): void {
    // TODO: Implement delete functionality
  }

  createOrder(): void {
    this.router.navigateByUrl('/create');
  }

}
