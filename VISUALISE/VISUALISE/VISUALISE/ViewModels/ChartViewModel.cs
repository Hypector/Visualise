using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using Visualise.Models;
using Visualise.Views;
using Xamarin.Forms;

namespace Visualise.ViewModels
{
	public struct Data
	{

		public Data(string val1, string val2)
		{
			XVal = val1;
			YVal = val2;
		}

		public string XVal { get; private set; }
		public string YVal { get; private set; }
	}
    public class ChartViewModel : BaseViewModel
    {
		public Form Form { get; set; }
		public PlotModel Graph { get; set; }
		public ChartViewModel(Form form = null)
        {
			Title = form?.ChartName;
            Form = form;
			Graph = CreateChart();
		}
		private PlotModel CreateChart()
		{
			// OxyPlot Setup
			var model = new PlotModel();

			var ps = new PieSeries
			{
				StrokeThickness = .125,
				InsideLabelPosition = 0.25,
				AngleSpan = 360,
				StartAngle = 0
			};

			// TODO for after MVP ------ optional graph choices
			List<String> xVals = Form.XFormValues;
			List<String> yVals = Form.YFormValues;

			// decide what kind of graph -> (string, int) = pie... (int, int) and (string, string) = line/plot
			// (assuming all values have the same type) -- TODO after MVP is add strict type checking and form customization
			bool isXInt = Int32.TryParse(xVals[0], out int a);
			bool isYInt = Int32.TryParse(yVals[0], out int b);

			// ========= normalise the values ===========
			// pie where x = category and y = value
			if (!isXInt && isYInt)
			{
				List<Data> data = new List<Data>();
				List<Int32> ignoreIndexes = new List<Int32>();
				for (int i = 0; i < xVals.Count; i++)
				{
					if (!ignoreIndexes.Contains(i))
					{
						int total = Int32.Parse(yVals[i]);
						for (int j = i + 1; j < yVals.Count; j++) 
						{
							if (xVals[j] == xVals[i])
							{
								total += Int32.Parse(yVals[j]);
								ignoreIndexes.Add(j);	
							}
						}
						Console.WriteLine("============================");
						Console.WriteLine(total);
						Console.WriteLine("============================");
						data.Add(new Data(xVals[i].ToString(), total.ToString()));
					}
				}

				// Create the graph
				foreach (Data key in data)
				{
					ps.Slices.Add(new PieSlice(key.XVal, Double.Parse(key.YVal)));
				}
				model.Series.Add(ps);
				return model;
			// pie where y = category and x = value
			} else if (isXInt && !isYInt)
			{
				List<Data> data = new List<Data>();
				List<Int32> ignoreIndexes = new List<Int32>();
				for (int i = 0; i < yVals.Count; i++)
				{
					if (!ignoreIndexes.Contains(i))
					{
						int total = Int32.Parse(xVals[i]);
						for (int j = i + 1; j < xVals.Count; j++) 
						{
							if (yVals[j] == yVals[i])
							{
								total += Int32.Parse(xVals[j]);
								ignoreIndexes.Add(j);	
							}
						}
						Console.WriteLine("==**8*=8=8=8=8=8=8=8=8======");
						Console.WriteLine(total);
						Console.WriteLine("8=8==88=8=8=8=8=8==88=8==88=");
						data.Add(new Data(total.ToString(), yVals[i].ToString()));
					}
				}
				// Create the graph
				foreach (Data key in data)
				{
					ps.Slices.Add(new PieSlice(key.YVal, Double.Parse(key.XVal)));
				}
				model.Series.Add(ps);
				return model;
			// line/plot
			} else
			{

			}

			ps.Slices.Add(new PieSlice("Asia", 900));
			ps.Slices.Add(new PieSlice("Europe", 739) { IsExploded = false });
			ps.Slices.Add(new PieSlice("Oceania", 500) { IsExploded = false });
			model.Series.Add(ps);
			return model;
		}
	}
}

