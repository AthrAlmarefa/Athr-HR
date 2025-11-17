import {CategoryResponse, CategoryResponsePaginatedList, CategoryService} from "../../../services/AthrHR";
import {Action, Selector, State, StateContext} from "@ngxs/store";
import {GetAllCategories, GetAllCategoriesFailure, GetAllCategoriesSuccess} from "../actions/GetAllCategories";
import {catchError, tap} from "rxjs/operators";
import {throwError} from "rxjs";

export interface CategoryStateModel {
    categories: CategoryResponse[],
    currentPage: number,
    pageSize: number,
    total: number,
    loading: boolean,
    error: any
}

@State<CategoryStateModel>({
  name: "categoryState",
  defaults: {
      categories: [],
      currentPage: 1,
      pageSize: 10,
      total: 0,
      loading: false,
      error: null,
  }
})

export class CategoryState {
    constructor(public categoryService: CategoryService) {}

    @Selector()
    static categories(state: CategoryStateModel): CategoryResponse[] {
        return state.categories;
    }

    @Selector()
    static loading(state: CategoryStateModel): boolean {
        return state.loading;
    }

    @Selector()
    static currentPage(state: CategoryStateModel): number {
        return state.currentPage;
    }

    @Selector()
    static error(state: CategoryStateModel): any {
        return state.error;
    }

    @Action(GetAllCategories)
    getAllCategories(context: StateContext<CategoryStateModel>, action: GetAllCategories){
        context.patchState({loading: true, error: null});

        return this.categoryService.getCategories(action.payload.currentPage, action.payload.perPage)
            .pipe(
                tap((response: CategoryResponsePaginatedList) => {
                    context.dispatch(new GetAllCategoriesSuccess(response));
                }),
                catchError(error => {
                    context.dispatch(error);
                    return throwError(error);
                })
            );
    }


    @Action(GetAllCategoriesSuccess)
    getAllCategoriesSuccess(context: StateContext<CategoryStateModel>, action:GetAllCategoriesSuccess) {
        context.patchState({
            categories: action.payload.data,
            total: action.payload.total,
            currentPage: action.payload.currentPage,
            loading: false,
            error: null
        });
    }

    @Action(GetAllCategoriesFailure)
    getAllCategoriesFailure(context: StateContext<CategoryStateModel>, action: GetAllCategoriesFailure) {
        context.patchState({loading: false, error: action.error});
    }
}
