using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZVocEngl.DAL.Data.Models
{
    [Table("Words")]
    public class Word
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // nav
        public virtual ICollection<VocabulariesWords> VocabulariesWords { get; set; }

        public virtual ICollection<WordInformation> WordInformations { get; set; }
    }
}