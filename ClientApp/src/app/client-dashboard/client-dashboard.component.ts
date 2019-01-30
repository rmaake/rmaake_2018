import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';

@Component({
  selector: 'app-client-dashboard',
  templateUrl: './client-dashboard.component.html',
  styleUrls: ['./client-dashboard.component.css']
})
export class ClientDashboardComponent implements OnInit {

  constructor(private router: Router) {
   
  }
  ngOnInit() {
    this.authorize();
  }
  authorize() {
    
    if (sessionStorage.getItem('currentUser') != '1') {
      this.router.navigateByUrl('access-control');
      return;
    }
    
  }

}
