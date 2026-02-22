import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { OrderService } from '../../services/order.service';
import { OrderDto } from '../../models/order';
import { orderColumns } from '../../models/columns/order-columns';
import { CommonModule } from '@angular/common';

import { Router, RouterModule } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';

import { MatLabel, MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatTableModule, MatCellDef, MatHeaderCellDef, MatTableDataSource } from '@angular/material/table';

import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-order-table',
  imports: [CommonModule, MatIconModule,
    MatLabel, MatFormField, MatInput, MatTableModule, MatCellDef, MatHeaderCellDef,
    MatPaginator, MatSortModule, RouterModule],
  templateUrl: './order-table.component.html',
  styleUrl: './order-table.component.scss'
})

export class OrderTableComponent implements OnInit, AfterViewInit {

  displayedColumns: string[] = orderColumns;

  dataSource!: MatTableDataSource<OrderDto>
  @ViewChild(MatSort) refMatSort!: MatSort;
  @ViewChild(MatPaginator) refMatPaginator!: MatPaginator;


  constructor(private router: Router, private _orderService: OrderService) {
    this.dataSource = new MatTableDataSource();
  }

  ngOnInit(): void {
    this.refreshPage();

  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.refMatPaginator;
    this.dataSource.sort = this.refMatSort;
  }

  refreshPage(): void {
    this._orderService.getOrders().subscribe({
      next: (data) => {
        this.dataSource.data = data
      },

      error: (err) => console.error("error on refreshing page", err)
    })
  }

  applyFilter(event: Event) {
    const filteredData = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filteredData.trim().toLowerCase();
  }

  navigateTo(): void {
    this.router.navigate(["orders/new"]);
  }
}
