import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms'; 
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/services/auth.service';
import { Login } from 'src/app/shared/models/auth.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  exportAs: 'ngForm'
})
export class LoginComponent implements OnInit {

  login: Login = new Login('','');
  errorMessage: string = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  register() {
    this.router.navigateByUrl('/register');
  }

  submitLogin(form: NgForm): void {
    if (form.valid) {
      this.login = {
        email: form.value.email,
        password: form.value.password
      };
      this.authService.login(this.login).subscribe(
        (response: { token: any; }) => {
          console.log(`Successfully logged in with token: ${response.token}`);
          this.router.navigate(['/orders']);
        },
        (error: any) => {
          console.log('Login error:', error);
          let errorMessage = 'An error occurred while logging in. Please try again.';
          if (error.error && error.error.message) {
            errorMessage = error.error.message;
          }
          // Display the error message to the user using a popup or a toast message
          alert(errorMessage);
        }
      );
    }
  }
  

}
