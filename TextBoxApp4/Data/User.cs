using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextBoxApp4.Data
{
    /// <summary>
    /// ユーザー
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
        /// Name of the user
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        public DateTime? Birth { get; set; }

        [NotMapped]
        public bool Insert { get; set; } = false;
    }
}