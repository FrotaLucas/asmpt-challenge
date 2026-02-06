import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { BoardService } from '../../services/board.service';
import { BoardDto } from '../../models/board';
import { boardColumns } from '../../models/board-column';

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
  selector: 'app-board-table',
    imports: [CommonModule, RouterModule, MatIconModule,
    MatLabel, MatFormField, MatInput, MatTableModule, MatCellDef, MatHeaderCellDef,
    MatPaginator, MatSortModule],
  templateUrl: './board-table.component.html',
  styleUrl: './board-table.component.scss'
})


export class BoardTableComponent implements OnInit {

  listOfBoards!: BoardDto[];
  displayedColumn : string[] = boardColumns;

dataSource!: MatTableDataSource<BoardDto>
  @ViewChild(MatSort) refMatSort!: MatSort;
  @ViewChild(MatPaginator) refMatPaginator!: MatPaginator;


  constructor(private router: Router, private dialog: MatDialog,
    private snackBar: MatSnackBar, private _boardService: BoardService) {
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
    this._boardService.getBoards().subscribe({
      next: (data) => {
        this.listOfBoards = data,
      console.log(this.listOfBoards)},
      
      error: (err) => console.error("error on refreshing page", err)
    })
  }

  deleteBoard(id: number){
    this._boardService.deleteBoard(id).subscribe({
      next: () => this.refreshPage(),

      error: () => console.log("error on deleting board")
    })

    this.snackBar.open('successfully deleted', '', { duration: 2000 });
  }

  updateBoard(board: BoardDto){
    // const dialogRef = this.dialog.open()

  }
}
