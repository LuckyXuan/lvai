using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:virtualgoods
	/// </summary>
	public partial class virtualgoods
	{
		public virtualgoods()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("virtualgoods_ID", "virtualgoods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int virtualgoods_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from virtualgoods");
			strSql.Append(" where virtualgoods_ID=@virtualgoods_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4)			};
			parameters[0].Value = virtualgoods_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.virtualgoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into virtualgoods(");
			strSql.Append("virtualgoods_ID,virtualgoods_name,virtualgoods_price,virtualgoods_comment,virtualgoods_pic_url,virtualgoods_type,virtualgoods_fun)");
			strSql.Append(" values (");
			strSql.Append("@virtualgoods_ID,@virtualgoods_name,@virtualgoods_price,@virtualgoods_comment,@virtualgoods_pic_url,@virtualgoods_type,@virtualgoods_fun)");
			SqlParameter[] parameters = {
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4),
					new SqlParameter("@virtualgoods_name", SqlDbType.VarChar,30),
					new SqlParameter("@virtualgoods_price", SqlDbType.Float,8),
					new SqlParameter("@virtualgoods_comment", SqlDbType.VarChar,200),
					new SqlParameter("@virtualgoods_pic_url", SqlDbType.VarChar,200),
					new SqlParameter("@virtualgoods_type", SqlDbType.VarChar,30),
					new SqlParameter("@virtualgoods_fun", SqlDbType.VarChar,40)};
			parameters[0].Value = model.virtualgoods_ID;
			parameters[1].Value = model.virtualgoods_name;
			parameters[2].Value = model.virtualgoods_price;
			parameters[3].Value = model.virtualgoods_comment;
			parameters[4].Value = model.virtualgoods_pic_url;
			parameters[5].Value = model.virtualgoods_type;
			parameters[6].Value = model.virtualgoods_fun;

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
		public bool Update(la.Model.virtualgoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update virtualgoods set ");
			strSql.Append("virtualgoods_name=@virtualgoods_name,");
			strSql.Append("virtualgoods_price=@virtualgoods_price,");
			strSql.Append("virtualgoods_comment=@virtualgoods_comment,");
			strSql.Append("virtualgoods_pic_url=@virtualgoods_pic_url,");
			strSql.Append("virtualgoods_type=@virtualgoods_type,");
			strSql.Append("virtualgoods_fun=@virtualgoods_fun");
			strSql.Append(" where virtualgoods_ID=@virtualgoods_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@virtualgoods_name", SqlDbType.VarChar,30),
					new SqlParameter("@virtualgoods_price", SqlDbType.Float,8),
					new SqlParameter("@virtualgoods_comment", SqlDbType.VarChar,200),
					new SqlParameter("@virtualgoods_pic_url", SqlDbType.VarChar,200),
					new SqlParameter("@virtualgoods_type", SqlDbType.VarChar,30),
					new SqlParameter("@virtualgoods_fun", SqlDbType.VarChar,40),
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.virtualgoods_name;
			parameters[1].Value = model.virtualgoods_price;
			parameters[2].Value = model.virtualgoods_comment;
			parameters[3].Value = model.virtualgoods_pic_url;
			parameters[4].Value = model.virtualgoods_type;
			parameters[5].Value = model.virtualgoods_fun;
			parameters[6].Value = model.virtualgoods_ID;

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
		public bool Delete(int virtualgoods_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from virtualgoods ");
			strSql.Append(" where virtualgoods_ID=@virtualgoods_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4)			};
			parameters[0].Value = virtualgoods_ID;

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
		public bool DeleteList(string virtualgoods_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from virtualgoods ");
			strSql.Append(" where virtualgoods_ID in ("+virtualgoods_IDlist + ")  ");
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
		public la.Model.virtualgoods GetModel(int virtualgoods_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 virtualgoods_ID,virtualgoods_name,virtualgoods_price,virtualgoods_comment,virtualgoods_pic_url,virtualgoods_type,virtualgoods_fun from virtualgoods ");
			strSql.Append(" where virtualgoods_ID=@virtualgoods_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@virtualgoods_ID", SqlDbType.Int,4)			};
			parameters[0].Value = virtualgoods_ID;

			la.Model.virtualgoods model=new la.Model.virtualgoods();
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
		public la.Model.virtualgoods DataRowToModel(DataRow row)
		{
			la.Model.virtualgoods model=new la.Model.virtualgoods();
			if (row != null)
			{
				if(row["virtualgoods_ID"]!=null && row["virtualgoods_ID"].ToString()!="")
				{
					model.virtualgoods_ID=int.Parse(row["virtualgoods_ID"].ToString());
				}
				if(row["virtualgoods_name"]!=null)
				{
					model.virtualgoods_name=row["virtualgoods_name"].ToString();
				}
				if(row["virtualgoods_price"]!=null && row["virtualgoods_price"].ToString()!="")
				{
					model.virtualgoods_price=decimal.Parse(row["virtualgoods_price"].ToString());
				}
				if(row["virtualgoods_comment"]!=null)
				{
					model.virtualgoods_comment=row["virtualgoods_comment"].ToString();
				}
				if(row["virtualgoods_pic_url"]!=null)
				{
					model.virtualgoods_pic_url=row["virtualgoods_pic_url"].ToString();
				}
				if(row["virtualgoods_type"]!=null)
				{
					model.virtualgoods_type=row["virtualgoods_type"].ToString();
				}
				if(row["virtualgoods_fun"]!=null)
				{
					model.virtualgoods_fun=row["virtualgoods_fun"].ToString();
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
			strSql.Append("select virtualgoods_ID,virtualgoods_name,virtualgoods_price,virtualgoods_comment,virtualgoods_pic_url,virtualgoods_type,virtualgoods_fun ");
			strSql.Append(" FROM virtualgoods ");
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
			strSql.Append(" virtualgoods_ID,virtualgoods_name,virtualgoods_price,virtualgoods_comment,virtualgoods_pic_url,virtualgoods_type,virtualgoods_fun ");
			strSql.Append(" FROM virtualgoods ");
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
			strSql.Append("select count(1) FROM virtualgoods ");
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
			strSql.Append(")AS Row, T.*  from virtualgoods T ");
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
			parameters[0].Value = "virtualgoods";
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

