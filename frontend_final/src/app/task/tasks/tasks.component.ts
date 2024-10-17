import { Component, EventEmitter, Input, Output,inject } from '@angular/core';
import { Task,FTask,Users } from './tasks.model';
import { CardComponent } from '../../shared/card/card.component';
import { DatePipe } from '@angular/common';
import { TaskService } from '../task.service';

@Component({
  selector: 'app-tasks',
  standalone: true,
  imports: [CardComponent,DatePipe],
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css'
})


export class TasksComponent {
  @Input({required:true}) task!:FTask;

  private tasksService = inject(TaskService);


  onCompleteTask(){
    this.tasksService.removeTask(this.task , this.task.task_title);
  }

}
