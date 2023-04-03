import {Component, EventEmitter, Input, Output} from '@angular/core';
import {TodoListItemModel} from "../shared/todo-list-item.model";

@Component({
  selector: 'app-todo-list-item',
  templateUrl: './todo-list-item.component.html',
  styleUrls: ['./todo-list-item.component.scss']
})
export class TodoListItemComponent {

  @Input() item: TodoListItemModel;
  @Output() itemDeleted = new EventEmitter<TodoListItemModel>();

  deleteItem($event: any) {

    this.itemDeleted.next(this.item);
  }

}
