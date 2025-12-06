#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-09
//
// SOLUTION: FFArchiverCore
// PROJECT: FFArchiver
// FILE: ToolStripSpringComboBox.cs

#endregion File Info

namespace FFArchiver.Controls
{
    using System.Drawing;
    using System.Windows.Forms;

    public class ToolStripSpringComboBox : ToolStripComboBox
    {
        public override Size GetPreferredSize(Size constrainingSize)
        {
            if (IsOnOverflow || Owner.Orientation == Orientation.Vertical)
            {
                return DefaultSize;
            }

            int width = Owner.DisplayRectangle.Width;
            if (Owner.OverflowButton.Visible)
            {
                width -= Owner.OverflowButton.Width - Owner.OverflowButton.Margin.Horizontal;
            }

            var springItemCount = 0;
            foreach (ToolStripItem item in Owner.Items)
            {
                if (item.IsOnOverflow)
                {
                    continue;
                }

                if (item is ToolStripSpringComboBox)
                {
                    springItemCount++;
                    width -= item.Margin.Horizontal;
                }
                else
                {
                    width -= item.Width - item.Margin.Horizontal;
                }
            }

            if (springItemCount > 1)
            {
                width /= springItemCount;
            }

            width = width < DefaultSize.Width ? DefaultSize.Width : width;

            Size size = base.GetPreferredSize(constrainingSize);
            size.Width = width;
            return size;
        }
    }
}