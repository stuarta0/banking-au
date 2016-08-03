using R = Banking.AU.ABA;

namespace Banking.AU.ABA.Validation.AbaFile
{
    public interface ICanAdd
    {
        /// <summary>
        /// Indicates whether additional DetailRecords can be added to an AbaFile.
        /// </summary>
        bool CanAdd(R.AbaFile file, params R.Records.DetailRecord[] records);
    }
}
