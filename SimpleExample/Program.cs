using ImageGeneration;
using System;
using System.Drawing;

namespace SimpleExample
{
    class Program
    {
        private static void Main()
        {
            var half6x6 = ImageGenerator.GenerateImage(size: 6, fillChance: 0.5);

            Console.WriteLine("6x6, 50% fill chance");
            printImage(half6x6);

            var half2x2 = ImageGenerator.GenerateImage(size: 2, fillChance: 0.5);

            Console.WriteLine("2x2, 50% fill chance");
            printImage(half2x2);

            var threeQuarter10x10 = ImageGenerator.GenerateImage(size: 10, fillChance: 0.75);

            Console.WriteLine("10x10, 75% fill chance");
            printImage(threeQuarter10x10);

            var oneQuarter10x10 = ImageGenerator.GenerateImage(size: 10, fillChance: 0.25);

            Console.WriteLine("10x10, 25% fill chance");
            printImage(oneQuarter10x10);

            var allBlack = ImageGenerator.GenerateImage(size: 6, fillChance: 0.0);

            Console.WriteLine("6x6, 0% fill chance");
            printImage(allBlack);

            var allWhite = ImageGenerator.GenerateImage(size: 6, fillChance: 1.0);

            Console.WriteLine("6x6, 100% fill chance");
            printImage(allWhite);

            var half20x20 = ImageGenerator.GenerateImage(size: 20, fillChance: 0.5);

            Console.WriteLine("20x20, 50% fill chance");
            printImage(half20x20);

            var same1 = ImageGenerator.GenerateImage(size: 10, fillChance: 0.5, seed: 1);
            var same2 = ImageGenerator.GenerateImage(size: 10, fillChance: 0.5, seed: 1);

            Console.WriteLine("Two images using the same seed and fill chance");
            printImage(same1);
            printImage(same2);

            Console.WriteLine("Go again? [y/n]");

            if (Console.ReadLine().ToLower() == "y")
            {
                Main();
            }
        }

        private static void printImage(GeneratedImage image)
        {
            for (int x = 0; x < image.Pixels.GetLength(0); x++)
            {
                for (int y = 0; y < image.Pixels.GetLength(1); y++)
                {
                    Console.Write(image.Pixels[x, y] ? "■" : " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
