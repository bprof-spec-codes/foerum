export interface ITopic {
  topicID: string;
  subjectID?: string;
  userID?: string;
  topicName?: string;
  creationDate: Date;
  offeredCoins?: number;
  attachmentUrl?: string;

  onAdd?: any;
  showAdd?: boolean;
}

export const defaultValue: Readonly<ITopic> = {
  topicID:"",
  creationDate: new Date()
};
