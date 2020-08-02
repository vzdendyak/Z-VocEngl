using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZVocEngl.DAL.Data.Models
{
    [Table("WordInformations")]
    public class WordInformations
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int WordId { get; set; }
        public int PartOfSpeechId { get; set; }
        public int TypeId { get; set; }

        // nav
        public ICollection<Examples> Examples { get; set; }

        public ICollection<DefinitionSynonyms> DefinitionSynonyms { get; set; }
        public ICollection<CollocationWords> CollocationWords { get; set; }
        public Types Type { get; set; }
        public Words Word { get; set; }
        public PartsOfSpeeches PartOfSpeech { get; set; }
    }
}