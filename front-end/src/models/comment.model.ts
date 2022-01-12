export interface IComment {
  commentID?: string | null;
  topicID?: string;
  userID?: string;
  content?: string;
  creationDate?: string | Date;
  replyToCommentId?: string | null;
  coinReward?: number | null;
  attachmentUrl?: string;
  reactionCount?: number;
  isEdited?: string | null; // prev state id
  isActive?: boolean;
}
