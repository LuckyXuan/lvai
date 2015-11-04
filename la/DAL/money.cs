using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:money
	/// </summary>
	public partial class money
	{
		public money()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("money_id", "money"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int money_id,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from money");
			strSql.Append(" where money_id=@money_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@money_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = money_id;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into money(");
			strSql.Append("money_id,user_telphone,money_change,moneychange_time,moneychange_comment,money_balance,moneychange_type)");
			strSql.Append(" values (");
			strSql.Append("@money_id,@user_telphone,@money_change,@moneychange_time,@moneychange_comment,@money_balance,@moneychange_type)");
			SqlParameter[] parameters = {
					new SqlParameter("@money_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@money_change", SqlDbType.Float,8),
					new SqlParameter("@moneychange_time", SqlDbType.DateTime),
					new SqlParameter("@moneychange_comment", SqlDbType.VarChar,200),
					new SqlParameter("@money_balance", SqlDbType.Float,8),
					new SqlParameter("@moneychange_type", SqlDbType.VarChar,30)};
			parameters[0].Value = model.money_id;
			parameters[1].Value = model.user_telphone;
			parameters[2].Value = model.money_change;
			parameters[3].Value = model.moneychange_time;
			parameters[4].Value = model.moneychange_comment;
			parameters[5].Value = model.money_balance;
			parameters[6].Value = model.moneychange_type;

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
		public bool Update(la.Model.money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update money set ");
			strSql.Append("money_change=@money_change,");
			strSql.Append("moneychange_time=@moneychange_time,");
			strSql.Append("moneychange_comment=@moneychange_comment,");
			strSql.Append("money_balance=@money_balance,");
			strSql.Append("moneychange_type=@moneychange_type");
			strSql.Append(" where money_id=@money_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@money_change", SqlDbType.Float,8),
					new SqlParameter("@moneychange_time", SqlDbType.DateTime),
					new SqlParameter("@moneychange_comment", SqlDbType.VarChar,200),
					new SqlParameter("@money_balance", SqlDbType.Float,8),
					new SqlParameter("@moneychange_type", SqlDbType.VarChar,30),
					new SqlParameter("@money_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.money_change;
			parameters[1].Value = model.moneychange_time;
			parameters[2].Value = model.moneychange_comment;
			parameters[3].Value = model.money_balance;
			parameters[4].Value = model.moneychange_type;
			parameters[5].Value = model.money_id;
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
		public bool Delete(int money_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from money ");
			strSql.Append(" where money_id=@money_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@money_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = money_id;
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
		public la.Model.money GetModel(int money_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 money_id,user_telphone,money_change,moneychange_time,moneychange_comment,money_balance,moneychange_type from money ");
			strSql.Append(" where money_id=@money_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@money_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = money_id;
			parameters[1].Value = user_telphone;

			la.Model.money model=new la.Model.money();
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
		public la.Model.money DataRowToModel(DataRow row)
		{
			la.Model.money model=new la.Model.money();
			if (row != null)
			{
				if(row["money_id"]!=null && row["money_id"].ToString()!="")
				{
					model.money_id=int.Parse(row["money_id"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["money_change"]!=null && row["money_change"].ToString()!="")
				{
					model.money_change=decimal.Parse(row["money_change"].ToString());
				}
				if(row["moneychange_time"]!=null && row["moneychange_time"].ToString()!="")
				{
					model.moneychange_time=DateTime.Parse(row["moneychange_time"].ToString());
				}
				if(row["moneychange_comment"]!=null)
				{
					model.moneychange_comment=row["moneychange_comment"].ToString();
				}
				if(row["money_balance"]!=null && row["money_balance"].ToString()!="")
				{
					model.money_balance=decimal.Parse(row["money_balance"].ToString());
				}
				if(row["moneychange_type"]!=null)
				{
					model.moneychange_type=row["moneychange_type"].ToString();
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
			strSql.Append("select money_id,user_telphone,money_change,moneychange_time,moneychange_comment,money_balance,moneychange_type ");
			strSql.Append(" FROM money ");
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
			strSql.Append(" money_id,user_telphone,money_change,moneychange_time,moneychange_comment,money_balance,moneychange_type ");
			strSql.Append(" FROM money ");
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
			strSql.Append("select count(1) FROM money ");
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
			strSql.Append(")AS Row, T.*  from money T ");
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
			parameters[0].Value = "money";
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

