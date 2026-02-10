export interface OrderDto {
    orderNumber: string;
    name: string;
    description: string;
    orderDate: string; // string from Backend
    quantityBoards: number;
    quantityComponents: number;
}
