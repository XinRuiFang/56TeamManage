//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class C56rms_file
    {
        public int file_id { get; set; }
        public string file_name { get; set; }
        public int file_type { get; set; }
        public System.DateTime file_update_time { get; set; }
        public double file_size { get; set; }
        public int file_updater { get; set; }
        public string file_path { get; set; }
    
        public virtual C56rms_user C56rms_user { get; set; }
    }
}
