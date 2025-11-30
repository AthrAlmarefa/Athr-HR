export class DeleteCategory {
  static readonly type = "[Category] Delete Category";
  constructor(public categoryId: string) {}
}

// export class DeleteCategorySuccess {
//   static readonly type = "[Category] Delete Category Success";
//   constructor(public payload: string) {}
// }

// export class DeleteCategoryFailure {
//   static readonly type = "[Category] Delete Category Failure";
//   constructor(public error: any) {}
// }
