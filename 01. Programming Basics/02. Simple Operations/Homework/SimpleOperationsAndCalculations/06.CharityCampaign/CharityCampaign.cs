using System;

namespace _06.CharityCampaign
{
    class CharityCampaign
    {
        static void Main(string[] args)
        {
			int daysCount = int.Parse(Console.ReadLine());
			int sweetmakersCount = int.Parse(Console.ReadLine());

			int torti = int.Parse(Console.ReadLine());
			int gofreti = int.Parse(Console.ReadLine());
			int palachinki = int.Parse(Console.ReadLine());

			double sum = daysCount * sweetmakersCount * (torti * 45 + gofreti * 5.8 + palachinki * 3.2);

			sum -= (sum / 8);
			Console.WriteLine("{0:F2}", sum);
		}
    }
}
