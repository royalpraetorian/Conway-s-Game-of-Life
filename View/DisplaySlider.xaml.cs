using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Conway_s_Game_of_Life.View
{
	/// <summary>
	/// Interaction logic for DisplaySlider.xaml
	/// </summary>
	public partial class DisplaySlider : UserControl
	{
		public Slider Slider
		{
			get { return primarySlider; }
			set { primarySlider = value; }
		}
		public TextBox TextBox
		{
			get { return textBox; }
			set { textBox = value; }
		}
		public Label Label
		{
			get { return valueLabel; }
			set { valueLabel = value; }
		}
		public DisplaySlider()
		{
			InitializeComponent();
		}
	}
}
