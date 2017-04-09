using System.Drawing;

namespace BaseLibC.Graphic{
	//TODO: should not be exposed
	public class CGraphics : WindowsBasedGraphics {
		public CGraphics(Graphics g) : base(g) { }
		public override void Close() {}
	}
}