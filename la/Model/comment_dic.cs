using System;
namespace la.Model
{
	/// <summary>
	/// 评价字典，评价只能从这个地方读取
	/// </summary>
	[Serializable]
	public partial class comment_dic
	{
		public comment_dic()
		{}
		#region Model
		private int _评价字典编号;
		private string _评价字典内容;
		private int? _对应分值;
		/// <summary>
		/// 评价字典编号
		/// </summary>
		public int 评价字典编号
		{
			set{ _评价字典编号=value;}
			get{return _评价字典编号;}
		}
		/// <summary>
		/// 评价字典内容
		/// </summary>
		public string 评价字典内容
		{
			set{ _评价字典内容=value;}
			get{return _评价字典内容;}
		}
		/// <summary>
		/// 对应分值
		/// </summary>
		public int? 对应分值
		{
			set{ _对应分值=value;}
			get{return _对应分值;}
		}
		#endregion Model

	}
}

