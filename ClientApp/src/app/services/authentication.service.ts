import { Injectable } from '@angular/core';

//import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { RequestOptions, } from '@angular/http';
import { Headers } from '@angular/http';
import { Http } from '@angular/http';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { ClientContact } from '../models/clientContact.model';
import { Employee } from '../models/employee.model';
import { UserCredentials } from '../models/userCredentials.model';
import { Client } from '../models/client.model';
import { environment } from '../../environments/environment.prod';

@Injectable()
export class AuthService {

  public currentClientSubject: BehaviorSubject<ClientContact>;
  public currentEmployeeSubject: BehaviorSubject<Employee>;
  private isLoggedInSubject: BehaviorSubject<number>;
  private url = environment.apiUrl;
  public isLoggedIn: Observable<number>;
  public currentEmployee: Observable<Employee>;
  public currentClient: Observable<ClientContact>;

  private options: RequestOptions;

  constructor(private http: Http, public location: Location, public router: Router) {
    const headers = new Headers({
      'Content-Type': 'application/json',
    });

    this.options = new RequestOptions({ headers: headers, withCredentials: true });
    
    this.currentClientSubject = new BehaviorSubject<ClientContact>(null);
    this.currentEmployeeSubject = new BehaviorSubject<Employee>(null);
    this.isLoggedInSubject = new BehaviorSubject<number>(-1);
    if (sessionStorage.length > 1) {
      var tmp = parseInt(sessionStorage.getItem('currentUser'));
      this.isLoggedInSubject = new BehaviorSubject<number>(tmp);
      switch (tmp) {
        case 1:
          this.storeClient();
          break;
        case 2:
          this.storeEmployee();
          break;
        default:
          this.isLoggedInSubject = new BehaviorSubject<number>(-1);
          break;
      }
    }
    else {
      this.isLoggedInSubject = new BehaviorSubject<number>(-1);
      
    }

    this.isLoggedIn = this.isLoggedInSubject.asObservable();
  }
  private storeEmployee() {
    this.isLoggedInSubject = new BehaviorSubject<number>(2);
    try {
      this.currentEmployeeSubject = new BehaviorSubject<Employee>(JSON.parse(sessionStorage.getItem('userData')) as Employee);
      this.currentEmployee = this.currentEmployeeSubject.asObservable();
    }
    catch (e)
    {
      console.log(e);

    }
    
  }
  private storeClient() {
    this.isLoggedInSubject = new BehaviorSubject<number>(1);
    try {
      this.currentClientSubject = new BehaviorSubject<ClientContact>(JSON.parse(sessionStorage.getItem('userData')) as ClientContact);
      this.currentClient = this.currentClientSubject.asObservable();
    }
    catch (e) {
      console.log(e);
    }
  }
  public signInEmployee(user: UserCredentials) {
    this.http.post(this.url + 'authentication', user, this.options).subscribe(resp => {
      this.currentEmployeeSubject.next(resp.json() as Employee);
      if (resp.json() as Employee != null) {
        this.isLoggedInSubject.next(2);
        this.currentEmployee = this.currentEmployeeSubject.asObservable();
        sessionStorage.setItem('currentUser', '2');
        sessionStorage.setItem('userData', resp.text());
        //this.router.navigateByUrl('/dashboard');
        var tmp = document.getElementById('btn') as HTMLAnchorElement;
        tmp.click();
      }
      else {
        this.isLoggedInSubject.next(-2);
      }
      console.log(resp.json());
    }, err => {
      console.log(err);
      this.isLoggedInSubject.next(-2)
      });
  }
  public signInClient(user: UserCredentials) {
    this.http.post(this.url + 'authentication/0', user, this.options).subscribe(resp => {
      this.currentClientSubject.next(resp.json() as ClientContact);
      if (resp.json() as ClientContact != null) {
        this.isLoggedInSubject.next(1);
        this.currentClient = this.currentClientSubject.asObservable();
        sessionStorage.setItem('currentUser', '1');
        sessionStorage.setItem('userData', resp.text());
        //this.router.navigateByUrl('/client-dashboard');
        var tmp = document.getElementById('btns') as HTMLAnchorElement;
        tmp.click();
      }
      else {
        this.isLoggedInSubject.next(-2);
      }
      console.log(resp.json());
    }, err => console.log(err));
  }
  
  public signOut() {

    this.http.delete(this.url + 'authentication', this.options).subscribe(resp => {
      sessionStorage.clear();
      this.isLoggedInSubject.next(-1);
      this.currentEmployeeSubject.next(new Employee());
      this.currentClientSubject.next(new ClientContact());
      this.router.navigateByUrl('');
    }, err => { console.log(err); });
  }

}
