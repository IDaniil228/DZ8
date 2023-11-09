using System;

namespace Task_Manager
{
    internal class Report
    {
        private string text;
        private DateTime date;
        private Employee implementer;

        public Report(string text, DateTime date, Employee employee)
        {
            this.text = text;
            this.date = date;
            implementer = employee;
        }
    }
}
