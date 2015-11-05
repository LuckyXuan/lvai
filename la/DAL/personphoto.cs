using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:personphoto
	/// </summary>
	public partial class personphoto
	{
		public personphoto()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("personphoto_id", "personphoto"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int personphoto_id,int album_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from personphoto");
			strSql.Append(" where personphoto_id=@personphoto_id and album_id=@album_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@personphoto_id", SqlDbType.Int,4),
					new SqlParameter("@album_id", SqlDbType.Int,4)			};
			parameters[0].Value = personphoto_id;
			parameters[1].Value = album_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.personphoto model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into personphoto(");
			strSql.Append("album_id,personphoto_path)");
			strSql.Append(" values (");
			strSql.Append("@album_id,@personphoto_path)");
			SqlParameter[] parameters = {
					
					new SqlParameter("@album_id", SqlDbType.Int,4),
					new SqlParameter("@personphoto_path", SqlDbType.VarChar,200)};
			
			parameters[0].Value = model.album_id;
			parameters[1].Value = model.personphoto_path;

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
		public bool Update(la.Model.personphoto model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update personphoto set ");
			strSql.Append("personphoto_path=@personphoto_path");
			strSql.Append(" where personphoto_id=@personphoto_id and album_id=@album_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@personphoto_path", SqlDbType.VarChar,200),
					new SqlParameter("@personphoto_id", SqlDbType.Int,4),
					new SqlParameter("@album_id", SqlDbType.Int,4)};
			parameters[0].Value = model.personphoto_path;
			parameters[1].Value = model.personphoto_id;
			parameters[2].Value = model.album_id;

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
		public bool Delete(int personphoto_id,int album_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from personphoto ");
			strSql.Append(" where personphoto_id=@personphoto_id and album_id=@album_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@personphoto_id", SqlDbType.Int,4),
					new SqlParameter("@album_id", SqlDbType.Int,4)			};
			parameters[0].Value = personphoto_id;
			parameters[1].Value = album_id;

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
		public la.Model.personphoto GetModel(int personphoto_id,int album_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 personphoto_id,album_id,personphoto_path from personphoto ");
			strSql.Append(" where personphoto_id=@personphoto_id and album_id=@album_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@personphoto_id", SqlDbType.Int,4),
					new SqlParameter("@album_id", SqlDbType.Int,4)			};
			parameters[0].Value = personphoto_id;
			parameters[1].Value = album_id;

			la.Model.personphoto model=new la.Model.personphoto();
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
		public la.Model.personphoto DataRowToModel(DataRow row)
		{
			la.Model.personphoto model=new la.Model.personphoto();
			if (row != null)
			{
				if(row["personphoto_id"]!=null && row["personphoto_id"].ToString()!="")
				{
					model.personphoto_id=int.Parse(row["personphoto_id"].ToString());
				}
				if(row["album_id"]!=null && row["album_id"].ToString()!="")
				{
					model.album_id=int.Parse(row["album_id"].ToString());
				}
				if(row["personphoto_path"]!=null)
				{
					model.personphoto_path=row["personphoto_path"].ToString();
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
			strSql.Append("select personphoto_id,album_id,personphoto_path ");
			strSql.Append(" FROM personphoto ");
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
			strSql.Append(" personphoto_id,album_id,personphoto_path ");
			strSql.Append(" FROM personphoto ");
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
			strSql.Append("select count(1) FROM personphoto ");
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
				strSql.Append("order by T.album_id desc");
			}
			strSql.Append(")AS Row, T.*  from personphoto T ");
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
			parameters[0].Value = "personphoto";
			parameters[1].Value = "album_id";
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

