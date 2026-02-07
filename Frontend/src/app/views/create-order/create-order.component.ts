import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderBoardComponent } from '../../shared/components/order-board/order-board.component';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-create-order',
  imports: [CommonModule, OrderBoardComponent, ReactiveFormsModule],
  templateUrl: './create-order.component.html',
  styleUrl: './create-order.component.scss'
})

export class CreateOrderComponent {

  orderForm!: FormGroup;

  constructor(private fb: FormBuilder) {
    this.orderForm = this.fb.group({
      boards: this.fb.array([])
    })

    this.addNewBoard();
  }

  get boards() : FormArray {

    return this.orderForm.get("boards") as FormArray
  }

  get boardGroups() : FormGroup[] {
    return this.boards.controls as FormGroup[];
  }
  
  addNewBoard(): void {
  
    this.boards.push( this.fb.group({
      board: [null],
      components: this.fb.array([])
    }))
  }

  sendOrder(): void {

    console.log(this.orderForm.value);
  }

//structure 
//   this.boards.controls = [
//   FormGroup {
//     controls: {
//       board: FormControl,
//       components: FormArray
//     }
//   },
//   FormGroup {
//     controls: {
//       board: FormControl,
//       components: FormArray
//     }
//   }
// ]


}
