import { AddCategoryRequest } from "../../../services/AthrHR";

export class CreateCategory {
  static readonly type = "[Category] Create Category";
  constructor(public payload: AddCategoryRequest) {}
}

export class CreateCategorySuccess {
  static readonly type = "[Category] Create Category Success";
  constructor(public payload: string) {}
}

export class CreateCategoryFailure {
  static readonly type = "[Category] Create Category Failure";
  constructor(public error: any) {}
}
