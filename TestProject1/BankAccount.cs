using System;
using System.Collections.Generic;

public class BankAccount
{
    private static int nextId = 1;
    private int accountId;
    private string customerName;
    private decimal balance;
    private List<string> transactions;

    // Properties
    public int AccountId => accountId;
    public string CustomerName => customerName;
    public decimal Balance => balance;
    public IReadOnlyList<string> Transactions => transactions.AsReadOnly();

    // Constructor
    public BankAccount(string customerName, decimal initialBalance)
    {
        if (string.IsNullOrWhiteSpace(customerName))
            throw new ArgumentException("Customer name cannot be empty.");
        if (initialBalance < 0)
            throw new ArgumentOutOfRangeException("Initial balance cannot be negative.");

        this.accountId = nextId++;
        this.customerName = customerName;
        this.balance = initialBalance;
        this.transactions = new List<string>();

        transactions.Add($"Account created with balance: {initialBalance:C}");
    }

    // Deposit
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException("Deposit amount must be positive.");

        balance += amount;
        transactions.Add($"Deposited {amount:C}, new balance: {balance:C}");
    }

    // Withdraw
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException("Withdrawal amount must be positive.");
        if (amount > balance)
        {
            transactions.Add($"Failed withdrawal of {amount:C}, insufficient funds.");
            return false;
        }

        balance -= amount;
        transactions.Add($"Withdrew {amount:C}, new balance: {balance:C}");
        return true;
    }

    public override string ToString()
    {
        return $"Account #{accountId} {customerName}, Balance: {balance:C}";
    }
}

/*
public class Program
{
    public static void Main(string[] args)
    {
        // Test case 1: Create account with valid inputs
        BankAccount account = new BankAccount("opera", 676767);
        Console.WriteLine(account);

        // Test case 2: Deposit valid amount
        account.Deposit(67);
        Console.WriteLine("After deposit: " + account);

        // Test case 3: Withdraw valid amount
        bool success = account.Withdraw(76);
        Console.WriteLine("Withdrawal success: " + success);
        Console.WriteLine("After withdrawal: " + account);

        // Test case 4: Withdraw amount greater than balance (failure)
        success = account.Withdraw(4200);
        Console.WriteLine("Withdrawal success: " + success);

        // Test case 5: Invalid deposit (negative amount)
        try
        {
            account.Deposit(-1738m);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Caught exception: " + e.Message);
        }

        // Test case 6: Invalid withdrawal (negative amount)
        try
        {
            account.Withdraw(-679);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Caught exception: " + e.Message);
        }

        // Print transaction history
        Console.WriteLine("\n--- Transaction History ---");
        foreach (var t in account.Transactions)
        {
            Console.WriteLine(t);
        }
    }
}
*/ 