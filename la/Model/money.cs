using System;
namespace la.Model
{
	/// <summary>
	/// 财富（单位旅币）。财富变化情况。当充值后，财富会增加，当消费后，财富会减少。财富变化类型：充值;礼品替换；查看消费;购买礼品消费；
	/// </summary>
	[Serializable]
	public partial class money
	{
		public money()
		{}
		#region Model
		private int _money_id;
		private string _user_telphone;
		private decimal? _money_change;
		private DateTime? _moneychange_time;
		private string _moneychange_comment;
		private decimal? _money_balance;
		private string _moneychange_type;
		/// <summary>
		/// 财富ID
		/// </summary>
		public int money_id
		{
			set{ _money_id=value;}
			get{return _money_id;}
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
		/// 财富变化
		/// </summary>
		public decimal? money_change
		{
			set{ _money_change=value;}
			get{return _money_change;}
		}
		/// <summary>
		/// 财富变化时间
		/// </summary>
		public DateTime? moneychange_time
		{
			set{ _moneychange_time=value;}
			get{return _moneychange_time;}
		}
		/// <summary>
		/// 财富变化说明
		/// </summary>
		public string moneychange_comment
		{
			set{ _moneychange_comment=value;}
			get{return _moneychange_comment;}
		}
		/// <summary>
		/// 余额
		/// </summary>
		public decimal? money_balance
		{
			set{ _money_balance=value;}
			get{return _money_balance;}
		}
		/// <summary>
		/// 财富变化类型
		/// </summary>
		public string moneychange_type
		{
			set{ _moneychange_type=value;}
			get{return _moneychange_type;}
		}
		#endregion Model

	}
}

