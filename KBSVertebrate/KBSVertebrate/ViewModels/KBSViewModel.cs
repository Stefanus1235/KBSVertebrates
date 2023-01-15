using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using CsvHelper;
using KBSVertebrate.Models;
using Xamarin.Forms;

namespace KBSVertebrate.ViewModels
{
    public class KBSViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Vertebrate> Vertebrates { get; set; }
        public ObservableCollection<Vertebrate> Headers { get; set; }
        public ObservableCollection<QuestionModel> CurrentQuestion { get; set; }

        ObservableCollection<List<string>> AvailableTraits { get; set; }
        ObservableCollection<string> AvailableHasil { get; set; }


        public KBSViewModel()
        {
            Vertebrates = new ObservableCollection<Vertebrate>(); 
            Headers = new ObservableCollection<Vertebrate>();
            CurrentQuestion = new ObservableCollection<QuestionModel>();
            AvailableTraits = new ObservableCollection<List<string>>();
            AvailableHasil = new ObservableCollection<string>();
            ReadCSV();
            QuestionMaker();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ReadCSV()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "KBSVertebrate.vertebrata.csv";
            string[] names = assembly.GetManifestResourceNames();
            Console.WriteLine(names.Length);
            Console.WriteLine("testing");
            foreach (var words in names)
            {
                Console.WriteLine(words);
            }
            Console.WriteLine(names);

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                //string result = reader.ReadToEnd();

                if (reader != null)
                {
                    using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
                    {
                        while (csv.Read())
                        {
                            Vertebrates.Add(new Vertebrate
                            {
                                Suhu = csv.GetField<string>(0).Split('&'),
                                Reproduksi = csv.GetField<string>(1).Split('&'),
                                RuangJantung = csv.GetField<string>(2).Split('&'),
                                Pernapasan = csv.GetField<string>(3).Split('&'),
                                PenutupTubuh = csv.GetField<string>(4).Split('&'),
                                Habitat = csv.GetField<string>(5).Split('&'),
                                Hasil = csv.GetField<string>(6)
                            });
                        }
                    }
                }
            }
            Headers.Add(Vertebrates[0]);
            Vertebrates.RemoveAt(0);

            Console.WriteLine(Headers[0].PenutupTubuh[0]);
            Console.WriteLine(Vertebrates[0].PenutupTubuh[0]);

        }
        public void QuestionMaker()
        {
            var UniqueSuhuValues = new List<string>() { Headers[0].Suhu[0] };
            var UniqueReproduksiValues = new List<string>() { Headers[0].Reproduksi[0] };
            var UniqueRuangJantungValues = new List<string>() { Headers[0].RuangJantung[0] };
            var UniquePernapasanValues = new List<string>() { Headers[0].Pernapasan[0] };
            var UniquePenutupTubuhValues = new List<string>() { Headers[0].PenutupTubuh[0] };
            var UniqueHabitatValues = new List<string>() { Headers[0].Habitat[0] };

            foreach (var vertebrate in Vertebrates)
            {
                UniqueValAdder(UniqueSuhuValues, vertebrate.Suhu);
                UniqueValAdder(UniqueReproduksiValues, vertebrate.Reproduksi);
                UniqueValAdder(UniqueRuangJantungValues, vertebrate.RuangJantung);
                UniqueValAdder(UniquePernapasanValues, vertebrate.Pernapasan);
                UniqueValAdder(UniquePenutupTubuhValues, vertebrate.PenutupTubuh);
                UniqueValAdder(UniqueHabitatValues, vertebrate.Habitat);


            }
            Console.WriteLine("");

            Console.WriteLine("UniqueValAdder");

            Console.WriteLine("[{0}]", string.Join(", ", UniqueSuhuValues));
            Console.WriteLine("[{0}]", string.Join(", ", UniqueReproduksiValues));
            Console.WriteLine("[{0}]", string.Join(", ", UniqueRuangJantungValues));
            Console.WriteLine("[{0}]", string.Join(", ", UniquePernapasanValues));
            Console.WriteLine("[{0}]", string.Join(", ", UniquePenutupTubuhValues));
            Console.WriteLine("[{0}]", string.Join(", ", UniqueHabitatValues));
            Console.WriteLine("[{0}]", string.Join(", ", AvailableHasil));
            Console.WriteLine("");


            AvailableTraits.Add(UniqueSuhuValues);
            AvailableTraits.Add(UniqueReproduksiValues);
            AvailableTraits.Add(UniqueRuangJantungValues);
            AvailableTraits.Add(UniquePernapasanValues);
            AvailableTraits.Add(UniquePenutupTubuhValues);
            AvailableTraits.Add(UniqueHabitatValues);
            
            Console.WriteLine("");
            Console.WriteLine("AvailableTraits Initialize");
            Console.WriteLine("[{0}]", string.Join(", ", AvailableTraits[0]));
            Console.WriteLine("[{0}]", string.Join(", ", AvailableTraits[1]));
            Console.WriteLine("[{0}]", string.Join(", ", AvailableTraits[2]));
            Console.WriteLine("[{0}]", string.Join(", ", AvailableTraits[4]));
            Console.WriteLine("[{0}]", string.Join(", ", AvailableTraits[4]));
            Console.WriteLine("[{0}]", string.Join(", ", AvailableTraits[5]));
            Console.WriteLine("");

        }

        public void TraitPruning()
        {
            var UniqueSuhuValues = new List<string>() { Headers[0].Suhu[0] };
            var UniqueReproduksiValues = new List<string>() { Headers[0].Reproduksi[0] };
            var UniqueRuangJantungValues = new List<string>() { Headers[0].RuangJantung[0] };
            var UniquePernapasanValues = new List<string>() { Headers[0].Pernapasan[0] };
            var UniquePenutupTubuhValues = new List<string>() { Headers[0].PenutupTubuh[0] };
            var UniqueHabitatValues = new List<string>() { Headers[0].Habitat[0] };

            foreach (var vertebrate in Vertebrates)
            {
                UniqueValAdder(UniqueSuhuValues, vertebrate.Suhu);
                UniqueValAdder(UniqueReproduksiValues, vertebrate.Reproduksi);
                UniqueValAdder(UniqueRuangJantungValues, vertebrate.RuangJantung);
                UniqueValAdder(UniquePernapasanValues, vertebrate.Pernapasan);
                UniqueValAdder(UniquePenutupTubuhValues, vertebrate.PenutupTubuh);
                UniqueValAdder(UniqueHabitatValues, vertebrate.Habitat);
            }

            for(int i=0; i< AvailableTraits.Count; i++)
            {
                switch (AvailableTraits[i][0])
                {
                    case "Suhu tubuh":
                        if (UniqueSuhuValues.Count < AvailableTraits[i].Count)
                        {
                            AvailableTraits[i] = UniqueSuhuValues;
                            break;
                        }
                        break;
                    case "Cara reproduksi":
                        if (UniqueReproduksiValues.Count < AvailableTraits[i].Count)
                        {
                            AvailableTraits[i] = UniqueReproduksiValues;
                            break;
                        }
                        break;
                    case "Jumlah ruang jantung":
                        if (UniqueRuangJantungValues.Count < AvailableTraits[i].Count)
                        {
                            AvailableTraits[i] = UniqueRuangJantungValues;
                            break;
                        }
                        break;
                    case "Alat pernapasan":
                        if (UniquePernapasanValues.Count < AvailableTraits[i].Count)
                        {
                            AvailableTraits[i] = UniquePernapasanValues;
                            break;
                        }
                        break;
                    case "Penutup tubuh":
                        if (UniquePenutupTubuhValues.Count < AvailableTraits[i].Count)
                        {
                            AvailableTraits[i] = UniquePenutupTubuhValues;
                            break;
                        }
                        break;
                    case "Habitat":
                        if (UniqueHabitatValues.Count < AvailableTraits[i].Count)
                        {
                            AvailableTraits[i] = UniqueHabitatValues;
                            break;
                        }
                        break;
                };
            }
            Console.WriteLine("");
            Console.WriteLine("AvailableTraits After Pruning");
            foreach (var item in AvailableTraits)
            {
                Console.WriteLine("x");
                Console.WriteLine("[{0}]", string.Join(", ", item));
            }

            Console.WriteLine("");

        }

        public void FillAvailableTraits()
        {

        }

        public List<ResultModel> QuestionBuilder()
        {
            if (AvailableTraits.Count == 0 || Vertebrates.Count == 1)
            {
                List<ResultModel> result = new List<ResultModel>();
                foreach (var vertebrate in Vertebrates)
                {
                    result.Add(new ResultModel
                    {
                        Result = vertebrate.Hasil
                    });
                }

                return result;
            }
            else 
            { 
                var arraycount = new List<int>();
                var max = 0;
                foreach (var trait in AvailableTraits)
                {
                    arraycount.Add(trait.Count);
                    if (max < trait.Count){
                        max = trait.Count;
                    }
                }
                var qna = AvailableTraits[arraycount.IndexOf(max)];
                var pertanyaan = qna[0];
                var jawaban = qna; jawaban.RemoveAt(0);
                var jawaban_choicesmodel = ChoiceBuilder(jawaban);
                var curquestion = new QuestionModel
                {
                    Pertanyaan = pertanyaan,
                    OpsiList = jawaban_choicesmodel
                };

                if (CurrentQuestion.Count != 0) 
                {
                    CurrentQuestion.RemoveAt(0);
                }
                CurrentQuestion.Add(curquestion);

                AvailableTraits.Remove(qna);

                return null;
            }

        }

        private List<ChoiceModel> ChoiceBuilder(List<string> list)
        {
            List<ChoiceModel> choices = new List<ChoiceModel>();
            foreach (var val in list)
            {
                ChoiceModel choice = new ChoiceModel();
                choice.Opsi = val;
                choices.Add(choice);
            }
            return choices;
        }
        

        public void PruneQnA(string answer)
        {
            for(int i = Vertebrates.Count-1; i >= 0; i--)
            {
                var trait_values = get_trait_values(Vertebrates[i]);
                var is_included = false;


                foreach(var value in trait_values)
                {
                    if (value == answer)
                    {
                        is_included = true;
                        break;
                    }
                }
                if (is_included == false) {
                    Vertebrates.RemoveAt(i);
                }
            }

        }

        private void UniqueValAdder(List<string> list, string[] arraystring)
        {
            for (var i = 0; i < arraystring.Length; i++)
            {
                if (!list.Contains(arraystring[i]))
                {
                    list.Add(arraystring[i]);
                }
            }
        }
        private string[] get_trait_values(Vertebrate vertebrate)
        {
            switch (CurrentQuestion[0].Pertanyaan)
            {
                case "Suhu tubuh":
                    return vertebrate.Suhu;
                case "Cara reproduksi":
                    return vertebrate.Reproduksi;
                case "Jumlah ruang jantung":
                    return vertebrate.RuangJantung;
                case "Alat pernapasan":
                    return vertebrate.Pernapasan;
                case "Penutup tubuh":
                    return vertebrate.PenutupTubuh;
                default:
                    return vertebrate.Habitat;
            };
        }

    }
}
