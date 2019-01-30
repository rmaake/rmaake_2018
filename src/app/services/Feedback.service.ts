import { Injectable } from '@angular/core';

//import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { RequestOptions, } from '@angular/http';
import { Headers } from '@angular/http';
import { Http } from '@angular/http';
import { Location } from '@angular/common';
import { HttpRequest, HttpEventType, HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ClientFeedback } from '../models/clientFeedback.model';
import { FeedbackComment } from '../models/FeedbackComment.model';
import { ClientTimelineViewComponent } from '../client-dashboard/client-timeline-view/client-timeline-view.component';
import { Employee } from '../models/employee.model';
import { ClientContact } from '../models/clientContact.model';


@Injectable()
export class FeedbackService {

  public feedbacksSubject: BehaviorSubject<ClientFeedback[]>;
  public commentsSubject: BehaviorSubject<FeedbackComment[]>;
  private url = 'http://localhost:55079/api/';
  private options: RequestOptions;

  constructor(private http: Http, public location: Location, public router: Router, private httpClient: HttpClient) {
    const headers = new Headers({
      'Content-Type': 'application/json',
    });
    this.feedbacksSubject = new BehaviorSubject<ClientFeedback[]>([]);
    this.commentsSubject = new BehaviorSubject<FeedbackComment[]>([]);
    this.options = new RequestOptions({ headers: headers, withCredentials: true });
    this.getFeedbacks();
    this.getComments();
  }
  /*Manage Feedbacks*/
  getFeedbacks() {
    this.http.get(this.url + 'clientfeedback', this.options).subscribe(resp => {
      this.feedbacksSubject.next(resp.json() as ClientFeedback[]);
    }, err => console.log(err));
  }
  addFeedback(feed: ClientFeedback) {
    this.http.post(this.url + 'clientfeedback', feed, this.options).subscribe(resp => {
      this.getFeedbacks();
      alert("Feedback sent");
    }, err => console.log(err));
  }
  updateFeedback(id: number, feed: ClientFeedback) {
    this.http.put(this.url + 'clientfeedback/' + id.toString(), feed, this.options).subscribe(resp => {
    }, err => console.log(err));
  }
  removeFeedback(id: number) {
    this.http.delete(this.url + 'clientfeedback/' + id.toString(), this.options).subscribe(resp => {

    }, err => console.log(err));
  }
  /*Manage Comments to feedbacks */
  getComments() {
    this.http.get(this.url + 'feedbackcomment', this.options).subscribe(resp => {
      this.commentsSubject.next(resp.json() as FeedbackComment[]);
    }, err => console.log(err));
  }
  addFeebackComment(comment: FeedbackComment) {
    var tmp = sessionStorage.getItem('currentUser');

    if (tmp == '2')
      comment.employeeId = (JSON.parse(sessionStorage.getItem('userData')) as Employee).employeeId;
    else
      comment.clientContactInfoId = (JSON.parse(sessionStorage.getItem('userData')) as ClientContact).clientContactInfoId;
    this.http.post(this.url + 'feedbackcomment', comment, this.options).subscribe(resp => {
      comment = resp.json() as FeedbackComment;
      this.getComments();
      //alert("Feedback sent");
    }, err => console.log(err));
  }
  updateFeedbackComment(id: number, comment: FeedbackComment) {
    this.http.put(this.url + 'feedbackcomment/' + id.toString(), comment, this.options).subscribe(resp => {
    }, err => console.log(err));
  }
  removeFeedbackComment(id: number) {
    this.http.delete(this.url + 'feedbackcomment/' + id.toString(), this.options).subscribe(resp => {

    }, err => console.log(err));
  }

  /*Manage Uploads*/
  upload(files, obj: ClientTimelineViewComponent, path: string) {
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
        obj.feedback.imagePath = event.body.toString();
      }

    });
  }
}
