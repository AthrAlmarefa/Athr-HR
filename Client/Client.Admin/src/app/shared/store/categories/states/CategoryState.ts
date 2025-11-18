import { CategoryResponse, CategoryResponsePaginatedList, CategoryService } from "../../../services/AthrHR";
import { Action, Selector, State, StateContext } from "@ngxs/store";
import { GetAllCategories, GetAllCategoriesFailure, GetAllCategoriesSuccess } from "../actions/GetAllCategories";
import { catchError, tap } from "rxjs/operators";
import { throwError } from "rxjs";
import { GetCategoryById as GetCategoryById, GetCategoryByIdFailure, GetCategoryByIdSuccess } from "../actions/GetCategory";
import { error } from "../../../../components/error-pages/error.routes";
import { Injectable } from "@angular/core";

export interface CategoryStateModel {
    categories: CategoryResponse[],
    selectedCategory: CategoryResponse | null,
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
        selectedCategory: null,
        currentPage: 1,
        pageSize: 10,
        total: 0,
        loading: false,
        error: null,
    }
})
@Injectable()
export class CategoryState {
    constructor(public categoryService: CategoryService) { }

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
    static total(state: CategoryStateModel): number {
        return state.total;
    }

    @Selector()
    static error(state: CategoryStateModel): any {
        return state.error;
    }


    @Selector()
    static selectedCategory(state: CategoryStateModel): CategoryResponse | null {
        return state.selectedCategory;
    }

    @Action(GetAllCategories)
    getAllCategories(context: StateContext<CategoryStateModel>, action: GetAllCategories) {
        context.patchState({ loading: true, error: null });

        return this.categoryService.getCategories(action.payload.currentPage, action.payload.perPage)
            .pipe(
                tap((response: CategoryResponsePaginatedList) => {
                    context.dispatch(new GetAllCategoriesSuccess(response));
                }),
                catchError(error => {
                    context.dispatch(new GetAllCategoriesFailure(error));
                    return throwError(error);
                })
            );
    }


    @Action(GetAllCategoriesSuccess)
    getAllCategoriesSuccess(context: StateContext<CategoryStateModel>, action: GetAllCategoriesSuccess) {
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
        context.patchState({ loading: false, error: action.error });
    }

    @Action(GetCategoryById)
    getGetCategoryById(context : StateContext<CategoryStateModel>, action: GetCategoryById){
        context.patchState({loading: true, error: null});

        return this.categoryService.getCategory(action.categoryId).pipe(
            tap((response: CategoryResponse) => {
                context.dispatch(new GetCategoryByIdSuccess(response));
            }),
            catchError(error => {
                context.dispatch(new GetCategoryByIdFailure(error));
                return throwError(error) ;
            })
        )
    }

    @Action(GetCategoryByIdSuccess)
    getCategoryByIdSuccess(context: StateContext<CategoryStateModel>, action: GetCategoryByIdSuccess) {
        context.patchState({selectedCategory: action.payload, loading: false, error: null});
    }

    @Action(GetCategoryByIdFailure)
    getCategoryByIdFailure(context: StateContext<CategoryStateModel>, action: GetCategoryByIdFailure) {
        context.patchState({loading: false, error: error});
    }

}
