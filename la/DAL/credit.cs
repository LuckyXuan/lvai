using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:credit
	/// </summary>
	public partial class credit
	{
		public credit()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("credit_id", "credit"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int credit_id,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from credit");
			strSql.Append(" where credit_id=@credit_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@credit_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = credit_id;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.credit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into credit(");
			strSql.Append("credit_id,user_telphone,credit_change,creditchange_type,creditchange_time,credit_balance,creditchange_comment)");
			strSql.Append(" values (");
			strSql.Append("@credit_id,@user_telphone,@credit_change,@creditchange_type,@creditchange_time,@credit_balance,@creditchange_comment)");
			SqlParameter[] parameters = {
					new SqlParameter("@credit_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@credit_change", SqlDbType.Float,8),
					new SqlParameter("@creditchange_type", SqlDbType.VarChar,20),
					new SqlParameter("@creditchange_time", SqlDbType.DateTime),
					new SqlParameter("@credit_balance", SqlDbType.Float,8),
					new SqlParameter("@creditchange_comment", SqlDbType.VarChar,200)};
			parameters[0].Value = model.credit_id;
			parameters[1].Value = model.user_telphone;
			parameters[2].Value = model.credit_change;
			parameters[3].Value = model.creditchange_type;
			parameters[4].Value = model.creditchange_time;
			parameters[5].Value = model.credit_balance;
			parameters[6].Value = model.creditchange_comment;

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
		public bool Update(la.Model.credit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update credit set ");
			strSql.Append("credit_change=@credit_change,");
			strSql.Append("creditchange_type=@creditchange_type,");
			strSql.Append("creditchange_time=@creditchange_time,");
			strSql.Append("credit_balance=@credit_balance,");
			strSql.Append("creditchange_comment=@creditchange_comment");
			strSql.Append(" where credit_id=@credit_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@credit_change", SqlDbType.Float,8),
					new SqlParameter("@creditchange_type", SqlDbType.VarChar,20),
					new SqlParameter("@creditchange_time", SqlDbType.DateTime),
					new SqlParameter("@credit_balance", SqlDbType.Float,8),
					new SqlParameter("@creditchange_comment", SqlDbType.VarChar,200),
					new SqlParameter("@credit_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.credit_change;
			parameters[1].Value = model.creditchange_type;
			parameters[2].Value = model.creditchange_time;
			parameters[3].Value = model.credit_balance;
			parameters[4].Value = model.creditchange_comment;
			parameters[5].Value = model.credit_id;
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
		public bool Delete(int credit_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from credit ");
			strSql.Append(" where credit_id=@credit_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@credit_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = credit_id;
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
		public la.Model.credit GetModel(int credit_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 credit_id,user_telphone,credit_change,creditchange_type,creditchange_time,credit_balance,creditchange_comment from credit ");
			strSql.Append(" where credit_id=@credit_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@credit_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = credit_id;
			parameters[1].Value = user_telphone;

			la.Model.credit model=new la.Model.credit();
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
		public la.Model.credit DataRowToModel(DataRow row)
		{
			la.Model.credit model=new la.Model.credit();
			if (row != null)
			{
				if(row["credit_id"]!=null && row["credit_id"].ToString()!="")
				{
					model.credit_id=int.Parse(row["credit_id"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["credit_change"]!=null && row["credit_change"].ToString()!="")
				{
					model.credit_change=decimal.Parse(row["credit_change"].ToString());
				}
				if(row["creditchange_type"]!=null)
				{
					model.creditchange_type=row["creditchange_type"].ToString();
				}
				if(row["creditchange_time"]!=null && row["creditchange_time"].ToString()!="")
				{
					model.creditchange_time=DateTime.Parse(row["creditchange_time"].ToString());
				}
				if(row["credit_balance"]!=null && row["credit_balance"].ToString()!="")
				{
					model.credit_balance=decimal.Parse(row["credit_balance"].ToString());
				}
				if(row["creditchange_comment"]!=null)
				{
					model.creditchange_comment=row["creditchange_comment"].ToString();
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
			strSql.Append("select credit_id,user_telphone,credit_change,creditchange_type,creditchange_time,credit_balance,creditchange_comment ");
			strSql.Append(" FROM credit ");
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
			strSql.Append(" credit_id,user_telphone,credit_change,creditchange_type,creditchange_time,credit_balance,creditchange_comment ");
			strSql.Append(" FROM credit ");
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
			strSql.Append("select count(1) FROM credit ");
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
			strSql.Append(")AS Row, T.*  from credit T ");
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
			parameters[0].Value = "credit";
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

