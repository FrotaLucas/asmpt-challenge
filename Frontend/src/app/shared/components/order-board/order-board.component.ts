import { Component, Input } from '@angular/core';

import { MatIcon, MatIconModule } from '@angular/material/icon';

import { MatLabel, MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';

@Component({
  selector: 'app-order-board',
  imports: [MatFormField, MatLabel, MatIcon, MatInput, MatIconModule],
  templateUrl: './order-board.component.html',
  styleUrl: './order-board.component.scss'
})

export class OrderBoardComponent {

  @Input() boardIndex!: number;

}
