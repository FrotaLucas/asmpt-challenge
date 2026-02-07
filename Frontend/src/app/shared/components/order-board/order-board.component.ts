import { Component, Input } from '@angular/core';

import { MatIcon, MatIconModule } from '@angular/material/icon';

import { MatLabel, MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { BoardComponentComponent } from '../board-component/board-component.component';
import { CommonModule } from '@angular/common';
import { BoardService } from '../../../services/board.service';


@Component({
  selector: 'app-order-board',
  imports: [CommonModule, MatFormField, MatLabel, MatInput, MatIconModule, BoardComponentComponent],
  templateUrl: './order-board.component.html',
  styleUrl: './order-board.component.scss'
})

export class OrderBoardComponent {

  components: number[] = [0];

  @Input() boardIndex!: number;

  addNewComponent() : void{

    this.components.push(this.components.length);
  }
}
