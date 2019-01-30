import { Component, OnInit } from '@angular/core';
import { UserCredentials } from '../models/userCredentials.model';
import { AuthService } from '../services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user = new UserCredentials();
  option = "0";
  status = 0;
  constructor(private service: AuthService, private router: Router) {

  }
  ngOnInit() {
    this.service.isLoggedIn.subscribe(resp => {
      if (resp == 2) {
        this.router.navigate(['/dashboard']);
        return;
      }
      if (resp == 1) {
        this.router.navigate(['/client-dashboard']);
        return;
      }
      if (resp == -2) {
        this.status = -1;
      }
    });
  }
  clientSignIn() {
    this.status = 1;
    this.service.signInClient(this.user);
  }
  employeeSignIn() {
    this.status = 1;
    this.service.signInEmployee(this.user);
  }
}
