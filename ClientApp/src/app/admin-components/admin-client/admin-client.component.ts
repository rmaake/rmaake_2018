import { Component, OnInit } from '@angular/core';

import { AuthService } from '../../services/authentication.service';
import { Router } from '@angular/router';
import { AdminService } from '../../services/admin.service';
import { Client } from '../../models/client.model';

@Component({
  selector: 'app-admin-client',
  templateUrl: './admin-client.component.html',
  styleUrls: ['./admin-client.component.css']
})
export class AdminClientComponent implements OnInit {

  clients: Client[] = [];
  selectedId: number;
  constructor(private service: AdminService, private router: Router) {
    //  this.service.signOut();
  }
  ngOnInit() {
    this.service.getClients();
    this.service.clientSubject.subscribe(resp => {
      this.clients = resp;
    });
  }
  toAdd() {
    this.router.navigateByUrl('admin-client-edit');
  }
  toEdit(id: number) {
    this.router.navigateByUrl('admin-client-edit/' + id.toString());
  }
  toDelete(id: number) {
    this.selectedId = id;
    this.service.deleteClient(id);

  }
}
