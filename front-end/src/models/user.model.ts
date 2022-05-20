export interface IUser {
  id?: string | null;
  email?: string;
  password?: string;
  fullName?: string;
  nikCoin?: number;
  startYear?: number;
  isActive: boolean;
  role?: [];
  walletAddress?: string;
}

export const defaultValue: Readonly<IUser> = {
  id: null,
  isActive: false,
};
