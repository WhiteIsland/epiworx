using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Tests.Helpers
{
    public class DataHelper
    {
        private static Random Random = new Random((int)DateTime.Now.Ticks);

        public static string RandomEmail()
        {
            var sb = new StringBuilder();

            sb.Append(DataHelper.RandomString(10));
            sb.Append("@");
            sb.Append(DataHelper.RandomString(20));
            sb.Append(".com");

            return sb.ToString();
        }

        public static string RandomPhoneNumber()
        {
            var sb = new StringBuilder();

            sb.Append("(");
            sb.Append(DataHelper.RandomNumber(3));
            sb.Append(") ");
            sb.Append(DataHelper.RandomNumber(3));
            sb.Append("-");
            sb.Append(DataHelper.RandomNumber(4));

            return sb.ToString();
        }

        public static int RandomNumber(int maxValue)
        {
            return DataHelper.RandomNumber(0, maxValue);
        }

        public static int RandomNumber(int minValue, int maxValue)
        {
            var random = new Random();

            return random.Next(minValue, maxValue);
        }

        public static string RandomString(int length)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                sb.Append(
                    Convert.ToChar(Convert.ToInt32(Math.Floor(26 * DataHelper.Random.NextDouble() + 65))));
            }

            return sb.ToString();
        }
    }
}
