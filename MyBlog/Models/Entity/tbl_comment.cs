//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBlog.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_comment
    {
        public int id { get; set; }
        public string comment_content { get; set; }
        public Nullable<System.DateTime> create_time { get; set; }
        public int author { get; set; }
        public string email { get; set; }
        public string pic_url { get; set; }
        public int post_id { get; set; }
    
        public virtual tbl_post tbl_post { get; set; }
        public virtual tbl_user tbl_user { get; set; }
    }
}
