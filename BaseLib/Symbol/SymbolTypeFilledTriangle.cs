using System;
using System.Collections.Generic;
using System.Drawing;
using BaseLib.Graphic;
using BaseLibS.Graph;

namespace BaseLib.Symbol{
	public class SymbolTypeFilledTriangle : SymbolType{
		public SymbolTypeFilledTriangle(int index) : base(index) {}
		public override string Name => "Filled triangle";

		public override void GetPath(int size, out int[] pathX, out int[] pathY){
			int s2 = size/2;
			List<int> x = new List<int>();
			List<int> y = new List<int>();
			int min = (int) Math.Round(-(2*s2 + 1)/Math.Sqrt(3)/2.0);
			int max = (int) Math.Round((2*s2 + 1)/Math.Sqrt(3));
			for (int i = -s2; i <= s2; i++){
				x.Add(i);
				y.Add(-min);
			}
			for (int i = min + 1; i <= max; i++){
				int k = (int) Math.Round((max - i)/(float) (max - min)*s2);
				for (int l = -k; l <= k; l++){
					x.Add(l);
					y.Add(-i);
				}
			}
			pathX = x.ToArray();
			pathY = y.ToArray();
		}

		public override void Draw(int size, int x, int y, IGraphics g, Pen2 pen, Brush2 brush){
			int s2 = size/2;
			Point[] points = {new Point(x, y - s2), new Point(x - s2, y - s2), new Point(x + s2, y - s2)};
			g.FillPolygon(brush, points);
			g.DrawPolygon(pen, points);
		}
	}
}