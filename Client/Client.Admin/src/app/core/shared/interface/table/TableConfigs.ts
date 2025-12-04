import { TableAction } from "./TableAction";
import { TableColumn } from "./TableColumn";


export interface TableConfigs {
  columns: TableColumn[];
  row_action?: TableAction[];
  data: any[];
}
