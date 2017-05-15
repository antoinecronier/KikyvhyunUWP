using Kikyvhyun.Entities.Base;
using System;

namespace Kikyvhyun.Entities
{
    public class Category : EntityBase
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String categoryName;
        #endregion

        #region Properties
        public String CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }
        #endregion

        #region Constructors
        public Category()
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