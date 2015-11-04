using System;
namespace la.Model
{
	/// <summary>
	/// 充值历史记录，会在财富表里面也进行体现。
	/// </summary>
	[Serializable]
	public partial class recharge
	{
		public recharge()
		{}
		#region Model
		private int _recharge_id;
		private string _user_telphone;
		private string _recharge_plat;
		private decimal? _recharge_money;
		private DateTime? _recharge_time;
		private string _recharge_code;
		private string _recharge_comment;
		/// <summary>
		/// 充值ID
		/// </summary>
		public int recharge_ID
		{
			set{ _recharge_id=value;}
			get{return _recharge_id;}
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
		/// 充值平台
		/// </summary>
		public string recharge_plat
		{
			set{ _recharge_plat=value;}
			get{return _recharge_plat;}
		}
		/// <summary>
		/// 充值金额
		/// </summary>
		public decimal? recharge_money
		{
			set{ _recharge_money=value;}
			get{return _recharge_money;}
		}
		/// <summary>
		/// 充值时间
		/// </summary>
		public DateTime? recharge_time
		{
			set{ _recharge_time=value;}
			get{return _recharge_time;}
		}
		/// <summary>
		/// 交易编码
		/// </summary>
		public string recharge_code
		{
			set{ _recharge_code=value;}
			get{return _recharge_code;}
		}
		/// <summary>
		/// 充值说明
		/// </summary>
		public string recharge_comment
		{
			set{ _recharge_comment=value;}
			get{return _recharge_comment;}
		}
		#endregion Model

	}
}

