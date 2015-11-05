using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using la.Model;
namespace la.BLL
{
	/// <summary>
	/// 才艺指数变化历史。
	/// </summary>
	public partial class talent
	{
		private readonly la.DAL.talent dal=new la.DAL.talent();
		public talent()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int talent_ID,string user_telphone)
		{
			return dal.Exists(talent_ID,user_telphone);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.talent model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(la.Model.talent model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int talent_ID,string user_telphone)
		{
			
			return dal.Delete(talent_ID,user_telphone);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public la.Model.talent GetModel(int talent_ID,string user_telphone)
		{
			
			return dal.GetModel(talent_ID,user_telphone);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public la.Model.talent GetModelByCache(int talent_ID,string user_telphone)
		{
			
			string CacheKey = "talentModel-" + talent_ID+user_telphone;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(talent_ID,user_telphone);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (la.Model.talent)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<la.Model.talent> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<la.Model.talent> DataTableToList(DataTable dt)
		{
			List<la.Model.talent> modelList = new List<la.Model.talent>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				la.Model.talent model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

