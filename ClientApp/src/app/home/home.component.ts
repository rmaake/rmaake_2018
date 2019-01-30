import { Component, OnInit } from '@angular/core';
import { AdminService } from '../services/admin.service';
import { ProjectService } from '../services/project.service';
import { Client } from '../models/client.model';
import { Project } from '../models/project.model';
import { Timeline } from '../models/Timeline.model';
import { ProjectStatus } from '../models/projectStatus.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  clients: Client[] = [];
  activeProjects: number = 0;
  completedProjects: number = 0;
  timeline: Timeline[] = [];
  status: ProjectStatus[] = []
  constructor(private projS: ProjectService, private router: Router) {

  }
  ngOnInit() {
    this.authorize();
    this.projS.admin.clientSubject.subscribe(resp => {
      this.clients = resp;
    })
    
    this.projS.timelineSubject.subscribe(resp => {
      this.timeline = [];
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].overallTimeline == true)
          this.timeline.push(resp[i]);
      }
      this.getStatus();
    });

  }
  getStatus() {
    this.projS.projectStatusSubject.subscribe(resp => {
      this.status = resp;
      this.getActiveProjects();
    });
  }
  getActiveProjects() {
    this.activeProjects = 0;
    this.completedProjects = 0;
    for (var i = 0; i < this.status.length; i++) {
      for (var j = 0; j < this.timeline.length; j++) {
        if (this.timeline[j].projectStatusId == this.status[i].projectStatusId && this.status[i].stage.localeCompare('active') == 0)
          this.activeProjects++;
        if (this.timeline[j].projectStatusId == this.status[i].projectStatusId && this.status[i].stage.localeCompare('completed') == 0)
          this.completedProjects++;
      }
    }
  }
  authorize() {

    if (sessionStorage.getItem('currentUser') != '2') {
      this.router.navigateByUrl('access-control');
      return;
    }
  }
}
