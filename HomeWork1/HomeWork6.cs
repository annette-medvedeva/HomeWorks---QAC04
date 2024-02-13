
using HomeWork1;
using HomeWork1.Doctors;
using HomeWork1.Enums;
using HomeWorks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HomeWorks
{
    internal class HomeWork6
    {

        static void Main(string[] args)
        {
            LogToFile("Log.txt", "Logging started at: " + DateTime.Now);
            LogToFile("Log.txt", "An error occurred: This is an example error message.");
            LogToFile("Log.txt", "Logging finished at: " + DateTime.Now);
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Добро пожаловать в нашу клинику");

            Clinic clinic = initializeClinic();

            Console.WriteLine("Введите ваше имя : ");
            String patientName = Convert.ToString(Console.ReadLine());

            while (true)
            {
                try
                {
                    Console.WriteLine(patientName + ", Выберите к какому доктору вы хотите попасть");
                    while (true)
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
                                Doctor selectedDoctor = null;
                                switch (number)
                                {
                                    case 1:
                                        selectedDoctor = clinic.doctors.FirstOrDefault(doc => doc.Specialization.Equals("Стоматолог"));
                                        break;
                                    case 2:
                                        selectedDoctor = clinic.doctors.FirstOrDefault(doc => doc.Specialization.Equals("Хирург"));
                                        break;
                                    case 3:
                                        selectedDoctor = clinic.doctors.FirstOrDefault(doc => doc.Specialization.Equals("Терапевт"));
                                        break;
                                    case 4:

                                        foreach (Doctor doc in clinic.doctors)
                                        {
                                            doc.Treat();
                                            Console.WriteLine($"{doc.GetType().Name} - {doc.Name}, Специализация: {doc.Specialization}");
                                        }
                                        break;
                                }

                                if (number == 4)
                                {
                                    Console.WriteLine(patientName + ", Выберите к какому доктору вы хотите попасть");
                                    break;
                                }

                                if (selectedDoctor != null)
                                {
                                    Console.WriteLine($"Вы выбрали {selectedDoctor?.GetType()}, Имя вашего врача {selectedDoctor?.Name}");
                                    selectedDoctor?.Schedule();
                                }

                                bool isValidDay = false;
                                DayOfWeek selectedDay = DayOfWeek.Sunday; ;
                                while (!isValidDay)
                                {
                                    Console.WriteLine("На какой день недели вы хотите записаться?");

                                    Console.WriteLine("1 - Понедельник");
                                    Console.WriteLine("2 - Вторник");
                                    Console.WriteLine("3 - Среда");
                                    Console.WriteLine("4 - Четверг");
                                    Console.WriteLine("5 - Пятница");
                                    Console.WriteLine("6 - Суббота");
                                    Console.WriteLine("7 - Воскресенье");

                                        Console.Write("Введите номер дня: ");
                                        if (int.TryParse(Console.ReadLine(), out int dayNumber) && dayNumber >= 1 && dayNumber <= 7)
                                        {
                                            selectedDay = (DayOfWeek)((dayNumber + 5) % 7);
                                            isValidDay = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 1 до 7.");
                                        }
                                    }
                                    if (selectedDoctor != null)
                                    {
                                        Console.WriteLine($"Вы выбрали {selectedDoctor?.Name}");
                                        selectedDoctor?.Schedule();

                                        if (selectedDoctor.Rest(selectedDay))
                                        {
                                            Console.WriteLine($"{selectedDoctor?.GetType().Name} отдыхает в этот день.");
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
                                            clinic.patients.Add(newPatient);
                                            Console.WriteLine($"Вы записаны к {selectedDoctor?.GetType().Name} на {selectedDay}.");
                                        }
                                    }


                                    else
                                    {
                                        Console.WriteLine("Некорректный ввод. Выберите доктора сначала.");
                                        break;
                                    }

                                    Console.WriteLine("Вывести информацаю об очереди? \n\t 1 - да , 0 - завершить программу");
                                    if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= 4)
                                    {
                                        switch (num)
                                        {
                                            case 1:
                                                Console.WriteLine("Информация о пациентах:");
                                                foreach (Patient patient in clinic.patients)
                                                {
                                                    Console.WriteLine($"Пациент {patient.Name} - Доктор {patient.SelectedDoctor.Name}, День {patient.SelectedDay}, Процедура {patient.SelectedProcedure}, Номер в очереди {patient.QueueNumber}");
                                                }
                                                break;
                                            case 2:
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
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод. Введите 1 или 0.");
                                    isWantToRegisterAgain = false;
                                }
                            }

                        }
                    
              
                    
                            
                }
                        Console.ReadLine();
            
        }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
}
        }
        private static void Doctor_PatientEnqueued(object sender, PatientEnqueuedEventArgs e)
{
    Console.WriteLine($"Пациент {e.Patient.Name} добавлен в очередь к {((Doctor)sender).Name}.");
    ((Doctor)sender).DisplayPatientQueue();
}
static void LogToFile(string filePath, string message)
{
    try
    {
        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while logging to file: {ex.Message}");
    }
}

static Clinic initializeClinic()
{
    Clinic clinic = new Clinic();
    Surgeon surgeon1 = new Surgeon("Sam", "head", "Surgeon");
    Surgeon surgeon2 = new Surgeon("Валера", "Общий хирург", "Surgeon");
    Doctor sanya = new Surgeon("Mat", "leg", "Surgeon");
    Dentist dentist1 = new Dentist("Dan", "Dentist");
    Dentist dentist2 = new Dentist("Maya", "Dentist");
    Therapist terapist = new Therapist("Tanya", "Therapist");
    Administration Polly = new Administration("Polly", "Night Ammin");
    Administration Sara = new Administration("Sara", "Day Admin");
    List<Doctor> doctors = new List<Doctor>();
    clinic.doctors.Add(surgeon1);
    clinic.doctors.Add(surgeon2);
    clinic.doctors.Add(sanya);
    clinic.doctors.Add(dentist1);
    clinic.doctors.Add(dentist2);
    clinic.doctors.Add(terapist);
    //patients
    Patient patient1 = new Patient("Пациент1", dentist1, DayOfWeek.Monday, "Чистка зубов", 1);
    Patient patient2 = new Patient("Пациент2", dentist1, DayOfWeek.Monday, "Чистка зубов", 2);
    Patient patient3 = new Patient("Пациент3", surgeon2, DayOfWeek.Friday, "Leg Surgeryg", 2);
    Patient patient4 = new Patient("Пациент4", surgeon1, DayOfWeek.Monday, "Other Surgical Procedures", 1);
    Patient patient5 = new Patient("Пациент5", terapist, DayOfWeek.Wednesday, "Prescription", 1);
    Patient patient6 = new Patient("Пациент6", terapist, DayOfWeek.Wednesday, "General Checkup", 1);
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
    return clinic;
}

    }



}


