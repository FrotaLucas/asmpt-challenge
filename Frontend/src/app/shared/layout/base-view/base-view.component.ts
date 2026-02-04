import { Component } from '@angular/core';
import { FooterComponent } from "../footer/footer.component";
import { HeaderComponent } from "../header/header.component";
// import { RouterOutlet } from "../../../../../node_modules/@angular/router/router_module.d-Bx9ArA6K";
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-base-view',
  imports: [FooterComponent, HeaderComponent, RouterOutlet],
  templateUrl: './base-view.component.html',
  styleUrl: './base-view.component.scss'
})
export class BaseViewComponent {

}
