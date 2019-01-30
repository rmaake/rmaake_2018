import { Injectable } from '@angular/core';

//import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { RequestOptions, } from '@angular/http';
import { Headers, ResponseContentType } from '@angular/http';
import { Http } from '@angular/http';
import { Location } from '@angular/common';
import { HttpRequest, HttpEventType, HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Project } from '../models/project.model';
import { ProjectStatus } from '../models/projectStatus.model';
import { ProjectFile } from '../models/projectFile.model';
import { ProjectContent } from '../models/projectContent.model';
import { Timeline } from '../models/Timeline.model';
import { EmployeeTimeline } from '../models/EmployeeTimeline.model';
import { AdminService } from './admin.service';
import { ProjectViewComponent } from '../project/project-view/project-view.component';
import { environment } from '../../environments/environment.prod';

@Injectable()
export class ProjectService {
  public projectsSubject: BehaviorSubject<Project[]>;
  public projectStatusSubject: BehaviorSubject<ProjectStatus[]>;
  public projectFileSubject: BehaviorSubject<ProjectFile[]>;
  public projectContentSubject: BehaviorSubject<ProjectContent[]>;
  public timelineSubject: BehaviorSubject<Timeline[]>;
  public employeeTimelineSubject: BehaviorSubject<EmployeeTimeline[]>;

  private url = environment.apiUrl;
  private options: RequestOptions;

  constructor(private http: Http, private httpClient: HttpClient, public admin: AdminService, public router: Router) {
    const headers = new Headers({
      'Content-Type': 'application/json',
    });
    this.options = new RequestOptions({ headers: headers, withCredentials: true });
    this.projectContentSubject = new BehaviorSubject<ProjectContent[]>([]);
    this.projectFileSubject = new BehaviorSubject<ProjectFile[]>([]);
    this.projectStatusSubject = new BehaviorSubject<ProjectStatus[]>([]);
    this.projectsSubject = new BehaviorSubject<Project[]>([]);
    this.timelineSubject = new BehaviorSubject<Timeline[]>([]);
    this.employeeTimelineSubject = new BehaviorSubject<EmployeeTimeline[]>([]);
    this.getTimeline();
    this.getEmployeeTimeline();
    this.getProjects();
    this.getProjectStatus();
    this.getProjectFile();
    this.getProjectContent();
    
  }
  /*Manage Projects*/

  getProjects() {
    this.http.get(this.url + 'project', this.options).subscribe(resp => {
      this.projectsSubject.next(resp.json() as Project[]);
    }, err => console.log(err));
  }

  addProject(project: Project, timeline: Timeline, sMangager: EmployeeTimeline, pManager: EmployeeTimeline) {
    this.http.post(this.url + 'project', project, this.options).subscribe(resp => {
      project = resp.json() as Project;
      timeline.projectId = project.projectId;
      sMangager.projectId = project.projectId;
      pManager.projectId = project.projectId;
      this.addEmployeeTimeline(sMangager);
      this.addEmployeeTimeline(pManager);
      this.addTimeline(project.projectId, timeline);
      this.router.navigateByUrl('project');
    }, err => console.log(err));
  }

  updateProject(id: number, project: Project) {
    this.http.put(this.url + 'project/' + id.toString(), project, this.options).subscribe(resp => {
    }, err => console.log(err));
  }
  deleteProject(id: number) {
    this.http.delete(this.url + 'project/' + id.toString(), this.options).subscribe(resp => {
      this.getProjects();
    }, err => console.log(err));
  }
  /*Manage Project Content*/

  getProjectContent() {
    this.http.get(this.url + 'projectcontent', this.options).subscribe(resp => {
      this.projectContentSubject.next(resp.json() as ProjectContent[]);
    }, err => console.log(err));
  }

  /*Manage Project Status*/

  getProjectStatus() {
    this.http.get(this.url + 'projectstatus', this.options).subscribe(resp => {
      this.projectStatusSubject.next(resp.json() as ProjectStatus[]);
    }, err => console.log(err));
  }

  /*Manage Project File*/

  getProjectFile() {
    this.http.get(this.url + 'projectfile', this.options).subscribe(resp => {
      this.projectFileSubject.next(resp.json() as ProjectFile[]);
    }, err => console.log(err));
  }

  addProjectFile(file: ProjectFile) {
    this.http.post(this.url + 'projectfile', file, this.options).subscribe(resp => {
      file = resp.json() as ProjectFile;
      this.getProjectFile();
    }, err =>console.log(file));
  }

  deleteProjectFile(id: number) {
    this.http.delete(this.url + 'projectfile/' + id.toString(), this.options).subscribe(resp => {
      this.getProjectFile();
    }, err => console.log(err));
  }

  upload(files, obj: ProjectViewComponent, path: string) {
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
        obj.content.filePath = event.body.toString();
      }

    });
  }

  /*Manage Timelines*/

  getTimeline() {
    this.http.get(this.url + 'timeline', this.options).subscribe(resp => {
      this.timelineSubject.next(resp.json() as Timeline[]);
    }, err => console.log(err));
  }

  addTimeline(projectId: number, timeline: Timeline) {
    timeline.projectId = projectId;
    this.http.post(this.url + 'timeline', timeline, this.options).subscribe(resp => {
      timeline = resp.json() as Timeline;
    }, err => console.log(err));
  }

  updateTimeline(id: number, timeline: Timeline) {
    this.http.put(this.url + 'timeline/' + id.toString(), timeline, this.options).subscribe(resp => {
      this.router.navigateByUrl('project');
    }, err => console.log(err));
  }
  deleteTimeline(id: number) {
    this.http.delete(this.url + 'timeline/' + id.toString(), this.options).subscribe(resp => {
      this.getTimeline();
    }, err => console.log(err));
  }
  /*Manage Employee Timeline*/

  getEmployeeTimeline() {
    this.http.get(this.url + 'employeetimeline', this.options).subscribe(resp => {
      this.employeeTimelineSubject.next(resp.json() as EmployeeTimeline[]);
    }, err => console.log(err));
  }

  addEmployeeTimeline(et: EmployeeTimeline) {
    this.http.post(this.url + 'employeetimeline', et, this.options).subscribe(resp => {
      et = resp.json();
      this.getEmployeeTimeline()
    }, err => console.log(err));
  }
  updateEmployeeTimeline(id: number, et: EmployeeTimeline) {
    this.http.put(this.url + 'employeetimeline/' + id.toString(), et, this.options).subscribe(resp => {

    }, err => console.log(err));
  }
  deleteEmployeeTimeline(id: number) {
    this.http.delete(this.url + 'employeetimeline/' + id.toString(), this.options).subscribe(resp => {
      this.getEmployeeTimeline();
    }, err => console.log(err));
  }
}
