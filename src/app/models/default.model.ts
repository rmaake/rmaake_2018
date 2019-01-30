import { ProjectContent } from "./projectContent.model";

export class Default {
  defaultId: number;
  title: string;
  description: string;
  date: Date;

  projectContentId: number;
  projectContent: ProjectContent;
}
