export interface EntityVideoGame {
  id: string;
  title: string;
  quantity: number;
  price: number;
  isAvailable: boolean;
  dateAdded: Date;
  dateUpdated: Date;
  genreId: string;
  platformId: string;
}
