import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatFormField, MatLabel, } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ComponentDto } from '../../../models/component';
import { ComponentService } from '../../../services/component.service';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-board-component',
  imports: [CommonModule, MatFormField, MatLabel, MatInputModule, MatSelectModule],
  templateUrl: './board-component.component.html',
  styleUrl: './board-component.component.scss'
})

export class BoardComponentComponent implements OnInit{

  availableComponents!: ComponentDto[];
  selectedComponent!: ComponentDto;

  constructor(private _componentService: ComponentService){

  }

  @Input() componentIndex! : number;

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

  onSelectionChange(component: ComponentDto){
    this.selectedComponent = component;
  }

}
