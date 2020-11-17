using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VCSprojektasAT
{
    public class Class1
    {

        [Test]
        public static void TestIf4IsEven()
        {
            // testas, ar 4 dalinas be liekanos
            int leftover = 4 % 2;
            Assert.AreEqual(0, leftover, "4 is not even");

        }

        [Test]

        public static void TestNowIs18H()
        {   //Patikrinkime ar 18valanda dabar
            DateTime CurrentTime = DateTime.Now;
            Assert.IsTrue(CurrentTime.Hour.Equals(21), "Dabar ne 18 valanda!");
        }


        [Test]
        public static void TestIf995IsEvenFrom3()
        {
            //testas ar 995 dalinas is 3 be liekanos
            int leftover = 995 % 3;
            Assert.AreEqual(2, leftover, "995 is not even");
        }
        [Test]

        public static void TestIfTodayIsWednesday()
        {
            DateTime now = DateTime.Now;
            
             string s = now.DayOfWeek.ToString();

            Assert.AreEqual(DayOfWeek.Friday.ToString(),s, "Siandien ne treciadienis");
        }

        [Test]
        public static void TestToWait5S()
        {
            Thread.Sleep(5000);
        }









    }
}
