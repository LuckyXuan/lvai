using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:ownvirtualgoods
	/// </summary>
	public partial class ownvirtualgoods
	{
		public ownvirtualgoods()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("property_ID", "ownvirtualgoods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int property_ID,int virtualgoods_ID,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ownvirtualgoods");
			strSql.Append(" where property_ID=@property_ID and virtualgoods_ID=@virtualgoods_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@property_ID", SqlDbType.Int,4),
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = property_ID;
			parameters[1].Value = virtualgoods_ID;
			parameters[2].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.ownvirtualgoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ownvirtualgoods(");
			strSql.Append("property_ID,virtualgoods_ID,user_telphone,property_count)");
			strSql.Append(" values (");
			strSql.Append("@property_ID,@virtualgoods_ID,@user_telphone,@property_count)");
			SqlParameter[] parameters = {
					new SqlParameter("@property_ID", SqlDbType.Int,4),
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@property_count", SqlDbType.Int,4)};
			parameters[0].Value = model.property_ID;
			parameters[1].Value = model.virtualgoods_ID;
			parameters[2].Value = model.user_telphone;
			parameters[3].Value = model.property_count;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(la.Model.ownvirtualgoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ownvirtualgoods set ");
			strSql.Append("property_count=@property_count");
			strSql.Append(" where property_ID=@property_ID and virtualgoods_ID=@virtualgoods_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@property_count", SqlDbType.Int,4),
					new SqlParameter("@property_ID", SqlDbType.Int,4),
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.property_count;
			parameters[1].Value = model.property_ID;
			parameters[2].Value = model.virtualgoods_ID;
			parameters[3].Value = model.user_telphone;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int property_ID,int virtualgoods_ID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ownvirtualgoods ");
			strSql.Append(" where property_ID=@property_ID and virtualgoods_ID=@virtualgoods_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@property_ID", SqlDbType.Int,4),
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = property_ID;
			parameters[1].Value = virtualgoods_ID;
			parameters[2].Value = user_telphone;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public la.Model.ownvirtualgoods GetModel(int property_ID,int virtualgoods_ID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 property_ID,virtualgoods_ID,user_telphone,property_count from ownvirtualgoods ");
			strSql.Append(" where property_ID=@property_ID and virtualgoods_ID=@virtualgoods_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@property_ID", SqlDbType.Int,4),
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = property_ID;
			parameters[1].Value = virtualgoods_ID;
			parameters[2].Value = user_telphone;

			la.Model.ownvirtualgoods model=new la.Model.ownvirtualgoods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public la.Model.ownvirtualgoods DataRowToModel(DataRow row)
		{
			la.Model.ownvirtualgoods model=new la.Model.ownvirtualgoods();
			if (row != null)
			{
				if(row["property_ID"]!=null && row["property_ID"].ToString()!="")
				{
					model.property_ID=int.Parse(row["property_ID"].ToString());
				}
				if(row["virtualgoods_ID"]!=null && row["virtualgoods_ID"].ToString()!="")
				{
					model.virtualgoods_ID=int.Parse(row["virtualgoods_ID"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["property_count"]!=null && row["property_count"].ToString()!="")
				{
					model.property_count=int.Parse(row["property_count"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select property_ID,virtualgoods_ID,user_telphone,property_count ");
			strSql.Append(" FROM ownvirtualgoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" property_ID,virtualgoods_ID,user_telphone,property_count ");
			strSql.Append(" FROM ownvirtualgoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ownvirtualgoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.user_telphone desc");
			}
			strSql.Append(")AS Row, T.*  from ownvirtualgoods T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "ownvirtualgoods";
			parameters[1].Value = "user_telphone";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

