using Kikyvhyun.Entities.Base;
using System;

namespace Kikyvhyun.Entities
{
    public class Address : EntityBase
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String addressName;
        private String addressStreet;
        private String addressCity;
        #endregion

        #region Properties
        public String AddressCity
        {
            get { return addressCity; }
            set
            {
                addressCity = value;
                OnPropertyChanged("AddressCity");
            }
        }

        public String AddressStreet
        {
            get { return addressStreet; }
            set
            {
                addressStreet = value;
                OnPropertyChanged("AddressStreet");
            }
        }

        public String AddressName
        {
            get { return addressName; }
            set
            {
                addressName = value;
                OnPropertyChanged("AddressName");
            }
        }
        #endregion

        #region Constructors
        public Address()
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