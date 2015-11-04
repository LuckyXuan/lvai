using System;
namespace la.Model
{
	/// <summary>
	/// 才艺指数变化历史。
	/// </summary>
	[Serializable]
	public partial class talent
	{
		public talent()
		{}
		#region Model
		private int _talent_id;
		private string _user_telphone;
		private decimal? _talent_change_value;
		private string _talent_change_comment;
		private DateTime? _talent_change_time;
		private string _talent_change_type;
		private decimal? _talent_result;
		/// <summary>
		/// 才艺指数ID
		/// </summary>
		public int talent_ID
		{
			set{ _talent_id=value;}
			get{return _talent_id;}
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
		/// 才艺指数变化值
		/// </summary>
		public decimal? talent_change_value
		{
			set{ _talent_change_value=value;}
			get{return _talent_change_value;}
		}
		/// <summary>
		/// 才艺指数变化说明
		/// </summary>
		public string talent_change_comment
		{
			set{ _talent_change_comment=value;}
			get{return _talent_change_comment;}
		}
		/// <summary>
		/// 才艺指数变化时间
		/// </summary>
		public DateTime? talent_change_time
		{
			set{ _talent_change_time=value;}
			get{return _talent_change_time;}
		}
		/// <summary>
		/// 才艺指数变化类型
		/// </summary>
		public string talent_change_type
		{
			set{ _talent_change_type=value;}
			get{return _talent_change_type;}
		}
		/// <summary>
		/// 才艺指数结果
		/// </summary>
		public decimal? talent_result
		{
			set{ _talent_result=value;}
			get{return _talent_result;}
		}
		#endregion Model

	}
}

