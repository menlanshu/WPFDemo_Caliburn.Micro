using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoLibrary
{
    public class DataAccess
    {
        Random _rnd = new Random();
        string[] _streetAddresses = new string[]
            {
                "101 State Street",
                "102 State Street",
                "103 State Street",
                "104 State Street",
                "105 State Street",
                "106 State Street",
                "107 State Street",
                "109 State Street",
                "110 State Street",
            };
        string[] _cities = new string[]
            {
                "Shanghai",
                "Beijing",
                "GuangZhou",
                "Shenzhen",
                "Taizhou",
                "Lianyungang",
                "Kuanshan",
                "Changzhou",
                "Yancheng",
                "Huaian"
            };
        string[] _states = new string[]
            {
                "WI",
                "GA",
                "TX",
                "CA",
                "IL",
                "WA",
                "VA",
                "FL",
                "OK",
                "AZ"
            };
        string[] _zipCodes = new string[]
            {
                "1111",
                "2222",
                "3333",
                "4444",
                "5555",
                "6666",
                "7777",
                "8888",
                "9999",
                "1234"
            };

        private string[] _firstNames = new string[]
            {
                "Zhao",
                "Qian",
                "Sun",
                "Li",
                "Zhou",
                "Wu",
                "Zheng",
                "Wang",
                "Feng",
                "Chen",
            };
        private string[] _lastNames = new string[]
            {
                "Long",
                "Da",
                "Li",
                "Ting",
                "Hua",
                "Tian",
                "Jiu",
                "Di",
                "Mei",
                "Kong",
            };

        bool[] _aliveStatues = new bool[] { true, false };

        int _daysFromLowDate;
        private DateTime _lowEndDate = new DateTime(1943, 1, 1);


        public DataAccess()
        {
            _daysFromLowDate = (DateTime.Today - _lowEndDate).Days;
        }

        public List<PersonModel> GetPeople(int total = 10)
        {
            List<PersonModel> output = new List<PersonModel>();

            for (int i = 0; i < total; i++)
            {
                output.Add(GetPerson(i + 1));
            }

            return output;

        }

        public void AddPerson(IList<PersonModel> people)
        {
            int maxId = people.Count == 0 ? 1 : people.ToList().Max(x => x.PersonId);
            people.Add(GetPerson(maxId + 1));
        }

        public PersonModel GetPerson(int id)
        {
            PersonModel output = new PersonModel();

            output.PersonId = id;
            output.FirstName = GetRandomItem(_firstNames);
            output.LastName = GetRandomItem(_lastNames);
            output.IsAlive = GetRandomItem(_aliveStatues);
            output.DateOfBirth = GetRandomDate();
            output.Age = GetAgeInYears(output.DateOfBirth);
            output.AccountBalance = ((decimal)_rnd.Next(1, 100000) / 100);

            int addressCount = _rnd.Next(1, 5);

            for (int i = 0; i < addressCount; i++)
            {
                output.Addresses.Add(GetAddress(((id - 1) * 5) + i + 1));
            }

            return output;
        }

        private AddressModel GetAddress(int id)
        {
            AddressModel output = new AddressModel();

            output.AddressId = id;
            output.StreetAddress = GetRandomItem(_streetAddresses);
            output.City = GetRandomItem(_cities);
            output.State = GetRandomItem(_states);
            output.ZipCode = GetRandomItem(_zipCodes);

            return output;
        }

        private int GetAgeInYears(DateTime dateOfBirth)
        {
            DateTime now = DateTime.Today;

            int age = now.Year - dateOfBirth.Year;
            if (now < dateOfBirth.AddYears(age))
            {
                age--;
            }

            return age;
        }

        private DateTime GetRandomDate()
        {
            return _lowEndDate.AddDays(_rnd.Next(_daysFromLowDate));
        }

        public T GetRandomItem<T>(T[] data)
        {
            return data.Length == 0 ? default(T) : data[_rnd.Next(0, data.Length)];
        }
    }
}
