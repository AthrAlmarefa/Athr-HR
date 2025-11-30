import { Injectable } from "@angular/core";
import { PaginatedResponse } from "../interface/table/PaginatedResponse";
import { BehaviorSubject, combineLatest, map, Observable } from "rxjs";
import { TableState } from "../interface/table/TableState";

@Injectable({
  providedIn: "root",
})
export class TableService<T> {
  private readonly tableState = new BehaviorSubject<TableState>({
    pageSize: 10,
    currentPage: 1,
    total: 0,
  });

  private readonly dataSource = new BehaviorSubject<T[]>([]);
  public paginatedData$: Observable<PaginatedResponse<T>>;

  constructor() {
    this.paginatedData$ = combineLatest([
      this.dataSource,
      this.tableState,
    ]).pipe(
      map(([data, state]) => ({
        data: data,
        total: state.total,
        currentPage: state.currentPage,
        pageSize: state.pageSize,
        totalPages: Math.ceil(state.total / state.pageSize),
      }))
    );
  }

  setData(data: T[]): void {
    this.dataSource.next(data);
  }

  getData(): Observable<T[]> {
    return this.dataSource.asObservable();
  }

  setTableState(state: Partial<TableState>): void {
    const currentState = this.tableState.value;
    this.tableState.next({ ...currentState, ...state });
  }

  getTableState(): Observable<TableState> {
    return this.tableState.asObservable();
  }

  paginateData(
    data: T[],
    page: number,
    pageSize: number
  ): PaginatedResponse<T> {
    const total = data.length;
    const totalPages = Math.ceil(total / pageSize);
    const startIndex = (page - 1) * pageSize;
    const endIndex = Math.min(startIndex + pageSize, total);

    const paginatedData = data.slice(startIndex, endIndex);

    return {
      data: paginatedData,
      total,
      currentPage: page,
      pageSize,
      totalPages,
    };
  }

  reset(): void {
    this.tableState.next({
      pageSize: 10,
      currentPage: 1,
      total: 0,
    });
    this.dataSource.next([]);
  }
}
