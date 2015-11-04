using System;
namespace la.Model
{
	/// <summary>
	/// 发送的短信，发送短信的可能性。短信验证码，广告，登录提醒，广告提醒等等，统计短信缴费记录
	/// </summary>
	[Serializable]
	public partial class sms
	{
		public sms()
		{}
		#region Model
		private int _sms_id;
		private string _user_telphone;
		private string _sms_content;
		private DateTime? _sms_time;
		private string _sms_comment;
		private bool _sms_ispay;
		/// <summary>
		/// 短信编码
		/// </summary>
		public int sms_id
		{
			set{ _sms_id=value;}
			get{return _sms_id;}
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
		/// 短信内容
		/// </summary>
		public string sms_content
		{
			set{ _sms_content=value;}
			get{return _sms_content;}
		}
		/// <summary>
		/// 发送时间
		/// </summary>
		public DateTime? sms_time
		{
			set{ _sms_time=value;}
			get{return _sms_time;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string sms_comment
		{
			set{ _sms_comment=value;}
			get{return _sms_comment;}
		}
		/// <summary>
		/// 是否缴费
		/// </summary>
		public bool sms_ispay
		{
			set{ _sms_ispay=value;}
			get{return _sms_ispay;}
		}
		#endregion Model

	}
}

