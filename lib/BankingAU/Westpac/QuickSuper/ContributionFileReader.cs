using FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Banking.AU.Westpac.QuickSuper
{
    public class ContributionFileReader
    {
        public ContributionFileReader()
        {
            
        }

        /// <summary>
        /// Warning: usage sets global singleton value for FileHelpers engine.
        /// Using two or more readers with different formats simultaneously will fail.
        /// </summary>
        public string DateTimeFormat
        {
            get { return FileHelpers.ConverterBase.DefaultDateTimeFormat; }
            set { FileHelpers.ConverterBase.DefaultDateTimeFormat = value; }
        }


        public IList<ContributionRecord> Read(string filename)
        {
            using (var stream = File.OpenText(filename))
                return Read(stream);
        }

        public IList<ContributionRecord> Read(TextReader stream)
        {
            var engine = new DelimitedFileEngine<ContributionRecord>();
            return engine.ReadStream(stream);
        }

        public void Write(string filename, IList<ContributionRecord> records)
        {
            using (var stream = File.OpenWrite(filename))
            using (var writer = new StreamWriter(stream))
                Write(writer, records);
        }

        public void Write(TextWriter stream, IList<ContributionRecord> records)
        {
            var engine = new DelimitedFileEngine<ContributionRecord>();
            engine.WriteStream(stream, records);
        }


        // Class to provide runtime custom DateTime format
        //private class DateTimeConverter : ConverterBase
        //{
        //    static DateTimeConverter()
        //    {
        //    }

        //    public string DateTimeFormat { get; set; }

        //    public override string FieldToString(object from)
        //    {
        //        if (from == null)
        //            return null;
        //        return ((DateTime)from).ToString(DateTimeFormat);
        //    }

        //    public override object StringToField(string from)
        //    {
        //        try
        //        {
        //            return DateTime.ParseExact(from, DateTimeFormat, System.Globalization.CultureInfo.CurrentCulture);
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //}
    }
}
