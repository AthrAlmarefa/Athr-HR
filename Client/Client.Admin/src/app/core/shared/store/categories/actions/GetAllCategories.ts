import { CategoryResponsePaginatedList } from "../../../../../shared/services/AthrHR";

export class GetAllCategories {
  static readonly type = "[Category] Get All Categories";
  constructor(
    public payload: {
      currentPage?: number;
      perPage?: number;
      pageSize?: number;
    }
  ) {}
}

export class GetAllCategoriesSuccess {
  static readonly type = "[Category] Get All Categories Success";
  constructor(public payload: CategoryResponsePaginatedList) {}
}

export class GetAllCategoriesFailure {
  static readonly type = "[Category] Get All Categories Failure";
  constructor(public error: any) {}
}
