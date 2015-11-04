using System;
namespace la.Model
{
	/// <summary>
	/// vip等级历史变化情况
	/// </summary>
	[Serializable]
	public partial class VIP
	{
		public VIP()
		{}
		#region Model
		private int _vipid;
		private string _user_telphone;
		private decimal? _vip_change_credit;
		private string _vip_change_comment;
		private DateTime? _vip_change_time;
		private decimal? _vip_credit;
		private int? _vip_level;
		private string _vip_change_type;
		/// <summary>
		/// VIPID
		/// </summary>
		public int VIPID
		{
			set{ _vipid=value;}
			get{return _vipid;}
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
		/// VIP变化积分
		/// </summary>
		public decimal? VIP_change_credit
		{
			set{ _vip_change_credit=value;}
			get{return _vip_change_credit;}
		}
		/// <summary>
		/// VIP变化原因
		/// </summary>
		public string VIP_change_comment
		{
			set{ _vip_change_comment=value;}
			get{return _vip_change_comment;}
		}
		/// <summary>
		/// VIP变化时间
		/// </summary>
		public DateTime? VIP_change_time
		{
			set{ _vip_change_time=value;}
			get{return _vip_change_time;}
		}
		/// <summary>
		/// VIP积分值
		/// </summary>
		public decimal? VIP_credit
		{
			set{ _vip_credit=value;}
			get{return _vip_credit;}
		}
		/// <summary>
		/// VIP变化后等级
		/// </summary>
		public int? VIP_level
		{
			set{ _vip_level=value;}
			get{return _vip_level;}
		}
		/// <summary>
		/// VIP积分变化类型
		/// </summary>
		public string VIP_change_type
		{
			set{ _vip_change_type=value;}
			get{return _vip_change_type;}
		}
		#endregion Model

	}
}

