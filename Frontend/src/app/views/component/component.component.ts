import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ComponentService } from '../../services/component.service';
import { ComponentDto } from '../../models/component';

@Component({
  selector: 'app-component',
  standalone: true,
  imports: [],
  templateUrl: './component.component.html',
  styleUrl: './component.component.scss'
})

export class ComponentComponent implements OnInit, AfterViewInit {

  listOfComponents!: ComponentDto[];

  constructor(private componentService: ComponentService) {

  }

  ngOnInit(): void {

  }

  ngAfterViewInit(): void {

  }

  refreshPage() : void {
    this.componentService.getComponents().subscribe(data => {
      this.listOfComponents = data;
    })
  }

}
