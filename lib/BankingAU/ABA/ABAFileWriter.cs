using Banking.AU.ABA.Records;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Banking.AU.ABA
{
    public class ABAFileWriter
    {
        public ABAFileWriter()
        {
        }

        public ABAFile Read(string filename)
        {
            using (var stream = File.OpenText(filename))
                return Read(stream);
        }

        public ABAFile Read(TextReader stream)
        {
            var engine = new MultiRecordEngine(typeof(DescriptiveRecord),
                                               typeof(DetailRecord),
                                               typeof(FileTotalRecord));
            engine.RecordSelector = new RecordTypeSelector(ABAFormatSelector);
            var records = engine.ReadStream(stream);

            var file = new ABAFile();
            foreach (var r in records)
            {
                if (r is DescriptiveRecord)
                    file.DescriptiveRecord = (DescriptiveRecord)r;
                else if (r is DetailRecord)
                    file.DetailRecords.Add((DetailRecord)r);
                else if (r is FileTotalRecord)
                    file.FileTotalRecord = (FileTotalRecord)r;
            }
            return file;
        }

        public void Write(string filename, ABAFile file)
        {
            using (var stream = File.CreateText(filename))
                Write(stream, file);
        }

        public void Write(TextWriter stream, ABAFile file)
        {
            var engine = new MultiRecordEngine(typeof(DescriptiveRecord),
                                               typeof(DetailRecord),
                                               typeof(FileTotalRecord));
            engine.RecordSelector = new RecordTypeSelector(ABAFormatSelector);
            
            var data = new List<object>();
            data.Add(file.DescriptiveRecord);
            foreach (var d in file.DetailRecords)
                data.Add(d);
            data.Add(file.FileTotalRecord);
            engine.WriteStream(stream, data);
        }

        private Type ABAFormatSelector(MultiRecordEngine engine, string recordLine)
        {
            if (recordLine.Length == 0)
                return null;

            var type = Convert.ToInt32(recordLine[0]) - 48; // ascii 48 = '0'
            if (type == 0)
                return typeof(DescriptiveRecord);
            else if (type == 1)
                return typeof(DetailRecord);
            else if (type == 7)
                return typeof(FileTotalRecord);
            return null;
        }
    }
}
