using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Conway_s_Game_of_Life.Model
{
	public class Cell : INotifyPropertyChanged
	{
		private bool isAlive;

		private List<Cell> neighbors = null;

		public List<Cell> Neighbors
		{
			get { return neighbors; }
			set { neighbors = value; }
		}


		public bool IsAlive
		{
			get { return isAlive; }
			set
			{
				isAlive = value;
				FieldChanged();
			}
		}
		public bool NextState { get; set; } = false;

		public int X { get; set; }
		public int Y { get; set; }

		public Cell(int x, int y)
		{
			X = x;
			Y = y;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void FieldChanged()
		{
			if (PropertyChanged!=null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(null));
			}
		}

		public void Update()
		{
			IsAlive = NextState;
		}
	}
}
