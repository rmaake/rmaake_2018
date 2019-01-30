import { Component, OnInit } from '@angular/core';
import { UserCredentials } from '../models/userCredentials.model';
import { AuthService } from '../services/authentication.service';
import { Router } from '@angular/router';
import { ProjectService } from '../services/project.service';
import { Project } from '../models/project.model';
import { Timeline } from '../models/Timeline.model';
import { ProjectStatus } from '../models/projectStatus.model';
import { Client } from '../models/client.model';
import { window } from 'rxjs/operator/window';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {
  project: Project[] = [];
  timeline: Timeline[] = [];
  status: ProjectStatus[] = [];
  client: Client[] = [];
  overdueProjects = 0;
  activeProjects = 0;
  pendingProjects = 0;
  completedProjects = 0;
  ready = false;
  constructor(private service: ProjectService, private router: Router) {
    //this.service.signOut();
    
  }
  ngOnInit() {
    this.service.getProjectStatus();
    this.service.getProjects();
    this.service.getTimeline();
    this.service.admin.getClients();
    this.service.projectsSubject.subscribe(resp => {
      this.project = resp;
      this.service.admin.clientSubject.subscribe(res => {
        this.client = res;
        this.merge();
      });
    });
    this.service.projectStatusSubject.subscribe(resp => {
      this.status = resp;
      this.service.timelineSubject.subscribe(res => {
        this.timeline = res;
        this.getReport();
      });
    });
  }
  toAdd() {
    this.router.navigateByUrl('project-edit');
  }
  merge() {
    for (var i = 0; i < this.client.length; i++) {
      for (var j = 0; j < this.project.length; j++) {
        if (this.project[j].clientId == this.client[i].clientId) {
          this.ready = true;
          this.project[j].client = this.client[i];
        }
          
      }
    }
    
  }
  getProjectStatus(projectId: number) {
    for (var i = 0; i < this.status.length; i++) {
      for (var j = 0; j < this.timeline.length; j++) {
        if (this.timeline[j].projectId == projectId && this.status[i].projectStatusId == this.timeline[j].projectStatusId) {
          return this.status[i].stage;
        }
          
      }
    }
  }
  getReport() {
    for (var i = 0; i < this.status.length; i++) {
      this.status[i].timeline = [];
      for (var j = 0; j < this.timeline.length; j++) {
        if (this.timeline[j].overallTimeline == true && this.timeline[j].projectStatusId == this.status[i].projectStatusId)
          this.status[i].timeline.push(this.timeline[j]);
      }
    }
    for (var i = 0; i < this.status.length; i++) {
      switch (this.status[i].stage) {
        case 'completed':
          this.completedProjects = this.status[i].timeline.length;
          break;
        case 'overdue':
          this.overdueProjects = this.status[i].timeline.length;
          break;
        case 'pending':
          this.pendingProjects = this.status[i].timeline.length;
          break;
        case 'active':
          this.activeProjects = this.status[i].timeline.length;
          break;
        default:
          break;
      }
    }
  }
  toDelete(id: number) {
    this.service.deleteProject(id);
    this.getReport();
  }
  toView(id: number) {
    this.router.navigateByUrl('project/' + id.toString());
  }
}
