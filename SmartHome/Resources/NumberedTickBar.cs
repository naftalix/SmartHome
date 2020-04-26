using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace SmartHome.Resources
{
    public class NumberedTickBar : TickBar
    {
        protected override void OnRender(DrawingContext dc)
        {

            Size size = new Size(base.ActualWidth, base.ActualHeight);
            int tickCount = (int)((this.Maximum - this.Minimum) / this.TickFrequency) + 1;
            if ((this.Maximum - this.Minimum) % this.TickFrequency == 0)
                tickCount -= 1;
            Double tickFrequencySize;
            // Calculate tick's setting
            tickFrequencySize = (size.Width * this.TickFrequency / (this.Maximum - this.Minimum));
            string text = "";
            FormattedText formattedText = null;
            double num = this.Maximum - this.Minimum;
            int i = 0;
            // Draw each tick text
            for (i = 0; i <= tickCount; i++)
            {
               text = Convert.ToString(Convert.ToInt32(this.Minimum + this.TickFrequency * i), 10);
              //  text = Convert.ToString(Convert.ToInt32(this.Maximum) - Convert.ToInt32(this.Minimum + this.TickFrequency * i), 10);


                formattedText = new FormattedText(text, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Verdana"), 8, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF18A6DA")));
                //dc.DrawText(formattedText, new Point(0,(tickFrequencySize * i)));
               dc.DrawText(formattedText, new Point((tickFrequencySize * i),30));


            }
        }

    }
}

