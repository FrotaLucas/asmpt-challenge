import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, map } from "rxjs";
import { environment } from "../environments/environment.development";
import { BoardDto } from "../models/board";
import { ApiResponse } from "../models/api-response";

@Injectable({
  providedIn: "root",
})
export class BoardService {
  private readonly baseUrl: string;
  private readonly apiPath: string;

  constructor(private http: HttpClient) {
    this.baseUrl = environment.baseUrl;
    this.apiPath = "/boards";
  }

  getBoards(): Observable<BoardDto[]> {
    return this.http
      .get<ApiResponse<BoardDto[]>>(`${this.baseUrl}${this.apiPath}`)
      .pipe(
        map((response) => {
          if (!response.success) {
            throw new Error(response.message || "Failed to fetch boards.");
          }
          return response.data;
        })
      );
  }

  getBoard(id: number): Observable<BoardDto> {
    return this.http
      .get<ApiResponse<BoardDto>>(`${this.baseUrl}${this.apiPath}/${id}`)
      .pipe(
        map((response) => {
          if (!response.success) {
            throw new Error(response.message || `Failed to fetch board with ID ${id}.`);
          }
          return response.data;
        })
      );
  }

  createBoard(board: BoardDto): Observable<BoardDto> {
    return this.http
      .post<ApiResponse<BoardDto>>(`${this.baseUrl}${this.apiPath}`, board)
      .pipe(
        map((response) => {
          if (!response.success) {
            throw new Error(response.message || "Failed to create board.");
          }
          return response.data;
        })
      );
  }

  updateBoard(board: BoardDto): Observable<BoardDto> {
    return this.http
      .put<ApiResponse<BoardDto>>(`${this.baseUrl}${this.apiPath}`, board)
      .pipe(
        map((response) => {
          if (!response.success) {
            throw new Error(response.message || "Failed to update board.");
          }
          return response.data;
        })
      );
  }

  deleteBoard(id: number): Observable<void> {
    return this.http
      .delete<ApiResponse<null>>(`${this.baseUrl}${this.apiPath}/${id}`)
      .pipe(
        map((response) => {
          if (!response.success) {
            throw new Error(response.message || `Failed to delete board with ID ${id}.`);
          }
          return; 
        })
      );
  }
}
