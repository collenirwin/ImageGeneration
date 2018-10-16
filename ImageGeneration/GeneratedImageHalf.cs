using Newtonsoft.Json;
using System;
using System.Drawing;

namespace ImageGeneration
{
    /// <summary>
    /// Represents half of a generated image
    /// </summary>
    public class GeneratedImageHalf
    {
        /// <summary>
        /// The <see cref="Random"/> object used in generating random pixels
        /// </summary>
        private static readonly Random random = new Random();

        /// <summary>
        /// Number of rows and columns in the full image
        /// (for example, a Size of 10 would result in a 10 by 10 "pixel" image)
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; private set; }

        /// <summary>
        /// Boolean 2D array that represents the pixels of the image half
        /// (true -> filled, false -> blank)
        /// </summary>
        [JsonProperty("pixels")]
        public bool[,] Pixels { get; private set; }

        /// <summary>
        /// The color of all <see cref="Pixels"/>
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }

        /// <summary>
        /// Generates a <see cref="GeneratedImageHalf"/> with the specified size, color, and fill chance
        /// </summary>
        /// <param name="size">Number of rows and columns in the full image (must be even, minimum is 2)</param>
        /// <param name="color">The color of all <see cref="Pixels"/></param>
        /// <param name="fillChance">Chance to color a rectangle out of 1.0</param>
        /// <returns>
        /// A <see cref="GeneratedImageHalf"/> object with randomly selected <see cref="Pixels"/>
        /// based on fillChance
        /// </returns>
        public static GeneratedImageHalf Generate(int size, Color color, double fillChance)
        {
            if (size < 2)
            {
                throw new ArgumentException("size must be greater than 1.", "size");
            }

            if (size % 2 != 0)
            {
                throw new ArgumentException("size must be an even number.", "size");
            }

            if (fillChance < 0.0 || fillChance > 1.0)
            {
                throw new ArgumentException("fillChance must be between 0.0 and 1.0.", "fillChance");
            }

            var imageHalf = new GeneratedImageHalf
            {
                Size = size,

                // size # of rows, 1/2 size # of columns
                Pixels = new bool[size, size / 2],
                Color = color
            };

            // iterate over the pixel matrix and fill pixels based on the fill chance
            for (int x = 0; x < imageHalf.Pixels.GetLength(0); x++)
            {
                for (int y = 0; y < imageHalf.Pixels.GetLength(1); y++)
                {
                    // roll a random double between 0.0 and 1.0
                    double roll = random.NextDouble();

                    // if the roll is within the fill chance we 'fill' the pixel
                    imageHalf.Pixels[x, y] = roll <= fillChance;
                }
            }

            return imageHalf;
        }
    }
}
