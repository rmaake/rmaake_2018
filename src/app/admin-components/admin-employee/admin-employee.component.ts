import { Component, OnInit } from '@angular/core';

import { AuthService } from '../../services/authentication.service';
import { Router } from '@angular/router';
import { AdminService } from '../../services/admin.service';
import { Employee } from '../../models/employee.model';

@Component({
  selector: 'app-admin-employee',
  templateUrl: './admin-employee.component.html',
  styleUrls: ['./admin-employee.component.css']
})
export class AdminEmployeeComponent implements OnInit {

  employees: Employee[] = [];
  selectedId: number;
  constructor(private service: AdminService, private router: Router) {
  //  this.service.signOut();
  }
  ngOnInit() {
    this.service.getEmployees();
    this.service.employeeSubject.subscribe(resp => {
      this.employees = resp;
    });
  }
  toAdd() {
    this.router.navigateByUrl('admin-employee-edit');
  }
  toEdit(id: number) {
    this.router.navigateByUrl('admin-employee-edit/' + id.toString());
  }
  toDelete(id: number) {
    this.selectedId = id;
    this.service.deleteEmployee(id);
   
  }
  delete() {
    this.service.deleteEmployee(this.selectedId);
  }
}
