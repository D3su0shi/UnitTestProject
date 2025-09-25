namespace TestProject1;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        // Constructor Test
        decimal bankTest = 67m;
        BankAccount testBankAccount = new BankAccount("Sir D3", 67m);

        Assert.AreEqual(bankTest, testBankAccount.Balance, "The bank account wasn’t initialized properly");
    }

    [TestMethod]
    public void TestMethod2()
    {
        // Deposit Method Test
        BankAccount testBankAccount = new BankAccount("Sir D3", 67m);

        decimal depositAmount = 69m;
        testBankAccount.Deposit(depositAmount);

        Assert.AreEqual(67m + 69m, testBankAccount.Balance, "Deposit did not update balance correctly");

        // Test invalid deposit (should throw exception)
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => testBankAccount.Deposit(-96m));
    }

    [TestMethod]
    public void TestMethod3()
    {
        // Withdraw Method Test
        BankAccount testBankAccount = new BankAccount("Sir D3", 67m);

        decimal debitAmount = 42m;
        decimal currentBalance = testBankAccount.Balance;

        testBankAccount.Withdraw(debitAmount);

        Assert.AreEqual(currentBalance - debitAmount, testBankAccount.Balance, "Withdraw did not update balance correctly");
    }


    [TestMethod]
    public void TestMethod4()
    {
        BankAccount testBankAccount = new BankAccount("Sir D3", 67m);

        decimal depositAmount = 69m;
        testBankAccount.Deposit(depositAmount);

        decimal debitAmount = 42m;
        testBankAccount.Withdraw(debitAmount);

        Assert.AreEqual(3, testBankAccount.Transactions.Count, "Transaction count mismatch");

        Assert.AreEqual("Account created with balance: $67.00", testBankAccount.Transactions[0]);
        Assert.AreEqual("Deposited $69.00, new balance: $136.00", testBankAccount.Transactions[1]);
        Assert.AreEqual("Withdrew $42.00, new balance: $94.00", testBankAccount.Transactions[2]);
    }


    [TestMethod]
    public void TestMethod5()
    {
        BankAccount testBankAccount = new BankAccount("Sir D3", 67m);

        decimal depositAmount = 69m;
        testBankAccount.Deposit(depositAmount);

        decimal debitAmount = 42m;
        testBankAccount.Withdraw(debitAmount);

        Assert.AreEqual(testBankAccount.Balance, (67 + 69 - 42) );

    }

}