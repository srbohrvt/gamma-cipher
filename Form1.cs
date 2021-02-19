using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Praca1
{
    public partial class Form1 : Form
    {
        /*public IEnumerable<T> RandomPermutation<T>(this IEnumerable<T> sequence, int start, int end)
        {
            Random random = new Random();

            T[] array = sequence as T[] ?? sequence.ToArray();

            var result = new T[array.Length];

            for (int i = 0; i < start; i++)
            {
                result[i] = array[i];
            }
            for (int i = end; i < array.Length; i++)
            {
                result[i] = array[i];
            }

            var sortArray = new List<KeyValuePair<double, T>>(array.Length - start - (array.Length - end));
            lock (random)
            {
                for (int i = start; i < end; i++)
                {
                    sortArray.Add(new KeyValuePair<double, T>(random.NextDouble(), array[i]));
                }
            }

            sortArray.Sort((i, j) => i.Key.CompareTo(j.Key));

            for (int i = start; i < end; i++)
            {
                result[i] = sortArray[i - start].Value;
            }

            return result;
        }*/
        public Form1()
        {
            InitializeComponent();
        }
        private Dictionary<char, string> cyrilic = new Dictionary<char, string>()
            {
                {'А',"000001"},
                {'Б',"000010"},
                {'В',"000011"},
                {'Г',"000100"},
                {'Д',"000101"},
                {'Е',"000110"},
                {'Ё',"000111"},
                {'Ж',"001000"},
                {'З',"001001"},
                {'И',"001010"},
                {'Й',"001011"},
                {'К',"001100"},
                {'Л',"001101"},
                {'М',"001110"},
                {'Н',"001111"},
                {'О',"010000"},
                {'П',"010001"},
                {'Р',"010010"},
                {'С',"010011"},
                {'Т',"010100"},
                {'У',"010101"},
                {'Ф',"010110"},
                {'Х',"010111"},
                {'Ц',"011000"},
                {'Ч',"011001"},
                {'Ш',"011010"},
                {'Щ',"011011"},
                {'Ъ',"011100"},
                {'Ы',"011101"},
                {'Ь',"011110"},
                {'Э',"011111"},
                {'Ю',"000000"},
                {'Я',"100000"},
                {'1',"100001"},
                {'2',"100010"},
                {'3',"100011"},
                {'4',"100100"},
                {'5',"100101"},
                {'6',"100110"},
                {'7',"100111"},
                {'8',"101000"},
                {'9',"101001"},
                {'0',"101010"},

            };
        private Dictionary<string, char> cyrilic_reverse = new Dictionary<string, char>()
            {
                {"000001",'А'},
                {"000010",'Б'},
                {"000011",'В'},
                {"000100",'Г'},
                {"000101",'Д'},
                {"000110",'Е'},
                {"000111",'Ё'},
                {"001000",'Ж'},
                {"001001",'З'},
                {"001010",'И'},
                {"001011",'Й'},
                {"001100",'К'},
                {"001101",'Л'},
                {"001110",'М'},
                {"001111",'Н'},
                {"010000",'О'},
                {"010001",'П'},
                {"010010",'Р'},
                {"010011",'С'},
                {"010100",'Т'},
                {"010101",'У'},
                {"010110",'Ф'},
                {"010111",'Х'},
                {"011000",'Ц'},
                {"011001",'Ч'},
                {"011010",'Ш'},
                {"011011",'Щ'},
                {"011100",'Ъ'},
                {"011101",'Ы'},
                {"011110",'Ь'},
                {"011111",'Э'},
                {"000000",'Ю'},
                {"100000",'Я'},
                {"100001",'1'},
                {"100010",'2'},
                {"100011",'3'},
                {"100100",'4'},
                {"100101",'5'},
                {"100110",'6'},
                {"100111",'7'},
                {"101000",'8'},
                {"101001",'9'},
                {"101010",'0'},

            };

        private Dictionary<char, string> latin = new Dictionary<char, string>()
            {
                {'A',"000001"},
                {'B',"000010"},
                {'C',"000011"},
                {'D',"000100"},
                {'E',"000101"},
                {'F',"000110"},
                {'G',"000111"},
                {'H',"001000"},
                {'I',"001001"},
                {'J',"001010"},
                {'K',"001011"},
                {'L',"001100"},
                {'M',"001101"},
                {'N',"001110"},
                {'O',"001111"},
                {'P',"010000"},
                {'Q',"010001"},
                {'R',"010010"},
                {'S',"010011"},
                {'T',"010100"},
                {'U',"010101"},
                {'V',"010110"},
                {'W',"010111"},
                {'X',"011000"},
                {'Y',"011001"},
                {'Z',"011010"},
                {'0',"011011"},
                {'1',"011100"},
                {'2',"011101"},
                {'3',"011110"},
                {'4',"011111"},
                {'5',"000000"},
                {'6',"100000"},
                {'7',"100001"},
                {'8',"100010"},
                {'9',"100011"},
            };
        private Dictionary<string, char> latin_reverse = new Dictionary<string, char>()
            {
                {"000001",'A'},
                {"000010",'B'},
                {"000011",'C'},
                {"000100",'D'},
                {"000101",'E'},
                {"000110",'F'},
                {"000111",'G'},
                {"001000",'H'},
                {"001001",'I'},
                {"001010",'J'},
                {"001011",'K'},
                {"001100",'L'},
                {"001101",'M'},
                {"001110",'N'},
                {"001111",'O'},
                {"010000",'P'},
                {"010001",'Q'},
                {"010010",'R'},
                {"010011",'S'},
                {"010100",'T'},
                {"010101",'U'},
                {"010110",'V'},
                {"010111",'W'},
                {"011000",'X'},
                {"011001",'Y'},
                {"011010",'Z'},
                {"011011",'0'},
                {"011100",'1'},
                {"011101",'2'},
                {"011110",'3'},
                {"011111",'4'},
                {"000000",'5'},
                {"100000",'6'},
                {"100001",'7'},
                {"100010",'8'},
                {"100011",'9'},
            };

        private string GammaToBinary(string gamma, char lang)
        {
            //string gammaBin = "2"; //Пишем 2 тк бигинт не может начинаться с 0 :(
            string gammaBin = "";
            if (lang == 'e')
            {
                foreach (char simbol in gamma)
                {
                    try
                    {
                        gammaBin += latin[simbol];
                    }
                    catch (KeyNotFoundException ke)
                    {
                        richTextBox4.Text = "Проверьте правльность выбора вводимого языка. И на вход принемаются только цифры [0..9] и буквы выбранного алфавита";
                        return "#ErroR";
                    }
                }
            } else if (lang == 'r')
            {
                foreach (char simbol in gamma)
                {
                    try
                    {
                        gammaBin += cyrilic[simbol];
                    }
                    catch (KeyNotFoundException ke)
                    {
                        richTextBox4.Text = "Проверьте правльность выбора вводимого языка. И на вход принемаются только цифры [0..9] и буквы выбранного алфавита";
                        return "#ErroR";
                    }
                }
            }

            return gammaBin;
            //return BigInteger.Parse(gammaBin);
        }
        private string TextToBinary(string text, char lang)
        {
            //string textBin = "2"; //Пишем 2 тк бигинт не может начинаться с 0 :(
            string textBin = "";
            if (lang == 'e')
            {
                foreach (char simbol in text)
                {
                    try
                    { 
                        textBin += latin[simbol];
                    }
                    catch (KeyNotFoundException ke)
                    {
                        richTextBox4.Text = "Проверьте правльность выбора вводимого языка. И на вход принемаются только цифры [0..9] и буквы выбранного алфавита";
                        return "#ErroR";
                    }
                }
            }
            else if (lang == 'r')
            {
                foreach (char simbol in text)
                {
                    try
                    {
                        textBin += cyrilic[simbol];
                    }
                        catch (KeyNotFoundException ke)
                    {
                        richTextBox4.Text = "Проверьте правльность выбора вводимого языка. И на вход принемаются только цифры [0..9] и буквы выбранного алфавита";
                        return "#ErroR";
                    }
                }
            }

            return textBin;
            //return BigInteger.Parse(textBin);
        }
        private string XOR(string g, string t)
        {
            char[] gamma = g.ToCharArray();
            char[] text = t.ToCharArray();
            string answer = "";
            int n1, n2;
            //for (int i = 1; i < t.Length; i++)
            for (int i = 0; i < t.Length; i++)
            {
                n1 = Convert.ToInt32(gamma[i]); n2 = Convert.ToInt32(text[i]);
                answer += (n1 ^ n2).ToString();
            }
            return answer;
        }
        private string EncryptWithKey (string text, string key, char lang)
        {
            if (text.Length > 23000)
            {
                richTextBox4.Text = "Слишком длинная последовательность";
            }
            string gamma = key;
            //отсекаем излишек ключа
            while (gamma.Length > text.Length)
            {
                gamma = gamma.Remove(gamma.Length-1);
            }
            //Размножаем ключ по длине слова
            while (gamma.Length < text.Length)
            {
                if (gamma.Length + key.Length > text.Length)
                {
                    for (int i = 0; i < key.Length && (gamma.Length < text.Length); i++)
                    {
                        gamma += key[i];
                    }
                } else gamma += key;
            }

            //Переводим гамму в бинарный код
            //BigInteger gammaBin = GammaToBinary(gamma, lang);
            string gammaBin = GammaToBinary(gamma, lang);
            if (gammaBin == "#ErroR")
            {
                return "#ErroR";
            }
            //Текст в бинарный
            string textBin = TextToBinary(text, lang);
            if (textBin == "#ErroR")
            {
                return "#ErroR";
            }

            string cipher = XOR(gammaBin, textBin);
            return cipher;
        }
        private string FromBin(string bins, char lang)
        {
            string orig = "";

            for (int i = 0; i < bins.Length; i = i + 6)
            {
                string l = "";
                for (int j = i; j < i + 6 && j < bins.Length; j++)
                {
                    l += bins[j];
                }

                try
                {
                    if (lang == 'e') orig += latin_reverse[l];
                    else orig += cyrilic_reverse[l];
                }
                catch (KeyNotFoundException ke)
                {
                    richTextBox4.Text = "В сообщение используются символы, которых нет в выбранном алфавите";
                    return "#ErroRFromBin";
                }

                
            }
            return orig;
        }
        private string DecryptWithKey(string cipher, string key, char lang)
        {
            if (!CheckIsReallyBin(cipher))
            {
                richTextBox4.Text = "Шифр может содержать только 0 и 1";
                return "#ErroR2";
            }
            //Переводим гамму в бинарный код
            //BigInteger gammaBin = GammaToBinary(gamma, lang);
            string gammaBin = GammaToBinary(key, lang);
            if (gammaBin == "#ErroR")
            {
                return "#ErroR";
            }
            string gamma1 = gammaBin;

            //Размножаем ключ по длине слова
            while (gammaBin.Length < cipher.Length)
            {
                if (gammaBin.Length + gamma1.Length > cipher.Length)
                {
                    for (int i = 0; i < gamma1.Length && (gammaBin.Length < cipher.Length); i++)
                    {
                        gammaBin += gamma1[i];
                    }
                }
                else gammaBin += gamma1;
            }

            
            //Текст в бинарный
            //string textBin = TextToBinary(text, lang);

            string text = XOR(gammaBin, cipher);
            string textOrig = FromBin(text, lang);
            //richTextBox4.Text = textOrig;
            return textOrig;
        }

        private string GeneratePseudo(int N)
        {
            string answer = "";
            Random random = new Random();
            bool[] arr;
            if (N % 2 == 0)
            {
                //List<bool> half0 = new List<bool>();
                bool[] half0 = Enumerable.Repeat(false, N / 2).ToArray();
                bool[] half1 = Enumerable.Repeat(true, N/2).ToArray();

                arr = half0.Concat(half1).ToArray();
            } else
            {
                bool[] half0 = Enumerable.Repeat(false, (N-1) / 2).ToArray();
                bool[] half1 = Enumerable.Repeat(true, (N-1) / 2).ToArray();

                arr = half0.Concat(half1).ToArray();
            }

            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                // обменять значения arr[j] и arr[i]
                var temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
            }
            foreach (bool symb in arr)
            {
                answer += symb == true ? 1 : 0;
            }

            return answer + "1";
        }
        private string EncryptWithPseudo(string text, char lang)
        {
            if (text.Length > 13000)
            {
                richTextBox4.Text = "Слишком длинная последовательность";
            }
            //Текст в бинарный
            string textBin = TextToBinary(text, lang);
            if (textBin == "#ErroR")
            {
                return "#ErroR";
            }
            //создаем псевдослуч последовательность
            string pseudo = GeneratePseudo(textBin.Length);
            richTextBox5.Text = pseudo;
            string cipher = XOR(pseudo, textBin);
            //richTextBox3.Text = cipher;
            return cipher;
        }
        private string DecryptWithPseudo(string cipher, char lang)
        {
            string pseudo = richTextBox5.Text;
            if (!CheckIsReallyBin(pseudo))
            {
                richTextBox4.Text = "Псевдо-случайная последовательность может содержать только 0 и 1";
                return "#ErroR2";
            }
            if (!CheckIsReallyBin(cipher))
            {
                richTextBox4.Text = "Шифр может содержать только 0 и 1";
                return "#ErroR2";
            }
            string text = XOR(pseudo, cipher);
            string textOrig = FromBin(text, lang);
            //richTextBox4.Text = textOrig;
            return textOrig;
        }

        private bool CheckIsReallyBin(string s)
        {
            foreach(char c in s)
            {
                if (c != '1' && c != '0')
                {
                    return false;
                }
            }
            return true;
        }

        //Button-encrypter
        private void button1_Click(object sender, EventArgs e)
        {
            //Смотрим radio-button
            if (radioButton2.Checked == true)
            {
                //Если нет ключа - работаем с псевдослуч послед
                if (richTextBox1.Text.Trim(' ') == "")
                {
                    string text = richTextBox2.Text.Trim(' ').ToUpper();
                    string cipher = EncryptWithPseudo(text, 'e');
                    if (cipher != "#ErroR" && cipher != "#ErroRFromBin")
                    {
                        richTextBox3.Text = cipher;
                        return;
                    }
                } else
                {
                    string key = richTextBox1.Text.Trim(' ').ToUpper();
                    string text = richTextBox2.Text.Trim(' ').ToUpper();
                    string cipher = EncryptWithKey(text, key, 'e');

                    if (cipher != "#ErroR" && cipher != "#ErroRFromBin")
                    {
                        richTextBox3.Text = cipher;
                        return;
                    }
                }
            } else if (radioButton1.Checked == true)
            {
                //Если нет ключа - работаем с псевдослуч послед
                if (richTextBox1.Text.Trim(' ') == "")
                {
                    string text = richTextBox2.Text.Trim(' ').ToUpper();
                    string cipher = EncryptWithPseudo(text, 'r');

                    if (cipher != "#ErroR" && cipher != "#ErroRFromBin")
                    {
                        richTextBox3.Text = cipher;
                        return;
                    }
                }
                else
                {
                    string key = richTextBox1.Text.Trim(' ').ToUpper();
                    string text = richTextBox2.Text.Trim(' ').ToUpper();
                    string cipher = EncryptWithKey(text, key, 'r');

                    if (cipher != "#ErroR" && cipher != "#ErroRFromBin")
                    {
                        richTextBox3.Text = cipher;
                        return;
                    }
                }
            }

        }


        //Button-decrypter
        private void button2_Click(object sender, EventArgs e)
        {
            //Смотрим radio-button
            if (radioButton2.Checked == true)
            {
                //Если нет ключа - работаем с псевдослуч послед
                if (richTextBox1.Text.Trim(' ') == "")
                {
                    if (richTextBox5.Text == "")
                    {
                        richTextBox4.Text = "Невозможно расшифровать без ключа или псевдо-случайной последовательности";
                        return;
                    }
                    if (richTextBox3.Text.Length < 6)
                    {
                        richTextBox4.Text = "Невозможно расшифровать код с менее чем шестью битами";
                        return;
                    }
                    if (richTextBox3.Text.Length != richTextBox5.Text.Length)
                    {
                        richTextBox4.Text = "Длина шифра и псевдо-случайной последовательности должны совпадать. В противном случае это есть Ключ";
                        return;
                    }
                    string cipher = richTextBox3.Text.Trim(' ');
                    string text = DecryptWithPseudo(cipher, 'e');

                    if (text != "#ErroR2" && text != "#ErroRFromBin")
                    {
                        richTextBox2.Text = text;
                        return;
                    }
                }
                else
                {
                    string key = richTextBox1.Text.Trim(' ').ToUpper();
                    string cipher = richTextBox3.Text.Trim(' ');
                    string text = DecryptWithKey(cipher, key, 'e');

                    if (text != "#ErroR2" && text != "#ErroR" && text != "#ErroRFromBin")
                    {
                        richTextBox2.Text = text;
                        return;
                    }
                }
            }
            else if (radioButton1.Checked == true)
            {
                //Если нет ключа - работаем с псевдослуч послед
                if (richTextBox1.Text.Trim(' ') == "")
                {
                    if (richTextBox5.Text == "")
                    {
                        richTextBox4.Text = "Невозможно расшифровать без ключа или псевдо-случайной последовательности";
                        return;
                    }
                    if (richTextBox3.Text.Length % 6 != 0)
                    {
                        richTextBox4.Text = "Невозможно расшифровать код с менее чем шестью битами и с длиной кода не кратной 6";
                        return;
                    }
                    if (richTextBox3.Text.Length != richTextBox5.Text.Length)
                    {
                        richTextBox4.Text = "Длина шифра и псевдо-случайной последовательности должны совпадать. В противном случае это есть Ключ";
                        return;
                    }
                    string cipher = richTextBox3.Text.Trim(' ');
                    string text = DecryptWithPseudo(cipher, 'r');

                    if (text != "#ErroR2" && text != "#ErroRFromBin")
                    {
                        richTextBox2.Text = text;
                        return;
                    }
                }
                else
                {
                    string key = richTextBox1.Text.Trim(' ').ToUpper();
                    string cipher = richTextBox3.Text.Trim(' ');
                    string text = DecryptWithKey(cipher, key, 'r');

                    if (text != "#ErroR2" && text != "#ErroR" && text != "#ErroRFromBin")
                    {
                        richTextBox2.Text = text;
                        return;
                    }
                }
            }
        }

    }
}
