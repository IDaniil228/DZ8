using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    public enum Status { проект, исполнение, закрыт }
    internal class Project
    {
        private string description;
        private DateTime date;
        private string customer;
        private Employee teamLeader;
        private List<Task> tasks = new List<Task>();
        private Status status = Status.проект;

        public Project(DateTime date, string description, string customer)
        {
            this.date = date;
            this.description = description;
            this.customer = customer;
        }
        public List<Task> Tasks
        {
            get { return  tasks; }
        }
        public Status Status_
        {
            get { return status; }
            set { status = value; }
        }
        public void MakeTeamLeader(Employee teamLeader)
        {
            this.teamLeader = teamLeader;
            teamLeader.MakeTeamLeader();
        }
        /// <summary>
        /// Меняет статус проекта на "Исполнение"
        /// </summary>
        public void NextStatus()
        {
            status = Status.исполнение;
        }
        /// <summary>
        /// Закрывает проект
        /// </summary>
        public void EndStatus()
        {
            status = Status.закрыт;
        }
        /// <summary>
        /// Добовляет задачу в проект
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

    }
}
