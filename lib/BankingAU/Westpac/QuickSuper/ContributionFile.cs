using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Westpac.QuickSuper
{
    public class ContributionFile : IList<ContributionRecord>
    {
        public IList<ContributionRecord> Records { get; set; }

        public ContributionFile()
            : this(new List<ContributionRecord>())
        {
        }

        public ContributionFile(IEnumerable<ContributionRecord> records)
        {
            Records = new List<ContributionRecord>(records);
        }

        public int IndexOf(ContributionRecord item)
        {
            return Records.IndexOf(item);
        }

        public void Insert(int index, ContributionRecord item)
        {
            Records.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            Records.RemoveAt(index);
        }

        public ContributionRecord this[int index]
        {
            get
            {
                return Records[index];
            }
            set
            {
                Records[index] = value;
            }
        }

        public void Add(ContributionRecord item)
        {
            Records.Add(item);
        }

        public void Clear()
        {
            Records.Clear();
        }

        public bool Contains(ContributionRecord item)
        {
            return Records.Contains(item);
        }

        public void CopyTo(ContributionRecord[] array, int arrayIndex)
        {
            Records.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Records.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(ContributionRecord item)
        {
            return Records.Remove(item);
        }

        public IEnumerator<ContributionRecord> GetEnumerator()
        {
            return Records.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
