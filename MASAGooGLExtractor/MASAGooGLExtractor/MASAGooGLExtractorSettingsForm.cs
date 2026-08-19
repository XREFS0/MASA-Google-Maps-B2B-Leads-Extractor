using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace MASAGooGLExtractor
{
	// Token: 0x02000020 RID: 32
	public partial class SettingsForm : KryptonForm
	{
		// Token: 0x06000108 RID: 264 RVA: 0x00010810 File Offset: 0x0000EA10
		public SettingsForm()
		{
			this.InitializeComponent();
			this.toolTip2.SetToolTip(this.cbAutoRestart, "If checked the programm will be automatically open in case of sudden closure or crash \nand the extraction will also automatically resume from the last processed task.\n In the Auto Export you will find all data.");
			this.IsInitSettings = true;
			foreach (string ColumnName in this.ColumnNames)
			{
				this.cblExport.Items.Add(ColumnName);
			}
			Program.LanguagesManager.InitControl(this, base.Controls);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00010910 File Offset: 0x0000EB10
		private void btnOk_Click(object sender, EventArgs e)
		{
			Settings AppSettings = Settings.Load(Program.SettingsFileName);
			int.TryParse(this.tbNumberOfResultsPerZipCode.Text, out AppSettings.NumberOfResultsPerZipCode);
			AppSettings.AutoRestart = this.cbAutoRestart.Checked;
			AppSettings.Language = this.cbLanguage.SelectedIndex;
			for (int i = 0; i < this.cblExport.Items.Count; i++)
			{
				AppSettings.ColumnsToExport[i] = this.cblExport.GetItemChecked(i);
			}
			AppSettings.ExtractEmails = this.cbExtractEmails.Checked;
			AppSettings.numthreads = (int)this.numthreads.Value;
			AppSettings.AutoExport = this.rbAutoExport.Checked;
			AppSettings.AutoExportPath = this.tbExportPath.Text;
			AppSettings.ExportType = this.cbExportType.SelectedIndex;
			AppSettings.CSVDelimiter = this.cbCSVDelimiter.SelectedIndex;
			AppSettings.CSVEncoding = this.cbCSVEncoding.SelectedIndex;
			if (this.rbNoProxy.Checked)
			{
				AppSettings.ConnectionType = 0;
			}
			else if (this.rbUseSingleProxy.Checked)
			{
				AppSettings.ConnectionType = 1;
			}
			else if (this.rbRundomProxyList.Checked)
			{
				AppSettings.ConnectionType = 2;
			}
			else if (this.rbFreeProxiesList.Checked)
			{
				AppSettings.ConnectionType = 3;
			}
			else if (this.rbUseVPN.Checked)
			{
				AppSettings.ConnectionType = 4;
			}
			AppSettings.IsRandomDelay = this.cbRandomDelay.Checked;
			AppSettings.DelayFrom = this.tbDelayFrom.Value;
			AppSettings.DelayTo = this.tbDelayTo.Value;
			AppSettings.ProxyServer = this.tbProxyServerIP.Text;
			int.TryParse(this.tbProxyServerIP.Text, out AppSettings.ProxyPort);
			AppSettings.ProxyAuthentification = this.cbAuthentification.Checked;
			AppSettings.ProxyAuthLogin = this.tbProxyAuthUsername.Text;
			AppSettings.Numeric = (int)this.numericUpDown1.Value;
			AppSettings.ProxyAuthPassword = this.tbProxyAuthPassword.Text;
			AppSettings.ProxyList = this.tbRandomProxyList.Text.Split(new char[] { '\r' });
			AppSettings.ProxySourcesList = this.tbFreeProxiesList.Text.Split(new char[] { '\r' });
			AppSettings.Save(Program.SettingsFileName);
			base.Close();
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00010B70 File Offset: 0x0000ED70
		private void SettingsForm_Shown(object sender, EventArgs e)
		{
			Settings AppSettings = Settings.Load(Program.SettingsFileName);
			this.tbNumberOfResultsPerZipCode.Text = AppSettings.NumberOfResultsPerZipCode.ToString();
			this.cbLanguage.SelectedIndex = AppSettings.Language;
			for (int i = 0; i < this.cblExport.Items.Count; i++)
			{
				if (AppSettings.ColumnsToExport[i])
				{
					this.cblExport.SetItemChecked(i, true);
				}
			}
			this.tbExportPath.Text = AppSettings.AutoExportPath;
			if (AppSettings.AutoExport)
			{
				this.rbAutoExport.Checked = true;
				this.tbExportPath.Enabled = true;
			}
			else
			{
				this.tbExportPath.Enabled = false;
				this.rbManualExport.Checked = true;
			}
			this.cbExtractEmails.Checked = AppSettings.ExtractEmails;
			this.cbAutoRestart.Checked = AppSettings.AutoRestart;
			this.cbExportType.SelectedIndex = AppSettings.ExportType;
			this.cbCSVDelimiter.SelectedIndex = AppSettings.CSVDelimiter;
			this.cbCSVEncoding.SelectedIndex = AppSettings.CSVEncoding;
			this.tbDelayFrom.Value = AppSettings.DelayFrom;
			this.tbDelayTo.Value = AppSettings.DelayTo;
			this.tbDelayFrom.Enabled = AppSettings.IsRandomDelay;
			this.tbDelayTo.Enabled = AppSettings.IsRandomDelay;
			this.cbRandomDelay.Checked = AppSettings.IsRandomDelay;
			this.numthreads.Value = AppSettings.numthreads;
			this.tbProxyServerIP.Text = AppSettings.ProxyServer;
			this.tbProxyServerPort.Text = AppSettings.ProxyPort.ToString();
			if (AppSettings.ProxyList != null)
			{
				foreach (string p in AppSettings.ProxyList)
				{
					TextBox textBox = this.tbRandomProxyList;
					textBox.Text += string.Format("{0}{1}", p, Environment.NewLine);
				}
			}
			if (AppSettings.ProxySourcesList != null)
			{
				foreach (string p2 in AppSettings.ProxySourcesList)
				{
					TextBox textBox2 = this.tbFreeProxiesList;
					textBox2.Text += string.Format("{0}{1}", p2, Environment.NewLine);
				}
			}
			switch (AppSettings.ConnectionType)
			{
			case 0:
				this.rbNoProxy.Checked = true;
				break;
			case 1:
				this.rbUseSingleProxy.Checked = true;
				this.tbProxyServerIP.Enabled = true;
				this.tbProxyServerPort.Enabled = true;
				break;
			case 2:
				this.rbRundomProxyList.Checked = true;
				this.tbRandomProxyList.Enabled = true;
				break;
			case 3:
				this.rbFreeProxiesList.Checked = true;
				this.tbFreeProxiesList.Enabled = true;
				break;
			case 4:
				this.rbUseVPN.Checked = true;
				break;
			}
			this.cbAuthentification.Checked = AppSettings.ProxyAuthentification;
			this.tbProxyAuthUsername.Enabled = AppSettings.ProxyAuthentification;
			this.tbProxyAuthPassword.Enabled = AppSettings.ProxyAuthentification;
			this.IsInitSettings = false;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000FC17 File Offset: 0x0000DE17
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00010E78 File Offset: 0x0000F078
		private void rbNoProxy_CheckedChanged(object sender, EventArgs e)
		{
			this.tbProxyServerIP.Enabled = false;
			this.tbProxyServerPort.Enabled = false;
			this.tbProxyAuthPassword.Enabled = true;
			this.tbProxyAuthUsername.Enabled = true;
			this.cbAuthentification.Enabled = true;
			this.tbRandomProxyList.Enabled = false;
			this.tbFreeProxiesList.Enabled = false;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00010EDC File Offset: 0x0000F0DC
		private void rbUseSingleProxy_CheckedChanged(object sender, EventArgs e)
		{
			this.tbProxyServerIP.Enabled = true;
			this.tbProxyServerPort.Enabled = true;
			this.tbProxyAuthPassword.Enabled = true;
			this.tbProxyAuthUsername.Enabled = true;
			this.cbAuthentification.Enabled = true;
			this.tbRandomProxyList.Enabled = false;
			this.tbFreeProxiesList.Enabled = false;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00010F40 File Offset: 0x0000F140
		private void rbRundomProxyList_CheckedChanged(object sender, EventArgs e)
		{
			this.tbProxyServerIP.Enabled = false;
			this.tbProxyServerPort.Enabled = false;
			this.tbProxyAuthPassword.Enabled = true;
			this.tbProxyAuthUsername.Enabled = true;
			this.cbAuthentification.Enabled = true;
			this.tbRandomProxyList.Enabled = true;
			this.tbFreeProxiesList.Enabled = false;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00010FA4 File Offset: 0x0000F1A4
		private void rbFreeProxiesList_CheckedChanged(object sender, EventArgs e)
		{
			this.tbProxyServerIP.Enabled = false;
			this.tbProxyServerPort.Enabled = false;
			this.tbProxyAuthPassword.Enabled = true;
			this.tbProxyAuthUsername.Enabled = true;
			this.cbAuthentification.Enabled = true;
			this.tbRandomProxyList.Enabled = false;
			this.tbFreeProxiesList.Enabled = true;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00011005 File Offset: 0x0000F205
		private void rbUseVPN_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rbUseVPN.Checked && !this.IsInitSettings)
			{
				Process.Start("http://www.estrattoredati.com/vpn.php");
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00011027 File Offset: 0x0000F227
		private void cbRandomDelay_CheckedChanged(object sender, EventArgs e)
		{
			this.tbDelayFrom.Enabled = this.cbRandomDelay.Checked;
			this.tbDelayTo.Enabled = this.cbRandomDelay.Checked;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00011058 File Offset: 0x0000F258
		private void tbDelayFrom_ValueChanged(object sender, EventArgs e)
		{
			if (this.tbDelayTo.Value < this.tbDelayFrom.Value && this.tbDelayFrom.Value + 1 <= this.tbDelayTo.Maximum)
			{
				this.tbDelayTo.Value = this.tbDelayFrom.Value + 1;
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000110B0 File Offset: 0x0000F2B0
		private void tbDelayTo_ValueChanged(object sender, EventArgs e)
		{
			if (this.tbDelayTo.Value < this.tbDelayFrom.Value && this.tbDelayTo.Value - 1 >= this.tbDelayFrom.Minimum)
			{
				this.tbDelayFrom.Value = this.tbDelayTo.Value - 1;
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00011107 File Offset: 0x0000F307
		private void cbAuthentification_CheckedChanged(object sender, EventArgs e)
		{
			this.tbProxyAuthPassword.Enabled = this.cbAuthentification.Checked;
			this.tbProxyAuthUsername.Enabled = this.cbAuthentification.Checked;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00011135 File Offset: 0x0000F335
		private void rbAutoExport_CheckedChanged(object sender, EventArgs e)
		{
			this.tbExportPath.Enabled = this.rbAutoExport.Checked;
			this.btnChooseExportFolder.Enabled = this.rbAutoExport.Checked;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00011164 File Offset: 0x0000F364
		private void btnChooseExportFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = Application.StartupPath;
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				this.tbExportPath.Text = fbd.SelectedPath;
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0001119C File Offset: 0x0000F39C
		private void cbExportType_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.cbCSVDelimiter.Enabled = this.cbExportType.SelectedIndex == 0;
			this.cbCSVEncoding.Enabled = this.cbExportType.SelectedIndex == 0;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000089C9 File Offset: 0x00006BC9
		private void cblExport_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00011258 File Offset: 0x0000F458
		private void button1_Click(object sender, EventArgs e)
		{
			Process.Start("explorer.exe", Program.SettingDir);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000089C9 File Offset: 0x00006BC9
		private void numthreads_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000089C9 File Offset: 0x00006BC9
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0001128C File Offset: 0x0000F48C
		private void cbAutoRestart_CheckedChanged(object sender, EventArgs e)
		{
			AutoRestartManager.SetAutoRestartEnabled(this.cbAutoRestart.Checked);
			try
			{
				string exeDir = Path.GetDirectoryName(Application.ExecutablePath);
				string launcherPath = Path.Combine(exeDir, "MASAGooGLExtractorLauncher.exe");
				if (this.cbAutoRestart.Checked)
				{
					if (Process.GetProcessesByName("MASAGooGLExtractorLauncher").Length == 0)
					{
						if (File.Exists(launcherPath))
						{
							try
							{
								Process.Start(new ProcessStartInfo
								{
									FileName = launcherPath,
									WorkingDirectory = exeDir,
									UseShellExecute = false,
									CreateNoWindow = true
								});
								goto IL_0104;
							}
							catch (Exception ex)
							{
								this.cbAutoRestart.Checked = false;
								AutoRestartManager.SetAutoRestartEnabled(false);
								MessageBox.Show("Unable to start MASAGooGLExtractorLauncher.exe.\r\nAuto Restart has been disabled.\r\n\r\nDetails:\r\n" + ex.Message, "Auto Restart", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								goto IL_0104;
							}
						}
						this.cbAutoRestart.Checked = false;
						AutoRestartManager.SetAutoRestartEnabled(false);
						MessageBox.Show("MASAGooGLExtractorLauncher.exe not found.\r\nDownload it and copy it into the same folder of MASAGooGLExtractor.exe.", "Auto Restart", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				else
				{
					foreach (Process p in Process.GetProcessesByName("MASAGooGLExtractorLauncher"))
					{
						try
						{
							p.Kill();
						}
						catch
						{
						}
					}
				}
				IL_0104:;
			}
			catch
			{
			}
		}

		// Token: 0x04000116 RID: 278
		private bool IsInitSettings;

		// Token: 0x04000117 RID: 279
		private string[] ColumnNames = new string[]
		{
			"Category", "Real Category", "Business Name", "Full Address", "City", "State", "Postal Code", "Country", "Phone", "Email",
			"Website", "Latitude", "Longitude", "Map Link", "Details Link"
		};
	}
}
