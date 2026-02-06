import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { OrderService } from '../../services/order.service';
import { OrderDto } from '../../models/order';
import { orderColumns } from '../../models/order-columns';
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

export class OrderTableComponent implements OnInit {

  displayedColumns: string[] = orderColumns;

  dataSource!: MatTableDataSource<OrderDto>
  @ViewChild(MatSort) refMatSort!: MatSort;
  @ViewChild(MatPaginator) refMatPaginator!: MatPaginator;


  constructor(private router: Router) {

  }

  ngOnInit(): void {

  }

  applyFilter(event: Event) {
    const filteredData = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filteredData.trim().toLowerCase();
  }

  navigateTo(): void {
    this.router.navigate(["orders/new"]);
  }
}
