namespace MASAGooGLExtractor
{
	// Token: 0x02000018 RID: 24
	public partial class LocationEditForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000097 RID: 151 RVA: 0x000089CB File Offset: 0x00006BCB
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000089EC File Offset: 0x00006BEC
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::MASAGooGLExtractor.LocationEditForm));
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnApply = new global::System.Windows.Forms.Button();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.cbCountry = new global::System.Windows.Forms.ComboBox();
			this.cbState = new global::System.Windows.Forms.ComboBox();
			this.cbCity = new global::System.Windows.Forms.ComboBox();
			this.clbStates = new global::System.Windows.Forms.CheckedListBox();
			this.btnSelectAll = new global::System.Windows.Forms.Button();
			this.btnClearAll = new global::System.Windows.Forms.Button();
			this.cbZipCodes = new global::System.Windows.Forms.ComboBox();
			this.label8 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(80, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select location:";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(12, 93);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(121, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Or select multiple states:";
			this.btnCancel.Image = (global::System.Drawing.Image)resources.GetObject("MASAGooGLExtractor.btnCancel.Image");
			this.btnCancel.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancel.Location = new global::System.Drawing.Point(405, 276);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(67, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnApply.Image = (global::System.Drawing.Image)resources.GetObject("MASAGooGLExtractor.btnApply.Image");
			this.btnApply.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnApply.Location = new global::System.Drawing.Point(349, 276);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new global::System.Drawing.Size(50, 23);
			this.btnApply.TabIndex = 5;
			this.btnApply.Text = "Ok";
			this.btnApply.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new global::System.EventHandler(this.btnApply_Click);
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(12, 34);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(46, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Country:";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(254, 34);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(35, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "State:";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(12, 61);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(27, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "City:";
			this.cbCountry.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbCountry.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbCountry.FormattingEnabled = true;
			this.cbCountry.Location = new global::System.Drawing.Point(59, 31);
			this.cbCountry.Name = "cbCountry";
			this.cbCountry.Size = new global::System.Drawing.Size(160, 21);
			this.cbCountry.TabIndex = 10;
			this.cbCountry.SelectedIndexChanged += new global::System.EventHandler(this.cbCountry_SelectedIndexChanged);
			this.cbState.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbState.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbState.FormattingEnabled = true;
			this.cbState.Location = new global::System.Drawing.Point(312, 31);
			this.cbState.Name = "cbState";
			this.cbState.Size = new global::System.Drawing.Size(160, 21);
			this.cbState.TabIndex = 11;
			this.cbState.SelectedIndexChanged += new global::System.EventHandler(this.cbState_SelectedIndexChanged);
			this.cbCity.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbCity.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbCity.FormattingEnabled = true;
			this.cbCity.Location = new global::System.Drawing.Point(59, 58);
			this.cbCity.Name = "cbCity";
			this.cbCity.Size = new global::System.Drawing.Size(160, 21);
			this.cbCity.TabIndex = 12;
			this.cbCity.SelectedIndexChanged += new global::System.EventHandler(this.cbCity_SelectedIndexChanged);
			this.clbStates.FormattingEnabled = true;
			this.clbStates.Location = new global::System.Drawing.Point(15, 109);
			this.clbStates.MultiColumn = true;
			this.clbStates.Name = "clbStates";
			this.clbStates.Size = new global::System.Drawing.Size(457, 154);
			this.clbStates.TabIndex = 13;
			this.btnSelectAll.Location = new global::System.Drawing.Point(15, 276);
			this.btnSelectAll.Name = "btnSelectAll";
			this.btnSelectAll.Size = new global::System.Drawing.Size(75, 23);
			this.btnSelectAll.TabIndex = 14;
			this.btnSelectAll.Text = "Select all";
			this.btnSelectAll.UseVisualStyleBackColor = true;
			this.btnSelectAll.Click += new global::System.EventHandler(this.btnSelectAll_Click);
			this.btnClearAll.Location = new global::System.Drawing.Point(96, 276);
			this.btnClearAll.Name = "btnClearAll";
			this.btnClearAll.Size = new global::System.Drawing.Size(75, 23);
			this.btnClearAll.TabIndex = 15;
			this.btnClearAll.Text = "Clear all";
			this.btnClearAll.UseVisualStyleBackColor = true;
			this.btnClearAll.Click += new global::System.EventHandler(this.btnClearAll_Click);
			this.cbZipCodes.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbZipCodes.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbZipCodes.FormattingEnabled = true;
			this.cbZipCodes.Location = new global::System.Drawing.Point(312, 58);
			this.cbZipCodes.Name = "cbZipCodes";
			this.cbZipCodes.Size = new global::System.Drawing.Size(160, 21);
			this.cbZipCodes.TabIndex = 17;
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(254, 61);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(52, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "Zip code:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(484, 311);
			base.Controls.Add(this.cbZipCodes);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.btnClearAll);
			base.Controls.Add(this.btnSelectAll);
			base.Controls.Add(this.clbStates);
			base.Controls.Add(this.cbCity);
			base.Controls.Add(this.cbState);
			base.Controls.Add(this.cbCountry);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnApply);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("MASAGooGLExtractor.$this.Icon");
			base.Name = "LocationEditForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Location";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400006D RID: 109
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400006E RID: 110
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400006F RID: 111
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000070 RID: 112
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000071 RID: 113
		private global::System.Windows.Forms.Button btnApply;

		// Token: 0x04000072 RID: 114
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000073 RID: 115
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000075 RID: 117
		public global::System.Windows.Forms.ComboBox cbCountry;

		// Token: 0x04000076 RID: 118
		public global::System.Windows.Forms.ComboBox cbState;

		// Token: 0x04000077 RID: 119
		public global::System.Windows.Forms.ComboBox cbCity;

		// Token: 0x04000078 RID: 120
		public global::System.Windows.Forms.ComboBox cbZipCodes;

		// Token: 0x04000079 RID: 121
		public global::System.Windows.Forms.CheckedListBox clbStates;

		// Token: 0x0400007A RID: 122
		private global::System.Windows.Forms.Button btnSelectAll;

		// Token: 0x0400007B RID: 123
		private global::System.Windows.Forms.Button btnClearAll;

		// Token: 0x0400007C RID: 124
		private global::System.Windows.Forms.Label label8;
	}
}
