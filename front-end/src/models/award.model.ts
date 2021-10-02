export interface IAward {
  awardId?: string | null;
  awardName?: string;
  points?: number;
  iconUrl?: string;
}

export const defaultValue: Readonly<IAward> = {};
