import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Project } from '../../models/project.model';
import { Timeline } from '../../models/Timeline.model';
import { ProjectStatus } from '../../models/projectStatus.model';
import { ProjectService } from '../../services/project.service';
import { Client } from '../../models/client.model';
import { Employee } from '../../models/employee.model';
import { EmployeeTimeline } from '../../models/EmployeeTimeline.model';
import { EmployeeRole } from '../../models/employeeRole.model';

@Component({
  selector: 'app-project-edit',
  templateUrl: './project-edit.component.html',
  styleUrls: ['./project-edit.component.css']
})
export class ProjectEditComponent implements OnInit {
  tabNumber = 0;
  project: Project;
  timeline: Timeline;
  status: ProjectStatus[] = [];
  clients: Client[] = [];
  employees: Employee[] = [];
  employeeTimelines: EmployeeTimeline[] = [];
  siteManager: EmployeeTimeline;
  projectManager: EmployeeTimeline;
  roles: EmployeeRole[] = [];
  id = 0;
  ready = false;
  constructor(private router: Router, private service: ProjectService, private route: ActivatedRoute) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.siteManager = new EmployeeTimeline();
    this.projectManager = new EmployeeTimeline();
    this.siteManager.employeeId = 0;
    this.projectManager.employeeId = 0;
    if (this.id <= 0) {
      this.projectManager.projectId = this.id;
      this.siteManager.projectId = this.id;
      this.project = new Project();
      this.timeline = new Timeline();
      this.timeline.projectStatusId = 0;
      this.project.clientId = 0;
      this.ready = true;
      this.assignRoleToNewProject();
    }
    else
      this.getById(this.id);
    this.service.projectStatusSubject.subscribe(resp => {
      this.status = resp;
      
    });
    this.service.admin.clientSubject.subscribe(resp => {
      this.clients = resp;
    });
    //this.service.signOut();
  }
  ngOnInit() {
    this.service.projectStatusSubject.subscribe(resp => {
      this.status = resp;
      
    });
    this.service.admin.clientSubject.subscribe(resp => {
      this.clients = resp;
    });
    this.service.admin.employeeSubject.subscribe(resp => {
      this.employees = resp;
    });
    this.service.admin.employeeRoleSubject.subscribe(resp => {
      this.roles = resp;
    });
    //this.service.signOut();
  }
  submit() {
    console.log(this.project);
    console.log(this.timeline);
    console.log(this.siteManager);
    console.log(this.projectManager);
    if (this.id <= 0) {
      this.timeline.overallTimeline = true;
      this.service.addProject(this.project, this.timeline, this.siteManager, this.projectManager);
    }
    else {
      this.service.updateProject(this.project.projectId, this.project);
      this.service.updateEmployeeTimeline(this.siteManager.employeeTimelineId, this.siteManager);
      this.service.updateEmployeeTimeline(this.projectManager.employeeTimelineId, this.projectManager);
      this.service.updateTimeline(this.timeline.timelineId, this.timeline);
    }
  }
  statusChange(value: any) {
    

    //this.timeline.projectStatusId = value as number;
  }
  getById(id: number) {
    
    this.service.projectsSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].projectId == id) {
          this.project = resp[i];
          this.ready = true;
        }
      }
    });
    this.service.timelineSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].projectId == id) {
          this.timeline = resp[i];
          //this.ready = true;
        }
      }
    });
    this.service.employeeTimelineSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].projectId == id)
          this.employeeTimelines.push(resp[i]);
      }
      this.assignRole();
    });
  }
  assignRole() {
    this.service.admin.employeeRoleSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        for (var j = 0; j < this.employeeTimelines.length; j++) {
          if (resp[i].employeeRoleId == this.employeeTimelines[j].employeeRoleId && resp[i].title.localeCompare('ProjectManager') == 0 && this.employeeTimelines[j].projectId == this.id)
            this.projectManager = this.employeeTimelines[j];
          if (resp[i].employeeRoleId == this.employeeTimelines[j].employeeRoleId && resp[i].title.localeCompare('SiteManager') == 0 && this.employeeTimelines[j].projectId == this.id)
            this.siteManager = this.employeeTimelines[j];
        }
      }
    });
  }
  assignRoleToNewProject() {
    this.service.admin.employeeRoleSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].title.localeCompare('ProjectManager') == 0)
          this.projectManager.employeeRoleId = resp[i].employeeRoleId;
        if (resp[i].title.localeCompare('SiteManager') == 0)
          this.siteManager.employeeRoleId = resp[i].employeeRoleId;
      }
    });
  }
  changeDate(key: number, ev: any) {
    switch (key) {
      case 1:
        this.timeline.startDate = new Date(ev.target.value);
        break;
      case 2:
        this.timeline.endDate = new Date(ev.target.value);
        break;
      case 3:
        this.timeline.extension = new Date(ev.target.value);
        break;
      default:
        break;
    }
    
  }
  switchTab(id: number) {
    document.getElementById(id.toString()).className = "active";
    document.getElementById(this.tabNumber.toString()).className = "";
    this.tabNumber = id;
  }
}
