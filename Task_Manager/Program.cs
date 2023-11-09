using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Project gameProject = new Project(new DateTime(2025, 01, 01), "Создать игру", "другая компания");

            Employee sasha = new Employee("Саша", gameProject);
            Employee pety = new Employee("Петя", gameProject);
            Employee masha = new Employee("Маша", gameProject);
            Employee any = new Employee("Аня", gameProject);
            Employee daniil = new Employee("Даниил", gameProject);
            Employee vlad = new Employee("Влад", gameProject);
            Employee amir = new Employee("Амир", gameProject);
            Employee dasha = new Employee("Даша", gameProject);
            Employee tany = new Employee("Таня", gameProject);
            Employee dima = new Employee("Дима", gameProject);

            gameProject.MakeTeamLeader(daniil);

            Task task_1 = new Task(new DateTime(2024, 01, 10), "Что-то сделать", daniil, gameProject);
            Task task_2 = new Task(new DateTime(2024, 01, 11), "Что-то сделать", daniil, gameProject);
            Task task_3 = new Task(new DateTime(2024, 03, 12), "Что-то сделать", daniil, gameProject);
            Task task_4 = new Task(new DateTime(2024, 01, 13), "Что-то сделать", daniil, gameProject);
            Task task_5 = new Task(new DateTime(2024, 05, 14), "Что-то сделать", daniil, gameProject);
            Task task_6 = new Task(new DateTime(2024, 01, 15), "Что-то сделать", daniil, gameProject);
            Task task_7 = new Task(new DateTime(2024, 12, 16), "Что-то сделать", daniil, gameProject);
            Task task_8 = new Task(new DateTime(2024, 01, 17), "Что-то сделать", daniil, gameProject);
            Task task_9 = new Task(new DateTime(2024, 02, 18), "Что-то сделать", daniil, gameProject);
            Task task_10 = new Task(new DateTime(2024, 01, 19), "Что-то сделать", daniil, gameProject);

            daniil.AssignTask(task_1, sasha, gameProject);
            daniil.AssignTask(task_2, pety, gameProject);
            daniil.AssignTask(task_3, masha, gameProject);
            daniil.AssignTask(task_4, any, gameProject);
            daniil.AssignTask(task_5, daniil, gameProject);
            daniil.AssignTask(task_6, vlad, gameProject);
            daniil.AssignTask(task_7, amir, gameProject);
            daniil.AssignTask(task_8, dasha, gameProject);
            daniil.AssignTask(task_9, tany, gameProject);
            daniil.AssignTask(task_10, dima, gameProject);

            sasha.TakeTask();
            pety.TakeTask();
            masha.TakeTask();
            any.TakeTask();
            daniil.TakeTask();
            vlad.TakeTask();
            amir.Refuse();
            dasha.DelegateTask(amir);
            amir.TakeTask();
            tany.TakeTask();
            dima.TakeTask();
            daniil.Delete(task_7);
            Task task_11 = new Task(new DateTime(2024, 05, 19), "Что-то сделать", daniil, gameProject);
            daniil.AssignTask(task_11, dasha, gameProject);
            dasha.TakeTask();

            gameProject.NextStatus();

            sasha.CreateReport("Что-то сделал", new DateTime(2024, 01, 09));
            pety.CreateReport("Что-то сделал", new DateTime(2024, 21, 09));
            masha.CreateReport("Что-то сделал", new DateTime(2024, 01, 20));
            any.CreateReport("Что-то сделал", new DateTime(2024, 01, 01));
            daniil.CreateReport("Что-то сделал", new DateTime(2024, 04, 25));
            vlad.CreateReport("Что-то сделал", new DateTime(2024, 01, 02));
            amir.CreateReport("Что-то сделал", new DateTime(2024, 11, 08));
            tany.CreateReport("Что-то сделал", new DateTime(2024, 01, 16));
            dima.CreateReport("Что-то сделал", new DateTime(2024, 01, 30));
            dasha.CreateReport("Что-то сделал", new DateTime(2024, 01, 09));

            foreach (Task item in gameProject.Tasks)
            {
                daniil.CheckReport(item);
            }
            bool flag = true;
            foreach (Task item in gameProject.Tasks)
            {
                if (item.Status == Status_Task.в_работе)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                gameProject.EndStatus();
                Console.WriteLine("Проект закрыт");
            }
            else
            {
                Console.WriteLine("Проект не закончен");
            }
        }
    }
}
