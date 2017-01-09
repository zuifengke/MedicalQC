﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MedQC.Web.Models
{
    [Table("EmpMenu")]
    public class EmpMenu
    {
        [Key]
        [ColumnAttribute(Order = 0)]
        public int EmpID { get; set; }
        [Key]
        [ColumnAttribute(Order =1)]
        public int MenuID { get; set; }
       
    }

}
