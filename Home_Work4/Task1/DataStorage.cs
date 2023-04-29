using System.Collections.Generic;
using System.IO;

namespace Task1
{
    public class DataStorage
    {
        private List<string> _lines;
        public List<string> Storage()
        {
            _lines = new List<string>();
            //Не варто прикріплюватись до одного файлу.
            FileStream file = new FileStream("E:\\SSWU_ShapkaDenys_NET_CAMP\\Home_Work4\\Task1\\test.txt", FileMode.Open);
            StreamReader readFile = new StreamReader(file);
            while (!readFile.EndOfStream)
            {
                _lines.Add(readFile.ReadLine());
            }

            readFile.Close(); // в мене зчитується з текстового файлу, але я продублював хардкодом і закоментував, щоб ви не змінювали посилання
            /*
            _lines = new List<string>()
            {
                "The Battle of Cannae was a key engagement of the Second Punic War between the Roman Republic and Carthage!",
                "Fought on 2 August 216 BC near the ancient village of Cannae in Apulia (southeast Italy). The Carthaginians and their allies,",
                "led by Hannibal, surrounded and practically annihilated a larger Roman and Italian army under the consuls ",
                "Lucius Aemilius Paullus and Gaius Terentius Varro! It is regarded as one of the greatest tactical feats in military history and one of the worst defeats in Roman history.",
                "For defense, warriors from Hispania carried large oval shields. Most Gallic foot warriors likely had no protection (other than large shields)."
            };
            */
            return _lines;
        }
    }
}
