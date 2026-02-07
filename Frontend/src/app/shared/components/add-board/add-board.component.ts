import {Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BoardService } from '../../../services/board.service';

@Component({
  selector: 'app-add-board',
   imports: [CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
  ],
  templateUrl: './add-board.component.html',
  styleUrl: './add-board.component.scss'
})


export class AddBoardComponent implements OnInit {

  form!: FormGroup;

 constructor(private fb: FormBuilder, private _boardService: BoardService, private dialog: MatDialogRef<AddBoardComponent>,
  private snackBar: MatSnackBar){
 }

  ngOnInit(): void {
      this.form = this.fb.group({
        code : ['', Validators.required],
        name : ['' ,Validators.required],
        description : [''],
        width: ['', Validators.required],
        length: ['', Validators.required]
      })
  }

  onSubmit(): void {
    const board = this.form.value;

    if(this.form.valid){
      this._boardService.createBoard(board).subscribe({
        next: () => {
          this.form.reset;
          this.dialog.close(true);
          this.snackBar.open("board added successfully", "", {duration: 2000});
        },

        error: (err) => console.error("error on creating new board", err)
      })
    }
  }
}
