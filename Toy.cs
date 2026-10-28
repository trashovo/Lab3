using System;

namespace Lab3
{
    [Serializable]
    public struct Toy
    {
        private string _name;
        private double _price;
        private int _minAge;
        private int _maxAge;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int MinAge
        {
            get { return _minAge; }
            set { _minAge = value; }
        }

        public int MaxAge
        {
            get { return _maxAge; }
            set { _maxAge = value; }
        }

        public Toy(string name, double price, int minAge, int maxAge)
        {
            _name = name;
            _price = price;
            _minAge = minAge;
            _maxAge = maxAge;
        }

        public override string ToString()
        {
            return $"Игрушка: {_name}, Цена: {_price}, Возраст: {_minAge} - {_maxAge}";
        }
    }
}