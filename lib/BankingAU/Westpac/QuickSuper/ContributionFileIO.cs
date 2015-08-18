using Banking.AU.Common;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Banking.AU.Westpac.QuickSuper
{
    public class ContributionFileIO : IFileIO<ContributionFile>
    {
        private static string HEADER;

        static ContributionFileIO()
        {
            var props = new List<string>();
            foreach (var p in typeof(ContributionRecord).GetFields())
                props.Add(p.Name);
            HEADER = String.Join(",", props.ToArray());
        }

        public ContributionFileIO()
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


        public ContributionFile Read(string filename)
        {
            using (var stream = File.OpenText(filename))
                return Read(stream);
        }

        public ContributionFile Read(TextReader stream)
        {
            var engine = new DelimitedFileEngine<ContributionRecord>();
            engine.ErrorMode = ErrorMode.ThrowException;
            return new ContributionFile(engine.ReadStream(stream));
        }

        public void Write(string filename, ContributionFile file)
        {
            using (var stream = File.CreateText(filename))
                Write(stream, file);
        }

        public void Write(TextWriter stream, ContributionFile file)
        {
            var engine = new DelimitedFileEngine<ContributionRecord>();
            engine.HeaderText = HEADER; // Contribution file must have header row
            engine.ErrorMode = ErrorMode.ThrowException;
            engine.WriteStream(stream, file.Records);
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
