using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:travel
	/// </summary>
	public partial class travel
	{
		public travel()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("travle_ID", "travel"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int travle_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from travel");
			strSql.Append(" where travle_ID=@travle_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@travle_ID", SqlDbType.Int,4)			};
			parameters[0].Value = travle_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.travel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into travel(");
			strSql.Append("travle_ID,promoter_userid,release_time,Destination,startplace,return_time,start_time,transportation,fee,travle_theme,travle_personcount,companion_condition,travle_msg,pic1,pic2,pic3,income_condition,car_condition,height_condition,credit_condition,wantget_gift,wantsend_gift,reg_fee)");
			strSql.Append(" values (");
			strSql.Append("@travle_ID,@promoter_userid,@release_time,@Destination,@startplace,@return_time,@start_time,@transportation,@fee,@travle_theme,@travle_personcount,@companion_condition,@travle_msg,@pic1,@pic2,@pic3,@income_condition,@car_condition,@height_condition,@credit_condition,@wantget_gift,@wantsend_gift,@reg_fee)");
			SqlParameter[] parameters = {
					new SqlParameter("@travle_ID", SqlDbType.Int,4),
					new SqlParameter("@promoter_userid", SqlDbType.Int,4),
					new SqlParameter("@release_time", SqlDbType.DateTime),
					new SqlParameter("@Destination", SqlDbType.VarChar,200),
					new SqlParameter("@startplace", SqlDbType.VarChar,50),
					new SqlParameter("@return_time", SqlDbType.DateTime),
					new SqlParameter("@start_time", SqlDbType.DateTime),
					new SqlParameter("@transportation", SqlDbType.VarChar,30),
					new SqlParameter("@fee", SqlDbType.VarChar,40),
					new SqlParameter("@travle_theme", SqlDbType.VarChar,100),
					new SqlParameter("@travle_personcount", SqlDbType.Int,4),
					new SqlParameter("@companion_condition", SqlDbType.VarChar,200),
					new SqlParameter("@travle_msg", SqlDbType.VarChar,400),
					new SqlParameter("@pic1", SqlDbType.VarChar,200),
					new SqlParameter("@pic2", SqlDbType.VarChar,200),
					new SqlParameter("@pic3", SqlDbType.VarChar,200),
					new SqlParameter("@income_condition", SqlDbType.VarChar,30),
					new SqlParameter("@car_condition", SqlDbType.VarChar,30),
					new SqlParameter("@height_condition", SqlDbType.VarChar,30),
					new SqlParameter("@credit_condition", SqlDbType.VarChar,30),
					new SqlParameter("@wantget_gift", SqlDbType.VarChar,30),
					new SqlParameter("@wantsend_gift", SqlDbType.VarChar,30),
					new SqlParameter("@reg_fee", SqlDbType.Float,8)};
			parameters[0].Value = model.travle_ID;
			parameters[1].Value = model.promoter_userid;
			parameters[2].Value = model.release_time;
			parameters[3].Value = model.Destination;
			parameters[4].Value = model.startplace;
			parameters[5].Value = model.return_time;
			parameters[6].Value = model.start_time;
			parameters[7].Value = model.transportation;
			parameters[8].Value = model.fee;
			parameters[9].Value = model.travle_theme;
			parameters[10].Value = model.travle_personcount;
			parameters[11].Value = model.companion_condition;
			parameters[12].Value = model.travle_msg;
			parameters[13].Value = model.pic1;
			parameters[14].Value = model.pic2;
			parameters[15].Value = model.pic3;
			parameters[16].Value = model.income_condition;
			parameters[17].Value = model.car_condition;
			parameters[18].Value = model.height_condition;
			parameters[19].Value = model.credit_condition;
			parameters[20].Value = model.wantget_gift;
			parameters[21].Value = model.wantsend_gift;
			parameters[22].Value = model.reg_fee;

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
		public bool Update(la.Model.travel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update travel set ");
			strSql.Append("promoter_userid=@promoter_userid,");
			strSql.Append("release_time=@release_time,");
			strSql.Append("Destination=@Destination,");
			strSql.Append("startplace=@startplace,");
			strSql.Append("return_time=@return_time,");
			strSql.Append("start_time=@start_time,");
			strSql.Append("transportation=@transportation,");
			strSql.Append("fee=@fee,");
			strSql.Append("travle_theme=@travle_theme,");
			strSql.Append("travle_personcount=@travle_personcount,");
			strSql.Append("companion_condition=@companion_condition,");
			strSql.Append("travle_msg=@travle_msg,");
			strSql.Append("pic1=@pic1,");
			strSql.Append("pic2=@pic2,");
			strSql.Append("pic3=@pic3,");
			strSql.Append("income_condition=@income_condition,");
			strSql.Append("car_condition=@car_condition,");
			strSql.Append("height_condition=@height_condition,");
			strSql.Append("credit_condition=@credit_condition,");
			strSql.Append("wantget_gift=@wantget_gift,");
			strSql.Append("wantsend_gift=@wantsend_gift,");
			strSql.Append("reg_fee=@reg_fee");
			strSql.Append(" where travle_ID=@travle_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@promoter_userid", SqlDbType.Int,4),
					new SqlParameter("@release_time", SqlDbType.DateTime),
					new SqlParameter("@Destination", SqlDbType.VarChar,200),
					new SqlParameter("@startplace", SqlDbType.VarChar,50),
					new SqlParameter("@return_time", SqlDbType.DateTime),
					new SqlParameter("@start_time", SqlDbType.DateTime),
					new SqlParameter("@transportation", SqlDbType.VarChar,30),
					new SqlParameter("@fee", SqlDbType.VarChar,40),
					new SqlParameter("@travle_theme", SqlDbType.VarChar,100),
					new SqlParameter("@travle_personcount", SqlDbType.Int,4),
					new SqlParameter("@companion_condition", SqlDbType.VarChar,200),
					new SqlParameter("@travle_msg", SqlDbType.VarChar,400),
					new SqlParameter("@pic1", SqlDbType.VarChar,200),
					new SqlParameter("@pic2", SqlDbType.VarChar,200),
					new SqlParameter("@pic3", SqlDbType.VarChar,200),
					new SqlParameter("@income_condition", SqlDbType.VarChar,30),
					new SqlParameter("@car_condition", SqlDbType.VarChar,30),
					new SqlParameter("@height_condition", SqlDbType.VarChar,30),
					new SqlParameter("@credit_condition", SqlDbType.VarChar,30),
					new SqlParameter("@wantget_gift", SqlDbType.VarChar,30),
					new SqlParameter("@wantsend_gift", SqlDbType.VarChar,30),
					new SqlParameter("@reg_fee", SqlDbType.Float,8),
					new SqlParameter("@travle_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.promoter_userid;
			parameters[1].Value = model.release_time;
			parameters[2].Value = model.Destination;
			parameters[3].Value = model.startplace;
			parameters[4].Value = model.return_time;
			parameters[5].Value = model.start_time;
			parameters[6].Value = model.transportation;
			parameters[7].Value = model.fee;
			parameters[8].Value = model.travle_theme;
			parameters[9].Value = model.travle_personcount;
			parameters[10].Value = model.companion_condition;
			parameters[11].Value = model.travle_msg;
			parameters[12].Value = model.pic1;
			parameters[13].Value = model.pic2;
			parameters[14].Value = model.pic3;
			parameters[15].Value = model.income_condition;
			parameters[16].Value = model.car_condition;
			parameters[17].Value = model.height_condition;
			parameters[18].Value = model.credit_condition;
			parameters[19].Value = model.wantget_gift;
			parameters[20].Value = model.wantsend_gift;
			parameters[21].Value = model.reg_fee;
			parameters[22].Value = model.travle_ID;

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
		public bool Delete(int travle_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from travel ");
			strSql.Append(" where travle_ID=@travle_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@travle_ID", SqlDbType.Int,4)			};
			parameters[0].Value = travle_ID;

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
		public bool DeleteList(string travle_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from travel ");
			strSql.Append(" where travle_ID in ("+travle_IDlist + ")  ");
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
		public la.Model.travel GetModel(int travle_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 travle_ID,promoter_userid,release_time,Destination,startplace,return_time,start_time,transportation,fee,travle_theme,travle_personcount,companion_condition,travle_msg,pic1,pic2,pic3,income_condition,car_condition,height_condition,credit_condition,wantget_gift,wantsend_gift,reg_fee from travel ");
			strSql.Append(" where travle_ID=@travle_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@travle_ID", SqlDbType.Int,4)			};
			parameters[0].Value = travle_ID;

			la.Model.travel model=new la.Model.travel();
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
		public la.Model.travel DataRowToModel(DataRow row)
		{
			la.Model.travel model=new la.Model.travel();
			if (row != null)
			{
				if(row["travle_ID"]!=null && row["travle_ID"].ToString()!="")
				{
					model.travle_ID=int.Parse(row["travle_ID"].ToString());
				}
				if(row["promoter_userid"]!=null && row["promoter_userid"].ToString()!="")
				{
					model.promoter_userid=int.Parse(row["promoter_userid"].ToString());
				}
				if(row["release_time"]!=null && row["release_time"].ToString()!="")
				{
					model.release_time=DateTime.Parse(row["release_time"].ToString());
				}
				if(row["Destination"]!=null)
				{
					model.Destination=row["Destination"].ToString();
				}
				if(row["startplace"]!=null)
				{
					model.startplace=row["startplace"].ToString();
				}
				if(row["return_time"]!=null && row["return_time"].ToString()!="")
				{
					model.return_time=DateTime.Parse(row["return_time"].ToString());
				}
				if(row["start_time"]!=null && row["start_time"].ToString()!="")
				{
					model.start_time=DateTime.Parse(row["start_time"].ToString());
				}
				if(row["transportation"]!=null)
				{
					model.transportation=row["transportation"].ToString();
				}
				if(row["fee"]!=null)
				{
					model.fee=row["fee"].ToString();
				}
				if(row["travle_theme"]!=null)
				{
					model.travle_theme=row["travle_theme"].ToString();
				}
				if(row["travle_personcount"]!=null && row["travle_personcount"].ToString()!="")
				{
					model.travle_personcount=int.Parse(row["travle_personcount"].ToString());
				}
				if(row["companion_condition"]!=null)
				{
					model.companion_condition=row["companion_condition"].ToString();
				}
				if(row["travle_msg"]!=null)
				{
					model.travle_msg=row["travle_msg"].ToString();
				}
				if(row["pic1"]!=null)
				{
					model.pic1=row["pic1"].ToString();
				}
				if(row["pic2"]!=null)
				{
					model.pic2=row["pic2"].ToString();
				}
				if(row["pic3"]!=null)
				{
					model.pic3=row["pic3"].ToString();
				}
				if(row["income_condition"]!=null)
				{
					model.income_condition=row["income_condition"].ToString();
				}
				if(row["car_condition"]!=null)
				{
					model.car_condition=row["car_condition"].ToString();
				}
				if(row["height_condition"]!=null)
				{
					model.height_condition=row["height_condition"].ToString();
				}
				if(row["credit_condition"]!=null)
				{
					model.credit_condition=row["credit_condition"].ToString();
				}
				if(row["wantget_gift"]!=null)
				{
					model.wantget_gift=row["wantget_gift"].ToString();
				}
				if(row["wantsend_gift"]!=null)
				{
					model.wantsend_gift=row["wantsend_gift"].ToString();
				}
				if(row["reg_fee"]!=null && row["reg_fee"].ToString()!="")
				{
					model.reg_fee=decimal.Parse(row["reg_fee"].ToString());
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
			strSql.Append("select travle_ID,promoter_userid,release_time,Destination,startplace,return_time,start_time,transportation,fee,travle_theme,travle_personcount,companion_condition,travle_msg,pic1,pic2,pic3,income_condition,car_condition,height_condition,credit_condition,wantget_gift,wantsend_gift,reg_fee ");
			strSql.Append(" FROM travel ");
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
			strSql.Append(" travle_ID,promoter_userid,release_time,Destination,startplace,return_time,start_time,transportation,fee,travle_theme,travle_personcount,companion_condition,travle_msg,pic1,pic2,pic3,income_condition,car_condition,height_condition,credit_condition,wantget_gift,wantsend_gift,reg_fee ");
			strSql.Append(" FROM travel ");
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
			strSql.Append("select count(1) FROM travel ");
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
				strSql.Append("order by T.travle_ID desc");
			}
			strSql.Append(")AS Row, T.*  from travel T ");
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
			parameters[0].Value = "travel";
			parameters[1].Value = "travle_ID";
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

