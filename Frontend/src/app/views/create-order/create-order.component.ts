import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderBoardComponent } from '../../shared/components/order-board/order-board.component';

@Component({
  selector: 'app-create-order',
  imports: [CommonModule, OrderBoardComponent],
  templateUrl: './create-order.component.html',
  styleUrl: './create-order.component.scss'
})

export class CreateOrderComponent {

  boards: number[] = [0];

  constructor() {

  }

  addNewBoard(): void {

    this.boards.push(this.boards.length);
  }

  createOrder(): void {

  }
}
