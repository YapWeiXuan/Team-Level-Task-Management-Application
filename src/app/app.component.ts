import { Component, DestroyRef } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { UserComponent } from "./user/user.component";
import { TaskComponent } from './task/task.component';
import { DUMMY_USERS } from './dummy-users';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CardComponent } from './shared/card/card.component';
import { RouterOutlet } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { inject } from '@angular/core';
import { TaskService } from './task/task.service';
import { FTask,Users } from './task/tasks/tasks.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,FormsModule,ReactiveFormsModule ,HeaderComponent, UserComponent,TaskComponent,CardComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})


export class AppComponent {

  selectedUserID?: string;

  app_tasks : any =  Array<FTask>;
  user_list: any = Array<Users>;
  APIRUL = "https://localhost:32769/";
  private httpClient = inject(HttpClient);
  private destroyRef = inject(DestroyRef);

  constructor(public tasksService:TaskService){};
  users = this.tasksService.users;


  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.get_all_task_and_users();

  }

  async get_all_task_and_users(){
    var subscription = await  this.httpClient
    .get("https://localhost:32769/get_tasks")
    .subscribe(
      (resData) =>{
        console.log(resData);

        this.app_tasks = resData as FTask[];

        //Convert json to list of dict
        // var json_alltasks = JSON.stringify(this.app_tasks);
        this.tasksService.getandsetAllTasks(this.app_tasks);
        //Convert list of dict to json
        // var json_parse_tasks = JSON.parse(json_alltasks);

    }
    );

    this.destroyRef.onDestroy(
      ()=>{
        subscription.unsubscribe();
      }
    );

    var subscription = await  this.httpClient
    .get("https://localhost:32769/get_dist_users")
    .subscribe(
      (resData) =>{
        console.log("get_dist_users : " +JSON.stringify(resData));

        this.user_list = resData as Users[];
        this.tasksService.getandsetAllUsers(this.user_list);
        this.users = this.tasksService.users;

    }
    );

    this.destroyRef.onDestroy(
      ()=>{
        subscription.unsubscribe();
      }
    );
  }

  get selectedUser(){
    console.log("selected User Tasks : " + this.users.find((user: any)=>user.task_user == this.selectedUserID))
    return this.users.find((user: any)=>user.task_user == this.selectedUserID);
    //need to add exclamation mark to convince typescript that will
    //always have value as there is a probability that get undefined which not allowed
    //typescript needs to be sure of types of values in and out, in the above case got probability that cant find value


  }

  onSelectUser(task_user:string){
    console.log('selected id'+ task_user);
    this.selectedUserID = task_user

  }
}
