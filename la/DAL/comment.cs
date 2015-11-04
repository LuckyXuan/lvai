using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:comment
	/// </summary>
	public partial class comment
	{
		public comment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("评价编号", "comment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int 评价编号,int travle_ID,string user_telphone,int 评价字典编号)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from comment");
			strSql.Append(" where 评价编号=@评价编号 and travle_ID=@travle_ID and user_telphone=@user_telphone and 评价字典编号=@评价字典编号 ");
			SqlParameter[] parameters = {
					new SqlParameter("@评价编号", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@评价字典编号", SqlDbType.Int,4)			};
			parameters[0].Value = 评价编号;
			parameters[1].Value = travle_ID;
			parameters[2].Value = user_telphone;
			parameters[3].Value = 评价字典编号;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into comment(");
			strSql.Append("评价编号,travle_ID,user_telphone,评价字典编号,评价时间)");
			strSql.Append(" values (");
			strSql.Append("@评价编号,@travle_ID,@user_telphone,@评价字典编号,@评价时间)");
			SqlParameter[] parameters = {
					new SqlParameter("@评价编号", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@评价字典编号", SqlDbType.Int,4),
					new SqlParameter("@评价时间", SqlDbType.DateTime)};
			parameters[0].Value = model.评价编号;
			parameters[1].Value = model.travle_ID;
			parameters[2].Value = model.user_telphone;
			parameters[3].Value = model.评价字典编号;
			parameters[4].Value = model.评价时间;

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
		public bool Update(la.Model.comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update comment set ");
			strSql.Append("评价时间=@评价时间");
			strSql.Append(" where 评价编号=@评价编号 and travle_ID=@travle_ID and user_telphone=@user_telphone and 评价字典编号=@评价字典编号 ");
			SqlParameter[] parameters = {
					new SqlParameter("@评价时间", SqlDbType.DateTime),
					new SqlParameter("@评价编号", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@评价字典编号", SqlDbType.Int,4)};
			parameters[0].Value = model.评价时间;
			parameters[1].Value = model.评价编号;
			parameters[2].Value = model.travle_ID;
			parameters[3].Value = model.user_telphone;
			parameters[4].Value = model.评价字典编号;

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
		public bool Delete(int 评价编号,int travle_ID,string user_telphone,int 评价字典编号)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from comment ");
			strSql.Append(" where 评价编号=@评价编号 and travle_ID=@travle_ID and user_telphone=@user_telphone and 评价字典编号=@评价字典编号 ");
			SqlParameter[] parameters = {
					new SqlParameter("@评价编号", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@评价字典编号", SqlDbType.Int,4)			};
			parameters[0].Value = 评价编号;
			parameters[1].Value = travle_ID;
			parameters[2].Value = user_telphone;
			parameters[3].Value = 评价字典编号;

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
		public la.Model.comment GetModel(int 评价编号,int travle_ID,string user_telphone,int 评价字典编号)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 评价编号,travle_ID,user_telphone,评价字典编号,评价时间 from comment ");
			strSql.Append(" where 评价编号=@评价编号 and travle_ID=@travle_ID and user_telphone=@user_telphone and 评价字典编号=@评价字典编号 ");
			SqlParameter[] parameters = {
					new SqlParameter("@评价编号", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@评价字典编号", SqlDbType.Int,4)			};
			parameters[0].Value = 评价编号;
			parameters[1].Value = travle_ID;
			parameters[2].Value = user_telphone;
			parameters[3].Value = 评价字典编号;

			la.Model.comment model=new la.Model.comment();
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
		public la.Model.comment DataRowToModel(DataRow row)
		{
			la.Model.comment model=new la.Model.comment();
			if (row != null)
			{
				if(row["评价编号"]!=null && row["评价编号"].ToString()!="")
				{
					model.评价编号=int.Parse(row["评价编号"].ToString());
				}
				if(row["travle_ID"]!=null && row["travle_ID"].ToString()!="")
				{
					model.travle_ID=int.Parse(row["travle_ID"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["评价字典编号"]!=null && row["评价字典编号"].ToString()!="")
				{
					model.评价字典编号=int.Parse(row["评价字典编号"].ToString());
				}
				if(row["评价时间"]!=null && row["评价时间"].ToString()!="")
				{
					model.评价时间=DateTime.Parse(row["评价时间"].ToString());
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
			strSql.Append("select 评价编号,travle_ID,user_telphone,评价字典编号,评价时间 ");
			strSql.Append(" FROM comment ");
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
			strSql.Append(" 评价编号,travle_ID,user_telphone,评价字典编号,评价时间 ");
			strSql.Append(" FROM comment ");
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
			strSql.Append("select count(1) FROM comment ");
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
				strSql.Append("order by T.评价字典编号 desc");
			}
			strSql.Append(")AS Row, T.*  from comment T ");
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
			parameters[0].Value = "comment";
			parameters[1].Value = "评价字典编号";
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

