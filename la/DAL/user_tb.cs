using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:user_tb
	/// </summary>
	public partial class user_tb
	{
		public user_tb()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from user_tb");
			strSql.Append(" where user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.user_tb model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into user_tb(");
			strSql.Append("user_telphone,user_sex,user_nikeName,user_photo,user_birthday,user_height,user_weight,user_address,user_job,user_income,user_pwd,user_marrystate,user_edu,personcenter_bg,user_photo_state,user_state)");
			strSql.Append(" values (");
			strSql.Append("@user_telphone,@user_sex,@user_nikeName,@user_photo,@user_birthday,@user_height,@user_weight,@user_address,@user_job,@user_income,@user_pwd,@user_marrystate,@user_edu,@personcenter_bg,@user_photo_state,@user_state)");
			SqlParameter[] parameters = {
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@user_sex", SqlDbType.Bit,1),
					new SqlParameter("@user_nikeName", SqlDbType.VarChar,40),
					new SqlParameter("@user_photo", SqlDbType.VarChar,100),
					new SqlParameter("@user_birthday", SqlDbType.DateTime),
					new SqlParameter("@user_height", SqlDbType.VarChar,20),
					new SqlParameter("@user_weight", SqlDbType.VarChar,20),
					new SqlParameter("@user_address", SqlDbType.VarChar,50),
					new SqlParameter("@user_job", SqlDbType.VarChar,40),
					new SqlParameter("@user_income", SqlDbType.VarChar,20),
					new SqlParameter("@user_pwd", SqlDbType.VarChar,100),
					new SqlParameter("@user_marrystate", SqlDbType.VarChar,20),
					new SqlParameter("@user_edu", SqlDbType.VarChar,20),
					new SqlParameter("@personcenter_bg", SqlDbType.VarChar,200),
					new SqlParameter("@user_photo_state", SqlDbType.VarChar,30),
					new SqlParameter("@user_state", SqlDbType.VarChar,20)};
			parameters[0].Value = model.user_telphone;
			parameters[1].Value = model.user_sex;
			parameters[2].Value = model.user_nikeName;
			parameters[3].Value = model.user_photo;
			parameters[4].Value = model.user_birthday;
			parameters[5].Value = model.user_height;
			parameters[6].Value = model.user_weight;
			parameters[7].Value = model.user_address;
			parameters[8].Value = model.user_job;
			parameters[9].Value = model.user_income;
			parameters[10].Value = model.user_pwd;
			parameters[11].Value = model.user_marrystate;
			parameters[12].Value = model.user_edu;
			parameters[13].Value = model.personcenter_bg;
			parameters[14].Value = model.user_photo_state;
			parameters[15].Value = model.user_state;

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
		public bool Update(la.Model.user_tb model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update user_tb set ");
			strSql.Append("user_sex=@user_sex,");
			strSql.Append("user_nikeName=@user_nikeName,");
			strSql.Append("user_photo=@user_photo,");
			strSql.Append("user_birthday=@user_birthday,");
			strSql.Append("user_height=@user_height,");
			strSql.Append("user_weight=@user_weight,");
			strSql.Append("user_address=@user_address,");
			strSql.Append("user_job=@user_job,");
			strSql.Append("user_income=@user_income,");
			strSql.Append("user_pwd=@user_pwd,");
			strSql.Append("user_marrystate=@user_marrystate,");
			strSql.Append("user_edu=@user_edu,");
			strSql.Append("personcenter_bg=@personcenter_bg,");
			strSql.Append("user_photo_state=@user_photo_state,");
			strSql.Append("user_state=@user_state");
			strSql.Append(" where user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@user_sex", SqlDbType.Bit,1),
					new SqlParameter("@user_nikeName", SqlDbType.VarChar,40),
					new SqlParameter("@user_photo", SqlDbType.VarChar,100),
					new SqlParameter("@user_birthday", SqlDbType.DateTime),
					new SqlParameter("@user_height", SqlDbType.VarChar,20),
					new SqlParameter("@user_weight", SqlDbType.VarChar,20),
					new SqlParameter("@user_address", SqlDbType.VarChar,50),
					new SqlParameter("@user_job", SqlDbType.VarChar,40),
					new SqlParameter("@user_income", SqlDbType.VarChar,20),
					new SqlParameter("@user_pwd", SqlDbType.VarChar,100),
					new SqlParameter("@user_marrystate", SqlDbType.VarChar,20),
					new SqlParameter("@user_edu", SqlDbType.VarChar,20),
					new SqlParameter("@personcenter_bg", SqlDbType.VarChar,200),
					new SqlParameter("@user_photo_state", SqlDbType.VarChar,30),
					new SqlParameter("@user_state", SqlDbType.VarChar,20),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.user_sex;
			parameters[1].Value = model.user_nikeName;
			parameters[2].Value = model.user_photo;
			parameters[3].Value = model.user_birthday;
			parameters[4].Value = model.user_height;
			parameters[5].Value = model.user_weight;
			parameters[6].Value = model.user_address;
			parameters[7].Value = model.user_job;
			parameters[8].Value = model.user_income;
			parameters[9].Value = model.user_pwd;
			parameters[10].Value = model.user_marrystate;
			parameters[11].Value = model.user_edu;
			parameters[12].Value = model.personcenter_bg;
			parameters[13].Value = model.user_photo_state;
			parameters[14].Value = model.user_state;
			parameters[15].Value = model.user_telphone;

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
		public bool Delete(string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from user_tb ");
			strSql.Append(" where user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = user_telphone;

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
		public bool DeleteList(string user_telphonelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from user_tb ");
			strSql.Append(" where user_telphone in ("+user_telphonelist + ")  ");
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
		public la.Model.user_tb GetModel(string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 user_telphone,user_sex,user_nikeName,user_photo,user_birthday,user_height,user_weight,user_address,user_job,user_income,user_pwd,user_marrystate,user_edu,personcenter_bg,user_photo_state,user_state from user_tb ");
			strSql.Append(" where user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = user_telphone;

			la.Model.user_tb model=new la.Model.user_tb();
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
		public la.Model.user_tb DataRowToModel(DataRow row)
		{
			la.Model.user_tb model=new la.Model.user_tb();
			if (row != null)
			{
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["user_sex"]!=null && row["user_sex"].ToString()!="")
				{
					if((row["user_sex"].ToString()=="1")||(row["user_sex"].ToString().ToLower()=="true"))
					{
						model.user_sex=true;
					}
					else
					{
						model.user_sex=false;
					}
				}
				if(row["user_nikeName"]!=null)
				{
					model.user_nikeName=row["user_nikeName"].ToString();
				}
				if(row["user_photo"]!=null)
				{
					model.user_photo=row["user_photo"].ToString();
				}
				if(row["user_birthday"]!=null && row["user_birthday"].ToString()!="")
				{
					model.user_birthday=DateTime.Parse(row["user_birthday"].ToString());
				}
				if(row["user_height"]!=null)
				{
					model.user_height=row["user_height"].ToString();
				}
				if(row["user_weight"]!=null)
				{
					model.user_weight=row["user_weight"].ToString();
				}
				if(row["user_address"]!=null)
				{
					model.user_address=row["user_address"].ToString();
				}
				if(row["user_job"]!=null)
				{
					model.user_job=row["user_job"].ToString();
				}
				if(row["user_income"]!=null)
				{
					model.user_income=row["user_income"].ToString();
				}
				if(row["user_pwd"]!=null)
				{
					model.user_pwd=row["user_pwd"].ToString();
				}
				if(row["user_marrystate"]!=null)
				{
					model.user_marrystate=row["user_marrystate"].ToString();
				}
				if(row["user_edu"]!=null)
				{
					model.user_edu=row["user_edu"].ToString();
				}
				if(row["personcenter_bg"]!=null)
				{
					model.personcenter_bg=row["personcenter_bg"].ToString();
				}
				if(row["user_photo_state"]!=null)
				{
					model.user_photo_state=row["user_photo_state"].ToString();
				}
				if(row["user_state"]!=null)
				{
					model.user_state=row["user_state"].ToString();
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
			strSql.Append("select user_telphone,user_sex,user_nikeName,user_photo,user_birthday,user_height,user_weight,user_address,user_job,user_income,user_pwd,user_marrystate,user_edu,personcenter_bg,user_photo_state,user_state ");
			strSql.Append(" FROM user_tb ");
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
			strSql.Append(" user_telphone,user_sex,user_nikeName,user_photo,user_birthday,user_height,user_weight,user_address,user_job,user_income,user_pwd,user_marrystate,user_edu,personcenter_bg,user_photo_state,user_state ");
			strSql.Append(" FROM user_tb ");
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
			strSql.Append("select count(1) FROM user_tb ");
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
			strSql.Append(")AS Row, T.*  from user_tb T ");
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
			parameters[0].Value = "user_tb";
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

