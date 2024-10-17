# Team-Level-Task-Management-Application
A team level task management web application utilizing Angular.js framework (TypeScript) for the front-end and ASP.NET Core framework (C#) for the back-end. SQL Server data base instance is used to store the users' task data. Web application is deployed in Microsoft Azure.

### Start Application
#### For Frontend
In Visual Studio Code terminal, run "npm install" > "ng serve" at the cloned frontend_final directory. 
#### For Backend
Open Docker Desktop and download the nuget packages Microsoft.AspNetCore.Mvc.NewtonsoftJson (Version: 8.0.4) , Microsoft.Data.SqlClient (Version: 5.1.6) in Visual Studio , click "Run Container (Dockerfile)".

# Application Usage Showcase
1. Application Home Page    
![image](https://github.com/user-attachments/assets/fb4d0291-c8c0-4f65-9373-6240c12ded5f)    

2. Select a User's name to view their respective tasks which each task detailing the task's title , description and due date.    
![image](https://github.com/user-attachments/assets/0cd485fe-59a8-4840-8007-2ba45c9ab107)    

3. Click "Add Task" to open dialog box to fill in the new task information. Then click "Create" to add the task or "Cancel" to exit dialog box without adding.   
![image](https://github.com/user-attachments/assets/064f3f6f-4865-443b-8eda-fb3f2f52764f)   

4. Added new task in the homepage   
![image](https://github.com/user-attachments/assets/2af35721-b30b-4174-b6ed-6f93c0a57bd9)   

5. Click "Complete" to remove task from the selected user's task list   
![image](https://github.com/user-attachments/assets/a89d7b40-692a-4505-b8ea-089801b1e697)    


# Future Add Ons and Improvements
1. Add a "Add User" button in the homepage for the team leader using this web application to add new team members to the users list as currently new team members are added through the SQL server.
 
2. Deploy the application onto Microsoft Azure platform as its currently hosted locally.

3. Implement a login box when the web application first boots up to retrieve a team leader's memberrs' tasks, this allows the web application to be used among multiple teams as opposed to only 1.
