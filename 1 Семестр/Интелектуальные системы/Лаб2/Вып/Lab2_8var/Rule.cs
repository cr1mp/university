using System.Collections;
using System.IO;
using System.Text;

namespace Lab2_8var
{
    public class Rule
    {
        private int _id;
        private string _name;
        private string _condition;
        private ArrayList _conclusions;
        private double _truth;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int Id
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


        public string Condition
        {
            get
            {
                return _condition;
            }
            set
            {
                _condition = value;
            }
        }

        public ArrayList Conclusions
        {
            get
            {
                return _conclusions;
            }
            set
            {
                _conclusions = value;
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

        public Rule(int _id)
        {
            this._id = _id;
            Name = "";
            Condition = "";
            Conclusions = new ArrayList();
            Truth = 1.0;
        }

        public override string ToString()
        {
            return Name;
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
                _name = encoding.GetString(numArray, 0, numArray.Length);
            }
            int length2 = br.ReadInt32();
            if (length2 > 0 && length2 < 1024)
            {
                byte[] numArray = new byte[length2];
                br.Read(numArray, 0, numArray.Length);
                _condition = encoding.GetString(numArray, 0, numArray.Length);
            }
            _conclusions.Clear();
            int num = br.ReadInt32();
            for (int index = 0; index < num; ++index)
                _conclusions.Add(br.ReadInt32());
            _truth = br.ReadDouble();
        }
    }
}
