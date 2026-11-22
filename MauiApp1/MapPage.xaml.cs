
namespace MauiApp1;

public partial class MapPage : ContentPage
{
    private readonly StoreMapDrawable drawable;

    public MapPage()
    {
        InitializeComponent();

        drawable = new StoreMapDrawable();

        MapCanvas.Drawable = drawable;
    }

    // מופעל כשהמשתמש נוגע במפה
    private void OnMapTouched(
        object sender, TouchEventArgs e)
    {
        if (e.Touches.Length == 0)
            return;

        // מקבלים את מיקום הלחיצה
        var point = e.Touches[0];

        // מוסיפים את הנקודה לרשימה
        drawable.Points.Add(point);

        // מבקשים לצייר מחדש
        MapCanvas.Invalidate();
    }

    // ניקוי המפה
    private void OnClearClicked(
        object sender, EventArgs e)
    {
        drawable.Points.Clear();

        MapCanvas.Invalidate();
    }
}
