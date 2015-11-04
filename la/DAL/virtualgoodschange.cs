using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:virtualgoodschange
	/// </summary>
	public partial class virtualgoodschange
	{
		public virtualgoodschange()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("virtualgoodschange_ID", "virtualgoodschange"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int virtualgoodschange_ID,string user_telphone,int virtualgoods_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from virtualgoodschange");
			strSql.Append(" where virtualgoodschange_ID=@virtualgoodschange_ID and user_telphone=@user_telphone and virtualgoods_ID=@virtualgoods_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@virtualgoodschange_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4)			};
			parameters[0].Value = virtualgoodschange_ID;
			parameters[1].Value = user_telphone;
			parameters[2].Value = virtualgoods_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.virtualgoodschange model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into virtualgoodschange(");
			strSql.Append("virtualgoodschange_ID,user_telphone,virtualgoods_ID,virtualgoodschange_count,virtualgoodschange_time,virtualgoodschange_comment)");
			strSql.Append(" values (");
			strSql.Append("@virtualgoodschange_ID,@user_telphone,@virtualgoods_ID,@virtualgoodschange_count,@virtualgoodschange_time,@virtualgoodschange_comment)");
			SqlParameter[] parameters = {
					new SqlParameter("@virtualgoodschange_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4),
					new SqlParameter("@virtualgoodschange_count", SqlDbType.Int,4),
					new SqlParameter("@virtualgoodschange_time", SqlDbType.DateTime),
					new SqlParameter("@virtualgoodschange_comment", SqlDbType.VarChar,200)};
			parameters[0].Value = model.virtualgoodschange_ID;
			parameters[1].Value = model.user_telphone;
			parameters[2].Value = model.virtualgoods_ID;
			parameters[3].Value = model.virtualgoodschange_count;
			parameters[4].Value = model.virtualgoodschange_time;
			parameters[5].Value = model.virtualgoodschange_comment;

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
		public bool Update(la.Model.virtualgoodschange model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update virtualgoodschange set ");
			strSql.Append("virtualgoodschange_count=@virtualgoodschange_count,");
			strSql.Append("virtualgoodschange_time=@virtualgoodschange_time,");
			strSql.Append("virtualgoodschange_comment=@virtualgoodschange_comment");
			strSql.Append(" where virtualgoodschange_ID=@virtualgoodschange_ID and user_telphone=@user_telphone and virtualgoods_ID=@virtualgoods_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@virtualgoodschange_count", SqlDbType.Int,4),
					new SqlParameter("@virtualgoodschange_time", SqlDbType.DateTime),
					new SqlParameter("@virtualgoodschange_comment", SqlDbType.VarChar,200),
					new SqlParameter("@virtualgoodschange_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.virtualgoodschange_count;
			parameters[1].Value = model.virtualgoodschange_time;
			parameters[2].Value = model.virtualgoodschange_comment;
			parameters[3].Value = model.virtualgoodschange_ID;
			parameters[4].Value = model.user_telphone;
			parameters[5].Value = model.virtualgoods_ID;

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
		public bool Delete(int virtualgoodschange_ID,string user_telphone,int virtualgoods_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from virtualgoodschange ");
			strSql.Append(" where virtualgoodschange_ID=@virtualgoodschange_ID and user_telphone=@user_telphone and virtualgoods_ID=@virtualgoods_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@virtualgoodschange_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4)			};
			parameters[0].Value = virtualgoodschange_ID;
			parameters[1].Value = user_telphone;
			parameters[2].Value = virtualgoods_ID;

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
		public la.Model.virtualgoodschange GetModel(int virtualgoodschange_ID,string user_telphone,int virtualgoods_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 virtualgoodschange_ID,user_telphone,virtualgoods_ID,virtualgoodschange_count,virtualgoodschange_time,virtualgoodschange_comment from virtualgoodschange ");
			strSql.Append(" where virtualgoodschange_ID=@virtualgoodschange_ID and user_telphone=@user_telphone and virtualgoods_ID=@virtualgoods_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@virtualgoodschange_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4)			};
			parameters[0].Value = virtualgoodschange_ID;
			parameters[1].Value = user_telphone;
			parameters[2].Value = virtualgoods_ID;

			la.Model.virtualgoodschange model=new la.Model.virtualgoodschange();
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
		public la.Model.virtualgoodschange DataRowToModel(DataRow row)
		{
			la.Model.virtualgoodschange model=new la.Model.virtualgoodschange();
			if (row != null)
			{
				if(row["virtualgoodschange_ID"]!=null && row["virtualgoodschange_ID"].ToString()!="")
				{
					model.virtualgoodschange_ID=int.Parse(row["virtualgoodschange_ID"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["virtualgoods_ID"]!=null && row["virtualgoods_ID"].ToString()!="")
				{
					model.virtualgoods_ID=int.Parse(row["virtualgoods_ID"].ToString());
				}
				if(row["virtualgoodschange_count"]!=null && row["virtualgoodschange_count"].ToString()!="")
				{
					model.virtualgoodschange_count=int.Parse(row["virtualgoodschange_count"].ToString());
				}
				if(row["virtualgoodschange_time"]!=null && row["virtualgoodschange_time"].ToString()!="")
				{
					model.virtualgoodschange_time=DateTime.Parse(row["virtualgoodschange_time"].ToString());
				}
				if(row["virtualgoodschange_comment"]!=null)
				{
					model.virtualgoodschange_comment=row["virtualgoodschange_comment"].ToString();
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
			strSql.Append("select virtualgoodschange_ID,user_telphone,virtualgoods_ID,virtualgoodschange_count,virtualgoodschange_time,virtualgoodschange_comment ");
			strSql.Append(" FROM virtualgoodschange ");
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
			strSql.Append(" virtualgoodschange_ID,user_telphone,virtualgoods_ID,virtualgoodschange_count,virtualgoodschange_time,virtualgoodschange_comment ");
			strSql.Append(" FROM virtualgoodschange ");
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
			strSql.Append("select count(1) FROM virtualgoodschange ");
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
				strSql.Append("order by T.virtualgoods_ID desc");
			}
			strSql.Append(")AS Row, T.*  from virtualgoodschange T ");
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
			parameters[0].Value = "virtualgoodschange";
			parameters[1].Value = "virtualgoods_ID";
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

