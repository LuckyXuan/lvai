using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:gpslocation
	/// </summary>
	public partial class gpslocation
	{
		public gpslocation()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("gps_id", "gpslocation"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int gps_id,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from gpslocation");
			strSql.Append(" where gps_id=@gps_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@gps_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = gps_id;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.gpslocation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into gpslocation(");
			strSql.Append("user_telphone,location_lat,location_lng)");
			strSql.Append(" values (");
			strSql.Append("@user_telphone,@location_lat,@location_lng)");
			SqlParameter[] parameters = {
					//new SqlParameter("@gps_id", SqlDbType.Int,4)
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@location_lat", SqlDbType.Decimal,9),
					new SqlParameter("@location_lng", SqlDbType.Decimal,9)};
			//parameters[0].Value = model.gps_id;
			parameters[0].Value = model.user_telphone;
			parameters[1].Value = model.location_lat;
			parameters[2].Value = model.location_lng;

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
		public bool Update(la.Model.gpslocation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update gpslocation set ");
			strSql.Append("location_lat=@location_lat,");
			strSql.Append("location_lng=@location_lng");
			strSql.Append(" where gps_id=@gps_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@location_lat", SqlDbType.Decimal,9),
					new SqlParameter("@location_lng", SqlDbType.Decimal,9),
					new SqlParameter("@gps_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.location_lat;
			parameters[1].Value = model.location_lng;
			parameters[2].Value = model.gps_id;
			parameters[3].Value = model.user_telphone;

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
		public bool Delete(int gps_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from gpslocation ");
			strSql.Append(" where gps_id=@gps_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@gps_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = gps_id;
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
		public la.Model.gpslocation GetModel(int gps_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 gps_id,user_telphone,location_lat,location_lng from gpslocation ");
			strSql.Append(" where gps_id=@gps_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@gps_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = gps_id;
			parameters[1].Value = user_telphone;

			la.Model.gpslocation model=new la.Model.gpslocation();
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
		public la.Model.gpslocation DataRowToModel(DataRow row)
		{
			la.Model.gpslocation model=new la.Model.gpslocation();
			if (row != null)
			{
				if(row["gps_id"]!=null && row["gps_id"].ToString()!="")
				{
					model.gps_id=int.Parse(row["gps_id"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["location_lat"]!=null && row["location_lat"].ToString()!="")
				{
					model.location_lat=decimal.Parse(row["location_lat"].ToString());
				}
				if(row["location_lng"]!=null && row["location_lng"].ToString()!="")
				{
					model.location_lng=decimal.Parse(row["location_lng"].ToString());
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
			strSql.Append("select gps_id,user_telphone,location_lat,location_lng ");
			strSql.Append(" FROM gpslocation ");
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
			strSql.Append(" gps_id,user_telphone,location_lat,location_lng ");
			strSql.Append(" FROM gpslocation ");
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
			strSql.Append("select count(1) FROM gpslocation ");
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
			strSql.Append(")AS Row, T.*  from gpslocation T ");
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
			parameters[0].Value = "gpslocation";
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

