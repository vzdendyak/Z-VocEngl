using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZVocEngl.DAL.Data.Models
{
    [Table("VocabulariesWords")]
    public class VocabulariesWords : IEntity
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public int VocabularyId { get; set; }
        public Word Word { get; set; }
        public Vocabulary Vocabulary { get; set; }
    }
}