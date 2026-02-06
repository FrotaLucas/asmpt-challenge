import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatFormField, MatLabel, } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-board-component',
  imports: [CommonModule, MatFormField, MatLabel, MatInputModule],
  templateUrl: './board-component.component.html',
  styleUrl: './board-component.component.scss'
})

export class BoardComponentComponent {

  @Input() componentIndex! : number;
}
