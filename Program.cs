using System.Diagnostics;
//Q1 פתרון רגיל שאלה מספר
static void MainQ1()
{
    Console.WriteLine("Enter 3 numbers");
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
Console.WriteLine($"The smallest is {Smallest(2, 3, 2)}");
int n, m, k;
(n, m, k) = (1, 4, 5);
//השוואה בין פתרון 1 ל-2
Debug.Assert(Smallest(n, m, k) == Smallest2(n, m, k));
(n, m, k) = (1, 1, 2);
Debug.Assert(Smallest(n, m, k) == Smallest2(n, m, k));
(n, m, k) = (1, -1, -1);
Debug.Assert(Smallest(n, m, k) == Smallest2(n, m, k));
(n, m, k) = (3, 1, 6); //בדיקת הפתרון השלישי
Debug.Assert(Smallest(n, m, k) == Smallest3(new[] { n, m, k }));





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
    Console.WriteLine("Enter number of shirts");
    int quantity = int.Parse(Console.ReadLine());

    if (quantity <= 5)
        Console.WriteLine(quantity * 20*0.95);
    else if (quantity <=10)
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
    int total = 0;
    for (int i = 0; i < 5; i++)
    //write 286 instead of 5 in the actual test
    {
        Console.WriteLine("Enter name, then number of repairs");
        string name = "Guy"; // קלוט מחרוזת Console.ReadLine();
        int numFixes = 26; // קלוט מספר שלם // int.Parse(Console.ReadLine());
        if (numFixes > 25)
            Console.WriteLine(name + " BONUS");
        total += numFixes;
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
Console.WriteLine("start Q2 tests");
//כאן יש שגיאה במכוון
D(T21(0), T21(3), "T21");
D(T22(5), T22(1), "T22");
D(T23(14), T23(0), "T23");
D(T24(1), T24(4), "T24");
D(T25(15), T25(-2), "T25");

Console.WriteLine("Test finished");


