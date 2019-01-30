import { Injectable } from '@angular/core';

//import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { RequestOptions, } from '@angular/http';
import { Headers } from '@angular/http';
import { Http } from '@angular/http';
import { Location } from '@angular/common';
import { HttpRequest, HttpEventType, HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ProjectContent } from '../models/projectContent.model';
import { Default } from '../models/default.model';
import { ProjectService } from './project.service';
import { SnagsComponent } from '../project/snags/snags.component';
import { environment } from '../../environments/environment.prod';


@Injectable()
export class ProjectContentService {
  public projectContentSubject: BehaviorSubject<ProjectContent[]>;
  public defaultSubject: BehaviorSubject<Default[]>;

  private url = environment.apiUrl;
  public isLoggedIn: Observable<number>;

  private options: RequestOptions;

  constructor(private http: Http, public location: Location, public router: Router, public service: ProjectService, private httpClient: HttpClient) {
    const headers = new Headers({
      'Content-Type': 'application/json',
    });

    this.options = new RequestOptions({ headers: headers, withCredentials: true });
    this.defaultSubject = new BehaviorSubject<Default[]>([]);
    this.projectContentSubject = new BehaviorSubject<ProjectContent[]>([]);
    this.getProjectContent();
    this.getDefaults();
  }
  /*Manage Defaults*/
  getDefaults() {
    this.http.get(this.url + 'default', this.options).subscribe(resp => {
      this.defaultSubject.next(resp.json() as Default[]);
    }, err => console.log(err));
  }

  addDefault(projectContentId: number, defl: Default) {
    defl.projectContentId = projectContentId;
    this.http.post(this.url + 'default', defl, this.options).subscribe(resp => {
      defl = resp.json() as Default;
    }, err => console.log(err));
  }

  updateDefault(id: number, defl: Default) {
    this.http.put(this.url + 'default/' + id.toString(), defl, this.options).subscribe(resp => {
    }, err => console.log(err));
  }

  deleteDefault(id: number) {
    this.http.delete(this.url + 'default/' + id.toString()).subscribe(resp => {
      this.getDefaults();
    }, err => console.log(err));
  }

  /*Manage Project Content*/
  getProjectContent() {
    this.http.get(this.url + 'projectcontent', this.options).subscribe(resp => {
      this.projectContentSubject.next(resp.json() as ProjectContent[]);
    }, err => console.log(err));
  }

  addContentDefault(defl: Default, content: ProjectContent) {
    console.log(content);
    this.http.post(this.url + 'projectcontent', content, this.options).subscribe(resp => {
      content = resp.json() as ProjectContent;
      defl.projectContentId = content.projectContentId;
      this.addDefault(content.projectContentId, defl);
      this.getProjectContent();
    }, err => console.log(err));
  }

  addProjectContent(content: ProjectContent) {
    this.http.post(this.url + 'projectcontent', content, this.options).subscribe(resp => {
      content = resp.json() as ProjectContent;
    }, err => console.log(err));
  }

  updateProjectContent(id: number, content: ProjectContent) {
    this.http.put(this.url + 'projectcontent/' + id.toString(), content, this.options).subscribe(resp => {
    }, err => console.log(err));
  }

  deleteProjectContent(id: number) {
    this.http.delete(this.url + 'projectcontent/' + id.toString(), this.options).subscribe(resp => {
      this.getProjectContent();
    }, err => console.log(err));
  }
  /*Manage Uploads*/
  upload(files, obj: SnagsComponent, path: string) {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    const uploadReq = new HttpRequest('POST', this.url + `upload/` + path, formData, {
      reportProgress: true, withCredentials: true,
    });

    this.httpClient.request(uploadReq ).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        obj.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response) {
        obj.message = "success";
        obj.content.imagePath = event.body.toString();
      }
       
    });
  }
}
