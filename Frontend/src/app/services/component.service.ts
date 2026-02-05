import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, map } from "rxjs";
import { environment } from "../environments/environment.development";
import { ComponentDto } from "../models/component";
import { ApiResponse } from "../models/api-response";

@Injectable({
  providedIn: "root",
})
export class ComponentService {
  private readonly baseUrl: string;
  private readonly apiPath: string;

  constructor(private http: HttpClient) {
    this.baseUrl = environment.baseUrl;
    this.apiPath = "/components";
  }

  getComponents(): Observable<ComponentDto[]> {
    return this.http
      .get<ApiResponse<ComponentDto[]>>(`${this.baseUrl}${this.apiPath}`)
      .pipe(
        map((response) => {
          if (!response.success) {
            throw new Error(response.message || "Failed to fetch components.");
          }
          return response.data;
        })
      );
  }

  getComponent(id: number): Observable<ComponentDto> {
    return this.http
      .get<ApiResponse<ComponentDto>>(`${this.baseUrl}${this.apiPath}/${id}`)
      .pipe(
        map((response) => {
          if (!response.success) {
            throw new Error(response.message || `Failed to fetch component with ID ${id}.`);
          }
          return response.data;
        })
      );
  }

  createComponent(component: ComponentDto): Observable<ComponentDto> {
    return this.http
      .post<ApiResponse<ComponentDto>>(`${this.baseUrl}${this.apiPath}`, component)
      .pipe(
        map((response) => {
          if (!response.success) {
            throw new Error(response.message || "Failed to create component.");
          }
          return response.data;
        })
      );
  }

  updateComponent(component: ComponentDto): Observable<ComponentDto> {
    return this.http
      .put<ApiResponse<ComponentDto>>(`${this.baseUrl}${this.apiPath}`, component)
      .pipe(
        map((response) => {
          if (!response.success) {
            throw new Error(response.message || "Failed to update component.");
          }
          return response.data;
        })
      );
  }

  deleteComponent(id: number): Observable<void> {
    return this.http
      .delete<ApiResponse<null>>(`${this.baseUrl}${this.apiPath}/${id}`)
      .pipe(
        map((response) => {
          if (!response.success) {
            throw new Error(response.message || `Failed to delete component with ID ${id}.`);
          }
          return;
        })
      );
  }
}
