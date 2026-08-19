using System;
using System.Collections.Generic;

namespace MASAGooGLExtractor
{
	// Token: 0x0200000E RID: 14
	public class DataBlock
	{
		// Token: 0x0600004C RID: 76 RVA: 0x00003E50 File Offset: 0x00002050
		public DataBlock(string InputString)
		{
			this.Data = new List<string>();
			this.Parse(new List<string> { InputString });
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003ED0 File Offset: 0x000020D0
		private void Parse(List<string> InputData)
		{
			this.AddedLines = 0;
			for (int i = 0; i < InputData.Count; i++)
			{
				if (InputData[i][0] == '[' && InputData[i][InputData[i].Length - 1] == ']')
				{
					InputData[i] = InputData[i].Substring(1, InputData[i].Length - 2);
				}
				int PrevPos = 0;
				int Pos = 0;
				int Counter = 0;
				while (Pos < InputData[i].Length - 2)
				{
					if (InputData[i][Pos] == '[')
					{
						Counter++;
					}
					if (InputData[i][Pos] == ']')
					{
						Counter--;
					}
					if (Counter == 0)
					{
						for (int j = 0; j < this.Splitters.Length; j++)
						{
							if (InputData[i].Substring(Pos, 3) == this.Splitters[j])
							{
								string v = InputData[i].Substring(PrevPos + 1, Pos - PrevPos);
								if (v != "null")
								{
									this.Data.Add(v);
								}
								PrevPos = Pos + 1;
								this.AddedLines++;
							}
						}
					}
					Pos++;
				}
			}
		}

		// Token: 0x0400001C RID: 28
		public List<string> Data;

		// Token: 0x0400001D RID: 29
		private string[] Splitters = new string[] { "],\"", "\",[", "\",n", "n,\"", "l,n", "l,[", "],[", "],n" };

		// Token: 0x0400001E RID: 30
		public bool IsCompleted;

		// Token: 0x0400001F RID: 31
		private int AddedLines;
	}
}
