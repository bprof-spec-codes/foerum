export interface ICommentReacters {
  commentId?: string | null;
  userId?: string;
  choice?: number;
}

export const defaultValue: Readonly<ICommentReacters> = {};
