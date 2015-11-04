using System;
namespace la.Model
{
	/// <summary>
	/// 拍的照片
	/// </summary>
	[Serializable]
	public partial class personphoto
	{
		public personphoto()
		{}
		#region Model
		private int _personphoto_id;
		private int _album_id;
		private string _personphoto_path;
		/// <summary>
		/// 相片ID
		/// </summary>
		public int personphoto_id
		{
			set{ _personphoto_id=value;}
			get{return _personphoto_id;}
		}
		/// <summary>
		/// 相册_id
		/// </summary>
		public int album_id
		{
			set{ _album_id=value;}
			get{return _album_id;}
		}
		/// <summary>
		/// 相片路径
		/// </summary>
		public string personphoto_path
		{
			set{ _personphoto_path=value;}
			get{return _personphoto_path;}
		}
		#endregion Model

	}
}

