import {
  Component,
  OnInit,
  OnDestroy,
  inject,
  EventEmitter,
  Output,
} from "@angular/core";
import { CategoryFacade } from "../category.facade";
import { CategoryResponse } from "../../../shared/services/AthrHR";
import { TableService } from "../../shared/service/Table.service";
import { combineLatest, Subject, takeUntil } from "rxjs";
import { MyTableComponent } from "../../shared/ui/table/table.component";
import { TableConfigs } from "../../shared/interface/table/TableConfigs";
import { TableClickedAction } from "../../shared/interface/table/TableClickedAction";

@Component({
  selector: "app-category-list",
  imports: [MyTableComponent],
  templateUrl: "./category-list.component.html",
  styleUrl: "./category-list.component.scss",
})
export class CategoryListComponent implements OnInit, OnDestroy {
  @Output() editCategory = new EventEmitter<any>();
  private readonly destroy$ = new Subject<void>();
  tableConfig: TableConfigs;
  pageSize = 10;
  total: number = 0;
  currentPage: number = 1;

  facade = inject(CategoryFacade);
  tableService = inject(TableService<CategoryResponse>);

  ngOnInit(): void {
    combineLatest([
      this.facade.categories$,
      this.facade.total$,
      this.facade.currentPage$,
    ])
      .pipe(takeUntil(this.destroy$))
      .subscribe(([categories, total, currentPage]) => {
        this.total = total;

        this.tableService.setTableState({
          total,
          pageSize: this.pageSize,
          currentPage,
        });

        this.tableConfig = this.tableService
          .createBuilder()
          .setColumns([{ title: "Category", field_value: "name" }])
          .setRowActions([
            { label: "Edit", action_to_perform: "edit", icon: "edit-content" },
            {
              label: "Delete",
              action_to_perform: "delete",
              class: "btn-delete",
              icon: "trash1",
              confirm: true,
              confirmMessage: "Are you sure?",
            },
          ])
          .setData(categories, total)
          .setPageSize(this.pageSize)
          .build();

        this.currentPage = currentPage;
      });

    this.facade.loadCategories(1, this.pageSize);
  }

  onPageChange(page: number) {
    this.facade.loadCategories(page, this.pageSize);
  }

  onPageSizeChange(size: number) {
    this.pageSize = size;
    this.facade.loadCategories(1, size);
  }

  handleAction(value: TableClickedAction) {
    switch (value.action_to_perform) {
      case "delete":
        this.handleDelete(value.data);
        break;

      case "edit":
        this.handleEdit(value.data);
        break;

      default:
        console.warn("Unknown action:", value.action_to_perform);
    }
  }

  private handleDelete(category: CategoryResponse): void {
    console.log("Delete category:", category);
    // Example: this.store.dispatch(new DeleteCategory(category.id));
  }

  private handleEdit(category: CategoryResponse): void {
    this.editCategory.emit(category);
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
