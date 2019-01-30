import { Component, OnInit } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';
import { Project } from '../../models/project.model';
import { Client } from '../../models/client.model';
import { ClientContact } from '../../models/clientContact.model';
import { Timeline } from '../../models/Timeline.model';
import { ProjectStatus } from '../../models/projectStatus.model';
import { ProjectService } from '../../services/project.service';
import { AuthService } from '../../services/authentication.service';

@Component({
  selector: 'app-client-view',
  templateUrl: './client-view.component.html',
  styleUrls: ['./client-view.component.css']
})
export class ClientViewComponent implements OnInit {

  id = 0;
  project: Project;
  client: Client;
  contact: ClientContact;
  timeline: Timeline[] = [];
  duration: Timeline;
  status: ProjectStatus[] = [];
  durationProgress: number;
  projectProgress: number = 0;
  tabNumber = 0;
  constructor(private service: ProjectService, private route: ActivatedRoute, private router: Router, private authS: AuthService) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.project = new Project();
    this.client = new Client();
    this.duration = new Timeline();
    this.authS.currentClient.subscribe(resp => {
      this.contact = resp;
      this.getById(this.id);
      this.getClientById(this.contact.clientId);
    });
    
    
    
  }
  ngOnInit() {
    this.authorize();
    this.getById(this.id);
    this.service.projectStatusSubject.subscribe(resp => {
      this.status = resp;
      this.getProjectProgress();
    });
  }
  getById(id: number) {
    this.service.projectsSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].projectId == id) {
          this.project = resp[i];
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
    catch (e) { }
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
  
  toViewTimeline(id: number) {
    this.router.navigateByUrl('client-timeline-view/' + this.id.toString() + '/' + id.toString());
  }
  authorize() {

    if (sessionStorage.getItem('currentUser') != '1') {
      this.router.navigateByUrl('access-control');
      return;
    }

  }
  
}
