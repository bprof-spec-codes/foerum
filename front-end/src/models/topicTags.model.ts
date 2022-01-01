export interface ITopicTags {
  topicID?: string | null;
  tagID?: string;
  creationDate?: string | Date;
}

export const defaultValue: Readonly<ITopicTags> = {};
