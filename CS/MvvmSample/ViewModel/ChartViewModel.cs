using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSample.ViewModel {
    class ChartViewModel {
        public IEnumerable<PaneViewModel>   Panes { get; private set; }
        public XAxisViewModel               XAxis { get; private set; }
        public IEnumerable<YAxisViewModel>  YAxes { get; private set; }
        public IEnumerable<SeriesViewModel> Series { get; private set; }
        public IEnumerable<LegendViewModel> Legends { get; private set; }

        public ChartViewModel (IEnumerable<SeriesViewModel> series, IEnumerable<LegendViewModel> legends, IEnumerable<PaneViewModel> panes, XAxisViewModel xAxis, IEnumerable<YAxisViewModel> yAxes) {
            this.Series = series;
            this.XAxis = xAxis;
            this.YAxes = yAxes;
            this.Panes = panes;
            this.Legends = legends;
        }
    }

    class LegendViewModel {
        public PaneViewModel DockTarget { get; private set; }

        public LegendViewModel(PaneViewModel dockTarget) {
            this.DockTarget = dockTarget;
        }
    }

    class PaneViewModel {
        public bool ShowXAxis { get; private set; }

        public PaneViewModel(bool showXAxis) {
            this.ShowXAxis = showXAxis;
        }
    }
    
    class XAxisViewModel {
        public DateTime MinValue { get; set; }
        public DateTime MaxValue { get; set; }
    }

    class YAxisViewModel {
        public string Title { get; private set; }
        public IEnumerable<ConstantLineViewModel> ConstantLines { get; private set; }

        public YAxisViewModel(string title, IEnumerable<ConstantLineViewModel> constantLines) {
            this.Title = title;
            this.ConstantLines = constantLines;
        }
    }

    class SeriesViewModel {
        public string Name { get; set; }
        public string ArgumentName { get; private set; }
        public string ValueName { get; private set; }
        public LegendViewModel Legend { get; private set; }
        public PaneViewModel Pane { get; private set; }
        public YAxisViewModel YAxis { get; private set; }
        public SeriesType Type { get; private set; }

        public SeriesViewModel(string name, SeriesType type, string argumentName, string valueName, LegendViewModel legend, PaneViewModel pane, YAxisViewModel yAxis) {
            this.Name = name;
            this.Type = type;
            this.ArgumentName = argumentName;
            this.ValueName = valueName;
            this.Legend = legend;
            this.Pane = pane;
            this.YAxis = yAxis;
        }
    }

    class ConstantLineViewModel {
        public string Title { get; private set; }
        public double Value { get; private set; }

        public ConstantLineViewModel(string title, double value) {
            this.Title = title;
            this.Value = value;
        }

    }

    public enum SeriesType {
        Bar, Area, Line
    }
}
