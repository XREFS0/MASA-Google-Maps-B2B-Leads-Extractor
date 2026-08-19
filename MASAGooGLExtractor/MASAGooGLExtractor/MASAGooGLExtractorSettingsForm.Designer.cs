namespace MASAGooGLExtractor
{
	// Token: 0x02000020 RID: 32
	public partial class SettingsForm : global::ComponentFactory.Krypton.Toolkit.KryptonForm
	{
		// Token: 0x0600011E RID: 286 RVA: 0x000113CC File Offset: 0x0000F5CC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000113EC File Offset: 0x0000F5EC
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::MASAGooGLExtractor.SettingsForm));
			this.tabControl = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.cbAutoRestart = new global::System.Windows.Forms.CheckBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.numthreads = new global::System.Windows.Forms.NumericUpDown();
			this.button1 = new global::System.Windows.Forms.Button();
			this.tbNumberOfResultsPerZipCode = new global::System.Windows.Forms.TextBox();
			this.label13 = new global::System.Windows.Forms.Label();
			this.cbLanguage = new global::System.Windows.Forms.ComboBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.cbExtractEmails = new global::System.Windows.Forms.CheckBox();
			this.cbCSVEncoding = new global::System.Windows.Forms.ComboBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.cbCSVDelimiter = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.cbExportType = new global::System.Windows.Forms.ComboBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.btnChooseExportFolder = new global::System.Windows.Forms.Button();
			this.tbExportPath = new global::System.Windows.Forms.TextBox();
			this.rbAutoExport = new global::System.Windows.Forms.RadioButton();
			this.rbManualExport = new global::System.Windows.Forms.RadioButton();
			this.cblExport = new global::System.Windows.Forms.CheckedListBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.numericUpDown1 = new global::System.Windows.Forms.NumericUpDown();
			this.tbDelayTo = new global::System.Windows.Forms.TrackBar();
			this.tbDelayFrom = new global::System.Windows.Forms.TrackBar();
			this.label12 = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.cbRandomDelay = new global::System.Windows.Forms.CheckBox();
			this.rbUseVPN = new global::System.Windows.Forms.RadioButton();
			this.tbProxyAuthPassword = new global::System.Windows.Forms.TextBox();
			this.tbProxyAuthUsername = new global::System.Windows.Forms.TextBox();
			this.tbFreeProxiesList = new global::System.Windows.Forms.TextBox();
			this.tbRandomProxyList = new global::System.Windows.Forms.TextBox();
			this.cbAuthentification = new global::System.Windows.Forms.CheckBox();
			this.tbProxyServerPort = new global::System.Windows.Forms.TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.tbProxyServerIP = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.rbFreeProxiesList = new global::System.Windows.Forms.RadioButton();
			this.rbRundomProxyList = new global::System.Windows.Forms.RadioButton();
			this.rbUseSingleProxy = new global::System.Windows.Forms.RadioButton();
			this.rbNoProxy = new global::System.Windows.Forms.RadioButton();
			this.btnOk = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.panel = new global::System.Windows.Forms.Panel();
			this.toolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.toolTip2 = new global::System.Windows.Forms.ToolTip(this.components);
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numthreads).BeginInit();
			this.tabPage2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.tbDelayTo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.tbDelayFrom).BeginInit();
			this.panel.SuspendLayout();
			base.SuspendLayout();
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new global::System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new global::System.Drawing.Size(584, 315);
			this.tabControl.TabIndex = 0;
			this.tabPage1.Controls.Add(this.cbAutoRestart);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.numthreads);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.tbNumberOfResultsPerZipCode);
			this.tabPage1.Controls.Add(this.label13);
			this.tabPage1.Controls.Add(this.cbLanguage);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.cbExtractEmails);
			this.tabPage1.Controls.Add(this.cbCSVEncoding);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.cbCSVDelimiter);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.cbExportType);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.btnChooseExportFolder);
			this.tabPage1.Controls.Add(this.tbExportPath);
			this.tabPage1.Controls.Add(this.rbAutoExport);
			this.tabPage1.Controls.Add(this.rbManualExport);
			this.tabPage1.Controls.Add(this.cblExport);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(576, 289);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Data";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.cbAutoRestart.AutoSize = true;
			this.cbAutoRestart.ForeColor = global::System.Drawing.Color.FromArgb(0, 128, 128);
			this.cbAutoRestart.Location = new global::System.Drawing.Point(151, 193);
			this.cbAutoRestart.Name = "cbAutoRestart";
			this.cbAutoRestart.Size = new global::System.Drawing.Size(134, 17);
			this.cbAutoRestart.TabIndex = 23;
			this.cbAutoRestart.Text = "Auto Restart and Scan";
			this.cbAutoRestart.UseVisualStyleBackColor = true;
			this.cbAutoRestart.CheckedChanged += new global::System.EventHandler(this.cbAutoRestart_CheckedChanged);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(416, 187);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(46, 13);
			this.label1.TabIndex = 22;
			this.label1.Text = "Threads";
			this.numthreads.Location = new global::System.Drawing.Point(475, 183);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numthreads;
			int[] array = new int[4];
			array[0] = 5;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numthreads;
			int[] array2 = new int[4];
			array2[0] = 1;
			numericUpDown2.Minimum = new decimal(array2);
			this.numthreads.Name = "numthreads";
			this.numthreads.Size = new global::System.Drawing.Size(47, 20);
			this.numthreads.TabIndex = 21;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numthreads;
			int[] array3 = new int[4];
			array3[0] = 4;
			numericUpDown3.Value = new decimal(array3);
			this.numthreads.ValueChanged += new global::System.EventHandler(this.numthreads_ValueChanged);
			this.button1.Location = new global::System.Drawing.Point(27, 187);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(108, 23);
			this.button1.TabIndex = 19;
			this.button1.Text = "Auto Export Folder";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.tbNumberOfResultsPerZipCode.Location = new global::System.Drawing.Point(475, 156);
			this.tbNumberOfResultsPerZipCode.Name = "tbNumberOfResultsPerZipCode";
			this.tbNumberOfResultsPerZipCode.Size = new global::System.Drawing.Size(74, 20);
			this.tbNumberOfResultsPerZipCode.TabIndex = 18;
			this.label13.AutoSize = true;
			this.label13.Location = new global::System.Drawing.Point(288, 159);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(174, 13);
			this.label13.TabIndex = 17;
			this.label13.Text = "Number of results for each zip code";
			this.cbLanguage.FormattingEnabled = true;
			this.cbLanguage.Items.AddRange(new object[] { "English", "Italian", "German", "French", "Spain" });
			this.cbLanguage.Location = new global::System.Drawing.Point(126, 11);
			this.cbLanguage.Name = "cbLanguage";
			this.cbLanguage.Size = new global::System.Drawing.Size(159, 21);
			this.cbLanguage.TabIndex = 16;
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(24, 14);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(96, 13);
			this.label10.TabIndex = 15;
			this.label10.Text = "Interface language";
			this.cbExtractEmails.AutoSize = true;
			this.cbExtractEmails.Location = new global::System.Drawing.Point(27, 158);
			this.cbExtractEmails.Name = "cbExtractEmails";
			this.cbExtractEmails.Size = new global::System.Drawing.Size(208, 17);
			this.cbExtractEmails.TabIndex = 14;
			this.cbExtractEmails.Text = "Extract email from website (slower app)";
			this.cbExtractEmails.UseVisualStyleBackColor = true;
			this.cbCSVEncoding.FormattingEnabled = true;
			this.cbCSVEncoding.Items.AddRange(new object[] { "ASCII", "UTF7", "UTF8" });
			this.cbCSVEncoding.Location = new global::System.Drawing.Point(428, 255);
			this.cbCSVEncoding.Name = "cbCSVEncoding";
			this.cbCSVEncoding.Size = new global::System.Drawing.Size(121, 21);
			this.cbCSVEncoding.TabIndex = 13;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(370, 258);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(52, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Encoding";
			this.cbCSVDelimiter.FormattingEnabled = true;
			this.cbCSVDelimiter.Items.AddRange(new object[] { ", - comma (for USA)", "; - semicolon (for Europe)" });
			this.cbCSVDelimiter.Location = new global::System.Drawing.Point(180, 255);
			this.cbCSVDelimiter.Name = "cbCSVDelimiter";
			this.cbCSVDelimiter.Size = new global::System.Drawing.Size(186, 21);
			this.cbCSVDelimiter.TabIndex = 11;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(24, 258);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(133, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "CSV file columns separator";
			this.cbExportType.FormattingEnabled = true;
			this.cbExportType.Items.AddRange(new object[] { "CSV (comma separated file)", "Microsoft Excel File" });
			this.cbExportType.Location = new global::System.Drawing.Point(180, 224);
			this.cbExportType.Name = "cbExportType";
			this.cbExportType.Size = new global::System.Drawing.Size(186, 21);
			this.cbExportType.TabIndex = 9;
			this.cbExportType.SelectedIndexChanged += new global::System.EventHandler(this.cbExportType_SelectedIndexChanged);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(24, 227);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(150, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "File format for data export data";
			this.btnChooseExportFolder.Enabled = false;
			this.btnChooseExportFolder.Location = new global::System.Drawing.Point(291, 44);
			this.btnChooseExportFolder.Name = "btnChooseExportFolder";
			this.btnChooseExportFolder.Size = new global::System.Drawing.Size(75, 23);
			this.btnChooseExportFolder.TabIndex = 7;
			this.btnChooseExportFolder.Text = "Choose";
			this.btnChooseExportFolder.UseVisualStyleBackColor = true;
			this.btnChooseExportFolder.Visible = false;
			this.btnChooseExportFolder.Click += new global::System.EventHandler(this.btnChooseExportFolder_Click);
			this.tbExportPath.Location = new global::System.Drawing.Point(439, 12);
			this.tbExportPath.Name = "tbExportPath";
			this.tbExportPath.Size = new global::System.Drawing.Size(129, 20);
			this.tbExportPath.TabIndex = 6;
			this.tbExportPath.Visible = false;
			this.rbAutoExport.AutoSize = true;
			this.rbAutoExport.Location = new global::System.Drawing.Point(320, 6);
			this.rbAutoExport.Name = "rbAutoExport";
			this.rbAutoExport.Size = new global::System.Drawing.Size(202, 17);
			this.rbAutoExport.TabIndex = 5;
			this.rbAutoExport.TabStop = true;
			this.rbAutoExport.Text = "Export results automatically to a folder";
			this.rbAutoExport.UseVisualStyleBackColor = true;
			this.rbAutoExport.Visible = false;
			this.rbAutoExport.CheckedChanged += new global::System.EventHandler(this.rbAutoExport_CheckedChanged);
			this.rbManualExport.AutoSize = true;
			this.rbManualExport.Location = new global::System.Drawing.Point(364, 29);
			this.rbManualExport.Name = "rbManualExport";
			this.rbManualExport.Size = new global::System.Drawing.Size(132, 17);
			this.rbManualExport.TabIndex = 4;
			this.rbManualExport.TabStop = true;
			this.rbManualExport.Text = "Export results manually";
			this.rbManualExport.UseVisualStyleBackColor = true;
			this.rbManualExport.Visible = false;
			this.cblExport.FormattingEnabled = true;
			this.cblExport.Location = new global::System.Drawing.Point(27, 73);
			this.cblExport.MultiColumn = true;
			this.cblExport.Name = "cblExport";
			this.cblExport.Size = new global::System.Drawing.Size(522, 79);
			this.cblExport.TabIndex = 3;
			this.cblExport.SelectedIndexChanged += new global::System.EventHandler(this.cblExport_SelectedIndexChanged);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(28, 57);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(92, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Columns to Export";
			this.tabPage2.Controls.Add(this.numericUpDown1);
			this.tabPage2.Controls.Add(this.tbDelayTo);
			this.tabPage2.Controls.Add(this.tbDelayFrom);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.cbRandomDelay);
			this.tabPage2.Controls.Add(this.rbUseVPN);
			this.tabPage2.Controls.Add(this.tbProxyAuthPassword);
			this.tabPage2.Controls.Add(this.tbProxyAuthUsername);
			this.tabPage2.Controls.Add(this.tbFreeProxiesList);
			this.tabPage2.Controls.Add(this.tbRandomProxyList);
			this.tabPage2.Controls.Add(this.cbAuthentification);
			this.tabPage2.Controls.Add(this.tbProxyServerPort);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.tbProxyServerIP);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.rbFreeProxiesList);
			this.tabPage2.Controls.Add(this.rbRundomProxyList);
			this.tabPage2.Controls.Add(this.rbUseSingleProxy);
			this.tabPage2.Controls.Add(this.rbNoProxy);
			this.tabPage2.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(576, 289);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Connection";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.numericUpDown1.Location = new global::System.Drawing.Point(389, 110);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.numericUpDown1;
			int[] array4 = new int[4];
			array4[0] = 10000;
			numericUpDown4.Maximum = new decimal(array4);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new global::System.Drawing.Size(60, 20);
			this.numericUpDown1.TabIndex = 21;
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.numericUpDown1;
			int[] array5 = new int[4];
			array5[0] = 2;
			numericUpDown5.Value = new decimal(array5);
			this.numericUpDown1.Visible = false;
			this.tbDelayTo.AutoSize = false;
			this.tbDelayTo.Location = new global::System.Drawing.Point(483, 54);
			this.tbDelayTo.Name = "tbDelayTo";
			this.tbDelayTo.Size = new global::System.Drawing.Size(85, 18);
			this.tbDelayTo.TabIndex = 20;
			this.tbDelayTo.ValueChanged += new global::System.EventHandler(this.tbDelayTo_ValueChanged);
			this.tbDelayFrom.AutoSize = false;
			this.tbDelayFrom.Location = new global::System.Drawing.Point(352, 54);
			this.tbDelayFrom.Name = "tbDelayFrom";
			this.tbDelayFrom.Size = new global::System.Drawing.Size(85, 18);
			this.tbDelayFrom.TabIndex = 19;
			this.tbDelayFrom.ValueChanged += new global::System.EventHandler(this.tbDelayFrom_ValueChanged);
			this.label12.AutoSize = true;
			this.label12.Location = new global::System.Drawing.Point(452, 54);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(16, 13);
			this.label12.TabIndex = 18;
			this.label12.Text = "to";
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(288, 54);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(57, 13);
			this.label11.TabIndex = 17;
			this.label11.Text = "Delay from";
			this.cbRandomDelay.AutoSize = true;
			this.cbRandomDelay.Location = new global::System.Drawing.Point(291, 34);
			this.cbRandomDelay.Name = "cbRandomDelay";
			this.cbRandomDelay.Size = new global::System.Drawing.Size(198, 17);
			this.cbRandomDelay.TabIndex = 16;
			this.cbRandomDelay.Text = "Use random delay between requests";
			this.cbRandomDelay.UseVisualStyleBackColor = true;
			this.cbRandomDelay.CheckedChanged += new global::System.EventHandler(this.cbRandomDelay_CheckedChanged);
			this.rbUseVPN.AutoSize = true;
			this.rbUseVPN.Location = new global::System.Drawing.Point(8, 10);
			this.rbUseVPN.Name = "rbUseVPN";
			this.rbUseVPN.Size = new global::System.Drawing.Size(140, 17);
			this.rbUseVPN.TabIndex = 15;
			this.rbUseVPN.TabStop = true;
			this.rbUseVPN.Text = "Use VPN to hide your IP";
			this.rbUseVPN.UseVisualStyleBackColor = true;
			this.rbUseVPN.CheckedChanged += new global::System.EventHandler(this.rbUseVPN_CheckedChanged);
			this.tbProxyAuthPassword.Location = new global::System.Drawing.Point(455, 132);
			this.tbProxyAuthPassword.Name = "tbProxyAuthPassword";
			this.tbProxyAuthPassword.Size = new global::System.Drawing.Size(113, 20);
			this.tbProxyAuthPassword.TabIndex = 14;
			this.tbProxyAuthPassword.Text = "120";
			this.tbProxyAuthPassword.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.tbProxyAuthPassword.Visible = false;
			this.tbProxyAuthUsername.Location = new global::System.Drawing.Point(455, 106);
			this.tbProxyAuthUsername.Name = "tbProxyAuthUsername";
			this.tbProxyAuthUsername.Size = new global::System.Drawing.Size(113, 20);
			this.tbProxyAuthUsername.TabIndex = 13;
			this.tbProxyAuthUsername.Text = "2";
			this.tbProxyAuthUsername.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.tbProxyAuthUsername.Visible = false;
			this.tbFreeProxiesList.Enabled = false;
			this.tbFreeProxiesList.Location = new global::System.Drawing.Point(291, 197);
			this.tbFreeProxiesList.Multiline = true;
			this.tbFreeProxiesList.Name = "tbFreeProxiesList";
			this.tbFreeProxiesList.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.tbFreeProxiesList.Size = new global::System.Drawing.Size(277, 84);
			this.tbFreeProxiesList.TabIndex = 10;
			this.tbRandomProxyList.Enabled = false;
			this.tbRandomProxyList.Location = new global::System.Drawing.Point(8, 197);
			this.tbRandomProxyList.Multiline = true;
			this.tbRandomProxyList.Name = "tbRandomProxyList";
			this.tbRandomProxyList.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.tbRandomProxyList.Size = new global::System.Drawing.Size(277, 84);
			this.tbRandomProxyList.TabIndex = 9;
			this.cbAuthentification.AutoSize = true;
			this.cbAuthentification.Enabled = false;
			this.cbAuthentification.Location = new global::System.Drawing.Point(291, 88);
			this.cbAuthentification.Name = "cbAuthentification";
			this.cbAuthentification.Size = new global::System.Drawing.Size(88, 17);
			this.cbAuthentification.TabIndex = 8;
			this.cbAuthentification.Text = "Pause every:";
			this.cbAuthentification.UseVisualStyleBackColor = true;
			this.cbAuthentification.Visible = false;
			this.cbAuthentification.CheckedChanged += new global::System.EventHandler(this.cbAuthentification_CheckedChanged);
			this.tbProxyServerPort.Enabled = false;
			this.tbProxyServerPort.Location = new global::System.Drawing.Point(240, 110);
			this.tbProxyServerPort.Name = "tbProxyServerPort";
			this.tbProxyServerPort.Size = new global::System.Drawing.Size(45, 20);
			this.tbProxyServerPort.TabIndex = 7;
			this.tbProxyServerPort.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(205, 113);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(28, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "port:";
			this.tbProxyServerIP.Enabled = false;
			this.tbProxyServerIP.Location = new global::System.Drawing.Point(92, 110);
			this.tbProxyServerIP.Name = "tbProxyServerIP";
			this.tbProxyServerIP.Size = new global::System.Drawing.Size(107, 20);
			this.tbProxyServerIP.TabIndex = 5;
			this.tbProxyServerIP.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(5, 113);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(81, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Proxy server IP:";
			this.rbFreeProxiesList.AutoSize = true;
			this.rbFreeProxiesList.Location = new global::System.Drawing.Point(291, 174);
			this.rbFreeProxiesList.Name = "rbFreeProxiesList";
			this.rbFreeProxiesList.Size = new global::System.Drawing.Size(247, 17);
			this.rbFreeProxiesList.TabIndex = 3;
			this.rbFreeProxiesList.TabStop = true;
			this.rbFreeProxiesList.Text = "Use free proxies lists (enter one source per line)";
			this.rbFreeProxiesList.UseVisualStyleBackColor = true;
			this.rbFreeProxiesList.CheckedChanged += new global::System.EventHandler(this.rbFreeProxiesList_CheckedChanged);
			this.rbRundomProxyList.AutoSize = true;
			this.rbRundomProxyList.Location = new global::System.Drawing.Point(8, 174);
			this.rbRundomProxyList.Name = "rbRundomProxyList";
			this.rbRundomProxyList.Size = new global::System.Drawing.Size(258, 17);
			this.rbRundomProxyList.TabIndex = 2;
			this.rbRundomProxyList.TabStop = true;
			this.rbRundomProxyList.Text = "Use random proxy from list (line format server:port)";
			this.rbRundomProxyList.UseVisualStyleBackColor = true;
			this.rbRundomProxyList.CheckedChanged += new global::System.EventHandler(this.rbRundomProxyList_CheckedChanged);
			this.rbUseSingleProxy.AutoSize = true;
			this.rbUseSingleProxy.Location = new global::System.Drawing.Point(8, 88);
			this.rbUseSingleProxy.Name = "rbUseSingleProxy";
			this.rbUseSingleProxy.Size = new global::System.Drawing.Size(102, 17);
			this.rbUseSingleProxy.TabIndex = 1;
			this.rbUseSingleProxy.TabStop = true;
			this.rbUseSingleProxy.Text = "Use single proxy";
			this.rbUseSingleProxy.UseVisualStyleBackColor = true;
			this.rbUseSingleProxy.CheckedChanged += new global::System.EventHandler(this.rbUseSingleProxy_CheckedChanged);
			this.rbNoProxy.AutoSize = true;
			this.rbNoProxy.Location = new global::System.Drawing.Point(8, 33);
			this.rbNoProxy.Name = "rbNoProxy";
			this.rbNoProxy.Size = new global::System.Drawing.Size(142, 17);
			this.rbNoProxy.TabIndex = 0;
			this.rbNoProxy.TabStop = true;
			this.rbNoProxy.Text = "Do not use proxy servers";
			this.rbNoProxy.UseVisualStyleBackColor = true;
			this.rbNoProxy.CheckedChanged += new global::System.EventHandler(this.rbNoProxy_CheckedChanged);
			this.btnOk.Location = new global::System.Drawing.Point(214, 12);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new global::System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new global::System.EventHandler(this.btnOk_Click);
			this.btnCancel.Location = new global::System.Drawing.Point(295, 12);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.panel.Controls.Add(this.btnCancel);
			this.panel.Controls.Add(this.btnOk);
			this.panel.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel.Location = new global::System.Drawing.Point(0, 315);
			this.panel.Name = "panel";
			this.panel.Size = new global::System.Drawing.Size(584, 46);
			this.panel.TabIndex = 3;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(584, 361);
			base.Controls.Add(this.tabControl);
			base.Controls.Add(this.panel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("MASAGooGLExtractor.$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SettingsForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			base.Shown += new global::System.EventHandler(this.SettingsForm_Shown);
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numthreads).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.tbDelayTo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.tbDelayFrom).EndInit();
			this.panel.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000118 RID: 280
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000119 RID: 281
		private global::System.Windows.Forms.TabControl tabControl;

		// Token: 0x0400011A RID: 282
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x0400011B RID: 283
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x0400011C RID: 284
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x0400011D RID: 285
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400011E RID: 286
		private global::System.Windows.Forms.Panel panel;

		// Token: 0x0400011F RID: 287
		private global::System.Windows.Forms.ComboBox cbCSVEncoding;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.ComboBox cbCSVDelimiter;

		// Token: 0x04000122 RID: 290
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000123 RID: 291
		private global::System.Windows.Forms.ComboBox cbExportType;

		// Token: 0x04000124 RID: 292
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000125 RID: 293
		private global::System.Windows.Forms.Button btnChooseExportFolder;

		// Token: 0x04000126 RID: 294
		private global::System.Windows.Forms.TextBox tbExportPath;

		// Token: 0x04000127 RID: 295
		private global::System.Windows.Forms.RadioButton rbAutoExport;

		// Token: 0x04000128 RID: 296
		private global::System.Windows.Forms.RadioButton rbManualExport;

		// Token: 0x04000129 RID: 297
		private global::System.Windows.Forms.CheckedListBox cblExport;

		// Token: 0x0400012A RID: 298
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400012B RID: 299
		private global::System.Windows.Forms.RadioButton rbFreeProxiesList;

		// Token: 0x0400012C RID: 300
		private global::System.Windows.Forms.RadioButton rbRundomProxyList;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.RadioButton rbUseSingleProxy;

		// Token: 0x0400012E RID: 302
		private global::System.Windows.Forms.RadioButton rbNoProxy;

		// Token: 0x0400012F RID: 303
		private global::System.Windows.Forms.TextBox tbProxyAuthPassword;

		// Token: 0x04000130 RID: 304
		private global::System.Windows.Forms.TextBox tbProxyAuthUsername;

		// Token: 0x04000131 RID: 305
		private global::System.Windows.Forms.TextBox tbFreeProxiesList;

		// Token: 0x04000132 RID: 306
		private global::System.Windows.Forms.TextBox tbRandomProxyList;

		// Token: 0x04000133 RID: 307
		private global::System.Windows.Forms.CheckBox cbAuthentification;

		// Token: 0x04000134 RID: 308
		private global::System.Windows.Forms.TextBox tbProxyServerPort;

		// Token: 0x04000135 RID: 309
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000136 RID: 310
		private global::System.Windows.Forms.TextBox tbProxyServerIP;

		// Token: 0x04000137 RID: 311
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000138 RID: 312
		private global::System.Windows.Forms.CheckBox cbExtractEmails;

		// Token: 0x04000139 RID: 313
		private global::System.Windows.Forms.RadioButton rbUseVPN;

		// Token: 0x0400013A RID: 314
		private global::System.Windows.Forms.ComboBox cbLanguage;

		// Token: 0x0400013B RID: 315
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400013C RID: 316
		private global::System.Windows.Forms.TrackBar tbDelayTo;

		// Token: 0x0400013D RID: 317
		private global::System.Windows.Forms.TrackBar tbDelayFrom;

		// Token: 0x0400013E RID: 318
		private global::System.Windows.Forms.Label label12;

		// Token: 0x0400013F RID: 319
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000140 RID: 320
		private global::System.Windows.Forms.CheckBox cbRandomDelay;

		// Token: 0x04000141 RID: 321
		private global::System.Windows.Forms.TextBox tbNumberOfResultsPerZipCode;

		// Token: 0x04000142 RID: 322
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000143 RID: 323
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000144 RID: 324
		private global::System.Windows.Forms.NumericUpDown numericUpDown1;

		// Token: 0x04000145 RID: 325
		private global::System.Windows.Forms.NumericUpDown numthreads;

		// Token: 0x04000146 RID: 326
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000147 RID: 327
		private global::System.Windows.Forms.CheckBox cbAutoRestart;

		// Token: 0x04000148 RID: 328
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x04000149 RID: 329
		private global::System.Windows.Forms.ToolTip toolTip2;
	}
}
