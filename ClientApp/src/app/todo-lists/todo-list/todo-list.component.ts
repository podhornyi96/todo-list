import {Component, Input} from '@angular/core';
import {TodoListItemModel} from "../shared/todo-list-item.model";
import {TodoListModel} from "../shared/todo-list.model";

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.scss']
})
export class TodoListComponent {

  @Input() todoList: TodoListModel;

}
