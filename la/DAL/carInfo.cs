using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:carInfo
	/// </summary>
	public partial class carInfo
	{
		public carInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("car_id", "carInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int car_id,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from carInfo");
			strSql.Append(" where car_id=@car_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@car_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = car_id;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.carInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into carInfo(");
			strSql.Append("user_telphone,car_level,car_brand,car_type,car_photo1,car_photo2,car_photo3,car_photo1_state,car_photo2_state,car_photo3_state)");
			strSql.Append(" values (");
			strSql.Append("@user_telphone,@car_level,@car_brand,@car_type,@car_photo1,@car_photo2,@car_photo3,@car_photo1_state,@car_photo2_state,@car_photo3_state)");
			SqlParameter[] parameters = {
					//new SqlParameter("@car_id", SqlDbType.Int,4)
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@car_level", SqlDbType.VarChar,50),
					new SqlParameter("@car_brand", SqlDbType.VarChar,30),
					new SqlParameter("@car_type", SqlDbType.VarChar,30),
					new SqlParameter("@car_photo1", SqlDbType.VarChar,200),
					new SqlParameter("@car_photo2", SqlDbType.VarChar,200),
					new SqlParameter("@car_photo3", SqlDbType.VarChar,200),
					new SqlParameter("@car_photo1_state", SqlDbType.VarChar,30),
					new SqlParameter("@car_photo2_state", SqlDbType.VarChar,30),
					new SqlParameter("@car_photo3_state", SqlDbType.VarChar,30)};
			//parameters[0].Value = model.car_id;
			parameters[0].Value = model.user_telphone;
			parameters[1].Value = model.car_level;
			parameters[2].Value = model.car_brand;
			parameters[3].Value = model.car_type;
			parameters[4].Value = model.car_photo1;
			parameters[5].Value = model.car_photo2;
			parameters[6].Value = model.car_photo3;
			parameters[7].Value = model.car_photo1_state;
			parameters[8].Value = model.car_photo2_state;
			parameters[9].Value = model.car_photo3_state;

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
		public bool Update(la.Model.carInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update carInfo set ");
			strSql.Append("car_level=@car_level,");
			strSql.Append("car_brand=@car_brand,");
			strSql.Append("car_type=@car_type,");
			strSql.Append("car_photo1=@car_photo1,");
			strSql.Append("car_photo2=@car_photo2,");
			strSql.Append("car_photo3=@car_photo3,");
			strSql.Append("car_photo1_state=@car_photo1_state,");
			strSql.Append("car_photo2_state=@car_photo2_state,");
			strSql.Append("car_photo3_state=@car_photo3_state");
			strSql.Append(" where car_id=@car_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@car_level", SqlDbType.VarChar,50),
					new SqlParameter("@car_brand", SqlDbType.VarChar,30),
					new SqlParameter("@car_type", SqlDbType.VarChar,30),
					new SqlParameter("@car_photo1", SqlDbType.VarChar,200),
					new SqlParameter("@car_photo2", SqlDbType.VarChar,200),
					new SqlParameter("@car_photo3", SqlDbType.VarChar,200),
					new SqlParameter("@car_photo1_state", SqlDbType.VarChar,30),
					new SqlParameter("@car_photo2_state", SqlDbType.VarChar,30),
					new SqlParameter("@car_photo3_state", SqlDbType.VarChar,30),
					new SqlParameter("@car_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.car_level;
			parameters[1].Value = model.car_brand;
			parameters[2].Value = model.car_type;
			parameters[3].Value = model.car_photo1;
			parameters[4].Value = model.car_photo2;
			parameters[5].Value = model.car_photo3;
			parameters[6].Value = model.car_photo1_state;
			parameters[7].Value = model.car_photo2_state;
			parameters[8].Value = model.car_photo3_state;
			parameters[9].Value = model.car_id;
			parameters[10].Value = model.user_telphone;

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
		public bool Delete(int car_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from carInfo ");
			strSql.Append(" where car_id=@car_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@car_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = car_id;
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
		public la.Model.carInfo GetModel(int car_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 car_id,user_telphone,car_level,car_brand,car_type,car_photo1,car_photo2,car_photo3,car_photo1_state,car_photo2_state,car_photo3_state from carInfo ");
			strSql.Append(" where car_id=@car_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@car_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = car_id;
			parameters[1].Value = user_telphone;

			la.Model.carInfo model=new la.Model.carInfo();
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
		public la.Model.carInfo DataRowToModel(DataRow row)
		{
			la.Model.carInfo model=new la.Model.carInfo();
			if (row != null)
			{
				if(row["car_id"]!=null && row["car_id"].ToString()!="")
				{
					model.car_id=int.Parse(row["car_id"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["car_level"]!=null)
				{
					model.car_level=row["car_level"].ToString();
				}
				if(row["car_brand"]!=null)
				{
					model.car_brand=row["car_brand"].ToString();
				}
				if(row["car_type"]!=null)
				{
					model.car_type=row["car_type"].ToString();
				}
				if(row["car_photo1"]!=null)
				{
					model.car_photo1=row["car_photo1"].ToString();
				}
				if(row["car_photo2"]!=null)
				{
					model.car_photo2=row["car_photo2"].ToString();
				}
				if(row["car_photo3"]!=null)
				{
					model.car_photo3=row["car_photo3"].ToString();
				}
				if(row["car_photo1_state"]!=null)
				{
					model.car_photo1_state=row["car_photo1_state"].ToString();
				}
				if(row["car_photo2_state"]!=null)
				{
					model.car_photo2_state=row["car_photo2_state"].ToString();
				}
				if(row["car_photo3_state"]!=null)
				{
					model.car_photo3_state=row["car_photo3_state"].ToString();
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
			strSql.Append("select car_id,user_telphone,car_level,car_brand,car_type,car_photo1,car_photo2,car_photo3,car_photo1_state,car_photo2_state,car_photo3_state ");
			strSql.Append(" FROM carInfo ");
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
			strSql.Append(" car_id,user_telphone,car_level,car_brand,car_type,car_photo1,car_photo2,car_photo3,car_photo1_state,car_photo2_state,car_photo3_state ");
			strSql.Append(" FROM carInfo ");
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
			strSql.Append("select count(1) FROM carInfo ");
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
			strSql.Append(")AS Row, T.*  from carInfo T ");
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
			parameters[0].Value = "carInfo";
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

