using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpmodul8_1302213030
{
    internal class CovidConfig
    {
        public string SatuanSuhu { get; set; }
        public int BatasHariDeman { get; set; }
        public string PesanDitolak { get; set; }
        public string PesanDiterima { get; set; }

        public static CovidConfig LoadConfig()
        {
            var file = "covid_config.json";
            if (!File.Exists(file))
            {
                return new CovidConfig
                {
                    SatuanSuhu = "celcius",
                    BatasHariDeman = 14,
                    PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                    PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
                };
            }

            var json = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<CovidConfig>(json);
        }

        public bool inputData(double suhu, int hariDeman)
        {
            double suhuCelsius = SatuanSuhu == "celcius" ? suhu : (suhu - 32) * 5 / 9;
            return suhuCelsius >= 36.5 && suhuCelsius <= 37.5 && hariDeman < BatasHariDeman;
        }


        public void UbahSatuan()
        {
            switch (SatuanSuhu)
            {
                case "celcius":
                    SatuanSuhu = "fahrenheit";
                    break;
                case "fahrenheit":
                    SatuanSuhu = "celcius";
                    break;
                default:
                    Console.WriteLine("Satuan suhu tidak valid.");
                    return;
            }
            Console.WriteLine("");
            Console.WriteLine($"Satuan suhu telah diubah ke {SatuanSuhu}");
        }
    }
}
