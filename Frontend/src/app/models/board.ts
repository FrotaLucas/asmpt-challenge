import { ComponentDto } from "./component";

export interface BoardDto {
    id: number,
    name: string,
    code: string,
    description: string,
    length: number,
    width: number,
    components: ComponentDto[]
}