// See https://aka.ms/new-console-template for more information

using tpmodul8_1302213030;

class Program
{
    static void Main(string[] args)
    {
        var cc = CovidConfig.LoadConfig();

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {cc.SatuanSuhu} ");
        double suhu = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("");

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hariDeman = Convert.ToInt32(Console.ReadLine());

        if (cc.inputData(suhu, hariDeman))
        {
            Console.WriteLine(cc.PesanDiterima);
        }
        else
        {
            Console.WriteLine(cc.PesanDitolak);
        }
        cc.UbahSatuan();
    }
}
