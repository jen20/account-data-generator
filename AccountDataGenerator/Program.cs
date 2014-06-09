using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AccountDataGenerator
{
    class Program
    {
        private static readonly Random Random = new Random();

        static void Main()
        {
            const int numberOfAccounts = 30;
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            foreach (var number in Enumerable.Range(10001, numberOfAccounts))
            {
                var accountNumber = string.Format("currentAccount-{0}", number);
                var stream = GenerateAccountStream(accountNumber);

                var jsonString = JsonConvert.SerializeObject(stream.ToArray(), Formatting.Indented, jsonSerializerSettings);

                File.WriteAllLines(string.Format("{0}.json", accountNumber), new[] {jsonString});
                Console.WriteLine(jsonString);
            }

            Console.ReadLine();
        }

        static IEnumerable<EventJson> GenerateAccountStream(string accountNumber)
        {
            var eventStream = new List<EventJson>();
            var numberOfEvents = Random.Next(70, 100);
            var currentDate = DateTime.Now.Subtract(TimeSpan.FromDays(Random.Next(100, 150)));

            eventStream.Add(GenerateAccountOpenedEvent(accountNumber, currentDate));
            for (var i = 0; i < numberOfEvents; i++)
            {
                var pair = Random.Next(0, 2) == 0 ? GenerateDepositEvent(accountNumber, currentDate) :
                    GenerateWithdrawalEvent(accountNumber, currentDate);
                currentDate = pair.Item2;
                eventStream.Add(pair.Item1);
            }

            return eventStream;
        }

        static Tuple<EventJson, DateTime> GenerateDepositEvent(string accountNumber, DateTime currentDate)
        {
            var eventDate = currentDate.AddDays(1);

            var quantity = Random.Next(3, 450);

            var deposit = new FundsDeposited(accountNumber, eventDate, quantity);
            var eventId = Guid.NewGuid();
            const string eventType = "fundsDeposited";

            var eventJson = new EventJson(eventId, eventType, deposit);

            return new Tuple<EventJson, DateTime>(eventJson, eventDate);
        }
        
        static Tuple<EventJson, DateTime> GenerateWithdrawalEvent(string accountNumber, DateTime currentDate)
        {
            var eventDate = currentDate.AddDays(1);

            var quantity = Random.Next(3, 450);

            var deposit = new FundsWithdrawn(accountNumber, eventDate, quantity);
            var eventId = Guid.NewGuid();
            const string eventType = "fundsWithdrawn";

            var eventJson = new EventJson(eventId, eventType, deposit);

            return new Tuple<EventJson, DateTime>(eventJson, eventDate);
        }

        static EventJson GenerateAccountOpenedEvent(string accountNumber, DateTime date)
        {
            var accountOpened = new AccountOpened(accountNumber, date);
            var eventId = Guid.NewGuid();
            const string eventType = "accountOpened";

            return new EventJson(eventId, eventType, accountOpened);
        }
    }
}
