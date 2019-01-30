import { Employee } from "./employee.model";
import { ClientContact } from "./clientContact.model";
import { Project } from "./project.model";

export class ProjectFile {
  projectFileId: number;
  filePath: string;
  description: string;

  projectId: number;
  employeeId?: number;
  clientContactInfoId?: number;
  employee: Employee;
  client: ClientContact;
  project: Project;
}
