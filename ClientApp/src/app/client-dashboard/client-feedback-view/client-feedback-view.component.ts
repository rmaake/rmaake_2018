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
  selector: 'app-client-feedback-view',
  templateUrl: './client-feedback-view.component.html',
  styleUrls: ['./client-feedback-view.component.css']
})
export class ClientFeedbackViewComponent implements OnInit {
  id = 0;
  projectId = 0;
  timelineId: number;
  feedback: ClientFeedback;
  contact: ClientContact;
  apiUrl = environment.apiURI;
  constructor(private service: ProjectContentService, private router: Router, private route: ActivatedRoute, private feedS: FeedbackService) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.projectId = Number(this.route.snapshot.paramMap.get('projectid'));
    this.timelineId = Number(this.route.snapshot.paramMap.get('timelineid'));
    this.feedback = new ClientFeedback();
    this.feedback.imagePath = "";
    //this.feedS.getFeedbacks();
    this.contact = JSON.parse(sessionStorage.getItem('userData')) as ClientContact;
  }
  ngOnInit() {
    this.authorize();
    this.getById(this.id);
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
    this.feedS.feedbacksSubject.subscribe(resp => {
        for (var i = 0; i < resp.length; i++) {
          if (resp[i].clientFeedbackId== this.id)
            this.feedback = resp[i];
        }
      });
    
  }
  
  authorize() {

    if (sessionStorage.getItem('currentUser') != '1') {
      this.router.navigateByUrl('access-control');
      return;
    }

  }
}
