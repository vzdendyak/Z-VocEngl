using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZVocEngl.DAL.Data.Models
{
    [Table("Types")]
    public class Types
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<WordInformations> WordInformations { get; set; }
    }
}