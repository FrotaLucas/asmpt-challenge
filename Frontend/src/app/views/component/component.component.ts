import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { ComponentService } from '../../services/component.service';
import { ComponentDto } from '../../models/component';
import { componentColumns } from '../../models/component-column';


import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';

import { MatPaginator } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { HttpClient } from '@angular/common/http';

import { MatLabel, MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatTableModule, MatCellDef, MatHeaderCellDef, MatTableDataSource } from '@angular/material/table';

import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTooltip } from '@angular/material/tooltip';

@Component({
  selector: 'app-component',
  standalone: true,
  imports: [CommonModule, RouterModule, MatIconModule,
    MatLabel, MatFormField, MatInput, MatTableModule, MatCellDef, MatHeaderCellDef,
    MatPaginator, MatSortModule, MatTooltip],
  templateUrl: './component.component.html',
  styleUrl: './component.component.scss'
})

export class ComponentComponent implements OnInit, AfterViewInit {


  listOfComponents!: ComponentDto[];
  displayedColumns: string[] = componentColumns;

  dataSource!: MatTableDataSource<ComponentDto>
  @ViewChild(MatSort) refMatSort!: MatSort;
  @ViewChild(MatPaginator) refMatPaginator!: MatPaginator;


  constructor(private router: Router, private dialog: MatDialog, private componentService: ComponentService) {
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
    console.log("lisssssssssssssssssst" + this.listOfComponents);
    this.componentService.getComponents().subscribe({
      next: (data) => {
        this.listOfComponents = data;
        this.dataSource.data = data;
        console.log(this.listOfComponents);
      },

      error: (err) => console.error("error refresh page", err)
    })



  }

}
