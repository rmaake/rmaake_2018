import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';

import { AuthService } from '../../services/authentication.service';
import { Employee } from '../../models/employee.model';

import html2canvas from 'html2canvas';
import * as jspdf from 'jspdf';
import { ProjectContentService } from '../../services/project-content.service';
import { ProjectContent } from '../../models/projectContent.model';
import { Project } from '../../models/project.model';
import { ProjectService } from '../../services/project.service';
import { Timeline } from '../../models/Timeline.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-report',
  templateUrl: './view-report.component.html',
  styleUrls: ['./view-report.component.css']
})
export class ViewReportComponent implements OnInit {

  today: Date;
  report = '';
  timelines: Timeline[] = [];
  employee: Employee;
  project: Project;
  projectFiles: ProjectContent[];
  @ViewChild('cover') cover: ElementRef;
  @Input() projectId: number;
  month = ['January', 'February', 'March', 'April', 'May', 'June',
  'July', 'August', 'September', 'October', 'November', 'December'];
  day = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday',
  'Saturday', 'Sunday'];
id = 0;
  constructor(
    private authService: AuthService,
    private projectFileService: ProjectContentService,
    private service: ProjectService, private route: ActivatedRoute
  ) { 
    this.id = Number(this.route.snapshot.paramMap.get('id'));
  }

  ngOnInit() {
    this.today = new Date();
    this.employee = JSON.parse(sessionStorage.getItem('userData')) as Employee;
    this.getTimelineOfId(this.id);
  }

  /*getFullProjectFiles(): void {
    this.projectFileService.getProjectsFiles()
      .subscribe(projectsFiles => {
        this.projectFiles = projectsFiles.filter(projectFile => projectFile.projectId === projectId);
      });
    /*this.projectFiles = [
      {
        projectContentId: 1,
        projectId: 1,
        description: 'Blah Blah Blah',
        filePath: 'assets/annual.png',
      },
      {
        projectFileId: 2,
        projectId: 2,
        description: 'Blah Blah Blah',
        filePath: 'assets/admin.png',
      },
      {
        projectFileId: 3,
        projectId: 3,
        description: 'Blah Blah Blah',
        filePath: 'assets/background.png',
      },
      {
        projectFileId: 4,
        projectId: 4,
        description: 'Blah Blah Blah',
        filePath: 'assets/budget.png',
      }
    ];
  }*/

  /*getWeeklyProjectFiles(): void {
    this.projectFileService.projectContentSubject
      .subscribe(projectsFiles => {
        this.projectFiles = projectsFiles.filter(projectFile => {
          if (projectFile.projectId === projectId) {
            const date = new Date();
            date.setDate(-7);
            if (projectFile.date > date) {
              return projectFile;
            }
          }
        });
      });

    /*this.projectFiles = [
      {
        projectFileId: 1,
        projectId: 1,
        description: 'Blah Blah Blah',
        filePath: 'assets/annual.png',
      },
      {
        projectFileId: 2,
        projectId: 2,
        description: 'Blah Blah Blah',
        filePath: 'assets/admin.png',
      },
      {
        projectFileId: 3,
        projectId: 3,
        description: 'Blah Blah Blah',
        filePath: 'assets/background.png',
      },
      {
        projectFileId: 4,
        projectId: 4,
        description: 'Blah Blah Blah',
        filePath: 'assets/budget.png',
      }
    ];
  }*/

  downloadFullReportPDF() {
    this.report = 'FULL REPORT';
    //this.getFullProjectFiles();
    const pdf = new jspdf('p', 'mm', 'a4');
    html2canvas(this.cover.nativeElement).then(canvas => {
      const imgWidth = 208;
      const imgHeight = canvas.height * imgWidth / canvas.width;

      const contentData = canvas.toDataURL('image/png');
      pdf.addImage(contentData, 'PNG', 0, 0, imgWidth, imgHeight);
    });

    // let pos = 0;
    // let count = 0;
    // pdf.addPage();
    // for (const file of this.projectFiles) {
    //   if (count === 3) {
    //     pos = 0;
    //     count = 0;s
    //     pdf.addPage();
    //   }

    //   await html2canvas(document.getElementById(`content${this.id}`)).then(canvas => {
    //     const imgWidth = 208;
    //     const imgHeight = canvas.height * imgWidth / canvas.width;

    //     const contentData = canvas.toDataURL('image/png');
    //     pdf.addImage(contentData, 'PNG', 0, pos, imgWidth, imgHeight);
    //     pos += (imgHeight + 10);
    //     count++;
    //   });
    // }
    pdf.save('Project Report.pdf');
  }

  /*async downloadWeeklyReportPDF() {
    this.report = 'UPDATE';
    this.getWeeklyProjectFiles();
    const pdf = new jspdf('p', 'mm', 'a4');
    await html2canvas(this.cover.nativeElement).then(canvas => {
      const imgWidth = 208;
      const imgHeight = canvas.height * imgWidth / canvas.width;

      const contentData = canvas.toDataURL('image/png');
      pdf.addImage(contentData, 'PNG', 0, 0, imgWidth, imgHeight);
    });

    let pos = 0;
    let count = 0;
    pdf.addPage();
    for (const file of this.projectFiles) {
      if (count === 3) {
        pos = 0;
        count = 0;
        pdf.addPage();
      }

      await html2canvas(document.getElementById(`content${file.projectId}`)).then(canvas => {
        const imgWidth = 208;
        const imgHeight = canvas.height * imgWidth / canvas.width;

        const contentData = canvas.toDataURL('image/png');
        pdf.addImage(contentData, 'PNG', 0, pos, imgWidth, imgHeight);
        pos += (imgHeight + 10);
        count++;
      });
    }
    pdf.save('Weekly Project Report.pdf');
  }*/
  getTimelineOfId(projecId: number)
  {
    this.service.timelineSubject.subscribe(resp=>{
      for(var i = 0; i < resp.length; i++)
      {
        if (resp[i].projectId == projecId)
        this.timelines.push(resp[i]);
      }
      this.getContentOfTimelines();
    });
  }
  getContentOfTimelines()
  {
    this.projectFileService.projectContentSubject.subscribe(resp=>{
      this.projectFiles = [];
      for(var i = 0; i < resp.length; i++)
      {
        for(var j = 0; j < this.timelines.length; j++)
        {
          if (resp[i].timelineId == this.timelines[j].timelineId)
            this.projectFiles.push(resp[i]);
        }
      }
    });
    this.downloadFullReportPDF();
  }

}
