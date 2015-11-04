using System;
namespace la.Model
{
	/// <summary>
	/// 用户表
	/// </summary>
	[Serializable]
	public partial class user_tb
	{
		public user_tb()
		{}
		#region Model
		private string _user_telphone;
		private bool _user_sex;
		private string _user_nikename;
		private string _user_photo;
		private DateTime? _user_birthday;
		private string _user_height;
		private string _user_weight;
		private string _user_address;
		private string _user_job;
		private string _user_income;
		private string _user_pwd;
		private string _user_marrystate;
		private string _user_edu;
		private string _personcenter_bg;
		private string _user_photo_state;
		private string _user_state;
		/// <summary>
		/// 用户Phone
		/// </summary>
		public string user_telphone
		{
			set{ _user_telphone=value;}
			get{return _user_telphone;}
		}
		/// <summary>
		/// 用户性别
		/// </summary>
		public bool user_sex
		{
			set{ _user_sex=value;}
			get{return _user_sex;}
		}
		/// <summary>
		/// 用户昵称
		/// </summary>
		public string user_nikeName
		{
			set{ _user_nikename=value;}
			get{return _user_nikename;}
		}
		/// <summary>
		/// 用户头像
		/// </summary>
		public string user_photo
		{
			set{ _user_photo=value;}
			get{return _user_photo;}
		}
		/// <summary>
		/// 出生年月
		/// </summary>
		public DateTime? user_birthday
		{
			set{ _user_birthday=value;}
			get{return _user_birthday;}
		}
		/// <summary>
		/// 身高
		/// </summary>
		public string user_height
		{
			set{ _user_height=value;}
			get{return _user_height;}
		}
		/// <summary>
		/// 体重
		/// </summary>
		public string user_weight
		{
			set{ _user_weight=value;}
			get{return _user_weight;}
		}
		/// <summary>
		/// 常住地
		/// </summary>
		public string user_address
		{
			set{ _user_address=value;}
			get{return _user_address;}
		}
		/// <summary>
		/// 职业
		/// </summary>
		public string user_job
		{
			set{ _user_job=value;}
			get{return _user_job;}
		}
		/// <summary>
		/// 年收入
		/// </summary>
		public string user_income
		{
			set{ _user_income=value;}
			get{return _user_income;}
		}
		/// <summary>
		/// 用户密码
		/// </summary>
		public string user_pwd
		{
			set{ _user_pwd=value;}
			get{return _user_pwd;}
		}
		/// <summary>
		/// 感情状况
		/// </summary>
		public string user_marrystate
		{
			set{ _user_marrystate=value;}
			get{return _user_marrystate;}
		}
		/// <summary>
		/// 学历
		/// </summary>
		public string user_edu
		{
			set{ _user_edu=value;}
			get{return _user_edu;}
		}
		/// <summary>
		/// 个人中心背景
		/// </summary>
		public string personcenter_bg
		{
			set{ _personcenter_bg=value;}
			get{return _personcenter_bg;}
		}
		/// <summary>
		/// 头像审核状态
		/// </summary>
		public string user_photo_state
		{
			set{ _user_photo_state=value;}
			get{return _user_photo_state;}
		}
		/// <summary>
		/// 用户状态
		/// </summary>
		public string user_state
		{
			set{ _user_state=value;}
			get{return _user_state;}
		}
		#endregion Model

	}
}

