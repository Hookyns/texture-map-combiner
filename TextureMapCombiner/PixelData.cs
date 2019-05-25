using System.Drawing;

namespace TextureMapCombiner
{
	/// <summary>
	/// Pixel data
	/// </summary>
	public struct PixelData
	{
		public int x;
		public int y;
		public Color color;

		public PixelData(int x, int y, Color color)
		{
			this.x = x;
			this.y = y;
			this.color = color;
		}
	}
}