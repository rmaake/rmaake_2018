import { Component, OnInit } from '@angular/core';

import { AuthService } from '../../services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminService } from '../../services/admin.service';
import { forEach } from '@angular/router/src/utils/collection';
import { Supplier } from '../../models/supplier.model';
import { SupplierAccount } from '../../models/supplierAccount.model';
import { Employee } from '../../models/employee.model';



@Component({
  selector: 'app-admin-supplier-edit',
  templateUrl: './admin-supplier-edit.component.html',
  styleUrls: ['./admin-supplier-edit.component.css']
})
export class AdminSupplierEditComponent implements OnInit {
  tabNumber = 0;
  supplier = new Supplier();
  supplierAccount = new SupplierAccount();
  id = 0;
  sent: boolean = false;
  constructor(private service: AdminService, private route: ActivatedRoute, private router: Router) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    if (this.id > 0)
      this.getById(this.id);
    //  this.service.signOut();
  }
  ngOnInit() {
    this.authorize();
    this.sent = false;
    this.getById(this.id);
    //this.service.signOut();
  }
  submit() {
    if (this.id <= 0)
      this.service.addSupplier(this.supplier, this.supplierAccount);
    else {
      this.service.updateSupplier(this.id, this.supplier);
      this.service.updateSupplierAccount(this.supplierAccount.supplierAccountId, this.supplierAccount);
    }
    this.sent = true;
  }

  getById(id: number) {
    this.service.supplierSubject.subscribe(resp => {
      resp.forEach(supplier => {
        if (supplier.supplierId == id) {
          this.supplier = supplier;
        }
      });
    });
    this.service.supplierAccountSubject.subscribe(resp => {
      resp.forEach(account => {
        if (account.supplierId == id)
          this.supplierAccount = account;

      });
    });
    this.supplier.supplierId = id;
    this.supplierAccount.supplierId = id;
  }

  switchTab(id: number) {
    document.getElementById(id.toString()).className = "active";
    document.getElementById(this.tabNumber.toString()).className = "";
    this.tabNumber = id;
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
