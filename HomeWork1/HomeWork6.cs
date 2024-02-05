
using HomeWork1.Doctors;
using HomeWorks;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HomeWorks
{
    internal class HomeWork6
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Добро пожаловать в нашу клинику");

            List<Patient> patients = new List<Patient>();
            Surgeon surgeon1 = new Surgeon("Sam", "head");
            Surgeon surgeon2 = new Surgeon("Sam", "head");
            Doctor sanya = new Surgeon("Mat", "leg");
            Dentist dentist1 = new Dentist("Dan");
            Dentist dentist2 = new Dentist("Maya");
            Therapist terapist = new Therapist("Tanya");
            Administration Polly = new Administration("Polly");
            Administration Sara = new Administration("Sara");

            //patients
            Patient patient1 = new Patient("Пациент1", dentist1, "Monday", "Чистка зубов", 1);
            Patient patient2 = new Patient("Пациент2", dentist1, "Monday", "Чистка зубов", 2);
            Patient patient3 = new Patient("Пациент3", surgeon2, "Friday", "Leg Surgeryg", 2);
            Patient patient4 = new Patient("Пациент4", surgeon1, "Monday", "Other Surgical Procedures", 1);
            Patient patient5 = new Patient("Пациент5", terapist, "Wednesday", "Prescription", 1);
            Patient patient6 = new Patient("Пациент6", terapist, "Wednesday", "General Checkup", 1);
            dentist1.EnqueuePatient(patient1);
            surgeon1.EnqueuePatient(patient4);
            surgeon2.EnqueuePatient(patient3);
            dentist1.EnqueuePatient(patient2);
            terapist.EnqueuePatient(patient5);
            terapist.EnqueuePatient(patient6);
            List<IWRestable> wRables = new List<IWRestable>()
            {
            surgeon1,surgeon2, sanya,dentist1,dentist2,terapist, Polly, Sara
            };
            Console.WriteLine("Сегодня работают:");
            foreach (var wRable in wRables)
            {
                if (wRable is Doctor doctor)
                {
                    if (doctor.Rest(DateTime.Now.DayOfWeek))
                        continue;

                    Console.WriteLine($"{doctor.GetType().Name} - {doctor.Name}");
                }
                else if (wRable is Administration admin)
                {
                    if (admin.Rest(DateTime.Now.DayOfWeek))
                        continue;
                    Console.WriteLine($"{admin.GetType().Name} - {admin.Name}");
                }
            }

            Console.WriteLine("Введите ваше имя : ");

            String patientName = Convert.ToString(Console.ReadLine());

        n0:
            Console.WriteLine(patientName + ", Выберите к какому доктору вы хотите попасть");
        n1:
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
                            result = "Стоматолог";
                            selectedDoctor = new Dentist(result);
                            break;
                        case 2:
                            result = "Хирург";
                            selectedDoctor = new Surgeon(result, "Specialization");
                            break;
                        case 3:
                            result = "Терапевт";
                            selectedDoctor = new Therapist(result);
                            break;
                        case 4:
                            result = "Все доктора";
                            List<Doctor> doctors = new List<Doctor>();
                            doctors.Add(surgeon1);
                            doctors.Add(surgeon2);
                            doctors.Add(sanya);
                            doctors.Add(dentist1);
                            doctors.Add(dentist2);
                            doctors.Add(terapist);

                            foreach (Doctor doc in doctors)
                            {
                                doc.Treat();
                            }
                            break;
                    }
                    if (number == 4)
                    {
                        Console.WriteLine("Выберите к какому доктору вы хотите попасть");
                        goto n1;

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

                        if (Enum.TryParse(selectedDay, true, out DayOfWeek dayOfWeek))
                        {
                            if (selectedDoctor != null)
                            {
                                Console.WriteLine($"Вы выбрали {selectedDoctor?.GetType().Name}");
                                selectedDoctor?.Schedule();

                                if (selectedDoctor.Rest(dayOfWeek))
                                {
                                    Console.WriteLine($"{selectedDoctor?.GetType().Name} отдыхает в этот день {selectedDay}. Выберите другой день.");

                                }
                                else
                                {
                                    isValidDay = true;
                                    Console.WriteLine("На какую процедуру вы хотите записаться?");
                                    string procedure = selectedDoctor?.ProvideTreatmentOptions();
                                    Patient newPatient = new Patient(patientName, selectedDoctor, selectedDay, procedure, selectedDoctor.PublicQueueCount + 1); //счетчик не могу увеличить если записывается пациент к одному доктору
                                    selectedDoctor.EnqueuePatient(newPatient);
                                    Console.WriteLine("Обработка очереди:");
                                    selectedDoctor.PatientEnqueued += Doctor_PatientEnqueued;
                                    patients.Add(newPatient);                                    
                                    Console.WriteLine($"Вы записаны к {selectedDoctor?.GetType().Name} на {selectedDay}.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ввод. Выберите доктора сначала.");
                            }
                            Console.WriteLine("Вывести информацаю об очереди? \n\t 1 - да , 0 - завершить программу");
                            if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= 4)
                            {

                                switch (num)
                                {
                                    case 1:
                                        result = "1";
                                        Console.WriteLine("Информация о пациентах:");
                                        foreach (Patient patient in patients)
                                        {
                                            Console.WriteLine($"Пациент {patient.Name} - Доктор {patient.SelectedDoctor.Name}, День {patient.SelectedDay}, Процедура {patient.SelectedProcedure}, Номер в очереди {patient.QueueNumber}");
                                        }
                                        break;
                                    case 2:
                                        result = "0";
                                        Environment.Exit(0);
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ввод. Введите 1 или 0.");
                            }
                        }

                        else
                        {
                            Console.WriteLine("Некорректный ввод. Введите день недели корректно.");
                        }
                        bool isWantToRegisterAgain = true;

                        while (isWantToRegisterAgain)
                        {


                            Console.WriteLine("Хотите записаться к другому доктору? (1 - да, 0 - нет)");
                            if (int.TryParse(Console.ReadLine(), out int wantToRegister) && (wantToRegister == 1 || wantToRegister == 0))
                            {
                                goto n0;
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ввод. Введите 1 или 0.");
                                isWantToRegisterAgain = false;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите число от 1 до 3.");

                }
            }

            Console.ReadLine();
        }

        private static void Doctor_PatientEnqueued(object sender, PatientEnqueuedEventArgs e)
        {
            Console.WriteLine($"Пациент {e.Patient.Name} добавлен в очередь к {((Doctor)sender).Name}.");
            ((Doctor)sender).DisplayPatientQueue();
        }
    }



}


