import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatFormField } from '@angular/material/form-field';
import { ComponentDto } from '../../../models/component';
import { ComponentService } from '../../../services/component.service';
import { MatSelectModule } from '@angular/material/select';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-board-component',
  imports: [CommonModule, MatFormField, MatSelectModule, ReactiveFormsModule],
  templateUrl: './board-component.component.html',
  styleUrl: './board-component.component.scss'
})

export class BoardComponentComponent implements OnInit {

  availableComponents!: ComponentDto[];
  selectedComponent!: ComponentDto;

  constructor(private _componentService: ComponentService) {

  }

  @Input() componentIndex!: number;
  @Input() componentGroup!: FormGroup;

  ngOnInit(): void {
    
    this.loadComponents();
  }

  loadComponents(): void {
    this._componentService.getComponents().subscribe({
      next: (data) => {
        this.availableComponents = data;
      }
    })
  }

}
