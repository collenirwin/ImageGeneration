using System.Drawing;

namespace ImageGeneration
{
    /// <summary>
    /// Provides methods for generating random images and image halves
    /// </summary>
    public static class ImageGenerator
    {
        /// <summary>
        /// Generates a <see cref="GenerateImage"/> with the specified size, color, and fill chance
        /// </summary>
        /// <param name="size">Number of rows and columns in the full image (must be even, minimum is 2)</param>
        /// <param name="fillChance">Chance to color a rectangle out of 1.0</param>
        /// <param name="seed">
        /// Optional integer to seed the Random object with (default time-based seed used if left null)
        /// </param>
        /// <returns>
        /// A <see cref="GenerateImage"/> object with randomly selected <see cref="GenerateImage.Pixels"/>
        /// based on fillChance
        /// </returns>
        public static GeneratedImage GenerateImage(int size, double fillChance, int? seed = null)
        {
            var imageHalf = GeneratedImageHalf.Generate(size, fillChance, seed);

            return new GeneratedImage(imageHalf);
        }

        /// <summary>
        /// Generates a <see cref="GeneratedImageHalf"/> with the specified size, color, and fill chance
        /// </summary>
        /// <param name="size">Number of rows and columns in the full image (must be even, minimum is 2)</param>
        /// <param name="fillChance">Chance to color a rectangle out of 1.0</param>
        /// <param name="seed">
        /// Optional integer to seed the Random object with (default time-based seed used if left null)
        /// </param>
        /// <returns>
        /// A <see cref="GeneratedImageHalf"/> object with randomly selected <see cref="Pixels"/>
        /// based on fillChance
        /// </returns>
        public static GeneratedImageHalf GenerateImageHalf(int size, double fillChance, int? seed = null)
        {
            return GeneratedImageHalf.Generate(size, fillChance, seed);
        }
    }
}
