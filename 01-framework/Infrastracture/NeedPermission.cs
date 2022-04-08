using System;

namespace _01_framework.Infrastracture
{
    public  class NeedPermission:Attribute
    {
        public int Code { get; set; }
        public NeedPermission(int code)
        {
            Code=code;
        }
    }
}
