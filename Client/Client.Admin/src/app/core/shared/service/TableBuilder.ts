import { TableAction } from "../interface/table/TableAction";
import { TableColumn } from "../interface/table/TableColumn";
import { TableConfigs } from "../interface/table/TableConfigs";
import { TableService } from "./Table.service";

export class TableBuilder<T> {
  private _columns: TableColumn[] = [];
  private _rowActions: TableAction[] = [];
  private _data: T[] = [];
  private _pageSize = 10;

  constructor(private readonly tableService: TableService<T>) {}
  setColumns(columns: TableColumn[]): this {
    this._columns = columns;
    return this;
  }

  setRowActions(actions: TableAction[]): this {
    this._rowActions = actions;
    return this;
  }

  setData(data: T[], total?: number): this {
    this._data = data;
    this.tableService.setData(data, total);
    return this;
  }

  setPageSize(size: number): this {
    this._pageSize = size;
    this.tableService.setTableState({ pageSize: size });
    return this;
  }

  build(): TableConfigs {
    return {
      columns: this._columns,
      row_action: this._rowActions,
      data: this._data,
    };
  }
}
