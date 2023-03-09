import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../models/order.model';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  private apiUrl = 'http://localhost:5199/orders';

  constructor(private http: HttpClient) { }

  getOrders(token: string): Observable<Order[]> {
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    console.log('OrdersService.getOrders(): token:', token);
    console.log('OrdersService.getOrders(): headers:', headers);
    return this.http.get<Order[]>(this.apiUrl, { headers });

  }

  getOrderById(id: string, token: string): Observable<Order> {
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<Order>(`${this.apiUrl}/${id}`, { headers });
  }

  addOrder(order: Order, token: string): Observable<Order> {
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post<Order>(this.apiUrl, order, { headers });
  }

  updateOrder(order: Order, token: string): Observable<Order> {
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.put<Order>(`${this.apiUrl}/${order.id}`, order, { headers });
  }

  deleteOrder(id: string, token: string): Observable<any> {
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.delete(`${this.apiUrl}/${id}`, { headers });
  }
}
