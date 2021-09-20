using System;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public virtual int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            StringBuilder bobTheBuilder = new StringBuilder();
            bobTheBuilder.Append($"Name: {Name}, Age: {Age}");

            return bobTheBuilder.ToString();
        }

    }
}
