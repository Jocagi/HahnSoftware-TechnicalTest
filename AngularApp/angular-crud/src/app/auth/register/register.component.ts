import { CommonModule } from '@angular/common';
import { NgForm, FormGroup, FormControl, Validators } from '@angular/forms'; 
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/services/auth.service';
import { Register } from 'src/app/shared/models/auth.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  exportAs: 'ngFormRegister'
})
export class RegisterComponent implements OnInit {
  
  public registerModel: Register = new Register('', '', '', '');
  public errorMessage: string = '';
  public submitted: boolean = false;
  public registerForm: FormGroup =  new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required)
  });

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required)
    });
  }

  register(): void {
    if (this.registerForm.invalid) {
      return;
    }
    this.submitted = true;
    this.registerModel = {
      email: this.registerForm.get('email')?.value,
      password: this.registerForm.get('password')?.value,
      firstName: this.registerForm.get('firstName')?.value,
      lastName: this.registerForm.get('lastName')?.value
    };
    console.log('Registering user:', this.registerModel);
    this.authService.register(this.registerModel).subscribe(
      (response: { token: any; }) => {
        console.log(`Successfully registered with token: ${response.token}`);
        this.router.navigate(['/orders']);
        this.submitted = false;
      },
      (error: any) => {
        console.log('Register error:', error);
        let errorMessage = 'An error occurred while registering. Please try again.';
        if (error.error && error.error.message) {
          errorMessage = error.error.message;
        }
        // Display the error message to the user using a popup or a toast message
        alert(errorMessage);
        this.submitted = false;
      }
    );
  }

}
