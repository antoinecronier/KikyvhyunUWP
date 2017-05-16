using Kikyvhyun.Entities.Base;
using Kikyvhyun.Entities.Relations;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

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
        private List<Meeting> meetings;
        private List<People> people;
        #endregion

        #region Properties
        [ManyToMany(typeof(UserMeeting))]
        public List<Meeting> Meetings
        {
            get { return meetings; }
            set
            {
                meetings = value;
                OnPropertyChanged("Meetings");
            }
        }

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

        [OneToMany]
        public List<People> People
        {
            get { return people; }
            set
            {
                people = value;
                OnPropertyChanged("People");
            }
        }
        #endregion

        #region Constructors
        public User()
        {
            meetings = new List<Meeting>();
            people = new List<Entities.People>();
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