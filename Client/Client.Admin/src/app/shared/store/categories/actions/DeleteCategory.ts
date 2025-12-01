export class DeleteCategory{
    static readonly type = "[Category] Delete";
    constructor(public payload: { categoryId: number }) {}
}

export class DeleteCategorySuccess {
  static readonly type = "[Category] Delete Success";
  constructor(public payload: string) {}
}


export class DeleteCategoryFailure {
    static readonly type = "[Category] Delete Failure";
    constructor(public error: any) { }
}