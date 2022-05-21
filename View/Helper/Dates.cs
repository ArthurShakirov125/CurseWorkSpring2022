using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.View.Helper
{
    public class Dates
    {

        public Dates()
        {
            initializeDates();
        }
        public int[] days { get; set; }

        public int SelectedDay { get; set; }

        public int[] months { get; set; }

        public int SelectedMonth { get; set; }

        public int[] years { get; set; }

        public int SelectedYear { get; set; }


        private void initializeDates()
        {
            days = new int[31];

            for (int i = 0; i < 31; i++)
            {
                days[i] = i + 1;
            }

            months = new int[12];
            for (int i = 0; i < 12; i++)
            {
                months[i] = i + 1;
            }

            years = new int[50];

            for (int i = 0; i < 50; i++)
            {
                years[i] = 1980 + i;
            }
        }

        public DateTime MakeADate()
        {
            string date = string.Join("/", SelectedDay, SelectedMonth, SelectedYear);
            return DateTime.Parse(date);

        }
    }
}
