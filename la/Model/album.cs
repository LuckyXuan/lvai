using System;
using System.Collections.Generic;
namespace la.Model
{
	/// <summary>
	/// 相册，每次只能上传9张以内作为一个相册。相册直接按照上传的时间作为一组，不再另行管理
	/// </summary>
	[Serializable]
	public partial class album
	{
		public album()
		{}
		#region Model
		private int _album_id;
		private string _user_telphone;
		private DateTime? _album_time;
		private string _album_comment;
		private bool _album_isvalid;
		private bool _album_isprivate;
        private List<Model.personphoto> _photoList=new List<personphoto>();

        public List<Model.personphoto> PhotoList
        {
            get { return _photoList; }
            set { _photoList = value; }
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
		/// 用户Phone
		/// </summary>
		public string user_telphone
		{
			set{ _user_telphone=value;}
			get{return _user_telphone;}
		}
		/// <summary>
		/// 相册上传时间
		/// </summary>
		public DateTime? album_time
		{
			set{ _album_time=value;}
			get{return _album_time;}
		}
		/// <summary>
		/// 相册说明
		/// </summary>
		public string album_comment
		{
			set{ _album_comment=value;}
			get{return _album_comment;}
		}
		/// <summary>
		/// 是否有效
		/// </summary>
		public bool album_isvalid
		{
			set{ _album_isvalid=value;}
			get{return _album_isvalid;}
		}
		/// <summary>
		/// 是否私密相册
		/// </summary>
		public bool album_isprivate
		{
			set{ _album_isprivate=value;}
			get{return _album_isprivate;}
		}

		#endregion Model

	}
}

