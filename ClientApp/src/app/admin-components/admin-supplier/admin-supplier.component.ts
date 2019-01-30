import { Component, OnInit } from '@angular/core';

import { AuthService } from '../../services/authentication.service';
import { Router } from '@angular/router';
import { AdminService } from '../../services/admin.service';
import { Supplier } from '../../models/supplier.model';
import { Employee } from '../../models/employee.model';

@Component({
  selector: 'app-admin-supplier',
  templateUrl: './admin-supplier.component.html',
  styleUrls: ['./admin-supplier.component.css']
})
export class AdminSupplierComponent implements OnInit {

  suppliers: Supplier[] = [];
  selectedId: number;
  constructor(private service: AdminService, private router: Router) {
    //  this.service.signOut();
  }
  ngOnInit() {
    this.authorize();
    this.service.getSuppliers();
    this.service.supplierSubject.subscribe(resp => {
      this.suppliers = resp;
    });
  }
  toAdd() {
    this.router.navigateByUrl('admin-supplier-edit');
  }
  toEdit(id: number) {
    this.router.navigateByUrl('admin-supplier-edit/' + id.toString());
  }
  toDelete(id: number) {
    this.selectedId = id;
    this.service.deleteSupplier(id);

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
