using System;
namespace la.Model
{
	/// <summary>
	/// 发布的一次旅行，可能有多个人申请，但是只有一个人是配对成功的，其他的是等待确认，只有一个是同意配对。（状态）
	/// </summary>
	[Serializable]
	public partial class travleapply
	{
		public travleapply()
		{}
		#region Model
		private int _travleapply_id;
		private int _travle_id;
		private int? _applyer_id;
		private DateTime? _apply_time;
		private string _apply_state;
		private string _apply_msg;
		/// <summary>
		/// 申请ID
		/// </summary>
		public int travleapply_ID
		{
			set{ _travleapply_id=value;}
			get{return _travleapply_id;}
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
		/// 申请人ID
		/// </summary>
		public int? applyer_ID
		{
			set{ _applyer_id=value;}
			get{return _applyer_id;}
		}
		/// <summary>
		/// 申请时间
		/// </summary>
		public DateTime? apply_time
		{
			set{ _apply_time=value;}
			get{return _apply_time;}
		}
		/// <summary>
		/// 匹配状态
		/// </summary>
		public string apply_state
		{
			set{ _apply_state=value;}
			get{return _apply_state;}
		}
		/// <summary>
		/// 申请留言
		/// </summary>
		public string apply_msg
		{
			set{ _apply_msg=value;}
			get{return _apply_msg;}
		}
		#endregion Model

	}
}

