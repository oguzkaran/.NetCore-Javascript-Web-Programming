using CSD.Application.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace CSD.Application.Factories
{
    public class PersonFactory
    {
        private static Person createPerson(string[] personInfo)
        {
            return new Person
            {
                Id = int.Parse(personInfo[0]),
                Name = personInfo[1],
                Email = personInfo[2],
                MaritalStatus = (MaritalStatus)int.Parse(personInfo[3]),
                BirthDate = DateTime.Parse(personInfo[4])
            };
        }
        private void loadPerson(string path)
        {
            using var sr = new StreamReader(path);

            string line;

            sr.ReadLine();

            while ((line = sr.ReadLine()) != null)
                Persons.Add(createPerson(line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)));


        }

        public List<Person> Persons { get; private set; } = new List<Person>();

        public PersonFactory(string path)
        {
            loadPerson(path);
        }
    }
  
}
