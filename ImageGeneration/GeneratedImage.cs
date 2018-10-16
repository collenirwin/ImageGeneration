using Newtonsoft.Json;
using System.Drawing;

namespace ImageGeneration
{
    /// <summary>
    /// Represents a generated image
    /// (a generated image half with the other half reflected over the horizontal axis)
    /// </summary>
    public class GeneratedImage
    {
        /// <summary>
        /// Number of rows and columns in the full image
        /// (for example, a Size of 10 would result in a 10 by 10 "pixel" image)
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; private set; }

        /// <summary>
        /// Boolean matrix that represents the pixels of the image
        /// (true -> filled, false -> blank)
        /// </summary>
        [JsonProperty("pixels")]
        public bool[,] Pixels { get; private set; }

        /// <summary>
        /// The color of all <see cref="Pixels"/>
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }

        public GeneratedImage(GeneratedImageHalf imageHalf)
        {
            Size = imageHalf.Size;
            Pixels = new bool[Size, Size];
            Color = imageHalf.Color;

            int halfSize = Size / 2;

            for (int x = 0; x < Size; x++)
            {
                // 0 to halfway, copy from imageHalf.Pixels
                for (int y = 0; y < halfSize; y++)
                {
                    Pixels[x, y] = imageHalf.Pixels[x, y];
                }

                // halfway to end, flip the y values from imageHalf.Pixels
                for (int y = halfSize; y < Size; y++)
                {
                    Pixels[x, y] = imageHalf.Pixels[x, Size - y - 1];
                }
            }
        }
    }
}
