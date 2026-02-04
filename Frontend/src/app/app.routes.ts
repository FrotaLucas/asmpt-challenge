import { Routes } from '@angular/router';
import { BaseViewComponent } from './shared/layout/base-view/base-view.component';
import { ComponentComponent } from './shared/views/component/component.component';
import { BoardComponent } from './shared/views/board/board.component';

export const routes: Routes = [
    {
        path:' ', 
        component: BaseViewComponent,
        children: [
            {path: 'components', component: ComponentComponent},
            {path: 'boards', component: BoardComponent}]
    }
];
