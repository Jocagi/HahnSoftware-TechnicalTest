import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CreateOrder, Order } from 'src/app/shared/models/order.model';
import { AuthService } from 'src/app/shared/services/auth.service';
import { OrdersService } from 'src/app/shared/services/order.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class OrderCreateComponent implements OnInit {

  order: CreateOrder = new CreateOrder();

  constructor(
    private ordersService: OrdersService,
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  returnToOrdersOverview(): void {
    this.router.navigateByUrl('/orders');
  }

  createOrder(form: NgForm): void {
    if (form.valid) {
      //Add order, alert error if any
      console.log('OrderCreateComponent.createOrder(): this.order:', this.order);
      console.log('OrderCreateComponent.createOrder(): AuthService.token:', AuthService.token);

      this.ordersService.addOrder(this.order, AuthService.token).subscribe(order => {
        console.log(`Created order`);
        alert(`Created order`);
        //Navigate to orders overview
        this.router.navigateByUrl('/orders');
      }); 
    }
  }

}
