using ImageGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace ImageGenerationTest
{
    [TestClass]
    public class GeneratedImageShould
    {
        [TestMethod]
        public void HaveCorrectSizePixels()
        {
            int size = 6;

            var image = new GeneratedImage(GeneratedImageHalf.Generate(size, Color.Green, fillChance: 0.5));

            int length0 = image.Pixels.GetLength(0);
            int length1 = image.Pixels.GetLength(1);

            Assert.AreEqual(length0, size);
            Assert.AreEqual(length1, size);
        }

        [TestMethod]
        public void ReflectImageHalfPixels()
        {
            var imageHalf = GeneratedImageHalf.Generate(size: 4, color: Color.Green, fillChance: 0.5);

            var image = new GeneratedImage(imageHalf);

            // check that the left side of image.Pixels is the same as imageHalf.Pixels
            for (int x = 0; x < imageHalf.Pixels.GetLength(0); x++)
            {
                for (int y = 0; y < imageHalf.Pixels.GetLength(1); y++)
                {
                    Assert.AreEqual(imageHalf.Pixels[x, y], image.Pixels[x, y]);
                }
            }

            // check that the right side of image.Pixels is imageHalf.Pixels flipped horizontally
            for (int x = 0; x < image.Pixels.GetLength(0); x++)
            {
                for (int y = image.Pixels.GetLength(1) / 2; y < image.Pixels.GetLength(1); y++)
                {
                    Assert.AreEqual(imageHalf.Pixels[x, image.Pixels.GetLength(1) - y - 1], image.Pixels[x, y]);
                }
            }
        }
    }
}
