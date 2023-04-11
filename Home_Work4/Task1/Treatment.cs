namespace Task1
{
    public class Treatment
    {
        private List<string> _result;
        private DataStorage _storage;
        private string _sentence;
        private string[] _punctuations;
        public List<string> Processing()
        {
            _storage = new DataStorage();
            _result = new List<string>();
            _punctuations = new string[] { ".", "!", "?" };
            for (int i = 0; i < _storage.Storage().Count; i++)
            {
                for (int j = 0; j < _storage.Storage()[i].Length; j++)
                {
                    _sentence = _sentence + _storage.Storage()[i][j];
                    if (_punctuations.Any(a => _sentence.Contains(a)))
                    {
                        if (_sentence.Contains('(') && _sentence.Contains(')'))
                        {
                            _sentence = _sentence.Trim();
                            _result.Add(_sentence);
                        }

                        _sentence = null;
                    }
                }
            }

            return _result;
        }
    }
}
