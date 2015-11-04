using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:looksindex
	/// </summary>
	public partial class looksindex
	{
		public looksindex()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("looksindex_id", "looksindex"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int looksindex_id,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from looksindex");
			strSql.Append(" where looksindex_id=@looksindex_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@looksindex_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = looksindex_id;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.looksindex model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into looksindex(");
			strSql.Append("looksindex_id,user_telphone,looksindex_change_value,looksindex_change_time,looksindex_change_comment,looksindex_result,looksindex_change_type)");
			strSql.Append(" values (");
			strSql.Append("@looksindex_id,@user_telphone,@looksindex_change_value,@looksindex_change_time,@looksindex_change_comment,@looksindex_result,@looksindex_change_type)");
			SqlParameter[] parameters = {
					new SqlParameter("@looksindex_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@looksindex_change_value", SqlDbType.Float,8),
					new SqlParameter("@looksindex_change_time", SqlDbType.DateTime),
					new SqlParameter("@looksindex_change_comment", SqlDbType.VarChar,200),
					new SqlParameter("@looksindex_result", SqlDbType.Float,8),
					new SqlParameter("@looksindex_change_type", SqlDbType.VarChar,30)};
			parameters[0].Value = model.looksindex_id;
			parameters[1].Value = model.user_telphone;
			parameters[2].Value = model.looksindex_change_value;
			parameters[3].Value = model.looksindex_change_time;
			parameters[4].Value = model.looksindex_change_comment;
			parameters[5].Value = model.looksindex_result;
			parameters[6].Value = model.looksindex_change_type;

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
		public bool Update(la.Model.looksindex model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update looksindex set ");
			strSql.Append("looksindex_change_value=@looksindex_change_value,");
			strSql.Append("looksindex_change_time=@looksindex_change_time,");
			strSql.Append("looksindex_change_comment=@looksindex_change_comment,");
			strSql.Append("looksindex_result=@looksindex_result,");
			strSql.Append("looksindex_change_type=@looksindex_change_type");
			strSql.Append(" where looksindex_id=@looksindex_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@looksindex_change_value", SqlDbType.Float,8),
					new SqlParameter("@looksindex_change_time", SqlDbType.DateTime),
					new SqlParameter("@looksindex_change_comment", SqlDbType.VarChar,200),
					new SqlParameter("@looksindex_result", SqlDbType.Float,8),
					new SqlParameter("@looksindex_change_type", SqlDbType.VarChar,30),
					new SqlParameter("@looksindex_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.looksindex_change_value;
			parameters[1].Value = model.looksindex_change_time;
			parameters[2].Value = model.looksindex_change_comment;
			parameters[3].Value = model.looksindex_result;
			parameters[4].Value = model.looksindex_change_type;
			parameters[5].Value = model.looksindex_id;
			parameters[6].Value = model.user_telphone;

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
		public bool Delete(int looksindex_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from looksindex ");
			strSql.Append(" where looksindex_id=@looksindex_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@looksindex_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = looksindex_id;
			parameters[1].Value = user_telphone;

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
		public la.Model.looksindex GetModel(int looksindex_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 looksindex_id,user_telphone,looksindex_change_value,looksindex_change_time,looksindex_change_comment,looksindex_result,looksindex_change_type from looksindex ");
			strSql.Append(" where looksindex_id=@looksindex_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@looksindex_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = looksindex_id;
			parameters[1].Value = user_telphone;

			la.Model.looksindex model=new la.Model.looksindex();
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
		public la.Model.looksindex DataRowToModel(DataRow row)
		{
			la.Model.looksindex model=new la.Model.looksindex();
			if (row != null)
			{
				if(row["looksindex_id"]!=null && row["looksindex_id"].ToString()!="")
				{
					model.looksindex_id=int.Parse(row["looksindex_id"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["looksindex_change_value"]!=null && row["looksindex_change_value"].ToString()!="")
				{
					model.looksindex_change_value=decimal.Parse(row["looksindex_change_value"].ToString());
				}
				if(row["looksindex_change_time"]!=null && row["looksindex_change_time"].ToString()!="")
				{
					model.looksindex_change_time=DateTime.Parse(row["looksindex_change_time"].ToString());
				}
				if(row["looksindex_change_comment"]!=null)
				{
					model.looksindex_change_comment=row["looksindex_change_comment"].ToString();
				}
				if(row["looksindex_result"]!=null && row["looksindex_result"].ToString()!="")
				{
					model.looksindex_result=decimal.Parse(row["looksindex_result"].ToString());
				}
				if(row["looksindex_change_type"]!=null)
				{
					model.looksindex_change_type=row["looksindex_change_type"].ToString();
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
			strSql.Append("select looksindex_id,user_telphone,looksindex_change_value,looksindex_change_time,looksindex_change_comment,looksindex_result,looksindex_change_type ");
			strSql.Append(" FROM looksindex ");
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
			strSql.Append(" looksindex_id,user_telphone,looksindex_change_value,looksindex_change_time,looksindex_change_comment,looksindex_result,looksindex_change_type ");
			strSql.Append(" FROM looksindex ");
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
			strSql.Append("select count(1) FROM looksindex ");
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
			strSql.Append(")AS Row, T.*  from looksindex T ");
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
			parameters[0].Value = "looksindex";
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

