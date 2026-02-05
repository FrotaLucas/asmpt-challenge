import { Component, Inject, OnInit, Optional } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponentDto } from '../../../models/component';


import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ComponentService } from '../../../services/component.service';

@Component({
  selector: 'app-add-component',
  imports: [CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    MatRadioModule,
    MatButtonModule,
    MatIcon,
  ],
  templateUrl: './add-component.component.html',
  styleUrl: './add-component.component.scss'
})

export class AddComponentComponent implements OnInit {

  form!: FormGroup;
  listOfComponents!: ComponentDto[];

  constructor(private fb: FormBuilder, private componentService: ComponentService, private snackBar: MatSnackBar,
    private dialog: MatDialogRef<AddComponentComponent>
  ) {

  }

  ngOnInit(): void {
    this.form = this.fb
      .group({
        code: ['', Validators.required],
        name: ['', Validators.required],
        description: [''],
      })
  }

  onSubmit(): void {
    const component = this.form.value;

    this.componentService.createComponent(component).subscribe({
      next: (data) => {
        this.form.reset();
        this.dialog.close(true);
        this.snackBar.open("Component added successfully", "", { duration: 2000 })
      },
      error: (err) => {
        console.error("error on adding component", err);
        this.dialog.close(false);
      }
    })
  }

}
