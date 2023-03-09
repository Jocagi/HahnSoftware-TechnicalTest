import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Order } from 'src/app/shared/models/order.model';
import { AuthService } from 'src/app/shared/services/auth.service';
import { OrdersService } from 'src/app/shared/services/order.service';

@Component({
  selector: 'app-order-create',
  templateUrl: './order-create.component.html',
  styleUrls: ['./order-create.component.css']
})
export class OrderCreateComponent implements OnInit {

  order: Order = new Order();

  constructor(private ordersService: OrdersService) { }

  ngOnInit(): void {
  }

  createOrder(form: NgForm): void {
    if (form.valid) {
      this.ordersService.addOrder(this.order, AuthService.token).subscribe(order => {
        console.log(`Created order with id: ${order.id}`);
      });
    }
  }

}
