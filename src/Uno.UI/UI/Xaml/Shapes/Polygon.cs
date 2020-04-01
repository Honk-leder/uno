﻿#if !__IOS__ && !__MACOS__
#define LEGACY_SHAPE_MEASURE
#endif

using Windows.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Collections;

namespace Windows.UI.Xaml.Shapes
{
	public partial class Polygon
#if LEGACY_SHAPE_MEASURE
		: ArbitraryShapeBase
#endif
	{
		#region Points

		public PointCollection Points
		{
			get { return (PointCollection)GetValue(PointsProperty); }
			set { SetValue(PointsProperty, value); }
		}

		public static global::Windows.UI.Xaml.DependencyProperty PointsProperty { get; } =
			DependencyProperty.Register(
				"Points", typeof(global::Windows.UI.Xaml.Media.PointCollection),
				typeof(global::Windows.UI.Xaml.Shapes.Polygon),
				new FrameworkPropertyMetadata(
					defaultValue: default(global::Windows.UI.Xaml.Media.PointCollection),
					options: FrameworkPropertyMetadataOptions.LogicalChild | FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange,
					propertyChangedCallback: (s, e) => ((Polygon)s).OnPointsChanged()
				)
			);

		partial void OnPointsChanged();

		#endregion

		public Polygon()
		{
			Points = new PointCollection();
		}

#if LEGACY_SHAPE_MEASURE
		protected internal override IEnumerable<object> GetShapeParameters()
		{
			yield return Points?.ToArray();

			foreach (var p in base.GetShapeParameters())
			{
				yield return p;
			}
		}
#endif
	}
}
