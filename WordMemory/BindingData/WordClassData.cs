using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemory.BindingData
{
    public enum eWordClass
    {
        NULL,           // 선택되지 않은 상태
        NOUN,           // 명사
        VERB,           // 동사
        ADJECTIVE,      // 형용사
        PREPOSITION,    // 전치사
        CONJUNCTION,    // 접속사
        PRONOUN,        // 대명사
        INTERJECTION,   // 감탄사
        ADVERB          // 부사
    }

    public class WordClassData
    {
        public eWordClass WordClassType { get; set; }
        public string WordClassName { get; set; }
        private WordClassData(eWordClass wordClassType, string wordClassName)
        {

            WordClassType = wordClassType;
            WordClassName = wordClassName;
        }
        public static void Initialize()
        {
            DataList.Add(new WordClassData(eWordClass.NULL, "NULL"));
            DataList.Add(new WordClassData(eWordClass.NOUN, "명사"));
            DataList.Add(new WordClassData(eWordClass.VERB, "동사"));
            DataList.Add(new WordClassData(eWordClass.ADJECTIVE, "형용사"));
            DataList.Add(new WordClassData(eWordClass.PREPOSITION, "전치사"));
            DataList.Add(new WordClassData(eWordClass.CONJUNCTION, "접속사"));
            DataList.Add(new WordClassData(eWordClass.PRONOUN, "대명사"));
            DataList.Add(new WordClassData(eWordClass.INTERJECTION, "감탄사"));
        }
        public static void Release()
        {
            DataList.Clear();
            DataList = null;
        }

        public static IList<WordClassData> DataList = new List<WordClassData>();

    }
}
