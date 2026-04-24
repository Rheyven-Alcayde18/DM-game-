/*
 * Created by SharpDevelop.
 * User: CJ
 * Date: 4/24/2026
 * Time: 6:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Laro
{
	partial class Form1
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button BckBtn;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.BckBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// BckBtn
			// 
			this.BckBtn.Location = new System.Drawing.Point(13, 13);
			this.BckBtn.Name = "BckBtn";
			this.BckBtn.Size = new System.Drawing.Size(190, 54);
			this.BckBtn.TabIndex = 0;
			this.BckBtn.Text = "BACK";
			this.BckBtn.UseVisualStyleBackColor = true;
			this.BckBtn.Click += new System.EventHandler(this.BckBtnClick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1369, 667);
			this.Controls.Add(this.BckBtn);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
	}
}
