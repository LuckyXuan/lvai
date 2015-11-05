using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:log
	/// </summary>
	public partial class log
	{
		public log()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("log_id", "log"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int log_id,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from log");
			strSql.Append(" where log_id=@log_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@log_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = log_id;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into log(");
			strSql.Append("user_telphone,log_ip,log_time,LAT,LNG)");
			strSql.Append(" values (");
			strSql.Append("@user_telphone,@log_ip,@log_time,@LAT,@LNG)");
			SqlParameter[] parameters = {
					
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@log_ip", SqlDbType.VarChar,20),
					new SqlParameter("@log_time", SqlDbType.DateTime),
					new SqlParameter("@LAT", SqlDbType.Decimal,9),
					new SqlParameter("@LNG", SqlDbType.Decimal,9)};
			
			parameters[0].Value = model.user_telphone;
			parameters[1].Value = model.log_ip;
			parameters[2].Value = model.log_time;
			parameters[3].Value = model.LAT;
			parameters[4].Value = model.LNG;

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
		public bool Update(la.Model.log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update log set ");
			strSql.Append("log_ip=@log_ip,");
			strSql.Append("log_time=@log_time,");
			strSql.Append("LAT=@LAT,");
			strSql.Append("LNG=@LNG");
			strSql.Append(" where log_id=@log_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@log_ip", SqlDbType.VarChar,20),
					new SqlParameter("@log_time", SqlDbType.DateTime),
					new SqlParameter("@LAT", SqlDbType.Decimal,9),
					new SqlParameter("@LNG", SqlDbType.Decimal,9),
					new SqlParameter("@log_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.log_ip;
			parameters[1].Value = model.log_time;
			parameters[2].Value = model.LAT;
			parameters[3].Value = model.LNG;
			parameters[4].Value = model.log_id;
			parameters[5].Value = model.user_telphone;

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
		public bool Delete(int log_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from log ");
			strSql.Append(" where log_id=@log_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@log_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = log_id;
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
		public la.Model.log GetModel(int log_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 log_id,user_telphone,log_ip,log_time,LAT,LNG from log ");
			strSql.Append(" where log_id=@log_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@log_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = log_id;
			parameters[1].Value = user_telphone;

			la.Model.log model=new la.Model.log();
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
		public la.Model.log DataRowToModel(DataRow row)
		{
			la.Model.log model=new la.Model.log();
			if (row != null)
			{
				if(row["log_id"]!=null && row["log_id"].ToString()!="")
				{
					model.log_id=int.Parse(row["log_id"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["log_ip"]!=null)
				{
					model.log_ip=row["log_ip"].ToString();
				}
				if(row["log_time"]!=null && row["log_time"].ToString()!="")
				{
					model.log_time=DateTime.Parse(row["log_time"].ToString());
				}
				if(row["LAT"]!=null && row["LAT"].ToString()!="")
				{
					model.LAT=decimal.Parse(row["LAT"].ToString());
				}
				if(row["LNG"]!=null && row["LNG"].ToString()!="")
				{
					model.LNG=decimal.Parse(row["LNG"].ToString());
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
			strSql.Append("select log_id,user_telphone,log_ip,log_time,LAT,LNG ");
			strSql.Append(" FROM log ");
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
			strSql.Append(" log_id,user_telphone,log_ip,log_time,LAT,LNG ");
			strSql.Append(" FROM log ");
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
			strSql.Append("select count(1) FROM log ");
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
			strSql.Append(")AS Row, T.*  from log T ");
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
			parameters[0].Value = "log";
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

