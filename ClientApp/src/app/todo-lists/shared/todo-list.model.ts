import {TodoListItemModel} from "./todo-list-item.model";

export class TodoListModel {
  id?: number;
  todoListItems: TodoListItemModel[] | undefined;
}
