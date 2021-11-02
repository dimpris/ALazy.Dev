﻿using ALazy.Dev.BaseComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALazy.Dev.Models.LaData
{
    public enum LaBindingFlagsEnum
    {
        Public,
        Protected,
        Privat,
        Static
    }
    public class LaStrSet<T>
    {
        protected List<T> set;
        public virtual string Value
        { 
            get { return set.ToString(); }
            //set 
            //{ 
            //    string strVal = value.ToString();
            //    // if value is int or other value types, try parse
            //    Console.WriteLine(strVal);
            //} 
        }
        public int Add(T item)
        {
            if (set.Contains(item))
            {
                throw new LaException("Duplicate value. Set stores only unique values");
            }

            set.Add(item);

            return set.Count;
        }
    }
    public class LaBindingFlags : LaStrSet<LaBindingFlagsEnum> {}
    public class LaPayload
    {
        public Dictionary<string, string> DataSet { get; set; }
    }
    public class LaPropertyPayload : LaPayload { }
    public class LaMethodPayload : LaPayload { }
    public class LaEntityPayload : LaPayload { }
    public class LaProperty 
    {
        public int PropertyID { get; set; }
        public string Name { get; set; }
        //public Type PropertyType { get; set; }
        public string PropertyType { get; set; }
        public string BindingFlags { get; set; }
        public virtual LaBindingFlags BindingFlagsSet { get; set; }
        public int EntityID { get; set; }
        public virtual LaEntity Entity { get; set; }
        public string Payload { get; set; }
        public virtual LaPropertyPayload PropertyPayload { get; set; }

        //public string PropertyValue { get; set; }
        //public bool CanRead { get; set; }
        //public bool CanWrite { get; set; }
    }
    public class LaMethod
    {
        public int MethodID { get; set; }
        public string Name { get; set; }
        public string Arguments { get; set; } // TODO add virtual
        public string MethodType { get; set; }
        public string BindingFlags { get; set; }
        public virtual LaBindingFlags BindingFlagsSet { get; set; }
        public int EntityID { get; set; }
        public virtual LaEntity Entity { get; set; }
        public string Payload { get; set; }
        public virtual LaMethodPayload MethodPayload { get; set; }
    }

    // TODO ALazyDataEntity -> ALazyEntity  LaEntity LeEntity La. Le.
    public class LaEntity
    {
        public int EntityID { get; set; }
        public string EntityType { get; set; }
        public string Name { get; set; }
        public string BaseType { get; set; }
        public string Namespace { get; set; }
        public int ContextID { get; set; }
        public virtual LaContext Context { get; set; }
        public virtual ICollection<LaProperty> Properties { get; set; }
        public virtual ICollection<LaMethod> Methods { get; set; }
        public string Payload { get; set; }
        public virtual LaEntityPayload EntityPayload { get; set; }
    }
    public class LaContext 
    {
        public int ContextID { get; set; }
        public string Name { get; set; }
        public int AppID { get; set; }
        public virtual LaApp App { get; set; }
        public virtual List<LaEntity> Entities { get; set; }
        public string Payload { get; set; }
    }
    public class LaApp
    {
        public int AppID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrgID { get; set; }
        public string Payload { get; set; }
        public virtual ICollection<LaContext> Contexts { get; set; }
    }
}
