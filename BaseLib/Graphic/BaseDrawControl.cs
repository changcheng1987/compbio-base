using System.Windows.Forms;
using BaseLibC.Forms.Base;
using BaseLibS.Graph;

namespace BaseLibC.Graphic{
	public abstract class BaseDrawControl : BasicUserControl{
	    protected BaseDrawControl(){
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.CacheText, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}

        public new abstract void DoPaint(IGraphics g);
	}
}