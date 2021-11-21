export interface ITopic {
  topicID?: string | null;
  subjectID?: string;
  userID?: string;
  topicName?: string;
  creationDate?: string | Date;
  offeredCoins?: number;
  attachmentUrl?: string;

  onAdd?: any;
  showAdd?: boolean;
}

export const defaultValue: Readonly<ITopic> = {};
