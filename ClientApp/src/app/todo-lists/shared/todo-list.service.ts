import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {TodoListModel} from "./todo-list.model";
import {Observable} from "rxjs";
import {environment} from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class TodoListService {

  constructor(private http: HttpClient) { }

  getById(id: number): Observable<TodoListModel> {
    return this.http.get<TodoListModel>(`${environment.apiUrl}/todolist/${id}`)
  }

}
