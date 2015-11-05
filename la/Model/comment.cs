using System;
namespace la.Model
{
	/// <summary>
	/// 对一次旅行的评价，评价内容只能来源于字典。
	/// </summary>
	[Serializable]
	public partial class comment
	{
		public comment()
		{}
		#region Model
		private int _评价编号;
		private int _travle_id;
		private string _user_telphone;
		private int _评价字典编号;
		private DateTime? _评价时间;
		/// <summary>
		/// 评价编号
		/// </summary>
		public int 评价编号
		{
			set{ _评价编号=value;}
			get{return _评价编号;}
		}
		/// <summary>
		/// 旅行ID
		/// </summary>
		public int travle_ID
		{
			set{ _travle_id=value;}
			get{return _travle_id;}
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
		/// 评价字典编号
		/// </summary>
		public int 评价字典编号
		{
			set{ _评价字典编号=value;}
			get{return _评价字典编号;}
		}
		/// <summary>
		/// 评价时间
		/// </summary>
		public DateTime? 评价时间
		{
			set{ _评价时间=value;}
			get{return _评价时间;}
		}
		#endregion Model

	}
}

