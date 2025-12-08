import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
  selector: "app-HRPagination",
  imports: [CommonModule],
  templateUrl: "./HRPagination.component.html",
  styleUrl: "./HRPagination.component.scss",
})
export class HRPaginationComponent {

  @Input() public total: number;
  @Input() public currentPage: number;
  @Input() public pageSize: number;
  @Input() paginate: any = {};
  @Input() paginateDetails: boolean;

  @Output() setPage: EventEmitter<number> = new EventEmitter();
  
  pageSet(page: number) {
    this.setPage.emit(page);  // Set Page Number
  }
}
