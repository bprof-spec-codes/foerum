export interface ICommentReacters {
  commentID?: string | null;
  userID?: string;
  choice?: number;
}

export const defaultValue: Readonly<ICommentReacters> = {};
