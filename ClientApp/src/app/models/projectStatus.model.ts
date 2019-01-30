import { Timeline } from "./Timeline.model";

export class ProjectStatus {
  projectStatusId: number;
  description: string;
  stage: string;

  timeline: Timeline[];
}
