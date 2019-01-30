import { Employee } from "./employee.model";
import { Project } from "./project.model";
import { Timeline } from "./Timeline.model";

export class EmployeeTimeline{
  employeeTimelineId: number;
  employeeId?: number;
  timelineId?: number;
  projectId?: number;
  employeeRoleId?: number;

  employee: Employee;
  project: Project;
  timeline: Timeline;
}
