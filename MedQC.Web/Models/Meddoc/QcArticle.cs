using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;

namespace MedQC.Web.Models.Meddoc
{
    [Table("QC_ARTICLE")]
    public class QcArticle
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int ID { get; set; }
        [Column("CATEGORY_CODE")]
        public string CategoryCode { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }

        [Column("TITLE", TypeName = "VARCHAR2")]
        public string Title { get; set; }
        [Column("IMAGE_PATH", TypeName = "VARCHAR2")]
        public string ImagePath { get; set; }
        [Column("KEYWORDS", TypeName = "VARCHAR2")]
        public string Keywords { get; set; }
        [Column("SUMMARY", TypeName = "VARCHAR2")]
        public string Summary { get; set; }
        [Column("CONTENT", TypeName = "VARCHAR2")]
        public string Content { get; set; }
        [Column("CREATETIME", TypeName = "DATE")]
        public DateTime CreateTime { get; set; }
        [Column("MODIFYTIME", TypeName = "DATE")]
        public DateTime ModifyTime { get; set; }
        [Column("VIEWCOUNT")]
        public int ViewCount { get; set; }
        public int GetNextID()
        {
            int id = 0;
            string sql = "select SEQ_qc_ARTICLE_ID.NEXTVAL from dual ";
            DataTable dt = MedQC.Web.DataAccess.Meddoc.MeddocEFSqlHelper.SqlQueryForDataTatable(sql);
            if (dt != null && dt.Rows.Count > 0)
                id = int.Parse(dt.Rows[0][0].ToString());
            return id;
        }
    }
}