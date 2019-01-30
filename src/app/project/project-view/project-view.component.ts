import { Component, OnInit } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';
import { ProjectService } from '../../services/project.service';
import { Project } from '../../models/project.model';
import { Client } from '../../models/client.model';
import { ClientContact } from '../../models/clientContact.model';
import { Timeline } from '../../models/Timeline.model';
import { ProjectStatus } from '../../models/projectStatus.model';
import { DatePipe } from '@angular/common';
import { ProjectContent } from '../../models/projectContent.model';
import { ProjectFile } from '../../models/projectFile.model';
import { ProjectContentService } from '../../services/project-content.service';
import { Employee } from '../../models/employee.model';
import { EmployeeTimeline } from '../../models/EmployeeTimeline.model';
import { EmployeeRole } from '../../models/employeeRole.model';

@Component({
  selector: 'app-project-view',
  templateUrl: './project-view.component.html',
  styleUrls: ['./project-view.component.css']
})
export class ProjectViewComponent implements OnInit {
  id = 0;
  project: Project;
  client: Client;
  contact: ClientContact;
  timeline: Timeline[] = [];
  duration: Timeline;
  status: ProjectStatus[] = [];
  contents: ProjectFile[] = [];
  content: ProjectFile;
  sManager: Employee;
  pManager: Employee;
  roles: EmployeeRole[] = [];
  et: EmployeeTimeline[] = [];
  durationProgress: number;
  projectProgress: number = 0;
  tabNumber = 0;
  progress = 0;
  message = "";
  constructor(private service: ProjectService, private route: ActivatedRoute, private router: Router, private contentS: ProjectContentService) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.project = new Project();
    this.client = new Client();
    this.contact = new ClientContact();
    this.duration = new Timeline();
    this.getById(this.id);
    this.content = new ProjectFile();
    this.pManager = new Employee();
    this.sManager = new Employee();
    this.content.projectId = this.id;
    this.content.filePath = "";
  }
  ngOnInit() {
    this.getById(this.id);
    this.service.projectStatusSubject.subscribe(resp => {
      this.status = resp;
      this.getProjectProgress();
    });
    this.service.projectFileSubject.subscribe(resp => {
      this.contents = [];
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].projectId == this.id)
          this.contents.push(resp[i]);
      }
    });
    this.service.employeeTimelineSubject.subscribe(resp => {
      this.et = [];
      for (var i = 0; i < resp.length; i++) {
        if (this.id == resp[i].projectId)
          this.et.push(resp[i]);
      }
      this.getRoles();
    });
  }
  getRoles() {
    this.service.admin.employeeRoleSubject.subscribe(resp => {
      this.roles = resp;
      for (var i = 0; i < resp.length; i++) {
        for (var j = 0; j < this.et.length; j++) {
          if (resp[i].title.localeCompare('ProjectManager') == 0 && this.et[j].employeeRoleId == resp[i].employeeRoleId && this.et[j].projectId == this.id) {
            this.pManager.employeeId = this.et[j].employeeId;
            
          }
          if (resp[i].title.localeCompare('SiteManager') == 0 && this.et[j].employeeRoleId == resp[i].employeeRoleId && this.et[j].projectId == this.id) {
            this.sManager.employeeId = this.et[j].employeeId;
            
          }
        }
      }
      this.assignEmployees();
    });
  }
  assignEmployees() {
    console.log(this.pManager.employeeId);
    console.log(this.sManager.employeeId);
    this.service.admin.employeeSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].employeeId == this.sManager.employeeId) {
          this.sManager = resp[i];
          console.log("first loop");
          console.log(this.sManager);
          break;
        }
        
      }
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].employeeId = this.pManager.employeeId) {
          console.log("second loop");
          console.log(this.pManager);
          this.pManager = resp[i];
          break;
        }
      }
    });
  }
  getById(id: number) {
    this.service.projectsSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].projectId == id) {
          this.project = resp[i];
          this.getClientById(this.project.clientId);
          this.getTimelineById(id);
          break;
        }
      }
    });
    
  }
  getClientById(id: number) {
    this.service.admin.clientSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].clientId == id) {
          this.client = resp[i];
          this.getContactById(id);
          break;
        }
      }
    });
  }
  getContactById(id: number) {
    this.service.admin.clientContactSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].clientId == id) {
          this.contact = resp[i];
          break;
        }
      }
    });
  }
  getTimelineById(id: number) {
   
    this.service.timelineSubject.subscribe(resp => {
      this.timeline = [];
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].projectId == id)
          this.timeline.push(resp[i]);
      }
      this.getDuration();
    });
  }
  getDuration() {
    for (var i = 0; i < this.timeline.length; i++) {
      if (this.timeline[i].overallTimeline == true) {
        this.duration = this.timeline[i];
        this.getDurationProgress();
        return;
      }
    }
  }
  getProjectProgress() {
    var c = 0;
    for (var i = 0; i < this.status.length; i++) {
      for (var j = 0; j < this.timeline.length; j++) {
        if (this.timeline[j].projectStatusId == this.status[i].projectStatusId && this.status[i].stage.localeCompare('completed') == 0)
          c++;
      }
    }
    this.projectProgress = c / this.timeline.length * 100;
    try {
      document.getElementById('progressBar2').style.width = this.projectProgress.toString() + '%';
    }
    catch (e) { }
    
  }
  getProjectStatus(timelineId: number) {
    for (var i = 0; i < this.status.length; i++) {
      for (var j = 0; j < this.timeline.length; j++) {
        if (this.timeline[j].timelineId == timelineId && this.status[i].projectStatusId == this.timeline[j].projectStatusId) {
          return this.status[i].stage;
        }

      }
    }
  }
  getDurationProgress() {
    var endDate = new Date(this.duration.endDate).getTime();
    var startDate = new Date(this.duration.startDate).getTime();

    var now = new Date().getTime();

    // Find the distance between now and the count down date
    var distance = endDate - startDate;

    // Time calculations for days, hours, minutes and seconds
    var totaldays = Math.floor(distance / (1000 * 60 * 60 * 24));
    distance = now - startDate;
    var coveredDays = Math.floor(distance / (1000 * 60 * 60 * 24));
    if (totaldays == 0)
      this.durationProgress = 100;
    else
      this.durationProgress = coveredDays / totaldays * 100;
    try {
      if (totaldays < 0 || coveredDays < 0 && totaldays != 0) {
        document.getElementById('progressBar').style.backgroundColor = 'red';
      }
      else {
        document.getElementById('progressBar').style.backgroundColor = '#227093';
      }
      document.getElementById('progressBar').style.width = this.durationProgress.toString() + '%';
    }
    catch (e) {}
  }
  getTimelineProgress(id: string, startDate: Date, endDate: Date) {
    var end = new Date(endDate).getTime();
    var start = new Date(startDate).getTime();

    var now = new Date().getTime();

    // Find the distance between now and the count down date
    var distance = end - start;

    // Time calculations for days, hours, minutes and seconds
    var totaldays = Math.floor(distance / (1000 * 60 * 60 * 24));
    distance = now - start;
    var coveredDays = Math.floor(distance / (1000 * 60 * 60 * 24));
    var duration = 0.0;
    if (totaldays == 0)
      duration = 100;
    else
      duration = coveredDays / totaldays * 100;
    try {
      if (totaldays < 0 || coveredDays < 0 && totaldays != 0) {
        document.getElementById(id).style.backgroundColor = 'red';
      }
      else {
        document.getElementById(id).style.backgroundColor = '#227093';
      }
      document.getElementById(id).style.width = duration.toString() + '%';
    }
    catch (e) { }
    return duration;
  }
  toEdit(id: number) {
    this.router.navigateByUrl('project-edit/' + id.toString());
  }
  toViewTimeline(id: number) {
    this.router.navigateByUrl('timeline/' + this.id.toString() + '/' + id.toString());
  }
  toAddTimeline() {
    this.router.navigateByUrl('timeline/' + this.id.toString());
  }
  switchTab(id: number) {
    document.getElementById(id.toString()).className = "active";
    document.getElementById(this.tabNumber.toString()).className = "";
    this.tabNumber = id;
  }
  fileChange(file) {
    if (this.content.filePath.length > 1)
      this.service.upload(file, this, this.content.filePath.split("/")[1]);
    else
      this.service.upload(file, this, '');
  }
  submit() {
    var tmp = JSON.parse(sessionStorage.getItem('userData')) as Employee;
    this.content.employeeId = tmp.employeeId;
    this.content.projectId = this.id;
    this.service.addProjectFile(this.content);
    //this.content = new ProjectFile();
  }
  
}
