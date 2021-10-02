export interface ITopicTags {
  topicId?: string | null;
  tagId?: string;
  creationDate?: string | Date;
}

export const defaultValue: Readonly<ITopicTags> = {};
