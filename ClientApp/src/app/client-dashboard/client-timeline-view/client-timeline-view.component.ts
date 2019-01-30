import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectService } from '../../services/project.service';
import { Timeline } from '../../models/Timeline.model';
import { ProjectStatus } from '../../models/projectStatus.model';
import { Default } from '../../models/default.model';
import { ProjectContentService } from '../../services/project-content.service';
import { ProjectContent } from '../../models/projectContent.model';
import { environment } from '../../../environments/environment';
import { FeedbackService } from '../../services/Feedback.service';
import { ClientFeedback } from '../../models/clientFeedback.model';
import { ClientContact } from '../../models/clientContact.model';
@Component({
  selector: 'app-client-timeline-view',
  templateUrl: './client-timeline-view.component.html',
  styleUrls: ['./client-timeline-view.component.css']
})
export class ClientTimelineViewComponent implements OnInit {
  id = 0;
  projectId = 0;
  timeline: Timeline;
  status: ProjectStatus[] = [];
  snags: Default[] = [];
  content: ProjectContent[] = [];
  feedbacks: ClientFeedback[] = [];
  feedback: ClientFeedback;
  contact: ClientContact;
  progress: number = 0;
  message = "";
  apiUrl = "";
  constructor(private service: ProjectContentService, private router: Router, private route: ActivatedRoute, private feedS: FeedbackService) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.projectId = Number(this.route.snapshot.paramMap.get('projectid'));
    this.timeline = new Timeline();
    this.feedback = new ClientFeedback();
    this.feedback.imagePath = "";
    this.apiUrl = `${environment.apiUrl}`;
    if (this.id <= 0) {

      this.timeline.projectId = this.projectId;
    }
    else {

      this.getById(this.id);
    }
    //this.feedS.getFeedbacks();
    this.contact = JSON.parse(sessionStorage.getItem('userData')) as ClientContact;
  }
  ngOnInit() {
    this.authorize();
    this.service.service.projectStatusSubject.subscribe(resp => {
      this.status = resp;
    });
    this.feedS.feedbacksSubject.subscribe(resp => {
      this.feedbacks = [];
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].timelineId == this.id)
          this.feedbacks.push(resp[i]);
      }
    });
  }
 

  submit() {
    this.feedback.timelineId = this.id;
    this.feedback.clientContactInfoId = this.contact.clientContactInfoId;
    this.feedS.addFeedback(this.feedback);
  }

  toViewFeedback(id: number) {
    this.router.navigateByUrl('client-feedback/' + id.toString())
  }
  
  getById(id: number) {
    this.service.service.timelineSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].timelineId == id) {
          this.timeline = resp[i];
        }

      }
    });
    this.service.projectContentSubject.subscribe(resp => {
      this.content = [];
      this.snags = [];
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].timelineId == this.id) {
          this.content.push(resp[i]);
          this.getDefaultById(resp[i].projectContentId);
        }

      }

    });
  }
  getDefaultById(id: number) {
    this.service.defaultSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].projectContentId == id)
          this.snags.push(resp[i]);
      }
    });
  }
  snageChange(file) {

    if (this.feedback.imagePath.length > 1)
      this.feedS.upload(file, this, this.feedback.imagePath.split("/")[1]);
    else
      this.feedS.upload(file, this, '');
  }
  authorize() {

    if (sessionStorage.getItem('currentUser') != '1') {
      this.router.navigateByUrl('access-control');
      return;
    }

  }
}
