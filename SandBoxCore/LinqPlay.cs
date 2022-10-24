using System;
using System.Collections.Generic;
using System.Linq;

namespace SandBoxCore
{
    public class LinqPlay
    {
        private List<byte> _source = new List<byte>();
        private int _total = 10000000;
        private int _valueToSkip = 9000000;


        public LinqPlay()
        {
            for (int i = 0; i < _total; i++)
            {
                _source.Add((byte)i);
            }
        }



        public IEnumerable<string> GetLineNumberStrings()
        {
            // return Enumerable.Empty<string>();

            List<int> numbers = Enumerable.Range(1, 10).ToList();
            return numbers.Select(i => String.Format("{0}: ", i)).ToList();
        }

        public IEnumerable<byte> UsingSkip()
        {
            return RetrieveSource().Skip(_valueToSkip)
                .ToList()
                .Select(v => FakeWork(v));
        }

        public IEnumerable<byte> UsingIndexer()
        {
            var valuesList = RetrieveSource() as List<byte>;
            var count = valuesList.Count;

            for (int i = _valueToSkip; i < count; i++)
                yield return FakeWork(valuesList[i]);
        }

        public IEnumerable<byte> UsingArray()
        {
            var valuesList = RetrieveSource() as List<byte>;
            var valuesToTake = _total - _valueToSkip;
            var array = new byte[valuesToTake + 1];
            valuesList.CopyTo(_valueToSkip, array, 0, valuesToTake);
            var arraySegment = new ArraySegment<byte>(array);
            return arraySegment.Select(v => FakeWork(v)).ToList();

        }

        public IEnumerable<byte> UsingImprovedArray()
        {
            var valuesList = RetrieveSource() as List<byte>;
            var valuesToTake = _total - _valueToSkip;
            var array = new byte[valuesToTake];
            valuesList.CopyTo(_valueToSkip, array, 0, valuesToTake);
            return array.Select(v => FakeWork(v));
        }

        public IEnumerable<byte> UsingImprovedArrayWithToListGuard()
        {
            var valuesList = (RetrieveSource() as List<byte>) ?? RetrieveSource().ToList();
            var valuesToTake = valuesList.Count - _valueToSkip;
            var array = new byte[valuesToTake];
            valuesList.CopyTo(_valueToSkip, array, 0, valuesToTake);
            return array.Select(v => FakeWork(v));
        }

        public IEnumerable<byte> UsingElementAt()
        {
            var values = RetrieveSource();
            for (int i = _valueToSkip; i < values.Count(); i++)
                yield return FakeWork(values.ElementAt(i));
        } 


        private static byte FakeWork(byte input)
        {
            return input++;
        }

        private IEnumerable<byte> RetrieveSource()
        {
            return _source;
        }
    }
}