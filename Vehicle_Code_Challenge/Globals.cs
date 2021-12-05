using System;

namespace Vehicle_Code_Challenge
{
    public static class Globals
    {
        //Sets the current year to an int that can be used throughout the program for age checks.
        public static int currentYear = System.DateTime.Now.Year;
        //Sets one instance of random to be used for generating lists
        public static Random random = new();
    }
}
