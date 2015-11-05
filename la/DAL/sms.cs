using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:sms
	/// </summary>
	public partial class sms
	{
		public sms()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("sms_id", "sms"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sms_id,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sms");
			strSql.Append(" where sms_id=@sms_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@sms_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = sms_id;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.sms model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sms(");
			strSql.Append("user_telphone,sms_content,sms_time,sms_comment,sms_ispay)");
			strSql.Append(" values (");
			strSql.Append("@user_telphone,@sms_content,@sms_time,@sms_comment,@sms_ispay)");
			SqlParameter[] parameters = {
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@sms_content", SqlDbType.VarChar,280),
					new SqlParameter("@sms_time", SqlDbType.DateTime),
					new SqlParameter("@sms_comment", SqlDbType.VarChar,400),
					new SqlParameter("@sms_ispay", SqlDbType.Bit,1)};
			parameters[0].Value = model.user_telphone;
			parameters[1].Value = model.sms_content;
			parameters[2].Value = model.sms_time;
			parameters[3].Value = model.sms_comment;
			parameters[4].Value = model.sms_ispay;

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
		public bool Update(la.Model.sms model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sms set ");
			strSql.Append("sms_content=@sms_content,");
			strSql.Append("sms_time=@sms_time,");
			strSql.Append("sms_comment=@sms_comment,");
			strSql.Append("sms_ispay=@sms_ispay");
			strSql.Append(" where sms_id=@sms_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@sms_content", SqlDbType.VarChar,280),
					new SqlParameter("@sms_time", SqlDbType.DateTime),
					new SqlParameter("@sms_comment", SqlDbType.VarChar,400),
					new SqlParameter("@sms_ispay", SqlDbType.Bit,1),
					new SqlParameter("@sms_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.sms_content;
			parameters[1].Value = model.sms_time;
			parameters[2].Value = model.sms_comment;
			parameters[3].Value = model.sms_ispay;
			parameters[4].Value = model.sms_id;
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
		public bool Delete(int sms_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sms ");
			strSql.Append(" where sms_id=@sms_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@sms_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = sms_id;
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
		public la.Model.sms GetModel(int sms_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sms_id,user_telphone,sms_content,sms_time,sms_comment,sms_ispay from sms ");
			strSql.Append(" where sms_id=@sms_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@sms_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = sms_id;
			parameters[1].Value = user_telphone;

			la.Model.sms model=new la.Model.sms();
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
		public la.Model.sms DataRowToModel(DataRow row)
		{
			la.Model.sms model=new la.Model.sms();
			if (row != null)
			{
				if(row["sms_id"]!=null && row["sms_id"].ToString()!="")
				{
					model.sms_id=int.Parse(row["sms_id"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["sms_content"]!=null)
				{
					model.sms_content=row["sms_content"].ToString();
				}
				if(row["sms_time"]!=null && row["sms_time"].ToString()!="")
				{
					model.sms_time=DateTime.Parse(row["sms_time"].ToString());
				}
				if(row["sms_comment"]!=null)
				{
					model.sms_comment=row["sms_comment"].ToString();
				}
				if(row["sms_ispay"]!=null && row["sms_ispay"].ToString()!="")
				{
					if((row["sms_ispay"].ToString()=="1")||(row["sms_ispay"].ToString().ToLower()=="true"))
					{
						model.sms_ispay=true;
					}
					else
					{
						model.sms_ispay=false;
					}
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
			strSql.Append("select sms_id,user_telphone,sms_content,sms_time,sms_comment,sms_ispay ");
			strSql.Append(" FROM sms ");
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
			strSql.Append(" sms_id,user_telphone,sms_content,sms_time,sms_comment,sms_ispay ");
			strSql.Append(" FROM sms ");
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
			strSql.Append("select count(1) FROM sms ");
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
			strSql.Append(")AS Row, T.*  from sms T ");
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
			parameters[0].Value = "sms";
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

