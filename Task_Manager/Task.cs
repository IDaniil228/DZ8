using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    public enum Status_Task{ назначена, в_работе, на_проверке, выполнена }
    internal class Task
    {
        private string description;
        private DateTime date;
        private Employee customer;
        private Status_Task status = Status_Task.назначена;
        private Employee implementer;
        private Report report;

        public Task(DateTime date, string description, Employee customer, Project project)
        {
            this.date = date;
            this.description = description;
            this.customer = customer;
            project.AddTask(this);
        }
        public Report Report
        {
            get { return  report; }
            set { report = value; }
        }

        public Employee Implementer
        {
            get { return implementer; }
            set { implementer = value; }
        }
        public Status_Task Status
        {
            get { return status; }
        }

        /// <summary>
        /// Меняет статус задачи на "в работе"
        /// </summary>
        public void ToInWork()
        {
            status = Status_Task.в_работе;
        }
        /// <summary>
        /// Меняет статус задачи на "на проверке"
        /// </summary>
        public void ToOnChecking()
        {
            status = Status_Task.на_проверке;
        }
        /// <summary>
        /// Меняет статус задачи на "выполнена"
        /// </summary>
        public void ToDone()
        {
            status = Status_Task.выполнена;
        }

    }
}
