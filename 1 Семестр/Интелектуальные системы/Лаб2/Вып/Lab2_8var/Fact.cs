using System.IO;
using System.Text;

namespace Lab2_8var
{
    public class Fact
    {
        private int _id;
        private string _object;
        private string _attribute;
        private string _value;
        private double _truth;
        private FactType _type;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Object
        {
            get
            {
                return _object;
            }
            set
            {
                _object = value;
            }
        }

        public string Attribute
        {
            get
            {
                return _attribute;
            }
            set
            {
                _attribute = value;
            }
        }

        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public double Truth
        {
            get
            {
                return _truth;
            }
            set
            {
                _truth = value;
            }
        }

        public FactType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public Fact(int _id, string _object, string _attribute, string _value, double _truth, FactType _type)
        {
            this._id = _id;
            this._object = _object;
            this._attribute = _attribute;
            this._value = _value;
            this._truth = _truth;
            this._type = _type;
        }

        public override string ToString()
        {
            return Object + "__" + Attribute + "__" + Value;
        }

        public void ReadFromFile(BinaryReader br)
        {
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            _id = br.ReadInt32();
            int length1 = br.ReadInt32();
            if (length1 > 0 && length1 < 1024)
            {
                byte[] numArray = new byte[length1];
                br.Read(numArray, 0, numArray.Length);
                this._object = encoding.GetString(numArray, 0, numArray.Length);
            }
            int length2 = br.ReadInt32();
            if (length2 > 0 && length2 < 1024)
            {
                byte[] numArray = new byte[length2];
                br.Read(numArray, 0, numArray.Length);
                this._attribute = encoding.GetString(numArray, 0, numArray.Length);
            }
            int length3 = br.ReadInt32();
            if (length3 > 0 && length3 < 1024)
            {
                byte[] numArray = new byte[length3];
                br.Read(numArray, 0, numArray.Length);
                this._value = encoding.GetString(numArray, 0, numArray.Length);
            }
            _truth = br.ReadDouble();
            _type = (FactType)br.ReadInt32();
        }
    }
}
