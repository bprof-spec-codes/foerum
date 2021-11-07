export interface ITopic {
  topicId?: string | null;
  subjectId?: string;
  userId?: string;
  topicName?: string;
  creationDate?: string | Date;
  offeredCoins?: number;
  attachmentUrl?: string;

  onAdd?: any;
  showAdd?: boolean;
}

export const defaultValue: Readonly<ITopic> = {};
