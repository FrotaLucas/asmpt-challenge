import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, map } from "rxjs";
import { environment } from "../environments/environment.development";
import { ApiResponse } from "../models/api-response";
import { OrderDto } from "../models/order";

@Injectable({
  providedIn: "root",
})
export class OrderService {
  private readonly baseUrl: string;
  private readonly apiPath: string;

  constructor(private http: HttpClient) {
    this.baseUrl = environment.baseUrl;
    this.apiPath = "/orders";
  }

  getOrders(): Observable<OrderDto[]> {
    return this.http
      .get<ApiResponse<OrderDto[]>>(`${this.baseUrl}${this.apiPath}`)
      .pipe(
        map((response) => {
          if (!response.success) {
            throw new Error(response.message || "Failed to fetch orders.");
          }
          return response.data;
        })
      );
  }

  getOrder(id: number): Observable<OrderDto> {
    return this.http
      .get<ApiResponse<OrderDto>>(`${this.baseUrl}${this.apiPath}/${id}`)
      .pipe(
        map((response) => {
          if (!response.success) {
            throw new Error(
              response.message || `Failed to fetch order with ID ${id}.`
            );
          }
          return response.data;
        })
      );
  }

  createOrder(order: any): Observable<OrderDto> {
    return this.http
      .post<ApiResponse<OrderDto>>(`${this.baseUrl}${this.apiPath}`, order)
      .pipe(
        map((response) => {
          if (!response.success) {
            throw new Error(response.message || "Failed to create order.");
          }
          return response.data;
        })
      );
  }
}
