using System;
namespace la.Model
{
	/// <summary>
	/// 虚拟物品字典。
	/// </summary>
	[Serializable]
	public partial class virtualgoods
	{
		public virtualgoods()
		{}
		#region Model
		private int _virtualgoods_id;
		private string _virtualgoods_name;
		private decimal? _virtualgoods_price;
		private string _virtualgoods_comment;
		private string _virtualgoods_pic_url;
		private string _virtualgoods_type;
		private string _virtualgoods_fun;
		/// <summary>
		/// 虚拟物品ID
		/// </summary>
		public int virtualgoods_ID
		{
			set{ _virtualgoods_id=value;}
			get{return _virtualgoods_id;}
		}
		/// <summary>
		/// 虚拟物品名称
		/// </summary>
		public string virtualgoods_name
		{
			set{ _virtualgoods_name=value;}
			get{return _virtualgoods_name;}
		}
		/// <summary>
		/// 虚拟物品价格
		/// </summary>
		public decimal? virtualgoods_price
		{
			set{ _virtualgoods_price=value;}
			get{return _virtualgoods_price;}
		}
		/// <summary>
		/// 虚拟物品说明
		/// </summary>
		public string virtualgoods_comment
		{
			set{ _virtualgoods_comment=value;}
			get{return _virtualgoods_comment;}
		}
		/// <summary>
		/// 虚拟物品图片
		/// </summary>
		public string virtualgoods_pic_url
		{
			set{ _virtualgoods_pic_url=value;}
			get{return _virtualgoods_pic_url;}
		}
		/// <summary>
		/// 虚拟物品类别
		/// </summary>
		public string virtualgoods_type
		{
			set{ _virtualgoods_type=value;}
			get{return _virtualgoods_type;}
		}
		/// <summary>
		/// 虚拟物品功能
		/// </summary>
		public string virtualgoods_fun
		{
			set{ _virtualgoods_fun=value;}
			get{return _virtualgoods_fun;}
		}
		#endregion Model

	}
}

