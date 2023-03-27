using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Transactions;

public class TransactionManager : ITransactionManager
{

    public ITransactionsEnumerator CommittedTransactions { get; }
    public ITransactionsEnumerator UndoneTransactions { get; }
    public ITransaction CurrentTransaction { get; }
    public ITransactionEvents TransactionEvents { get; }
    public ITransaction StartTransaction(IDocument Document, string DisplayName)
    {
        throw new NotImplementedException();
    }

    public ITransaction StartGlobalTransaction(IDocument Document, string DisplayName)
    {
        throw new NotImplementedException();
    }

    public ICheckPoint SetCheckPoint()
    {
        throw new NotImplementedException();
    }

    public void UndoTransaction()
    {
        throw new NotImplementedException();
    }

    public void GoToCheckPoint(ICheckPoint CheckPoint)
    {
        throw new NotImplementedException();
    }

    public void RedoTransaction()
    {
        throw new NotImplementedException();
    }

    public ITransaction _StartUnidentifiedTransaction()
    {
        throw new NotImplementedException();
    }

    public ITransaction StartTransactionForDocumentOpen(string DisplayName)
    {
        throw new NotImplementedException();
    }

    public void ClearAllTransactions()
    {
        throw new NotImplementedException();
    }

    public ITransaction StartTransactionWithOptions(IDocument Document, string DisplayName, INameValueMap Options)
    {
        throw new NotImplementedException();
    }

    public ITransaction EndTransaction()
    {
        throw new NotImplementedException();
    }

    public void AbortTransaction(TransactionPointEnum TransactionPoint, object TransactionObject)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}