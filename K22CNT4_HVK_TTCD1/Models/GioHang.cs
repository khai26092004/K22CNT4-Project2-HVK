//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K22CNT4_HVK_TTCD1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GioHang
    {
        public int Id { get; set; }
        public int Idcay { get; set; }
        public int Idnguoidung { get; set; }
        public int soluong { get; set; }
        public decimal tonggiatien { get; set; }
    
        public virtual Cay Cay { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
