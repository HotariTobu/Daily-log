using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daily_log
{
    // This form tests various features of the RolloverItem
    // control. RolloverItem conrols are created and added
    // to the form's ToolStrip. They are also created and 
    // added to a button's ContextMenuStrip. The behavior
    // of the RolloverItem control differs depending on 
    // the type of parent control.
    public class TestForm : Form
    {
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button button1;

        private string infoIconKey = "Information icon";
        private string handIconKey = "Hand icon";
        private string exclIconKey = "Exclamation icon";
        private string questionIconKey = "Question icon";
        private string warningIconKey = "Warning icon ";

        private System.ComponentModel.IContainer components = null;

        public TestForm()
        {
            InitializeComponent();

            // Set up the form's ToolStrip control.
            InitializeToolStrip();

            // Set up the ContextMenuStrip for the button.
            InitializeContextMenu();
        }

        // This utility method initializes the ToolStrip control's 
        // image list. For convenience, icons from the SystemIcons 
        // class are used for this demonstration, but any images
        // could be used.
        private void InitializeImageList(ToolStrip ts)
        {
            if (ts.ImageList == null)
            {
                ts.ImageList = new ImageList();
                ts.ImageList.ImageSize = SystemIcons.Exclamation.Size;

                ts.ImageList.Images.Add(
                    this.infoIconKey,
                    SystemIcons.Information);

                ts.ImageList.Images.Add(
                    this.handIconKey,
                    SystemIcons.Hand);

                ts.ImageList.Images.Add(
                    this.exclIconKey,
                    SystemIcons.Exclamation);

                ts.ImageList.Images.Add(
                    this.questionIconKey,
                    SystemIcons.Question);

                ts.ImageList.Images.Add(
                    this.warningIconKey,
                    SystemIcons.Warning);
            }
        }

        private void InitializeToolStrip()
        {
            this.InitializeImageList(this.toolStrip1);

            this.toolStrip1.Renderer = new RolloverItemRenderer();

            RolloverItem item = this.CreateRolloverItem(
                this.toolStrip1,
                "RolloverItem on ToolStrip",
                this.Font,
                infoIconKey,
                TextImageRelation.ImageBeforeText,
                exclIconKey);

            this.toolStrip1.Items.Add(item);

            item = this.CreateRolloverItem(
                this.toolStrip1,
                "RolloverItem on ToolStrip",
                this.Font,
                infoIconKey,
                TextImageRelation.ImageBeforeText,
                exclIconKey);

            this.toolStrip1.Items.Add(item);
        }

        private void InitializeContextMenu()
        {
            Font f = new System.Drawing.Font(
                "Arial",
                18f,
                FontStyle.Bold);

            ContextMenuStrip cms = new ContextMenuStrip();
            this.InitializeImageList(cms);

            cms.Renderer = new RolloverItemRenderer();
            cms.AutoSize = true;
            cms.ShowCheckMargin = false;
            cms.ShowImageMargin = false;

            RolloverItem item = this.CreateRolloverItem(
                cms,
                "RolloverItem on ContextMenuStrip",
                f,
                handIconKey,
                TextImageRelation.ImageBeforeText,
                exclIconKey);

            cms.Items.Add(item);

            item = this.CreateRolloverItem(
                cms,
                "Another RolloverItem on ContextMenuStrip",
                f,
                questionIconKey,
                TextImageRelation.ImageBeforeText,
                exclIconKey);

            cms.Items.Add(item);

            item = this.CreateRolloverItem(
                cms,
                "And another RolloverItem on ContextMenuStrip",
                f,
                warningIconKey,
                TextImageRelation.ImageBeforeText,
                exclIconKey);

            cms.Items.Add(item);

            cms.Closing += new ToolStripDropDownClosingEventHandler(cms_Closing);

            this.button1.ContextMenuStrip = cms;
        }

        // This method handles the ContextMenuStrip 
        // control's Closing event. It prevents the 
        // RolloverItem from closing the drop-down  
        // when the item is clicked.
        void cms_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }

        // This method handles the Click event for the button.
        // it selects the first item in the ToolStrip control
        // by using the ToolStripITem.Select method.
        private void button1_Click(object sender, EventArgs e)
        {
            RolloverItem item = this.toolStrip1.Items[0] as RolloverItem;

            if (item != null)
            {
                item.Select();

                this.Invalidate();
            }
        }

        // This utility method creates a RolloverItem 
        // and adds it to a ToolStrip control.
        private RolloverItem CreateRolloverItem(
            ToolStrip owningToolStrip,
            string txt,
            Font f,
            string imgKey,
            TextImageRelation tir,
            string backImgKey)
        {
            RolloverItem item = new RolloverItem();

            item.Alignment = ToolStripItemAlignment.Left;
            item.AllowDrop = false;
            item.AutoSize = true;

            item.BackgroundImage = owningToolStrip.ImageList.Images[backImgKey];
            item.BackgroundImageLayout = ImageLayout.Center;
            item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            item.DoubleClickEnabled = true;
            item.Enabled = true;
            item.Font = f;

            // These assignments are equivalent. Each assigns an
            // image from the owning toolstrip's image list.
            item.ImageKey = imgKey;
            //item.Image = owningToolStrip.ImageList.Images[infoIconKey];
            //item.ImageIndex = owningToolStrip.ImageList.Images.IndexOfKey(infoIconKey);
            item.ImageScaling = ToolStripItemImageScaling.None;

            item.Owner = owningToolStrip;
            item.Padding = new Padding(2);
            item.Text = txt;
            item.TextAlign = ContentAlignment.MiddleLeft;
            item.TextDirection = ToolStripTextDirection.Horizontal;
            item.TextImageRelation = tir;

            return item;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(845, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Click to select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RolloverItemTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(845, 282);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RolloverItemTestForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
