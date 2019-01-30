import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectService } from '../../services/project.service';
import { Timeline } from '../../models/Timeline.model';
import { ProjectStatus } from '../../models/projectStatus.model';
import { Default } from '../../models/default.model';
import { ProjectContentService } from '../../services/project-content.service';
import { ProjectContent } from '../../models/projectContent.model';
import { environment } from '../../../environments/environment';
import { ClientFeedback } from '../../models/clientFeedback.model';
import { FeedbackService } from '../../services/Feedback.service';
@Component({
  selector: 'app-timeline',
  templateUrl: './timeline.component.html',
  styleUrls: ['./timeline.component.css']
})
export class TimelineComponent implements OnInit {
  id = 0;
  projectId = 0;
  timeline: Timeline;
  status: ProjectStatus[] = [];
  snags: Default[] = [];
  content: ProjectContent[] = [];
  apiUrl = "";
  feedbacks: ClientFeedback[] = [];
  constructor(private service: ProjectContentService, private router: Router, private route: ActivatedRoute, private feedS: FeedbackService) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.projectId = Number(this.route.snapshot.paramMap.get('projectid'));
    this.timeline = new Timeline();
    this.apiUrl = `${ environment.apiUrl }`;
    if (this.id <= 0) {
      
      this.timeline.projectId = this.projectId;
    }
    else {
     
      this.getById(this.id);
    }
    
  }
  ngOnInit() {
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
  toViewFeedback(id: number) {
    this.router.navigateByUrl('client-feedback/' + id.toString())
  }
  toAddSnag() {
    this.router.navigateByUrl('snags/' + this.projectId.toString() + '/' + this.id.toString());
  }
  toViewSnag(id: number) {
    this.router.navigateByUrl('snags/' + this.projectId.toString() + '/' + this.id.toString() + '/' + id.toString());
  }
  toDeleteSnag(id: number) {
    this.service.deleteProjectContent(id);
  }
  statusChange(value: any) {


    //this.timeline.projectStatusId = value as number;
  }

  submit() {
    if (this.id <= 0) {
      this.service.service.addTimeline(this.projectId, this.timeline);
    }
    else {
      this.service.service.updateTimeline(this.id, this.timeline);
    }
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

}
