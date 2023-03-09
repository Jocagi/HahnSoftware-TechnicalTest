import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Order } from 'src/app/shared/models/order.model';
import { OrdersService } from 'src/app/shared/services/order.service';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {

  order: Order = new Order();
  isLoading = false;

  constructor(
    private ordersService: OrdersService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    const id = this.route.snapshot.paramMap.get('id');
    if (id === null) {
        console.log('No id found');
        return;
    }
    this.ordersService.getOrderById(id, AuthService.token).subscribe(order => {
      this.order = order;
      this.isLoading = false;
    });
  }

}
