export interface ISubject {
  subjectID?: string | null;
  yearId?: string;
  subjectName?: string;
  isPrivate?: boolean;
  inviteKeyIfPrivate?: string;
}

export const defaultValue: Readonly<ISubject> = {
  subjectID: null,
  isPrivate: false,
};
