export interface IYear {
  yearID?: string | null;
  yearName?: string;
}

export const defaultValue:Readonly<IYear>={
  yearID: null
}
