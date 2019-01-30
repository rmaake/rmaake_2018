import { Component, OnInit } from '@angular/core';

import { AuthService } from '../../services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Employee } from '../../models/employee.model';
import { EmployeeKin } from '../../models/employeeKin';
import { EmployeeAccount } from '../../models/employeeAccount';
import { AdminService } from '../../services/admin.service';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-admin-employee-edit',
  templateUrl: './admin-employee-edit.component.html',
  styleUrls: ['./admin-employee-edit.component.css']
})
export class AdminEmployeeEditComponent implements OnInit {
  tabNumber = 0;
  employee = new Employee();
  employeeKin = new EmployeeKin();
  employeeAccount = new EmployeeAccount();
  permission: string[] = [];
  id = 0;
  val: boolean;
  sent: boolean = false;
  constructor(private service: AdminService, private route: ActivatedRoute) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    if (this.id > 0)
      this.getById(this.id);
    //  this.service.signOut();
  }
  ngOnInit() {
    this.sent = false;
    //this.service.signOut();
  }
  submit() {
    var c = 0;
    this.permission.forEach(val => {
      if (c == 0)
        this.employee.accessCode = val + ".";
      else
        this.employee.accessCode += val + ".";
      c++;
    });
    if (this.permission.length == 0)
      this.employee.accessCode = ".";
    if (this.id <= 0) {
      
      this.service.addEmployee(this.employee, this.employeeKin, this.employeeAccount);
     
    }
    else {
      this.service.updateEmployee(this.employee.employeeId, this.employee);
      this.service.updateEmployeeAccount(this.employeeAccount.employeeAccountsId, this.employeeAccount);
      this.service.updateEmployeeKin(this.employeeKin.employeeKinId, this.employeeKin);
    }
    this.sent = true;
  }
  isChecked(val: string) {
    for (var i = 0; i < this.permission.length; i++) {
      if (this.permission[i].localeCompare(val) == 0)
        return true;
    }
    return false;
  }
  test(acc: string, perm: string, ev: boolean) {
    if (ev == true) {
      this.permission.push(acc + ":" + perm);
    }
    else {
      var i = 0;
      this.permission.forEach(val => {
        if (val.localeCompare(acc + ":" + perm) == 0) {
          this.permission.splice(i, 1);
          return;
        }
        i++;
      });
    }
    console.log(this.permission);
  }
  getById(id: number) {
    this.service.employeeSubject.subscribe(resp => {
      resp.forEach(emp => {
        if (emp.employeeId == id) {
          this.employee = emp;
          this.permission = this.employee.accessCode.split(".");
        }
      });
    });
    this.service.employeeAccountSubject.subscribe(resp => {
      resp.forEach(acc => {
        if (acc.employeeId == id)
          this.employeeAccount = acc;
        
      });
    });
    this.service.employeeKinSubject.subscribe(resp => {
      resp.forEach(kin => {
        if (kin.employeeId == id)
          this.employeeKin = kin;
        
      });
    });
    this.employeeKin.employeeId = id;
    this.employeeAccount.employeeId = id;
  }

  switchTab(id: number) {
    document.getElementById(id.toString()).className = "active";
    document.getElementById(this.tabNumber.toString()).className = "";
    this.tabNumber = id;
  }

}
