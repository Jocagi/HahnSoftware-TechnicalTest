import { Component, Inject } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth.service';
import { OrdersService } from 'src/app/shared/services/order.service';

@Component({
  selector: 'app-delete-order',
  templateUrl: './delete-order.component.html',
  styleUrls: ['./delete-order.component.css']
})
export class DeleteOrderComponent {
  constructor( public orderId: string,
    private ordersService: OrdersService
  ) { }

  onConfirmDelete(): void {
    this.ordersService.deleteOrder(this.orderId, AuthService.token)
      .subscribe(() => {
        console.log(`Deleted order with id: ${this.orderId}`);
      });
  }
}
