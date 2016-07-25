﻿using System.Drawing;
using BaseLib.Forms.Base;
using BaseLib.Graphic;
using BaseLibS.Graph;

namespace BaseLib.Forms.Scroll{
	internal class ScrollComponentView : BasicView{
		protected readonly CompoundScrollableControl main;

		protected ScrollComponentView(CompoundScrollableControl main){
			this.main = main;
		}

		protected internal sealed override void OnPaintBackground(IGraphics g, int width, int height){
			if (main == null){
				return;
			}
			if (main.BackColor.IsEmpty || main.BackColor == Color.Transparent){
				return;
			}
			Brush2 b = new Brush2(Color2.FromArgb(main.BackColor.A, main.BackColor.R, main.BackColor.G, main.BackColor.B));
			g.FillRectangle(b, 0, 0, width, height);
		}
	}
}