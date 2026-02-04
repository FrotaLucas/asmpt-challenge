import { HttpClient } from "@angular/common/http";
import { environment } from "../environments/environment.development";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BoardDto } from "../models/board";


@Injectable({
    providedIn: "root"
})

export class BoardService {

    private app: string;
    private api: string

    constructor(private http: HttpClient) {
        this.app = environment.baseUrl;
        this.api = "/boards"
    }

    getBoards(): Observable<BoardDto[]> {
        return this.http.get<BoardDto[]>(`${this.app}${this.api}`);
    }

    getBoard(id: number): Observable<BoardDto> {
        return this.http.get<BoardDto>(`${this.app}${this.api}/${id}`);
    }

    createBoard(board: BoardDto): Observable<BoardDto> {
        return this.http.post<BoardDto>(`${this.app}${this.api}`, board);
    }

    deleteBoard(id: number): Observable<void>{
        return this.http.delete<void>(`${this.app}${this.api}/${id}`);
    }

    updateBoard(board: BoardDto): Observable<BoardDto>{
        return this.http.put<BoardDto>(`${this.app}${this.api}`, board);
    }
}