export interface IUser {
  id?: string | null;
}

export const defaultValue: Readonly<IUser> = {
  id: null,
};
