export class DeleteCategory {
  static readonly type = "[Category] Delete Category";
  constructor(public categoryId: string) {}
}
