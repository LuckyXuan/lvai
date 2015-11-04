using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:recharge
	/// </summary>
	public partial class recharge
	{
		public recharge()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("recharge_ID", "recharge"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int recharge_ID,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from recharge");
			strSql.Append(" where recharge_ID=@recharge_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@recharge_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = recharge_ID;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.recharge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into recharge(");
			strSql.Append("recharge_ID,user_telphone,recharge_plat,recharge_money,recharge_time,recharge_code,recharge_comment)");
			strSql.Append(" values (");
			strSql.Append("@recharge_ID,@user_telphone,@recharge_plat,@recharge_money,@recharge_time,@recharge_code,@recharge_comment)");
			SqlParameter[] parameters = {
					new SqlParameter("@recharge_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@recharge_plat", SqlDbType.VarChar,30),
					new SqlParameter("@recharge_money", SqlDbType.Float,8),
					new SqlParameter("@recharge_time", SqlDbType.DateTime),
					new SqlParameter("@recharge_code", SqlDbType.VarChar,100),
					new SqlParameter("@recharge_comment", SqlDbType.VarChar,200)};
			parameters[0].Value = model.recharge_ID;
			parameters[1].Value = model.user_telphone;
			parameters[2].Value = model.recharge_plat;
			parameters[3].Value = model.recharge_money;
			parameters[4].Value = model.recharge_time;
			parameters[5].Value = model.recharge_code;
			parameters[6].Value = model.recharge_comment;

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
		public bool Update(la.Model.recharge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update recharge set ");
			strSql.Append("recharge_plat=@recharge_plat,");
			strSql.Append("recharge_money=@recharge_money,");
			strSql.Append("recharge_time=@recharge_time,");
			strSql.Append("recharge_code=@recharge_code,");
			strSql.Append("recharge_comment=@recharge_comment");
			strSql.Append(" where recharge_ID=@recharge_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@recharge_plat", SqlDbType.VarChar,30),
					new SqlParameter("@recharge_money", SqlDbType.Float,8),
					new SqlParameter("@recharge_time", SqlDbType.DateTime),
					new SqlParameter("@recharge_code", SqlDbType.VarChar,100),
					new SqlParameter("@recharge_comment", SqlDbType.VarChar,200),
					new SqlParameter("@recharge_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.recharge_plat;
			parameters[1].Value = model.recharge_money;
			parameters[2].Value = model.recharge_time;
			parameters[3].Value = model.recharge_code;
			parameters[4].Value = model.recharge_comment;
			parameters[5].Value = model.recharge_ID;
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
		public bool Delete(int recharge_ID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from recharge ");
			strSql.Append(" where recharge_ID=@recharge_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@recharge_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = recharge_ID;
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
		public la.Model.recharge GetModel(int recharge_ID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 recharge_ID,user_telphone,recharge_plat,recharge_money,recharge_time,recharge_code,recharge_comment from recharge ");
			strSql.Append(" where recharge_ID=@recharge_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@recharge_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = recharge_ID;
			parameters[1].Value = user_telphone;

			la.Model.recharge model=new la.Model.recharge();
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
		public la.Model.recharge DataRowToModel(DataRow row)
		{
			la.Model.recharge model=new la.Model.recharge();
			if (row != null)
			{
				if(row["recharge_ID"]!=null && row["recharge_ID"].ToString()!="")
				{
					model.recharge_ID=int.Parse(row["recharge_ID"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["recharge_plat"]!=null)
				{
					model.recharge_plat=row["recharge_plat"].ToString();
				}
				if(row["recharge_money"]!=null && row["recharge_money"].ToString()!="")
				{
					model.recharge_money=decimal.Parse(row["recharge_money"].ToString());
				}
				if(row["recharge_time"]!=null && row["recharge_time"].ToString()!="")
				{
					model.recharge_time=DateTime.Parse(row["recharge_time"].ToString());
				}
				if(row["recharge_code"]!=null)
				{
					model.recharge_code=row["recharge_code"].ToString();
				}
				if(row["recharge_comment"]!=null)
				{
					model.recharge_comment=row["recharge_comment"].ToString();
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
			strSql.Append("select recharge_ID,user_telphone,recharge_plat,recharge_money,recharge_time,recharge_code,recharge_comment ");
			strSql.Append(" FROM recharge ");
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
			strSql.Append(" recharge_ID,user_telphone,recharge_plat,recharge_money,recharge_time,recharge_code,recharge_comment ");
			strSql.Append(" FROM recharge ");
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
			strSql.Append("select count(1) FROM recharge ");
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
			strSql.Append(")AS Row, T.*  from recharge T ");
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
			parameters[0].Value = "recharge";
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

