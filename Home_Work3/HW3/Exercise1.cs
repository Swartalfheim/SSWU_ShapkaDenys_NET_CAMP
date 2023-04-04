using System.Text.RegularExpressions;

namespace HW3
{
    public class Exercise1
    {
        private OriginalString _originalString;
        private string _finalString;
        private string _find;
        private int? _result;
        public Exercise1(string find)
        {
            _find = find;
        }

        public int? Treatment()
        {
            _originalString = new OriginalString();
            _finalString = _originalString.Original();
            bool result = Regex.IsMatch(_finalString, _find);
            if (result == false)
            {
                _result = null;
            }
            else
            {
                int r = Convert.ToInt32(_finalString.IndexOf(_find));
                _result = Convert.ToInt32(_finalString.IndexOf(_find, r + 1));
            }

            if (_result == -1)
            {
                _result = null;
            }

            return _result;
        }
    }
}
