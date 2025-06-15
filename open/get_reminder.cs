using System.Collections.Generic;
using System;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;

namespace open
{
    public class get_reminder
    {
        // Global arrays or generics
        private List<string> descriptions = new List<string>();
        private List<string> dates = new List<string>();
        // Validate user input

        public string validate_input(string user_input)
        {
            // check if empty or not 
            if (user_input != "")
            {
                // return found
                return "found";


            }// end of if
            else
            {
                // then return an error message
                return "Please add a task.";

            }// end of else

        }// end of the method to validate

        // method to get number

        public string get_days(string day)
        {
            //Get the numbers from the users input
            string get_day_in = Regex.Replace(day, @"[^\d]", "");

            // check if the is 0 
            if (get_day_in != "0")
            {

                return get_day_in;
            }
            else
            {
                return "today";
            }
        }// end of get days method

        // method to store to days date

        public string today_date(string description, string date)


        {
            // validate

            if (date == "today")
            {
                // get the date 
                DateTime today_date = DateTime.Now.Date;
                string format_date = today_date.ToString("yyyy-MM-dd");

                //add all

                descriptions.Add(description);
                dates.Add(format_date);

                return "Nice, will remind you in " + date;
            }
            else
            {
                return "error";
            }

        }  // end of  method to store to days date

        // Get the reminder date

        public string get_reminderDate(string description, string date)
        {
            //Get the current date
            DateTime currentDate = DateTime.Now.Date;

            // then format date

            string format_date = currentDate.ToString("yyyy-MM-dd");

            // Get the day in the format

            string find_day = format_date.Substring(8, 2);

            //Get date from 2 to 8

            string final_date = format_date.Substring(0, 8);

            int total_days = int.Parse(find_day) + int.Parse(date);
            string store_date = final_date + total_days;

            descriptions.Add(description);
            dates.Add(store_date);

            return "done";
        }// end of method date

        // method to check reminders
        public string get_remind()

        {
            // then searrch for today
            DateTime today = DateTime.Now.Date;
            string now_date = today.ToString("yyyy-MM-dd");

            string found_remind = "";
            {
                for (int count = 0; count < dates.Count; count++)
                {
                    // check for the date

                    if (dates[count] == now_date)
                    {
                        // then append message
                        found_remind += "\nDue Today:" + descriptions[count] + "\n +dates"[count];

                    }// end of if 
                    else
                    {
                        found_remind += "\n" + descriptions[count] + "\n" + dates[count];
                    }
                }
            }
            return found_remind;
        }
    }// end of a class
}// end of a name space