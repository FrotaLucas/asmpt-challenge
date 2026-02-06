import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatFormField, MatLabel, } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ComponentService } from '../../../services/component.service';
import { MatSelectChange, MatSelectModule } from '@angular/material/select';
import { ComponentDto } from '../../../models/component';

@Component({
  selector: 'app-board-component',
  imports: [CommonModule, MatFormField, MatLabel, MatInputModule, MatSelectModule],
  templateUrl: './board-component.component.html',
  styleUrl: './board-component.component.scss'
})

export class BoardComponentComponent implements OnInit {

  @Input() componentIndex!: number;

  components!: ComponentDto[];
  selectedComponent!: ComponentDto;

  constructor(private _componentService: ComponentService) {

  }

  ngOnInit(): void {
    this.loadSelection();
  }

  loadSelection(): void {
    this._componentService.getComponents().subscribe({
      next: (data) => {
        this.components = data;
      },
    })
  }

  //1
  onSelectionChange(component: ComponentDto): void {
    this.selectedComponent = component;
    console.log("content of event", component);
  }



}
