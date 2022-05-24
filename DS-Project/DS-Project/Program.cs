using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace DS_Project
{
    class Program
    {
        /*
         * menue asli:
         * 1.sakhte noskhe jadid(checked)
         * 2.barresi affect yek daroo bar digar daroo ha va alergie on bar mariziha(checked)
         * 3.afzayesh ya kahesh gheymat hame daroo ha ba darsad elam shode(checked)
         * 4.ijad daroo jadid dar dataset(checked)
         * 5.ijad bimari jadid dar dataset(checked)
         * 6.hazf bimari az data set(checked)
         * 7.hazf daroo az data set(checked)
         * 8.jostjoo daroo dar deyta set(checked)
         * 9.jostjoo bimari dar data set(checked)
         * 10.namayesh daroo hayi ke bar bimari gofte shode asare mosbat daran(checked)
         * 11.payan barname(checked)
         * 
         * 
         * menue noskhe:
         * 1.mohasebe factor gheymat daroo(checked)
         * 2.ezafe kardane daroo jadid be noskhe(checked)
         * 3.ezafe kardane bimari jadid be noskhe(checked)
         * 4.hazfe daroo az noskhe(checked)
         * 5.hazfe bimari az noskhe(checked)
         * 6.barresi alergie beyne darooha va marizi ha(checked)
         * 7.barresi affect beyne daroo ha(checked)
         * 8.bazgasht be menue asli(checked)
         */

        //Data:
        public static double tavarom = 1;
        static Dictionary<string, Drug> Drugs = new Dictionary<string, Drug>();
        static Dictionary<string,Disease> Diseases2 = new Dictionary<string, Disease>();
        //Methods:
        static void Main()
        {
            bool checkPath = false;
            Stopwatch stopwatch = new Stopwatch();
            while (!checkPath)
            {
                string pathD1 = @"C:\Users\nmash\Desktop\drugs.txt";
                string pathD2 = @"C:\Users\nmash\Desktop\diseases.txt";
                string pathD3 = @"C:\Users\nmash\Desktop\effects.txt";
                string pathD4 = @"C:\Users\nmash\Desktop\alergies.txt";
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Hi , if you want to enter the path , write it , if you dont just write no");
                Console.Write("path for first dataset (drugs): ");
                Console.ForegroundColor = ConsoleColor.White;
                string str = Console.ReadLine();
                if (!str.Equals("no") && !str.Equals("No")) pathD1 = $@"{str}";
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("path for second dataset (diseases): ");
                Console.ForegroundColor = ConsoleColor.White;
                str = Console.ReadLine();
                if (!str.Equals("no") && !str.Equals("No")) pathD2 = $@"{str}";
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("path for 3th dataset (effects): ");
                Console.ForegroundColor = ConsoleColor.White;
                str = Console.ReadLine();
                if (!str.Equals("no") && !str.Equals("No")) pathD3 = $@"{str}";
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("path for 4th dataset (alergies): ");
                Console.ForegroundColor = ConsoleColor.White;
                str = Console.ReadLine();
                if (!str.Equals("no") && !str.Equals("No")) pathD4 = $@"{str}";
                checkPath = ReadDataFromFiles(pathD1, pathD2, pathD3, pathD4);
                if (!checkPath)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("oops path was incorrect");
                }
            }
            MainMenue();
            Console.WriteLine(GC.GetTotalMemory(true));
        }
        static void NoskheMenue(Noskhe noskhe)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nwelcome , please choose one of the number of our command:\n\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t1.mohasebe factor gheymat daroo\n\t2.ezafe kardane daroo jadid be noskhe\n\t" +
                "3.ezafe kardane bimari jadid be noskhe\n\t4.hazfe daroo az noskhe\n\t" +
                "5.hazfe bimari az noskhe\n\t6.barresi alergie beyne darooha va marizi ha\n\t"+
                "7.barresi affect beyne daroo ha\n\t8.bazgasht be menue asli");
            Console.ForegroundColor = ConsoleColor.White;
            int n = 0;
            try
            {
                n = int.Parse(Console.ReadLine());
                string command = "";
                switch (n)
                {
                    case 1:
                        MohasebeFactor(noskhe);
                        NoskheMenue(noskhe);
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("please enter name of drug:");
                        Console.ForegroundColor = ConsoleColor.White;
                        command = Console.ReadLine();
                        AddDrugToNoskhe(noskhe ,command);
                        NoskheMenue(noskhe);
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("please enter name of disease:");
                        Console.ForegroundColor = ConsoleColor.White;
                        command = Console.ReadLine();
                        AddDiseaseToNoskhe(noskhe, command);
                        NoskheMenue(noskhe);
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("please enter name of drug:");
                        Console.ForegroundColor = ConsoleColor.White;
                        command = Console.ReadLine();
                        RemoveDrugFromNoskhe(noskhe, command);
                        NoskheMenue(noskhe);
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("please enter name of disease:");
                        Console.ForegroundColor = ConsoleColor.White;
                        command = Console.ReadLine();
                        RemoveDiseaseFromNoskhe(noskhe, command);
                        NoskheMenue(noskhe);
                        break;
                    case 6:
                        BarresiAlergie(noskhe);
                        NoskheMenue(noskhe);
                        break;
                    case 7:
                        BarresiAffect(noskhe);
                        NoskheMenue(noskhe);
                        break;
                    case 8:
                        MainMenue();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("sorry your command can not be found in commands");
                        Console.ForegroundColor = ConsoleColor.White;
                        NoskheMenue(noskhe);
                        break;
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("oops! data is invalid , pleade try again");
                Console.ForegroundColor = ConsoleColor.White;
                NoskheMenue(noskhe);
            }
        }
        static void MainMenue()
        {
            Noskhe noskhe = new Noskhe();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nwelcome , please choose one of the number of our command:\n\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t1.sakhte noskhe jadid\n\t2.barresi affect yek daroo bar digar daroo ha va alergie on bar mariziha\n\t" +
                "3.afzayesh gheymat hame daroo ha ba darsad elam shode\n\t4.ijad daroo jadid dar dataset\n\t" +
                "5.ijad bimari jadid dar dataset\n\t6.hazf bimari az data set\n\t7.hazf daroo az data set\n\t8.jostjoo daroo dar deyta set\n\t" +
                "9.jostjoo bimari dar data set\n\t10.namayesh daroo hayi ke bar bimari gofte shode asare mosbat daran\n\t11.payan barname\n\t");
            Console.ForegroundColor = ConsoleColor.White;
            int n = 0;
            try
            {
                n = int.Parse(Console.ReadLine());
                string command = "";
                switch (n)
                {
                    case 1:
                        NoskheMenue(noskhe);
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("please enter name of drug:");
                        Console.ForegroundColor = ConsoleColor.White;
                        command = Console.ReadLine();
                        ReadDrug(command);
                        MainMenue();
                        break;
                    case 3:
                        bool checkData = false;
                        double t = 1;
                        while (!checkData)
                        {
                            checkData = true;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("please enter number between -1 and 1\n(sample:0.5\nthis sample means +50%");
                            Console.ForegroundColor = ConsoleColor.White;
                            try
                            {
                                t = double.Parse(Console.ReadLine());
                                if (t > 1 || t < -1) checkData = false;
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("oops! invalid format data");
                                Console.ForegroundColor = ConsoleColor.White;
                                checkData = false;
                            }
                        }
                        UpdateTavarom(t);
                        MainMenue();
                        break;
                    case 4:
                        string name = "";
                        int price = 0;
                        bool checkData2 = false;
                        while (!checkData2)
                        {
                            checkData2 = true;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("please enter name of your new drug and its price:\n(sample:Drug_vhlwunmpuu-16186)");
                            Console.ForegroundColor = ConsoleColor.White;
                            command = Console.ReadLine();
                            string[] temp = command.Split("-");
                            if (temp.Length != 2) checkData2 = false;
                            try
                            {
                                price=int.Parse(temp[1]);
                                name = temp[0];
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("oops! invalid format , please try again");
                                Console.ForegroundColor = ConsoleColor.White;
                                checkData2 = false;
                            }
                        }
                        CreateDrug(name, price);
                        MainMenue();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("please enter name of disease:");
                        Console.ForegroundColor = ConsoleColor.White;
                        command = Console.ReadLine();
                        CreateDisease(command);
                        MainMenue();
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("please enter name of disease:");
                        Console.ForegroundColor = ConsoleColor.White;
                        command = Console.ReadLine();
                        RemoveDiseases(command);
                        MainMenue();
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("please enter name of drug:");
                        Console.ForegroundColor = ConsoleColor.White;
                        command = Console.ReadLine();
                        RemoveDrug(command);
                        MainMenue();
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("enter the name of drug:");
                        Console.ForegroundColor = ConsoleColor.White;
                        command = Console.ReadLine();
                        SearchDrug(command);
                        MainMenue();
                        break;
                    case 9:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("please enter name of disease:");
                        Console.ForegroundColor = ConsoleColor.White;
                        command = Console.ReadLine();
                        SearchDisease(command);
                        MainMenue();
                        break;
                    case 10:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("please enter name of disease:");
                        Console.ForegroundColor = ConsoleColor.White;
                        command = Console.ReadLine();
                        ReadDisease(command);
                        MainMenue();
                        break;
                    case 11:
                        SaveDataToFiles();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Done!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("sorry your command can not be found in commands");
                        Console.ForegroundColor = ConsoleColor.White;
                        MainMenue();
                        break;
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("oops! data is invalid , pleade try again");
                Console.ForegroundColor = ConsoleColor.White;
                MainMenue();
            }
        }
        static bool ReadDataFromFiles(string pathD1, string pathD2 , string pathD3 ,string pathD4)
        {
            bool checkPath = true;
            //reading data from first file
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                StreamReader file = new StreamReader(pathD1);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] temp = line.Split(':');
                    temp[0] = temp[0].Replace(" ", "");
                    temp[1] = temp[1].Replace(" ", "");
                    Drug drug = new Drug(temp[0], int.Parse(temp[1]));
                    Drugs.Add(temp[0], drug);
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("reading data from first file takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                file.Close();

                //redanig from second file
                stopwatch.Restart();
                file = new StreamReader(pathD2);
                while ((line = file.ReadLine()) != null)
                {
                    Disease disease = new Disease(line);
                    Diseases2.Add(line, disease);
                }
                file.Close();
                Console.WriteLine("reading data from 2th file takes " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                //reading data from 3th file
                stopwatch.Restart();
                file = new StreamReader(pathD3);
                while ((line = file.ReadLine()) != null)
                {
                    try
                    {
                        string[] temp = line.Split(":");
                        temp[0] = temp[0].Replace(" ", "");
                        Drug drug = Drugs.GetValueOrDefault(temp[0]);
                        if (drug != null)
                        {
                            drug.flag = true;
                            string[] temp2 = temp[1].Split(";");
                            for (int i = 0; i < temp2.Length; i++)
                            {
                                temp2[i] = temp2[i].Replace(" (", "");
                                temp2[i] = temp2[i].Replace(") ", "");
                                temp2[i] = temp2[i].Replace(")", "");
                                string[] DataOfAffectedDrug = temp2[i].Split(",");
                                drug.AffectedDrugs.Add(DataOfAffectedDrug[0], DataOfAffectedDrug[1]);
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("wrong format");
                    }
                }
                file.Close();
                Console.WriteLine("reading data from 3th file takes " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                //reading data from 4th file
                stopwatch.Restart();
                file = new StreamReader(pathD4);
                while ((line = file.ReadLine()) != null)
                {

                    string[] temp = line.Split(":");
                    temp[0] = temp[0].Replace(" ", "");

                    Disease disease1 = Diseases2.GetValueOrDefault(temp[0]);
                    if (disease1 != null)
                    {
                        disease1.flag = true;
                        string[] temp3 = temp[1].Split(";");
                        for (int i = 0; i < temp3.Length; i++)
                        {
                            temp3[i] = temp3[i].Replace(" (", "");
                            temp3[i] = temp3[i].Replace(") ", "");
                            temp3[i] = temp3[i].Replace(")", "");
                            string[] Data = temp3[i].Split(",");
                            disease1.DiseaseAffectedDrugs.Add(Data[0], Data[1]);
                            //add disease to drug's list
                            Drug drug = Drugs.GetValueOrDefault(Data[0]);
                            if (drug != null)
                            {
                                drug.AffectedDiseases.Add(temp[0]);
                            }
                        }
                    }
                }
                file.Close();
                Console.WriteLine("reading data from 4th file takes " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                checkPath = false;
            }
            return checkPath;
            
        }
        static void SearchDrug(string name)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Drug drug = Drugs.GetValueOrDefault(name);
            if (drug == null)
            {
                Console.WriteLine($"there is no {name} in drugs list");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("search drug takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine($"name : {name} , cost is : {drug.price*tavarom}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("search drug takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void RemoveDrug(string name)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Drug drug = Drugs.GetValueOrDefault(name);
            if (drug != null)
            {
                if (drug.AffectedDiseases != null)
                {
                    foreach(string item in drug.AffectedDiseases)
                    {
                        Disease disease = Diseases2.GetValueOrDefault(item);
                        if (disease != null)
                        {
                            try
                            {
                                disease.DiseaseAffectedDrugs.Remove(name);
                            }
                            catch
                            {
                                //error
                            }
                        }
                    }
                }
                Drugs.Remove(name);
                Console.WriteLine("drug removed");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"there is no {name} in drugs");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("removing data takes " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void SearchDisease(string name)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            if (Diseases2.ContainsKey(name))
            {
                Console.WriteLine($"{name} found");
            }
            else
            {
                Console.WriteLine($"{name} doens't found");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("search disease takes " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
            Console.ForegroundColor = ConsoleColor.White;

        }
        static void RemoveDiseases (string name)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (Diseases2.ContainsKey(name))
            {
                //vaghti as diseases pak mishe ye marizi dg kollan hame effect hasham pak mishe
                Diseases2.Remove(name);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{name} is deleted succsessfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{name} doens't found");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("search disease takes " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
            Console.ForegroundColor = ConsoleColor.White;
            
        }
        static void SaveDataToFiles()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //first 
            StreamWriter file = new StreamWriter(@"C:\Users\nmash\Desktop\datasets\drugs.txt");
            foreach(var item in Drugs)
            {
                item.Value.price *= tavarom;
                file.WriteLine($"{item.Key} : {item.Value.price}");
            }
            file.Close();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("writing data on first file takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
            file = new StreamWriter(@"C:\Users\nmash\Desktop\datasets\diseases.txt");
            foreach(var item in Diseases2)
            {
                file.WriteLine(item.Key);
            }
            Console.WriteLine("writing data on second file takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
            //2th file
            file = new StreamWriter(@"C:\Users\nmash\Desktop\datasets\effects.txt");
            foreach(var item in Drugs)
            {
                if (item.Value.flag==true)
                {
                    file.Write($"{item.Key} :");
                    int n = item.Value.AffectedDrugs.Count;
                    foreach(var item2 in item.Value.AffectedDrugs)
                    {
                        file.Write($" ({item2.Key},{item2.Value}) ");
                        n--;
                        if (n > 0)
                        {
                            file.Write(";");
                        }
                    }
                    file.WriteLine();
                }
            }
            file.Close();
            Console.WriteLine("writing data on 3th file takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
            //3th file
            file = new StreamWriter(@"C:\Users\nmash\Desktop\datasets\alergies.txt");
            foreach (var item in Diseases2)
            {
                if (item.Value.flag == true)
                {
                    file.Write($"{item.Key} :");
                    int n = item.Value.DiseaseAffectedDrugs.Count;
                    foreach (var item2 in item.Value.DiseaseAffectedDrugs)
                    {
                        file.Write($" ({item2.Key},{item2.Value}) ");
                        n--;
                        if (n > 0)
                        {
                            file.Write(";");
                        }
                    }
                    file.WriteLine();
                }
            }
            file.Close();
            Console.WriteLine("writing data on 4th file takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void MohasebeFactor(Noskhe noskhe)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double TotalPrice = 0;
            foreach(var drug in noskhe.drugsOfNoskhe)
            {
                TotalPrice += drug.price;
            }
            TotalPrice = TotalPrice * tavarom;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Total price is : {TotalPrice}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("search drug takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void AddDrugToNoskhe(Noskhe noskhe , string DrugName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Drug drug = Drugs.GetValueOrDefault(DrugName);
            if (drug == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"there is no {DrugName} in drugs list");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("search drug takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                bool exist = false;
                foreach (var item in noskhe.drugsOfNoskhe)
                {
                    if (item.name.Equals(DrugName)) exist = true;
                }
                if (exist)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{DrugName} is already in list");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    noskhe.drugsOfNoskhe.Add(drug);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{DrugName} has been added to noskhe");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("add drug takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("\ndrugs in noskhe: ");
                foreach (var item in noskhe.drugsOfNoskhe)
                {
                    Console.WriteLine($"-name : {item.name}");
                }
            }
        }
        static void AddDiseaseToNoskhe(Noskhe noskhe,string DiseaseName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Disease disease = Diseases2.GetValueOrDefault(DiseaseName);
            if (disease == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"there is no {DiseaseName} in drugs list");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("search disease takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                bool exist = false;
                foreach(var item in noskhe.diseasesOfNoskhe)
                {
                    if (item.name.Equals(DiseaseName)) exist = true;
                }
                if (exist)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{DiseaseName} is already in list");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    noskhe.diseasesOfNoskhe.Add(disease);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{DiseaseName} has been added from noskhe");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("add disease takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("\ndisease in noskhe: ");
                foreach (var item in noskhe.diseasesOfNoskhe)
                {
                    Console.WriteLine($"-name : {item.name}");
                }
            }
        }
        static void RemoveDiseaseFromNoskhe(Noskhe noskhe,string DiseaseName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Disease disease = Diseases2.GetValueOrDefault(DiseaseName);
            if (disease == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"there is no {DiseaseName} in drugs list");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("search disease takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                noskhe.diseasesOfNoskhe.Remove(disease);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{DiseaseName} has been removed from noskhe");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Remove disease takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\ndisease in noskhe: ");
                foreach (var item in noskhe.diseasesOfNoskhe)
                {
                    Console.WriteLine($"-name : {item.name}");
                }
            }
        }
        static void RemoveDrugFromNoskhe(Noskhe noskhe , string DrugName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Drug drug = Drugs.GetValueOrDefault(DrugName);
            if (drug == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"there is no {DrugName} in drugs list");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("search drug takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                noskhe.drugsOfNoskhe.Remove(drug);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{DrugName} has been removed from noskhe");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("add drug takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\ndrugs in noskhe: ");
                foreach (var item in noskhe.drugsOfNoskhe)
                {
                    Console.WriteLine($"-name : {item.name}");
                }
            }
        }
        static void BarresiAffect(Noskhe noskhe)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var drug in noskhe.drugsOfNoskhe)
            {
                Console.WriteLine($"DrugName : {drug.name}");
                if (drug.AffectedDrugs != null && drug.AffectedDrugs.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"affected drugs are : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (var ad in drug.AffectedDrugs)
                    {
                        Console.WriteLine($"Name : {ad.Key} effect is : {ad.Value}");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("there are no affected drugs");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Read drug takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void BarresiAlergie(Noskhe noskhe)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var d in noskhe.diseasesOfNoskhe)
            {
                Console.WriteLine($"disease name : {d.name}");
                Disease disease = Diseases2.GetValueOrDefault(d.name);
                if (disease != null)
                {
                    if (disease.DiseaseAffectedDrugs != null && disease.DiseaseAffectedDrugs.Count != 0)
                    {

                        var negativeDrugs = disease.DiseaseAffectedDrugs.Where(x => x.Value == "-");
                        if (negativeDrugs != null && negativeDrugs.Count() != 0)
                        {
                            Console.WriteLine("Drugs with negative effect are : ");
                            foreach (var drug in negativeDrugs)
                            {
                                Console.WriteLine(drug.Key);
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("there are no drugs with negative effect for this disease.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("there are no affected drugs");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("this disease doesnt exist");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Read disease takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Read drug takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
            Console.ForegroundColor = ConsoleColor.White;

        }
        static void ReadDrug(string name)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Drug drug = Drugs.GetValueOrDefault(name);
            if (drug != null)
            {
                Console.WriteLine($"DrugName : {drug.name} price : {drug.price*tavarom}");
                if (drug.AffectedDrugs != null && drug.AffectedDrugs.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"affected drugs are : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (var ad in drug.AffectedDrugs)
                    {
                        Console.WriteLine($"Name : {ad.Key} effect is : {ad.Value}");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("there are no affected drugs");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (drug.AffectedDiseases != null && drug.AffectedDiseases.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("affected diseases are : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (var ad in drug.AffectedDiseases)
                    {
                        Disease disease = Diseases2.GetValueOrDefault(ad);
                        Console.WriteLine($"Name : {ad} effect state : {disease.DiseaseAffectedDrugs[$"{drug.name}"]}");


                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("there are no affected diseases");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Read drug takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("this drug doesnt exist");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Read drug takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                Console.ForegroundColor = ConsoleColor.White;
            }



        }
        static void CreateDrug(string name, double price)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Random rnd = new Random();
            Drug drug = new Drug(name, price);
            foreach (var d in RandomValues(Drugs).Take(2))
            {
                // using guid (global unique identifier with no collision to generate random effect name)
                string EffectName = "Eff_";
                EffectName += Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 10);
                drug.AffectedDrugs.Add(d.name, EffectName);
            }
            Drugs.Add(drug.name, drug);
            int i = 0; //yeki dar mioon mosbat manfi rooye 3 bimarie random asar mizare
            foreach (var disease in RandomValues(Diseases2).Take(3))
            {
                drug.AffectedDiseases.Add(disease.name);
                if (i % 2 == 0)
                {
                    disease.DiseaseAffectedDrugs.Add(drug.name, "+");
                }
                else
                {
                    disease.DiseaseAffectedDrugs.Add(drug.name, "-");
                }
                i++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Drug created successfully.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Create drug takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void UpdateTavarom (double t)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            tavarom = tavarom * (1+t);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("update Prices takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void ReadDisease(string name)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Disease disease = Diseases2.GetValueOrDefault(name);
            if (disease != null)
            {
                if (disease.DiseaseAffectedDrugs != null && disease.DiseaseAffectedDrugs.Count != 0)
                {

                    var positivedrugs = disease.DiseaseAffectedDrugs.Where(x => x.Value == "+");
                    if (positivedrugs != null && positivedrugs.Count() != 0)
                    {
                        Console.WriteLine("Drugs with positive effect are : ");
                        foreach (var drug in positivedrugs)
                        {
                            Console.WriteLine(drug.Key);
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("there are no drugs with positive effect for this disease.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("there are no affected drugs");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Read drug takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("this disease doesnt exist");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Read disease takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void CreateDisease(string name)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Disease disease = new Disease(name);
            int i = 0; //yeki dar mioon mosbat manfi rooye 3 bimarie random asar mizare
            Console.WriteLine("add shodane 3 drug random ke besoorate yeki dar mioon rooye in bimari asare + ya - migozarad be nam haye : ");
            foreach (var drug in RandomValues(Drugs).Take(3))
            {
                drug.AffectedDiseases.Add(disease.name);
                if (i % 2 == 0)
                {
                    disease.DiseaseAffectedDrugs.Add(drug.name, "+");
                    //disease.DiseaseAffectedDrugs.Add(drug.name, "+");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"name : {drug.name}  effect state : +");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    disease.DiseaseAffectedDrugs.Add(drug.name, "-");
                    //disease.DiseaseAffectedDrugs.Add(drug.name, "-");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"name : {drug.name}  effect state : -");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                i++;
            }
            Diseases2.Add(disease.name, disease);
            Console.WriteLine("disease created successfully.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Create disease takes : " + stopwatch.ElapsedTicks * 1000000.0 / Stopwatch.Frequency + " µs");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dict)
        {
            Random rand = new Random();
            List<TValue> values = Enumerable.ToList(dict.Values);
            int size = dict.Count;
            while (true)
            {
                yield return values[rand.Next(size)];
            }
        }
    }
    class Drug
    {
        public bool flag = false;
        public string name;
        public double price;
        public Dictionary<string,string> AffectedDrugs;
        public List<string> AffectedDiseases;
        public Drug(string name,double price)
        {
            this.price = price;
            this.name = name;
            this.AffectedDrugs = new Dictionary<string, string>();
            this.AffectedDiseases = new List<string>();
        }
    }
    class Disease
    {
        public bool flag = false;
        public string name;
        public Dictionary<string, string> DiseaseAffectedDrugs;
        public Disease (string name)
        {
            this.name = name;
            DiseaseAffectedDrugs = new Dictionary<string, string>();
        }
    }
    class Noskhe
    {
        public List<Drug> drugsOfNoskhe;
        public List<Disease>diseasesOfNoskhe;
        public Noskhe()
        {
            drugsOfNoskhe = new List<Drug>();
            diseasesOfNoskhe = new List<Disease>();
        }
    }
}
