using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MASAGooGLExtractor
{
	// Token: 0x0200000B RID: 11
	public static class AutoRestartManager
	{
		// Token: 0x06000035 RID: 53 RVA: 0x000033FC File Offset: 0x000015FC
		public static void SetAutoRestartEnabled(bool enabled)
		{
			try
			{
				File.WriteAllText(AutoRestartManager.AutoRestartFlagPath, enabled ? "1" : "0");
			}
			catch
			{
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003438 File Offset: 0x00001638
		public static bool IsAutoRestartEnabled()
		{
			bool flag;
			try
			{
				if (!File.Exists(AutoRestartManager.AutoRestartFlagPath))
				{
					flag = false;
				}
				else
				{
					string value = File.ReadAllText(AutoRestartManager.AutoRestartFlagPath).Trim();
					flag = value == "1" || value.Equals("true", StringComparison.OrdinalIgnoreCase);
				}
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000349C File Offset: 0x0000169C
		public static void SaveState(bool isRunning, string taskInfo = "")
		{
			try
			{
				string state = string.Format("{0:yyyy-MM-dd HH:mm:ss}|{1}|{2}", DateTime.Now, isRunning, taskInfo);
				File.WriteAllText(AutoRestartManager.StateFilePath, state);
			}
			catch
			{
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000034E8 File Offset: 0x000016E8
		public static void ClearState()
		{
			try
			{
				if (File.Exists(AutoRestartManager.StateFilePath))
				{
					File.Delete(AutoRestartManager.StateFilePath);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003520 File Offset: 0x00001720
		public static bool ShouldAutoRestart(out string taskInfo)
		{
			taskInfo = "";
			try
			{
				if (!File.Exists(AutoRestartManager.StateFilePath))
				{
					return false;
				}
				string[] parts = File.ReadAllText(AutoRestartManager.StateFilePath).Split(new char[] { '|' });
				if (parts.Length >= 2)
				{
					bool flag = parts[1].ToLower() == "true";
					taskInfo = ((parts.Length > 2) ? parts[2] : "");
					return flag;
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000035A4 File Offset: 0x000017A4
		public static void LogCrash(Exception ex = null)
		{
			try
			{
				string crashInfo = string.Format("{0:yyyy-MM-dd HH:mm:ss} | CRASH\r\n", DateTime.Now);
				if (ex != null)
				{
					crashInfo = string.Concat(new string[]
					{
						crashInfo,
						"Exception: ",
						ex.GetType().Name,
						"\r\nMessage: ",
						ex.Message,
						"\r\nStack: ",
						ex.StackTrace,
						"\r\n"
					});
				}
				File.AppendAllText(AutoRestartManager.CrashLogPath, crashInfo + new string('-', 80) + "\r\n");
			}
			catch
			{
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000364C File Offset: 0x0000184C
		public static void SetupCrashWatchdog()
		{
			try
			{
				string taskInfo;
				if (AutoRestartManager.ShouldAutoRestart(out taskInfo))
				{
					System.Threading.Tasks.Task.Run(delegate
					{
						Thread.Sleep(2000);
						AutoRestartManager.TriggerAutoRestart(taskInfo);
					});
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003694 File Offset: 0x00001894
		private static void TriggerAutoRestart(string taskInfo)
		{
			try
			{
				MainForm mainForm = null;
				foreach (object obj in Application.OpenForms)
				{
					Form form = (Form)obj;
					if (form is MainForm)
					{
						mainForm = (MainForm)form;
						break;
					}
				}
				if (mainForm != null && !mainForm.IsDisposed)
				{
					mainForm.Invoke(new MethodInvoker(delegate
					{
						try
						{
							mainForm.ResumeDataCollection();
						}
						catch
						{
						}
					}));
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003748 File Offset: 0x00001948
		public static void SetupGlobalExceptionHandler()
		{
			AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs e)
			{
				try
				{
					AutoRestartManager.LogCrash(e.ExceptionObject as Exception);
					if (e.IsTerminating)
					{
						AutoRestartManager.SaveState(true, "CrashRecovery");
						Thread.Sleep(500);
					}
				}
				catch
				{
				}
			};
			TaskScheduler.UnobservedTaskException += delegate(object sender, UnobservedTaskExceptionEventArgs e)
			{
				try
				{
					AutoRestartManager.LogCrash(e.Exception);
					e.SetObserved();
				}
				catch
				{
				}
			};
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000037A4 File Offset: 0x000019A4
		public static void RestartApplication()
		{
			try
			{
				string exePath = Application.ExecutablePath;
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(exePath);
				int currentId = Process.GetCurrentProcess().Id;
				foreach (Process p in Process.GetProcessesByName(fileNameWithoutExtension))
				{
					if (p.Id != currentId)
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
				Thread.Sleep(1000);
				Process.Start(exePath);
				Application.Exit();
			}
			catch
			{
			}
		}

		// Token: 0x04000015 RID: 21
		private static readonly string StateFilePath = Path.Combine(Path.GetTempPath(), "MASA_AutoRestart_State.txt");

		// Token: 0x04000016 RID: 22
		private static readonly string AutoRestartFlagPath = Path.Combine(Path.GetTempPath(), "MASA_AutoRestart_Flag.txt");

		// Token: 0x04000017 RID: 23
		private static readonly string CrashLogPath = Path.Combine(Path.GetTempPath(), "MASA_CrashLog.txt");
	}
}
