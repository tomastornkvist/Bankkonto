
enum AccountTypes { TransactionAccount, SavingsAccount, CreditAccount }
class Account(string mainHolder, string accountNumber, AccountTypes accountType)
{
    string AccountNumber = accountNumber;
    string MainHolder = mainHolder;
    List<String> AdditionalHolders = new();
    AccountTypes AccountType = accountType;
    double Balance = 0;
    private double interestRate = 0;
    public double InterestRate
    {
        get { return interestRate; }
        set
        {
            if (AccountType == AccountTypes.SavingsAccount)
                interestRate = value;
        }
    }

    private double creditLimit = 0;
    public double CreditLimit
    {
        get { return creditLimit; }
        set
        {
            switch (AccountType)
            {
                case AccountTypes.CreditAccount:
                    creditLimit = value;
                    break;
            }
        }
    }
    bool Locked = false;
    double TransferLimit = 0;
    double AccountFee = 0;

    public void Deposit(double amount)
    {
        Balance += amount;
    }
    public bool WithDraw(double amount)
    {
        switch (AccountType)
        {
            case AccountTypes.TransactionAccount:
            case AccountTypes.SavingsAccount:
                if (amount > Balance)
                    return false;
                break;

            case AccountTypes.CreditAccount:
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

    public bool Transfer(double amount, Account recipient)
    {
        switch (AccountType)
        {
            case AccountTypes.TransactionAccount:
            case AccountTypes.SavingsAccount:
                if (amount > Balance)
                    return false;
                break;

            case AccountTypes.CreditAccount:
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