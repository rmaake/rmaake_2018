import { Client } from "./client.model";
import { Timeline } from "./Timeline.model";
import { EmployeeTimeline } from "./EmployeeTimeline.model";
import { ProjectFile } from "./projectFile.model";

export class Project {
  projectId: number;
  title: string;
  facility: string;
  description: string;
  date: Date;

  clientId: number;
  client: Client;
  timeline: Timeline[];
  employeeTimeline: EmployeeTimeline;
  projectFile: ProjectFile[];
}
