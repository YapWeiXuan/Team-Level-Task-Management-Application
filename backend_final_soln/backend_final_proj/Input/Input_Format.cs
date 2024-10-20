namespace backend_final_proj.Input
{
    public class GET_Input_Format
    {
        private string? manager;
        private string? manager_email;
        private string? task_user;
        private string? task_title;
        private string? task_description;
        private DateTime time_created;
        private DateTime due_date;

        public string Manager
        {
            get
            {
                return this.manager;
            }
            set
            {
                if (value == null)
                {
                    this.manager = " ";
                }
                else { this.manager = value; }

            }

        }
        public string Manager_email
        {
            get
            {
                return this.manager_email;
            }
            set
            {
                if (value == null)
                {
                    this.manager_email = " ";
                }
                else { this.manager_email = value; }
            }

        }
        public string Task_user
        {
            get
            {
                return this.task_user;
            }
            set
            {
                if (value == null)
                {
                    this.task_user = " ";
                }
                else { this.task_user = value; }
            }

        }
        public string Task_title
        {
            get
            {
                return this.task_title;
            }
            set
            {
                if (value == null)
                {
                    this.task_title = " ";
                }
                else { this.task_title = value; }
            }

        }
        public string Task_description
        {
            get
            {
                return this.task_description;
            }
            set
            {
                if (value == null)
                {
                    this.task_description = " ";
                }
                else { this.task_description = value; }
            }

        }
        public DateTime Time_created
        {
            get
            {
                return this.time_created;
            }
            set
            {
                if (value == null)
                {
                    DateTime localDate = DateTime.Now;
                    this.time_created = localDate;
                }
                else { this.time_created = value; }
            }

        }
        public DateTime Due_date
        {
            get
            {
                return this.due_date;
            }
            set
            {
                if (value == null)
                {
                    DateTime localDate = DateTime.Now;
                    this.due_date = localDate;
                }
                else { this.due_date = value; }
            }

        }

    }
    public class DELETE_Input_Format
    {
        private string? manager;
        private string? manager_email;
        private string? task_user;
        private string? task_title;
        private string? task_description;

        public string Manager
        {
            get
            {
                return this.manager;
            }
            set
            {
                if (value == null)
                {
                    this.manager = " ";
                }
                else { this.manager = value; }

            }

        }
        public string Manager_email
        {
            get
            {
                return this.manager_email;
            }
            set
            {
                if (value == null)
                {
                    this.manager_email = " ";
                }
                else { this.manager_email = value; }
            }

        }
        public string Task_user
        {
            get
            {
                return this.task_user;
            }
            set
            {
                if (value == null)
                {
                    this.task_user = " ";
                }
                else { this.task_user = value; }
            }

        }
        public string Task_title
        {
            get
            {
                return this.task_title;
            }
            set
            {
                if (value == null)
                {
                    this.task_title = " ";
                }
                else { this.task_title = value; }
            }

        }
        public string Task_description
        {
            get
            {
                return this.task_description;
            }
            set
            {
                if (value == null)
                {
                    this.task_description = " ";
                }
                else { this.task_description = value; }
            }

        }

    }
}
