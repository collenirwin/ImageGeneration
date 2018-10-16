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
        /// <param name="color">The color of all <see cref="GenerateImage.Pixels"/></param>
        /// <param name="fillChance">Chance to color a rectangle out of 1.0</param>
        /// <returns>
        /// A <see cref="GenerateImage"/> object with randomly selected <see cref="GenerateImage.Pixels"/>
        /// based on fillChance
        /// </returns>
        public static GeneratedImage GenerateImage(int size, Color color, double fillChance)
        {
            var imageHalf = GeneratedImageHalf.Generate(size, color, fillChance);

            return new GeneratedImage(imageHalf);
        }

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
        public static GeneratedImageHalf GenerateImageHalf(int size, Color color, double fillChance)
        {
            return GeneratedImageHalf.Generate(size, color, fillChance);
        }
    }
}
