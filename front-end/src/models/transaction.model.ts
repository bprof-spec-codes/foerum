export interface ITransaction {
  transactionId?: string | null;
  source?: string;
  recipient?: string;
  quantity?: number;
  transactionDate?: string | Date;
  reason?: string;
}

export const defaultValue: Readonly<ITransaction> = {};
