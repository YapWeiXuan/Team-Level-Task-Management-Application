import { JsonPipe } from '@angular/common';
import{type FTask,Task,submit_task,Users} from './tasks/tasks.model'
import { inject,Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DestroyRef } from '@angular/core';


@Injectable({providedIn:'root'})
export class TaskService{

  public tasks : any =  Array<FTask>;
  public users : any = Array<String>;


  constructor(){

  }

  app_tasks : any =  Array<FTask>;
  APIRUL = "https://localhost:32769/";
  private httpClient = inject(HttpClient);
  private destroyRef = inject(DestroyRef);

  private saveTasks(){
    localStorage.setItem('tasks', JSON.stringify(this.tasks))
  }

  getandsetAllTasks( alltasks:FTask[]){
    console.log("alltasks : ")
    console.log(alltasks);

    this.tasks = alltasks;

  }

  getandsetAllUsers( allusers:Users[]){
    console.log("users : ")
    console.log(this.users);

    this.users = allusers;

  }


  getUserTasks(userId:string){
    return this.tasks.filter((x:any) =>x.task_user == userId);
  }

  async addTask(taskData: FTask,userId:string){

    this.tasks.push(taskData)

    const formData = new FormData()
    formData.append("Manager",taskData.manager)
    formData.append("Manager_email",taskData.manager_email)
    formData.append("Task_user",taskData.task_user)
    formData.append("Task_title",taskData.task_title)
    formData.append("Task_description",taskData.task_description)
    formData.append("Time_created","2024-10-24")
    formData.append("Due_date",taskData.due_date)


    console.log("addTask formData : " + formData.toString())
    var subscription = await  this.httpClient
    .post("https://localhost:32769/add_tasks",formData)
    .subscribe(
      {
        next : (resData) => console.log(resData)
      }

    );

    this.destroyRef.onDestroy(
      ()=>{
        subscription.unsubscribe();
      }
    );

    this.saveTasks();

  }


  async removeTask(taskData: FTask,task_title:string){
    this.tasks = this.tasks.filter((x:any)=>(x.task_user != taskData.task_user || x.task_title != taskData.task_title)) ;
    console.log("removetask filter : " + JSON.stringify(this.tasks))


    const formData = new FormData()
    formData.append("Manager",taskData.manager)
    formData.append("Manager_email",taskData.manager_email)
    formData.append("Task_user",taskData.task_user)
    formData.append("Task_title",taskData.task_title)
    formData.append("Task_description",taskData.task_description)

    var subscription = await  this.httpClient
    .post("https://localhost:32769/delete_tasks",formData)
    .subscribe(
      {
        next : (resData) => console.log(resData)
      }

    );

    this.destroyRef.onDestroy(
      ()=>{
        subscription.unsubscribe();
      }
    );


    this.saveTasks();

  }

}
