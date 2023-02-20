using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace linq
{
    internal class Program
    {
        static void printTab(string s, Hashtable a)
        {
            Console.WriteLine(s);
            ICollection key = a.Keys;
            foreach (string i in key)
            {
                Console.WriteLine(i + "\t" + a[i]);
            }
        }
        static void Main(string[] args)
        {
            Hashtable people = new Hashtable();
            int[] Array = new int[100];
            StreamReader fileIn = new StreamReader("contacts.txt");
            string contact;
            while ((contact = fileIn.ReadLine()) != null)
            {
                string[] temp = contact.Split(' ');
                people.Add(temp[0], temp[1]);
            }

            printTab("Сейчас в ваших контактах: ", people);

            for (int i = 0; i < Array.Length; i++)
            {
                Console.WriteLine("Выберите что вы хотите сделать: ");
                Console.WriteLine("1 - Добавить в контакты ");
                Console.WriteLine("2 - Убрать из контактов ");
                int otv = int.Parse(Console.ReadLine());
                switch (otv)
                {
                    case 1:
                        Console.WriteLine("Введите номер телефона: ");
                        contact = Console.ReadLine();
                        if (people.ContainsKey(contact)) Console.WriteLine("У вас в записной книге под номером " + contact + ", записан " + people[contact]);
                        else
                        {
                            Console.WriteLine("Введите фамилию: ");
                            string line2 = Console.ReadLine();
                            people.Add(contact, line2);
                        }
                        printTab("Сейчас в ваших контактах: ", people);
                        break;
                    case 2:
                        Console.WriteLine("Введите фамилию для удаления");
                        contact = Console.ReadLine();
                        if (people.ContainsValue(contact))
                        {
                            ICollection key = people.Keys;
                            Console.WriteLine(contact);
                            string del = "";
                            foreach (string j in key)
                                if (string.Compare((string)people[j], contact) == 0)
                                {
                                    del = j;
                                    break;
                                }
                            Console.WriteLine(del + "\t" + people[del] + " - удален");
                            people.Remove(del);
                            printTab("Сейчас в ваших контактах: ", people);
                        }
                        break;
                    case 3:
                        printTab("Сейчас в ваших контактах: ", people);
                        break;
                }
            }
        }
    }
}
