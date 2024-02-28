using System.Globalization;
using System.Text;

class FrequencyAnalysis
{
    public static void Main()
    {
        char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        double[] counter = new double[26];
        int count = 0;

        string path = "Betty.txt";

        using StreamReader reader = new StreamReader(path);
        string text = reader.ReadToEnd();


        foreach (char c in text)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (c == alphabet[i])
                {
                    counter[i]++;
                    count += 1;
                }
            }
        }

        for (int i = 0; i < counter.Length; i++)
        {
            counter[i] = counter[i] / count;
        }

        for (int i = 0; i < counter.Length - 1; i++)
        {
            int least = i;
            for (int j = i + 1; j < counter.Length; j++)
            {
                if (counter[j] > counter[least])
                {
                    least = j;
                }
            }
            double temp = counter[least];
            counter[least] = counter[i];
            counter[i] = temp;

            char temp2 = alphabet[least];
            alphabet[least] = alphabet[i];
            alphabet[i] = temp2;
        }

        char[] freqAlphabet = { 'E', 'T', 'A', 'O', 'N', 'I', 'S', 'H', 'R', 'L', 'D', 'U', 'C', 'Y', 'W', 'M', 'G', 'F', 'B', 'P', 'V', 'K', 'J', 'X', 'Q', 'Z' };


        for (int i = 0; i < alphabet.Length; i++)
        {
            Console.WriteLine(count + "\n" + alphabet[i] + " | " + counter[i].ToString("P", CultureInfo.InvariantCulture));
        }


        StringBuilder newText = new StringBuilder(text);
        for (int i = 0; i < newText.Length; i++)
        {
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (text[i] == alphabet[j])
                {
                    newText[i] = freqAlphabet[j];
                }
            }
        }


        FileStream file = new FileStream("Betty Output.txt", FileMode.Create);
        StreamWriter writer = new StreamWriter(file);

        writer.Write(newText);
        writer.Close();
    }
}