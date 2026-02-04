import { HttpClient } from "@angular/common/http";
import { environment } from "../environments/environment.development";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Board } from "../models/board";


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

    getBoards(): Observable<Board[]> {
        return this.http.get<Board[]>(`${this.app}${this.api}`);
    }

    getBoard(id: number): Observable<Board> {
        return this.http.get<Board>(`${this.app}${this.api}/${id}`);
    }

    createBoard(board: Board): Observable<Board> {
        return this.http.post<Board>(`${this.app}${this.api}`, board);
    }

    deleteBoard(id: number): Observable<void>{
        return this.http.delete<void>(`${this.app}${this.api}/${id}`);
    }

    updateBoard(board: Board): Observable<Board>{
        return this.http.put<Board>(`${this.app}${this.api}`, board);
    }
}