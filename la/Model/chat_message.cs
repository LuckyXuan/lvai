using System;
namespace la.Model
{
	/// <summary>
	/// 聊天记录，记住系统也是一个用户，可以和用户聊天留言
	/// </summary>
	[Serializable]
	public partial class chat_message
	{
		public chat_message()
		{}
		#region Model
		private int _chat_id;
		private int? _chat_from;
		private int? _chat_to;
		private string _chat_content;
		private DateTime? _chat_time;
		private string _chat_comment;
		private string _chat_state;
		/// <summary>
		/// 聊天记录ID
		/// </summary>
		public int chat_ID
		{
			set{ _chat_id=value;}
			get{return _chat_id;}
		}
		/// <summary>
		/// 聊天记录FROM
		/// </summary>
		public int? chat_FROM
		{
			set{ _chat_from=value;}
			get{return _chat_from;}
		}
		/// <summary>
		/// 聊天记录TO
		/// </summary>
		public int? chat_TO
		{
			set{ _chat_to=value;}
			get{return _chat_to;}
		}
		/// <summary>
		/// 聊天内容
		/// </summary>
		public string chat_content
		{
			set{ _chat_content=value;}
			get{return _chat_content;}
		}
		/// <summary>
		/// 聊天时间
		/// </summary>
		public DateTime? chat_time
		{
			set{ _chat_time=value;}
			get{return _chat_time;}
		}
		/// <summary>
		/// 聊天备注
		/// </summary>
		public string chat_comment
		{
			set{ _chat_comment=value;}
			get{return _chat_comment;}
		}
		/// <summary>
		/// 聊天记录状态
		/// </summary>
		public string chat_state
		{
			set{ _chat_state=value;}
			get{return _chat_state;}
		}
		#endregion Model

	}
}

