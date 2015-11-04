using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:audio
	/// </summary>
	public partial class audio
	{
		public audio()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("audio_id", "audio"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int audio_id,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from audio");
			strSql.Append(" where audio_id=@audio_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@audio_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = audio_id;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.audio model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into audio(");
			//strSql.Append("audio_id,user_telphone,audio_url,audio_time,audio_comment,audio_state)");
            strSql.Append("user_telphone,audio_url,audio_time,audio_comment,audio_state)");
			strSql.Append(" values (");
			//strSql.Append("@audio_id,@user_telphone,@audio_url,@audio_time,@audio_comment,@audio_state)");
            strSql.Append("@user_telphone,@audio_url,@audio_time,@audio_comment,@audio_state)");
			SqlParameter[] parameters = {
					//new SqlParameter("@audio_id", SqlDbType.Int,4)
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@audio_url", SqlDbType.VarChar,200),
					new SqlParameter("@audio_time", SqlDbType.DateTime),
					new SqlParameter("@audio_comment", SqlDbType.VarChar,200),
					new SqlParameter("@audio_state", SqlDbType.VarChar,30)};
			//parameters[0].Value = model.audio_id;
			parameters[0].Value = model.user_telphone;
			parameters[1].Value = model.audio_url;
			parameters[2].Value = model.audio_time;
			parameters[3].Value = model.audio_comment;
			parameters[4].Value = model.audio_state;

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
		public bool Update(la.Model.audio model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update audio set ");
			strSql.Append("audio_url=@audio_url,");
			strSql.Append("audio_time=@audio_time,");
			strSql.Append("audio_comment=@audio_comment,");
			strSql.Append("audio_state=@audio_state");
			strSql.Append(" where audio_id=@audio_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@audio_url", SqlDbType.VarChar,200),
					new SqlParameter("@audio_time", SqlDbType.DateTime),
					new SqlParameter("@audio_comment", SqlDbType.VarChar,200),
					new SqlParameter("@audio_state", SqlDbType.VarChar,30),
					new SqlParameter("@audio_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.audio_url;
			parameters[1].Value = model.audio_time;
			parameters[2].Value = model.audio_comment;
			parameters[3].Value = model.audio_state;
			parameters[4].Value = model.audio_id;
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
		public bool Delete(int audio_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from audio ");
			strSql.Append(" where audio_id=@audio_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@audio_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = audio_id;
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
		public la.Model.audio GetModel(int audio_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 audio_id,user_telphone,audio_url,audio_time,audio_comment,audio_state from audio ");
			strSql.Append(" where audio_id=@audio_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@audio_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = audio_id;
			parameters[1].Value = user_telphone;

			la.Model.audio model=new la.Model.audio();
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
		public la.Model.audio DataRowToModel(DataRow row)
		{
			la.Model.audio model=new la.Model.audio();
			if (row != null)
			{
				if(row["audio_id"]!=null && row["audio_id"].ToString()!="")
				{
					model.audio_id=int.Parse(row["audio_id"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["audio_url"]!=null)
				{
					model.audio_url=row["audio_url"].ToString();
				}
				if(row["audio_time"]!=null && row["audio_time"].ToString()!="")
				{
					model.audio_time=DateTime.Parse(row["audio_time"].ToString());
				}
				if(row["audio_comment"]!=null)
				{
					model.audio_comment=row["audio_comment"].ToString();
				}
				if(row["audio_state"]!=null)
				{
					model.audio_state=row["audio_state"].ToString();
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
			strSql.Append("select audio_id,user_telphone,audio_url,audio_time,audio_comment,audio_state ");
			strSql.Append(" FROM audio ");
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
			strSql.Append(" audio_id,user_telphone,audio_url,audio_time,audio_comment,audio_state ");
			strSql.Append(" FROM audio ");
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
			strSql.Append("select count(1) FROM audio ");
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
			strSql.Append(")AS Row, T.*  from audio T ");
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
			parameters[0].Value = "audio";
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

