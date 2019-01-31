import { Component, OnInit } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';
import { ProjectService } from '../../services/project.service';
import { ProjectContentService } from '../../services/project-content.service';
import { Default } from '../../models/default.model';
import { ProjectContent } from '../../models/projectContent.model';
import { Employee } from '../../models/employee.model';
import { environment } from '../../../environments/environment.prod';

@Component({
  selector: 'app-new-update',
  templateUrl: './new-update.component.html',
  styleUrls: ['./new-update.component.css']
})
export class NewUpdateComponent implements OnInit {
  snag: Default;
  content: ProjectContent;
  id: number = 0;
  projectId: number;
  timelineId: number;
  employee: Employee;
  progress: any;
  message: string = "";
  url = environment.apiURI;
  constructor(private service: ProjectContentService, private router: Router, private route: ActivatedRoute) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.projectId = Number(this.route.snapshot.paramMap.get('projectid'));
    this.timelineId = Number(this.route.snapshot.paramMap.get('timelineid'));
    this.snag = new Default();
    this.content = new ProjectContent();
    this.content.imagePath = ""
    this.employee = JSON.parse(sessionStorage.getItem('userData')) as Employee;

    if (this.id <= 0) {
      this.content.timelineId = this.timelineId;
      this.content.employeeId = this.employee.employeeId;
    }
    else {
      //this.getById(this.id);
      this.getContentById();
    }

  }
  ngOnInit() {
    this.authorize();
  }
  getById(id: number) {
    this.service.defaultSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (this.id == resp[i].defaultId) {
          this.snag = resp[i];
          this.getContentById();
        }   
      }
    });
  }
  getContentById() {
    this.service.projectContentSubject.subscribe(resp => {
      for (var i = 0; i < resp.length; i++) {
        if (this.id == resp[i].projectContentId)
          this.content = resp[i];
      }
    });
  }
  snageChange(file) {

    if (this.content.imagePath.length > 1)
      this.service.uploadContent(file, this, this.content.imagePath.split("/")[1]);
    else
      this.service.uploadContent(file, this, '');
  }
  submit() {
    if (this.id > 0) {
      this.service.updateProjectContent(this.id, this.content);
    }
    else
      this.service.addProjectContent(this.content);
    this.router.navigateByUrl('timeline/' + this.projectId + '/' + this.timelineId);
  }
  authorize() {
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
