using System;
namespace la.Model
{
	/// <summary>
	/// 最后一次登录的地理位置，用于记录附近的人。
	/// </summary>
	[Serializable]
	public partial class gpslocation
	{
		public gpslocation()
		{}
		#region Model
		private int _gps_id;
		private string _user_telphone;
		private decimal? _location_lat;
		private decimal? _location_lng;
		/// <summary>
		/// gps定位编码
		/// </summary>
		public int gps_id
		{
			set{ _gps_id=value;}
			get{return _gps_id;}
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
		/// location_lat
		/// </summary>
		public decimal? location_lat
		{
			set{ _location_lat=value;}
			get{return _location_lat;}
		}
		/// <summary>
		/// location_lng
		/// </summary>
		public decimal? location_lng
		{
			set{ _location_lng=value;}
			get{return _location_lng;}
		}
		#endregion Model

	}
}

