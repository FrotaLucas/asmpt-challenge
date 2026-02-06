import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatFormField, MatLabel, } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ComponentService } from '../../../services/component.service';
import { MatSelectChange, MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-board-component',
  imports: [CommonModule, MatFormField, MatLabel, MatInputModule, MatSelectModule],
  templateUrl: './board-component.component.html',
  styleUrl: './board-component.component.scss'
})

export class BoardComponentComponent {

  @Input() componentIndex!: number;

  components: string[] = ['component1', 'component2', 'component3'];
  selectedComponent: string = '';

  constructor(private _componentService: ComponentService) {

  }


  loadSelection(): void {

  }

  //1
  // onSelectionChange(value: any): void {
  //   console.log("content of event", value);
  // }

  //2
  onSelectionChange(event: MatSelectChange): void {
    this.selectedComponent = event.value;
    console.log("content of event", this.selectedComponent);
  }

}
