import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {TodoListModel} from "./todo-list.model";
import {Observable} from "rxjs";
import {environment} from "../../../environments/environment";
import {TodoListItemModel} from "./todo-list-item.model";

@Injectable({
  providedIn: 'root'
})
export class TodoListService {

  constructor(private http: HttpClient) { }

  getById(id: number): Observable<TodoListModel> {
    return this.http.get<TodoListModel>(`${environment.apiUrl}/todolist/${id}`)
  }

  createListItem(model: TodoListItemModel) {
    return this.http.post<number>(`${environment.apiUrl}/todolist/${model.todoListId}/todolistitem`, model);
  }

  deleteListItem(todoListId: number, id: number) {
    return this.http.delete(`${environment.apiUrl}/todolist/${todoListId}/todolistitem/${id}`);
  }

}
