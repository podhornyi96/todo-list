import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {TodoListComponent} from "./todo-lists/todo-list/todo-list.component";
import {TodoListsComponent} from "./todo-lists/todo-lists/todo-lists.component";

const routes: Routes = [
  {path: '', component: TodoListsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
