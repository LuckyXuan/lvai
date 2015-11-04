using System;
namespace la.Model
{
	/// <summary>
	/// 用户的汽车信息，只能上传一辆车
	/// </summary>
	[Serializable]
	public partial class carInfo
	{
		public carInfo()
		{}
		#region Model
		private int _car_id;
		private string _user_telphone;
		private string _car_level;
		private string _car_brand;
		private string _car_type;
		private string _car_photo1;
		private string _car_photo2;
		private string _car_photo3;
		private string _car_photo1_state;
		private string _car_photo2_state;
		private string _car_photo3_state;
		/// <summary>
		/// 小车编码
		/// </summary>
		public int car_id
		{
			set{ _car_id=value;}
			get{return _car_id;}
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
		/// 车辆等级
		/// </summary>
		public string car_level
		{
			set{ _car_level=value;}
			get{return _car_level;}
		}
		/// <summary>
		/// 车辆牌子
		/// </summary>
		public string car_brand
		{
			set{ _car_brand=value;}
			get{return _car_brand;}
		}
		/// <summary>
		/// 车辆型号
		/// </summary>
		public string car_type
		{
			set{ _car_type=value;}
			get{return _car_type;}
		}
		/// <summary>
		/// 车辆图片1
		/// </summary>
		public string car_photo1
		{
			set{ _car_photo1=value;}
			get{return _car_photo1;}
		}
		/// <summary>
		/// 车辆图片2
		/// </summary>
		public string car_photo2
		{
			set{ _car_photo2=value;}
			get{return _car_photo2;}
		}
		/// <summary>
		/// 车辆图片3
		/// </summary>
		public string car_photo3
		{
			set{ _car_photo3=value;}
			get{return _car_photo3;}
		}
		/// <summary>
		/// 车辆图片1审核状态
		/// </summary>
		public string car_photo1_state
		{
			set{ _car_photo1_state=value;}
			get{return _car_photo1_state;}
		}
		/// <summary>
		/// 车辆图片2审核状态
		/// </summary>
		public string car_photo2_state
		{
			set{ _car_photo2_state=value;}
			get{return _car_photo2_state;}
		}
		/// <summary>
		/// 车辆图片3审核状态
		/// </summary>
		public string car_photo3_state
		{
			set{ _car_photo3_state=value;}
			get{return _car_photo3_state;}
		}
		#endregion Model

	}
}

