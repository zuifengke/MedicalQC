using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedQC.Web.ViewsModels
{
    public class DataChat
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public DataChat(int count, string name)
        {
            this.Count = count;
            this.Name = name;
        }
    }
}