namespace Task1
{
    public class Treatment
    {
        private List<string> _result;
        private List<string> _line;
        private DataStorage _storage;
        private char[] _punctuations;
        public List<string> Processing()
        {
            _storage = new DataStorage();
            _result = new List<string>();
            _line = new List<string>();
            _punctuations = new char[] { '.', '!', '?' };

            string[] arr = new string[_storage.Storage().Count]; // створюємо масив стрингів такоїж довжини як ліст
            _storage.Storage().CopyTo(arr); // необхідно зробити копію, бо функція змінює вміст масиву

            int index = 0;
            int i = 0;
            while (i < arr.Length)
            {
                do
                {
                    index = arr[i].IndexOfAny(_punctuations);
                    if (index != -1)
                    {
                        _line.Add(arr[i].Substring(0, index + 1));
                        arr[i] = arr[i].Substring(index + 1);
                        if (arr[i].Length == 0)
                        {
                            i++;
                        }

                        if (_line.Any(l => l.Contains('(') || l.Contains(')')))
                        {
                            _result.AddRange(_line);
                        }

                        _line = new List<string>();
                    }
                    else
                    {
                        _line.Add(arr[i]);
                        i++;
                    }
                }
                while (index == 0 && i < arr.Length);
            }

            return _result;
        }
    }
}
