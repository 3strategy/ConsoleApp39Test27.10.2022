using System.Diagnostics;
using System.Runtime.InteropServices;
//Q1 פתרון רגיל שאלה מספר
MainQ1(); // קריאה לפונקציה
static void MainQ1()
{
    Console.WriteLine("Here is the Minimal of 1,1,2:");
    int n1 = 1; //קלוט מספר שלם
    int n2 = 1; //קלוט מספר שלם
    int n3 = 2; //קלוט מספר שלם
    if (n1 < n2)
    {
        if (n1 < n3)
            Console.WriteLine(n1);
        Console.WriteLine(n3);
    }
    // by now we know n1 is no longer a candidate
    // the candidates remaining are n2, n3
    else if (n2 < n3)
        Console.WriteLine(n2);

    // The only remaining option is n3
    // note that this code will always PRINT some answer, 
    // even for 1,1,2
    else
        Console.WriteLine(n3);
}

//Q1 פתרון כפונקציה שאלה מספר Q1
static int Smallest(int n1, int n2, int n3)
{
    if (n1 < n2)
    {
        if (n1 < n3)
            return n1;
        return n3;
    }
    // by now we know n1 is no longer a candidate
    // the candidates remaining are n2, n3
    else if (n2 < n3)
        return n2;

    // The only remaining option is n3
    // note that this code will always return some answer, 
    // even for 1,1,2
    return n3;
}
//Q1 another alternative with a ternary (לא בחומר ולא יהיה בחומר)
//זה תרגום מדוייק לקוד שלעיל לתחביר שזהה בעצם לתנאי 
//excel כמו בגליון  if 
static int Smallest2(int n1, int n2, int n3) =>
    n1 < n2 ? n1 < n3 ? n1 : n3 : n2 < n3 ? n2 : n3;

static int Smallest3(int[] arr) //ideally take in (IEnumerable<int> arr)
{
    int min = int.MaxValue;
    foreach (var num in arr) // many times foreach makes it simpler...
        if (num < min)
            min = num;
    return min;
}

// Q1 testing the code by comparing the 2 alternatives:
//כאן, בבדיקת השוואת תוצאות בין שני פתרונות שונים 
// לא בחומר ולא יהיה בחומר Debug.Assert
// אבל בסה"כ אני טוען טענה שמשהו מתקיים
// ואם לא אז הקוד יעצור
Console.WriteLine($"\nThe smallest of 2, 3, 2 is: {Smallest(2, 3, 2)}");
int n1, n2, n3;
(n1, n2, n3) = (1, 4, 5);
//השוואה בין פתרון 1 ל-2
Debug.Assert(Smallest(n1, n2, n3) == Smallest2(n1, n2, n3));
(n1, n2, n3) = (1, 1, 2);
Debug.Assert(Smallest(n1, n2, n3) == Smallest2(n1, n2, n3));
(n1, n2, n3) = (1, -1, -1);
Debug.Assert(Smallest(n1, n2, n3) == Smallest2(n1, n2, n3));
(n1, n2, n3) = (3, 1, 6); //בדיקת הפתרון השלישי
Debug.Assert(Smallest(n1, n2, n3) == Smallest3(new[] { n1, n2, n3 }));





// Q2 קוד בדיקה לשאלה מספר 2 או שאלות מסוג דומה

static bool T21(double n) => n != 0; //הפונקציות מבצעות את התנאי ומחזירות אם אמת/שקר
static bool T22(double n) => n < 2 || n > 2;
static bool T23(double n) => n >= 0 && n <= 5;
static bool T24(double n) => n > 0 && n != 1;
static bool T25(double n) => n % 2 == 0 && n < 0;
static void D(bool bF, bool bT, string fName)
{
    Debug.Assert(!bF, fName + " False:    True instead of False");
    Debug.Assert(bT, fName + " True:   False instead of TRUE");
}
//Q3 פתרון רגיל לשאלת ההנחה
static void MainQ3()
{
    Console.WriteLine("\nEnter number of shirts\nso we can calculate the total price");
    int quantity = int.Parse(Console.ReadLine());

    if (quantity <= 5)
        Console.WriteLine(quantity * 20 * 0.95);
    else if (quantity <= 10)
        Console.WriteLine(quantity * 20 * 0.9);
    else
        Console.WriteLine(quantity * 20 * 0.8);
}

//Q3 שאלה מספר 3 כפונקציה: חישוב מחיר כולל 
static double TotalPrice(int quantity)
{
    double discountFactor; //this will be either 0.95, 0.9 or 0.8
    if (quantity > 10)
        discountFactor = 0.8; // זה הפקטור שגורם להקטנת מספר ב-20%
    else if (quantity > 5)
        discountFactor = 0.9; // זה הפקטור המקטין ב-10%
    else
        discountFactor = 0.95; // כך נראה מקדם דעיכה של 5%

    // פונקציה שמחזירה ערך חייבת תמיד להחזיר ערך
    return 20 * quantity * discountFactor;
}

// Q3 או בשורה אחת לא בחומר ולא יהיה בחומר
static double TotalPrice2(int qty) =>
    20 * qty * (qty > 10 ? 0.8 : qty > 5 ? 0.9 : 0.95);

//Qבדיקת משווה בין שני פתרונות  לשאלה 3
for (int i = 0; i < 40; i++)
    //if (TotalPrice(i) != TotalPrice2(i))
    //    Console.WriteLine(TotalPrice(i) +" "+ TotalPrice2(i));
    Debug.Assert(TotalPrice(i) == TotalPrice2(i));

// שאלה 4 
// היחידה שלא כדאי לכתוב כפונקציה
static void MainQ4()
{
    Console.WriteLine("\nThis is the repair count answer.\n" +
        "here all 5 technitians did 26 repairs\n" +
        "(input was bypassed)");
    int total = 0;
    for (int i = 0; i < 5; i++)
    //write 286 instead of 5 in the actual test
    {
        Console.WriteLine("Enter name, then number of repairs");
        string name = "Guy"; // קלוט מחרוזת Console.ReadLine();
        int numFixes = 26; // קלוט מספר שלם // int.Parse(Console.ReadLine());
        if (numFixes > 25)
            Console.WriteLine(name + " BONUS");
        total += numFixes; // סכימת התיקונים היומיים
    }
    Console.WriteLine($"Total number of repairs today was {total}");
}
// בדיקת שאלה 3 - קריאה לפונקציה
MainQ3();
// בדיקת שאלה 4 - קריאה לפונקציה
MainQ4();


//insert the numbers to the funtions 
//exactly in the order they appear
//in the answers table
Console.WriteLine("\nstart Q2 tests");

D(T21(0), T21(3), "T21");
D(T22(2), T22(1), "T22");
D(T23(14), T23(0), "T23");
D(T24(1), T24(4), "T24");
D(T25(15), T25(-2), "T25");

Console.WriteLine("Test Q2 finished\n");


// פתרון חילופי במערכים עם תמיכה במקרי קצה
// בחומר לסמסטר ב
Console.WriteLine("\n\n\nAlternative - advanced");
//using nullable types:
double? minPos1 = null, maxNeg1 = null;
foreach (var num in new[] { 8, -2, 0, -6.5, 15, 0, 7, 9.88, -50, 30 })
{
    // מסתמך על כך שעדיין אין ערך במשתנה
    // כדי לקחת את המספר החיובי הראשון
    if (num > 0 && (minPos1 is null || num < minPos1))
        minPos1 = num;
    else if (num < 0 && (maxNeg1 is null || num > maxNeg1))
        maxNeg1 = num;
}
if (minPos1 != null)
    Console.WriteLine("Min positive is " + minPos1);
if (maxNeg1 != null)
    Console.WriteLine("Max negative is " + maxNeg1);


//========================= מטלה 10 דגשים
//===========  שאלה 2 =========
//פתחו ויישמו אלגוריתם המקבל כקלט 10 מספרים. האלגוריתם יציג כפלט את:
//א.המספר החיובי הקטן ביותר.
//ב. המספר השלילי הגדול ביותר.
//לדוגמא:
//8, -2, 0, -6.5, 15,0 ,7, 9.88, -50, 30  : 	עבור הסדרה
//הפלט שיתקבל: המספר החיובי הקטן ביותר הוא 7
//			   -המספר השלילי הגדול ביותר הוא 2 
Console.WriteLine("This is Assignment 10 Q2:\n" +
    "Code will print minimal Positive and Maximal negative\n" +
    "assuming there are both positives and negatives");
double maxNeg = double.MinValue;
double minPos = double.MaxValue;
for (int i = 0; i < 3; i++) //need to go to 10 in real solution
{
  // הערה: ההנחה היא שיש חיוביים ושליליים בקלט 
  // אחרת יודפס מספר שגוי
  // דרכים להתמודד עם מקרי קצה כאלו יוצגו בעתיד
  Console.WriteLine("enter a number");
  double n = double.Parse(Console.ReadLine());
  if (n > 0 && n < minPos)
    minPos = n;
  else if (n < 0 && n > maxNeg)
    maxNeg = n;
}
Console.WriteLine($"Min positive is {minPos}\nMax negative is {maxNeg}");

//=========================
//====  שאלה 5
Console.WriteLine("\nThis code will check number of descending");
Console.WriteLine("Number of decending is:\n"+NumberOfDescending());
Console.WriteLine("Number of decending is:\n" + NumberOfDescending());

static int NumberOfDescending()
{
  int previous = int.MinValue;
  int currentNum = previous; //setting that will not bias count
  int counter = 0;
  while (true)
  {
    Console.WriteLine("Enter a whole number. 0 to exit");
    previous = currentNum; // KEEP HISTORY!!!
    currentNum = int.Parse(Console.ReadLine());
    if (currentNum ==0)
      break;
    if (currentNum < previous)
      counter++;
  }
  return counter;
}

//================================
//==========   שאלה 6

Console.WriteLine("\n this code will take a number -123 \n" +
    "and add a digit if missing");
//- א) כתיבה כפונקציה
// ב) טיפול במספר 0
// ג) טיפול במספרים שליליים
Console.WriteLine(AddDigitIfMissing158Q34(-123, 3));
static int AddDigitIfMissing158Q34(int num, int dig)
{
    int numToReturn = num;
    int sign = Math.Sign(numToReturn);
    if (num == 0)
        return dig; // או שאנו מחזירים 0 או שהוספנו את הספרה
    while (num != 0)
    {
        if (num % 10 == dig * sign)
            return numToReturn;
        else Console.WriteLine(num % 10);
        num /= 10;
    }
    return numToReturn * 10 + dig * sign;
}
