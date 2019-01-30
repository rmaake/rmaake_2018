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
import { PasswordChange } from '../models/passwordChange.model';
import { HttpRequest, HttpEventType, HttpClient } from '@angular/common/http';
import { EmployeeProfileComponent } from '../employee-profile/employee-profile.component';
import { environment } from '../../environments/environment';
import { AdminService } from './admin.service';

@Injectable()
export class EmployeeProfileService {

  private url = environment.apiUrl;
  private options: RequestOptions;

  constructor(private http: Http, public adminS: AdminService, public router: Router, private httpClient: HttpClient) {
    const headers = new Headers({
      'Content-Type': 'application/json',
    });
    this.options = new RequestOptions({ headers: headers, withCredentials: true });
  }

  chanagePassword(pChange: PasswordChange) {
    this.http.post(this.url + 'passwordchange', pChange, this.options).subscribe(resp => {
      alert("Password change successful");
    }, err => {
      alert("Password change failed:\nPossible reasons: Incorrect old password");
    });
  }
  requestChangePassword(id: number, user: string) {
    console.log("Username: " + user);
    var obj = new UserCredentials();
    obj.username = user;
    obj.password = "none";
    this.http.put(this.url + 'passwordchange/' + id.toString(), obj, this.options).subscribe(resp => {
      alert("A new password was sent to your email");

      this.router.navigateByUrl('');
    }, err => { });
  }
  updateEmployee(employee: Employee) {
    this.http.put(this.url + 'employee/' + employee.employeeId.toString(), employee, this.options).subscribe(resp => {
      alert("Profile picture uploaded successfully");
    }, err => { })
  }
  /*Manage Uploads*/
  upload(files, obj: EmployeeProfileComponent, path: string) {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    const uploadReq = new HttpRequest('POST', this.url + `upload/` + path, formData, {
      reportProgress: true, withCredentials: true,
    });

    this.httpClient.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        obj.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response) {
        obj.message = "success";
        obj.employee.imagePath = event.body.toString();
        this.updateEmployee(obj.employee);
      }

    });
  }
}
