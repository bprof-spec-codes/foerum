export interface ISubject {
  subjectId?: string | null;
  yearId?: string;
  subjectName?: string;
  isPrivate?: boolean;
  inviteKeyIfPrivate?: string;
}

export const defaultValue: Readonly<ISubject> = {
  subjectId: null,
  isPrivate: false,
};
