import { BoardDto } from "./board";

export interface OrderDto {
    orderNumber: string;
    name: string;
    description: string;
    orderDate: string; // string from Backend
    quantityBoards: number | null;
    quantityComponents: number | null;
    boards: BoardDto[]
}
