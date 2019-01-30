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
import { Supplier } from '../models/supplier.model';
import { Client } from '../models/client.model';
import { EmployeeKin } from '../models/employeeKin';
import { EmployeeAccount } from '../models/employeeAccount';
import { SupplierAccount } from '../models/supplierAccount.model';
import { EmployeeRole } from '../models/employeeRole.model';
import { environment } from '../../environments/environment.prod';

@Injectable()
export class AdminService {

  public clientSubject: BehaviorSubject<Client[]>;
  public clientContactSubject: BehaviorSubject<ClientContact[]>;
  public supplierSubject: BehaviorSubject<Supplier[]>;
  public supplierAccountSubject: BehaviorSubject<SupplierAccount[]>;
  public employeeSubject: BehaviorSubject<Employee[]>;
  public employeeKinSubject: BehaviorSubject<EmployeeKin[]>;
  public employeeAccountSubject: BehaviorSubject<EmployeeAccount[]>;
  public employeeRoleSubject: BehaviorSubject<EmployeeRole[]>;
  private url = environment.apiUrl;
  public isLoggedIn: Observable<number>;
  public employee: Observable<Employee[]>;
  public client: Observable<Client[]>;
  public supplier: Observable<Supplier[]>;

  private options: RequestOptions;

  constructor(private http: Http, public location: Location, public router: Router) {
    const headers = new Headers({
      'Content-Type': 'application/json',
    });

    this.options = new RequestOptions({ headers: headers, withCredentials: true });
    this.clientSubject = new BehaviorSubject<Client[]>([]);
    this.clientContactSubject = new BehaviorSubject<ClientContact[]>([]);
    this.employeeSubject = new BehaviorSubject<Employee[]>([]);
    this.supplierSubject = new BehaviorSubject<Supplier[]>([]);
    this.supplierAccountSubject = new BehaviorSubject<SupplierAccount[]>([]);
    this.employeeAccountSubject = new BehaviorSubject<EmployeeAccount[]>([]);
    this.employeeKinSubject = new BehaviorSubject<EmployeeKin[]>([]);
    this.employeeRoleSubject = new BehaviorSubject<EmployeeRole[]>([]);
    this.getClients();
    this.getClientContacts();
    this.getEmployees();
    this.getSuppliers();
    this.getSupplierAccounts();
    this.getEmployeeAccount();
    this.getEmployeeKin();
    this.getEmployeeRoles();
  }
  /*Manage clients */
  public getClients() {
    this.http.get(this.url + 'client', this.options).subscribe(resp => {
      this.clientSubject.next(resp.json() as Client[]);
    }, err => console.log(err));
  }

  public deleteClient(id: number) {
    this.http.delete(this.url + 'client/' + id.toString(), this.options).subscribe(resp => {
      this.getClients();
    }, err => console.log(err));
  }

  public addClient(client: Client, contact: ClientContact) {
    this.http.post(this.url + 'client', client, this.options).subscribe(resp => {
      client = resp.json() as Client;
      contact.clientId = client.clientId;
      this.addClientContact(contact);
      this.router.navigateByUrl('admin-client');
    }, err => console.log(err));
  }

  public updateClient(id: number, client: Client) {
    this.http.put(this.url + 'client/' + id.toString(), client, this.options).subscribe(resp => {
      this.router.navigateByUrl('admin-client');
    }, err => console.log(err));
  }

  /*Manage ClientContact */

  public getClientContacts() {
    this.http.get(this.url + 'clientcontact', this.options).subscribe(resp => {
      this.clientContactSubject.next(resp.json() as ClientContact[]);
    }, err => console.log(err));
  }

  public deleteClientContact(id: number) {
    this.http.delete(this.url + 'clientcontact/' + id.toString(), this.options).subscribe(resp => {
      this.getClientContacts();
    }, err => console.log(err));
  }

  public addClientContact(contact: ClientContact) {
    this.http.post(this.url + 'clientcontact', contact, this.options).subscribe(resp => {
      contact = resp.json() as ClientContact;
     
    }, err => console.log(err));
  }

  public updateClientContact(id: number, client: ClientContact) {
    this.http.put(this.url + 'clientcontact/' + id.toString(), client, this.options).subscribe(resp => {

    }, err => console.log(err));
  }

  /*Manage supppliers */

  public getSuppliers() {
    this.http.get(this.url + 'supplier', this.options).subscribe(resp => {
      this.supplierSubject.next(resp.json() as Supplier[]);
    }, err => console.log(err));
  }

  public addSupplier(supplier: Supplier, account: SupplierAccount) {
    this.http.post(this.url + 'supplier', supplier, this.options).subscribe(resp => {
      supplier = resp.json() as Supplier;
      this.addSupplierAccount(supplier.supplierId, account);
      this.router.navigateByUrl('admin-supplier');
    }, err => console.log(err));
  }

  public updateSupplier(id: number, supplier: Supplier) {
    this.http.put(this.url + 'supplier/' + id.toString(), supplier, this.options).subscribe(resp => {
      this.router.navigateByUrl('admin-supplier');
    }, err => console.log(err));
  }
  public deleteSupplier(id: number) {
    this.http.delete(this.url + 'supplier/' + id.toString(), this.options).subscribe(resp => {
      this.getSuppliers();
    }, err => console.log(err));
  }

  /*Manage Supplier Account */

  public getSupplierAccounts() {
    this.http.get(this.url + 'ExternalSupplierAccount', this.options).subscribe(resp => {
      this.supplierAccountSubject.next(resp.json() as SupplierAccount[]);

    }, err => console.log(err));
  }

  public addSupplierAccount(supplierId: number, account: SupplierAccount) {
    account.supplierId = supplierId;
    this.http.post(this.url + 'ExternalSupplierAccount', account, this.options).subscribe(resp => {
      account = resp.json();
    }, err => console.log(err));
  }

  public updateSupplierAccount(id: number, account: SupplierAccount) {
    this.http.put(this.url + 'ExternalSupplierAccount/' + id.toString(), account, this.options).subscribe(resp => {

    }, err => console.log(err));
  }

  public deleteSupplierAccount(id: number) {
    this.http.delete(this.url + 'ExternalSupplierAccount/' + id.toString(), this.options).subscribe(resp => {

    }, err => console.log(err));
  }

  /*Manage employees */
  public getEmployees() {
    this.http.get(this.url + 'employee', this.options).subscribe(resp => {
      this.employeeSubject.next(resp.json() as Employee[]);
    }, err => console.log(err));
  }

  public addEmployee(employee: Employee, kin: EmployeeKin, acc: EmployeeAccount) {
    this.http.post(this.url + 'employee', employee, this.options).subscribe(resp => {
      employee = resp.json();
      this.addEmployeeKin(employee.employeeId, kin);
      this.addEmployeeAccount(employee.employeeId, acc);
      this.router.navigateByUrl('admin-employee');
    }, err => console.log(err));
  }

  public updateEmployee(id: number, employee: Employee) {
    this.http.put(this.url + 'employee/' + id.toString(), employee, this.options).subscribe(resp => {
      this.router.navigateByUrl('admin-employee');
    }, err => console.log(err));
  }

  public deleteEmployee(id: number) {
    this.http.delete(this.url + 'employee/' + id.toString(), this.options).subscribe(resp => {
      this.getEmployees();
    }, err => console.log(err));
  }
  /**Manage employee next of kin */
  public getEmployeeKin() {
    this.http.get(this.url + 'employeeKin', this.options).subscribe(resp => {
      this.employeeKinSubject.next(resp.json() as EmployeeKin[]);

    }, err => console.log(err));
  }

  public addEmployeeKin(employeeId: number, kin: EmployeeKin) {
    kin.employeeId = employeeId;
    this.http.post(this.url + 'employeeKin', kin, this.options).subscribe(resp => {
      kin = resp.json();
    }, err => console.log(err));
  }

  public updateEmployeeKin(id: number, kin: EmployeeKin) {
    this.http.put(this.url + 'employeeKin/' + id.toString(), kin, this.options).subscribe(resp => {
      
    }, err => console.log(err));
  }

  public deleteEmployeeKin(id: number) {
    this.http.delete(this.url + 'employeeKin/' + id.toString(), this.options).subscribe(resp => {

    }, err => console.log(err));
  }

  /**Manage Employee Account */
  
  public getEmployeeAccount() {
    this.http.get(this.url + 'employeeAccount', this.options).subscribe(resp => {
      this.employeeAccountSubject.next(resp.json() as EmployeeAccount[]);
    }, err => console.log(err));
  }

  public addEmployeeAccount(employeeId: number, acc: EmployeeAccount) {
    acc.employeeId = employeeId;
    this.http.post(this.url + 'employeeAccount', acc, this.options).subscribe(resp => {
      acc = resp.json();
    }, err => console.log(err));
  }

  public updateEmployeeAccount(id: number, acc: EmployeeAccount) {
    this.http.put(this.url + 'employeeAccount/' + id.toString(), acc, this.options).subscribe(resp => {
     
    }, err => console.log(err));
  }

  public deleteEmployeeAccount(id: number) {
    this.http.delete(this.url + 'employeeAccount/' + id.toString(), this.options).subscribe(resp => {
      
    }, err => console.log(err));
  }
  /* Manage Employee Roles */

  getEmployeeRoles() {
    this.http.get(this.url + 'employeerole', this.options).subscribe(resp => {
      this.employeeRoleSubject.next(resp.json() as EmployeeRole[]);
    }, err => console.log(err));
  }
  addEmployeeRoles(er: EmployeeRole) {
    this.http.post(this.url + 'employeerole', er, this.options).subscribe(resp => {
      er = resp.json() as EmployeeRole;
    }, err => console.log(err));
  }
  updateEmplyeeRoles(id: number, er: EmployeeRole) {
    this.http.put(this.url + 'employeerole/' + id.toString(), er, this.options).subscribe(resp => {
    }, err => console.log(err));
  }
  deleteEmployeeRoles(id: number) {
    this.http.delete(this.url + 'empployeerole/' + id.toString(), this.options).subscribe(resp => {
      this.getEmployeeRoles();
    }, err => console.log(err));
  }
}
