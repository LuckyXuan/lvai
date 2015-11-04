using System;
namespace la.Model
{
	/// <summary>
	/// 用户的物品财产。
	/// </summary>
	[Serializable]
	public partial class ownvirtualgoods
	{
		public ownvirtualgoods()
		{}
		#region Model
		private int _property_id;
		private int _virtualgoods_id;
		private string _user_telphone;
		private int? _property_count;
		/// <summary>
		/// 财产ID
		/// </summary>
		public int property_ID
		{
			set{ _property_id=value;}
			get{return _property_id;}
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
		/// 用户Phone
		/// </summary>
		public string user_telphone
		{
			set{ _user_telphone=value;}
			get{return _user_telphone;}
		}
		/// <summary>
		/// 财产数量
		/// </summary>
		public int? property_count
		{
			set{ _property_count=value;}
			get{return _property_count;}
		}
		#endregion Model

	}
}

