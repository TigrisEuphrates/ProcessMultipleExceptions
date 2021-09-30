using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProcessMultipleExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("Rusty", 91);
            Car myCar2 = new Car("Rust", 91);
            myCar.CrankTunes(true);
            try
            {
                myCar2.Accelerate(10);
            }
            catch (CarIsDeadExeption e) when (e.ErrorTimeStamp.DayOfWeek!=DayOfWeek.Friday)
            {
                Console.WriteLine("Catching car is dead!");
                Console.WriteLine(e.Message);
            }
            try
            {
                myCar.Accelerate(10);
            }
            catch (CarIsDeadExeption e)
            {
                try
                {
                    FileStream fs = File.Open(@"D:\carErrors.txt", FileMode.Open);
                }
                catch (Exception e2)
                {
                    throw new CarIsDeadExeption(e.Message, e2);
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                myCar.CrankTunes(false);
            }
            Console.WriteLine();
            //try
            //{
            //    myCar.CrankTunes(true);
            //}
            //catch
            //{
            //    Console.WriteLine("Smth bad happened...");
            //}
            Console.WriteLine();
        }
    }
}
