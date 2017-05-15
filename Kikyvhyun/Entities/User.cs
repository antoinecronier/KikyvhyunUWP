using Kikyvhyun.Entities.Base;
using System;

namespace Kikyvhyun.Entities
{
    public class User : EntityBase
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String userFirstName;
        private String userLastname;
        private String userNickname;
        private String userLogin;
        private String userPassword;
        #endregion

        #region Properties
        public String UserPassword
        {
            get { return userPassword; }
            set
            {
                userPassword = value;
                OnPropertyChanged("UserPassword");
            }
        }

        public String UserLogin
        {
            get { return userLogin; }
            set
            {
                userLogin = value;
                OnPropertyChanged("UserLogin");
            }
        }

        public String UserNickname
        {
            get { return userNickname; }
            set
            {
                userNickname = value;
                OnPropertyChanged("UserNickname");
            }
        }

        public String UserLastname
        {
            get { return userLastname; }
            set
            {
                userLastname = value;
                OnPropertyChanged("UserLastname");
            }
        }

        public String UserFirstName
        {
            get { return userFirstName; }
            set
            {
                userFirstName = value;
                OnPropertyChanged("UserFirstName");
            }
        }
        #endregion

        #region Constructors
        public User()
        {

        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion


    }
}