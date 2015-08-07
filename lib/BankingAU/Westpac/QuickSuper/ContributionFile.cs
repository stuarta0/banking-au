using FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Banking.AU.Westpac.QuickSuper
{
    public class ContributionFile
    {
        private static string HEADER;

        static ContributionFile()
        {
            var props = new List<string>();
            foreach (var p in typeof(ContributionRecord).GetProperties())
                props.Add(p.Name);
            HEADER = String.Join(",", props.ToArray());
        }

        public ContributionFile()
        {
            DateTimeFormat = null;
        }

        /// <summary>
        /// Warning: usage sets global singleton value for FileHelpers engine.
        /// Using two or more readers with different formats simultaneously will fail.
        /// TODO: pull request from FileHelpers and allow FieldBase.Converter to have public set.
        /// </summary>
        public string DateTimeFormat
        {
            get { return FileHelpers.ConverterBase.DefaultDateTimeFormat; }
            set { FileHelpers.ConverterBase.DefaultDateTimeFormat = value ?? "dd-MMM-yy"; }
        }


        public IList<ContributionRecord> Read(string filename)
        {
            using (var stream = File.OpenText(filename))
                return Read(stream);
        }

        public IList<ContributionRecord> Read(TextReader stream)
        {
            var engine = new DelimitedFileEngine<ContributionRecord>();
            engine.ErrorMode = ErrorMode.ThrowException;
            return engine.ReadStream(stream);
        }

        public void Write(string filename, IList<ContributionRecord> records)
        {
            using (var stream = File.CreateText(filename))
                Write(stream, records);
        }

        public void Write(TextWriter stream, IList<ContributionRecord> records)
        {
            var engine = new DelimitedFileEngine<ContributionRecord>();
            engine.HeaderText = HEADER; // Contribution file must have header row
            engine.ErrorMode = ErrorMode.ThrowException;
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
