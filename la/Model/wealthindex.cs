using System;
namespace la.Model
{
	/// <summary>
	/// 记录财富指数变化情况。财富指数随着用户的充值，购买礼品，送礼品使用会发生变化。每一次消费或者充值均会修改这里的数据。
	/// </summary>
	[Serializable]
	public partial class wealthindex
	{
		public wealthindex()
		{}
		#region Model
		private int _wealthindex_id;
		private string _user_telphone;
		private decimal? _wealthindex_changevalue;
		private DateTime? _wealthindex_time;
		private string _wealthindex_comment;
		private string _wealthindex_changetype;
		private decimal? _wealthindex_result;
		/// <summary>
		/// 财富指数ID
		/// </summary>
		public int wealthindex_ID
		{
			set{ _wealthindex_id=value;}
			get{return _wealthindex_id;}
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
		/// 财富指数变化值
		/// </summary>
		public decimal? wealthindex_changevalue
		{
			set{ _wealthindex_changevalue=value;}
			get{return _wealthindex_changevalue;}
		}
		/// <summary>
		/// 财富指数变化时间
		/// </summary>
		public DateTime? wealthindex_time
		{
			set{ _wealthindex_time=value;}
			get{return _wealthindex_time;}
		}
		/// <summary>
		/// 财富指数变化说明
		/// </summary>
		public string wealthindex_comment
		{
			set{ _wealthindex_comment=value;}
			get{return _wealthindex_comment;}
		}
		/// <summary>
		/// 财富指数变化类型
		/// </summary>
		public string wealthindex_changetype
		{
			set{ _wealthindex_changetype=value;}
			get{return _wealthindex_changetype;}
		}
		/// <summary>
		/// 财富指数结果
		/// </summary>
		public decimal? wealthindex_result
		{
			set{ _wealthindex_result=value;}
			get{return _wealthindex_result;}
		}
		#endregion Model

	}
}

