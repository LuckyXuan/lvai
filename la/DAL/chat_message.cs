using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:chat_message
	/// </summary>
	public partial class chat_message
	{
		public chat_message()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("chat_ID", "chat_message"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int chat_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from chat_message");
			strSql.Append(" where chat_ID=@chat_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@chat_ID", SqlDbType.Int,4)			};
			parameters[0].Value = chat_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.chat_message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into chat_message(");
			strSql.Append("chat_ID,chat_FROM,chat_TO,chat_content,chat_time,chat_comment,chat_state)");
			strSql.Append(" values (");
			strSql.Append("@chat_ID,@chat_FROM,@chat_TO,@chat_content,@chat_time,@chat_comment,@chat_state)");
			SqlParameter[] parameters = {
					new SqlParameter("@chat_ID", SqlDbType.Int,4),
					new SqlParameter("@chat_FROM", SqlDbType.Int,4),
					new SqlParameter("@chat_TO", SqlDbType.Int,4),
					new SqlParameter("@chat_content", SqlDbType.VarChar,400),
					new SqlParameter("@chat_time", SqlDbType.DateTime),
					new SqlParameter("@chat_comment", SqlDbType.VarChar,200),
					new SqlParameter("@chat_state", SqlDbType.VarChar,30)};
			parameters[0].Value = model.chat_ID;
			parameters[1].Value = model.chat_FROM;
			parameters[2].Value = model.chat_TO;
			parameters[3].Value = model.chat_content;
			parameters[4].Value = model.chat_time;
			parameters[5].Value = model.chat_comment;
			parameters[6].Value = model.chat_state;

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
		public bool Update(la.Model.chat_message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update chat_message set ");
			strSql.Append("chat_FROM=@chat_FROM,");
			strSql.Append("chat_TO=@chat_TO,");
			strSql.Append("chat_content=@chat_content,");
			strSql.Append("chat_time=@chat_time,");
			strSql.Append("chat_comment=@chat_comment,");
			strSql.Append("chat_state=@chat_state");
			strSql.Append(" where chat_ID=@chat_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@chat_FROM", SqlDbType.Int,4),
					new SqlParameter("@chat_TO", SqlDbType.Int,4),
					new SqlParameter("@chat_content", SqlDbType.VarChar,400),
					new SqlParameter("@chat_time", SqlDbType.DateTime),
					new SqlParameter("@chat_comment", SqlDbType.VarChar,200),
					new SqlParameter("@chat_state", SqlDbType.VarChar,30),
					new SqlParameter("@chat_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.chat_FROM;
			parameters[1].Value = model.chat_TO;
			parameters[2].Value = model.chat_content;
			parameters[3].Value = model.chat_time;
			parameters[4].Value = model.chat_comment;
			parameters[5].Value = model.chat_state;
			parameters[6].Value = model.chat_ID;

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
		public bool Delete(int chat_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from chat_message ");
			strSql.Append(" where chat_ID=@chat_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@chat_ID", SqlDbType.Int,4)			};
			parameters[0].Value = chat_ID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string chat_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from chat_message ");
			strSql.Append(" where chat_ID in ("+chat_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public la.Model.chat_message GetModel(int chat_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 chat_ID,chat_FROM,chat_TO,chat_content,chat_time,chat_comment,chat_state from chat_message ");
			strSql.Append(" where chat_ID=@chat_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@chat_ID", SqlDbType.Int,4)			};
			parameters[0].Value = chat_ID;

			la.Model.chat_message model=new la.Model.chat_message();
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
		public la.Model.chat_message DataRowToModel(DataRow row)
		{
			la.Model.chat_message model=new la.Model.chat_message();
			if (row != null)
			{
				if(row["chat_ID"]!=null && row["chat_ID"].ToString()!="")
				{
					model.chat_ID=int.Parse(row["chat_ID"].ToString());
				}
				if(row["chat_FROM"]!=null && row["chat_FROM"].ToString()!="")
				{
					model.chat_FROM=int.Parse(row["chat_FROM"].ToString());
				}
				if(row["chat_TO"]!=null && row["chat_TO"].ToString()!="")
				{
					model.chat_TO=int.Parse(row["chat_TO"].ToString());
				}
				if(row["chat_content"]!=null)
				{
					model.chat_content=row["chat_content"].ToString();
				}
				if(row["chat_time"]!=null && row["chat_time"].ToString()!="")
				{
					model.chat_time=DateTime.Parse(row["chat_time"].ToString());
				}
				if(row["chat_comment"]!=null)
				{
					model.chat_comment=row["chat_comment"].ToString();
				}
				if(row["chat_state"]!=null)
				{
					model.chat_state=row["chat_state"].ToString();
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
			strSql.Append("select chat_ID,chat_FROM,chat_TO,chat_content,chat_time,chat_comment,chat_state ");
			strSql.Append(" FROM chat_message ");
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
			strSql.Append(" chat_ID,chat_FROM,chat_TO,chat_content,chat_time,chat_comment,chat_state ");
			strSql.Append(" FROM chat_message ");
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
			strSql.Append("select count(1) FROM chat_message ");
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
				strSql.Append("order by T.chat_ID desc");
			}
			strSql.Append(")AS Row, T.*  from chat_message T ");
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
			parameters[0].Value = "chat_message";
			parameters[1].Value = "chat_ID";
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

