using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using ZDictionary;
using ZVocEngl.DAL.Data;
using ZVocEngl.DAL.Data.Models;

namespace VocabularyMigrationHelper
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //MigrationStart();
            //RegexFind();
        }

        public static void RegexFind()
        {
            string text = "";
            using (StreamReader sr = new StreamReader(@"D:\projects\ZDictionary\vocabulary.json"))
            {
                text = sr.ReadToEnd();
            }
            Regex regex = new Regex(@"""PartOfSpeech"": ""(.*)""");
            var matches = regex.Matches(text);
            HashSet<string> parts = new HashSet<string>();
            foreach (Match item in matches)
            {
                parts.Add(item.Groups[1].Value);
            }
            foreach (var item in parts)
            {
                Console.WriteLine(item);
            }
        }

        public static void MigrationStart()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var options = optionsBuilder.UseSqlServer("Data Source=DESKTOP-V1GMI6E\\SQLEXPRESS;Initial Catalog=Z-VocenglDatabase;Integrated Security=True").Options;
            using (AppDbContext _context = new AppDbContext(options))
            {
                IOHelper helper = new IOHelper();
                var mainDictionary = helper.ReadVocabularyFromJson();

                List<PartsOfSpeech> partsOfSpeech = _context.PartsOfSpeeches.ToList();
                Vocabulary systemVocabulary = _context.Vocabularies.Where(v => v.UserId == "0b8a17e0-edf2-43fd-85e3-2baab5bc4871").FirstOrDefault();

                foreach (var item in mainDictionary.Words)
                {
                    //WordInformation tempWordInfo = new WordInformation();
                    var word = new Word { Name = item.Name };
                    word = CheckExistance(word, _context);
                    var vocWords = new VocabulariesWords()
                    {
                        VocabularyId = systemVocabulary.Id,
                        WordId = word.Id
                    };
                    //_context.VocabulariesWords.Add(vocWords);
                    //_context.SaveChanges();

                    foreach (var res in item.Collocation.CollocationResults)
                    {
                        if (res.PartOfSpeech != null)
                        {
                            res.PartOfSpeech = res.PartOfSpeech.Trim();
                            switch (res.PartOfSpeech.ToLower())
                            {
                                case "adv":
                                    res.PartOfSpeech = "Adverb";
                                    break;

                                case "adj":
                                    res.PartOfSpeech = "adjective";
                                    break;

                                case "prep":
                                    res.PartOfSpeech = "preposition";
                                    break;

                                case "verbs":
                                    res.PartOfSpeech = "verb";
                                    break;

                                default:
                                    var tempText = res.PartOfSpeech;
                                    if (tempText.Contains("NOUN +"))
                                    {
                                        res.PartOfSpeech = "noun+";
                                    }
                                    else if (tempText.Contains("+ NOUN"))
                                    {
                                        res.PartOfSpeech = "+noun";
                                    }
                                    else if (tempText.Contains("VERB +"))
                                    {
                                        res.PartOfSpeech = "verb+";
                                    }
                                    else if (tempText.Contains("+ VERB"))
                                    {
                                        res.PartOfSpeech = "+verb";
                                    }
                                    break;
                            }
                        }
                        var vInfo = new WordInformation()
                        {
                            Text = res.Meaning,
                            PartOfSpeechId = res.PartOfSpeech != null ? partsOfSpeech.Where(p => p.Name.ToLower() == res.PartOfSpeech.ToLower()).FirstOrDefault().Id : 7,
                            WordId = word.Id,
                            TypeId = 2
                        };

                        vInfo = CheckExistance(vInfo, _context);

                        if (res.Words != null)
                        {
                            foreach (var w in res.Words)
                            {
                                var colWord = new CollocationWord()
                                {
                                    Text = w,
                                    WordInformationId = vInfo.Id
                                };
                                colWord = CheckExistance(colWord, _context);
                            }
                        }

                        if (res.Examples != null)
                        {
                            foreach (var ex in res.Examples)
                            {
                                var example = new Example()
                                {
                                    Text = ex,
                                    WordInformationId = vInfo.Id
                                };
                                example = CheckExistance(example, _context);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public static Word CheckExistance(Word item, AppDbContext _context)
        {
            var existItem = _context.Words.Where(w => w.Name == item.Name).FirstOrDefault();
            if (existItem != null)
            {
                return existItem;
            }
            else
            {
                _context.Words.Add(item);
                _context.SaveChanges();
                item = _context.Words.Where(w => w.Name == item.Name).FirstOrDefault();
                return item;
            }
        }

        public static Example CheckExistance(Example item, AppDbContext _context)
        {
            var existItem = _context.Examples.Where(w => w.Text == item.Text).FirstOrDefault();

            if (existItem != null)
            {
                return existItem;
            }
            else
            {
                _context.Examples.Add(item);
                _context.SaveChanges();
                item = _context.Examples.Where(w => w.Text == item.Text).FirstOrDefault();
                return item;
            }
        }

        public static WordInformation CheckExistance(WordInformation item, AppDbContext _context)
        {
            var existItem = _context.WordInformations.Where(w => w.Text == item.Text).FirstOrDefault();

            if (existItem != null)
            {
                return existItem;
            }
            else
            {
                _context.WordInformations.Add(item);
                _context.SaveChanges();
                item = _context.WordInformations.Where(w => w.Text == item.Text).FirstOrDefault();
                return item;
            }
        }

        public static DefinitionSynonym CheckExistance(DefinitionSynonym item, AppDbContext _context)
        {
            var existItem = _context.DefinitionSynonyms.Where(w => w.Text == item.Text).FirstOrDefault();
            if (existItem != null)
            {
                return existItem;
            }
            else
            {
                _context.DefinitionSynonyms.Add(item);
                _context.SaveChanges();
                item = _context.DefinitionSynonyms.Where(w => w.Text == item.Text).FirstOrDefault();
                return item;
            }
        }

        public static CollocationWord CheckExistance(CollocationWord item, AppDbContext _context)
        {
            var existItem = _context.CollocationWords.Where(w => w.Text == item.Text).FirstOrDefault();
            if (existItem != null)
            {
                return existItem;
            }
            else
            {
                _context.CollocationWords.Add(item);
                _context.SaveChanges();
                item = _context.CollocationWords.Where(w => w.Text == item.Text).FirstOrDefault();
                return item;
            }
        }
    }
}

//foreach (var res in item.Results)
//{
//    if (res.PartOfSpeech != null)
//    {
//        switch (res.PartOfSpeech.ToLower())
//        {
//            case "adv":
//                res.PartOfSpeech = "Adverb";
//                break;

//            case "adj":
//                res.PartOfSpeech = "adjective";
//                break;

//            case "prep":
//                res.PartOfSpeech = "preposition";
//                break;

//            default:
//                var tempText = res.PartOfSpeech.ToLower();
//                if (tempText.Contains("NOUN +"))
//                {
//                    res.PartOfSpeech = "noun+";
//                }
//                else if (tempText.Contains("+ NOUN"))
//                {
//                    res.PartOfSpeech = "+noun";
//                }
//                else if (tempText.Contains("VERB +"))
//                {
//                    res.PartOfSpeech = "verb+";
//                }
//                else if (tempText.Contains("+ VERB"))
//                {
//                    res.PartOfSpeech = "+verb";
//                }
//                break;
//        }
//    }
//    var vInfo = new WordInformation()
//    {
//        Text = res.Definition,
//        PartOfSpeechId = res.PartOfSpeech != null ? partsOfSpeech.Where(p => p.Name.ToLower() == res.PartOfSpeech.ToLower()).FirstOrDefault().Id : 7,
//        WordId = word.Id,
//        TypeId = 1
//    };

//    vInfo = CheckExistance(vInfo, _context);

//    if (res.Synonyms != null)
//    {
//        foreach (var syn in res.Synonyms)
//        {
//            var defSynonym = new DefinitionSynonym()
//            {
//                Text = syn,
//                WordInformationId = vInfo.Id
//            };
//            defSynonym = CheckExistance(defSynonym, _context);
//        }
//    }

//    if (res.Examples != null)
//    {
//        foreach (var ex in res.Examples)
//        {
//            var example = new Example()
//            {
//                Text = ex,
//                WordInformationId = vInfo.Id
//            };
//            example = CheckExistance(example, _context);
//        }
//    }
//}