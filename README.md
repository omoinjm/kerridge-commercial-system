# MAM Pre-Interview Assessment

## Purpose

The pre-assessment is a small programming assignment that you will be expected to complete prior to your interview.

The core objectives of the pre-interview assignment are:

- to acquire an understanding of your basic coding style and approach.
- to assess your general architectural abilities.
- to ascertain your understanding of object-oriented programming concepts.
- to form part of a discussion at your interview.

## Project Constraints

You are free to undertake this project in either of the following languages:

- .NET 3.5+, VB.NET or C#.
- HTML / CSS + JavaScript.

If you’re applying for a .NET role then it is expected that you undertake some .NET programming elements in your solution.

You can take as long as required; just ensure your solution is submitted 2 days prior to your interview.

## Core Expectations

Your solution will require some sort of input. You are free to provide any mechanism for feeding input into your solution (for example mock data provided from within a unit test).

You should provide sufficient evidence that your solution is complete by, as a minimum, indicating that it works correctly against the supplied test data.

## Assignment

**Problem Statement: Sales Taxes**

Basic tax is applicable at a rate of 10% on all goods, except books, food, and medical products that are exempt. Import duty is an additional tax applicable on all imported goods at a rate of 5%, with no exceptions.

When I purchase items I receive a receipt which lists the name of all the items and their price (including tax), finishing with the total cost of items, and the total amount of tax paid.

The rounding rules for tax are:
For a tax rate of n%, a shelf price of p contains (np / 100 rounded up to the nearest 0.05) amount of tax.

Write an application that prints out the receipt details for these shopping baskets:

**Input 1:**
- 1 Book at 12.49
- 1 Music CD at 14.99
- 1 Chocolate bar at 0.85

**Output 1:**
- 1 book : 12.49
- 1 music CD: 16.49
- 1 chocolate bar: 0.85
- Sales Taxes: 1.50
- Total: 29.83

**Input 2:**
- 1 Imported box of chocolates at 10.00
- 1 Imported bottle of perfume at 47.50

**Output 2:**
- 1 imported box of chocolates: 10.50
- 1 imported bottle of perfume: 54.65
- Sales Taxes: 7.65
- Total: 65.15

**Input 3:**
- 1 Imported bottle of perfume at 27.99
- 1 Bottle of perfume at 18.99
- 1 Packet of paracetamol at 9.75
- 1 Box of imported chocolates at 11.25

**Output 3:**
- 1 imported bottle of perfume: 32.19
- 1 bottle of perfume: 20.89
- 1 packet of headache pills: 9.75
- 1 imported box of chocolates: 11.85
- Sales Taxes: 6.70
- Total: 74.68
