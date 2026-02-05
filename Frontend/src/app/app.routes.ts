import { Routes } from '@angular/router';
import { BaseViewComponent } from './shared/layout/base-view/base-view.component';
import { ComponentTableComponent } from './views/component-table/component-table.component';
import { BoardTableComponent } from './views/board-table/board-table.component';
import { OrderComponent } from './views/order/order.component';

export const routes: Routes = [
    {
        path: '',
        component: BaseViewComponent,
        children: [
            {
                path: 'components',
                component: ComponentTableComponent
            },
            {
                path: 'boards',
                component: BoardTableComponent
            },
            {
                path: 'orders',
                component: OrderComponent
            }]
    }
];
