import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { ComponentService } from '../../services/component.service';
import { ComponentDto } from '../../models/component';
import { componentColumns } from '../../models/component-column';

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
import { AddComponentComponent } from '../../shared/components/add-component/add-component.component';
import { EditComponentComponent } from '../../shared/components/edit-component/edit-component.component';

@Component({
  selector: 'app-component',
  standalone: true,
  imports: [CommonModule, RouterModule, MatIconModule,
    MatLabel, MatFormField, MatInput, MatTableModule, MatCellDef, MatHeaderCellDef,
    MatPaginator, MatSortModule],
  templateUrl: './component-table.component.html',
  styleUrl: './component-table.component.scss'
})

export class ComponentTableComponent implements OnInit, AfterViewInit {


  listOfComponents!: ComponentDto[];
  displayedColumns: string[] = componentColumns;

  dataSource!: MatTableDataSource<ComponentDto>
  @ViewChild(MatSort) refMatSort!: MatSort;
  @ViewChild(MatPaginator) refMatPaginator!: MatPaginator;


  constructor(private router: Router, private dialog: MatDialog,
    private snackBar: MatSnackBar, private _componentService: ComponentService) {
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
    this._componentService.getComponents().subscribe({
      next: (data) => {
        // this.listOfComponents = data;
        this.dataSource.data = data;
        // console.log(this.listOfComponents);
      },

      error: (err) => console.error("error on refreshing page", err)
    })
  }

  deleteComponent(id: number): void {

    this._componentService.deleteComponent(id).subscribe({
      next: () => {
        this.refreshPage();
      },
      error: (err) => console.error("error on deleting component", err)
    });

    this.snackBar.open('successfully deleted', '', { duration: 2000 });
  };

  editComponent(component: ComponentDto): void {
    const dialogRef = this.dialog.open(EditComponentComponent, {
      width: '600px',
      data: component
    })

    dialogRef.afterClosed().subscribe({
      next: (res => {
        if (res == true) {
          this.refreshPage();
        }
      })
    })
  };

  applyFilter(event: Event) {
    const filteredData = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filteredData.trim().toLowerCase();
  }

  addComponent(): void {
    const dialogRef = this.dialog.open(AddComponentComponent, {
      width: '600px'
    });

    dialogRef.afterClosed().subscribe(
      res => {
        if (res = true) {
          this.refreshPage();
        }
      }
    )
  }

  navigateTo(): void {
    //implement

  }

}


