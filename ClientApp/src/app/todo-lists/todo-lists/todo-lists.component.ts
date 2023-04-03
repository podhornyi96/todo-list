import {Component, OnInit} from '@angular/core';
import {TodoListModel} from "../shared/todo-list.model";
import {TodoListService} from "../shared/todo-list.service";

@Component({
  selector: 'app-todo-lists',
  templateUrl: './todo-lists.component.html',
  styleUrls: ['./todo-lists.component.scss']
})
export class TodoListsComponent implements OnInit {

  todoList: TodoListModel = {
    items: [
      {id: 1, description: 'test 1', isCompleted: false},
      {id: 2, description: 'test 2', isCompleted: false},
      {id: 3, description: 'test 3', isCompleted: true}
    ]
  };

  constructor(private todoListService: TodoListService) {
  }

  ngOnInit(): void {
    // const id = 1; // hardcoded jsut for demo purposes
    //
    // this.todoListService.getById(id).subscribe(x => {
    //   this.data = x;
    // });
  }

}
