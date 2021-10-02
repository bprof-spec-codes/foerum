export interface IComment {
  commentId?: string | null;
  topicId?: string;
  userId?: string;
  content?: string;
  creationDate?: string | Date;
  replyToCommentId?: string | null;
  coinReward?: number | null;
  attachmentUrl?: string;
  reactionCount?: number;
  isEdited?: string | null; // prev state id
  isActive?: boolean;
}

export const defaultValue: Readonly<IComment> = {};
