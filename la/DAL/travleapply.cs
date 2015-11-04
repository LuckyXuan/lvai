using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:travleapply
	/// </summary>
	public partial class travleapply
	{
		public travleapply()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("travleapply_ID", "travleapply"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int travleapply_ID,int travle_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from travleapply");
			strSql.Append(" where travleapply_ID=@travleapply_ID and travle_ID=@travle_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@travleapply_ID", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4)			};
			parameters[0].Value = travleapply_ID;
			parameters[1].Value = travle_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.travleapply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into travleapply(");
			strSql.Append("travleapply_ID,travle_ID,applyer_ID,apply_time,apply_state,apply_msg)");
			strSql.Append(" values (");
			strSql.Append("@travleapply_ID,@travle_ID,@applyer_ID,@apply_time,@apply_state,@apply_msg)");
			SqlParameter[] parameters = {
					new SqlParameter("@travleapply_ID", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4),
					new SqlParameter("@applyer_ID", SqlDbType.Int,4),
					new SqlParameter("@apply_time", SqlDbType.DateTime),
					new SqlParameter("@apply_state", SqlDbType.VarChar,30),
					new SqlParameter("@apply_msg", SqlDbType.VarChar,400)};
			parameters[0].Value = model.travleapply_ID;
			parameters[1].Value = model.travle_ID;
			parameters[2].Value = model.applyer_ID;
			parameters[3].Value = model.apply_time;
			parameters[4].Value = model.apply_state;
			parameters[5].Value = model.apply_msg;

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
		public bool Update(la.Model.travleapply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update travleapply set ");
			strSql.Append("applyer_ID=@applyer_ID,");
			strSql.Append("apply_time=@apply_time,");
			strSql.Append("apply_state=@apply_state,");
			strSql.Append("apply_msg=@apply_msg");
			strSql.Append(" where travleapply_ID=@travleapply_ID and travle_ID=@travle_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@applyer_ID", SqlDbType.Int,4),
					new SqlParameter("@apply_time", SqlDbType.DateTime),
					new SqlParameter("@apply_state", SqlDbType.VarChar,30),
					new SqlParameter("@apply_msg", SqlDbType.VarChar,400),
					new SqlParameter("@travleapply_ID", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.applyer_ID;
			parameters[1].Value = model.apply_time;
			parameters[2].Value = model.apply_state;
			parameters[3].Value = model.apply_msg;
			parameters[4].Value = model.travleapply_ID;
			parameters[5].Value = model.travle_ID;

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
		public bool Delete(int travleapply_ID,int travle_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from travleapply ");
			strSql.Append(" where travleapply_ID=@travleapply_ID and travle_ID=@travle_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@travleapply_ID", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4)			};
			parameters[0].Value = travleapply_ID;
			parameters[1].Value = travle_ID;

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
		public la.Model.travleapply GetModel(int travleapply_ID,int travle_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 travleapply_ID,travle_ID,applyer_ID,apply_time,apply_state,apply_msg from travleapply ");
			strSql.Append(" where travleapply_ID=@travleapply_ID and travle_ID=@travle_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@travleapply_ID", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4)			};
			parameters[0].Value = travleapply_ID;
			parameters[1].Value = travle_ID;

			la.Model.travleapply model=new la.Model.travleapply();
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
		public la.Model.travleapply DataRowToModel(DataRow row)
		{
			la.Model.travleapply model=new la.Model.travleapply();
			if (row != null)
			{
				if(row["travleapply_ID"]!=null && row["travleapply_ID"].ToString()!="")
				{
					model.travleapply_ID=int.Parse(row["travleapply_ID"].ToString());
				}
				if(row["travle_ID"]!=null && row["travle_ID"].ToString()!="")
				{
					model.travle_ID=int.Parse(row["travle_ID"].ToString());
				}
				if(row["applyer_ID"]!=null && row["applyer_ID"].ToString()!="")
				{
					model.applyer_ID=int.Parse(row["applyer_ID"].ToString());
				}
				if(row["apply_time"]!=null && row["apply_time"].ToString()!="")
				{
					model.apply_time=DateTime.Parse(row["apply_time"].ToString());
				}
				if(row["apply_state"]!=null)
				{
					model.apply_state=row["apply_state"].ToString();
				}
				if(row["apply_msg"]!=null)
				{
					model.apply_msg=row["apply_msg"].ToString();
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
			strSql.Append("select travleapply_ID,travle_ID,applyer_ID,apply_time,apply_state,apply_msg ");
			strSql.Append(" FROM travleapply ");
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
			strSql.Append(" travleapply_ID,travle_ID,applyer_ID,apply_time,apply_state,apply_msg ");
			strSql.Append(" FROM travleapply ");
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
			strSql.Append("select count(1) FROM travleapply ");
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
				strSql.Append("order by T.travle_ID desc");
			}
			strSql.Append(")AS Row, T.*  from travleapply T ");
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
			parameters[0].Value = "travleapply";
			parameters[1].Value = "travle_ID";
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

