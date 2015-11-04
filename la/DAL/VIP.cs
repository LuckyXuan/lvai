using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:VIP
	/// </summary>
	public partial class VIP
	{
		public VIP()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("VIPID", "VIP"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int VIPID,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from VIP");
			strSql.Append(" where VIPID=@VIPID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@VIPID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = VIPID;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.VIP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VIP(");
			strSql.Append("VIPID,user_telphone,VIP_change_credit,VIP_change_comment,VIP_change_time,VIP_credit,VIP_level,VIP_change_type)");
			strSql.Append(" values (");
			strSql.Append("@VIPID,@user_telphone,@VIP_change_credit,@VIP_change_comment,@VIP_change_time,@VIP_credit,@VIP_level,@VIP_change_type)");
			SqlParameter[] parameters = {
					new SqlParameter("@VIPID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@VIP_change_credit", SqlDbType.Float,8),
					new SqlParameter("@VIP_change_comment", SqlDbType.VarChar,200),
					new SqlParameter("@VIP_change_time", SqlDbType.DateTime),
					new SqlParameter("@VIP_credit", SqlDbType.Float,8),
					new SqlParameter("@VIP_level", SqlDbType.Int,4),
					new SqlParameter("@VIP_change_type", SqlDbType.VarChar,20)};
			parameters[0].Value = model.VIPID;
			parameters[1].Value = model.user_telphone;
			parameters[2].Value = model.VIP_change_credit;
			parameters[3].Value = model.VIP_change_comment;
			parameters[4].Value = model.VIP_change_time;
			parameters[5].Value = model.VIP_credit;
			parameters[6].Value = model.VIP_level;
			parameters[7].Value = model.VIP_change_type;

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
		public bool Update(la.Model.VIP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VIP set ");
			strSql.Append("VIP_change_credit=@VIP_change_credit,");
			strSql.Append("VIP_change_comment=@VIP_change_comment,");
			strSql.Append("VIP_change_time=@VIP_change_time,");
			strSql.Append("VIP_credit=@VIP_credit,");
			strSql.Append("VIP_level=@VIP_level,");
			strSql.Append("VIP_change_type=@VIP_change_type");
			strSql.Append(" where VIPID=@VIPID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@VIP_change_credit", SqlDbType.Float,8),
					new SqlParameter("@VIP_change_comment", SqlDbType.VarChar,200),
					new SqlParameter("@VIP_change_time", SqlDbType.DateTime),
					new SqlParameter("@VIP_credit", SqlDbType.Float,8),
					new SqlParameter("@VIP_level", SqlDbType.Int,4),
					new SqlParameter("@VIP_change_type", SqlDbType.VarChar,20),
					new SqlParameter("@VIPID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.VIP_change_credit;
			parameters[1].Value = model.VIP_change_comment;
			parameters[2].Value = model.VIP_change_time;
			parameters[3].Value = model.VIP_credit;
			parameters[4].Value = model.VIP_level;
			parameters[5].Value = model.VIP_change_type;
			parameters[6].Value = model.VIPID;
			parameters[7].Value = model.user_telphone;

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
		public bool Delete(int VIPID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VIP ");
			strSql.Append(" where VIPID=@VIPID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@VIPID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = VIPID;
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
		public la.Model.VIP GetModel(int VIPID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 VIPID,user_telphone,VIP_change_credit,VIP_change_comment,VIP_change_time,VIP_credit,VIP_level,VIP_change_type from VIP ");
			strSql.Append(" where VIPID=@VIPID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@VIPID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = VIPID;
			parameters[1].Value = user_telphone;

			la.Model.VIP model=new la.Model.VIP();
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
		public la.Model.VIP DataRowToModel(DataRow row)
		{
			la.Model.VIP model=new la.Model.VIP();
			if (row != null)
			{
				if(row["VIPID"]!=null && row["VIPID"].ToString()!="")
				{
					model.VIPID=int.Parse(row["VIPID"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["VIP_change_credit"]!=null && row["VIP_change_credit"].ToString()!="")
				{
					model.VIP_change_credit=decimal.Parse(row["VIP_change_credit"].ToString());
				}
				if(row["VIP_change_comment"]!=null)
				{
					model.VIP_change_comment=row["VIP_change_comment"].ToString();
				}
				if(row["VIP_change_time"]!=null && row["VIP_change_time"].ToString()!="")
				{
					model.VIP_change_time=DateTime.Parse(row["VIP_change_time"].ToString());
				}
				if(row["VIP_credit"]!=null && row["VIP_credit"].ToString()!="")
				{
					model.VIP_credit=decimal.Parse(row["VIP_credit"].ToString());
				}
				if(row["VIP_level"]!=null && row["VIP_level"].ToString()!="")
				{
					model.VIP_level=int.Parse(row["VIP_level"].ToString());
				}
				if(row["VIP_change_type"]!=null)
				{
					model.VIP_change_type=row["VIP_change_type"].ToString();
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
			strSql.Append("select VIPID,user_telphone,VIP_change_credit,VIP_change_comment,VIP_change_time,VIP_credit,VIP_level,VIP_change_type ");
			strSql.Append(" FROM VIP ");
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
			strSql.Append(" VIPID,user_telphone,VIP_change_credit,VIP_change_comment,VIP_change_time,VIP_credit,VIP_level,VIP_change_type ");
			strSql.Append(" FROM VIP ");
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
			strSql.Append("select count(1) FROM VIP ");
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
			strSql.Append(")AS Row, T.*  from VIP T ");
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
			parameters[0].Value = "VIP";
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

