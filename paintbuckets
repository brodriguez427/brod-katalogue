using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            // You are helping with a local soccer league
            // They need to be able to paint their fields
            // to mark the center circle. Different leagues
            // have different sized circles, however. Make
            // a program that will ask for the size of the
            // circle and then tell them how much paint they
            // need to cover the center circle. The paint
            // they use covers about 100 sq ft per bucket.
            // Make sure they have enough paint, it's ok
            // if there is some extra left in the last
            // bucket

            // Show the output like this:
            // It will take 8 buckets to paint the 15' radius circle

            // Bonus: Different colors cover better than
            // others. Let the user pick the color and show
            // the result. The colors are as follows:
            // Red = 100 sq ft/bucket
            // Blue = 120 sq ft/bucket
            // Green = 90 sq ft/bucket
            // Yellow = 70 sq ft/bucket

            // Extra Bonus: The colors also cost different
            // amounts. Tell the user how much it will cost
            // to paint their field.
            // Red = 25$ / bucket
            // Blue = 28$ / bucket
            // Green = 33$ / bucket
            // Yellow = 22$ / bucket


// Get radius of circle
            Console.WriteLine("What is the radius of your circle?");
            double Radius = Convert.ToDouble(Console.ReadLine());
            // Return area of circle
            double Area = Radius * Radius * Math.PI;
            Console.WriteLine("The area of your circle is " + Area);
            // Ask for color of circle
            Console.WriteLine("What color do you want to paint your circle?");
            string UserColor = Console.ReadLine();
            // Return amount of paint needed to paint the circle chosen color
            if (UserColor == "red")
            {
                double Buckets = Math.Ceiling(Area / 100);
                Console.WriteLine("You need " + Buckets + " buckets of " + UserColor + " paint.");
                decimal Cost = Convert.ToDecimal(Buckets) * 25.00m;
            }
            else if (UserColor == "blue")
            {
                double Buckets = Math.Ceiling(Area / 120);
                Console.WriteLine("You need " + Buckets + " buckets of " + UserColor + " paint.");
                decimal Cost = Convert.ToDecimal(Buckets) * 28.00m;
            }
            else if (UserColor == "green")
            {
                double Buckets = Math.Ceiling(Area / 90);
                Console.WriteLine("You need " + Buckets + " buckets of " + UserColor + " paint.");
                decimal Cost = Convert.ToDecimal(Buckets) * 33.00m;
            }
            else if (UserColor == "yellow")
            {
                double Buckets = Math.Ceiling(Area / 70);
                Console.WriteLine("You need " + Buckets + " buckets of " + UserColor + " paint.");
            }

            Console.ReadLine();
            // Return cost of paint


        }
    }
}
