using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:talent
	/// </summary>
	public partial class talent
	{
		public talent()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("talent_ID", "talent"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int talent_ID,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from talent");
			strSql.Append(" where talent_ID=@talent_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@talent_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = talent_ID;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.talent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into talent(");
			strSql.Append("talent_ID,user_telphone,talent_change_value,talent_change_comment,talent_change_time,talent_change_type,talent_result)");
			strSql.Append(" values (");
			strSql.Append("@talent_ID,@user_telphone,@talent_change_value,@talent_change_comment,@talent_change_time,@talent_change_type,@talent_result)");
			SqlParameter[] parameters = {
					new SqlParameter("@talent_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@talent_change_value", SqlDbType.Float,8),
					new SqlParameter("@talent_change_comment", SqlDbType.VarChar,200),
					new SqlParameter("@talent_change_time", SqlDbType.DateTime),
					new SqlParameter("@talent_change_type", SqlDbType.VarChar,40),
					new SqlParameter("@talent_result", SqlDbType.Float,8)};
			parameters[0].Value = model.talent_ID;
			parameters[1].Value = model.user_telphone;
			parameters[2].Value = model.talent_change_value;
			parameters[3].Value = model.talent_change_comment;
			parameters[4].Value = model.talent_change_time;
			parameters[5].Value = model.talent_change_type;
			parameters[6].Value = model.talent_result;

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
		public bool Update(la.Model.talent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update talent set ");
			strSql.Append("talent_change_value=@talent_change_value,");
			strSql.Append("talent_change_comment=@talent_change_comment,");
			strSql.Append("talent_change_time=@talent_change_time,");
			strSql.Append("talent_change_type=@talent_change_type,");
			strSql.Append("talent_result=@talent_result");
			strSql.Append(" where talent_ID=@talent_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@talent_change_value", SqlDbType.Float,8),
					new SqlParameter("@talent_change_comment", SqlDbType.VarChar,200),
					new SqlParameter("@talent_change_time", SqlDbType.DateTime),
					new SqlParameter("@talent_change_type", SqlDbType.VarChar,40),
					new SqlParameter("@talent_result", SqlDbType.Float,8),
					new SqlParameter("@talent_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.talent_change_value;
			parameters[1].Value = model.talent_change_comment;
			parameters[2].Value = model.talent_change_time;
			parameters[3].Value = model.talent_change_type;
			parameters[4].Value = model.talent_result;
			parameters[5].Value = model.talent_ID;
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
		public bool Delete(int talent_ID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from talent ");
			strSql.Append(" where talent_ID=@talent_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@talent_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = talent_ID;
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
		public la.Model.talent GetModel(int talent_ID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 talent_ID,user_telphone,talent_change_value,talent_change_comment,talent_change_time,talent_change_type,talent_result from talent ");
			strSql.Append(" where talent_ID=@talent_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@talent_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = talent_ID;
			parameters[1].Value = user_telphone;

			la.Model.talent model=new la.Model.talent();
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
		public la.Model.talent DataRowToModel(DataRow row)
		{
			la.Model.talent model=new la.Model.talent();
			if (row != null)
			{
				if(row["talent_ID"]!=null && row["talent_ID"].ToString()!="")
				{
					model.talent_ID=int.Parse(row["talent_ID"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["talent_change_value"]!=null && row["talent_change_value"].ToString()!="")
				{
					model.talent_change_value=decimal.Parse(row["talent_change_value"].ToString());
				}
				if(row["talent_change_comment"]!=null)
				{
					model.talent_change_comment=row["talent_change_comment"].ToString();
				}
				if(row["talent_change_time"]!=null && row["talent_change_time"].ToString()!="")
				{
					model.talent_change_time=DateTime.Parse(row["talent_change_time"].ToString());
				}
				if(row["talent_change_type"]!=null)
				{
					model.talent_change_type=row["talent_change_type"].ToString();
				}
				if(row["talent_result"]!=null && row["talent_result"].ToString()!="")
				{
					model.talent_result=decimal.Parse(row["talent_result"].ToString());
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
			strSql.Append("select talent_ID,user_telphone,talent_change_value,talent_change_comment,talent_change_time,talent_change_type,talent_result ");
			strSql.Append(" FROM talent ");
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
			strSql.Append(" talent_ID,user_telphone,talent_change_value,talent_change_comment,talent_change_time,talent_change_type,talent_result ");
			strSql.Append(" FROM talent ");
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
			strSql.Append("select count(1) FROM talent ");
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
			strSql.Append(")AS Row, T.*  from talent T ");
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
			parameters[0].Value = "talent";
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

