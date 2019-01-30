import { ClientContact } from "./clientContact.model";
import { Employee } from "./employee.model";
import { ClientFeedback } from "./clientFeedback.model";

export class FeedbackComment {
  FeedbackCommentId: number;
  description: string;
  date: Date;

  clientFeedbackId: number;
  clientContactInfoId?: number;
  employeeId?: number;
  contact: ClientContact;
  employee: Employee;
  feedback: ClientFeedback;
  className: string;
}
