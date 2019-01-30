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
    this.authorize();
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
