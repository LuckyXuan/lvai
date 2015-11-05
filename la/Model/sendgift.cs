using System;
namespace la.Model
{
	/// <summary>
	/// 送礼，谁送给谁什么礼品，数量；说明
	/// </summary>
	[Serializable]
	public partial class sendgift
	{
		public sendgift()
		{}
		#region Model
		private int _sendgift_id;
		private int _virtualgoods_id;
		private int? _sender_id;
		private int? _accepter_id;
		private DateTime? _send_time;
		private string _sendgift_comment;
		private string _sendgift_msg;
		private int? _sendgift_count;
		/// <summary>
		/// 送礼ID
		/// </summary>
		public int sendgift_ID
		{
			set{ _sendgift_id=value;}
			get{return _sendgift_id;}
		}
		/// <summary>
		/// 虚拟物品ID
		/// </summary>
		public int virtualgoods_ID
		{
			set{ _virtualgoods_id=value;}
			get{return _virtualgoods_id;}
		}
		/// <summary>
		/// 送礼人
		/// </summary>
		public int? sender_id
		{
			set{ _sender_id=value;}
			get{return _sender_id;}
		}
		/// <summary>
		/// 接受人
		/// </summary>
		public int? accepter_id
		{
			set{ _accepter_id=value;}
			get{return _accepter_id;}
		}
		/// <summary>
		/// 送礼时间
		/// </summary>
		public DateTime? send_time
		{
			set{ _send_time=value;}
			get{return _send_time;}
		}
		/// <summary>
		/// 送礼说明
		/// </summary>
		public string sendgift_comment
		{
			set{ _sendgift_comment=value;}
			get{return _sendgift_comment;}
		}
		/// <summary>
		/// 送礼留言
		/// </summary>
		public string sendgift_msg
		{
			set{ _sendgift_msg=value;}
			get{return _sendgift_msg;}
		}
		/// <summary>
		/// 送礼数量
		/// </summary>
		public int? sendgift_count
		{
			set{ _sendgift_count=value;}
			get{return _sendgift_count;}
		}
		#endregion Model

	}
}

