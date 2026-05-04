namespace Laro
{
    partial class frmLec4
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
        	this.label2 = new System.Windows.Forms.Label();
        	this.lblClue = new System.Windows.Forms.Label();
        	this.lblBoard = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// label2
        	// 
        	this.label2.BackColor = System.Drawing.Color.Transparent;
        	this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.label2.Location = new System.Drawing.Point(810, 131);
        	this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(55, 218);
        	this.label2.TabIndex = 1;
        	this.label2.Click += new System.EventHandler(this.label2_Click);
        	// 
        	// lblClue
        	// 
        	this.lblClue.BackColor = System.Drawing.Color.Transparent;
        	this.lblClue.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.lblClue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.lblClue.Location = new System.Drawing.Point(354, 431);
        	this.lblClue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.lblClue.Name = "lblClue";
        	this.lblClue.Size = new System.Drawing.Size(64, 62);
        	this.lblClue.TabIndex = 1;
        	this.lblClue.Click += new System.EventHandler(this.lblClue_Click);
        	// 
        	// lblBoard
        	// 
        	this.lblBoard.BackColor = System.Drawing.Color.Transparent;
        	this.lblBoard.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.lblBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.lblBoard.Location = new System.Drawing.Point(382, 145);
        	this.lblBoard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.lblBoard.Name = "lblBoard";
        	this.lblBoard.Size = new System.Drawing.Size(249, 116);
        	this.lblBoard.TabIndex = 1;
        	this.lblBoard.Click += new System.EventHandler(this.LblBoardClick);
        	// 
        	// frmLec4
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackgroundImage = global::Laro.Properties.Resources.LEC_4;
        	this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        	this.ClientSize = new System.Drawing.Size(961, 568);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.lblClue);
        	this.Controls.Add(this.lblBoard);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        	this.Name = "frmLec4";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Form4";
        	this.Load += new System.EventHandler(this.Form4Load);
        	this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBoard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblClue;
    }
}