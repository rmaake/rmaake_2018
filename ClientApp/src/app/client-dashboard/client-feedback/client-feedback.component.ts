import { Component, OnInit } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';
import { FeedbackService } from '../../services/Feedback.service';
import { AdminService } from '../../services/admin.service';
import { ClientFeedback } from '../../models/clientFeedback.model';
import { FeedbackComment } from '../../models/FeedbackComment.model';
import { Employee } from '../../models/employee.model';
import { ClientContact } from '../../models/clientContact.model';

@Component({
  selector: 'app-client-feedback',
  templateUrl: './client-feedback.component.html',
  styleUrls: ['./client-feedback.component.css']
})
export class ClientFeedbackComponent implements OnInit {
  feedbacks: ClientFeedback[] = [];
  comments: FeedbackComment[] = [];
  comment: FeedbackComment;
  selectedComments: FeedbackComment[] = [];
  contacts: ClientContact[] = [];
  employees: Employee[] = [];
  tabNumber = 0;
  selected: ClientFeedback;
  constructor(private router: Router, private service: FeedbackService, private adminS: AdminService, private route: ActivatedRoute) {
    this.comment = new FeedbackComment();
    this.tabNumber = Number(this.route.snapshot.paramMap.get('id'));
    this.selected = new ClientFeedback();
  }
  ngOnInit() {
    this.authorize();
    this.service.feedbacksSubject.subscribe(resp => {
      var tmp = JSON.parse(sessionStorage.getItem('userData')) as ClientContact;
      this.feedbacks = [];
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].clientContactInfoId == tmp.clientContactInfoId)
          this.feedbacks.push(resp[i]);

      }
      
      if (this.feedbacks.length > 0 && this.tabNumber <= 0) {
        this.tabNumber = resp[0].clientFeedbackId;
        this.comment.clientFeedbackId = this.tabNumber;
        
      }
      else {
        this.comment.clientFeedbackId = this.tabNumber;
        
      }
      this.getSelected(this.tabNumber);
      this.getComments();
    });

    this.adminS.clientContactSubject.subscribe(resp => {
      this.contacts = resp;
    });
    this.adminS.employeeSubject.subscribe(resp => {
      this.employees = resp;
    });
  }

  submit() {
    this.service.addFeebackComment(this.comment);
    this.comment.description = "";
  }

  getSelectedComments(id: number) {
    this.selectedComments = [];
    for (var i = 0; i < this.comments.length; i++) {
      if (this.comments[i].clientFeedbackId == id) {
        if (this.comments[i].clientContactInfoId)
          this.comments[i].className = "client";
        else
          this.comments[i].className = "nrp";
        this.selectedComments.push(this.comments[i]);
        
      }
       
    }
  }
  getName(comment: FeedbackComment) {
    
    if (comment.clientContactInfoId) {
      for (var i = 0; i < this.contacts.length; i++) {
        if (this.contacts[i].clientContactInfoId == comment.clientContactInfoId)
          return this.contacts[i].firstName + " " + this.contacts[i].lastName;
      }
    }
    else {
      for (var i = 0; i < this.employees.length; i++) {
        if (this.employees[i].employeeId == comment.employeeId)
          return this.employees[i].firstName + " " + this.employees[i].lastName;
      }
    }
    return "";
  }
  getComments() {
    this.service.commentsSubject.subscribe(resp => {
      this.comments = resp;
      this.getSelectedComments(this.tabNumber);
    });
  }
  getSelected(id: number) {
    this.service.feedbacksSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (resp[i].clientFeedbackId == id)
          this.selected = resp[i];
      }
    });
  }
  switchTab(id: number) {
    document.getElementById(this.tabNumber.toString()).className = "";
    document.getElementById(id.toString()).className = "active";
    
    this.tabNumber = id;
    this.comment.clientFeedbackId = this.tabNumber;
    this.getSelectedComments(this.tabNumber);
    this.getSelected(this.tabNumber);
  }
  authorize() {
    if (sessionStorage.getItem('currentUser') == '1')
      return;
    var tmpUser = JSON.parse(sessionStorage.getItem('userData')) as Employee;
    if (sessionStorage.getItem('currentUser') != '2') {
      this.router.navigateByUrl('access-control');
      return;
    }
    var read = false;
    var write = false;
    var dlt = false;
    var permission = tmpUser.accessCode.split(".");
    for (var i = 0; i < permission.length; i++) {
      if (permission[i].localeCompare('admin:read') == 0 || permission[i].localeCompare('projects:read') == 0)
        read = true;
      if (permission[i].localeCompare('admin:write') == 0 || permission[i].localeCompare('projects:write') == 0)
        write = true;
      if (permission[i].localeCompare('admin:delete') == 0 || permission[i].localeCompare('projects:delete') == 0)
        dlt = true;
    }
    if (read == false && write == false && dlt == false) {
      this.router.navigateByUrl('access-control');
      return;
    }
  }
}
