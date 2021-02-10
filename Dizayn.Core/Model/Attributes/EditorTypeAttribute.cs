using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrder.Core.Model.Attributes
{
    public class EditorTypeAttribute : Attribute
    {
        public string Name { get; set; }
        public string Param { get; set; }

        public EditorTypeAttribute(string Name, string Param = null)
        {
            this.Name = Name;
            this.Param = Param;
        }
    }

    public class EditorTypeExAttribute : Attribute
    {
        public string Name { get; set; }
        public object Param { get; set; }

        public EditorTypeExAttribute(string Name, string Param = null)
        {
            this.Param = null;
            this.Name = Name;


            if (Param != null)
            {
                try
                {
                    if (this.Param == null)
                    {
                        JObject json = JObject.Parse(Param);
                        this.Param = json;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }

                if (this.Param == null)
                {
                    this.Param = Param;
                }


            }
        }
    }

    public static class EditorType
    {
        public const string Hidden = "Hidden";
        public const string Enum = "Enum";
        public const string MultiEnum = "MultiEnum";
        public const string Date = "Date";
        public const string Key = "Key";
        public const string Wysiwyg = "Wysiwyg";
        public const string Image = "Image";
        public const string Disabled = "Disabled";
        public const string Bool = "Bool";
        public const string ForeignKey = "ForeignKey";
        public const string Collection = "Collection";
        public const string Range = "Range";
        public const string RangeDateTime = "RangeDateTime";
        public const string SelectionSet = "SelectionSet";
        public const string PoolImageUploader = "PoolImageUploader";
        public const string ExternalMultiSelect = "ExternalMultiSelect";
        public const string Timer = "Timer";
    }
}
