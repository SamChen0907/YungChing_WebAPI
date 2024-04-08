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
        public DataTable GetUser() //查詢所有User資料
        {
            UserRepository userRepository = new UserRepository();

            return userRepository.GetUser() ;
        }
        public DataTable GetUser(string userid) //依UserID查詢資料
        {
            UserRepository userRepository = new UserRepository();

            return userRepository.GetUser(userid);
        }

        //新增
        public bool AddUser(string userid, string username)
        {
            bool IsAdd = true; // 是否新增

            UserRepository userRepository = new UserRepository();
            int EffectCount = userRepository.AddUser(userid, username);

            if (EffectCount > 0)
                IsAdd = true;
            else
                IsAdd = false;

            return IsAdd;
        }
        //刪除
        public bool DelUser(string userid)
        {
            bool IsDel = true; //是否刪除

            UserRepository userRepository = new UserRepository();
            int EffectCount = userRepository.DelUser(userid);

            if (EffectCount > 0)
                IsDel = true;
            else
                IsDel = false;


            return IsDel;
        }
        //修改
        public bool UpdUser(string userid, string username)
        {
            bool IsUpd; //是否修改

            UserRepository userRepository = new UserRepository();
            int EffectCount = userRepository.UpdUser(userid, username);

            if (EffectCount > 0)
                IsUpd = true;
            else
                IsUpd = false;

            return IsUpd;
        }
    }
}