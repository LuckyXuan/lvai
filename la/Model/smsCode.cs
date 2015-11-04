using System;
namespace la.Model
{
	/// <summary>
	/// 短信验证码以及短信时间
	/// </summary>
	[Serializable]
	public partial class smsCode
	{
		public smsCode()
		{}
		#region Model
		private int _smscode_id;
		private string _user_telphone;
		private DateTime? _smscode_sendtime;
		private string _smscode;
		/// <summary>
		/// 短信验证码编码
		/// </summary>
		public int smscode_id
		{
			set{ _smscode_id=value;}
			get{return _smscode_id;}
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
		/// 验证码发送时间
		/// </summary>
		public DateTime? smscode_sendtime
		{
			set{ _smscode_sendtime=value;}
			get{return _smscode_sendtime;}
		}
		/// <summary>
		/// 验证码
		/// </summary>
		public string smscode
		{
			set{ _smscode=value;}
			get{return _smscode;}
		}
		#endregion Model

	}
}

