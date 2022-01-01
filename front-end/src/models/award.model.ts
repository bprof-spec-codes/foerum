export interface IAward {
  awardID?: string | null;
  awardName?: string;
  points?: number;
  iconUrl?: string;
}

export const defaultValue: Readonly<IAward> = {};
