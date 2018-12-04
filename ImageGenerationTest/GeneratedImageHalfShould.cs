using ImageGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Linq;

namespace ImageGenerationTest
{
    [TestClass]
    public class GeneratedImageHalfShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotAcceptSizeUnder2()
        {
            var imageHalf = GeneratedImageHalf.Generate(size: 1, fillChance: 0.5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotAcceptFillChanceAbove1()
        {
            var imageHalf = GeneratedImageHalf.Generate(size: 6, fillChance: 1.2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotAcceptFillChanceBelow0()
        {
            var imageHalf = GeneratedImageHalf.Generate(size: 6, fillChance: -0.1);
        }

        [TestMethod]
        public void HaveCorrectSizePixels()
        {
            int size = 6;

            var imageHalf = GeneratedImageHalf.Generate(size, fillChance: 0.5);

            int length0 = imageHalf.Pixels.GetLength(0);
            int length1 = imageHalf.Pixels.GetLength(1);

            Assert.AreEqual(length0, size);
            Assert.AreEqual(length1, size / 2);
        }

        [TestMethod]
        public void HaveCorrectSizePixelsUsingOddSize()
        {
            int size = 7;

            var imageHalf = GeneratedImageHalf.Generate(size, fillChance: 0.5);

            int length0 = imageHalf.Pixels.GetLength(0);
            int length1 = imageHalf.Pixels.GetLength(1);

            Assert.AreEqual(length0, 7);
            Assert.AreEqual(length1, 4);
        }

        /// <summary>
        /// This test should pass *most* of the time,
        /// but can fail occasionally due to the random nature of it
        /// </summary>
        [TestMethod]
        public void BeRouglyHalfFilledWhenUsingHalfFillChance()
        {
            var imageHalf = GeneratedImageHalf.Generate(size: 6, fillChance: 0.5);

            double totalPixels = imageHalf.Pixels.Length;

            // count all true values after flattening the 2d array
            double filledPixels = imageHalf.Pixels.Cast<bool>().Count(x => x);

            double percentage = filledPixels / totalPixels;

            // should be roughly between 1/3 and 2/3 given the fillChance of 0.5
            Assert.IsTrue(percentage > 0.33 && percentage < 0.66);
        }

        [TestMethod]
        public void GenerateSameImageUsingSameSeed()
        {
            // testing seeds from -1000 to 1000
            for (int n = -1000; n < 1001; n++)
            {
                var imageHalf1 = GeneratedImageHalf.Generate(
                    size: 6,
                    fillChance: 0.5,
                    seed: n);

                var imageHalf2 = GeneratedImageHalf.Generate(
                    size: 6,
                    fillChance: 0.5,
                    seed: n);

                // test that pixel arrays are the same size
                Assert.AreEqual(imageHalf1.Pixels.GetLength(0), imageHalf2.Pixels.GetLength(0));
                Assert.AreEqual(imageHalf1.Pixels.GetLength(1), imageHalf2.Pixels.GetLength(1));

                // iterate over both arrays and test that all values are equal
                for (int x = 0; x < imageHalf1.Pixels.GetLength(0); x++)
                {
                    for (int y = 0; y < imageHalf1.Pixels.GetLength(1); y++)
                    {
                        Assert.AreEqual(imageHalf1.Pixels[x, y], imageHalf2.Pixels[x, y]);
                    }
                }
            }
        }
    }
}
