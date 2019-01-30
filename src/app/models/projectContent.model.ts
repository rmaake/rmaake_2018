import { Employee } from "./employee.model";
import { ClientContact } from "./clientContact.model";
import { Timeline } from "./Timeline.model";

export class ProjectContent{
  projectContentId: number;
  imagePath: string;
  voiceNotePath: string;
  description: string;
  date: Date;

  timelineId: number;
  employeeId?: number;
  clientContactInfoId?: number;
  employee: Employee;
  client: ClientContact;
  timeline: Timeline;
}
