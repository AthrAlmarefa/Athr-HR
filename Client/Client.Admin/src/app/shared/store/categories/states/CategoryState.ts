import { DeleteCategory } from "./../actions/DeleteCategory";
import { state } from "./../../../data/form-widgets";
import {
  CategoryResponse,
  CategoryResponsePaginatedList,
  CategoryService,
} from "../../../services/AthrHR";
import { Action, Selector, State, StateContext } from "@ngxs/store";
import {
  GetAllCategories,
  GetAllCategoriesFailure,
  GetAllCategoriesSuccess,
} from "../actions/GetAllCategories";
import { catchError, tap } from "rxjs/operators";
import { throwError } from "rxjs";
import {
  GetCategoryById as GetCategoryById,
  GetCategoryByIdFailure,
  GetCategoryByIdSuccess,
} from "../actions/GetCategory";
import { error } from "../../../../components/error-pages/error.routes";
import { Injectable } from "@angular/core";
import {
  UpdateCategory,
  UpdateCategoryFailure,
  UpdateCategorySuccess,
} from "../actions/UpdateCategory";
import {
  CreateCategory,
  CreateCategoryFailure,
  CreateCategorySuccess,
} from "../actions/CreateCategory";

export interface CategoryStateModel {
  categories: CategoryResponse[];
  selectedCategory: CategoryResponse | null;
  currentPage: number;
  perPage: number;
  total: number;
  loading: boolean;
  error: any;
}

@State<CategoryStateModel>({
  name: "categoryState",
  defaults: {
    categories: [],
    selectedCategory: null,
    currentPage: 1,
    perPage: 10,
    total: 0,
    loading: false,
    error: null,
  },
})
@Injectable()
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
  getAllCategories(
    context: StateContext<CategoryStateModel>,
    action: GetAllCategories
  ) {
    context.patchState({ loading: true, error: null });

    return this.categoryService
      .getCategories(action.payload.currentPage, action.payload.perPage)
      .pipe(
        tap((response: CategoryResponsePaginatedList) => {
          context.dispatch(new GetAllCategoriesSuccess(response));
        }),
        catchError((error) => {
          context.dispatch(new GetAllCategoriesFailure(error));
          return throwError(error);
        })
      );
  }

  @Action(GetAllCategoriesSuccess)
  getAllCategoriesSuccess(
    context: StateContext<CategoryStateModel>,
    action: GetAllCategoriesSuccess
  ) {
    context.patchState({
      categories: action.payload.data,
      total: action.payload.total,
      currentPage: action.payload.currentPage,
      loading: false,
      error: null,
    });
  }

  @Action(GetAllCategoriesFailure)
  getAllCategoriesFailure(
    context: StateContext<CategoryStateModel>,
    action: GetAllCategoriesFailure
  ) {
    context.patchState({ loading: false, error: action.error });
  }

  @Action(GetCategoryById)
  getGetCategoryById(
    context: StateContext<CategoryStateModel>,
    action: GetCategoryById
  ) {
    context.patchState({ loading: true, error: null });

    return this.categoryService.getCategory(action.categoryId).pipe(
      tap((response: CategoryResponse) => {
        context.dispatch(new GetCategoryByIdSuccess(response));
      }),
      catchError((error) => {
        context.dispatch(new GetCategoryByIdFailure(error));
        return throwError(error);
      })
    );
  }

  @Action(GetCategoryByIdSuccess)
  getCategoryByIdSuccess(
    context: StateContext<CategoryStateModel>,
    action: GetCategoryByIdSuccess
  ) {
    context.patchState({
      selectedCategory: action.payload,
      loading: false,
      error: null,
    });
  }

  @Action(GetCategoryByIdFailure)
  getCategoryByIdFailure(
    context: StateContext<CategoryStateModel>,
    action: GetCategoryByIdFailure
  ) {
    context.patchState({ loading: false, error: error });
  }

  // =====================Create Category=============================

  @Action(CreateCategory)
  createCategory(
    context: StateContext<CategoryStateModel>,
    action: CreateCategory
  ) {
    context.patchState({ loading: true, error: null });

    return this.categoryService.addCategory(action.payload).pipe(
      tap((response: string) => {
        context.dispatch(new CreateCategorySuccess(response));
      }),
      catchError((error) => {
        context.patchState({ loading: false, error: error });
        return throwError(() => error);
      })
    );
  }

  @Action(CreateCategorySuccess)
  createCategorySuccess(
    context: StateContext<CategoryStateModel>,
    action: CreateCategorySuccess
  ) {
    context.patchState({
      loading: false,
      error: null,
    });

    const state = context.getState();
    const categoryListRequest = {
      currentPage: state.currentPage,
      perPage: state.perPage,
    };
    context.dispatch(new GetAllCategories(categoryListRequest));
  }

  @Action(CreateCategoryFailure)
  createCategoryFailure(
    context: StateContext<CategoryStateModel>,
    action: CreateCategoryFailure
  ) {
    context.patchState({
      loading: false,
      error: action.error,
    });
  }

  // =====================Update Category=============================

  @Action(UpdateCategory)
  updateCategory(
    context: StateContext<CategoryStateModel>,
    action: UpdateCategory
  ) {
    context.patchState({
      loading: true,
      error: null,
    });

    return this.categoryService
      .updateCategory({ id: action.payload.id, name: action.payload.name })
      .pipe(
        tap((response: string) => {
          context.dispatch(new UpdateCategorySuccess(response));
        }),

        catchError((error) => {
          context.dispatch(new UpdateCategoryFailure(error));
          return throwError(() => error);
        })
      );
  }

  @Action(UpdateCategorySuccess)
  updateCategorySuccess(
    context: StateContext<CategoryStateModel>,
    action: UpdateCategorySuccess
  ) {
    context.patchState({
      loading: false,
      error: null,
    });

    const state = context.getState();
    // const categoryListRequest = {
    //   currentPage: state.currentPage,
    //   perPage: state.perPage,
    // };
    context.dispatch(new GetAllCategories({}));
  }

  @Action(UpdateCategoryFailure)
  updateCategoryFailure(
    context: StateContext<CategoryStateModel>,
    action: UpdateCategoryFailure
  ) {
    context.patchState({
      loading: false,
      error: action.error,
    });
  }

  // =====================Delete Category=============================

  @Action(DeleteCategory)
  deleteCategory(
    context: StateContext<CategoryStateModel>,
    action: DeleteCategory
  ) {
    context.patchState({
      loading: true,
      error: null,
    });
    const deleteCategory = this.categoryService
      .deleteCategory(action.categoryId)
      .pipe(
        tap((_) => {
          context.dispatch(new GetAllCategories({}));
        }),
        catchError((error) => {
          return throwError(() => error);
        })
      );
    context.patchState({
      loading: false,
      error: error,
    });

    return deleteCategory;
  }
}
