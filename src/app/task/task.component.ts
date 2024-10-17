import { Component ,Input,input,Output, output,computed, signal, EventEmitter} from '@angular/core';
import { TasksComponent } from "./tasks/tasks.component";
import { Title } from '@angular/platform-browser';
import { NewTaskComponent } from './new-task/new-task.component';
import{type submit_task,Users} from './tasks/tasks.model';
import { TaskService } from './task.service';

@Component({
  selector: 'app-task',
  standalone: true,
  imports: [TasksComponent,NewTaskComponent],
  templateUrl: './task.component.html',
  styleUrl: './task.component.css'
})



export class TaskComponent {

  @Input({required:true}) name!: string ;
  @Input({}) avatar?:string ;

  isAddingTask = false;

  constructor(public tasksService:TaskService){}



  get imagePath(){
    return 'assets/users/' + this.avatar
  }


  get selectedUserTasks(){
    return this.tasksService.getUserTasks(this.name)
  }

  onStartAddTask(){
    this.isAddingTask = true;
  }

  onCloseAddTask(){
    this.isAddingTask = false;
  }

  onCompleteTask(id:string){

  }

  @Output() select = new EventEmitter<string>();

}
