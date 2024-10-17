import { FTask,Users } from './../tasks/tasks.model';
import { Component, Input, Output,EventEmitter, signal, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import{type submit_task} from '../tasks/tasks.model';
import { TaskService } from '../task.service';

@Component({
  selector: 'app-new-task',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './new-task.component.html',
  styleUrl: './new-task.component.css'
})


export class NewTaskComponent {

  @Input({required:true}) userId! : string;
  @Output() close = new EventEmitter<void>();


  enteredTitle = ''
  enteredSummary = ''
  enteredDate = ''

  private tasksService = inject(TaskService)


  onCloseAddTask(){
    this.close.emit();
  }

  onSubmitTask(){
    console.log("onSubmitTask manager : " +this.tasksService.tasks[0].manager)
    var new_task = {


      id:new Date().getTime().toString(),
      manager : this.tasksService.tasks[0].manager,
      manager_email : this.tasksService.tasks[0].manager_email,
      task_user : this.userId,
      task_title : this.enteredTitle,
      task_description : this.enteredSummary ,
      time_created: new Date().getTime().toString(),
      due_date: this.enteredDate,

    };
    var json_alltasks = JSON.stringify(new_task);
    console.log("onSubmitTask new_task : " +json_alltasks)
    this.tasksService.addTask(new_task,this.userId)


    this.close.emit();
  }


}
