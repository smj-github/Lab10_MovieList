using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10_MovieList
{
    class Movie
    {
        #region Fields
        private string _title;
        private string _category;
        #endregion

        #region Properties
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        #endregion

        #region Constructors
        public Movie() { }

        public Movie(string title, string category)
        {
            _title = title;
            _category = category;
        }
        #endregion
    }
}
