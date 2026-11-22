
using System.Collections.Generic;
using Microsoft.Maui.Graphics;

namespace MauiApp1;

public class StoreMapDrawable : IDrawable
{
    // רשימת נקודות שהמשתמש מסמן
    public List<PointF> Points { get; } = new();

    public void Draw(ICanvas canvas, RectF area)
    {
        // הגדרת צבע ועובי הקווים
        canvas.StrokeColor = Colors.Blue;
        canvas.StrokeSize = 5;

        // ציור קווים בין נקודות עוקבות
        for (int i = 1; i < Points.Count; i++)
        {
            PointF start = Points[i - 1];
            PointF end = Points[i];

            canvas.DrawLine(
                start.X, start.Y,
                end.X, end.Y);
        }

        // ציור הנקודות עצמן
        canvas.FillColor = Colors.DarkBlue;

        foreach (PointF point in Points)
        {
            canvas.FillCircle(
                point.X, point.Y, 8);
        }
    }
}
