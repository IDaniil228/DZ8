using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    internal class Employee
    {
        private bool teamLeader = false;
        private string name;
        private Task task;
        private Project project;

        public Task Task
        {
            get { return task; }
            set { task = value; }
        }

        public Employee(string name, Project project) 
        {
            this.project = project;
            this.name = name;
        }
        public bool TeamLeader
        {
            get { return teamLeader; }
        }
        /// <summary>
        /// Назначает человека на роль тим лида 
        /// </summary>
        public void MakeTeamLeader()
        {
            teamLeader = true;
        }
        /// <summary>
        /// Назначает задачу сотруднику
        /// </summary>
        public void AssignTask(Task task, Employee person, Project project)
        {
            if (teamLeader)
            {
                if (project.Status_ == Status.исполнение)
                {
                    Console.WriteLine("Нельзя назначать задачи в этом статусе проекта");
                }
                else 
                {
                    task.Implementer = person;
                    person.Task = task;
                }
            }
            else 
            {
                Console.WriteLine("Этот сотрудник не может назначать задачи");
            }
        }
        /// <summary>
        /// Удаляет задачу
        /// </summary>
        public void Delete(Task task)
        {
            project.Tasks.Remove(task);
        }
        /// <summary>
        /// Взять задачу в работу
        /// </summary>
        public void TakeTask()
        {
            Task.ToInWork();
        }
        /// <summary>
        /// Делегирование задачи другому сотруднику
        /// </summary>
        /// <param name="person"></param>
        public void DelegateTask(Employee person)
        {
            if (person.Task == null)
            {
                task.Implementer = person;
                person.Task = task;
                task = null;
            }
            else
            {
                Console.WriteLine("Нельзя делегировать задачу этому сотруднику");
            }
        }
        /// <summary>
        /// Отказ сотрудника от задачи 
        /// </summary>
        public void Refuse()
        {
            task.Implementer = null;
            task = null;
        }
        /// <summary>
        /// Создание отчета по задаче
        /// </summary>
        /// <param name="text"></param>
        /// <param name="date"></param>
        public void CreateReport(string text, DateTime date)
        {
            task.ToOnChecking();
            task.Report = new Report(text, date, this); 
        }
        public void CheckReport(Task task)
        {
            if (this.TeamLeader)
            {
                Console.WriteLine("Принят отчет или нет(yes/no)");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes")
                {
                    task.ToDone();
                }
                else 
                {
                    task.ToInWork();
                }
            }
            else
            {
                Console.WriteLine("Этот сотрудник не может проверять отчеты");
            }
        }
    }
}
