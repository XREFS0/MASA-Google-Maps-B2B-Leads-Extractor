using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using EO.Base;
using EO.WebEngine;

namespace MASAGooGLExtractor
{
	// Token: 0x02000019 RID: 25
	public partial class MainForm : KryptonForm
	{
		// Token: 0x06000099 RID: 153 RVA: 0x00009334 File Offset: 0x00007534
		public MainForm()
		{
			this.InitializeComponent();
			this._palette = new KryptonPalette();
			this._palette.BasePaletteMode = PaletteMode.Office2010Blue;
			this._palette.FormStyles.FormMain.StateCommon.Back.Color1 = Color.FromArgb(250, 250, 250);
			this._palette.FormStyles.FormMain.StateCommon.Back.Color2 = Color.White;
			this._palette.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = Color.FromArgb(0, 128, 128);
			this._palette.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = Color.FromArgb(0, 105, 92);
			this._palette.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Color1 = Color.White;
			this._palette.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
			base.Palette = this._palette;
			base.PaletteMode = PaletteMode.Custom;
			Engine.CleanUpCacheFolders(null, CacheFolderCleanUpPolicy.AllVersions);
			Runtime.Exception += this.EO_RuntimeException;
			this.InitializeBackgroundWorker();
			Program.LanguagesManager.InitFields(Program.LanguagesFiles[Program.AppSettings.Language]);
			Program.LanguagesManager.InitControl(this, base.Controls);
			Program.LanguagesManager.InitMenu(this);
			Program.LanguagesManager.InitTableColumns(this.dgvResults);
			this.LoadCategories();
			this.LoadLocations();
			this.LoadTasks();
			this.InitializeDataSourceComboBox();
			this.ValidateRegistration();
			if (AutoRestartManager.IsAutoRestartEnabled())
			{
				System.Threading.Tasks.Task.Run(delegate
				{
					Thread.Sleep(3000);
					try
					{
						base.Invoke(new MethodInvoker(delegate
						{
							this.btnGetData.PerformClick();
						}));
					}
					catch
					{
					}
				});
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000952A File Offset: 0x0000772A
		private void EO_RuntimeException(object sender, ExceptionEventArgs e)
		{
			e.ShowExceptionDialog = false;
			ChildProcessOutOfMemoryException ex = e.ErrorException as ChildProcessOutOfMemoryException;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00009658 File Offset: 0x00007858
		public void ResumeDataCollection()
		{
			try
			{
				if (Program.AppSettings.AutoRestart)
				{
					Thread.Sleep(1000);
					this.StartDataCollection();
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00009698 File Offset: 0x00007898
		private void StartDataCollection()
		{
			try
			{
				AutoRestartManager.SaveState(true, "ResumedFromCrash");
			}
			catch (Exception ex)
			{
				AutoRestartManager.LogCrash(ex);
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000096CC File Offset: 0x000078CC
		public void StopDataCollectionCleanly()
		{
			try
			{
				Program.StopDataCollection = true;
				AutoRestartManager.ClearState();
				AutoRestartManager.SaveState(false, "");
			}
			catch
			{
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00009704 File Offset: 0x00007904
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			try
			{
				if (!Program.StopDataCollection)
				{
					AutoRestartManager.SaveState(true, "UnexpectedClose");
				}
				else
				{
					AutoRestartManager.ClearState();
				}
			}
			catch
			{
			}
			base.OnFormClosing(e);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00009748 File Offset: 0x00007948
		private void ValidateRegistration()
		{
			Program.IsDemoVersion = false;
			Program.IsDemoLimit = false;
			this.Text = "MASA GooGle Extractor Pro — B2B Lead Generation Tool | XREFS0";
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00009816 File Offset: 0x00007A16
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show(Program.LanguagesManager.ExitMessage, "MASA GooGle Extractor Pro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				e.Cancel = false;
				return;
			}
			e.Cancel = true;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00009844 File Offset: 0x00007A44
		private void LoadCategories()
		{
			this.cbCategories.Items.Clear();
			foreach (string c in Program.AppSettings.Categories)
			{
				this.cbCategories.Items.Add(c);
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000098B8 File Offset: 0x00007AB8
		private void btnCategoriesAdd_Click(object sender, EventArgs e)
		{
			InputTextForm inputTextForm = new InputTextForm("", "Add category", "Category");
			inputTextForm.ShowDialog();
			if (inputTextForm.OkPressed)
			{
				Program.AppSettings.Categories.Add(inputTextForm.Value);
				this.LoadCategories();
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00009904 File Offset: 0x00007B04
		private void btnCategoriesEdit_Click(object sender, EventArgs e)
		{
			if (this.cbCategories.SelectedItem != null)
			{
				InputTextForm inputTextForm = new InputTextForm(this.cbCategories.SelectedItem.ToString(), "Edit category", "Category");
				inputTextForm.ShowDialog();
				if (inputTextForm.OkPressed)
				{
					Program.AppSettings.Categories[this.cbCategories.SelectedIndex] = inputTextForm.Value;
				}
				this.LoadCategories();
				return;
			}
			MessageBox.Show("Please select category!");
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00009980 File Offset: 0x00007B80
		private void btnCategoriesDelete_Click(object sender, EventArgs e)
		{
			if (this.cbCategories.CheckedItems.Count > 0 && MessageBox.Show("Do you wand to delete checked items?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < this.cbCategories.Items.Count; i++)
				{
					if (this.cbCategories.GetItemChecked(i))
					{
						for (int j = 0; j < Program.AppSettings.Categories.Count; j++)
						{
							if (Program.AppSettings.Categories[j] == this.cbCategories.Items[i].ToString())
							{
								Program.AppSettings.Categories.RemoveAt(j);
							}
						}
					}
				}
				this.LoadCategories();
				return;
			}
			MessageBox.Show(Program.LanguagesManager.SelectCategory);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00009A50 File Offset: 0x00007C50
		private void btnCategoriesUpload_Click(object sender, EventArgs e)
		{
			UploadCategoriesForm uploadForm = new UploadCategoriesForm();
			uploadForm.ShowDialog();
			if (uploadForm.UseThem)
			{
				foreach (string Category in uploadForm.tbUploadCategories.Lines)
				{
					if (Category.Trim() != "")
					{
						Program.AppSettings.Categories.Add(Category);
					}
				}
				this.LoadCategories();
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00009AB8 File Offset: 0x00007CB8
		private void btnCategoriesSelectAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.cbCategories.Items.Count; i++)
			{
				this.cbCategories.SetItemChecked(i, true);
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00009AF0 File Offset: 0x00007CF0
		private void btnCategoriesClearSelection_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.cbCategories.Items.Count; i++)
			{
				this.cbCategories.SetItemChecked(i, false);
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00009B28 File Offset: 0x00007D28
		private void LoadLocations()
		{
			this.cbLocations.Items.Clear();
			foreach (Location i in Program.AppSettings.Locations)
			{
				this.cbLocations.Items.Add(i);
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00009B9C File Offset: 0x00007D9C
		private void btnLocationsAdd_Click(object sender, EventArgs e)
		{
			LocationEditForm locationEditForm = new LocationEditForm(null, "Add location");
			locationEditForm.ShowDialog();
			if (locationEditForm.Ok)
			{
				Location NewLocation = locationEditForm.SelectedLocation;
				if (NewLocation.ToString() != "")
				{
					Program.AppSettings.Locations.Add(NewLocation);
					Program.AppSettings.Save(Program.SettingsFileName);
				}
			}
			this.LoadLocations();
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00009C04 File Offset: 0x00007E04
		private void btnLocationsEdit_Click(object sender, EventArgs e)
		{
			if (this.cbLocations.SelectedIndex > -1)
			{
				LocationEditForm locationEditForm = new LocationEditForm((Location)this.cbLocations.SelectedItem, "Edit location");
				locationEditForm.ShowDialog();
				if (locationEditForm.Ok)
				{
					Program.AppSettings.Locations[this.cbLocations.SelectedIndex] = locationEditForm.SelectedLocation;
					Program.AppSettings.Save(Program.SettingsFileName);
				}
				this.LoadLocations();
				return;
			}
			MessageBox.Show("Please select location!");
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00009C8C File Offset: 0x00007E8C
		private void btnLocationsDelete_Click(object sender, EventArgs e)
		{
			if (this.cbLocations.CheckedItems.Count > 0 && MessageBox.Show("Do you wand to delete checked items?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < this.cbLocations.Items.Count; i++)
				{
					if (this.cbLocations.GetItemChecked(i))
					{
						for (int j = 0; j < Program.AppSettings.Locations.Count; j++)
						{
							if (Program.AppSettings.Locations[j].ToString() == this.cbLocations.Items[i].ToString())
							{
								Program.AppSettings.Locations.RemoveAt(j);
							}
						}
					}
				}
				this.LoadLocations();
				return;
			}
			MessageBox.Show("Please select location!");
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00009D60 File Offset: 0x00007F60
		private void btnLocationsUpload_Click(object sender, EventArgs e)
		{
			UploadLocationsForm uploadLocationsForm = new UploadLocationsForm();
			uploadLocationsForm.ShowDialog();
			if (uploadLocationsForm.Ok)
			{
				foreach (string text in uploadLocationsForm.tbUploadLocations.Lines)
				{
					if (uploadLocationsForm.tbCountry.Text.Trim() != "")
					{
						string.Format("{0}, ", uploadLocationsForm.tbCountry.Text.Trim());
					}
					if (text.Trim() != "")
					{
						Location NewLocation = new Location();
						Program.AppSettings.Locations.Add(NewLocation);
					}
				}
				this.LoadLocations();
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00009E08 File Offset: 0x00008008
		private void btnLocationsSelectAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.cbLocations.Items.Count; i++)
			{
				this.cbLocations.SetItemChecked(i, true);
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00009E40 File Offset: 0x00008040
		private void btnLocationsClearSelection_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.cbLocations.Items.Count; i++)
			{
				this.cbLocations.SetItemChecked(i, false);
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00009E78 File Offset: 0x00008078
		private void LoadTasks()
		{
			this.dgvTasks.Rows.Clear();
			for (int i = 0; i < Program.AppSettings.Tasks.Count; i++)
			{
				this.dgvTasks.Rows.Add(new object[]
				{
					Program.AppSettings.Tasks[i].TaskId,
					Program.AppSettings.Tasks[i].Category,
					Program.AppSettings.Tasks[i].Location,
					Program.AppSettings.Tasks[i].Country,
					Program.AppSettings.Tasks[i].State,
					Program.AppSettings.Tasks[i].City,
					Program.AppSettings.Tasks[i].ZipCode
				});
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00009F7C File Offset: 0x0000817C
		private void startToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (Program.AppSettings.AutoRestart)
				{
					AutoRestartManager.SaveState(true, "DataCollectionStarted");
				}
				MainForm.DBSettings = DBSettings.LoadAndDecript("GBE_DB_FIXED_KEY_2026");
				MainForm.AppDatabase = new Database(MainForm.DBSettings);
				Program.StopDataCollection = false;
				Program.IsDemoLimit = false;
				if ((this.dgvTasks.Rows.Count > 0 && this.cbCategories.SelectedItems.Count > 0 && this.cbLocations.SelectedItems.Count > 0 && MessageBox.Show("Do you want to replace previous tasks?", "Tasks", MessageBoxButtons.YesNo) == DialogResult.Yes) || (this.dgvTasks.Rows.Count == 0 && this.cbCategories.SelectedItems.Count > 0 && this.cbLocations.SelectedItems.Count > 0))
				{
					this.dgvTasks.Rows.Clear();
					Program.AppSettings.Tasks.Clear();
					for (int i = 0; i < this.cbCategories.Items.Count; i++)
					{
						if (this.cbCategories.GetItemChecked(i))
						{
							for (int j = 0; j < this.cbLocations.Items.Count; j++)
							{
								if (this.cbLocations.GetItemChecked(j))
								{
									Location TaskLocation = Program.AppSettings.Locations[j];
									string Category = Program.AppSettings.Categories[i];
									if (TaskLocation.States.Count == 0 && TaskLocation.State != null && TaskLocation.State.Id == -1)
									{
										List<DatabaseObject> Cities = this.GetCitiesByCountry(TaskLocation.Country);
										for (int CityIndex = 0; CityIndex < Cities.Count; CityIndex++)
										{
											this.lblInfo.Text = string.Format("Adding locations for {0}... {1}/{2} ", TaskLocation.State.Name, CityIndex, Cities.Count);
											int v = (int)Math.Round((double)(100f * (float)CityIndex / (float)Cities.Count));
											if (v <= 100)
											{
												this.tspProgress.Value = v;
											}
											List<DatabaseObject> ZipCodes = this.GetZipCodes(Cities[CityIndex]);
											for (int ZipCodeIndex = 0; ZipCodeIndex < ZipCodes.Count; ZipCodeIndex++)
											{
												Task NewTask = new Task
												{
													TaskId = Program.AppSettings.Tasks.Count + 1,
													Category = Category,
													Location = "",
													Country = TaskLocation.Country.Name,
													State = TaskLocation.State.Name,
													City = Cities[CityIndex].Name,
													ZipCode = ZipCodes[ZipCodeIndex].Name
												};
												Program.AppSettings.Tasks.Add(NewTask);
											}
											if (CityIndex % 20 == 0)
											{
												Application.DoEvents();
											}
										}
									}
									else if (TaskLocation.States.Count > 0)
									{
										for (int k = 0; k < TaskLocation.States.Count; k++)
										{
											List<DatabaseObject> Cities2 = this.GetCities(TaskLocation.States[k]);
											for (int CityIndex2 = 0; CityIndex2 < Cities2.Count; CityIndex2++)
											{
												this.lblInfo.Text = string.Format("Adding locations for {0}... {1}/{2} ", TaskLocation.States[k].Name, CityIndex2, Cities2.Count);
												int v2 = (int)Math.Round((double)(100f * (float)CityIndex2 / (float)Cities2.Count));
												if (v2 <= 100)
												{
													this.tspProgress.Value = v2;
												}
												List<DatabaseObject> ZipCodes2 = this.GetZipCodes(Cities2[CityIndex2]);
												for (int ZipCodeIndex2 = 0; ZipCodeIndex2 < ZipCodes2.Count; ZipCodeIndex2++)
												{
													Task NewTask2 = new Task
													{
														TaskId = Program.AppSettings.Tasks.Count + 1,
														Category = Category,
														Location = "",
														Country = TaskLocation.Country.Name,
														State = TaskLocation.States[k].Name,
														City = Cities2[CityIndex2].Name,
														ZipCode = ZipCodes2[ZipCodeIndex2].Name
													};
													Program.AppSettings.Tasks.Add(NewTask2);
												}
												if (CityIndex2 % 20 == 0)
												{
													Application.DoEvents();
												}
											}
										}
									}
									else if (TaskLocation.States.Count == 0 && TaskLocation.City != null && TaskLocation.City.Id == -1)
									{
										List<DatabaseObject> Cities3 = this.GetCities(TaskLocation.State);
										for (int CityIndex3 = 0; CityIndex3 < Cities3.Count; CityIndex3++)
										{
											this.lblInfo.Text = string.Format("Adding locations for {0}... {1}/{2} ", TaskLocation.State.Name, CityIndex3, Cities3.Count);
											int v3 = (int)Math.Round((double)(100f * (float)CityIndex3 / (float)Cities3.Count));
											if (v3 <= 100)
											{
												this.tspProgress.Value = v3;
											}
											List<DatabaseObject> ZipCodes3 = this.GetZipCodes(Cities3[CityIndex3]);
											for (int ZipCodeIndex3 = 0; ZipCodeIndex3 < ZipCodes3.Count; ZipCodeIndex3++)
											{
												Task NewTask3 = new Task
												{
													TaskId = Program.AppSettings.Tasks.Count + 1,
													Category = Category,
													Location = "",
													Country = TaskLocation.Country.Name,
													State = TaskLocation.State.Name,
													City = Cities3[CityIndex3].Name,
													ZipCode = ZipCodes3[ZipCodeIndex3].Name
												};
												Program.AppSettings.Tasks.Add(NewTask3);
											}
											if (CityIndex3 % 20 == 0)
											{
												Application.DoEvents();
											}
										}
									}
									else if (TaskLocation.States.Count == 0 && TaskLocation.City != null && TaskLocation.ZipCode.Id == -1)
									{
										List<DatabaseObject> ZipCodes4 = this.GetZipCodes(TaskLocation.City);
										for (int ZipCodeIndex4 = 0; ZipCodeIndex4 < ZipCodes4.Count; ZipCodeIndex4++)
										{
											Task NewTask4 = new Task
											{
												TaskId = Program.AppSettings.Tasks.Count + 1,
												Category = Category,
												Location = "",
												Country = TaskLocation.Country.Name,
												State = TaskLocation.State.Name,
												City = TaskLocation.City.Name,
												ZipCode = ZipCodes4[ZipCodeIndex4].Name
											};
											Program.AppSettings.Tasks.Add(NewTask4);
										}
									}
									else if (TaskLocation.States.Count == 0)
									{
										Task NewTask5 = new Task
										{
											TaskId = Program.AppSettings.Tasks.Count + 1,
											Category = Category,
											Location = "",
											Country = ((TaskLocation.Country != null) ? TaskLocation.Country.Name : ""),
											State = ((TaskLocation.State != null) ? TaskLocation.State.Name : ""),
											City = ((TaskLocation.City != null) ? TaskLocation.City.Name : ""),
											ZipCode = ((TaskLocation.ZipCode != null) ? TaskLocation.ZipCode.Name : "")
										};
										Program.AppSettings.Tasks.Add(NewTask5);
									}
								}
							}
						}
					}
					Program.AppSettings.Save(Program.SettingsFileName);
					this.LoadTasks();
				}
				MainForm.AppDatabase.Connection.Close();
				if (this.dgvTasks.Rows.Count == 0)
				{
					MessageBox.Show("There are no tasks!");
				}
				else
				{
					this.dgvResults.Rows.Clear();
					if (Program.AppSettings.DataSource == 1)
					{
						if (!this._scrapingWorker.IsBusy)
						{
							this._scrapingWorker.RunWorkerAsync();
						}
						else
						{
							MessageBox.Show("Extraction already in progress!");
						}
					}
					else
					{
						this.RunGoogleMapsScraping();
					}
				}
			}
			catch (Exception ex)
			{
				if (Program.AppSettings.AutoRestart)
				{
					AutoRestartManager.LogCrash(ex);
				}
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000A824 File Offset: 0x00008A24
		private void stopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this._scrapingWorker != null && this._scrapingWorker.IsBusy)
			{
				this._scrapingWorker.CancelAsync();
			}
			Program.StopDataCollection = true;
			Application.DoEvents();
			foreach (Process p in Process.GetProcesses())
			{
				if (p.ProcessName == "phantomjs")
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
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000089C9 File Offset: 0x00006BC9
		private void exportKMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000A8C4 File Offset: 0x00008AC4
		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new SettingsForm().ShowDialog();
			Program.AppSettings = Settings.Load(Program.SettingsFileName);
			Program.LanguagesManager.InitFields(Program.LanguagesFiles[Program.AppSettings.Language]);
			Program.LanguagesManager.InitControl(this, base.Controls);
			Program.LanguagesManager.InitMenu(this);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000A93E File Offset: 0x00008B3E
		private List<DatabaseObject> GetCitiesByCountry(DatabaseObject Country)
		{
			List<DatabaseObject> Cities = new List<DatabaseObject>();
			foreach (object[] Row in MainForm.AppDatabase.Select(string.Format("SELECT Id, name FROM city WHERE country_id={0} ORDER BY name", Country.Id)))
			{
				DatabaseObject obj = new DatabaseObject
				{
					Id = Convert.ToInt32(Row[0]),
					Name = (string)Row[1]
				};
				Cities.Add(obj);
			}
			return Cities;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000AA08 File Offset: 0x00008C08
		private List<DatabaseObject> GetCities(DatabaseObject State)
		{
			List<DatabaseObject> Cities = new List<DatabaseObject>();
			foreach (object[] Row in MainForm.AppDatabase.Select(string.Format("SELECT Id, name FROM city WHERE region_id={0} ORDER BY name", State.Id)))
			{
				DatabaseObject obj = new DatabaseObject
				{
					Id = Convert.ToInt32(Row[0]),
					Name = (string)Row[1]
				};
				Cities.Add(obj);
			}
			return Cities;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000AAA0 File Offset: 0x00008CA0
		private List<DatabaseObject> GetZipCodes(DatabaseObject City)
		{
			List<DatabaseObject> ZipCodes = new List<DatabaseObject>();
			foreach (object[] Row in MainForm.AppDatabase.Select(string.Format("SELECT name FROM zip_codes WHERE city_id={0} ORDER BY name", City.Id)))
			{
				DatabaseObject obj = new DatabaseObject
				{
					Id = 0,
					Name = (string)Row[0]
				};
				ZipCodes.Add(obj);
			}
			return ZipCodes;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000AB30 File Offset: 0x00008D30
		private void btnTasksSelectAll_Click(object sender, EventArgs e)
		{
			this.dgvTasks.SelectAll();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000AB40 File Offset: 0x00008D40
		private void btnTasksClearSelection_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.dgvTasks.Rows.Count; i++)
			{
				this.dgvTasks.Rows[i].Selected = false;
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000AB80 File Offset: 0x00008D80
		private void btnTasksDeleteSelected_Click(object sender, EventArgs e)
		{
			int CurrentTaskId = 0;
			foreach (object obj in this.dgvTasks.SelectedRows)
			{
				DataGridViewRow row = (DataGridViewRow)obj;
				int.TryParse(this.dgvTasks.Rows[row.Index].Cells[0].Value.ToString(), out CurrentTaskId);
				for (int i = 0; i < Program.AppSettings.Tasks.Count; i++)
				{
					if (CurrentTaskId == Program.AppSettings.Tasks[i].TaskId)
					{
						Program.AppSettings.Tasks.RemoveAt(i);
						break;
					}
				}
				Program.AppSettings.Save(Program.SettingsFileName);
				this.dgvTasks.Rows.RemoveAt(row.Index);
			}
			Program.AppSettings.Save(Program.SettingsFileName);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000AC90 File Offset: 0x00008E90
		private void btnTasksSaveTasks_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Filter = "Tasks|*.tsk",
				InitialDirectory = Application.StartupPath
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string FileContent = "";
				for (int i = 0; i < this.dgvTasks.Rows.Count; i++)
				{
					string Line = "";
					for (int j = 0; j < this.dgvTasks.ColumnCount; j++)
					{
						Line = Line + this.dgvTasks.Rows[i].Cells[j].Value.ToString() + "|";
					}
					FileContent = FileContent + Line.Substring(0, Line.Length - 1) + Environment.NewLine;
				}
				File.WriteAllText(saveFileDialog.FileName, FileContent);
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000AD64 File Offset: 0x00008F64
		private void btnTasksLoadTasks_Click(object sender, EventArgs e)
		{
			if (this.dgvTasks.Rows.Count > 0 && MessageBox.Show("Do you want to replace previous tasks?", "Tasks", MessageBoxButtons.YesNo) == DialogResult.No)
			{
				return;
			}
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Tasks|*.tsk",
				InitialDirectory = Application.StartupPath
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.dgvTasks.Rows.Clear();
				Program.AppSettings.Tasks.Clear();
				string[] Content = File.ReadAllLines(openFileDialog.FileName);
				for (int i = 0; i < Content.Length; i++)
				{
					string[] Values = Content[i].Split(new char[] { '|' });
					DataGridViewRowCollection rows = this.dgvTasks.Rows;
					object[] array = Values;
					rows.Add(array);
					Task NewTask = new Task
					{
						TaskId = Program.AppSettings.Tasks.Count + 1,
						Category = Values[1],
						Location = "",
						Country = Values[3],
						State = Values[4],
						City = Values[5],
						ZipCode = Values[6]
					};
					Program.AppSettings.Tasks.Add(NewTask);
					Program.AppSettings.Save(Program.SettingsFileName);
				}
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000AEA0 File Offset: 0x000090A0
		private void btnSelectAll_Click(object sender, EventArgs e)
		{
			this.dgvResults.SelectAll();
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000AEAD File Offset: 0x000090AD
		private void btnClearSelection_Click(object sender, EventArgs e)
		{
			this.dgvResults.ClearSelection();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000AEBC File Offset: 0x000090BC
		private void btnDeleteSelected_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(string.Format(Program.LanguagesManager.DeleteSomeRows, this.dgvResults.SelectedRows.Count), "Delete", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
			{
				foreach (object obj in this.dgvResults.SelectedRows)
				{
					DataGridViewRow item = (DataGridViewRow)obj;
					this.dgvResults.Rows.RemoveAt(item.Index);
				}
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000AF5C File Offset: 0x0000915C
		private void btnDeleteAll_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(string.Format(Program.LanguagesManager.DeleteAllRows, this.dgvResults.SelectedRows.Count), "Delete", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
			{
				this.dgvResults.Rows.Clear();
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000AFAC File Offset: 0x000091AC
		private void btnExport_Click(object sender, EventArgs e)
		{
			if (this.dgvResults.Rows.Count == 0)
			{
				MessageBox.Show(Program.LanguagesManager.NoDataToExport);
			}
			this.dgvResults.SelectAll();
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (Program.AppSettings.ExportType == 0)
			{
				saveFileDialog.Filter = "CSV files|*.csv";
			}
			else if (Program.AppSettings.ExportType == 1)
			{
				saveFileDialog.Filter = "Excel files|*.xls";
			}
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (Program.AppSettings.ExportType == 0)
				{
					ExportManager.SaveToCSV(Program.AppSettings, saveFileDialog.FileName, this.dgvResults);
					return;
				}
				if (Program.AppSettings.ExportType == 1)
				{
					ExportManager.SaveToXLS(Program.AppSettings, saveFileDialog.FileName, this.dgvResults);
					return;
				}
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000B07C File Offset: 0x0000927C
		private void btnOpenWebsite_Click(object sender, EventArgs e)
		{
			if (this.dgvResults.SelectedRows.Count > 0)
			{
				string Url = "";
				if (this.dgvResults.Rows[this.dgvResults.SelectedRows[0].Index].Cells[10].Value != null)
				{
					Url = this.dgvResults.Rows[this.dgvResults.SelectedRows[0].Index].Cells[10].Value.ToString();
				}
				if (Url != "")
				{
					Process.Start(new ProcessStartInfo(Url));
				}
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000B134 File Offset: 0x00009334
		private void btnOpenMap_Click(object sender, EventArgs e)
		{
			string Url = "";
			if (this.dgvResults.Rows[this.dgvResults.SelectedRows[0].Index].Cells[13].Value != null)
			{
				Url = this.dgvResults.Rows[this.dgvResults.SelectedRows[0].Index].Cells[13].Value.ToString();
			}
			if (Url != "")
			{
				Process.Start(new ProcessStartInfo(Url));
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000B1D8 File Offset: 0x000093D8
		private void btnOpenDetails_Click(object sender, EventArgs e)
		{
			string Url = "";
			if (this.dgvResults.Rows[this.dgvResults.SelectedRows[0].Index].Cells[14].Value != null)
			{
				Url = this.dgvResults.Rows[this.dgvResults.SelectedRows[0].Index].Cells[14].Value.ToString();
			}
			if (Url != "")
			{
				Process.Start(new ProcessStartInfo(Url));
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000B27A File Offset: 0x0000947A
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Program.AppSettings.Save(Program.SettingsFileName);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000B28C File Offset: 0x0000948C
		private void dgvResults_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if ((e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 13 || e.ColumnIndex == 14) && e.RowIndex > -1 && this.dgvResults.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
			{
				try
				{
					string url = this.dgvResults.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
					if (e.ColumnIndex == 9)
					{
						url = string.Format("mailto:{0}", url);
					}
					Process.Start(new ProcessStartInfo(url));
				}
				catch
				{
				}
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000B368 File Offset: 0x00009568
		private void dgvResults_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex > 0 && (e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 13 || e.ColumnIndex == 14) && this.dgvResults.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && this.dgvResults.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
			{
				this.Cursor = Cursors.Hand;
				return;
			}
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000B42C File Offset: 0x0000962C
		private void ConfigureGrid(DataGridView grid)
		{
			grid.EnableHeadersVisualStyles = false;
			grid.BackgroundColor = Color.White;
			grid.BorderStyle = BorderStyle.None;
			grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 128, 128);
			grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
			grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			grid.DefaultCellStyle.BackColor = Color.White;
			grid.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
			grid.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
			grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(178, 223, 219);
			grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 33, 33);
			grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
			grid.RowHeadersVisible = false;
			grid.RowTemplate.Height = 22;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000B554 File Offset: 0x00009754
		private void StylePrimaryButton(Button btn)
		{
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
			btn.BackColor = Color.FromArgb(0, 128, 128);
			btn.ForeColor = Color.White;
			btn.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000B5AC File Offset: 0x000097AC
		private void StyleDangerButton(Button btn)
		{
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
			btn.BackColor = Color.FromArgb(198, 40, 40);
			btn.ForeColor = Color.White;
			btn.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000B604 File Offset: 0x00009804
		private void StyleSecondaryButton(Button btn)
		{
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
			btn.BackColor = Color.FromArgb(224, 242, 241);
			btn.ForeColor = Color.FromArgb(33, 33, 33);
			btn.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000B65F File Offset: 0x0000985F
		private void StyleGroupBox(GroupBox gb)
		{
			gb.BackColor = Color.Transparent;
			gb.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000B684 File Offset: 0x00009884
		private void MainForm_Load(object sender, EventArgs e)
		{
			this.ConfigureGrid(this.dgvResults);
			this.ConfigureGrid(this.dgvTasks);
			this.dgvResults.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 105, 92);
			this.dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			this.dgvResults.BackgroundColor = Color.FromArgb(236, 239, 241);
			this.panel2.BackColor = Color.FromArgb(236, 239, 241);
			this.StyleGroupBox(this.groupBox1);
			this.StyleGroupBox(this.groupBox2);
			this.StyleGroupBox(this.groupBox3);
			this.cbCategories.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
			this.cbLocations.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
			this.StylePrimaryButton(this.btnGetData);
			this.StyleDangerButton(this.btnStop);
			this.StylePrimaryButton(this.btnExport);
			this.StyleSecondaryButton(this.btnSelectAll);
			this.StyleSecondaryButton(this.btnClearSelection);
			this.StyleSecondaryButton(this.btnDeleteSelected);
			this.StyleSecondaryButton(this.btnDeleteAll);
			this.StyleSecondaryButton(this.btnTasksSelectAll);
			this.StyleSecondaryButton(this.btnTasksClearSelection);
			this.StyleSecondaryButton(this.btnTasksDeleteSelected);
			this.StyleSecondaryButton(this.btnTasksSaveTasks);
			this.StyleSecondaryButton(this.btnTasksLoadTasks);
			this.StyleSecondaryButton(this.btnCategoriesAdd);
			this.StyleSecondaryButton(this.btnCategoriesEdit);
			this.StyleSecondaryButton(this.btnCategoriesDelete);
			this.StyleSecondaryButton(this.btnCategoriesUpload);
			this.StyleSecondaryButton(this.btnCategoriesSelectAll);
			this.StyleSecondaryButton(this.btnCategoriesClearSelection);
			this.StyleSecondaryButton(this.btnLocationsAdd);
			this.StyleSecondaryButton(this.btnLocationsEdit);
			this.StyleSecondaryButton(this.btnLocationsDelete);
			this.StyleSecondaryButton(this.btnLocationsSelectAll);
			this.StyleSecondaryButton(this.btnLocationsClearSelection);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000B888 File Offset: 0x00009A88
		private void RunGoogleMapsScraping()
		{
			try
			{
				AutoRestartManager.SaveState(true, "GoogleMapsScraping");
				Program.StopDataCollection = false;
				int TaskIndex = 0;
				while (this.dgvTasks.Rows.Count > 0 && !Program.StopDataCollection)
				{
					new GoogleMapsScraper(TaskIndex, this, Program.AppSettings.ExtractEmails);
					GC.Collect();
					int CurrentTaskId = 0;
					int.TryParse(this.dgvTasks.Rows[TaskIndex].Cells[0].Value.ToString(), out CurrentTaskId);
					for (int i = 0; i < Program.AppSettings.Tasks.Count; i++)
					{
						if (CurrentTaskId == Program.AppSettings.Tasks[i].TaskId)
						{
							Program.AppSettings.Tasks.RemoveAt(i);
							break;
						}
					}
					Program.AppSettings.Save(Program.SettingsFileName);
					this.LoadTasks();
					Application.DoEvents();
				}
				this.lblInfo.Text = "Done!";
				this.tspProgress.Value = 0;
				if (Program.StopDataCollection)
				{
					if (!Program.IsDemoLimit)
					{
						MessageBox.Show("Stopped by user!");
					}
				}
				else
				{
					MessageBox.Show("Processing is done!");
				}
			}
			catch (Exception ex)
			{
				if (Program.AppSettings.AutoRestart)
				{
					AutoRestartManager.LogCrash(ex);
				}
				MessageBox.Show("Error: " + ex.Message);
			}
			finally
			{
				this.StopDataCollectionCleanly();
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000BA1C File Offset: 0x00009C1C
		private void InitializeBackgroundWorker()
		{
			this._scrapingWorker = new BackgroundWorker();
			this._scrapingWorker.WorkerReportsProgress = true;
			this._scrapingWorker.WorkerSupportsCancellation = true;
			this._scrapingWorker.DoWork += this.ScrapingWorker_DoWork;
			this._scrapingWorker.ProgressChanged += this.ScrapingWorker_ProgressChanged;
			this._scrapingWorker.RunWorkerCompleted += this.ScrapingWorker_RunWorkerCompleted;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000BA94 File Offset: 0x00009C94
		private void ScrapingWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			Program.StopDataCollection = false;
			int TaskIndex = 0;
			MethodInvoker cachedDeleteTask = null;
			while (TaskIndex < Program.AppSettings.Tasks.Count && !Program.StopDataCollection)
			{
				if (worker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}
				try
				{
					new BingMapsScraper(TaskIndex, this, Program.AppSettings.ExtractEmails);
					GC.Collect();
					MethodInvoker methodInvoker;
					if ((methodInvoker = cachedDeleteTask) == null)
					{
						methodInvoker = (cachedDeleteTask = delegate
						{
							if (this.dgvTasks.Rows.Count > TaskIndex)
							{
								int CurrentTaskId = 0;
								int.TryParse(this.dgvTasks.Rows[TaskIndex].Cells[0].Value.ToString(), out CurrentTaskId);
								for (int i = 0; i < Program.AppSettings.Tasks.Count; i++)
								{
									if (CurrentTaskId == Program.AppSettings.Tasks[i].TaskId)
									{
										Program.AppSettings.Tasks.RemoveAt(i);
										break;
									}
								}
								Program.AppSettings.Save(Program.SettingsFileName);
								this.LoadTasks();
							}
						});
					}
					MethodInvoker deleteTask = methodInvoker;
					if (base.InvokeRequired)
					{
						base.Invoke(deleteTask);
					}
					else
					{
						deleteTask();
					}
				}
				catch (Exception ex)
				{
					if (Program.AppSettings.AutoRestart)
					{
						AutoRestartManager.LogCrash(ex);
					}
				}
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000089C9 File Offset: 0x00006BC9
		private void ScrapingWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000BB74 File Offset: 0x00009D74
		private void ScrapingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.lblInfo.Text = "Done!";
			this.tspProgress.Value = 0;
			this.StopDataCollectionCleanly();
			if (e.Cancelled || Program.StopDataCollection)
			{
				if (!Program.IsDemoLimit)
				{
					MessageBox.Show("Stopped by user!");
					return;
				}
			}
			else
			{
				if (e.Error != null)
				{
					MessageBox.Show("Error during extraction: " + e.Error.Message);
					return;
				}
				MessageBox.Show("Processing is done!");
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000BBF4 File Offset: 0x00009DF4
		private void InitializeDataSourceComboBox()
		{
			try
			{
				if (Program.AppSettings.DataSource >= 0 && Program.AppSettings.DataSource < this.cboDataSource.Items.Count)
				{
					this.cboDataSource.SelectedIndex = Program.AppSettings.DataSource;
				}
				else
				{
					this.cboDataSource.SelectedIndex = 0;
				}
			}
			catch
			{
				this.cboDataSource.SelectedIndex = 0;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000BC70 File Offset: 0x00009E70
		private void cboDataSource_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				Program.AppSettings.DataSource = this.cboDataSource.SelectedIndex;
				Program.AppSettings.Save(Program.SettingsFileName);
			}
			catch
			{
			}
		}

		// Token: 0x0400007D RID: 125
		public static DBSettings DBSettings;

		// Token: 0x0400007E RID: 126
		public static Database AppDatabase;

		// Token: 0x0400007F RID: 127
		private KryptonPalette _palette;

		// Token: 0x04000080 RID: 128
		private BackgroundWorker _scrapingWorker;
	}
}
