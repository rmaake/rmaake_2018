import { Component, OnInit } from '@angular/core';
import { UserCredentials } from '../models/userCredentials.model';
import { AuthService } from '../services/authentication.service';
import { Router } from '@angular/router';
import { Employee } from '../models/employee.model';
import { PasswordChange } from '../models/passwordChange.model';
import { EmployeeProfileService } from '../services/employeeProfile.service';

@Component({
  selector: 'app-employee-profile',
  templateUrl: './employee-profile.component.html',
  styleUrls: ['./employee-profile.component.css']
})
export class EmployeeProfileComponent implements OnInit {
  employee: Employee;
  passwordChange: PasswordChange;
  confirmPassword: string;
  progress: number;
  message: string;
  constructor(private service: EmployeeProfileService, private router: Router) {
    this.passwordChange = new PasswordChange();
  }

  ngOnInit() {
    this.employee = JSON.parse(sessionStorage.getItem('userData')) as Employee;
    this.passwordChange.employeeId = this.employee.employeeId;
  }

  fileChange(file) {
    if (this.employee.imagePath.length > 1)
      this.service.upload(file, this, this.employee.imagePath.split("/")[1]);
    else
      this.service.upload(file, this, '');
  }

  checkPassword() {
    if (this.passwordChange.newPassword.localeCompare(this.confirmPassword) == 0)
      return true;
    else
      return false;
  }
  submit() {

  }
}
