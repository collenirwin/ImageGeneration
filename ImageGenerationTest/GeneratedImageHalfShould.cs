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
        public void NotAcceptOddSize()
        {
            var imageHalf = GeneratedImageHalf.Generate(size: 5, color: Color.Green, fillChance: 0.5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotAcceptSizeUnder2()
        {
            var imageHalf = GeneratedImageHalf.Generate(size: 1, color: Color.Green, fillChance: 0.5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotAcceptFillChanceAbove1()
        {
            var imageHalf = GeneratedImageHalf.Generate(size: 6, color: Color.Green, fillChance: 1.2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotAcceptFillChanceBelow0()
        {
            var imageHalf = GeneratedImageHalf.Generate(size: 6, color: Color.Green, fillChance: -0.1);
        }

        [TestMethod]
        public void HaveCorrectSizePixels()
        {
            int size = 6;

            var imageHalf = GeneratedImageHalf.Generate(size, Color.Green, fillChance: 0.5);

            int length0 = imageHalf.Pixels.GetLength(0);
            int length1 = imageHalf.Pixels.GetLength(1);

            Assert.AreEqual(length0, size);
            Assert.AreEqual(length1, size / 2);
        }

        [TestMethod]
        public void HaveRoughlyHalfOfPixelsFilled()
        {
            var imageHalf = GeneratedImageHalf.Generate(size: 6, color: Color.Green, fillChance: 0.5);

            double totalPixels = imageHalf.Pixels.Length;

            // count all true values after flattening the 2d array
            double filledPixels = imageHalf.Pixels.Cast<bool>().Count(x => x);

            double percentage = filledPixels / totalPixels;

            // should be roughly between 1/3 and 2/3 given the fillChance of 0.5
            Assert.IsTrue(percentage > 0.33 && percentage < 0.66);
        }
    }
}
