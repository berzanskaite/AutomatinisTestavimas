using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas
{
    public class Demo
    {
        [Test]
        public static void TestIf4IsEven()
        {
            int leftover = 4 % 2;
            Assert.AreEqual(0, leftover, "4 is not even");
        }

        [Test]
        public static void TestNowIs19()
        {
            DateTime CurrentTime = DateTime.Now;
            Assert.IsTrue(CurrentTime.Hour.Equals(19), "Dabar ne 19 valanda");
        }

        [Test]
        public static void Test995DalijasiIs3()
        {
            int liekana = 995 % 3;
            Assert.AreEqual(0, liekana, "995 nesidalija is 3 be liekanos");
        }

        [Test]
        public static void TestTodayIsMonday()
        {
            DayOfWeek Siandien = DayOfWeek.Monday;
            Assert.IsTrue(Siandien.Equals(DayOfWeek.Monday));
        }

        [Test]
        public static void TestWaitFor5Sec()
        {
            Thread.Sleep(5000);
        }


    }
}
