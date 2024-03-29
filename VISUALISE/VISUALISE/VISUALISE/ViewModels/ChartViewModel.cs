using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using Visualise.Models;
using Visualise.Services;
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

			var ls = new LineSeries
			{
				StrokeThickness = .25
			};

			List<String> xVals = Form.XFormValues;
			List<String> yVals = Form.YFormValues;

			if (xVals.Count > 0 && yVals.Count > 0)
				{

				// decide what kind of graph -> (string, int) = pie... (int, int) and (string, string) = line/plot
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
							data.Add(new Data(xVals[i].ToString(), total.ToString()));
						}
					}

					// Create the graph
					foreach (Data key in data)
					{
						ps.Slices.Add(new PieSlice(key.XVal, Double.Parse(key.YVal)));
					}
					ps.OutsideLabelFormat = "";
					ps.TickHorizontalLength = 0.00;
					ps.TickRadialLength = 0.00;
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
							data.Add(new Data(total.ToString(), yVals[i].ToString()));
						}
					}
					// Create the graph
					foreach (Data key in data)
					{
						ps.Slices.Add(new PieSlice(key.YVal, Double.Parse(key.XVal)));
					}
					ps.OutsideLabelFormat = "";
					ps.TickHorizontalLength = 0.00;
					ps.TickRadialLength = 0.00;
					model.Series.Add(ps);
					return model;
				// line/plot
				} else
				{
					for (int i = 0; i < xVals.Count; i++)
					{
						ls.Points.Add(new DataPoint(Double.Parse(xVals[i]), Double.Parse(yVals[i])));
					}
					model.Series.Add(ls);
					return model;
				}
			} else
			{
				return model;
			}
		}
	}
}

