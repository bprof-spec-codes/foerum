export interface ITopic {
  topicID: string;
  subjectID?: string;
  yearID?: string;
  userID?: string;
  topicName?: string;
  creationDate?: string | Date;
  offeredCoins?: number;
  attachmentUrl?: string;

  onAdd?: any;
  showAdd?: boolean;
}

export const defaultValue: Readonly<ITopic> = {
  topicID:""
};
