using Fare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class GeneratorForRecords
    {
        private static Random _random = new Random();

        public GeneratorForRecords()
        { }

        public string GenerateCreditCard()
        {
            var builder = new StringBuilder();

            while (builder.Length < 16)
            {
                builder.Append(_random.Next(9).ToString());
            }

            return builder.ToString();
        }

        public double GeneratePrice(bool isOneInstallment)
        {
            if (isOneInstallment)
            {
                return _random.NextDouble() + _random.Next(5000);
            }

            return _random.NextDouble() + _random.Next(int.MaxValue / 10);
        }
        public string GenerateStoreId()
        {
            Xeger xeger = new Xeger(@"^[A-F][A-D]\d{5}", _random);

            return xeger.Generate();
        }

        public DateTime GenerateDate(char activityDays = ' ')
        {
            var start = new DateTime(2000, 1, 1);
            var range = (DateTime.Today - start).Days;
            var date = start.AddDays(_random.Next(range));

            if (activityDays == 'B')
            {
                while ((int)date.DayOfWeek == 6)
                {
                    date = start.AddDays(_random.Next(range));
                }
            }
            else if (activityDays == 'C')
            {
                while ((int)date.DayOfWeek == 6 || (int)date.DayOfWeek == 5)
                {
                    date = start.AddDays(_random.Next(range));
                }
            }

            return date;
        }

        public dynamic GenerateInstallmentsByPrice(bool isMoreThenOneInstallment, double price)
        {
            var oneInstallmentOptions = new dynamic[] { "FULL", 1, String.Empty };
            if (isMoreThenOneInstallment)
            {
                return _random.Next(2, ((int)price) * 10);
            }
            else
            {
                return oneInstallmentOptions[_random.Next(oneInstallmentOptions.Length)];
            }
        }
    }
}
