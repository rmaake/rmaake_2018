import { Project } from "./project.model";
import { EmployeeTimeline } from "./EmployeeTimeline.model";
import { ProjectStatus } from "./projectStatus.model";

export class Timeline {
  timelineId: number;
  stage: string;
  description: string;
  overallTimeline: boolean;
  startDate: Date;
  endDate: Date;
  extension?: Date;

  projectId: number;
  projectStatusId: number;
  projectStatus: ProjectStatus;
  project: Project;
  employeeTimeline: EmployeeTimeline;
}
