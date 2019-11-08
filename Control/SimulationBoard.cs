using Conway_s_Game_of_Life.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;

namespace Conway_s_Game_of_Life.Control
{
	public static class SimulationBoard
	{
		private static int ticksPerSecond = 1;
		public static int TicksPerSecond
		{
			get { return ticksPerSecond; }
			set
			{
				ticksPerSecond = value;
				Clock.Interval = 1000 / ticksPerSecond;
			}
		}
		public static Timer Clock { get; set; } = new Timer();

		private static Cell[,] gameGrid;

		public static Cell[,] GameGrid
		{
			get { return gameGrid; }
			set
			{
				gameGrid = value;
				allCells = new List<Cell>();
				foreach(Cell c in GameGrid)
				{
					allCells.Add(c);
				}
			}
		}

		private static List<Cell> allCells;

		private static int height;

		public static int Height
		{
			get { return height; }
			set
			{
				height = value;
				GenerateBoard();
			}
		}

		private static int width;

		public static int Width
		{
			get { return width; }
			set
			{
				width = value;
				GenerateBoard();
			}
		}

		public static void Randomize()
		{
			Random rando = new Random();
			foreach(Cell c in gameGrid)
			{
				c.IsAlive = rando.Next(100) % 2 == 0;
			}
		}

		private static void GenerateBoard()
		{
			Cell[,] newGrid = new Cell[Width, Height];
			for (int r = 0; r<Width;r++)
			{
				for (int c = 0; c<Height;c++)
				{
					newGrid[r, c] = new Cell(r, c);
				}
			}
			GameGrid = newGrid;
		}

		static SimulationBoard()
		{
			Height = 10;
			Width = 10;
			Clock.Elapsed += Clock_Elapsed;
		}

		private static void Clock_Elapsed(object sender, ElapsedEventArgs e)
		{
			GenerationStep();
		}

		public static void GenerationStep()
		{
			for (int r = 0; r<Width;r++)
			{
				for (int c = 0; c<Height; c++)
				{
					gameGrid[r, c].NextState = CheckCell(r, c);
				}
			}
			foreach(Cell c in gameGrid)
			{
				if (c.NextState!=c.IsAlive)
					c.Update();
			}
		}

		public static bool CheckCell(int x, int y)
		{
			bool retVal;
			if (gameGrid[x, y].Neighbors == null)
			{
				gameGrid[x,y].Neighbors = allCells.Where(c=> ((Math.Abs(c.X - x) == 1 && Math.Abs(c.Y - y) == 1) || (Math.Abs(c.X - x) == 1 && c.Y == y) || (Math.Abs(c.Y - y) == 1 && c.X == x))).Select(c => c).ToList();
			}
			int neighbors = gameGrid[x, y].Neighbors.Where(c => c.IsAlive).Count();
			if (gameGrid[x,y].IsAlive)
			{
				retVal = !(neighbors<2 || neighbors>3);
			}
			else
			{
				retVal = (neighbors == 3);
			}
			return retVal;
		}
	}
}
