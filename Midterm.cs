namespace DSA;

using System;
using System.Collections.Generic;


public class Program
{
    public class Employee
    {
        public string full_name { get; set; }
        public bool gender { get; set; }
        public DateTime approval_time { get; set; }
        public string education_level { get; set; }

        public override string ToString()
        {
            return $"Employee(Full Name: {full_name}, Gender: {gender}, Appoval Time: {approval_time}, Education Level: {education_level})";
        }
    }

    public class ERM
    {
        private List<string> keys;
        private List<Employee> values;

        public ERM()
        {
            keys = new List<string>();
            values = new List<Employee>();
        }

        public void Add(string key, Employee value)
        {
            keys.Add(key);
            values.Add(value);
        }

        public void Remove(string key)
        {
            int index = keys.IndexOf(key);
            if (index != -1)
            {
                keys.RemoveAt(index);
                values.RemoveAt(index);
            }
        }

        public void Map(int n)
        {
            if (n >= 0)
            {
                List<string> newKeys = new List<string>();
                List<Employee> newValues = new List<Employee>();

                for (int i = 0; i < keys.Count; i++)
                {
                    newKeys.Add(keys[i]);
                    newValues.Add(values[(i + n) % keys.Count]);
                }

                keys = newKeys;
                values = newValues;
            }
        }

        public void Sort()
        {
            for (int i = 0; i < keys.Count - 1; i++)
            {
                for (int j = 0; j < keys.Count - i - 1; j++)
                {
                    if (string.Compare(keys[j], keys[j + 1]) > 0)
                    {
                        Swap<string>(keys, j, j + 1);
                        Swap<Employee>(values, j, j + 1);
                    }
                }
            }
        }

        public void Swap<T>(List<T> list, int indexA, int indexB)
        {
            T temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }

        public void Print()
        {
            for (int i = 0; i < keys.Count; i++)
            {
                Console.WriteLine($"{keys[i]}: {values[i]}");
            }
        }
    }

    public static void Main(string[] args)
    {
        // Create an instance of ERM
        ERM erm = new ERM();

        // Create some employees
        Employee employee1 = new Employee
        {
            full_name = "Huong Dat Huy",
            gender = true,
            approval_time = DateTime.Now,
            education_level = "Bachelor"
        };

        Employee employee2 = new Employee
        {
            full_name = "Luong Ngan Ha",
            gender = false,
            approval_time = DateTime.Now,
            education_level = "Bachelor"
        };

        Employee employee3 = new Employee
        {
            full_name = "Pham Thanh Nhan",
            gender = true,
            approval_time = DateTime.Now,
            education_level = "Bachelor"
        };

        Employee employee4 = new Employee
        {
            full_name = "Phan Hien",
            gender = true,
            approval_time = DateTime.Now,
            education_level = "Master"
        };

        Employee employee5 = new Employee
        {
            full_name = "Nguyen Manh Tuan",
            gender = true,
            approval_time = DateTime.Now,
            education_level = "PhD"
        };

        // Them 5 nhan vien
        erm.Add("007", employee1);
        erm.Add("003", employee2);
        erm.Add("002", employee3);
        erm.Add("005", employee4);
        erm.Add("010", employee5);
        Console.WriteLine("Da them 5 nhan vien:");
        erm.Print();

        // Sort ERM
        erm.Sort();
        Console.WriteLine("Da sort ERM:");
        erm.Print();

        // Map ERM
        int n = 2;
        erm.Map(n);
        Console.WriteLine($"Da map voi n = {n}: ");
        erm.Print();

        // Xoa 1 nhan vien
        erm.Remove("002");
        Console.WriteLine("Da xoa 1 nhan vien:");
        erm.Print();
    }
}
