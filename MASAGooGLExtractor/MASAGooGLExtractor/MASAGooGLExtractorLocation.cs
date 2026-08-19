using System;
using System.Collections.Generic;

namespace MASAGooGLExtractor
{
	// Token: 0x02000017 RID: 23
	public class Location
	{
		// Token: 0x06000086 RID: 134 RVA: 0x00007EF5 File Offset: 0x000060F5
		public Location()
		{
			this.States = new List<DatabaseObject>();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00007F08 File Offset: 0x00006108
		public override string ToString()
		{
			string str = "";
			if (this.States.Count > 0)
			{
				str = this.Country.Name;
				foreach (DatabaseObject s in this.States)
				{
					str += string.Format(", {0}", s);
				}
				return str;
			}
			if (this.Country != null)
			{
				str = this.Country.Name;
			}
			if (this.State != null)
			{
				str += string.Format(", {0}", this.State.Name);
			}
			if (this.City != null)
			{
				str += string.Format(", {0}", this.City.Name);
			}
			if (this.ZipCode != null)
			{
				str += string.Format(", {0}", this.ZipCode.Name);
			}
			return str;
		}

		// Token: 0x04000064 RID: 100
		public DatabaseObject Country;

		// Token: 0x04000065 RID: 101
		public DatabaseObject State;

		// Token: 0x04000066 RID: 102
		public DatabaseObject City;

		// Token: 0x04000067 RID: 103
		public DatabaseObject ZipCode;

		// Token: 0x04000068 RID: 104
		public List<DatabaseObject> States;
	}
}
