namespace MASAGooGLExtractor
{
	// Token: 0x02000023 RID: 35
	public partial class UploadLocationsForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600012B RID: 299 RVA: 0x0001370A File Offset: 0x0001190A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0001372C File Offset: 0x0001192C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::MASAGooGLExtractor.UploadLocationsForm));
			this.label2 = new global::System.Windows.Forms.Label();
			this.tbUploadLocations = new global::System.Windows.Forms.TextBox();
			this.btnLoadFile = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnApply = new global::System.Windows.Forms.Button();
			this.label3 = new global::System.Windows.Forms.Label();
			this.tbCountry = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(12, 85);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(56, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Locations:";
			this.tbUploadLocations.Location = new global::System.Drawing.Point(15, 101);
			this.tbUploadLocations.Multiline = true;
			this.tbUploadLocations.Name = "tbUploadLocations";
			this.tbUploadLocations.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.tbUploadLocations.Size = new global::System.Drawing.Size(457, 129);
			this.tbUploadLocations.TabIndex = 14;
			this.btnLoadFile.Location = new global::System.Drawing.Point(397, 60);
			this.btnLoadFile.Name = "btnLoadFile";
			this.btnLoadFile.Size = new global::System.Drawing.Size(75, 23);
			this.btnLoadFile.TabIndex = 13;
			this.btnLoadFile.Text = "Upload file";
			this.btnLoadFile.UseVisualStyleBackColor = true;
			this.btnLoadFile.Click += new global::System.EventHandler(this.btnLoadFile_Click);
			this.label1.Location = new global::System.Drawing.Point(12, 10);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(460, 47);
			this.label1.TabIndex = 12;
			this.label1.Text = resources.GetString("label1.Text");
			this.btnCancel.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnCancel.Image = (global::System.Drawing.Image)resources.GetObject("MASAGooGLExtractor.btnCancel.Image");
			this.btnCancel.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancel.Location = new global::System.Drawing.Point(405, 236);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(67, 23);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnApply.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnApply.Image = (global::System.Drawing.Image)resources.GetObject("MASAGooGLExtractor.btnApply.Image");
			this.btnApply.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnApply.Location = new global::System.Drawing.Point(349, 236);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new global::System.Drawing.Size(50, 23);
			this.btnApply.TabIndex = 10;
			this.btnApply.Text = "Ok";
			this.btnApply.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new global::System.EventHandler(this.btnApply_Click);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(12, 65);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(46, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Country:";
			this.tbCountry.Location = new global::System.Drawing.Point(64, 62);
			this.tbCountry.Name = "tbCountry";
			this.tbCountry.Size = new global::System.Drawing.Size(180, 20);
			this.tbCountry.TabIndex = 17;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(484, 261);
			base.Controls.Add(this.tbCountry);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.tbUploadLocations);
			base.Controls.Add(this.btnLoadFile);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnApply);
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("MASAGooGLExtractor.$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "UploadLocationsForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Upload locations";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400015A RID: 346
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400015B RID: 347
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400015C RID: 348
		public global::System.Windows.Forms.TextBox tbUploadLocations;

		// Token: 0x0400015D RID: 349
		private global::System.Windows.Forms.Button btnLoadFile;

		// Token: 0x0400015E RID: 350
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400015F RID: 351
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000160 RID: 352
		private global::System.Windows.Forms.Button btnApply;

		// Token: 0x04000161 RID: 353
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000162 RID: 354
		public global::System.Windows.Forms.TextBox tbCountry;
	}
}
