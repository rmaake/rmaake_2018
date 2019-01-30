import { ClientContact } from "./clientContact.model";
import { FeedbackComment } from "./FeedbackComment.model";

export class ClientFeedback {
  clientFeedbackId: number;
  title: string;
  imagePath: string;
  voiceNotePath: string;
  description: string;
  date: Date;

  timelineId?: number;
  clientContactInfoId?: number;
  contact: ClientContact;   
  comments: FeedbackComment[];
}
