import {Component, EventEmitter, Input, Output} from '@angular/core';
import {TodoListItemModel} from "../shared/todo-list-item.model";
import {TodoListService} from "../shared/todo-list.service";

@Component({
  selector: 'app-todo-list-item',
  templateUrl: './todo-list-item.component.html',
  styleUrls: ['./todo-list-item.component.scss']
})
export class TodoListItemComponent {

  @Input() item: TodoListItemModel;
  @Output() itemDeleted = new EventEmitter<TodoListItemModel>();

  itemEdited = false;

  constructor(private todoListService: TodoListService) {
  }

  deleteItem() {
    this.itemDeleted.next(this.item);
  }

  updateItem() {
    this.todoListService.updateListItem(this.item).subscribe(x => {
      this.itemEdited = false;
    });
  }

}
