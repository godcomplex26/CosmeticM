using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmeticM
{
    internal class CustomButton: Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Brush brush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.Blue, LinearGradientMode.Vertical);
            g.FillRoundedRectangle(brush, 0, 0, this.Width - 1, this.Height - 1, 20);
            brush.Dispose();
            g.DrawRoundedRectangle(Pens.Navy, 0, 0, this.Width - 1, this.Height - 1, 20);
        }
    }

    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush brush, int x, int y, int width, int height, int cornerRadius)
        {
            using (GraphicsPath path = RoundedRect(x, y, width, height, cornerRadius))
            {
                g.FillPath(brush, path);
            }
        }

        public static void DrawRoundedRectangle(this Graphics g, Pen pen, int x, int y, int width, int height, int cornerRadius)
        {
            using (GraphicsPath path = RoundedRect(x, y, width, height, cornerRadius))
            {
                g.DrawPath(pen, path);
            }
        }

        private static GraphicsPath RoundedRect(int x, int y, int width, int height, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(x, y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            path.AddLine(x + cornerRadius, y, x + width - cornerRadius, y);
            path.AddArc(x + width - cornerRadius * 2, y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            path.AddLine(x + width, y + cornerRadius, x + width, y + height - cornerRadius);
            path.AddArc(x + width - cornerRadius * 2, y + height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            path.AddLine(x + width - cornerRadius, y + height, x + cornerRadius, y + height);
            path.AddArc(x, y + height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
