import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { ProjectService } from '../../services/project.service';
import { Project } from '../../models/project.model';
import { AuthService } from '../../services/authentication.service';
import { ClientContact } from '../../models/clientContact.model';
import { Client } from '../../models/client.model';
import { Timeline } from '../../models/Timeline.model';
import { ProjectStatus } from '../../models/projectStatus.model';


@Component({
  selector: 'app-client-project',
  templateUrl: './client-project.component.html',
  styleUrls: ['./client-project.component.css']
})
export class ClientProjectComponent implements OnInit {
  projects: Project[] = [];
  clientContact: ClientContact;
  client: Client;
  timeline: Timeline[] = [];
  status: ProjectStatus[] = [];
  ready: boolean = false;
  completedProjects: number = 0;
  overdueProjects: number = 0;
  pendingProjects: number = 0;
  activeProjects: number = 0;
  constructor(private router: Router, private service: ProjectService, private authS: AuthService) {
    this.authS.currentClient.subscribe(resp => {
      this.clientContact = resp;
    });
  }
  ngOnInit() {
    this.authorize();
    this.service.getProjectStatus();
    this.service.getProjects();
    this.service.getTimeline();
    this.service.admin.getClients();
    this.service.projectsSubject.subscribe(resp => {
      this.projects = [];
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].clientId == this.clientContact.clientId)
          this.projects.push(resp[i]);
      }
      this.service.admin.clientSubject.subscribe(res => {
        for (var i = 0; i < res.length; i++) {
          if (res[i].clientId == this.clientContact.clientId) {
            this.client = res[i];
            break
          }
        }
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
  merge() {
    for (var j = 0; j < this.projects.length; j++) {
      if (this.projects[j].clientId == this.client.clientId) {
        this.ready = true;
        this.projects[j].client = this.client;
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
  toView(id: number) {
    this.router.navigateByUrl('client-view/' + id.toString());
  }
  authorize() {

    if (sessionStorage.getItem('currentUser') != '1') {
      this.router.navigateByUrl('access-control');
      return;
    }

  }
}
