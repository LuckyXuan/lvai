using System;
namespace la.Model
{
	/// <summary>
	/// 音频验证
	/// </summary>
	[Serializable]
	public partial class audio
	{
		public audio()
		{}
		#region Model
		private int _audio_id;
		private string _user_telphone;
		private string _audio_url;
		private DateTime? _audio_time;
		private string _audio_comment;
		private string _audio_state;
		/// <summary>
		/// 音频ID
		/// </summary>
		public int audio_id
		{
			set{ _audio_id=value;}
			get{return _audio_id;}
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
		/// 音频路径
		/// </summary>
		public string audio_url
		{
			set{ _audio_url=value;}
			get{return _audio_url;}
		}
		/// <summary>
		/// 上传时间
		/// </summary>
		public DateTime? audio_time
		{
			set{ _audio_time=value;}
			get{return _audio_time;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string audio_comment
		{
			set{ _audio_comment=value;}
			get{return _audio_comment;}
		}
		/// <summary>
		/// 审核状态
		/// </summary>
		public string audio_state
		{
			set{ _audio_state=value;}
			get{return _audio_state;}
		}
		#endregion Model

	}
}

