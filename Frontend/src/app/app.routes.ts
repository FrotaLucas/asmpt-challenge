import { Routes } from '@angular/router';
import { BaseViewComponent } from './shared/layout/base-view/base-view.component';
import { ComponentComponent } from './views/component-table/component.component';
import { BoardComponent } from './views/board-table/board.component';
import { OrderComponent } from './views/order-table/order.component';

export const routes: Routes = [
    {
        path: '',
        component: BaseViewComponent,
        children: [
            {
                path: 'components',
                component: ComponentComponent
            },
            {
                path: 'boards',
                component: BoardComponent
            },
            {
                path: 'orders',
                component: OrderComponent
            }]
    }
];
