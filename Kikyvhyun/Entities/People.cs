using Kikyvhyun.Entities.Base;
using Kikyvhyun.Entities.Relations;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace Kikyvhyun.Entities
{
    public class People : EntityBase
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private Boolean? hasAccept;
        private DateTime changeTime;
        private User user;
        private List<Meeting> meetings;
        private int userId;
        #endregion

        #region Properties
        [ManyToMany(typeof(PeopleMeeting))]
        public List<Meeting> Meetings
        {
            get { return meetings; }
            set
            {
                meetings = value;
                OnPropertyChanged("Meetings");
            }
        }

        [ManyToOne]
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public DateTime ChangeTime
        {
            get { return changeTime; }
            set
            {
                changeTime = value;
                OnPropertyChanged("ChangeTime");
            }
        }

        public Boolean? HasAccept
        {
            get { return hasAccept; }
            set
            {
                hasAccept = value;
                OnPropertyChanged("HasAccept");
            }
        }

        [ForeignKey(typeof(User))]
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        #endregion

        #region Constructors
        public People()
        {
            meetings = new List<Meeting>();
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