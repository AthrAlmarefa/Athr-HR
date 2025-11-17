import {CategoryResponsePaginatedList} from "../../../services/AthrHR";

export class GetAllCategories {
    static readonly type = '[Category] Get All';
    constructor(public payload: {currentPage?: number, perPage?: number}) {}
}

export class GetAllCategoriesSuccess {
    static readonly type = '[Category] Get All Success';
    constructor(public payload: CategoryResponsePaginatedList) {}
}

export class GetAllCategoriesFailure {
    static readonly type = '[Category] Get All Failure';
    constructor(public error: any) {}
}
