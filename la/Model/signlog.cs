using System;
namespace la.Model
{
	/// <summary>
	/// 签到日志
	/// </summary>
	[Serializable]
	public partial class signlog
	{
		public signlog()
		{}
		#region Model
		private int _sign_id;
		private string _user_telphone;
		private DateTime? _sign_time;
		/// <summary>
		/// 签到编号
		/// </summary>
		public int sign_id
		{
			set{ _sign_id=value;}
			get{return _sign_id;}
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
		/// 签到时间
		/// </summary>
		public DateTime? sign_time
		{
			set{ _sign_time=value;}
			get{return _sign_time;}
		}
		#endregion Model

	}
}

