
enum AccountTypes { TransactionAccount, SavingsAccount, DebitAccount, creditAccount }
class Account(string mainHolder, string accountNumber, AccountTypes accountType)
{
    string AccountNumber = accountNumber;
    string MainHolder = mainHolder;
    List<String> AdditionalHolders = new();
    AccountTypes AccountType = accountType;
    int Balance = 0;
    double InterestRate = 0;

    private int creditLimit = 0;
    public int CreditLimit
    {
        get { return creditLimit; }
        set
        {
            switch (AccountType)
            {
                case AccountTypes.DebitAccount:
                case AccountTypes.creditAccount:
                    creditLimit = value;
                    break;
            }
        }
    }
    bool Locked = false;
    int TransferLimit = 0;
    int AccountFee = 0;

    public void Deposit(int amount)
    {
        Balance += amount;
    }
    public bool WithDraw(int amount)
    {
        switch (AccountType)
        {
            case AccountTypes.TransactionAccount:
            case AccountTypes.SavingsAccount:
                if (amount > Balance)
                    return false;
                break;

            case AccountTypes.DebitAccount:
            case AccountTypes.creditAccount:
                if (amount > Balance + creditLimit)
                    return false;
                break;
        }
        Balance -= amount;
        return true;
    }

    public void ShowAccountInformation()
    {
        Console.WriteLine();
        Console.WriteLine($"Main holder: {MainHolder}");
        Console.WriteLine($"Account number: {AccountNumber}");
        if (AdditionalHolders.Count > 0)
            Console.WriteLine($"Additional holders: {string.Join(", ", AdditionalHolders)}");
        Console.WriteLine($"Account type: {AccountType}");
        Console.WriteLine($"Balance: {Balance}");
        if (this.InterestRate > 0)
            Console.WriteLine($"Interest rate: {this.InterestRate}");
        if (this.creditLimit > 0)
            Console.WriteLine($"Credit limit: {this.creditLimit}");
        if (this.Locked)
            Console.WriteLine("Account is locked");
        if (this.TransferLimit > 0)
            Console.WriteLine($"Transfer limit: {this.TransferLimit}");
        if (this.AccountFee > 0)
            Console.WriteLine($"Account fee: {this.AccountFee}");
    }

    public bool Transfer(int amount, Account recipient)
    {
        switch (AccountType)
        {
            case AccountTypes.TransactionAccount:
            case AccountTypes.SavingsAccount:
                if (amount > Balance)
                    return false;
                break;
            case AccountTypes.DebitAccount:
            case AccountTypes.creditAccount:
                if (amount > Balance + creditLimit)
                    return false;
                break;
        }
        recipient.Deposit(amount);
        Balance -= amount;
        return true;
    }

    public void addAdditionalHolder(string name)
    {
        AdditionalHolders.Add(name);
    }

    public void ShowBalance()
    {
        Console.WriteLine($"{AccountNumber} balance: {Balance}");
    }
}