import { CommonModule, DecimalPipe } from "@angular/common";
import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnDestroy,
  Output,
  SimpleChanges,
} from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import {
  OwlDateTimeModule,
  OwlNativeDateTimeModule,
} from "@danielmoncada/angular-datetime-picker";

import { SvgIconComponent } from "../../../../shared/components/ui/svg-icon/svg-icon.component";
import { MyPaginationComponent } from "../pagination/pagination.component";
import { TableConfigs } from "../../interface/table/TableConfigs";
import { TableClickedAction } from "../../interface/table/TableClickedAction";
import { PageSizeOptions } from "../../interface/table/PageSizeOptions";
import { TableState } from "../../interface/table/TableState";
import { Subject, takeUntil } from "rxjs";
import { TableService } from "../../service/Table.service";

@Component({
  selector: "Myapp-table",
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    MyPaginationComponent,
    SvgIconComponent,
  ],
  providers: [DecimalPipe],
  templateUrl: "./table.component.html",
  styleUrls: ["./table.component.scss"],
})
export class MyTableComponent<T> implements OnChanges, OnDestroy {
  @Input() tableConfig: TableConfigs;
  @Input() pageSize: number = 10;
  @Input() total: number = 0;
  @Input() currentPage: number = 1;

  @Output() action = new EventEmitter<TableClickedAction>();
  @Output() pageChange = new EventEmitter<number>();
  @Output() pageSizeChange = new EventEmitter<number>();

  paginatedData: any[] = [];
  tableState: TableState = {
    pageSize: 10,
    currentPage: 1,
    total: 0,
  };

  protected destroy$ = new Subject<void>();

  public pageSizeOptions: PageSizeOptions[] = [
    { title: 10, value: 10 },
    { title: 15, value: 15 },
    { title: 25, value: 25 },
    { title: 50, value: 50 },
    { title: 100, value: 100 },
  ];

  constructor(protected readonly tableService: TableService<T>) {
    this.subscribeToTableState();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes["pageSize"]?.currentValue) {
      this.tableService.setTableState({ pageSize: this.pageSize });
    }

    if (changes["currentPage"]?.currentValue) {
      this.tableService.setTableState({ currentPage: this.currentPage });
    }
  }

  protected subscribeToTableState(): void {
    this.tableService.paginatedData$
      .pipe(takeUntil(this.destroy$))
      .subscribe((paginatedResponse: any) => {
        this.paginatedData = paginatedResponse.data;
        this.tableState = {
          pageSize: paginatedResponse.pageSize,
          currentPage: paginatedResponse.currentPage,
          total: paginatedResponse.total,
        };
      });
  }

  protected handleDataChange(data: T[]): void {
    this.tableService.setData(data);
  }

  get paginateObj() {
    const totalItems = Math.max(0, this.tableState.total);
    const totalPages = this.totalPages;
    const startIndex =
      (this.tableState.currentPage - 1) * this.tableState.pageSize;
    const endIndex =
      Math.min(startIndex + this.paginatedData.length, totalItems) - 1;

    return {
      current_page: this.tableState.currentPage,
      total_items: totalItems,
      total_pages: totalPages,
      start_index: startIndex,
      end_index: endIndex,
      end_page: totalPages,
      pages: this.getPagesArray(),
    };
  }

  private getPagesArray(): number[] {
    const totalPages = this.totalPages;
    if (totalPages <= 0) return [];
    return Array.from({ length: totalPages }, (_, i) => i + 1);
  }

  setPage(page: number) {
    this.pageChange.emit(page);
  }

  changePageSize(newPageSize: number) {
    this.pageSizeChange.emit(newPageSize);
  }

  get totalPages(): number {
    return this.tableState.pageSize > 0
      ? Math.ceil(this.tableState.total / this.tableState.pageSize)
      : 0;
  }

  handleAction(action: any, details: any) {
    this.action.emit({
      action_to_perform: action.action_to_perform,
      data: details,
    });
  }

  trackByIndex(index: number): any {
    return index;
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
