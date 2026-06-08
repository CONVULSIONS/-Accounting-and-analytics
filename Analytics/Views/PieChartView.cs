using AccountingAndAnalytics.Analytics.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Analytics.Views;

public partial class PieChartView : Control
{
    public static readonly StyledProperty<List<PieSlice>> SlicesProperty =
        AvaloniaProperty.Register<PieChartView, List<PieSlice>>(nameof(Slices));

    public List<PieSlice> Slices
    {
        get => GetValue(SlicesProperty);
        set => SetValue(SlicesProperty, value);
    }

    static PieChartView()
    {
        SlicesProperty.Changed.AddClassHandler<PieChartView>((x, _) => x.InvalidateVisual());
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        if (Slices == null || Slices.Count == 0) return;

        double total = 0;
        foreach (var s in Slices) total += s.Value;

        double cx = Bounds.Width / 2;
        double cy = Bounds.Height / 2;
        double radius = Math.Min(cx, cy) - 4;
        double startAngle = -Math.PI / 2;

        foreach (var slice in Slices)
        {
            double sweepAngle = (slice.Value / total) * 2 * Math.PI;
            double endAngle = startAngle + sweepAngle;

            var geometry = new StreamGeometry();
            using (var ctx = geometry.Open())
            {
                ctx.BeginFigure(new Point(cx, cy), true);
                ctx.LineTo(new Point(
                    cx + radius * Math.Cos(startAngle),
                    cy + radius * Math.Sin(startAngle)));

                int steps = Math.Max((int)(sweepAngle / 0.05), 1);
                for (int i = 1; i <= steps; i++)
                {
                    double angle = startAngle + sweepAngle * i / steps;
                    ctx.LineTo(new Point(
                        cx + radius * Math.Cos(angle),
                        cy + radius * Math.Sin(angle)));
                }
                ctx.EndFigure(true);
            }

            context.DrawGeometry(
                new SolidColorBrush(slice.Color),
                new Pen(Brushes.White, 2),
                geometry);

            startAngle = endAngle;
        }
    }
}
