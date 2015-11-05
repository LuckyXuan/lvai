using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using la.Model;
using la.BLL;


namespace la.DataServer
{
    public  class AlbumServer
    {

   
        /// <summary>
        /// 根据用户手机号码获取用户的相册列表。
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public static List<la.Model.album> getAlbumListByTel(string tel)
        {
            List<la.Model.album> albumList = new la.BLL.album().GetModelList(" user_telphone='"+tel+"' ");

            foreach (la.Model.album album in albumList)
            {
                album.PhotoList = new la.BLL.personphoto().GetModelList(" album_id="+album.album_id);
            
            }
            return albumList;
        }

    }
}
