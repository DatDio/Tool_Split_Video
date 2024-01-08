using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Tool_Render_Video
{
	public class FunctionHelper
	{
		
		public static string GetVideoPathToSplit(string path)
		{
			lock (Form1._lockFolder)
			{
				var videos = Directory.GetFiles(Path.GetFullPath(path));
				foreach (var video in videos)
				{
					if (!video.Contains("DONE_") && !Form1._listVideoUsing.Contains(video))
					{
						try
						{
							Form1._listVideoUsing.Add(video);
							return Path.GetFullPath(video);
						}
						catch
						{

						}
					}
				}
			}
			return "";
		}
		public static string GetVideoPathToAddPart(string path)
		{
			lock (Form1._lockFolder)
			{
				var videos = Directory.GetFiles(Path.GetFullPath(path));
				foreach (var video in videos)
				{
					if (video.EndsWith("_OLD.mp4") && !Form1._listVideoUsing.Contains(video))
					{
						try
						{
							Form1._listVideoUsing.Add(video);
							return Path.GetFullPath(video);
						}
						catch
						{

						}
					}
				}
			}
			return "";
		}






		public static string GetBackgroundVideoPath(string path)
		{
			lock (Form1._lockFolder)
			{
				var videos = Directory.GetFiles(Path.GetFullPath(path));
				foreach (var video in videos)
				{
					//if (!video.Contains("_DONE"))
					//{
					//	return video;
					//}
					return video;
				}
			}
			return "";
		}
		public static string GetVideoPath(string path)
		{
			int count = 0;
			lock (Form1._lockFolder)
			{
				var videos = Directory.GetFiles(Path.GetFullPath(path));
				foreach (var video in videos)
				{
					count++;
					var videopathChange = $"Input/VideoGoc/Funny{count}.mp4";
					if (!video.Contains("DONE_") && !Form1._listVideoUsing.Contains(videopathChange))
					{
						try
						{

							Directory.Move(Path.GetFullPath(video), Path.GetFullPath(videopathChange));
							Form1._listVideoUsing.Add(videopathChange);
							return Path.GetFullPath(videopathChange);
						}
						catch
						{

						}
					}
				}
			}
			return "";
		}
		public static string GetVideoPathPet(string path)
		{
			int count = 0;
			lock (Form1._lockFolder)
			{
				var videos = Directory.GetFiles(Path.GetFullPath(path));
				foreach (var video in videos)
				{
					count++;
					var videopathChange = $"Input/VideoGoc/Yummy{count}.mp4";
					if (!video.Contains("DONE_") && !Form1._listVideoUsing.Contains(videopathChange))
					{
						try
						{

							Directory.Move(Path.GetFullPath(video), Path.GetFullPath(videopathChange));
							Form1._listVideoUsing.Add(videopathChange);
							return Path.GetFullPath(videopathChange);
						}
						catch
						{

						}
					}
				}
			}
			return "";
		}
		public static string GetMockup(string path)
		{
			lock (Form1._lockFolder)
			{
				var videos = Directory.GetFiles(Path.GetFullPath(path));
				foreach (var video in videos)
				{
					//if (!video.Contains("_DONE"))
					//{
					//	return video;
					//}
					return video;
				}
			}
			return "";
		}
		public static Double GetDuration(String file)
		{
			WindowsMediaPlayer wmp = new WindowsMediaPlayer();
			IWMPMedia mediainfo = wmp.newMedia(file);
			return mediainfo.duration;
		}
		public static void AddLogs(string text)
		{
			if (Form1._rtbLogs.InvokeRequired)
			{
				Form1._rtbLogs.Invoke(new Action(() => Form1._rtbLogs.AppendText(text)));
			}
			else
			{
				Form1._rtbLogs.AppendText(text);
			}
		}
	}
}
