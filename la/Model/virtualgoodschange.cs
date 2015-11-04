using System;
namespace la.Model
{
	/// <summary>
	/// 虚拟物品变化情况。花旅币购买虚拟物品，赠送，退现（只能兑出旅币）
	/// </summary>
	[Serializable]
	public partial class virtualgoodschange
	{
		public virtualgoodschange()
		{}
		#region Model
		private int _virtualgoodschange_id;
		private string _user_telphone;
		private int _virtualgoods_id;
		private int? _virtualgoodschange_count;
		private DateTime? _virtualgoodschange_time;
		private string _virtualgoodschange_comment;
		/// <summary>
		/// 虚拟物品变化记录ID
		/// </summary>
		public int virtualgoodschange_ID
		{
			set{ _virtualgoodschange_id=value;}
			get{return _virtualgoodschange_id;}
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
		/// 虚拟物品ID
		/// </summary>
		public int virtualgoods_ID
		{
			set{ _virtualgoods_id=value;}
			get{return _virtualgoods_id;}
		}
		/// <summary>
		/// 虚拟物品变化记录数量
		/// </summary>
		public int? virtualgoodschange_count
		{
			set{ _virtualgoodschange_count=value;}
			get{return _virtualgoodschange_count;}
		}
		/// <summary>
		/// 虚拟物品变化时间
		/// </summary>
		public DateTime? virtualgoodschange_time
		{
			set{ _virtualgoodschange_time=value;}
			get{return _virtualgoodschange_time;}
		}
		/// <summary>
		/// 虚拟物品变化记录说明
		/// </summary>
		public string virtualgoodschange_comment
		{
			set{ _virtualgoodschange_comment=value;}
			get{return _virtualgoodschange_comment;}
		}
		#endregion Model

	}
}

