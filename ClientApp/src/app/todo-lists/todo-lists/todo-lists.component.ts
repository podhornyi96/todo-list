import {Component, OnInit} from '@angular/core';
import {TodoListModel} from "../shared/todo-list.model";
import {TodoListService} from "../shared/todo-list.service";
import {TodoListItemModel} from "../shared/todo-list-item.model";

@Component({
  selector: 'app-todo-lists',
  templateUrl: './todo-lists.component.html',
  styleUrls: ['./todo-lists.component.scss']
})
export class TodoListsComponent implements OnInit {

  todoList: TodoListModel;

  constructor(private todoListService: TodoListService) {
  }

  ngOnInit(): void {
    const id = 1; // hardcoded just for demo purposes

    this.todoListService.getById(id).subscribe(x => {
      this.todoList = x;
    });
  }

}
