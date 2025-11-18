import { CategoryResponse } from "../../../services/AthrHR";

export class GetCategoryById {
    static readonly type = '[Category] Get By Id';
    constructor(public categoryId: string) {}
}

export class GetCategoryByIdSuccess {
    static readonly type = '[Category] Get By Id Success';
    constructor(public payload: CategoryResponse) {}
}

export class GetCategoryByIdFailure {
    static readonly type = '[Category] Get By Id Failure';
    constructor(public error: any) {}
}
