using System;
namespace la.Model
{
	/// <summary>
	/// 信用积分。信用积分的变化情况。信用积分可能增加也可能减少.各种行为均会产生信用积分变化。
	/// </summary>
	[Serializable]
	public partial class credit
	{
		public credit()
		{}
		#region Model
		private int _credit_id;
		private string _user_telphone;
		private decimal? _credit_change;
		private string _creditchange_type;
		private DateTime? _creditchange_time;
		private decimal? _credit_balance;
		private string _creditchange_comment;
		/// <summary>
		/// 信用积分ID
		/// </summary>
		public int credit_id
		{
			set{ _credit_id=value;}
			get{return _credit_id;}
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
		/// 信用积分变化
		/// </summary>
		public decimal? credit_change
		{
			set{ _credit_change=value;}
			get{return _credit_change;}
		}
		/// <summary>
		/// 信用积分变化类型
		/// </summary>
		public string creditchange_type
		{
			set{ _creditchange_type=value;}
			get{return _creditchange_type;}
		}
		/// <summary>
		/// 信用积分变化时间
		/// </summary>
		public DateTime? creditchange_time
		{
			set{ _creditchange_time=value;}
			get{return _creditchange_time;}
		}
		/// <summary>
		/// 信用积分余额
		/// </summary>
		public decimal? credit_balance
		{
			set{ _credit_balance=value;}
			get{return _credit_balance;}
		}
		/// <summary>
		/// 信用积分变化说明
		/// </summary>
		public string creditchange_comment
		{
			set{ _creditchange_comment=value;}
			get{return _creditchange_comment;}
		}
		#endregion Model

	}
}

