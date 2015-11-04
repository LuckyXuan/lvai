using System;
namespace la.Model
{
	/// <summary>
	/// 人民币财富（单位元），充值后，人民币增加，人民币只能转化为旅币。购买旅币后，账户减少。
	/// </summary>
	[Serializable]
	public partial class account
	{
		public account()
		{}
		#region Model
		private int _account_id;
		private string _user_telphone;
		private decimal? _account_balance;
		private decimal? _account_change;
		private string _account_changetype;
		private DateTime? _account_change_time;
		private string _account_change_comment;
		/// <summary>
		/// 实际账户编码
		/// </summary>
		public int account_id
		{
			set{ _account_id=value;}
			get{return _account_id;}
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
		/// 账户余额
		/// </summary>
		public decimal? account_balance
		{
			set{ _account_balance=value;}
			get{return _account_balance;}
		}
		/// <summary>
		/// 账户变更数量
		/// </summary>
		public decimal? account_change
		{
			set{ _account_change=value;}
			get{return _account_change;}
		}
		/// <summary>
		/// 账户变更类型
		/// </summary>
		public string account_changetype
		{
			set{ _account_changetype=value;}
			get{return _account_changetype;}
		}
		/// <summary>
		/// 账户变更时间
		/// </summary>
		public DateTime? account_change_time
		{
			set{ _account_change_time=value;}
			get{return _account_change_time;}
		}
		/// <summary>
		/// 账户变更备注
		/// </summary>
		public string account_change_comment
		{
			set{ _account_change_comment=value;}
			get{return _account_change_comment;}
		}
		#endregion Model

	}
}

