using HomeWork1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class Patient : PlanTreatment
    {

        public Patient() { }

        override public void PatientTreat()
        {
            Console.WriteLine("1. Стоматолог");
            Console.WriteLine("2. Хирург");
            Console.WriteLine("3. Терапевт");
            Console.WriteLine("4. Посмотреть весь список докторов");
            bool isNumber = false;
            while (!isNumber)
            {
                if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= 4)
                {
                    string result = "";
                    Doctor selectedDoctor = null;
                    switch (number)
                    {
                        case 1:
                            result = "стоматолог";
                            selectedDoctor = new Dentist(result);
                            break;
                        case 2:
                            result = "хирург";
                            selectedDoctor = new Surgeon(result, "Specialization");

                            break;
                        case 3:
                            result = "терапевт";
                            selectedDoctor = new Therapist(result);
                            break;
                        case 4:
                            result = "Все доктора";
                            Surgeon surgeon1 = new Surgeon("Sam", "head");
                            Surgeon surgeon2 = new Surgeon("Sam", "head");
                            Doctor sanya = new Surgeon("Mat", "leg");
                            Dentist dentist1 = new Dentist("Dan");
                            Dentist dentist2 = new Dentist("Maya");
                            Therapist t = new Therapist("Tanya");

                            List<Doctor> doctors = new List<Doctor>();
                            doctors.Add(surgeon1);
                            doctors.Add(surgeon2);
                            doctors.Add(sanya);
                            doctors.Add(dentist1);
                            doctors.Add(dentist2);
                            doctors.Add(t);

                            foreach (Doctor doc in doctors)
                            {
                                doc.Treat();
                            }
                            break;
                    }
                    if (number == 4)
                    {
                        Console.WriteLine("Выберите к какому доктору вы хотите попасть");
                        PatientTreat();

                    }
                    if (selectedDoctor != null)
                    {
                        Console.WriteLine($"Вы выбрали {selectedDoctor?.GetType().Name}");
                        selectedDoctor?.Schedule();
                    }
                    bool isValidDay = false;
                    while (!isValidDay)
                    {
                        Console.WriteLine("На какой день недели вы хотите записаться?");
                        string selectedDay = Console.ReadLine();

                        if (selectedDoctor != null && !selectedDoctor.Rest(selectedDay))
                        {
                            Console.WriteLine($"{selectedDoctor?.GetType().Name} отдыхает в этот день {selectedDay}. Выберите другой день.");
                        }
                        else
                        {
                            isValidDay = true;
                            Console.WriteLine("На какую процедуру вы хотите записаться?");
                            selectedDoctor?.ProvideTreatmentOptions();
                            Console.WriteLine($"Вы записаны к {selectedDoctor?.GetType().Name} на {selectedDay}. И выбрали такую процедуру:");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите число от 1 до 3.");

                }
            }
        }

        public override void ProvideTreatmentOptions() 
        {
        
        }




    }
}


