import { UpdateCategoryRequest } from "../../../../../shared/services/AthrHR";


export class UpdateCategory {
  static readonly type = "[Category] Update Category";
  constructor(public payload: UpdateCategoryRequest) {}
}

export class UpdateCategorySuccess {
  static readonly type = "[Category] Update Category Success";
  constructor(public payload: string) {}
}

export class UpdateCategoryFailure {
  static readonly type = "[Category] Update Category Failure";
  constructor(public error: any) {}
}
