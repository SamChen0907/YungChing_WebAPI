using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using YungChing_WebAPI.Repository;

namespace YungChing_WebAPI.Service
{
    public class UserService
    {
        //查詢
        public static DataTable GetUser() //查詢所有User資料
        {
            DataTable dt = UserRepository.GetUser();

            return dt;
        }
        public static DataTable GetUser(string userid) //依UserID查詢資料
        {
            DataTable dt = UserRepository.GetUser(userid);


            return dt;
        }

        //新增
        public static bool AddUser(string userid, string username)
        {
            bool IsAdd = true; // 是否新增

            int EffectCount = UserRepository.AddUser(userid, username);

            if (EffectCount > 0)
                IsAdd = true;
            else
                IsAdd = false;

            return IsAdd;
        }
        //刪除
        public static bool DelUser(string userid)
        {
            bool IsDel = true; //是否刪除

            int EffectCount = UserRepository.DelUser(userid);

            if (EffectCount > 0)
                IsDel = true;
            else
                IsDel = false;


            return IsDel;
        }
        //修改
        public static bool UpdUser(string userid, string username)
        {
            bool IsUpd; //是否修改

            int EffectCount = UserRepository.UpdUser(userid, username);

            if (EffectCount > 0)
                IsUpd = true;
            else
                IsUpd = false;

            return IsUpd;
        }
    }
}