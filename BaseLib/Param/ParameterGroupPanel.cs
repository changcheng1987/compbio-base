using System.Windows;
using System.Windows.Controls;

namespace BaseLib.Param{
	public partial class ParameterGroupPanel : UserControl{
		public ParameterGroup ParameterGroup { get; private set; }
		private Grid tableLayoutPanel;

		public void Init(ParameterGroup parameters1){
			Init(parameters1, 250F, 1000);
		}

		public void Init(ParameterGroup parameters1, float paramNameWidth, int totalWidth){
			ParameterGroup = parameters1;
			int nrows = ParameterGroup.Count;
			tableLayoutPanel = new Grid
			{HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, ShowGridLines = true};
			tableLayoutPanel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(paramNameWidth, GridUnitType.Pixel) });
			tableLayoutPanel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Star) });
			tableLayoutPanel.Margin =new Thickness(0);
			tableLayoutPanel.Name = "tableLayoutPanel";
			float totalHeight = 0;
			for (int i = 0; i < nrows; i++){
				float h = ParameterGroup[i].Visible ? ParameterGroup[i].Height : 0;
				tableLayoutPanel.RowDefinitions.Add(new RowDefinition { Height = new GridLength(h, GridUnitType.Pixel) });
				totalHeight += h;
			}
			tableLayoutPanel.Width = totalWidth;
			tableLayoutPanel.Height = (int)totalHeight;
			for (int i = 0; i < nrows; i++) {
				AddParameter(ParameterGroup[i], i);
			}
			AddChild(tableLayoutPanel);
			Name = "ParameterPanel";
			Width = totalWidth;
			Height = (int)totalHeight;
			Margin = new Thickness(3);
			Padding = new Thickness(3);
		}

		public void SetParameters(){
			ParameterGroup p1 = ParameterGroup;
			for (int i = 0; i < p1.Count; i++){
				p1[i].SetValueFromControl();
			}
		}

		private void AddParameter(Parameter p, int i){
			TextBlock txt1 = new TextBlock{Text = p.Name, ToolTip = p.Help, FontSize = 20, FontWeight = FontWeights.Bold};
			Grid.SetColumn(txt1, 0);
			Grid.SetRow(txt1, i);
			Control c = p.GetControl();
			c.Width = 500;
			Grid.SetColumn(c, 1);
			Grid.SetRow(c, i);
			tableLayoutPanel.Children.Add(txt1);
			tableLayoutPanel.Children.Add(c);
		}

		public void Enable(){
			tableLayoutPanel.IsEnabled = true;
		}

		public void Disable(){
			tableLayoutPanel.IsEnabled = false;
		}
	}
}