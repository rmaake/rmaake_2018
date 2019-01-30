import { Component, OnInit } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';
import { ProjectService } from '../../services/project.service';
import { ProjectContentService } from '../../services/project-content.service';
import { Default } from '../../models/default.model';
import { ProjectContent } from '../../models/projectContent.model';
import { Employee } from '../../models/employee.model';

@Component({
  selector: 'app-snags',
  templateUrl: './snags.component.html',
  styleUrls: ['./snags.component.css']
})
export class SnagsComponent implements OnInit {
  snag: Default;
  content: ProjectContent;
  id: number = 0;
  projectId: number;
  timelineId: number;
  employee: Employee;
  progress: any;
  message: string = "";
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
      this.getById(this.id);
    }

  }
  ngOnInit() {
   
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
        if (this.snag.projectContentId == resp[i].projectContentId)
          this.content = resp[i];
      }
    });
  }
  snageChange(file) {

    if (this.content.imagePath.length > 1)
      this.service.upload(file, this, this.content.imagePath.split("/")[1]);
    else
      this.service.upload(file, this, '');
  }
  submit() {
    if (this.id > 0) {
      this.service.updateProjectContent(this.id, this.content);
      this.service.updateDefault(this.snag.defaultId, this.snag);
    }
    else
      this.service.addContentDefault(this.snag, this.content);
    this.router.navigateByUrl('timeline/' + this.projectId + '/' + this.timelineId);
  }
  
}
