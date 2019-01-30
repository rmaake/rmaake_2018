import { Component, OnInit } from '@angular/core';
import { UserCredentials } from '../models/userCredentials.model';
import { AuthService } from '../services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-not-authorized',
  templateUrl: './not-authorized.component.html',
  styleUrls: ['./not-authorized.component.css']
})
export class NotAuthorizedComponent implements OnInit {

  constructor() {

  }
  ngOnInit() {
  }

}
