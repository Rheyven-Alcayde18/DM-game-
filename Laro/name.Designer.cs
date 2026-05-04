/*
 * Created by SharpDevelop.
 * User: CJ
 * Date: 5/4/2026
 * Time: 4:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Laro
{
	partial class frmName
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.Label label1;
		
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
			this.button1 = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(221)))));
			this.button1.Location = new System.Drawing.Point(1185, 2);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(52, 43);
			this.button1.TabIndex = 5;
			this.button1.Text = "-";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(221)))));
			this.btnClose.Location = new System.Drawing.Point(1242, 2);
			this.btnClose.Margin = new System.Windows.Forms.Padding(2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(52, 43);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "X";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Location = new System.Drawing.Point(2, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1303, 48);
			this.panel1.TabIndex = 8;
			// 
			// txtName
			// 
			this.txtName.AllowDrop = true;
			this.txtName.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtName.Location = new System.Drawing.Point(418, 369);
			this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtName.Multiline = true;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(373, 40);
			this.txtName.TabIndex = 9;
			// 
			// btnSubmit
			// 
			this.btnSubmit.BackColor = System.Drawing.Color.Lime;
			this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSubmit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSubmit.Location = new System.Drawing.Point(559, 410);
			this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(87, 28);
			this.btnSubmit.TabIndex = 10;
			this.btnSubmit.Text = "Confirm";
			this.btnSubmit.UseVisualStyleBackColor = false;
			this.btnSubmit.Click += new System.EventHandler(this.BtnSubmitClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.label1.Location = new System.Drawing.Point(418, 342);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(300, 23);
			this.label1.TabIndex = 11;
			this.label1.Text = "Enter character name:";
			this.label1.Click += new System.EventHandler(this.Label1Click);
			// 
			// frmName
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
			this.ClientSize = new System.Drawing.Size(1302, 821);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSubmit);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "frmName";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "name";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
