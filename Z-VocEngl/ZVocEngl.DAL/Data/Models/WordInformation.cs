using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZVocEngl.DAL.Data.Models
{
    [Table("WordInformations")]
    public class WordInformation
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int WordId { get; set; }
        public int PartOfSpeechId { get; set; }
        public int TypeId { get; set; }

        // nav
        public ICollection<Example> Examples { get; set; }

        public ICollection<DefinitionSynonym> DefinitionSynonyms { get; set; }
        public ICollection<CollocationWord> CollocationWords { get; set; }
        public Type Type { get; set; }
        public Word Word { get; set; }
        public PartsOfSpeech PartOfSpeech { get; set; }
    }
}