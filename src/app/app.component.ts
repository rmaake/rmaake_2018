import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  isLoggedIn = 0;
  constructor(private service: AuthService, private router: Router) {

  }
  ngOnInit() {
    this.service.isLoggedIn.subscribe(resp => {
      this.isLoggedIn = resp;
      if (resp == -1) {
        this.router.navigate(['']);
      }
    });
  }
  title = 'app';
}
