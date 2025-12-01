import { inject, Injectable } from "@angular/core";
import { Store } from "@ngxs/store";
import { TableService } from "../shared/service/Table.service";
import { CategoryResponse } from "../../shared/services/AthrHR";
import { take } from "rxjs";
import { CategoryState } from "../shared/store/categories/states/CategoryState";
import { GetAllCategories } from "../shared/store/categories/actions/GetAllCategories";
@Injectable({ providedIn: "root" })
export class CategoryFacade {
  private readonly store = inject(Store);

  categories$ = this.store.select(CategoryState.categories);
  total$ = this.store.select(CategoryState.total);
  currentPage$ = this.store.select(CategoryState.currentPage);
  pageSize$ = this.store.select(CategoryState.pageSize);

  constructor(private readonly table: TableService<CategoryResponse>) {}

  loadCategories(page: number, size: number) {
    return this.store
      .dispatch(
        new GetAllCategories({
          currentPage: page,
          perPage: size,
          pageSize: size,
        })
      )
      .subscribe(() => {
        this.categories$.pipe(take(1)).subscribe((data) => {
          this.store
            .select(CategoryState.total)
            .pipe(take(1))
            .subscribe((total) => {
              this.table.setData(data, total);
            });
        });
      });
  }
}
