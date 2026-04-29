namespace Laro
{
    partial class frmLec5
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLec5));
        	this.lblMonitor = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// lblMonitor
        	// 
        	this.lblMonitor.BackColor = System.Drawing.Color.Transparent;
        	this.lblMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.lblMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.lblMonitor.Location = new System.Drawing.Point(657, 287);
        	this.lblMonitor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.lblMonitor.Name = "lblMonitor";
        	this.lblMonitor.Size = new System.Drawing.Size(240, 51);
        	this.lblMonitor.TabIndex = 2;
        	// 
        	// label2
        	// 
        	this.label2.BackColor = System.Drawing.Color.Transparent;
        	this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.label2.Location = new System.Drawing.Point(811, 89);
        	this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(114, 119);
        	this.label2.TabIndex = 2;
        	this.label2.Click += new System.EventHandler(this.label2_Click);
        	// 
        	// frmLec5
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
        	this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        	this.ClientSize = new System.Drawing.Size(946, 547);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.lblMonitor);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "frmLec5";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Form5";
        	this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMonitor;
        private System.Windows.Forms.Label label2;

    }
}