using System;
namespace la.Model
{
	/// <summary>
	/// 发布的一次旅行
	/// </summary>
	[Serializable]
	public partial class travel
	{
		public travel()
		{}
		#region Model
		private int _travle_id;
		private int? _promoter_userid;
		private DateTime? _release_time;
		private string _destination;
		private string _startplace;
		private DateTime? _return_time;
		private DateTime? _start_time;
		private string _transportation;
		private string _fee;
		private string _travle_theme;
		private int? _travle_personcount;
		private string _companion_condition;
		private string _travle_msg;
		private string _pic1;
		private string _pic2;
		private string _pic3;
		private string _income_condition;
		private string _car_condition;
		private string _height_condition;
		private string _credit_condition;
		private string _wantget_gift;
		private string _wantsend_gift;
		private decimal? _reg_fee;
		/// <summary>
		/// 旅行ID
		/// </summary>
		public int travle_ID
		{
			set{ _travle_id=value;}
			get{return _travle_id;}
		}
		/// <summary>
		/// 发起人
		/// </summary>
		public int? promoter_userid
		{
			set{ _promoter_userid=value;}
			get{return _promoter_userid;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime? release_time
		{
			set{ _release_time=value;}
			get{return _release_time;}
		}
		/// <summary>
		/// 目的地
		/// </summary>
		public string Destination
		{
			set{ _destination=value;}
			get{return _destination;}
		}
		/// <summary>
		/// 出发地
		/// </summary>
		public string startplace
		{
			set{ _startplace=value;}
			get{return _startplace;}
		}
		/// <summary>
		/// 返回时间
		/// </summary>
		public DateTime? return_time
		{
			set{ _return_time=value;}
			get{return _return_time;}
		}
		/// <summary>
		/// 出发时间
		/// </summary>
		public DateTime? start_time
		{
			set{ _start_time=value;}
			get{return _start_time;}
		}
		/// <summary>
		/// 交通方式
		/// </summary>
		public string transportation
		{
			set{ _transportation=value;}
			get{return _transportation;}
		}
		/// <summary>
		/// 费用说明
		/// </summary>
		public string fee
		{
			set{ _fee=value;}
			get{return _fee;}
		}
		/// <summary>
		/// 旅行主题
		/// </summary>
		public string travle_theme
		{
			set{ _travle_theme=value;}
			get{return _travle_theme;}
		}
		/// <summary>
		/// 需要旅伴人数
		/// </summary>
		public int? travle_personcount
		{
			set{ _travle_personcount=value;}
			get{return _travle_personcount;}
		}
		/// <summary>
		/// 旅伴要求
		/// </summary>
		public string companion_condition
		{
			set{ _companion_condition=value;}
			get{return _companion_condition;}
		}
		/// <summary>
		/// 留言
		/// </summary>
		public string travle_msg
		{
			set{ _travle_msg=value;}
			get{return _travle_msg;}
		}
		/// <summary>
		/// 图1
		/// </summary>
		public string pic1
		{
			set{ _pic1=value;}
			get{return _pic1;}
		}
		/// <summary>
		/// 图2
		/// </summary>
		public string pic2
		{
			set{ _pic2=value;}
			get{return _pic2;}
		}
		/// <summary>
		/// 图3
		/// </summary>
		public string pic3
		{
			set{ _pic3=value;}
			get{return _pic3;}
		}
		/// <summary>
		/// 旅伴收入要求
		/// </summary>
		public string income_condition
		{
			set{ _income_condition=value;}
			get{return _income_condition;}
		}
		/// <summary>
		/// 旅伴车辆要求
		/// </summary>
		public string car_condition
		{
			set{ _car_condition=value;}
			get{return _car_condition;}
		}
		/// <summary>
		/// 旅伴身高要求
		/// </summary>
		public string height_condition
		{
			set{ _height_condition=value;}
			get{return _height_condition;}
		}
		/// <summary>
		/// 旅伴信用要求
		/// </summary>
		public string credit_condition
		{
			set{ _credit_condition=value;}
			get{return _credit_condition;}
		}
		/// <summary>
		/// 想得到的礼品
		/// </summary>
		public string wantget_gift
		{
			set{ _wantget_gift=value;}
			get{return _wantget_gift;}
		}
		/// <summary>
		/// 想送出的礼品
		/// </summary>
		public string wantsend_gift
		{
			set{ _wantsend_gift=value;}
			get{return _wantsend_gift;}
		}
		/// <summary>
		/// 报名费用（旅币)
		/// </summary>
		public decimal? reg_fee
		{
			set{ _reg_fee=value;}
			get{return _reg_fee;}
		}
		#endregion Model

	}
}

