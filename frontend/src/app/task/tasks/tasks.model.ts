export interface Task{
    id:string;
    userId: string;
    title:string;
    summary:string;
    dueDate:string
  }

export interface FTask{
  id:string;
  manager: string;
  manager_email:string;
  task_user:string;
  task_title:string;
  task_description:string;
  time_created:string;
  due_date:string
}

export interface submit_task{
  title:string;
  summary: string;
  date:string
}

export interface Users{
  task_user:string;
}
