import { Component, Input, OnInit } from '@angular/core';

import { MatIconModule } from '@angular/material/icon';

import { MatLabel, MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { BoardComponentComponent } from '../board-component/board-component.component';
import { CommonModule } from '@angular/common';
import { MatSelect, MatOption, MatSelectModule } from "@angular/material/select";
import { BoardDto } from '../../../models/board';
import { BoardService } from '../../../services/board.service';


@Component({
  selector: 'app-order-board',
  imports: [CommonModule, MatFormField, MatSelectModule, MatLabel, MatIconModule, BoardComponentComponent, MatSelect, MatOption],
  templateUrl: './order-board.component.html',
  styleUrl: './order-board.component.scss'
})

export class OrderBoardComponent implements OnInit {

  components: number[] = [0];

  availableBoards!: BoardDto[];
  selectedBoard!: BoardDto;

  @Input() boardIndex!: number;

  constructor(private _serviceBoard: BoardService){

  }

  ngOnInit(): void {
      this.loadBoards();
  }

  addNewComponent() : void{

    this.components.push(this.components.length);
  }

  loadBoards(): void {
    this._serviceBoard.getBoards().subscribe({
      next: (data) => {
        this.availableBoards = data;
      }
    })
  }

}
