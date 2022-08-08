using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daily_log
{
    public class RolloverItem : ToolStripItem
    {
        private bool clickedValue = false;
        private bool rolloverValue = false;

        private Rectangle imageRect;
        private Rectangle textRect;

        // For brevity, this implementation limits the possible 
        // TextDirection values to ToolStripTextDirection.Horizontal. 
        public override ToolStripTextDirection TextDirection
        {
            get
            {
                return base.TextDirection;
            }
            set
            {
                if (value == ToolStripTextDirection.Horizontal)
                {
                    base.TextDirection = value;
                }
                else
                {
                    throw new ArgumentException(
                        "RolloverItem supports only horizontal text.");
                }
            }
        }

        // For brevity, this implementation limits the possible 
        // TextImageRelation values to ImageBeforeText and TextBeforeImage. 
        public new TextImageRelation TextImageRelation
        {
            get
            {
                return base.TextImageRelation;
            }

            set
            {
                if (value == TextImageRelation.ImageBeforeText ||
                    value == TextImageRelation.TextBeforeImage)
                {
                    base.TextImageRelation = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Unsupported TextImageRelation value.");
                }
            }
        }

        // This property returns true if the mouse is 
        // inside the client rectangle.
        public bool Rollover
        {
            get
            {
                return this.rolloverValue;
            }
        }

        // This property returns true if the item 
        // has been toggled into the clicked state.
        // Clicking again toggles it to the 
        // unclicked state.
        public bool Clicked
        {
            get
            {
                return this.clickedValue;
            }
        }

        // The method defines the behavior of the Click event.
        // It simply toggles the state of the clickedValue field.
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            this.clickedValue ^= true;
        }

        // The method defines the behavior of the DoubleClick 
        // event. It shows a MessageBox with the item's text.
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            string msg = String.Format("Item: {0}", this.Text);

            MessageBox.Show(msg);
        }

        // This method defines the behavior of the MouseEnter event.
        // It sets the state of the rolloverValue field to true and
        // tells the control to repaint.
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.rolloverValue = true;

            this.Invalidate();
        }

        // This method defines the behavior of the MouseLeave event.
        // It sets the state of the rolloverValue field to false and
        // tells the control to repaint.
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.rolloverValue = false;

            this.Invalidate();
        }

        // This method defines the painting behavior of the control.
        // It performs the following operations:
        //
        // Computes the layout of the item's image and text.
        // Draws the item's background image.
        // Draws the item's image.
        // Draws the item's text.
        //
        // Drawing operations are implemented in the 
        // RolloverItemRenderer class.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Owner != null)
            {
                // Find the dimensions of the image and the text 
                // areas of the item. 
                this.ComputeImageAndTextLayout();

                // Draw the background. This includes drawing a highlighted 
                // border when the mouse is in the client area.
                ToolStripItemRenderEventArgs ea = new ToolStripItemRenderEventArgs(
                     e.Graphics,
                     this);
                this.Owner.Renderer.DrawItemBackground(ea);

                // Draw the item's image. 
                ToolStripItemImageRenderEventArgs irea =
                    new ToolStripItemImageRenderEventArgs(
                    e.Graphics,
                    this,
                    imageRect);
                this.Owner.Renderer.DrawItemImage(irea);

                // If the item is on a drop-down, give its
                // text a different highlighted color.
                Color highlightColor =
                    this.IsOnDropDown ?
                    Color.Salmon : SystemColors.ControlLightLight;

                // Draw the text, and highlight it if the 
                // the rollover state is true.
                ToolStripItemTextRenderEventArgs rea =
                    new ToolStripItemTextRenderEventArgs(
                    e.Graphics,
                    this,
                    base.Text,
                    textRect,
                    this.rolloverValue ? highlightColor : base.ForeColor,
                    base.Font,
                    base.TextAlign);
                this.Owner.Renderer.DrawItemText(rea);
            }
        }

        // This utility method computes the layout of the 
        // RolloverItem control's image area and the text area.
        // For brevity, only the following settings are 
        // supported:
        //
        // ToolStripTextDirection.Horizontal
        // TextImageRelation.ImageBeforeText 
        // TextImageRelation.ImageBeforeText
        // 
        // It would not be difficult to support vertical text
        // directions and other image/text relationships.
        private void ComputeImageAndTextLayout()
        {
            Rectangle cr = base.ContentRectangle;
            Image img = base.Owner?.ImageList?.Images[base.ImageKey];
            if (img == null)
            {
                return;
            }

            // Compute the center of the item's ContentRectangle.
            int centerY = (cr.Height - img.Height) / 2;

            // Find the dimensions of the image and the text 
            // areas of the item. The text occupies the space 
            // not filled by the image. 
            if (base.TextImageRelation == TextImageRelation.ImageBeforeText &&
                base.TextDirection == ToolStripTextDirection.Horizontal)
            {
                imageRect = new Rectangle(
                    base.ContentRectangle.Left,
                    centerY,
                    base.Image.Width,
                    base.Image.Height);

                textRect = new Rectangle(
                    imageRect.Width,
                    base.ContentRectangle.Top,
                    base.ContentRectangle.Width - imageRect.Width,
                    base.ContentRectangle.Height);
            }
            else if (base.TextImageRelation == TextImageRelation.TextBeforeImage &&
                     base.TextDirection == ToolStripTextDirection.Horizontal)
            {
                imageRect = new Rectangle(
                    base.ContentRectangle.Right - base.Image.Width,
                    centerY,
                    base.Image.Width,
                    base.Image.Height);

                textRect = new Rectangle(
                    base.ContentRectangle.Left,
                    base.ContentRectangle.Top,
                    imageRect.X,
                    base.ContentRectangle.Bottom);
            }
        }
    }

    #region RolloverItemRenderer

    // This is the custom renderer for the RolloverItem control.
    // It draws a border around the item when the mouse is
    // in the item's client area. It also draws the item's image
    // in an inactive state (grayed out) until the user clicks
    // the item to toggle its "clicked" state.
    internal class RolloverItemRenderer : ToolStripSystemRenderer
    {
        protected override void OnRenderItemImage(
            ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemImage(e);

            RolloverItem item = e.Item as RolloverItem;

            // If the ToolSTripItem is of type RolloverItem, 
            // perform custom rendering for the image.
            if (item != null)
            {
                if (item.Clicked)
                {
                    // The item is in the clicked state, so 
                    // draw the image as usual.
                    e.Graphics.DrawImage(
                        e.Image,
                        e.ImageRectangle.X,
                        e.ImageRectangle.Y);
                }
                else
                {
                    // In the unclicked state, gray out the image.
                    ControlPaint.DrawImageDisabled(
                        e.Graphics,
                        e.Image,
                        e.ImageRectangle.X,
                        e.ImageRectangle.Y,
                        item.BackColor);
                }
            }
        }

        // This method defines the behavior for rendering the
        // background of a ToolStripItem. If the item is a
        // RolloverItem, it paints the item's BackgroundImage 
        // centered in the client area. If the mouse is in the 
        // item's client area, a border is drawn around it.
        // If the item is on a drop-down or if it is on the
        // overflow, a gradient is painted in the background.
        protected override void OnRenderItemBackground(
            ToolStripItemRenderEventArgs e)
        {
            base.OnRenderItemBackground(e);

            RolloverItem item = e.Item as RolloverItem;

            // If the ToolSTripItem is of type RolloverItem, 
            // perform custom rendering for the background.
            if (item != null)
            {
                if (item.Placement == ToolStripItemPlacement.Overflow ||
                    item.IsOnDropDown)
                {
                    using (LinearGradientBrush b = new LinearGradientBrush(
                        item.ContentRectangle,
                        Color.Salmon,
                        Color.DarkRed,
                        0f,
                        false))
                    {
                        e.Graphics.FillRectangle(b, item.ContentRectangle);
                    }
                }

                // The RolloverItem control only supports 
                // the ImageLayout.Center setting for the
                // BackgroundImage property.
                if (item.BackgroundImageLayout == ImageLayout.Center)
                {
                    // Get references to the item's ContentRectangle
                    // and BackgroundImage, for convenience.
                    Rectangle cr = item.ContentRectangle;
                    Image bgi = item.BackgroundImage;

                    // Compute the center of the item's ContentRectangle.
                    int centerX = (cr.Width - bgi.Width) / 2;
                    int centerY = (cr.Height - bgi.Height) / 2;

                    // If the item is selected, draw the background
                    // image as usual. Otherwise, draw it as disabled.
                    if (item.Selected)
                    {
                        e.Graphics.DrawImage(bgi, centerX, centerY);
                    }
                    else
                    {
                        ControlPaint.DrawImageDisabled(
                                e.Graphics,
                                bgi,
                                centerX,
                                centerY,
                                item.BackColor);
                    }
                }

                // If the item is in the rollover state, 
                // draw a border around it.
                if (item.Rollover)
                {
                    ControlPaint.DrawFocusRectangle(
                        e.Graphics,
                        item.ContentRectangle);
                }
            }
        }

        #endregion

    }
}
