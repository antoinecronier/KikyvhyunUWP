using Kikyvhyun.Entities.Base;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kikyvhyun.Entities
{
    public class Meeting : EntityBase
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private DateTime meetingStart;
        private DateTime meetingEnd;
        private String meetingName;
        private List<People> people;
        private List<User> users;
        private List<Category> categories;
        private Address address;
        #endregion

        #region Properties
        [OneToMany]
        public List<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }

        [ManyToMany(typeof(User))]
        public List<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        [ManyToMany(typeof(People))]
        public List<People> People
        {
            get { return people; }
            set
            {
                people = value;
                OnPropertyChanged("People");
            }
        }

        public String MeetingName
        {
            get { return meetingName; }
            set
            {
                meetingName = value;
                OnPropertyChanged("MeetingName");
            }
        }

        public DateTime MeetingStart
        {
            get { return meetingStart; }
            set
            {
                meetingStart = value;
                OnPropertyChanged("MeetingStart");
            }
        }

        public DateTime MeetingEnd
        {
            get { return meetingEnd; }
            set
            {
                meetingEnd = value;
                OnPropertyChanged("MeetingEnd");
            }
        }

        public Address Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        #endregion

        #region Constructors
        public Meeting()
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
