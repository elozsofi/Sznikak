using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernLangToolsApp
{
    class ReportPrinter
    {
        private readonly IEnumerable<Person> people;
        private readonly Action headerPrinter;
        private readonly Action footerPrinter;
        private readonly Action<Person, int> personPrinter;

        public ReportPrinter(IEnumerable<Person> people, Action headerPrinter, Action<Person, int> personPrinter, Action footerPrinter)
        {
            this.people = people;
            this.headerPrinter = headerPrinter;
            this.personPrinter = personPrinter;
            this.footerPrinter = footerPrinter;
        }

        public void PrintReport()
        {
            headerPrinter();
            Console.WriteLine("-----------------------------------------");
            int i = 1;
            foreach (var person in people)
            {
                personPrinter(person, i++);
            }
            Console.WriteLine("--------------- Summary -----------------");
            footerPrinter();
        }
    }
}
