using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerA.Models
{
    public class CashStreamModel
    {
        public string ID { get; set; }
        public string USERNAME { get; set; }
        public int BALANCE { get; set; }
        public string SERVER { get; set; }
        public DateTime CREATETIME { get; set; }
    }
}