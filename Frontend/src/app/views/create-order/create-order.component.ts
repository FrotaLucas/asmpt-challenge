import { Component } from '@angular/core';

import { MatIcon, MatIconModule } from '@angular/material/icon';

import { MatLabel, MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';

@Component({
  selector: 'app-create-order',
  imports: [MatFormField, MatLabel, MatIcon, MatInput, MatIconModule],
  templateUrl: './create-order.component.html',
  styleUrl: './create-order.component.scss'
})
export class CreateOrderComponent {

  constructor(){

  }

  addNewBoadComponent(): void{

  }

  
}
