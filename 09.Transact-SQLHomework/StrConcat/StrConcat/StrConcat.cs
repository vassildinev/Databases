namespace StrConcat
{
    using Microsoft.SqlServer.Server;
    using System;
    using System.Data.SqlTypes;
    using System.IO;
    using System.Text;

    [Serializable]
    [SqlUserDefinedAggregate(
       Format.UserDefined,
       IsInvariantToDuplicates = false,
       IsInvariantToNulls = false,
       IsInvariantToOrder = true,
       MaxByteSize = 8000)]
    public class StrConcat : IBinarySerialize
    {
        private StringBuilder intermediateResult;

        public void Init()
        {
            this.intermediateResult = new StringBuilder();
        }

        public void Accumulate(SqlString value, SqlString separator)
        {
            if (value.IsNull)
            {
                return;
            }

            this.intermediateResult.Append(value.Value).Append(separator.Value);
        }

        public void Merge(StrConcat other)
        {
            this.intermediateResult.Append(other.intermediateResult);
        }

        public SqlString Terminate()
        {
            string output = string.Empty;
            if (this.intermediateResult != null
                && this.intermediateResult.Length > 0)
            {
                output = this.intermediateResult.ToString(startIndex: 0, length: this.intermediateResult.Length - 1);
            }

            return new SqlString(output);
        }

        public void Read(BinaryReader r)
        {
            intermediateResult = new StringBuilder(r.ReadString());
        }

        public void Write(BinaryWriter w)
        {
            w.Write(this.intermediateResult.ToString());
        }
    }
}
