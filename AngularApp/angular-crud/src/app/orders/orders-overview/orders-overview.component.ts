import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/shared/models/order.model';
import { AuthService } from 'src/app/shared/services/auth.service';
import { OrdersService } from 'src/app/shared/services/order.service';

@Component({
  selector: 'app-orders-overview',
  templateUrl: './orders-overview.component.html',
  styleUrls: ['./orders-overview.component.css']
})
export class OrdersOverviewComponent implements OnInit {

  orders: Order[] = [];

  constructor(private ordersService: OrdersService) { }

  ngOnInit(): void {
    this.ordersService.getOrders(AuthService.token).subscribe(orders => {
      this.orders = orders;
    });
  }

}
