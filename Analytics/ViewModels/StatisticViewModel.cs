using AccountingAndAnalytics.Analytics.Models;
using AccountingAndAnalytics.Shared.ViewModels;
using Avalonia.Media;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Analytics.ViewModels
{
    public partial class StatisticViewModel : ViewModelBase
    {
        public string TaskSpeedLabel { get; set; } = "Скорость выполнения задач";
        public string TasksCompletedCount { get; set; } = "Задач выполнено: 13";
        public double TasksCompletedPercent { get; set; } = 65;

        public string DealsChartLabel { get; set; } = "Сделки";
        public string DealsClosedLabel { get; set; } = "Закрыто";
        public string DealsActiveLabel { get; set; } = "В сопровождении";
        public string DealsCancelledLabel { get; set; } = "Разорвано";
        public double TasksProgress => 65;
        //public int TasksCompletedCount => 12;
        public int ApplicationsCount => 8;

        public List<PieSlice> ApplicationsSlices => new()
    {
        new PieSlice { Value = 5, Color = Color.FromRgb(15, 110, 86) },
        new PieSlice { Value = 2, Color = Color.FromRgb(46, 107, 138) },
        new PieSlice { Value = 1, Color = Color.FromRgb(163, 45, 45) },
    };

        public List<PieSlice> DealsSlices => new()
    {
        new PieSlice { Value = 4, Color = Color.FromRgb(15, 110, 86) },
        new PieSlice { Value = 3, Color = Color.FromRgb(46, 107, 138) },
        new PieSlice { Value = 2, Color = Color.FromRgb(163, 45, 45) },
    };
    }
}
