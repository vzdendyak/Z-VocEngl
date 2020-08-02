﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZVocEngl.DAL.Data.Models
{
    [Table("CollocationWords")]
    public class CollocationWords
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int WordInformationId { get; set; }
        public WordInformations WordInformation { get; set; }
    }
}