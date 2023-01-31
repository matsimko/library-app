using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopApp.ORM
{
    public class Key
    {
        public int[] Fields { get; set; }

        public Key(params int[] fields)
        {
            this.Fields = fields;
        }

        /// <summary>
        /// //convenience method for objects with simple integer primary key
        /// </summary>   
        public int Id
        {
            get
            {
                if (this.Fields.Length > 1)
                {
                    throw new InvalidOperationException("object doesn't have a simple integer primary key");
                }
                else if(this.Fields.Length == 0)
                {
                    throw new InvalidOperationException("key.Fields is empty");
                }

                return this.Fields[0];
            }
        }
        

        public override bool Equals(object obj)
        {
            if (!(obj is Key))
            {
                return false;
            }
            Key key = (Key)obj;
            if (key.Fields.Length != Fields.Length)
            {
                return false;
            }

            for(int i = 0; i < Fields.Length; i++)
            {
                if(Fields[i] != key.Fields[i])
                {
                    return false;
                }
            }

            return true;
            //return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string str = "[";
            foreach(int field in Fields)
            {
                str += field + ", ";
            }
            str = str.Remove(str.Length - 2);
            str += "]";
            return str;
        }
    }
}
