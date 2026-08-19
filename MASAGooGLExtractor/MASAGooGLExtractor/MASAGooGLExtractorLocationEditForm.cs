using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MASAGooGLExtractor
{
	// Token: 0x02000018 RID: 24
	public partial class LocationEditForm : Form
	{
		// Token: 0x06000088 RID: 136 RVA: 0x0000800C File Offset: 0x0000620C
		public LocationEditForm(Location Location, string Title)
		{
			this.InitializeComponent();
			this.Refresh();
			LocationEditForm.DBSettings = DBSettings.LoadAndDecript("GBE_DB_FIXED_KEY_2026");
			LocationEditForm.AppDatabase = new Database(LocationEditForm.DBSettings);
			this.SelectedLocation = Location;
			this.Text = Title;
			foreach (object[] Row in LocationEditForm.AppDatabase.Select("SELECT Id, name FROM country ORDER BY name"))
			{
				DatabaseObject obj = new DatabaseObject
				{
					Id = Convert.ToInt32(Row[0]),
					Name = (string)Row[1]
				};
				this.cbCountry.Items.Add(obj);
			}
			DatabaseObject otherCountries = new DatabaseObject
			{
				Id = -155,
				Name = "OTHER COUNTRIES"
			};
			this.cbCountry.Items.Add(otherCountries);
			if (this.SelectedLocation != null)
			{
				if (Location.Country != null)
				{
					this.SetCountry(Location.Country.Id);
				}
				if (Location.State != null)
				{
					this.SetState(Location.State.Id);
				}
				if (Location.City != null)
				{
					this.SetCity(Location.City.Id);
				}
				if (Location.ZipCode != null)
				{
					this.SetZipCode(Location.ZipCode.Id);
				}
				if (this.SelectedLocation.States.Count <= 0)
				{
					return;
				}
				using (List<DatabaseObject>.Enumerator enumerator2 = this.SelectedLocation.States.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						DatabaseObject State = enumerator2.Current;
						for (int i = 0; i < this.clbStates.Items.Count; i++)
						{
							if (State.ToString() == this.clbStates.Items[i].ToString())
							{
								this.clbStates.SetItemChecked(i, true);
							}
						}
					}
					return;
				}
			}
			this.SelectedLocation = new Location();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00008228 File Offset: 0x00006428
		private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Refresh();
			DatabaseObject Country = (DatabaseObject)this.cbCountry.SelectedItem;
			DatabaseObject selectedCountry = this.cbCountry.SelectedItem as DatabaseObject;
			if (selectedCountry != null && selectedCountry.Id == -155)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "https://estrattoredati.com/task-generator/",
					UseShellExecute = true
				});
			}
			List<object[]> States = LocationEditForm.AppDatabase.Select(string.Format("SELECT Id, name, code FROM region WHERE country_id={0} AND NOT name='' ORDER BY name", Country.Id));
			if (States.Count > 0)
			{
				this.cbState.Enabled = true;
				this.clbStates.Items.Clear();
				this.cbState.Items.Clear();
				DatabaseObject objAllStates = new DatabaseObject
				{
					Id = -1,
					Name = "All states"
				};
				this.cbState.Items.Add(objAllStates);
				foreach (object[] Row in States)
				{
					DatabaseObject obj = new DatabaseObject
					{
						Id = Convert.ToInt32(Row[0]),
						Name = (string)Row[1]
					};
					this.cbState.Items.Add(obj);
					this.clbStates.Items.Add(obj);
				}
				this.cbState.SelectedIndex = 0;
				return;
			}
			this.cbState.Enabled = false;
			List<object[]> list = LocationEditForm.AppDatabase.Select(string.Format("SELECT Id, name FROM city WHERE country_id={0} AND NOT name='' ORDER BY name", Country.Id));
			this.cbCity.Items.Clear();
			DatabaseObject objAllItems = new DatabaseObject
			{
				Id = -1,
				Name = "All cities"
			};
			this.cbCity.Items.Add(objAllItems);
			foreach (object[] Row2 in list)
			{
				DatabaseObject obj2 = new DatabaseObject
				{
					Id = Convert.ToInt32(Row2[0]),
					Name = (string)Row2[1]
				};
				this.cbCity.Items.Add(obj2);
			}
			this.cbCity.SelectedIndex = 0;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00008484 File Offset: 0x00006684
		private void cbState_SelectedIndexChanged(object sender, EventArgs e)
		{
			DatabaseObject Country = (DatabaseObject)this.cbCountry.SelectedItem;
			DatabaseObject State = (DatabaseObject)this.cbState.SelectedItem;
			List<object[]> list = LocationEditForm.AppDatabase.Select(string.Format("SELECT Id, name FROM city WHERE region_id={0} AND country_id={1} AND NOT name='' ORDER BY name", State.Id, Country.Id));
			this.cbCity.Items.Clear();
			DatabaseObject objAllItems = new DatabaseObject
			{
				Id = -1,
				Name = "All cities"
			};
			this.cbCity.Items.Add(objAllItems);
			foreach (object[] Row in list)
			{
				DatabaseObject obj = new DatabaseObject
				{
					Id = Convert.ToInt32(Row[0]),
					Name = (string)Row[1]
				};
				this.cbCity.Items.Add(obj);
			}
			this.cbCity.SelectedIndex = 0;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00008598 File Offset: 0x00006798
		private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
		{
			DatabaseObject City = (DatabaseObject)this.cbCity.SelectedItem;
			List<object[]> list = LocationEditForm.AppDatabase.Select(string.Format("SELECT city_id, name FROM zip_codes WHERE city_id={0} ORDER BY name", City.Id));
			this.cbZipCodes.Items.Clear();
			DatabaseObject objAllItems = new DatabaseObject
			{
				Id = -1,
				Name = "All zip codes"
			};
			this.cbZipCodes.Items.Add(objAllItems);
			foreach (object[] Row in list)
			{
				DatabaseObject obj = new DatabaseObject
				{
					Id = 0,
					Name = (string)Row[1]
				};
				this.cbZipCodes.Items.Add(obj);
			}
			this.cbZipCodes.SelectedIndex = 0;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00008684 File Offset: 0x00006884
		private void btnSelectAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.clbStates.Items.Count; i++)
			{
				this.clbStates.SetItemChecked(i, true);
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000086BC File Offset: 0x000068BC
		private void btnClearAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.clbStates.Items.Count; i++)
			{
				this.clbStates.SetItemChecked(i, false);
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000086F1 File Offset: 0x000068F1
		private void btnApply_Click(object sender, EventArgs e)
		{
			this.Ok = true;
			this.GetParameters();
			LocationEditForm.AppDatabase.Connection.Close();
			base.Close();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00008715 File Offset: 0x00006915
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Ok = false;
			LocationEditForm.AppDatabase.Connection.Close();
			base.Close();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00008734 File Offset: 0x00006934
		private void GetParameters()
		{
			if (this.clbStates.CheckedItems.Count > 0)
			{
				this.SelectedLocation.Country = (DatabaseObject)this.cbCountry.SelectedItem;
				this.SelectedLocation.States.Clear();
				for (int i = 0; i < this.clbStates.Items.Count; i++)
				{
					if (this.clbStates.GetItemChecked(i))
					{
						DatabaseObject State = (DatabaseObject)this.clbStates.Items[i];
						this.SelectedLocation.States.Add(State);
					}
				}
			}
			else
			{
				this.SelectedLocation.States.Clear();
			}
			if (this.cbCountry.SelectedIndex > -1 && this.clbStates.CheckedItems.Count == 0)
			{
				this.SelectedLocation.Country = (DatabaseObject)this.cbCountry.SelectedItem;
				this.SelectedLocation.State = (DatabaseObject)this.cbState.SelectedItem;
				this.SelectedLocation.City = (DatabaseObject)this.cbCity.SelectedItem;
				this.SelectedLocation.ZipCode = (DatabaseObject)this.cbZipCodes.SelectedItem;
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00008870 File Offset: 0x00006A70
		public void SetCountry(int Id)
		{
			for (int i = 0; i < this.cbCountry.Items.Count; i++)
			{
				if (((DatabaseObject)this.cbCountry.Items[i]).Id == Id)
				{
					this.cbCountry.SelectedIndex = i;
					return;
				}
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000088C4 File Offset: 0x00006AC4
		public void SetState(int Id)
		{
			for (int i = 0; i < this.cbState.Items.Count; i++)
			{
				if (((DatabaseObject)this.cbState.Items[i]).Id == Id)
				{
					this.cbState.SelectedIndex = i;
					return;
				}
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00008918 File Offset: 0x00006B18
		public void SetCity(int Id)
		{
			for (int i = 0; i < this.cbCity.Items.Count; i++)
			{
				if (((DatabaseObject)this.cbCity.Items[i]).Id == Id)
				{
					this.cbCity.SelectedIndex = i;
					return;
				}
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000896C File Offset: 0x00006B6C
		public void SetZipCode(int Id)
		{
			for (int i = 0; i < this.cbZipCodes.Items.Count; i++)
			{
				if (((DatabaseObject)this.cbZipCodes.Items[i]).Id == Id)
				{
					this.cbZipCodes.SelectedIndex = i;
					return;
				}
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000089BF File Offset: 0x00006BBF
		private void button1_Click(object sender, EventArgs e)
		{
			this.LocationEditForm_Load(sender, e);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000089C9 File Offset: 0x00006BC9
		private void LocationEditForm_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x04000069 RID: 105
		public bool Ok;

		// Token: 0x0400006A RID: 106
		public Location SelectedLocation;

		// Token: 0x0400006B RID: 107
		public static DBSettings DBSettings;

		// Token: 0x0400006C RID: 108
		public static Database AppDatabase;
	}
}
