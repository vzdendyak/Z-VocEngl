﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZVocEngl.DAL.Data.Models
{
    [Table("PartsOfSpeeches")]
    public class PartsOfSpeech : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<WordInformation> WordInformations { get; set; }
    }
}