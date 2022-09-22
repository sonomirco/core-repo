using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Attributes;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Gh_core
{
    internal class ComponentAttribute : GH_ComponentAttributes
    {
        internal ComponentAttribute(IGH_Component component) : base(component)
        {
        }

        protected override void Render(GH_Canvas canvas, Graphics graphics, GH_CanvasChannel channel)
        {
            if (channel == GH_CanvasChannel.Objects)
            {
                CoreFrame(graphics);
            }
            base.Render(canvas, graphics, channel);
        }

        internal void CoreFrame(Graphics graphics)
        {
            int radius = 3;
            Size size = new Size(2 * radius, 2 * radius);
            Rectangle bounds = Rectangle.Round(Bounds);
            Point location = new Point(bounds.Left - radius, bounds.Top - radius);
            Rectangle arcRec = new Rectangle(location, size);
            GraphicsPath roundedRec = new GraphicsPath();

            roundedRec.AddArc(arcRec, 180, 90);
            arcRec.X = bounds.Right - radius;
            roundedRec.AddArc(arcRec, 270, 90);
            arcRec.Y = bounds.Bottom - radius;
            roundedRec.AddArc(arcRec, 0, 90);
            arcRec.X = bounds.Left - radius;
            roundedRec.AddArc(arcRec, 90, 90);
            roundedRec.CloseFigure();

            graphics.FillPath(new SolidBrush(Color.FromArgb((int)byte.MaxValue, 231, 47, 135)), roundedRec);
        }
    }
}
