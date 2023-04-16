using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Treatment
    {
        private DataStorage _dataStorage;
        private List<string> _result;
        private char[] _submols;

        public List<string> Storage()
        {
            _dataStorage = new DataStorage();
            _result = new List<string>();
            /*Знаходимо чи є @*/
            for (int i = 0; i < _dataStorage.Storage().Count; i++)
            {
                if (_dataStorage.Storage()[i].Contains("@"))
                {
                    _result.Add(_dataStorage.Storage()[i]);
                }
            }

            /*Знаходимо чи не довше основна частина за 64 символи*/
            for (int i = 0; i < _dataStorage.Storage().Count; i++)
            {
                for (int j = 0; j < _dataStorage.Storage()[i].Length; j++)
                {
                    if (_dataStorage.Storage()[i][j] == '@' && j >= 64)
                    {
                        _result.Remove(_dataStorage.Storage()[i]);
                    }
                }
            }

            _submols = new char[] { ';', '(', ')', '<', '>', '[', ']', '\\', };
            /*Знаходимо чи є взяті у коментар спец символи*/
            for (int i = 0; i < _dataStorage.Storage().Count; i++)
            {
                for (int j = 0; j < _dataStorage.Storage()[i].Length; j++)
                {
                    for (int x = 0; x < _submols.Length; x++)
                    {
                        if (_dataStorage.Storage()[i][j] == _submols[x] && _dataStorage.Storage()[i][j + 1] != '\"' && _dataStorage.Storage()[i][j - 1] != '\"')
                        {
                            _result.Remove(_dataStorage.Storage()[i]);
                        }
                    }
                }
            }

            /*Знаходимо чи є спецсимволи в домен*/
            int findex = 0;
            for (int i = 0; i < _dataStorage.Storage().Count; i++)
            {
                for (int j = 0; j < _dataStorage.Storage()[i].Length; j++)
                {
                    if (_dataStorage.Storage()[i][j] == '@')
                    {
                        findex = j;
                    }
                }

                for (int j = 0; j < _dataStorage.Storage()[i].Length; j++)
                {
                    if (j > findex && _dataStorage.Storage()[i][j] == '_')
                    {
                        _result.Remove(_dataStorage.Storage()[i]);
                    }
                }
            }

            /*Знаходимо чи є більша кількість @, без коментарів*/
            int nums = 0;
            int fin = 0;
            for (int i = 0; i < _dataStorage.Storage().Count; i++)
            {
                for (int j = 0; j < _dataStorage.Storage()[i].Length; j++)
                {
                    if (_dataStorage.Storage()[i][j] == '@')
                    {
                        nums++;
                        fin = j;
                    }
                }

                for (int j = 0; j < _dataStorage.Storage()[i].Length; j++)
                {
                    if (nums > 1 && _dataStorage.Storage()[i][j] == '@' && _dataStorage.Storage()[i][j + 1] != '\"' && _dataStorage.Storage()[i][j - 1] != '\"')
                    {
                        if (_dataStorage.Storage()[i][j] == '@' && j != fin)
                        {
                            _result.Remove(_dataStorage.Storage()[i]);
                        }
                    }
                }

                nums = 0;
            }

            return _result;
        }

        public List<string> Storage1()
        {
            _dataStorage = new DataStorage();
            _result = new List<string>();
            /*Знаходимо чи є @*/
            for (int i = 0; i < _dataStorage.Storage().Count; i++)
            {
                if (_dataStorage.Storage()[i].Contains("@"))
                {
                    _result.Add(_dataStorage.Storage()[i]);
                }
            }

            return _result;
        }
    }
}
