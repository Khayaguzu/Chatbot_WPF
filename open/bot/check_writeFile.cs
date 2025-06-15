using System.Collections.Generic;
using System.IO;
using System;

namespace open
{
    public class check_writeFile
    {

        // Since AppDomaun as global gives an error of static
        // Lets do a return method for it to return the path
        private string path_return()
        {
            // App Domain get full path
            string fullpath = AppDomain.CurrentDomain.BaseDirectory;
            // then replace the bin/Debug/
            // so its bin\\Debug\\ inside the "" no space
            string new_path = fullpath.Replace("bin\\Debug\\", "");
            // now combone the path of the new_path and the txt file
            string path = Path.Combine(new_path, "memory.txt");

            return path;


        }// end of the return path method

        // Now lets do the three methods

        // Method to check the txt file and create if not found
        public void check_file()
        {
            string path = path_return();
            // Now check if the paths exist or not then if not found create the txt file

            if (!File.Exists(path))
            {
                // this 
                //  it means if not, the path of the file is not found the create or do something

                File.Create(path);
            }
            else
            {
                // then if the is found 
                Console.WriteLine("Fils is found...");
            }

        }// end of method check_file

        //Now for the get what is in the file method 
        public List<string> return_memory()
        {
            // Now get the path of the file
            string path = path_return();

            return new List<string>(File.ReadAllLines(path));
            // by this you return all in the txt file

        }// end of the return_memeory method 

        // method to write to the file
        public void save_memory(List<string> save_new)
        {
            // get the path
            string path = path_return();

            //then for the parameter pass a List
            //then lets write to the txt file
            File.WriteAllLines(path, save_new);
            //if you pass a varable it gives you an error,you can test using variable


        }// end of the save_memeory method

    }//end of class
}// end of namespace