using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool_Render_Video.Properties;
using FFmpeg.AutoGen;
using System;
using System.Runtime.InteropServices;
using Tool_Render_Video.Controllers;
using System.Security.Principal;

namespace Tool_Render_Video
{

	public partial class Form1 : Form
	{
		public double _timeVideoSplited;
		public static int _threadRunning, _numberThread, _success, _fail;

		public static List<string> _listContent, _listVideoUsing;
		public static bool stop;
		public static object _lockFolder, _lockfolerToDelete;
		public static RichTextBox _rtbLogs;
		Stopwatch stopwatch;
		public Form1()
		{
			InitializeComponent();
			_rtbLogs = rtbAddLogs;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			txtNumberThread.Text = Settings.Default.txtNumberThread;
			txtTimeVideoSplited.Text = Settings.Default.txtTimeVideoSplited;
			if (!Directory.Exists("Input"))
			{
				Directory.CreateDirectory("Input");
			}
			//if (!Directory.Exists("Input/BackgroundVideo"))
			//{
			//    Directory.CreateDirectory("Input/BackgroundVideo");
			//}
			if (!Directory.Exists("Input/VideoGoc"))
			{
				Directory.CreateDirectory("Input/VideoGoc");
			}
			//if (!Directory.Exists("Input/Mockup"))
			//{
			//    Directory.CreateDirectory("Input/Mockup");
			//}
			if (!Directory.Exists("Output"))
			{
				Directory.CreateDirectory("Output");
			}
			_lockFolder = new object();
			_lockfolerToDelete = new object();
			cbbScript.Text = cbbScript.Items[0].ToString();
		}
		private void btnInput_Click(object sender, EventArgs e)
		{
			Process.Start(Path.GetFullPath("Input"));
		}

		private void btnOutput_Click(object sender, EventArgs e)
		{
			Process.Start(Path.GetFullPath("Output"));
		}
		private void btnStop_Click(object sender, EventArgs e)
		{
			stop = true;
			btnStop.Enabled = false;
			btnStart.Enabled = true;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			stop = false;
			Settings.Default.txtNumberThread = txtNumberThread.Text;
			Settings.Default.txtTimeVideoSplited = txtTimeVideoSplited.Text;
			Settings.Default.Save();
			_timeVideoSplited = double.Parse(txtTimeVideoSplited.Value.ToString());
			_timeVideoSplited = _timeVideoSplited + (_timeVideoSplited * 0.25);
			_numberThread = int.Parse(txtNumberThread.Text);
			_threadRunning = _numberThread;
			lblthreadRunning.Text = _threadRunning.ToString();
			_success = 0;
			_fail = 0;
			lblSuccess.Text = _success.ToString();
			lblFail.Text = _fail.ToString();
			_listVideoUsing = new List<string>();
			//ConvertVideo("Input/Mockup/2.jpg", "Output/temp_image.mp4");
			//OneThreadRenderAnime();
			//if (cbbScript.SelectedItem.ToString() == "Render Anime Có Mockup")
			//{
			//	for (int i = 0; i < _numberThread; i++)
			//	{
			//		Thread thread = new Thread(OneThreadRenderAnime) { IsBackground = true };
			//		thread.Start();
			//	}
			//}
			//if (cbbScript.SelectedItem.ToString() == "Render Video Lồng Lên Video Sóng Funny")
			//{
			//	for (int i = 0; i < _numberThread; i++)
			//	{
			//		Thread thread = new Thread(OneThreadRenderWaveBackgroundFunny) { IsBackground = true };
			//		thread.Start();
			//	}
			//}
			//if (cbbScript.SelectedItem.ToString() == "Render Video Lồng Lên Video Sóng Pet")
			//{
			//	for (int i = 0; i < _numberThread; i++)
			//	{
			//		Thread thread = new Thread(OneThreadRenderWaveBackgroundPet) { IsBackground = true };
			//		thread.Start();
			//	}
			//}
			for (int i = 0; i < _numberThread; i++)
			{
				Thread thread = new Thread(OneThreadSplitVideo) { IsBackground = true };
				thread.Start();
			}
			stopwatch = new Stopwatch();
			stopwatch.Start();
			timer1.Start();
			btnStart.Enabled = false;
			btnStop.Enabled = true;
			FunctionHelper.AddLogs("Đang cut video...\n");
		}
		private void OneThreadSplitVideo()
		{
			var textContent = "";
			//ConvertVideoController convertVideoController = new ConvertVideoController();
			while (!stop)
			{
				var videoPath = FunctionHelper.GetVideoPathToSplit(Path.GetFullPath("Input/VideoGoc"));

				if (videoPath == "")
				{
					FunctionHelper.AddLogs($"Hết video \n");
					break;
				}
				var videoName = Path.GetFileNameWithoutExtension(videoPath);
				var originalTitle = videoName;
				//var duration = FunctionHelper.GetDuration(videoPath);
				if (!Directory.Exists($"Output/{videoName}"))
				{
					Directory.CreateDirectory($"Output/{videoName}");
				}
				if (videoName.Length > 20)
				{
					var lines = videoName.Split(' ');
					int lineCount = 0;
					int height = 300;
					originalTitle = lines[lineCount];
					while (originalTitle.Length < 20)
					{
						originalTitle = originalTitle + " " + lines[++lineCount];
					}
					for (int i = lineCount + 1; i < lines.Count(); i++)
					{
						//i = 4;
						//var c = lines.Count();
						string text = lines[i];
						while (text.Length < 20 && i < lines.Count() - 1)
						{
							text = text + " " + lines[++i];
							//textContent += $",drawtext=fontfile=BRITANIC.TTF:text='{text}':fontcolor=black:fontsize=80:x=(w-text_w)/2:y=((h-text_h)/10)+text_h+50:box=1:boxcolor=white:boxborderw=5";
						}
						if (text.Contains("'"))
						{
							text = text.Replace("'", "");
						}
						textContent += $",drawtext=fontfile=BRITANIC.TTF:text='{text}':fontcolor=black:fontsize=80:x=(w-text_w)/2:y={height}:box=1:boxcolor=white:boxborderw=5";
						height += 100;
					}
				}

				var status = ConvertVideoController.SplitVideo(videoPath, _timeVideoSplited, $"Output/{videoName}/Part_%d_{videoName}_OLD.mp4");
				if (status)
				{
					lock (_lockFolder)
					{
						var videos = Directory.GetFiles(Path.GetFullPath($"Output/{videoName}"));
						foreach (var video in videos)
						{
							if (video.EndsWith("_OLD.mp4") && !_listVideoUsing.Contains(video))
							{
								try
								{
									_listVideoUsing.Add(video);
									var videoPathToAddPart = video;
									if (videoPathToAddPart == "")
									{
										FunctionHelper.AddLogs($"Render video {videoName} bị lỗi!\n");
										Interlocked.Increment(ref _fail);
										Invoke((MethodInvoker)delegate ()
										{
											lblFail.Text = _fail.ToString();
										});
										continue;
									}
									var partNumber = int.Parse(Path.GetFileNameWithoutExtension(videoPathToAddPart).Split('_')[1]) + 1;
									status = ConvertVideoController.SpeedUpAndAddText(videoPathToAddPart, partNumber, originalTitle, textContent, $"Output/{videoName}/Part {partNumber}  {videoName}.mp4");
									if (status)
									{
										lock (_lockfolerToDelete)
										{
											try
											{
												File.Move(videoPath, videoPath.Replace("VideoGoc\\", "VideoGoc\\DONE_"));

											}
											catch
											{
												
											}
										}
										for (int i = 0; i < 10; i++)
										{
											try
											{
												File.Delete(videoPathToAddPart);
												break;
											}
											catch
											{
												Thread.Sleep(1000);
											}
										}
										FunctionHelper.AddLogs($"Render video {videoName}|Part{partNumber} thành công!\n");
										Interlocked.Increment(ref _success);
										Invoke((MethodInvoker)delegate ()
										{
											lblSuccess.Text = _success.ToString();
										});
									}
									else
									{
										FunctionHelper.AddLogs($"Render video {videoName}|{partNumber} bị lỗi!\n");
										Interlocked.Increment(ref _fail);
										Invoke((MethodInvoker)delegate ()
										{
											lblFail.Text = _fail.ToString();
										});
									}
								}
								catch
								{

								}
							}
						}
					}
				}
				else
				{
					FunctionHelper.AddLogs($"Render video {videoName} bị lỗi!\n");
					Interlocked.Increment(ref _fail);
					Invoke((MethodInvoker)delegate ()
					{
						lblFail.Text = _fail.ToString();
					});
				}
			}
			Interlocked.Decrement(ref _threadRunning);
			Invoke((MethodInvoker)delegate ()
			{
				lblthreadRunning.Text = _threadRunning.ToString();
			});
			if (_threadRunning == 0)
			{
				Invoke(new MethodInvoker(() =>
				{
					btnStop.Enabled = false;
					btnStart.Enabled = true;
					timer1.Stop();
				}));

				MessageBox.Show("Tool đã dừng");
			}
		}
		private void OneThreadRenderWaveBackgroundFunny()
		{

			//ConvertVideoController convertVideoController = new ConvertVideoController();
			while (!stop)
			{
				FunctionHelper.AddLogs("Bắt đầu render!");
				var backgroundPath = FunctionHelper.GetBackgroundVideoPath(Path.GetFullPath("Input/BackgroundVideo"));
				if (backgroundPath == "")
				{
					MessageBox.Show("Đã hết background video!");
					break;
				}
				var videoPath = FunctionHelper.GetVideoPath(Path.GetFullPath("Input/VideoGoc"));

				if (videoPath == "")
				{
					MessageBox.Show("Đã hết video !");
					break;
				}
				var videoName = new FileInfo(videoPath).Name;
				var duration = FunctionHelper.GetDuration(videoPath);
				var status = ConvertVideoController.ConvertVideoWaveBackground(backgroundPath, videoPath, duration, Path.GetFullPath("Output/" + videoName));
				if (status)
				{
					for (int i = 0; i < 10; i++)
					{
						try
						{
							File.Move(videoPath, videoPath.Replace("VideoGoc\\", "VideoGoc\\DONE_"));
							break;
						}
						catch
						{
							Thread.Sleep(1000);
						}
					}
					FunctionHelper.AddLogs("Render video thành công!\n");
					Interlocked.Increment(ref _success);
					Invoke((MethodInvoker)delegate ()
					{
						lblSuccess.Text = _success.ToString();
					});

				}
				else
				{
					FunctionHelper.AddLogs("Render video bị lỗi!\n");
					Interlocked.Increment(ref _fail);
					Invoke((MethodInvoker)delegate ()
					{
						lblFail.Text = _fail.ToString();
					});
				}
			}
			Interlocked.Decrement(ref _threadRunning);
			Invoke((MethodInvoker)delegate ()
			{
				lblthreadRunning.Text = _threadRunning.ToString();
			});
			if (_threadRunning == 0)
			{
				Invoke(new MethodInvoker(() =>
				{
					btnStop.Enabled = false;
					btnStart.Enabled = true;
					timer1.Stop();
				}));

				MessageBox.Show("Tool đã dừng");
			}
		}
		private void OneThreadRenderWaveBackgroundPet()
		{

			//ConvertVideoController convertVideoController = new ConvertVideoController();
			while (!stop)
			{
				FunctionHelper.AddLogs("Bắt đầu render!");
				var backgroundPath = FunctionHelper.GetBackgroundVideoPath(Path.GetFullPath("Input/BackgroundVideo"));
				if (backgroundPath == "")
				{
					MessageBox.Show("Đã hết background video!");
					break;
				}
				var videoPath = FunctionHelper.GetVideoPathPet(Path.GetFullPath("Input/VideoGoc"));

				if (videoPath == "")
				{
					MessageBox.Show("Đã hết video !");
					break;
				}
				var videoName = new FileInfo(videoPath).Name;
				var duration = FunctionHelper.GetDuration(videoPath);
				var status = ConvertVideoController.ConvertVideoWaveBackground(backgroundPath, videoPath, duration, Path.GetFullPath("Output/" + videoName));
				if (status)
				{
					for (int i = 0; i < 10; i++)
					{
						try
						{
							File.Move(videoPath, videoPath.Replace("VideoGoc\\", "VideoGoc\\DONE_"));
							break;
						}
						catch
						{
							Thread.Sleep(1000);
						}
					}
					FunctionHelper.AddLogs("Render video thành công!\n");
					Interlocked.Increment(ref _success);
					Invoke((MethodInvoker)delegate ()
					{
						lblSuccess.Text = _success.ToString();
					});

				}
				else
				{
					FunctionHelper.AddLogs("Render video bị lỗi!\n");
					Interlocked.Increment(ref _fail);
					Invoke((MethodInvoker)delegate ()
					{
						lblFail.Text = _fail.ToString();
					});
				}
			}
			Interlocked.Decrement(ref _threadRunning);
			Invoke((MethodInvoker)delegate ()
			{
				lblthreadRunning.Text = _threadRunning.ToString();
			});
			if (_threadRunning == 0)
			{
				Invoke(new MethodInvoker(() =>
				{
					btnStop.Enabled = false;
					btnStart.Enabled = true;
					timer1.Stop();
				}));

				MessageBox.Show("Tool đã dừng");
			}
		}
		private void OneThreadRenderAnime()
		{
			//ConvertVideoController convertVideoController = new ConvertVideoController();
			while (!stop)
			{
				//FunctionHelper.AddLogs("Bắt đầu render!");
				var backgroundPath = FunctionHelper.GetBackgroundVideoPath(Path.GetFullPath("Input/BackgroundVideo"));
				if (backgroundPath == "")
				{
					MessageBox.Show("Đã hết background video!");
					break;
				}
				var videoPath = FunctionHelper.GetVideoPath(Path.GetFullPath("Input/VideoGoc"));

				if (videoPath == "")
				{
					MessageBox.Show("Đã hết video !");
					break;
				}
				var videoName = new FileInfo(videoPath).Name;
				var duration = FunctionHelper.GetDuration(videoPath);
				var mockupPath = FunctionHelper.GetMockup(Path.GetFullPath("Input/Mockup"));
				if (mockupPath == "")
				{
					MessageBox.Show("Đã hết mockup!");
					break;
				}
				var status = ConvertVideoController.ConvertVideo(backgroundPath, videoPath, mockupPath, duration, Path.GetFullPath("Output/" + videoName));
				if (status)
				{
					for (int i = 0; i < 10; i++)
					{
						try
						{
							File.Move(videoPath, videoPath.Replace("VideoGoc\\", "VideoGoc\\DONE_"));
							break;
						}
						catch
						{
							Thread.Sleep(1000);
						}
					}
					FunctionHelper.AddLogs("Render video thành công!\n");
					Interlocked.Increment(ref _success);
					Invoke((MethodInvoker)delegate ()
					{
						lblSuccess.Text = _success.ToString();
					});

				}
				else
				{
					FunctionHelper.AddLogs("Render video bị lỗi!\n");
					Interlocked.Increment(ref _fail);
					Invoke((MethodInvoker)delegate ()
					{
						lblFail.Text = _fail.ToString();
					});
				}
			}
			Interlocked.Decrement(ref _threadRunning);
			Invoke((MethodInvoker)delegate ()
			{
				lblthreadRunning.Text = _threadRunning.ToString();
			});
			if (_threadRunning == 0)
			{
				Invoke(new MethodInvoker(() =>
				{
					btnStop.Enabled = false;
					btnStart.Enabled = true;
					timer1.Stop();
				}));

				MessageBox.Show("Tool đã dừng");
			}
		}
		private void timer1_Tick_1(object sender, EventArgs e)
		{
			lblTimeRunning.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
		}
	}
}