using System.Text.RegularExpressions;

namespace HW3
{
    public class Exercise1
    {
        private OriginalString _originalString;
        private string[] _finalString;
        private string _find;
        private string _result;
        public Exercise1(string find)
        {
            _find = find;
        }

        public string Treatment()
        {
            _originalString = new OriginalString();
            _finalString = _originalString.Original().Split(" ");
            bool result = Regex.IsMatch(_finalString[1], _find);
            if (result == false)
            {
                _result = "null";
            }
            else
            {
                _result = Convert.ToString(_finalString[1].IndexOf(_find));
            }

            return _result;
        }
    }
}
