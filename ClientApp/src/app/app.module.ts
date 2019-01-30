import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AuthService } from './services/authentication.service';
import { HttpModule } from '@angular/http';
import { LogoutComponent } from './logout/logout.component';
import { ProjectComponent } from './project/project.component';
import { AdminComponent } from './admin/admin.component';
import { RfqComponent } from './rfq/rfq.component';
import { ReportsComponent } from './reports/reports.component';
import { FinanceComponent } from './finance/finance.component';
import { QuotesComponent } from './quotes/quotes.component';
import { AdminEmployeeComponent } from './admin-components/admin-employee/admin-employee.component';
import { AdminEmployeeEditComponent } from './admin-components/admin-employee-edit/admin-employee-edit.component';
import { AdminService } from './services/admin.service';
import { AdminClientComponent } from './admin-components/admin-client/admin-client.component';
import { AdminClientEditComponent } from './admin-components/admin-client-edit/admin-client-edit.component';
import { AdminSupplierComponent } from './admin-components/admin-supplier/admin-supplier.component';
import { AdminSupplierEditComponent } from './admin-components/admin-supplier-edit/admin-supplier-edit.component';
import { ProjectEditComponent } from './project/project-edit/project-edit.component';
import { ProjectService } from './services/project.service';
import { ProjectViewComponent } from './project/project-view/project-view.component';
import { TimelineComponent } from './project/timeline/timeline.component';
import { SnagsComponent } from './project/snags/snags.component';
import { ProjectContentService } from './services/project-content.service';
import { ClientDashboardComponent } from './client-dashboard/client-dashboard.component';
import { ClientProjectComponent } from './client-dashboard/client-project/client-project.component';
import { ClientViewComponent } from './client-dashboard/client-view/client-view.component';
import { ClientTimelineViewComponent } from './client-dashboard/client-timeline-view/client-timeline-view.component';
import { FeedbackService } from './services/Feedback.service';
import { ClientFeedbackComponent } from './client-dashboard/client-feedback/client-feedback.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { NotAuthorizedComponent } from './not-authorized/not-authorized.component';
import { EmployeeProfileComponent } from './employee-profile/employee-profile.component';
import { EmployeeProfileService } from './services/employeeProfile.service';
import { BaseTemplateComponent } from './base-template/base-template.component';
import { UnderConstructionComponent } from './under-construction/under-construction.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LogoutComponent,
    ProjectComponent,
    AdminComponent,
    RfqComponent,
    ReportsComponent,
    FinanceComponent,
    QuotesComponent,
    AdminEmployeeComponent,
    AdminEmployeeEditComponent,
    AdminClientComponent,
    AdminClientEditComponent,
    AdminSupplierComponent,
    AdminSupplierEditComponent,
    ProjectEditComponent,
    ProjectViewComponent,
    TimelineComponent,
    SnagsComponent,
    ClientDashboardComponent,
    ClientProjectComponent,
    ClientViewComponent,
    ClientTimelineViewComponent,
    ClientFeedbackComponent,
    NotFoundComponent,
    NotAuthorizedComponent,
    EmployeeProfileComponent,
    LoginComponent,
    BaseTemplateComponent,
    UnderConstructionComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'dashboard', component: HomeComponent },
      { path: 'projects', component: ProjectComponent },
      { path: 'project/:id', component: ProjectViewComponent },
      { path: 'project-edit', component: ProjectEditComponent },
      { path: 'project-edit/:id', component: ProjectEditComponent },
      { path: 'timeline/:projectid/:id', component: TimelineComponent },
      { path: 'timeline/:projectid', component: TimelineComponent },
      { path: 'admin', component: AdminComponent },
      { path: 'snags/:projectid/:timelineid', component: SnagsComponent },
      { path: 'snags/:projectid/:timelineid/:id', component: SnagsComponent },
      { path: 'rfq', component: RfqComponent },
      { path: 'reports', component: ReportsComponent },
      { path: 'finance', component: FinanceComponent },
      { path: 'quotes', component: QuotesComponent },
      { path: 'admin-employee', component: AdminEmployeeComponent },
      { path: 'admin-employee-edit', component: AdminEmployeeEditComponent },
      { path: 'admin-employee-edit/:id', component: AdminEmployeeEditComponent },
      { path: 'admin-client-edit', component: AdminClientEditComponent },
      { path: 'admin-client-edit/:id', component: AdminClientEditComponent },
      { path: 'admin-client', component: AdminClientComponent },
      { path: 'admin-supplier', component: AdminSupplierComponent },
      { path: 'admin-supplier-edit', component: AdminSupplierEditComponent },
      { path: 'admin-supplier-edit/:id', component: AdminSupplierEditComponent },
      { path: 'client-dashboard', component: ClientDashboardComponent },
      { path: 'client-project', component: ClientProjectComponent },
      { path: 'client-view/:id', component: ClientViewComponent },
      { path: 'client-timeline-view/:projectid/:id', component: ClientTimelineViewComponent },
      { path: 'client-feedback/:id', component: ClientFeedbackComponent },
      { path: 'client-feedback', component: ClientFeedbackComponent },
      { path: 'logout', component: LogoutComponent },
      { path: 'access-control', component: NotAuthorizedComponent },
      { path: 'employee-profile', component: EmployeeProfileComponent },
      { path: '**', component: NotFoundComponent },
    ])
  ],
  providers: [AuthService, AdminService, ProjectService, ProjectContentService, FeedbackService, EmployeeProfileService],
  bootstrap: [AppComponent]
})
export class AppModule { }
