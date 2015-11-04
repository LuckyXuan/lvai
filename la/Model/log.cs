using System;
namespace la.Model
{
	/// <summary>
	/// 登录日志，记录每次登录的GPS
	/// </summary>
	[Serializable]
	public partial class log
	{
		public log()
		{}
		#region Model
		private int _log_id;
		private string _user_telphone;
		private string _log_ip;
		private DateTime? _log_time;
		private decimal? _lat;
		private decimal? _lng;
		/// <summary>
		/// 日志编号
		/// </summary>
		public int log_id
		{
			set{ _log_id=value;}
			get{return _log_id;}
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
		/// 登录IP
		/// </summary>
		public string log_ip
		{
			set{ _log_ip=value;}
			get{return _log_ip;}
		}
		/// <summary>
		/// 登录时间
		/// </summary>
		public DateTime? log_time
		{
			set{ _log_time=value;}
			get{return _log_time;}
		}
		/// <summary>
		/// LAT
		/// </summary>
		public decimal? LAT
		{
			set{ _lat=value;}
			get{return _lat;}
		}
		/// <summary>
		/// LNG
		/// </summary>
		public decimal? LNG
		{
			set{ _lng=value;}
			get{return _lng;}
		}
		#endregion Model

	}
}

