using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace MSSQLDatabaseDocGen
{
    [Serializable]
    public class OptionObject
    {
        public bool _ReadAll;
        public bool ReadAll{ 
                              set { _ReadAll = value;}
                              get { return _ReadAll;}
                           }
        public bool _ReadListThenChoiseDetail;
        public bool ReadListThenChoiseDetail
        {
            set {_ReadListThenChoiseDetail =value; }
            get { return _ReadListThenChoiseDetail; }
        }

        public String _ListObjectChoise;
        public String ListObjectChoise
        {
            set { _ListObjectChoise = value; }
            get { return _ListObjectChoise; }
        }

        public  OptionObject() 
        {
            _ReadAll = true;
            _ReadListThenChoiseDetail = false;
            _ListObjectChoise = string.Empty;
        }

    }
}
