using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:album
	/// </summary>
	public partial class album
	{
		public album()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("album_id", "album"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int album_id,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from album");
			strSql.Append(" where album_id=@album_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@album_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = album_id;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.album model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into album(");
			strSql.Append("user_telphone,album_time,album_comment,album_isvalid,album_isprivate)");
			strSql.Append(" values (");
			strSql.Append("@user_telphone,@album_time,@album_comment,@album_isvalid,@album_isprivate)");
			SqlParameter[] parameters = {
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@album_time", SqlDbType.DateTime),
					new SqlParameter("@album_comment", SqlDbType.VarChar,200),
					new SqlParameter("@album_isvalid", SqlDbType.Bit,1),
					new SqlParameter("@album_isprivate", SqlDbType.Bit,1)};

			parameters[0].Value = model.user_telphone;
			parameters[1].Value = model.album_time;
			parameters[2].Value = model.album_comment;
			parameters[3].Value = model.album_isvalid;
			parameters[4].Value = model.album_isprivate;

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
		public bool Update(la.Model.album model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update album set ");
			strSql.Append("album_time=@album_time,");
			strSql.Append("album_comment=@album_comment,");
			strSql.Append("album_isvalid=@album_isvalid,");
			strSql.Append("album_isprivate=@album_isprivate");
			strSql.Append(" where album_id=@album_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@album_time", SqlDbType.DateTime),
					new SqlParameter("@album_comment", SqlDbType.VarChar,200),
					new SqlParameter("@album_isvalid", SqlDbType.Bit,1),
					new SqlParameter("@album_isprivate", SqlDbType.Bit,1),
					new SqlParameter("@album_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.album_time;
			parameters[1].Value = model.album_comment;
			parameters[2].Value = model.album_isvalid;
			parameters[3].Value = model.album_isprivate;
			parameters[4].Value = model.album_id;
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
		public bool Delete(int album_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from album ");
			strSql.Append(" where album_id=@album_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@album_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = album_id;
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
		public la.Model.album GetModel(int album_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 album_id,user_telphone,album_time,album_comment,album_isvalid,album_isprivate from album ");
			strSql.Append(" where album_id=@album_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@album_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = album_id;
			parameters[1].Value = user_telphone;

			la.Model.album model=new la.Model.album();
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
		public la.Model.album DataRowToModel(DataRow row)
		{
			la.Model.album model=new la.Model.album();
			if (row != null)
			{
				if(row["album_id"]!=null && row["album_id"].ToString()!="")
				{
					model.album_id=int.Parse(row["album_id"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["album_time"]!=null && row["album_time"].ToString()!="")
				{
					model.album_time=DateTime.Parse(row["album_time"].ToString());
				}
				if(row["album_comment"]!=null)
				{
					model.album_comment=row["album_comment"].ToString();
				}
				if(row["album_isvalid"]!=null && row["album_isvalid"].ToString()!="")
				{
					if((row["album_isvalid"].ToString()=="1")||(row["album_isvalid"].ToString().ToLower()=="true"))
					{
						model.album_isvalid=true;
					}
					else
					{
						model.album_isvalid=false;
					}
				}
				if(row["album_isprivate"]!=null && row["album_isprivate"].ToString()!="")
				{
					if((row["album_isprivate"].ToString()=="1")||(row["album_isprivate"].ToString().ToLower()=="true"))
					{
						model.album_isprivate=true;
					}
					else
					{
						model.album_isprivate=false;
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
			strSql.Append("select album_id,user_telphone,album_time,album_comment,album_isvalid,album_isprivate ");
			strSql.Append(" FROM album ");
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
			strSql.Append(" album_id,user_telphone,album_time,album_comment,album_isvalid,album_isprivate ");
			strSql.Append(" FROM album ");
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
			strSql.Append("select count(1) FROM album ");
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
			strSql.Append(")AS Row, T.*  from album T ");
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
			parameters[0].Value = "album";
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

