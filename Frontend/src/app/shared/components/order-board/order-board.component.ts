import { Component, Input, OnInit } from '@angular/core';

import { MatIconModule } from '@angular/material/icon';

import { MatLabel, MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { BoardComponentComponent } from '../board-component/board-component.component';
import { CommonModule } from '@angular/common';
import { MatSelect, MatOption, MatSelectModule } from "@angular/material/select";
import { BoardDto } from '../../../models/board';
import { BoardService } from '../../../services/board.service';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';


@Component({
  selector: 'app-order-board',
  imports: [CommonModule, MatFormField, MatSelectModule,
    MatLabel, MatIconModule, BoardComponentComponent, MatSelect, MatOption, ReactiveFormsModule],
  templateUrl: './order-board.component.html',
  styleUrl: './order-board.component.scss'
})

export class OrderBoardComponent implements OnInit {

  availableBoards!: BoardDto[];
  selectedBoard!: BoardDto;

  @Input() boardIndex!: number;
  @Input() boardGroup!: FormGroup

  constructor(private _serviceBoard: BoardService, private fb: FormBuilder) {
  }

  ngOnInit(): void {
    this.loadBoards();
    this.addNewComponent();

  }

  get components(): FormArray {
    return this.boardGroup.get("components") as FormArray;
  }

  get componentGroups(): FormGroup[] {
    return this.components.controls as FormGroup[];
  }

  addNewComponent(): void {

    this.components.push(this.fb.group({
      component: [null]
    }))
  }

  loadBoards(): void {
    this._serviceBoard.getBoards().subscribe({
      next: (data) => {
        this.availableBoards = data;
      }
    })
  }

  onSelectionBoard() : void {
    // this.boardGroup.get('board')?.valueChanges.subscribe(board => 
    //   console.log("selected Board:", board)
    // )
  }
}
