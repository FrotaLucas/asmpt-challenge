import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ComponentService } from '../../../services/component.service';

@Component({
  selector: 'app-add-component',
  imports: [CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  templateUrl: './add-component.component.html',
  styleUrl: './add-component.component.scss'
})

export class AddComponentComponent implements OnInit {

  form!: FormGroup;

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
      next: () => {
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
