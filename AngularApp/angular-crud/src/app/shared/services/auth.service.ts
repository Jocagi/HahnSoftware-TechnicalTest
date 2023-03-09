import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Login, Register } from '../models/auth.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = 'http://localhost:5199/auth';
  public static token: string = '';

  constructor(private http: HttpClient) { }

  login(login: Login): Observable<any> {
    
    var request = this.http.post<any>(`${this.baseUrl}/login`, login);
    request.subscribe(response => {
      AuthService.token = response.token;
    });

    return request; 

  }

  register(register: Register): Observable<any> {
    var request = this.http.post<any>(`${this.baseUrl}/register`, register);
    request.subscribe(response => {
      AuthService.token = response.token;
    }
    );
    return request;
  }

  isAuthenticated() {
    if (AuthService.token === '') {
      return false;
    }
    return true;
  }
}
