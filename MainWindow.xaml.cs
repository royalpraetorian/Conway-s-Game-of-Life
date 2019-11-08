using Conway_s_Game_of_Life.Control;
using Conway_s_Game_of_Life.Model;
using Conway_s_Game_of_Life.View;
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

namespace Conway_s_Game_of_Life
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private bool mouseDown = false;
		private bool mouseDownAlive;
		public bool isRunning = false;
		public MainWindow()
		{
			InitializeComponent();
			ConfigureControls();
			PopulateGrid();
			ticksPerSecondSlider.Slider.ValueChanged += tickValueChanged;
		}

		public void ConfigureControls()
		{
			gridHeightSlider.Label.Content= "Grid Height";
			gridWidthSlider.Label.Content = "Grid Width";
			ticksPerSecondSlider.Label.Content = "Generations Per Second";
			gridHeightSlider.Slider.Interval = 1;
			ticksPerSecondSlider.Slider.Interval = 1;
			gridWidthSlider.Slider.Interval = 1;
			gridHeightSlider.Slider.Minimum = 10;
			gridWidthSlider.Slider.Minimum = 10;
			gridHeightSlider.Slider.Maximum = 100;
			gridWidthSlider.Slider.Maximum = 100;
			ticksPerSecondSlider.Slider.Minimum = 1;
			ticksPerSecondSlider.Slider.Maximum = 60;
		}

		private void updateButton_Click(object sender, RoutedEventArgs e)
		{
			SimulationBoard.Width=((int)gridWidthSlider.Slider.Value);
			SimulationBoard.Height = (int)gridHeightSlider.Slider.Value;
			PopulateGrid();
		}

		private void cellLabel_MouseDown(object sender, RoutedEventArgs e)
		{
			mouseDown = true;
			mouseDownAlive = ((Cell)((Label)sender).DataContext).IsAlive;
			updateCell(sender);
		}
		private void updateCell(object sender)
		{
			Cell dataContext = ((Cell)((Label)sender).DataContext);
			SimulationBoard.GameGrid[dataContext.X, dataContext.Y].IsAlive = !dataContext.IsAlive;
		}
		private void cellLabel_MouseUp(object sender, RoutedEventArgs e)
		{
			mouseDown = false;
		}
		private void PopulateGrid()
		{
			gameGrid.Children.Clear();
			gameGrid.Rows = SimulationBoard.Height;
			gameGrid.Columns= SimulationBoard.Width;
			Random rando = new Random();
			for (int r = 0; r < SimulationBoard.Height; r++)
			{
				for (int c = 0; c < SimulationBoard.Width; c++)
				{
					byte[] rgba = new byte[4];
					rando.NextBytes(rgba);
					Label cell = new Label();
					cell.DataContext = SimulationBoard.GameGrid[r, c];
					Binding bind = new Binding();
					bind.Converter = new CellStateConverter();
					bind.Source = cell.DataContext;
					bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
					bind.Path = new PropertyPath("IsAlive");
					cell.SetBinding(Label.BackgroundProperty, bind);
					cell.BorderBrush = new SolidColorBrush(new Color() { R = 255, G = 255, B = 255, A = 255 });
					cell.BorderThickness = new Thickness(1);
					cell.MouseLeftButtonDown += cellLabel_MouseDown;
					cell.MouseLeftButtonUp += cellLabel_MouseUp;
					cell.MouseEnter += labelMouseOver;
					gameGrid.Children.Add(cell);
				}
			}
		}

		private void randomizerButton_Click(object sender, RoutedEventArgs e)
		{
			SimulationBoard.Randomize();
		}

		private void stepButton_Click(object sender, RoutedEventArgs e)
		{
			SimulationBoard.GenerationStep();
		}

		private void startStopButton_Click(object sender, RoutedEventArgs e)
		{
			if (isRunning)
			{
				isRunning = false;
				SimulationBoard.Clock.Stop();
				startStopButton.Content = "Start";
				startStopButton.Background = new SolidColorBrush(new Color() { R=57,G=178,B=70,A=255});
			}
			else
			{
				isRunning = true;
				SimulationBoard.Clock.Start();
				startStopButton.Content = "Stop";
				startStopButton.Background = new SolidColorBrush(new Color() { R = 178, G = 44, B = 31, A = 255 });
			}
		}

		private void tickValueChanged(object sender, RoutedEventArgs e)
		{
			SimulationBoard.TicksPerSecond = (int)ticksPerSecondSlider.Slider.Value;
		}

		private void labelMouseOver(object sender, RoutedEventArgs e)
		{
			if (mouseDown && ((Cell)((Label)sender).DataContext).IsAlive==mouseDownAlive)
				updateCell(sender);
		}
	}
}
