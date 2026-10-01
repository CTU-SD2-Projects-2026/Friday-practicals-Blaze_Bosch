using System.Drawing;

namespace StudentManagementSystem;

public static class Theme
{
    public static readonly Color Background = Color.FromArgb(245, 247, 250);
    public static readonly Color Primary = Color.FromArgb(35, 83, 145);
    public static readonly Color PrimaryDark = Color.FromArgb(24, 58, 103);
    public static readonly Color Accent = Color.FromArgb(46, 125, 50);
    public static readonly Color Danger = Color.FromArgb(198, 40, 40);
    public static readonly Color Text = Color.FromArgb(35, 35, 35);
    public static readonly Font TitleFont = new("Segoe UI", 22, FontStyle.Bold);
    public static readonly Font HeadingFont = new("Segoe UI", 15, FontStyle.Bold);
    public static readonly Font NormalFont = new("Segoe UI", 10);
}
