namespace HW3
{
    public class Exercise2
    {
        private OriginalString _originalString;
        private int _num;
        private string[] _finalString;
        public int Treatment()
        {
            _originalString = new OriginalString();
            _finalString = _originalString.Original().Split(" ");
            _num = 0;
            for (int i = 0; i < _finalString.Length; i++)
            {
                if (char.IsUpper(_finalString[i][0]))
                {
                    _num++;
                }
            }

            return _num;
        }
    }
}
