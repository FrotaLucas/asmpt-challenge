import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatIcon, MatIconModule } from '@angular/material/icon';

import { MatLabel, MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';

import { OrderBoardComponent } from '../../shared/components/order-board/order-board.component';

@Component({
  selector: 'app-create-order',
  imports: [CommonModule, MatFormField, MatLabel, MatIcon, MatInput, MatIconModule, OrderBoardComponent],
  templateUrl: './create-order.component.html',
  styleUrl: './create-order.component.scss'
})

export class CreateOrderComponent {

  boards: number[] = [0];

  constructor(){

  }

  addNewBoadComponent(): void{

    this.boards.push(this.boards.length);
  }


}
