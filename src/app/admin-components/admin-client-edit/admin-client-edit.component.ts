import { Component, OnInit } from '@angular/core';

import { AuthService } from '../../services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminService } from '../../services/admin.service';
import { forEach } from '@angular/router/src/utils/collection';
import { Client } from '../../models/client.model';
import { ClientContact } from '../../models/clientContact.model';


@Component({
  selector: 'app-admin-client-edit',
  templateUrl: './admin-client-edit.component.html',
  styleUrls: ['./admin-client-edit.component.css']
})
export class AdminClientEditComponent implements OnInit {
  tabNumber = 0;
  client = new Client();
  contact = new ClientContact();
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
    //this.service.signOut();
  }
  submit() {
    if (this.id <= 0)
      this.service.addClient(this.client, this.contact);
    else {
      this.service.updateClient(this.id, this.client);
      this.service.updateClientContact(this.contact.clientContactInfoId, this.contact);
    }
    this.sent = true;
  }
  
  getById(id: number) {
    this.service.clientSubject.subscribe(resp => {
      resp.forEach(client => {
        if (client.clientId == id) {
          this.client = client;
        }
      });
    });
    this.service.clientContactSubject.subscribe(resp => {
      resp.forEach(contact => {
        if (contact.clientId == id)
          this.contact = contact;

      });
    });
    this.client.clientId = id;
    this.contact.clientId = id;
  }

  switchTab(id: number) {
    document.getElementById(id.toString()).className = "active";
    document.getElementById(this.tabNumber.toString()).className = "";
    this.tabNumber = id;
  }

}
