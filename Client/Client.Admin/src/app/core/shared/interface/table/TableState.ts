export interface TableState {
  pageSize: number;
  currentPage: number;
  total: number;
  sortField?: string;
  sortDirection?: 'asc' | 'desc';
}