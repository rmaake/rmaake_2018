import { Component } from '@angular/core';
import { AuthService } from '../services/authentication.service';
import { Employee } from '../models/employee.model';
import { ClientContact } from '../models/clientContact.model';

@Component({
  selector: 'app-base-template',
  templateUrl: './base-template.component.html',
  styleUrls: ['./base-template.component.css']
})
export class BaseTemplateComponent {

  isExpanded = false;
  employee = new Employee();
  client = new ClientContact();
  user = 0;
  constructor(private auth: AuthService) {
    this.auth.isLoggedIn.subscribe(resp => {
      if (resp == 1)
        this.getClient();
      else if (resp == 2)
        this.getEmployee();
    })
  }
  collapse() {
    this.isExpanded = false;
  }
  getEmployee() {
    this.auth.currentEmployeeSubject.subscribe(resp => {
      this.employee = resp;
      this.user = 2;
    });
  }
  getClient() {
    this.auth.currentClientSubject.subscribe(resp => {
      this.client = resp;
      this.user = 1;
    });
  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
