using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:smsCode
	/// </summary>
	public partial class smsCode
	{
		public smsCode()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("smscode_id", "smsCode"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int smscode_id,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from smsCode");
			strSql.Append(" where smscode_id=@smscode_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@smscode_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = smscode_id;
			parameters[1].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.smsCode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into smsCode(");
			strSql.Append("user_telphone,smscode_sendtime,smscode)");
			strSql.Append(" values (");
			strSql.Append("@user_telphone,@smscode_sendtime,@smscode)");
			SqlParameter[] parameters = {
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@smscode_sendtime", SqlDbType.DateTime),
					new SqlParameter("@smscode", SqlDbType.VarChar,8)};
			parameters[0].Value = model.user_telphone;
			parameters[1].Value = model.smscode_sendtime;
			parameters[2].Value = model.smscode;

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
		public bool Update(la.Model.smsCode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update smsCode set ");
			strSql.Append("smscode_sendtime=@smscode_sendtime,");
			strSql.Append("smscode=@smscode");
			strSql.Append(" where smscode_id=@smscode_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@smscode_sendtime", SqlDbType.DateTime),
					new SqlParameter("@smscode", SqlDbType.VarChar,8),
					new SqlParameter("@smscode_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.smscode_sendtime;
			parameters[1].Value = model.smscode;
			parameters[2].Value = model.smscode_id;
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
		public bool Delete(int smscode_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from smsCode ");
			strSql.Append(" where smscode_id=@smscode_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@smscode_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = smscode_id;
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
		public la.Model.smsCode GetModel(int smscode_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 smscode_id,user_telphone,smscode_sendtime,smscode from smsCode ");
			strSql.Append(" where smscode_id=@smscode_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@smscode_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = smscode_id;
			parameters[1].Value = user_telphone;

			la.Model.smsCode model=new la.Model.smsCode();
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
		public la.Model.smsCode DataRowToModel(DataRow row)
		{
			la.Model.smsCode model=new la.Model.smsCode();
			if (row != null)
			{
				if(row["smscode_id"]!=null && row["smscode_id"].ToString()!="")
				{
					model.smscode_id=int.Parse(row["smscode_id"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["smscode_sendtime"]!=null && row["smscode_sendtime"].ToString()!="")
				{
					model.smscode_sendtime=DateTime.Parse(row["smscode_sendtime"].ToString());
				}
				if(row["smscode"]!=null)
				{
					model.smscode=row["smscode"].ToString();
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
			strSql.Append("select smscode_id,user_telphone,smscode_sendtime,smscode ");
			strSql.Append(" FROM smsCode ");
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
			strSql.Append(" smscode_id,user_telphone,smscode_sendtime,smscode ");
			strSql.Append(" FROM smsCode ");
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
			strSql.Append("select count(1) FROM smsCode ");
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
			strSql.Append(")AS Row, T.*  from smsCode T ");
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
			parameters[0].Value = "smsCode";
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
        /// <summary>
        /// 获取最后一条验证码信息。
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public Model.smsCode getLastCode(string tel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 smscode_id,user_telphone,smscode_sendtime,smscode from smsCode ");
            strSql.Append(" where user_telphone=@user_telphone order by smscode_sendtime desc ");
            SqlParameter[] parameters = { new SqlParameter("@user_telphone", SqlDbType.VarChar, 20) };
            parameters[0].Value = tel;

            la.Model.smsCode model = new la.Model.smsCode();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


		#endregion  ExtensionMethod
	}
}

