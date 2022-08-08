namespace Daily_log
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchStrBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.allSearchButton = new System.Windows.Forms.Button();
            this.oneDaySearchButton = new System.Windows.Forms.Button();
            this.selectionSearchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchStrBox
            // 
            this.searchStrBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchStrBox.Location = new System.Drawing.Point(83, 12);
            this.searchStrBox.Name = "searchStrBox";
            this.searchStrBox.Size = new System.Drawing.Size(348, 19);
            this.searchStrBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "検索文字列";
            // 
            // allSearchButton
            // 
            this.allSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.allSearchButton.Location = new System.Drawing.Point(342, 37);
            this.allSearchButton.Name = "allSearchButton";
            this.allSearchButton.Size = new System.Drawing.Size(89, 23);
            this.allSearchButton.TabIndex = 5;
            this.allSearchButton.Text = "全体の検索";
            this.allSearchButton.UseVisualStyleBackColor = true;
            this.allSearchButton.Click += new System.EventHandler(this.allSearchButton_Click);
            // 
            // oneDaySearchButton
            // 
            this.oneDaySearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.oneDaySearchButton.Location = new System.Drawing.Point(206, 37);
            this.oneDaySearchButton.Name = "oneDaySearchButton";
            this.oneDaySearchButton.Size = new System.Drawing.Size(130, 23);
            this.oneDaySearchButton.TabIndex = 6;
            this.oneDaySearchButton.Text = "同じ日付けから検索";
            this.oneDaySearchButton.UseVisualStyleBackColor = true;
            this.oneDaySearchButton.Click += new System.EventHandler(this.oneDaySearchButton_Click);
            // 
            // selectionSearchButton
            // 
            this.selectionSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectionSearchButton.Location = new System.Drawing.Point(83, 37);
            this.selectionSearchButton.Name = "selectionSearchButton";
            this.selectionSearchButton.Size = new System.Drawing.Size(117, 23);
            this.selectionSearchButton.TabIndex = 7;
            this.selectionSearchButton.Text = "選択範囲を検索";
            this.selectionSearchButton.UseVisualStyleBackColor = true;
            this.selectionSearchButton.Click += new System.EventHandler(this.selectionSearchButton_Click);
            // 
            // SearchForm
            // 
            this.AcceptButton = this.allSearchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 75);
            this.Controls.Add(this.selectionSearchButton);
            this.Controls.Add(this.oneDaySearchButton);
            this.Controls.Add(this.allSearchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchStrBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "検索";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchStrBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button allSearchButton;
        private System.Windows.Forms.Button oneDaySearchButton;
        private System.Windows.Forms.Button selectionSearchButton;
    }
}