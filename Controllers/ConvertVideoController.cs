using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Render_Video.Controllers
{
	public class ConvertVideoController
	{
		public ConvertVideoController()
		{

		}
		public static bool SplitVideo(string videoPath,double time, string outputPath)
		{

			Process process = new Process();

			// Đặt thông số của tiến trình
			ProcessStartInfo startInfo = new ProcessStartInfo()
			{
				FileName = "cmd.exe",  // Tên tệp thực thi (Command Prompt)
				Arguments = $"/c ffmpeg -i \"{videoPath}\" -vf \"[in]scale=iw*min(1080/iw\\,1920/ih):ih*min(1080/iw\\,1920/ih),pad=1080:1920:(1080-iw)/2:(1920-ih)/2[out]\" -c:a copy -f segment -segment_time {time} -reset_timestamps 1 \"{outputPath}\"",
				UseShellExecute = false,  // Sử dụng ShellExecute = false để tránh hiển thị cửa sổ Command Prompt
				WindowStyle = ProcessWindowStyle.Hidden,
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true  // Tạo cửa sổ mới (ẩn)
			};
			process.StartInfo = startInfo;
			// Khởi động tiến trình
			process.Start();
			process.StandardError.ReadToEnd();
			process.WaitForExit();
			// Kiểm tra mã lỗi của tiến trình
			int exitCode = process.ExitCode;
			if (exitCode != 0)
			{
				// Xử lý lỗi ở đây
				//Console.WriteLine("Tiến trình kết thúc với mã lỗi: " + exitCode);
				string errorMessage = process.StandardError.ReadToEnd();
				Console.WriteLine("Thông báo lỗi: " + errorMessage);

				return false;
			}
			process.Close();
			return true;
		}
		public static bool SpeedUpAndAddText(string videoPath,int partNumber, string originalTitle, string textContent, string outputPath)
		{

			Process process = new Process();

			// Đặt thông số của tiến trình
			ProcessStartInfo startInfo = new ProcessStartInfo()
			{
				FileName = "cmd.exe",  // Tên tệp thực thi (Command Prompt)
				Arguments = $"/c ffmpeg -i \"{videoPath}\" -filter_complex \"[0:v]setpts=PTS/1.2[v];[0:a]atempo=1.2[a];[v]drawtext=fontfile=BRITANIC.TTF:text='Part {partNumber}':fontcolor=black:fontsize=80:x=(w-text_w)/2:y=h-(h/10)-120:box=1:boxcolor=white:boxborderw=5,drawtext=fontfile=BRITANIC.TTF:text='{originalTitle}':fontcolor=black:fontsize=80:x=(w-text_w)/2:y=200:box=1:boxcolor=white:boxborderw=5{textContent}[outv]\" -map \"[outv]\" -map \"[a]\" -y \"{outputPath}\"",
				UseShellExecute = false,  // Sử dụng ShellExecute = false để tránh hiển thị cửa sổ Command Prompt
				WindowStyle = ProcessWindowStyle.Hidden,
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true  // Tạo cửa sổ mới (ẩn)
			};
			process.StartInfo = startInfo;
			// Khởi động tiến trình
			process.Start();
			process.StandardError.ReadToEnd();
			process.WaitForExit();
			// Kiểm tra mã lỗi của tiến trình
			int exitCode = process.ExitCode;
			if (exitCode != 0)
			{
				// Xử lý lỗi ở đây
				//Console.WriteLine("Tiến trình kết thúc với mã lỗi: " + exitCode);
				string errorMessage = process.StandardError.ReadToEnd();
				Console.WriteLine("Thông báo lỗi: " + errorMessage);

				return false;
			}
			process.Close();
			return true;
		}
		public static bool ConvertVideo(string backgroundPath, string videoPath,string mockupPath, double duration, string outputPath)
		{
			
			Process process = new Process();

			// Đặt thông số của tiến trình
			ProcessStartInfo startInfo = new ProcessStartInfo()
			{
				FileName = "cmd.exe",  // Tên tệp thực thi (Command Prompt)
				Arguments = $"/c ffmpeg -stream_loop 100 -i {backgroundPath} -i {videoPath} -i {mockupPath} -filter_complex \"[1:v]scale=w=680:h=384[v1]; [0:v][v1]overlay=x=(W-w)/2:y=(H-h)/2+50[outv]; [2:v]scale=700:880[overlay2]; [outv][overlay2]overlay=(W-w)/2:(H-h)/2[outv2]\" -map \"[outv2]\" -map 1:a -t {duration} -shortest {outputPath}",
				UseShellExecute = false,  // Sử dụng ShellExecute = false để tránh hiển thị cửa sổ Command Prompt
				WindowStyle= ProcessWindowStyle.Hidden,
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true  // Tạo cửa sổ mới (ẩn)
			};
			process.StartInfo = startInfo;
			// Khởi động tiến trình
			process.Start();
			process.StandardError.ReadToEnd();
			process.WaitForExit();
			// Kiểm tra mã lỗi của tiến trình
			int exitCode = process.ExitCode;
			if (exitCode != 0)
			{
				// Xử lý lỗi ở đây
				//Console.WriteLine("Tiến trình kết thúc với mã lỗi: " + exitCode);
				string errorMessage = process.StandardError.ReadToEnd();
				Console.WriteLine("Thông báo lỗi: " + errorMessage);

				return false;
			}
			process.Close();
			var durationOutput = FunctionHelper.GetDuration(outputPath);
			if (durationOutput != duration)
				return false;
			return true;
		}
        public static bool ConvertVideoWaveBackground(string backgroundPath, string videoPath, double duration, string outputPath)
        {

            Process process = new Process();

            // Đặt thông số của tiến trình
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",  // Tên tệp thực thi (Command Prompt)
                Arguments = $"/c ffmpeg -stream_loop 10 -i {backgroundPath} -i {videoPath} -filter_complex \"[1:v]scale=w=680:h=1200, hflip[v1]; [0:v][v1]overlay=x=(W-w)/4:y=(H-h)/2[outv]\" -map \"[outv]\" -map 1:a -t {duration} -shortest {outputPath}",
                UseShellExecute = false,  // Sử dụng ShellExecute = false để tránh hiển thị cửa sổ Command Prompt
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true  // Tạo cửa sổ mới (ẩn)
            };
            process.StartInfo = startInfo;
            // Khởi động tiến trình
            process.Start();
            process.StandardError.ReadToEnd();
            process.WaitForExit();
            // Kiểm tra mã lỗi của tiến trình
            int exitCode = process.ExitCode;
            if (exitCode != 0)
            {
                // Xử lý lỗi ở đây
                //Console.WriteLine("Tiến trình kết thúc với mã lỗi: " + exitCode);
                string errorMessage = process.StandardError.ReadToEnd();
                Console.WriteLine("Thông báo lỗi: " + errorMessage);

                return false;
            }
            process.Close();
            var durationOutput = FunctionHelper.GetDuration(outputPath);
            if (durationOutput != duration)
                return false;
            return true;
        }
    }
}
