import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BoardService } from '../../../services/board.service';
import type { BoardDto } from '../../../models/board';


@Component({
  selector: 'app-edit-board',
  imports: [CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatRadioModule,
    MatButtonModule],
  templateUrl: './edit-board.component.html',
  styleUrl: './edit-board.component.scss'
})

export class EditBoardComponent {

  form!: FormGroup;

  constructor(private fb: FormBuilder, private _boardService: BoardService, private dialog: MatDialogRef<EditBoardComponent>,
    private snackBar: MatSnackBar, @Inject(MAT_DIALOG_DATA) private board: BoardDto) {
}

ngOnInit(): void {
  this.form = this.fb.group({
    id: [this.board.id],
    code: [this.board.code, Validators.required],
    name: [this.board.name, Validators.required],
    description: [this.board.description],
    width: [this.board.width, Validators.required],
    length: [this.board.length, Validators.required]
  })
}

onSubmit(): void {
  const board = this.form.value;

  if(this.form.valid){
  this._boardService.updateBoard(board).subscribe({
    next: () => {
      this.form.reset;
      this.dialog.close(true);
      this.snackBar.open("board updated successfully", "", { duration: 2000 });
    },

    error: (err) => console.error("error on updating board", err)
  })
}
  }
}
