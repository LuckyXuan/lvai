using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:video
	/// </summary>
	public partial class video
	{
		public video()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("video_ID", "video"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int video_ID,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from video");
			strSql.Append(" where video_ID=@video_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@video_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = video_ID;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.video model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into video(");
			strSql.Append("user_telphone,video_url,video_uploadtime,video_comment,video_state)");
			strSql.Append(" values (");
			strSql.Append("@user_telphone,@video_url,@video_uploadtime,@video_comment,@video_state)");
			SqlParameter[] parameters = {
					//new SqlParameter("@video_ID", SqlDbType.Int,4)
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@video_url", SqlDbType.VarChar,200),
					new SqlParameter("@video_uploadtime", SqlDbType.DateTime),
					new SqlParameter("@video_comment", SqlDbType.VarChar,200),
					new SqlParameter("@video_state", SqlDbType.VarChar,30)};
			//parameters[0].Value = model.video_ID;
			parameters[0].Value = model.user_telphone;
			parameters[1].Value = model.video_url;
			parameters[2].Value = model.video_uploadtime;
			parameters[3].Value = model.video_comment;
			parameters[4].Value = model.video_state;

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
		public bool Update(la.Model.video model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update video set ");
			strSql.Append("video_url=@video_url,");
			strSql.Append("video_uploadtime=@video_uploadtime,");
			strSql.Append("video_comment=@video_comment,");
			strSql.Append("video_state=@video_state");
			strSql.Append(" where video_ID=@video_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@video_url", SqlDbType.VarChar,200),
					new SqlParameter("@video_uploadtime", SqlDbType.DateTime),
					new SqlParameter("@video_comment", SqlDbType.VarChar,200),
					new SqlParameter("@video_state", SqlDbType.VarChar,30),
					new SqlParameter("@video_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.video_url;
			parameters[1].Value = model.video_uploadtime;
			parameters[2].Value = model.video_comment;
			parameters[3].Value = model.video_state;
			parameters[4].Value = model.video_ID;
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
		public bool Delete(int video_ID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from video ");
			strSql.Append(" where video_ID=@video_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@video_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = video_ID;
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
		public la.Model.video GetModel(int video_ID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 video_ID,user_telphone,video_url,video_uploadtime,video_comment,video_state from video ");
			strSql.Append(" where video_ID=@video_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@video_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = video_ID;
			parameters[1].Value = user_telphone;

			la.Model.video model=new la.Model.video();
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
		public la.Model.video DataRowToModel(DataRow row)
		{
			la.Model.video model=new la.Model.video();
			if (row != null)
			{
				if(row["video_ID"]!=null && row["video_ID"].ToString()!="")
				{
					model.video_ID=int.Parse(row["video_ID"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["video_url"]!=null)
				{
					model.video_url=row["video_url"].ToString();
				}
				if(row["video_uploadtime"]!=null && row["video_uploadtime"].ToString()!="")
				{
					model.video_uploadtime=DateTime.Parse(row["video_uploadtime"].ToString());
				}
				if(row["video_comment"]!=null)
				{
					model.video_comment=row["video_comment"].ToString();
				}
				if(row["video_state"]!=null)
				{
					model.video_state=row["video_state"].ToString();
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
			strSql.Append("select video_ID,user_telphone,video_url,video_uploadtime,video_comment,video_state ");
			strSql.Append(" FROM video ");
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
			strSql.Append(" video_ID,user_telphone,video_url,video_uploadtime,video_comment,video_state ");
			strSql.Append(" FROM video ");
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
			strSql.Append("select count(1) FROM video ");
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
			strSql.Append(")AS Row, T.*  from video T ");
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
			parameters[0].Value = "video";
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

