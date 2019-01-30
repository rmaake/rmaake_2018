import { Component, OnInit } from '@angular/core';

import { AuthService } from '../../services/authentication.service';
import { Router } from '@angular/router';
import { AdminService } from '../../services/admin.service';
import { Supplier } from '../../models/supplier.model';

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
}
