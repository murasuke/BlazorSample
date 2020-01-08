using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextBoxApp4.Data
{
    /// <summary>
    /// ユーザーModel
    /// </summary>
    //[Table("User", Schema = "dbo")]
    public class User
    {
        /// <summary>
        /// ID
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// ユーザ名
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// 誕生日
        /// </summary>
        /// <value></value>
        public DateTime? Birth { get; set; }

        // DB更新対象外
        // Insert、Updateを判断するためのフラグ(true -> Insert)
        [NotMapped]
        public bool Insert { get; set; } = false;
    }
}