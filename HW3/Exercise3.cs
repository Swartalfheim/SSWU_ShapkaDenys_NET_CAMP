namespace HW3
{
    public class Exercise3
    {
        private OriginalString _originalString;
        private string _change;
        private string _finalString;
        public Exercise3(string change)
        {
            _change = change;
        }

        public string Treatment()
        {
            _originalString = new OriginalString();
            string c = " ";
            _finalString = _originalString.Original();
            string result = _finalString;
            for (int i = 0; i < _finalString.Length; i++)
            {
                if (i >= 1 && _finalString[i] == _finalString[i - 1])
                {
                    c = Convert.ToString(_finalString[i]) + Convert.ToString(_finalString[i - 1]);
                    result = result.Replace(c, _change);
                }
            }

            return result;
        }
    }
}
