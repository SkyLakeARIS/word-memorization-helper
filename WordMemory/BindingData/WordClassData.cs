using System.Collections.Generic;

namespace WordMemory.BindingData
{
    public enum EWordClass
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
	    public static IList<WordClassData> DataList = new List<WordClassData>();

        public EWordClass WordClassType { get; set; }
        public string WordClassName { get; set; }
        private WordClassData(EWordClass wordClassType, string wordClassName)
        {

            WordClassType = wordClassType;
            WordClassName = wordClassName;
        }
        public static void Initialize()
        {
            DataList.Add(new WordClassData(EWordClass.NULL, "NULL"));
            DataList.Add(new WordClassData(EWordClass.NOUN, "명사"));
            DataList.Add(new WordClassData(EWordClass.VERB, "동사"));
            DataList.Add(new WordClassData(EWordClass.ADJECTIVE, "형용사"));
            DataList.Add(new WordClassData(EWordClass.PREPOSITION, "전치사"));
            DataList.Add(new WordClassData(EWordClass.CONJUNCTION, "접속사"));
            DataList.Add(new WordClassData(EWordClass.PRONOUN, "대명사"));
            DataList.Add(new WordClassData(EWordClass.INTERJECTION, "감탄사"));
            DataList.Add(new WordClassData(EWordClass.ADVERB, "부사"));
        }
        public static void Release()
        {
            DataList.Clear();
            DataList = null;
        }


    }
}
