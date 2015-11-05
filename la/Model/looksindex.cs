using System;
namespace la.Model
{
	/// <summary>
	/// 容貌指数变化情况
	/// </summary>
	[Serializable]
	public partial class looksindex
	{
		public looksindex()
		{}
		#region Model
		private int _looksindex_id;
		private string _user_telphone;
		private decimal? _looksindex_change_value;
		private DateTime? _looksindex_change_time;
		private string _looksindex_change_comment;
		private decimal? _looksindex_result;
		private string _looksindex_change_type;
		/// <summary>
		/// 容貌指数ID
		/// </summary>
		public int looksindex_id
		{
			set{ _looksindex_id=value;}
			get{return _looksindex_id;}
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
		/// 容貌指数变化值
		/// </summary>
		public decimal? looksindex_change_value
		{
			set{ _looksindex_change_value=value;}
			get{return _looksindex_change_value;}
		}
		/// <summary>
		/// 容貌指数变化时间
		/// </summary>
		public DateTime? looksindex_change_time
		{
			set{ _looksindex_change_time=value;}
			get{return _looksindex_change_time;}
		}
		/// <summary>
		/// 容貌指数变化说明
		/// </summary>
		public string looksindex_change_comment
		{
			set{ _looksindex_change_comment=value;}
			get{return _looksindex_change_comment;}
		}
		/// <summary>
		/// 容貌指数结果
		/// </summary>
		public decimal? looksindex_result
		{
			set{ _looksindex_result=value;}
			get{return _looksindex_result;}
		}
		/// <summary>
		/// 容貌指数变化类型
		/// </summary>
		public string looksindex_change_type
		{
			set{ _looksindex_change_type=value;}
			get{return _looksindex_change_type;}
		}
		#endregion Model

	}
}

