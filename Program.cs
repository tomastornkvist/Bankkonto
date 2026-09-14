Account account1 = new("Tomas", "1", AccountTypes.TransactionAccount);
Account account2 = new("Tomas", "2", AccountTypes.SavingsAccount);
Account account3 = new("Tomas", "3", AccountTypes.creditAccount);

account2.addAdditionalHolder("Stina");
account1.Deposit(100);
account2.Deposit(10000);
account3.Deposit(50);
account3.CreditLimit = 50;
account1.ShowAccountInformation();
account2.ShowAccountInformation();
account3.ShowAccountInformation();

account2.Transfer(20, account1);
account3.Transfer(100, account1);

account1.ShowBalance();
account2.ShowBalance();
account3.ShowBalance();
