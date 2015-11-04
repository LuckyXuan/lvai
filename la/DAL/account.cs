using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:account
	/// </summary>
	public partial class account
	{
		public account()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("account_id", "account"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int account_id,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from account");
			strSql.Append(" where account_id=@account_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@account_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = account_id;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.account model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into account(");
			strSql.Append("account_id,user_telphone,account_balance,account_change,account_changetype,account_change_time,account_change_comment)");
			strSql.Append(" values (");
			strSql.Append("@account_id,@user_telphone,@account_balance,@account_change,@account_changetype,@account_change_time,@account_change_comment)");
			SqlParameter[] parameters = {
					new SqlParameter("@account_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@account_balance", SqlDbType.Float,8),
					new SqlParameter("@account_change", SqlDbType.Float,8),
					new SqlParameter("@account_changetype", SqlDbType.VarChar,30),
					new SqlParameter("@account_change_time", SqlDbType.DateTime),
					new SqlParameter("@account_change_comment", SqlDbType.VarChar,200)};
			parameters[0].Value = model.account_id;
			parameters[1].Value = model.user_telphone;
			parameters[2].Value = model.account_balance;
			parameters[3].Value = model.account_change;
			parameters[4].Value = model.account_changetype;
			parameters[5].Value = model.account_change_time;
			parameters[6].Value = model.account_change_comment;

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
		public bool Update(la.Model.account model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update account set ");
			strSql.Append("account_balance=@account_balance,");
			strSql.Append("account_change=@account_change,");
			strSql.Append("account_changetype=@account_changetype,");
			strSql.Append("account_change_time=@account_change_time,");
			strSql.Append("account_change_comment=@account_change_comment");
			strSql.Append(" where account_id=@account_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@account_balance", SqlDbType.Float,8),
					new SqlParameter("@account_change", SqlDbType.Float,8),
					new SqlParameter("@account_changetype", SqlDbType.VarChar,30),
					new SqlParameter("@account_change_time", SqlDbType.DateTime),
					new SqlParameter("@account_change_comment", SqlDbType.VarChar,200),
					new SqlParameter("@account_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.account_balance;
			parameters[1].Value = model.account_change;
			parameters[2].Value = model.account_changetype;
			parameters[3].Value = model.account_change_time;
			parameters[4].Value = model.account_change_comment;
			parameters[5].Value = model.account_id;
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
		public bool Delete(int account_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from account ");
			strSql.Append(" where account_id=@account_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@account_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = account_id;
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
		public la.Model.account GetModel(int account_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 account_id,user_telphone,account_balance,account_change,account_changetype,account_change_time,account_change_comment from account ");
			strSql.Append(" where account_id=@account_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@account_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = account_id;
			parameters[1].Value = user_telphone;

			la.Model.account model=new la.Model.account();
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
		public la.Model.account DataRowToModel(DataRow row)
		{
			la.Model.account model=new la.Model.account();
			if (row != null)
			{
				if(row["account_id"]!=null && row["account_id"].ToString()!="")
				{
					model.account_id=int.Parse(row["account_id"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["account_balance"]!=null && row["account_balance"].ToString()!="")
				{
					model.account_balance=decimal.Parse(row["account_balance"].ToString());
				}
				if(row["account_change"]!=null && row["account_change"].ToString()!="")
				{
					model.account_change=decimal.Parse(row["account_change"].ToString());
				}
				if(row["account_changetype"]!=null)
				{
					model.account_changetype=row["account_changetype"].ToString();
				}
				if(row["account_change_time"]!=null && row["account_change_time"].ToString()!="")
				{
					model.account_change_time=DateTime.Parse(row["account_change_time"].ToString());
				}
				if(row["account_change_comment"]!=null)
				{
					model.account_change_comment=row["account_change_comment"].ToString();
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
			strSql.Append("select account_id,user_telphone,account_balance,account_change,account_changetype,account_change_time,account_change_comment ");
			strSql.Append(" FROM account ");
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
			strSql.Append(" account_id,user_telphone,account_balance,account_change,account_changetype,account_change_time,account_change_comment ");
			strSql.Append(" FROM account ");
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
			strSql.Append("select count(1) FROM account ");
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
			strSql.Append(")AS Row, T.*  from account T ");
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
			parameters[0].Value = "account";
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

