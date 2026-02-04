import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Component } from "../models/component";
import { environment } from "../environments/environment.development";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})

export class ComponentService {

    private app: string;
    private api: string;

    constructor(private http: HttpClient) {
        this.app = environment.baseUrl;
        this.api = "/components";
    }

    getComponents(): Observable<Component[]> {
        return this.http.get<Component[]>(`${this.app}${this.api}`);
    }

    getComponent(id:number): Observable<Component> {
        return this.http.get<Component>(`${this.app}${this.api}/${id}`)
    }

    createComponent(component: Component): Observable<Component>{
        return this.http.post<Component>(`${this.app}${this.api}`, component);
    }

    //backend reuturn object with boolean
    deleteComponent(id: number): Observable<void>{
        return this.http.delete<void>(`${this.app}${this.api}/${id}`);
    }
}