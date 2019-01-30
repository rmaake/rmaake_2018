import { Component, OnInit } from '@angular/core';
import { UserCredentials } from '../models/userCredentials.model';
import { AuthService } from '../services/authentication.service';
import { Router } from '@angular/router';
import { AdminService } from '../services/admin.service';
import { Client } from '../models/client.model';
import { Employee } from '../models/employee.model';
import { Supplier } from '../models/supplier.model';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  clients: Client[] = [];
  employees: Employee[] = [];
  suppliers: Supplier[] = [];
  constructor(private service: AdminService, private router: Router) {
  }
  ngOnInit() {
    this.authorize();
    this.service.getClients();
    this.service.getSuppliers();
    this.service.getEmployees();
    this.service.clientSubject.subscribe(resp => {
      this.clients = resp;
    });
    this.service.employeeSubject.subscribe(resp => {
      this.employees = resp;
    });
    this.service.supplierSubject.subscribe(resp => {
      this.suppliers = resp;
      
    });
    //this.service.signOut();
  }
  authorize() {
    var tmpUser = JSON.parse(sessionStorage.getItem('userData')) as Employee;
    if (sessionStorage.getItem('currentUser') != '2') {
      this.router.navigateByUrl('access-control');
      return;
    }
    var read = false;
    var write = false;
    var dlt = false;
    var permission = tmpUser.accessCode.split(".");
    for (var i = 0; i < permission.length; i++) {
      if (permission[i].localeCompare('admin:read') == 0)
        read = true;
      if (permission[i].localeCompare('admin:write') == 0)
        write = true;
      if (permission[i].localeCompare('admin:delete') == 0)
        dlt = true;
    }
    if (read == false && write == false && dlt == false) {
      this.router.navigateByUrl('access-control');
      return;
    }
  }

}
