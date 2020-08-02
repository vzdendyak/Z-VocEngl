﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZVocEngl.DAL.Data.Models
{
    [Table("Vocabularies")]
    public class Vocabularies
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        public Users User { get; set; }
        public virtual ICollection<VocabulariesWords> VocabulariesWords { get; set; }
    }
}