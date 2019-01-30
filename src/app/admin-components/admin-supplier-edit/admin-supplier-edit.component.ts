import { Component, OnInit } from '@angular/core';

import { AuthService } from '../../services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminService } from '../../services/admin.service';
import { forEach } from '@angular/router/src/utils/collection';
import { Supplier } from '../../models/supplier.model';
import { SupplierAccount } from '../../models/supplierAccount.model';



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
  constructor(private service: AdminService, private route: ActivatedRoute) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    if (this.id > 0)
      this.getById(this.id);
    //  this.service.signOut();
  }
  ngOnInit() {
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

}
