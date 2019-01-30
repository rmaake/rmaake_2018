import { Component, OnInit } from '@angular/core';
import { UserCredentials } from '../models/userCredentials.model';
import { AuthService } from '../services/authentication.service';
import { Router } from '@angular/router';
import { EmployeeProfileService } from '../services/employeeProfile.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {
  username: string;
  constructor(private service: EmployeeProfileService) {

  }
  ngOnInit() {
    

  }
  request(id: number) {
    this.service.requestChangePassword(id, this.username);
  }
  
}
