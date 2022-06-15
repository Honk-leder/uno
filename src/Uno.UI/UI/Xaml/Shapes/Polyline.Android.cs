using Uno.Media;
using Windows.Foundation;

namespace Microsoft.UI.Xaml.Shapes
{
	public partial class Polyline : Shape
	{
		/// <inheritdoc />
		protected override Size MeasureOverride(Size availableSize)
			=> MeasureAbsoluteShape(availableSize, GetPath());

		/// <inheritdoc />
		protected override Size ArrangeOverride(Size finalSize)
			=> ArrangeAbsoluteShape(finalSize, GetPath());

		private Android.Graphics.Path GetPath()
		{
			var coords = Points;

			if (coords == null || coords.Count <= 1)
			{
				return null;
			}
			var output = new Android.Graphics.Path();

			output.MoveTo((float)coords[0].X, (float)coords[0].Y);
			for (var i = 1; i < coords.Count; i++)
			{
				output.LineTo((float)coords[i].X, (float)coords[i].Y);
			}


			return output;
		}
	}
}
