using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStartUp.Ans
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Dragon Quest World!");

            var charas = Generator.GetCharacters();

            // Lesson01: 偶数レベルのキャラ一覧
            Console.WriteLine("Lesson01");
            var ans01 = charas.Where(_ => _.Level % 2 == 0);

            foreach (var a in ans01)
            {
                Console.WriteLine(a.Name);
            }

            // Lesson02: 全員のHpを2倍にする
            Console.WriteLine("Lesson02");
            charas = Generator.GetCharacters();
            charas.ForEach(_ => _.Hp *= 2);

            foreach (var chara in charas)
            {
                Console.WriteLine($"{chara.Name}:{chara.Hp}");
            }

            // Lesson03: レベルで昇順ソートを行い, インデックスをつける
            Console.WriteLine("Lesson03");
            charas = Generator.GetCharacters();
            charas.OrderBy(_ => _.Level).Select((c, i) => new { i, c })
                .ToList()
                .ForEach(_ => Console.WriteLine($"{_.c.Name}:{_.c.Level}:Index:{_.i}"));

            // Lesson04: 名前と職業のリストをつくる
            Console.WriteLine("Lesson04");
            charas = Generator.GetCharacters();
            var ans04 = charas.Select(_ => new { _.Name, _.Job });

            foreach (var a in ans04)
            {
                Console.WriteLine($"{a.Name}:{a.Job}");
            }

            // Lesson05: idの3番目から2人を抽出する
            Console.WriteLine("Lesson05");
            charas = Generator.GetCharacters();
            var ans05 = charas.Skip(2).Take(2);

            foreach (var a in ans05)
            {
                Console.WriteLine(a.Name);
            }


            // Lesson06: 重複のない呪文の一覧をつくる
            Console.WriteLine("Lesson06");
            charas = Generator.GetCharacters();
            var ans06 = charas.SelectMany(_ => _.Magics)
                .Distinct();

            foreach (var a in ans06)
            {
                Console.WriteLine(a);
            }

            // Lesson07: 職業と名前のディクショナリを作る
            Console.WriteLine("Lesson07");
            charas = Generator.GetCharacters();
            var ans07 = charas.GroupBy(_ => _.Job)
                .ToDictionary(g => g.Key, _ => _.Select(c => c.Name));

            foreach (var a in ans07)
            {
                Console.WriteLine($"{a.Key}:{string.Join(",", a.Value)}");
            }

        }
    }

    public static class Generator
    {
        public static List<Character> GetCharacters()
        {
            var list = new List<Character>
            {
                new Character { Id = 1, Level = 10, Name = "ライアン", Hp = 115, Mp = 0, Magics = null, Job = Job.Warrior },
                new Character { Id = 2, Level = 12, Name = "アリーナ", Hp = 85, Mp = 0, Magics = null, Job = Job.Monk },
                new Character { Id = 3, Level = 9, Name = "クリフト", Hp = 45, Mp = 25, Magics = new List<string> { "ホイミ", "スカラ", "キアリー", "マヌーサ" }, Job = Job.Priest },
                new Character { Id = 4, Level = 10, Name = "ブライ", Hp = 30, Mp = 45, Magics = new List<string> { "ヒャド", "ルカニ", "ラリホー", "リレミト", "マホカンタ", "ルーラ" }, Job = Job.Magician },
                new Character { Id = 5, Level = 16, Name = "トルネコ", Hp = 75, Mp = 0, Magics = null, Job = Job.Warrior },
                new Character { Id = 6, Level = 11, Name = "ミネア", Hp = 40, Mp = 30, Magics = new List<string> { "ホイミ", "キアリー", "ラリホー", "バギ", "キアリク" }, Job = Job.Priest },
                new Character { Id = 7, Level = 12, Name = "マーニャ", Hp = 35, Mp = 55, Magics = new List<string> { "メラ", "ルカニ", "ギラ", "ルーラ", "リレミト", "イオ" }, Job = Job.Magician }
            };

            return list;
        }
    }

    /// <summary>
    /// キャラクター
    /// </summary>
    public class Character
    {
        public int Id { get; set; }

        public int Level { get; set; }

        public string Name { get; set; }

        public int Hp { get; set; }

        public int Mp { get; set; }

        public List<string> Magics { get; set; }

        public Job Job { get; set; }
    }

    /// <summary>
    /// 職業
    /// </summary>
    public enum Job
    {
        Warrior, Monk, Magician, Priest
    }
}
}
