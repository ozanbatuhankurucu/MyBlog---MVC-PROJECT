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
    
    public partial class tbl_post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_post()
        {
            this.tbl_comment = new HashSet<tbl_comment>();
        }
    
        public int id { get; set; }
        public string title { get; set; }
        public string blog_content { get; set; }
        public int tags { get; set; }
        public Nullable<System.DateTime> create_time { get; set; }
        public Nullable<System.DateTime> update_time { get; set; }
        public int author_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_comment> tbl_comment { get; set; }
        public virtual tbl_tag tbl_tag { get; set; }
        public virtual tbl_user tbl_user { get; set; }
    }
}
