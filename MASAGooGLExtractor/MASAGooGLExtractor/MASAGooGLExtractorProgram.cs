using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MASAGooGLExtractor
{
	// Token: 0x0200001D RID: 29
	internal static class Program
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x0000F750 File Offset: 0x0000D950
		public static void RequestDelay()
		{
			if (Program.AppSettings.IsRandomDelay)
			{
				Thread.Sleep((int)(2000.0 * (double)Program.Rnd.Next(Program.AppSettings.DelayFrom, Program.AppSettings.DelayTo)));
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000F78D File Offset: 0x0000D98D
		public static void Pause()
		{
			if (Program.AppSettings.ProxyAuthentification)
			{
				Thread.Sleep(Program.AppSettings.Numeric);
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000F7AC File Offset: 0x0000D9AC
		[STAThread]
		private static void Main()
		{
			string processName = Process.GetCurrentProcess().ProcessName;
			AutoRestartManager.SetupGlobalExceptionHandler();
			string destFile = string.Format("Export_{0}.csv", DateTime.Now.ToString("dd-MM-yyyy"));
			Program.ExportFile = string.Format("{0}\\MASA GooGle Extractor\\" + destFile, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			Program.SettingsFileName = string.Format("{0}\\MASA GooGle Extractor\\settings.cfg", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			Program.SettingDir = string.Format("{0}\\MASA GooGle Extractor", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			if (!Directory.Exists(Program.SettingDir))
			{
				Directory.CreateDirectory(Program.SettingDir);
			}
			if (!File.Exists(Program.SettingsFileName))
			{
				Program.SettingsFileName = string.Format("{0}\\settings.cfg", Program.SettingDir);
			}
			Program.Rnd = new Random(DateTime.Now.Millisecond);
			Program.AppSettings = Settings.Load(Program.SettingsFileName);
			Program.LanguagesManager = new Languages();
			try
			{
				foreach (string langFile in Program.LanguagesFiles)
				{
					File.Exists(Path.Combine(Application.StartupPath, langFile));
				}
				if (Program.AppSettings.Language >= 0 && Program.AppSettings.Language < Program.LanguagesFiles.Length)
				{
					string langFilePath = Path.Combine(Application.StartupPath, Program.LanguagesFiles[Program.AppSettings.Language]);
					if (File.Exists(langFilePath))
					{
						Program.LanguagesManager.InitFields(langFilePath);
					}
					else
					{
						string fallbackPath = Path.Combine(Application.StartupPath, Program.LanguagesFiles[0]);
						if (File.Exists(fallbackPath))
						{
							Program.LanguagesManager.InitFields(fallbackPath);
							Program.AppSettings.Language = 0;
						}
					}
				}
			}
			catch (Exception)
			{
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				Form form = new MainForm();
				AutoRestartManager.SetupCrashWatchdog();
				Application.Run(form);
			}
			catch (Exception ex)
			{
				AutoRestartManager.LogCrash(ex);
				MessageBox.Show("Critical error: " + ex.Message);
			}
		}

		// Token: 0x040000DB RID: 219
		public static string SettingsFileName;

		// Token: 0x040000DC RID: 220
		public static bool IsDemoVersion = false;

		// Token: 0x040000DD RID: 221
		public static string ExportFile;

		// Token: 0x040000DE RID: 222
		public static string SettingDir;

		// Token: 0x040000DF RID: 223
		public static Random Rnd;

		// Token: 0x040000E0 RID: 224
		public static Settings AppSettings;

		// Token: 0x040000E1 RID: 225
		public static DBSettings DBSettings;

		// Token: 0x040000E2 RID: 226
		public static Database AppDatabase;

		// Token: 0x040000E3 RID: 227
		public static Languages LanguagesManager;

		// Token: 0x040000E4 RID: 228
		public static string[] LanguagesFiles = new string[] { "languages\\lang-en.txt", "languages\\lang-it.txt", "languages\\lang-ge.txt", "languages\\lang-fr.txt", "languages\\lang-sp.txt" };

		// Token: 0x040000E5 RID: 229
		public static bool StopDataCollection = false;

		// Token: 0x040000E6 RID: 230
		public static bool IsDemoLimit = false;
	}
}
