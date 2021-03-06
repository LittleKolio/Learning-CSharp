﻿using System;

public class BankAccount
{
    private int id;
    private decimal balance;

    public int Id
    {
        get { return id; }
        set { this.id = value; }
    }
    public decimal Balance
    {
        get { return balance; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Insufficient balance");
            }
            this.balance = value;
        }
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        this.Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account ID{this.Id}, balance {this.Balance:F2}";
    }
}