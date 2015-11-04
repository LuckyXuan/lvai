using System;
namespace la.Model
{
	/// <summary>
	/// 视频验证
	/// </summary>
	[Serializable]
	public partial class video
	{
		public video()
		{}
		#region Model
		private int _video_id;
		private string _user_telphone;
		private string _video_url;
		private DateTime? _video_uploadtime;
		private string _video_comment;
		private string _video_state;
		/// <summary>
		/// 视频ID
		/// </summary>
		public int video_ID
		{
			set{ _video_id=value;}
			get{return _video_id;}
		}
		/// <summary>
		/// 用户Phone
		/// </summary>
		public string user_telphone
		{
			set{ _user_telphone=value;}
			get{return _user_telphone;}
		}
		/// <summary>
		/// 视频路径
		/// </summary>
		public string video_url
		{
			set{ _video_url=value;}
			get{return _video_url;}
		}
		/// <summary>
		/// 视频上传时间
		/// </summary>
		public DateTime? video_uploadtime
		{
			set{ _video_uploadtime=value;}
			get{return _video_uploadtime;}
		}
		/// <summary>
		/// 视频说明
		/// </summary>
		public string video_comment
		{
			set{ _video_comment=value;}
			get{return _video_comment;}
		}
		/// <summary>
		/// 视频审核状态
		/// </summary>
		public string video_state
		{
			set{ _video_state=value;}
			get{return _video_state;}
		}
		#endregion Model

	}
}

