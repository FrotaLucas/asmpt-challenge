import { Component, OnInit } from '@angular/core';
import { BoardService } from '../../services/board.service';
import { BoardDto } from '../../models/board';

@Component({
  selector: 'app-board-table',
  imports: [],
  templateUrl: './board-table.component.html',
  styleUrl: './board-table.component.scss'
})


export class BoardTableComponent implements OnInit {

  listOfBoards!: BoardDto[];

  constructor(private _boardService: BoardService){

  }

  ngOnInit(): void {
      
  }

  refreshPage(): void {
    this._boardService.getBoards().subscribe({
      next: (data) => {
        this.listOfBoards = data,
      console.log(this.listOfBoards)},
      

      error: (err) => console.error("error on refreshing page", err)
    })
  }

  deleteBoard(id: Number){

  }

  updateBoard(board: BoardDto){

  }
}
