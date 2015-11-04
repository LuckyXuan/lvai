using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:wealthindex
	/// </summary>
	public partial class wealthindex
	{
		public wealthindex()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("wealthindex_ID", "wealthindex"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int wealthindex_ID,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wealthindex");
			strSql.Append(" where wealthindex_ID=@wealthindex_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@wealthindex_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = wealthindex_ID;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.wealthindex model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wealthindex(");
			strSql.Append("wealthindex_ID,user_telphone,wealthindex_changevalue,wealthindex_time,wealthindex_comment,wealthindex_changetype,wealthindex_result)");
			strSql.Append(" values (");
			strSql.Append("@wealthindex_ID,@user_telphone,@wealthindex_changevalue,@wealthindex_time,@wealthindex_comment,@wealthindex_changetype,@wealthindex_result)");
			SqlParameter[] parameters = {
					new SqlParameter("@wealthindex_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@wealthindex_changevalue", SqlDbType.Float,8),
					new SqlParameter("@wealthindex_time", SqlDbType.DateTime),
					new SqlParameter("@wealthindex_comment", SqlDbType.VarChar,200),
					new SqlParameter("@wealthindex_changetype", SqlDbType.VarChar,50),
					new SqlParameter("@wealthindex_result", SqlDbType.Float,8)};
			parameters[0].Value = model.wealthindex_ID;
			parameters[1].Value = model.user_telphone;
			parameters[2].Value = model.wealthindex_changevalue;
			parameters[3].Value = model.wealthindex_time;
			parameters[4].Value = model.wealthindex_comment;
			parameters[5].Value = model.wealthindex_changetype;
			parameters[6].Value = model.wealthindex_result;

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
		public bool Update(la.Model.wealthindex model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wealthindex set ");
			strSql.Append("wealthindex_changevalue=@wealthindex_changevalue,");
			strSql.Append("wealthindex_time=@wealthindex_time,");
			strSql.Append("wealthindex_comment=@wealthindex_comment,");
			strSql.Append("wealthindex_changetype=@wealthindex_changetype,");
			strSql.Append("wealthindex_result=@wealthindex_result");
			strSql.Append(" where wealthindex_ID=@wealthindex_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@wealthindex_changevalue", SqlDbType.Float,8),
					new SqlParameter("@wealthindex_time", SqlDbType.DateTime),
					new SqlParameter("@wealthindex_comment", SqlDbType.VarChar,200),
					new SqlParameter("@wealthindex_changetype", SqlDbType.VarChar,50),
					new SqlParameter("@wealthindex_result", SqlDbType.Float,8),
					new SqlParameter("@wealthindex_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.wealthindex_changevalue;
			parameters[1].Value = model.wealthindex_time;
			parameters[2].Value = model.wealthindex_comment;
			parameters[3].Value = model.wealthindex_changetype;
			parameters[4].Value = model.wealthindex_result;
			parameters[5].Value = model.wealthindex_ID;
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
		public bool Delete(int wealthindex_ID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wealthindex ");
			strSql.Append(" where wealthindex_ID=@wealthindex_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@wealthindex_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = wealthindex_ID;
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
		public la.Model.wealthindex GetModel(int wealthindex_ID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 wealthindex_ID,user_telphone,wealthindex_changevalue,wealthindex_time,wealthindex_comment,wealthindex_changetype,wealthindex_result from wealthindex ");
			strSql.Append(" where wealthindex_ID=@wealthindex_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@wealthindex_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = wealthindex_ID;
			parameters[1].Value = user_telphone;

			la.Model.wealthindex model=new la.Model.wealthindex();
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
		public la.Model.wealthindex DataRowToModel(DataRow row)
		{
			la.Model.wealthindex model=new la.Model.wealthindex();
			if (row != null)
			{
				if(row["wealthindex_ID"]!=null && row["wealthindex_ID"].ToString()!="")
				{
					model.wealthindex_ID=int.Parse(row["wealthindex_ID"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["wealthindex_changevalue"]!=null && row["wealthindex_changevalue"].ToString()!="")
				{
					model.wealthindex_changevalue=decimal.Parse(row["wealthindex_changevalue"].ToString());
				}
				if(row["wealthindex_time"]!=null && row["wealthindex_time"].ToString()!="")
				{
					model.wealthindex_time=DateTime.Parse(row["wealthindex_time"].ToString());
				}
				if(row["wealthindex_comment"]!=null)
				{
					model.wealthindex_comment=row["wealthindex_comment"].ToString();
				}
				if(row["wealthindex_changetype"]!=null)
				{
					model.wealthindex_changetype=row["wealthindex_changetype"].ToString();
				}
				if(row["wealthindex_result"]!=null && row["wealthindex_result"].ToString()!="")
				{
					model.wealthindex_result=decimal.Parse(row["wealthindex_result"].ToString());
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
			strSql.Append("select wealthindex_ID,user_telphone,wealthindex_changevalue,wealthindex_time,wealthindex_comment,wealthindex_changetype,wealthindex_result ");
			strSql.Append(" FROM wealthindex ");
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
			strSql.Append(" wealthindex_ID,user_telphone,wealthindex_changevalue,wealthindex_time,wealthindex_comment,wealthindex_changetype,wealthindex_result ");
			strSql.Append(" FROM wealthindex ");
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
			strSql.Append("select count(1) FROM wealthindex ");
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
			strSql.Append(")AS Row, T.*  from wealthindex T ");
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
			parameters[0].Value = "wealthindex";
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

