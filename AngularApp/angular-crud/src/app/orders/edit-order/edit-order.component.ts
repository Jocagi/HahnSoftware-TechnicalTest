import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Order } from 'src/app/shared/models/order.model';
import { OrdersService } from 'src/app/shared/services/order.service';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-order-update',
  templateUrl: './order-update.component.html',
  styleUrls: ['./order-update.component.css']
})
export class OrderUpdateComponent implements OnInit {

  order: Order = new Order();
  
  constructor(
    private ordersService: OrdersService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id === null) {
        console.log('No id found');
        return;
    }
    this.ordersService.getOrderById(id, AuthService.token).subscribe(order => {
      this.order = order;
    });
  }

  updateOrder(form: NgForm): void {
    if (form.valid) {
      const id = this.route.snapshot.paramMap.get('id');
      if (id === null) {
          console.log('No id found');
          return;
      }
      this.ordersService.updateOrder(this.order, AuthService.token).subscribe(order => {
        console.log(`Updated order with id: ${order.id}`);
      });
    }
  }

}
