import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderBoardComponent } from '../../shared/components/order-board/order-board.component';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from "@angular/material/input";
import { OrderService } from '../../services/order.service';
import { OrderDto } from '../../models/order';

@Component({
  selector: 'app-create-order',
  imports: [CommonModule, OrderBoardComponent, ReactiveFormsModule,
    MatFormField, MatLabel, MatInput],
  templateUrl: './create-order.component.html',
  styleUrl: './create-order.component.scss'
})

export class CreateOrderComponent {

  orderForm!: FormGroup;

  constructor(private fb: FormBuilder, private _orderService: OrderService) {
    this.orderForm = this.fb.group({
      boards: this.fb.array([]),
      orderNumber: [''],
      name: [''],
      description: [''],
      //Date deve ser gerado no Frontend
      //orderDate: [new Date().toISOString()],

    })

    this.addNewBoard();
  }

  get boards(): FormArray {

    return this.orderForm.get("boards") as FormArray
  }

  get boardGroups(): FormGroup[] {
    return this.boards.controls as FormGroup[];
  }

  addNewBoard(): void {
    this.boards.push(
      this.fb.group({
        board: [null],
        components: this.fb.array([])
      })
    );
  }

  sendOrder(): void {

    //console.log(this.orderForm.value);
    const formValue = this.orderForm.value;

    const order = {
      orderNumber: '',
      name: '',
      description: formValue.description,
      orderDate: new Date().toISOString(),
      // quantityBoards: 0,
      // quantityComponents: 0,
      boards: formValue.boards.map((b: any) => ({
        id: b.board.id,
        components: b.components
          .filter((c: any) => c.component)
          .map((c: any) => ({
            id: c.component.id
          }))
      }))
    };

    this._orderService.createOrder(order).subscribe((data) => {
      console.log('calling order post', order);

    })

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
