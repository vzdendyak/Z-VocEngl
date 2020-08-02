using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZVocEngl.DAL.Data.Models
{
    [Table("Words")]
    public class Words
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<VocabulariesWords> VocabulariesWords { get; set; }
        public virtual ICollection<WordInformations> WordInformations { get; set; }
    }
}