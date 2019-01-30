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

}
