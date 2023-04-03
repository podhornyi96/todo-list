import {Component, EventEmitter, Input, Output} from '@angular/core';
import {TodoListItemModel} from "../shared/todo-list-item.model";
import {TodoListModel} from "../shared/todo-list.model";
import {TodoListService} from "../shared/todo-list.service";

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.scss']
})
export class TodoListComponent {

  @Input() todoList: TodoListModel;

  constructor(private todoListService: TodoListService) {
  }

  addListItem(description: string) {
    if (!description) return;

    const data: TodoListItemModel = {
      todoListId: this.todoList.id,
      description: description,
      isCompleted: false
    }

    this.todoListService.createListItem(data).subscribe(id => {
      data.id = id;

      this.todoList.todoListItems?.unshift(data);
    });
  }

  onItemDeleted(item: TodoListItemModel) {
    debugger
    this.todoListService.deleteListItem(this.todoList.id!, item.id!).subscribe(x => {
      this.todoList.todoListItems?.splice(this.todoList.todoListItems?.indexOf(item), 1);
    });
  }

}
