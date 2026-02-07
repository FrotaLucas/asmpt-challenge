import { Component, Inject, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponentDto } from '../../../models/component';


import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ComponentService } from '../../../services/component.service';

@Component({
  selector: 'app-edit-component',
  imports: [CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatRadioModule,
    MatButtonModule],
  templateUrl: './edit-component.component.html',
  styleUrl: './edit-component.component.scss'
})

export class EditComponentComponent implements OnInit{


  form!: FormGroup;
  listOfComponents!: ComponentDto[];

  constructor(private fb: FormBuilder, private _componentService: ComponentService, private snackBar: MatSnackBar,
    private dialog: MatDialogRef<EditComponentComponent>, @Inject(MAT_DIALOG_DATA) private component: ComponentDto
  ) {

  }

  ngOnInit(): void {

    this.form = this.fb
      .group({
        id: [this.component.id],
        code: [this.component.code, Validators.required],
        name: [this.component.name, Validators.required],
        description: [this.component.description],
      })
  }


   onSubmit(): void {
    const component = this.form.value;
    console.log(this.component)

    this._componentService.updateComponent(component).subscribe({
      next: (data) => {
        this.form.reset();
        this.dialog.close(true);
        this.snackBar.open("Component updated successfully", "", { duration: 2000 })
      },
      error: (err) => {
        console.error("error on updating component", err);
        this.dialog.close(false);
      }
    })
  }
}
