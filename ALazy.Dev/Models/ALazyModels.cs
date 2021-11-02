using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALazy.Dev.Models
{
    #region Parts
    public abstract class ALazyType { }
    public class ALazyStringType { }
    public class ALazyNumberType { }
    public class ALazyLongType { }
    public class ALazyVar <T> where T : ALazyType
    {
        public ALazyVar(string name) 
        {
            this.name = name;
        }
        public ALazyVar(string name, T defaultValue) : this (name)
        {
            if (defaultValue != null) 
            {
                Init(defaultValue);
            }
        }
        protected string name;
        public string GetName() 
        {
            return name;
        }

        //protected Type type;
        public Type GetType_ALazy() { return varValue.GetType(); }
        public string GetTypeName_ALazy() { return GetType_ALazy().Name; }

        protected T varValue;
        public void Init(T val)
        {
            defaultValue = val;
            SetValue(val);
        }
        public void SetValue(T val)
        {
            varValue = val;
        }
        public T GetValue()
        {
            return varValue;
        }
        public T Value
        {
            get
            {
                return GetValue();
            }
            set
            {
                SetValue(value);
            }
        }

        protected T defaultValue;
        public T getDefaultValue()
        {
            return defaultValue;
        }
    }
    public class ALazyParameter <T> : ALazyVar <T> where T : ALazyType
    {
        public ALazyParameter(string name, T defaultValue, int? order = null) : this(name, order)
        {
            Init(defaultValue);
        }
        public ALazyParameter(string name, int? order = null) : base(name)
        {
            SetOrder(order);
        }
        public int Order { get; set; }
        public void SetOrder(int? order)
        {
            if (order != null)
            {
                Order = (int)order;
            }
        }
    }
    public class ALazyArguments : List<ALazyParameter<ALazyType>> { }
    public enum ALazyAccessModifiers
    {
        Public,
        Protected,
        Private
    }
    public class ALazyMember<T> : ALazyVar<T> where T : ALazyType
    {
        protected ALazyAccessModifiers accessModifier;
        public ALazyAccessModifiers GetAccessModifier()
        {
            return accessModifier;
        }
        public ALazyMember(string name, ALazyAccessModifiers accessModifier) : base(name) 
        {
            this.accessModifier = accessModifier;
        }
        public ALazyMember(string name, ALazyAccessModifiers accessModifier, T defaultValue) : this(name, accessModifier) 
        {
            Init(defaultValue);
        }
    }
    //public class ALazyModels { }
    #endregion

    #region Common
    public class ALazyApp { }
    public class ALazyContext { }
    public class ALazyProperty<T> : ALazyMember<T> where T : ALazyType
    {
        public ALazyProperty(string name, ALazyAccessModifiers accessModifier) : base(name, accessModifier) { }
        public ALazyProperty(string name, ALazyAccessModifiers accessModifier, T defaultValue) : base(name, accessModifier, defaultValue) { }
    }
    public class ALazyMethod<T> : ALazyMember<T> where T : ALazyType
    {
        protected ALazyArguments arguments;
        public ALazyMethod(string name, ALazyAccessModifiers accessModifier, ALazyArguments args) : base(name, accessModifier)
        {
            arguments = args;
        }

        public ALazyArguments GetArguments()
        {
            return arguments;
        }
    }
    namespace Base
    {
        public abstract class Entity <TKey> where TKey : ALazyType
        {
            public TKey ID { get; set; }
            public bool IsDeleted { get; set; }
            public int OrgID { get; set; }
        }
        public class Thing<TKey> : Entity<TKey> where TKey : ALazyType
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string URL { get; set; }
            public string Image { get; set; }
            //public string SameAs { get; set; }
        }
        
        public class Relation<T_Master, T_Slave, T_RKey> 
            : Entity<T_RKey> where T_RKey : ALazyType where T_Master : Entity<ALazyType> where T_Slave : Entity<ALazyType>
        { 
            public T_Master Master { get; set; }
            public T_Slave Slave { get; set; }
            public bool UsingMasterSlave { get; set; }
            public string RelationType { get; set; }
            public string Payload { get; set; }
            public int? Order { get; set; }
            public Relation(T_Master master, T_Slave slave, string relationType = null, bool usingMasterSlave = false)
            {
                Master = master;
                Slave = slave;
                UsingMasterSlave = usingMasterSlave;

                if (!string.IsNullOrWhiteSpace(relationType))
                {
                    RelationType = relationType;
                }
            }
        }
        //public class Relation<T_Master, T_Slave>
        //    : Relation<T_Master, T_Slave, ALazyLongType> where T_Master : Entity<ALazyType> where T_Slave : Entity<ALazyType>
        //{
        //    public Relation(T_Master master, T_Slave slave, bool usingMasterSlave = false)
        //        : base(master, slave,usingMasterSlave) { }
        //}
        //public class Thing<T> : Entity<T> { }

        // ContactPoint, CreativeWork, Language, MediaObject, Person, PostalAddress, Taxonomy
    }
    //public class ALazyModels { }
    //public class ALazyModels { }
    #endregion

    #region Back

    #endregion

    #region Front

    #endregion
}