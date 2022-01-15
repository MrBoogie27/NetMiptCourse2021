using System;

namespace CommonNetLibrary
{
    [Serializable]
    public class MyDES
    {
        public byte[] key;
        public byte[] IV;

        public MyDES(byte[] _key, byte[] _IV)
        {
            key = _key;
            IV = _IV;
        }
    }
}
