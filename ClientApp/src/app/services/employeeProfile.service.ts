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

@Injectable()
export class EmployeeProfileService {

  private url = environment.apiUrl;
  private options: RequestOptions;

  constructor(private http: Http, public location: Location, public router: Router, private httpClient: HttpClient) {
    const headers = new Headers({
      'Content-Type': 'application/json',
    });
    this.options = new RequestOptions({ headers: headers, withCredentials: true });
  }

  chanagePassword(pChange: PasswordChange) {
    this.http.post(this.url + 'passwordchange', pChange, this.options).subscribe(resp => {
      alert("Password change successful");
    }, err => {
      alert("Password chhange failed:\nPossible reasons: Incorrect old password");
    });
  }
  requestChangePassword(user: string) {
    this.http.put(this.url + 'passwordchange/' + user, null, this.options).subscribe(resp => {
      alert("A new password was sent to your email");
    }, err => { });
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
      }

    });
  }
}
