using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HighQuantity
{
    #region FirstChapter 基本语言要素

    //class Program
    //{
    //    //static void Main(string[] args)
    //    //{
    //    //    //Ip ip = "192.168.0.96";
    //    //    //Console.WriteLine(ip.ToString());
    //    //    FirstType firstType = new FirstType() { Name = "First Type" };
    //    //    SecondType secondType = (SecondType)firstType;//转型成功
    //    //    //secondType = firstType as SecondType;//编译期转型失败，编译不通过
    //    //}
    //    //class Ip : IConvertible
    //    //{
    //    //    IPAddress value;
    //    //    public Ip(string ip)
    //    //    {
    //    //        value = IPAddress.Parse(ip);
    //    //    }

    //    //    public TypeCode GetTypeCode()
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public bool ToBoolean(IFormatProvider provider)
    //    //    {
    //    //        throw new InvalidCastException("Ip-to-Boolean conversion is not supported.");
    //    //    }

    //    //    public byte ToByte(IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public char ToChar(IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public DateTime ToDateTime(IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public decimal ToDecimal(IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public double ToDouble(IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public short ToInt16(IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public int ToInt32(IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public long ToInt64(IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public sbyte ToSByte(IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public float ToSingle(IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public string ToString(IFormatProvider provider)
    //    //    {
    //    //        return value.ToString();
    //    //    }

    //    //    public object ToType(Type conversionType, IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public ushort ToUInt16(IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public uint ToUInt32(IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public ulong ToUInt64(IFormatProvider provider)
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    public static implicit operator Ip(string ip)
    //    //    {
    //    //        Ip iptemp = new Ip(ip);
    //    //        return iptemp;
    //    //    }
    //    //    //public override string ToString()
    //    //    //{
    //    //    //    return value.ToString();
    //    //    //}
    //    //}

    //    //class FirstType
    //    //{
    //    //    public string Name { get; set; }
    //    //}
    //    //class SecondType
    //    //{
    //    //    public string Name { get; set; }
    //    //    public static explicit operator SecondType(FirstType firstType)
    //    //    {
    //    //        SecondType secondType = new SecondType() { Name = "转型自：" + firstType.Name };
    //    //        return secondType;
    //    //    }
    //    //    static void DoWithSomeType(object obj)
    //    //    {
    //    //        //SecondType secondType = (SecondType)obj;
    //    //        SecondType secondType = obj as SecondType;
    //    //        if(secondType != null)
    //    //        {

    //    //        }
    //    //    }
    //    //}
    //    //static void Main(string[] args)
    //    //{
    //    //    double re;
    //    //    long ticks;
    //    //    Stopwatch sw = Stopwatch.StartNew();
    //    //    for (int i = 0; i < 1000; i++)
    //    //    {
    //    //        try
    //    //        {
    //    //            re = double.Parse("123");
    //    //        }
    //    //        catch
    //    //        {
    //    //            re = 0;
    //    //        }
    //    //    }
    //    //    sw.Stop();
    //    //    ticks = sw.ElapsedTicks;
    //    //    Console.WriteLine("double.Parse()成功，{0}ticks", ticks);
    //    //    sw = Stopwatch.StartNew();
    //    //    for (int i = 0; i < 1000; i++)
    //    //    {
    //    //        if(double.TryParse("123",out re) == false)
    //    //        {
    //    //            re = 0;
    //    //        }
    //    //    }
    //    //    sw.Stop();
    //    //    ticks = sw.ElapsedTicks;
    //    //    Console.WriteLine("double.TryParse()成功，{0}ticks", ticks);
    //    //    sw = Stopwatch.StartNew();
    //    //    for (int i = 0; i < 1000; i++)
    //    //    {
    //    //        try
    //    //        {
    //    //            re = double.Parse("aaa");
    //    //        }
    //    //        catch
    //    //        {
    //    //            re = 0;
    //    //        }
    //    //    }
    //    //    sw.Stop();
    //    //    ticks = sw.ElapsedTicks;
    //    //    Console.WriteLine("double.Parse()失败，{0}ticks", ticks);
    //    //    sw = Stopwatch.StartNew();
    //    //    for (int i = 0; i < 1000; i++)
    //    //    {
    //    //        if(double.TryParse("aaa",out re) == false)
    //    //        {
    //    //            re = 0;
    //    //        }
    //    //    }
    //    //    sw.Stop();
    //    //    ticks = sw.ElapsedTicks;
    //    //    Console.WriteLine("double.TryParse()失败，{0}ticks", ticks);
    //    //}
    //    //static void Main(string[] args)
    //    //{
    //    //    Sample sample = new Sample(200);
    //    //    //sample.ReadOnlyValue = 300;//无法对只读的字段赋值(构造函数或变量初始值指定项中除外)
    //    //    Sample2 sample2 = new Sample2(new Student() { Age = 10 });
    //    //    //sample2.ReadOnlyValue = new Student() { Age = 20 };//无法对只读的字段赋值(构造函数或变量初始值指定项中除外)
    //    //    sample2.ReadOnlyValue.Age = 20;
    //    //}
    //    //class Sample
    //    //{
    //    //    public readonly int ReadOnlyValue;
    //    //    public Sample(int value)
    //    //    {
    //    //        ReadOnlyValue = value;
    //    //    }
    //    //}
    //    //class Sample2
    //    //{
    //    //    public readonly Student ReadOnlyValue;
    //    //    public Sample2(Student value)
    //    //    {
    //    //        ReadOnlyValue = value;
    //    //    }
    //    //}

    //    //static Week week;
    //    //static void Main(string[] args)
    //    //{
    //    //    Console.WriteLine(week);
    //    //}
    //    static void Main(string[] args)
    //    {
    //        //ArrayList companySalary = new ArrayList();
    //        //companySalary.Add(new Salary() { Name = "Mike", BaseSalary = 3000, Bonus = 1000 });
    //        //companySalary.Add(new Salary() { Name = "Rose", BaseSalary = 2000, Bonus = 4000 });
    //        //companySalary.Add(new Salary() { Name = "Jeffry", BaseSalary = 1000, Bonus = 6000 });
    //        //companySalary.Add(new Salary() { Name = "Steve", BaseSalary = 4000, Bonus = 3000 });
    //        ////companySalary.Sort();
    //        ////foreach (Salary item in companySalary)
    //        ////{
    //        ////    Console.WriteLine(item.Name + "\t BaseSalary:" + item.BaseSalary.ToString());
    //        ////}
    //        //companySalary.Sort(new BonusComparer());
    //        //foreach (Salary item in companySalary)
    //        //{
    //        //    Console.WriteLine(string.Format("Name:{0}\tBaseSalary:{1}\tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
    //        //}
    //        List<Salary> companySalary = new List<Salary>()
    //        {
    //            new Salary() { Name = "Mike", BaseSalary = 3000, Bonus = 1000 },
    //            new Salary() { Name = "Rose", BaseSalary = 2000, Bonus = 4000 },
    //            new Salary() { Name = "Jeffry", BaseSalary = 1000, Bonus = 6000 },
    //            new Salary() { Name = "Steve", BaseSalary = 4000, Bonus = 3000 }
    //        };
    //        companySalary.Sort(new BonusComparer());
    //        foreach (Salary item in companySalary)
    //        {
    //            Console.WriteLine(string.Format("Name:{0}\tBaseSalary:{1}\tBonus:{2}"), item.Name, item.BaseSalary, item.Bonus);
    //        }
    //    }
    //}

    ////public class Student
    ////{
    ////    public int Age { get; set; }
    ////}
    ////enum Week
    ////{
    ////    Monday,
    ////    Tuesday,
    ////    Wednesday,
    ////    Thursday,
    ////    Friday,
    ////    Saturday,
    ////    Sunday
    ////}

    ////class Salary
    ////{
    ////    public int RMB { get; set; }
    ////    public static Salary operator + (Salary s1,Salary s2)
    ////    {
    ////        s2.RMB += s1.RMB;
    ////        return s2;
    ////    }
    ////}
    ////class Salary : IComparable
    ////{
    ////    public string Name { get; set; }
    ////    public int BaseSalary { get; set; }
    ////    public int Bonus { get; set; }
    ////    #region IComparable成员
    ////    public int CompareTo(object obj)
    ////    {
    ////        Salary staff = obj as Salary;
    ////        if (BaseSalary > staff.BaseSalary)
    ////        {
    ////            return 1;
    ////        }
    ////        else if (BaseSalary == staff.BaseSalary)
    ////        {
    ////            return 0;
    ////        }
    ////        else
    ////        {
    ////            return -1;
    ////        }
    ////        //return BaseSalary.CompareTo(staff.BaseSalary);
    ////    }
    ////    #endregion
    ////}
    ////public class BonusComparer : IComparer
    ////{
    ////    public int Compare(object x, object y)
    ////    {
    ////        Salary s1 = x as Salary;
    ////        Salary s2 = y as Salary;
    ////        return s1.Bonus.CompareTo(s2.Bonus);
    ////    }
    ////}
    //class Salary : IComparable<Salary>
    //{
    //    public string Name { get; set; }
    //    public int BaseSalary { get; set; }
    //    public int Bonus { get; set; }
    //    public int CompareTo(Salary other)
    //    {
    //        return BaseSalary.CompareTo(other.BaseSalary);
    //    }
    //}
    //class BonusComparer : IComparer<Salary>
    //{
    //    public int Compare(Salary x, Salary y)
    //    {
    //        return x.Bonus.CompareTo(y.Bonus);
    //    }
    //}

    #region 11、12
    //class Program
    //{
    //    static Dictionary<Person, PersonMoreInfo> PersonValues = new Dictionary<Person, PersonMoreInfo>();
    //    static void Main(string[] args)
    //    {
    //        //object a = new Person("NB123");
    //        //object b = new Person("NB123");
    //        //Console.WriteLine(a == b);
    //        //Console.WriteLine(a.Equals(b));
    //        AddAPerson();
    //        Person mike = new Person("NB123");
    //        Console.WriteLine(mike.GetHashCode());
    //        Console.WriteLine(PersonValues.ContainsKey(mike));
    //    }
    //    static void AddAPerson()
    //    {
    //        Person mike = new Person("NB123");
    //        PersonMoreInfo mikeValue = new PersonMoreInfo() { SomeInfo = "Mike's info" };
    //        PersonValues.Add(mike,mikeValue);
    //        Console.WriteLine(mike.GetHashCode());
    //        Console.WriteLine(PersonValues.ContainsKey(mike));
    //    }
    //}
    //class Person : IEquatable<Person>
    //{
    //    public string IDCode { get; private set; }
    //    public Person(string idCode)
    //    {
    //        this.IDCode = idCode;
    //    }
    //    public override bool Equals(object obj)
    //    {
    //        return IDCode == (obj as Person).IDCode;
    //    }
    //    public override int GetHashCode()
    //    {
    //        //return this.IDCode.GetHashCode();
    //        return (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "#" + this.IDCode).GetHashCode();
    //    }

    //    public bool Equals(Person other)
    //    {
    //        return IDCode == other.IDCode;
    //    }
    //}
    //class PersonMoreInfo
    //{
    //    public string SomeInfo { get; set; }
    //}
    #endregion

    #region 13
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //Person person = new Person()
    //        //{
    //        //    FirstName = "Jessica",
    //        //    LastName = "Hu",
    //        //    IDCode = "NB123"
    //        //};
    //        //Console.WriteLine(person);
    //        //Console.WriteLine(person.ToString("Ch", null));
    //        //Console.WriteLine(person.ToString("Eg", null));
    //        Person person = new Person()
    //        {
    //            FirstName = "Jessica",
    //            LastName = "Hu",
    //            IDCode = "NB123"
    //        };
    //        Console.WriteLine(person.ToString());
    //        PersonFormatter pFormatter = new PersonFormatter();
    //        Console.WriteLine(pFormatter.Format("Ch", person, null));
    //        Console.WriteLine(pFormatter.Format("Eg", person, null));
    //        Console.WriteLine(pFormatter.Format("ChM", person, null));
    //        Console.WriteLine(person.ToString("Ch", pFormatter));
    //        Console.WriteLine(person.ToString("Eg", pFormatter));
    //        Console.WriteLine(person.ToString("ChM", pFormatter));

    //    }
    //}
    //class Person : IFormattable
    //{
    //    public string IDCode { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string ToString(string format, IFormatProvider formatProvider)
    //    {
    //        switch (format)
    //        {
    //            case "Ch":
    //                return this.ToString();
    //            case "Eg":
    //                return string.Format("{0}{1}", FirstName, LastName);
    //            default:
    //                ICustomFormatter customFormatter = formatProvider as ICustomFormatter;
    //                if(customFormatter == null)
    //                {
    //                    return string.Empty;
    //                }
    //                return customFormatter.Format(format, this, null);
    //        }
    //    }
    //    public override string ToString()
    //    {
    //        return string.Format("{0}{1}", LastName, FirstName);
    //    }
    //}
    ////class Person
    ////{
    ////    public string IDCode { get; set; }
    ////    public string FirstName { get; set; }
    ////    public string LastName { get; set; }
    ////}
    //class PersonFormatter : IFormatProvider, ICustomFormatter
    //{
    //    public string Format(string format, object arg, IFormatProvider formatProvider)
    //    {
    //        Person person = arg as Person;
    //        if(person == null)
    //        {
    //            return string.Empty;
    //        }
    //        switch (format)
    //        {
    //            case "Ch":
    //                return string.Format("{0}{1}", person.LastName, person.FirstName);
    //            case "Eg":
    //                return string.Format("{0}{1}", person.FirstName, person.LastName);
    //            case "ChM":
    //                return string.Format("{0}{1}:{2}", person.LastName, person.FirstName, person.IDCode);
    //            default:
    //                return string.Format("{0}{1}", person.FirstName, person.LastName);
    //        }
    //    }

    //    public object GetFormat(Type formatType)
    //    {
    //        if(formatType == typeof(ICustomFormatter))
    //        {
    //            return this;
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //}
    #endregion

    #region 14
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Employee mike = new Employee()
    //        {
    //            IDCode = "NB123",
    //            Age = 30,
    //            Department = new Department()
    //            {
    //                Name = "Dep1"
    //            }
    //        };
    //        Employee rose = mike.Clone() as Employee;
    //        Console.WriteLine(rose.IDCode);
    //        Console.WriteLine(rose.Age);
    //        Console.WriteLine(rose.Department);
    //        Console.WriteLine("开始改变mike的值：");
    //        mike.IDCode = "NB456";
    //        mike.Age = 60;
    //        mike.Department.Name = "Dep2";
    //        Console.WriteLine(rose.IDCode);
    //        Console.WriteLine(rose.Age);
    //        Console.WriteLine(rose.Department);
    //    }
    //}
    //[Serializable]
    //class Employee : ICloneable
    //{
    //    public string IDCode { get; set; }
    //    public int Age { get; set; }
    //    public Department Department { get; set; }
    //    public object Clone()
    //    {
    //        return this.MemberwiseClone();
    //    }
    //    public Employee DeepClone()
    //    {
    //        using (Stream objectStream = new MemoryStream())
    //        {
    //            IFormatter formatter = new BinaryFormatter();
    //            formatter.Serialize(objectStream, this);
    //            objectStream.Seek(0, SeekOrigin.Begin);
    //            return formatter.Deserialize(objectStream) as Employee;
    //        }
    //    }
    //    public Employee ShallowClone()
    //    {
    //        return this.Clone() as Employee;
    //    }
    //}
    //[Serializable]
    //class Department
    //{
    //    public string Name { get; set; }
    //    public override string ToString()
    //    {
    //        return this.Name;
    //    }
    //}
    #endregion

    #region 15
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //DynamicSample dynamicSample = new DynamicSample();
    //        //var addMethod = typeof(DynamicSample).GetMethod("Add");
    //        //int re = (int)addMethod.Invoke(dynamicSample, new object[] { 1, 2 });
    //        //dynamic dynamicSample2 = new DynamicSample();
    //        //int re2 = dynamicSample2.Add(1, 2);
    //        int times = 1000000;
    //        DynamicSample reflectSample = new DynamicSample();
    //        var addMethod = typeof(DynamicSample).GetMethod("Add");
    //        Stopwatch watch1 = Stopwatch.StartNew();
    //        for (int i = 0; i < times; i++)
    //        {
    //            addMethod.Invoke(reflectSample, new object[] { 1, 2 });
    //        }
    //        Console.WriteLine(string.Format("反射耗时：{0}毫秒", watch1.ElapsedMilliseconds));
    //        dynamic dynamicSample = new DynamicSample();
    //        Stopwatch watch2 = Stopwatch.StartNew();
    //        for (int i = 0; i < times; i++)
    //        {
    //            dynamicSample.Add(1, 2);
    //        }
    //        Console.WriteLine(string.Format("dynamic耗时：{0}毫秒", watch2.ElapsedMilliseconds));
    //        DynamicSample reflectSampleBetter = new DynamicSample();
    //        var addMethod2 = typeof(DynamicSample).GetMethod("Add");
    //        var delg = (Func<DynamicSample, int, int, int>)Delegate.CreateDelegate(typeof(Func<DynamicSample, int, int, int>), addMethod2);
    //        Stopwatch watch3 = Stopwatch.StartNew();
    //        for (int i = 0; i < times; i++)
    //        {
    //            delg(reflectSampleBetter, 1, 2);
    //        }
    //        Console.WriteLine(string.Format("优化的反射耗时：{0}毫秒", watch3.ElapsedMilliseconds));
    //    }
    //}
    //public class DynamicSample
    //{
    //    public string Name { get; set; }
    //    public int Add(int a,int b)
    //    {
    //        return a + b;
    //    }
    //}
    #endregion
    #endregion

    #region SecondChapter 集合和LINQ

    #region 16 元素数量可变的情况下不应使用数组
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //int[] iArr = { 0, 1, 2, 3, 4, 5, 6 };
    //        //ArrayList arrayList = ArrayList.Adapter(iArr);//将数组转变为ArrayList
    //        //arrayList.Add(7);
    //        //List<int> listInt = iArr.ToList<int>();//将数组转变为List<T>
    //        //listInt.Add(7);
    //        //int[] iArr = { 0, 1, 2, 3, 4, 5, 6 };
    //        //iArr = (int[])iArr.ReSize(10);
    //        ResizeArray();
    //        ResizeList();
    //    }
    //    private static void ResizeArray()
    //    {
    //        int[] iArr = { 0, 1, 2, 3, 4, 5, 6 };
    //        Stopwatch watch = new Stopwatch();
    //        watch.Start();
    //        iArr = (int[])iArr.ReSize(10);
    //        watch.Stop();
    //        Console.WriteLine("ResizeArray:" + watch.Elapsed);
    //    }
    //    private static void ResizeList()
    //    {
    //        List<int> iArr = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6 });
    //        Stopwatch watch = new Stopwatch();
    //        watch.Start();
    //        iArr.Add(0);
    //        iArr.Add(0);
    //        iArr.Add(0);
    //        watch.Stop();
    //        Console.WriteLine("ResizeList:" + watch.Elapsed);
    //    }
    //}
    //public static class ClassForExtensions
    //{
    //    public static Array ReSize(this Array array,int newSize)
    //    {
    //        Type t = array.GetType().GetElementType();
    //        Array newArray = Array.CreateInstance(t, newSize);
    //        Array.Copy(array, 0, newArray, 0, Math.Min(array.Length, newSize));
    //        return newArray;
    //    }
    //}
    #endregion

    #region 17 多数情况下使用foreach进行循环遍历
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        IMyEnumerable list = new MyList();
    //        IMyEnumerator enumerator = list.GetEnumerator();
    //        for (int i = 0; i < list.Count; i++)
    //        {
    //            object current = enumerator.Current;
    //            enumerator.MoveNext();
    //        }
    //        while (enumerator.MoveNext())
    //        {
    //            object current = enumerator.Current;
    //        }
    //        foreach (var current in list)
    //        {

    //        }
    //    }
    //}
    //interface IMyEnumerator
    //{
    //    bool MoveNext();
    //    object Current { get; }
    //}
    //interface IMyEnumerable
    //{
    //    IMyEnumerator GetEnumerator();
    //    int Count { get; }
    //}
    //class MyList : IMyEnumerable
    //{
    //    object[] items = new object[10];
    //    IMyEnumerator myEnumerator;
    //    public object this[int i]
    //    {
    //        get { return items[i]; }
    //        set { this.items[i] = value; }
    //    }

    //    public int Count => items.Length;

    //    public IMyEnumerator GetEnumerator()
    //    {
    //        if (myEnumerator == null)
    //        {
    //            myEnumerator = new MyEnumerator(this);
    //        }
    //        return myEnumerator;
    //    }
    //}
    //class MyEnumerator : IMyEnumerator
    //{
    //    int index = 0;
    //    MyList myList;

    //    public MyEnumerator(MyList myList)
    //    {
    //        this.myList = myList;
    //    }

    //    public object Current => myList[index - 1];

    //    public bool MoveNext()
    //    {
    //        if (index + 1 > myList.Count)
    //        {
    //            index = 1;
    //            return false;
    //        }
    //        else
    //        {
    //            index++;
    //            return true;
    //        }
    //    }
    //}
    #endregion

    #region 18 foreach不能替代for
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        List<int> list = new List<int>() { 0, 1, 2, 3 };
    //        //foreach (int item in list)
    //        //{
    //        //    list.Remove(item);
    //        //    Console.WriteLine(item.ToString());
    //        //}
    //        for (int i = 0; i < list.Count; i++)
    //        {
    //            list.Remove(list[i]);
    //            Console.WriteLine(list[i].ToString());
    //        }
    //    }
    //}
    #endregion

    #region 19 使用更有效的对象和集合初始化
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Person person = new Person() { Name = "Mike", Age = 20 };
    //        List<Person> personList = new List<Person>()
    //        {
    //            new Person(){Name = "Rose",Age = 19},
    //            person,
    //            null
    //        };
    //        List<Person> personList2 = new List<Person>()
    //        {
    //            new Person(){Name = "Rose",Age = 19},
    //            new Person(){Name = "Steve",Age = 45},
    //            new Person(){Name = "Jessica",Age = 20}
    //        };
    //        var pTemp = from p in personList2
    //                    select new
    //                    {
    //                        p.Name,
    //                        AgeScope = p.Age > 20 ? "Old" : "Young"
    //                    };
    //        foreach (var item in pTemp)
    //        {
    //            Console.WriteLine(string.Format("{0}:{1}", item.Name, item.AgeScope));
    //        }
    //    }
    //}
    //class Person
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}
    #endregion

    #region 20 使用泛型集合代替非泛型集合
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //不好的写法
    //        //ArrayList al = new ArrayList();
    //        //al.Add(0);
    //        //al.Add(1);
    //        //al.Add("mike");
    //        //foreach (var item in al)
    //        //{
    //        //    Console.WriteLine(item);
    //        //}
    //        //List<int> intList = new List<int>();
    //        //intList.Add(1);
    //        //intList.Add(2);
    //        ////intList.Add("mike");
    //        //foreach (var item in intList)
    //        //{
    //        //    Console.WriteLine(item.ToString());
    //        //}
    //        Console.WriteLine("开始测试ArrayList");
    //        TestBegin();
    //        TestArrayList();
    //        TestEnd();
    //        Console.WriteLine("开始测试List<T>");
    //        TestBegin();
    //        TestGenericList();
    //        TestEnd();
    //    }
    //    static int collectionCount = 0;
    //    static Stopwatch watch = null;
    //    static int testCount = 10000000;
    //    static void TestBegin()
    //    {
    //        GC.Collect();
    //        GC.WaitForPendingFinalizers();
    //        GC.Collect();
    //        collectionCount = GC.CollectionCount(0);
    //        watch = new Stopwatch();
    //        watch.Start();
    //    }
    //    static void TestEnd()
    //    {
    //        watch.Stop();
    //        Console.WriteLine("耗时：" + watch.ElapsedMilliseconds.ToString());
    //        Console.WriteLine("垃圾回收次数：" + (GC.CollectionCount(0) - collectionCount));
    //    }
    //    static void TestArrayList()
    //    {
    //        ArrayList al = new ArrayList();
    //        int temp = 0;
    //        for (int i = 0; i < testCount; i++)
    //        {
    //            al.Add(i);
    //            temp = (int)al[i];
    //        }
    //        al = null;
    //    }
    //    static void TestGenericList()
    //    {
    //        List<int> listT = new List<int>();
    //        int temp = 0;
    //        for (int i = 0; i < testCount; i++)
    //        {
    //            listT.Add(i);
    //            temp = listT[i];
    //        }
    //        listT = null;
    //    }
    //}
    #endregion

    #region 21 选择正确的集合
    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //    }
    //}
    #endregion

    #region 22 确保集合的线程安全
    //class Program
    //{
    //    static List<Person> list = new List<Person>()
    //    {
    //        new Person(){Name = "Rose", Age = 19},
    //        new Person(){Name = "Steve", Age = 45},
    //        new Person(){Name = "Jessica", Age = 20}
    //    };
    //    //static ArrayList list = new ArrayList()
    //    //{
    //    //    new Person(){Name = "Rose", Age = 19},
    //    //    new Person(){Name = "Steve", Age = 45},
    //    //    new Person(){Name = "Jessica", Age = 20}
    //    //};
    //    static object sysObj = new object();
    //    static AutoResetEvent autoSet = new AutoResetEvent(false);
    //    static void Main(string[] args)
    //    {
    //        Thread t1 = new Thread(() =>
    //        {
    //            autoSet.WaitOne();
    //            //lock (list.SyncRoot)
    //            lock (sysObj)
    //            {
    //                foreach (Person item in list)
    //                {
    //                    Console.WriteLine("t1:" + item.Name);
    //                    Thread.Sleep(1000);
    //                }
    //            }
    //        });
    //        t1.Start();
    //        Thread t2 = new Thread(() =>
    //        {
    //            autoSet.Set();
    //            Thread.Sleep(1000);
    //            //lock (list.SyncRoot)
    //            lock (sysObj)
    //            {
    //                list.RemoveAt(2);
    //            }
    //        });
    //        t2.Start();
    //    }
    //}
    //class Person
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}
    #endregion

    #region 23 避免将List<T>作为自定义集合类的基类
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //Employees1 employees1 = new Employees1()
    //        //{
    //        //    new Employees(){Name = "Mike"},
    //        //    new Employees(){Name = "Rose"}
    //        //};
    //        //IList<Employees> employees = employees1;
    //        //employees.Add(new Employees() { Name = "Steve" });
    //        //foreach (var item in employees1)
    //        //{
    //        //    Console.WriteLine(item.Name);
    //        //}
    //        Employees2 employees2 = new Employees2()
    //        {
    //            new Employees(){Name = "Mike"},
    //            new Employees(){Name = "Rose"}
    //        };
    //        ICollection<Employees> employees = employees2;
    //        employees.Add(new Employees() { Name = "Steve" });
    //        foreach (var item in employees2)
    //        {
    //            Console.WriteLine(item.Name);
    //        }
    //    }
    //}
    //class Employees
    //{
    //    public string Name { get; set; }
    //}
    //class Employees1 : List<Employees>
    //{
    //    public new void Add(Employees item)
    //    {
    //        item.Name += "Changed!";
    //        base.Add(item);
    //    }
    //}
    //class Employees2 : IEnumerable<Employees>, ICollection<Employees>
    //{
    //    private List<Employees> items = new List<Employees>();
    //    public int Count => throw new NotImplementedException();

    //    public bool IsReadOnly => throw new NotImplementedException();

    //    public void Add(Employees item)
    //    {
    //        item.Name += "Changed!";
    //        this.items.Add(item);
    //    }

    //    public void Clear()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Contains(Employees item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void CopyTo(Employees[] array, int arrayIndex)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerator<Employees> GetEnumerator() => this.items.GetEnumerator();

    //    public bool Remove(Employees item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    #endregion

    #region 24 迭代器应该是只读的
    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //    }
    //}
    #endregion

    #region 25 谨慎集合属性的可写操作
    //class Program
    //{
    //    static List<Student> list1 = new List<Student>()
    //    {
    //        new Student(){Name = "Mike", Age = 1},
    //        new Student(){Name = "Rose", Age = 2}
    //    };
    //    static void Main(string[] args)
    //    {
    //        //StudentTeamA teamA = new StudentTeamA();
    //        //Thread t1 = new Thread(() =>
    //        //{
    //        //    teamA.Students = list1;
    //        //    Thread.Sleep(3000);
    //        //    Console.WriteLine(list1.Count);
    //        //});
    //        //t1.Start();
    //        //Thread t2 = new Thread(() =>
    //        //{
    //        //    list1 = null;
    //        //});
    //        //t2.Start();
    //        StudentTeamA teamA2 = new StudentTeamA();
    //        teamA2.Students.Add(new Student() { Name = "Steve", Age = 3 });
    //        teamA2.Students.AddRange(list1);
    //        Console.WriteLine(teamA2.Students.Count);

    //        StudentTeamA teamA3 = new StudentTeamA(list1);
    //        Console.WriteLine(teamA3.Students.Count);
    //    }
    //}
    //class Student
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}
    //internal class StudentTeamA
    //{
    //    public List<Student> Students { get; private set; }
    //    public StudentTeamA()
    //    {
    //        Students = new List<Student>();
    //    }
    //    public StudentTeamA(IEnumerable<Student> studentList) : this()
    //    {
    //        Students.AddRange(studentList);
    //    }
    //}
    #endregion

    #region 26 使用匿名类型存储LINQ查询结果 27 在查询中使用Lambda表达式
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        List<Company> companyList = new List<Company>()
    //        {
    //            new Company(){CompanyID = 0,Name = "Micro"},
    //            new Company(){CompanyID = 1,Name = "Sun"}
    //        };
    //        List<Person> personList = new List<Person>()
    //        {
    //            new Person(){Name = "Mike",CompanyID = 1},
    //            new Person(){Name = "Rose",CompanyID = 0},
    //            new Person(){Name = "Steve",CompanyID = 1}
    //        };
    //        var personWithCompanyList = from person in personList
    //                                    join company in companyList on person.CompanyID equals company.CompanyID
    //                                    select new { PersonName = person.Name, CompanyName = company.Name };
    //        foreach (var item in personWithCompanyList)
    //        {
    //            Console.WriteLine(string.Format("{0}\t:{1}", item.PersonName, item.CompanyName));
    //        }
    //        foreach (var item in personList.Select(person => new { PersonName = person.Name, CompanyName = person.CompanyID == 0 ? "Micro" : "Sun" }))
    //        {
    //            Console.WriteLine(string.Format("{0}\t:{1}", item.PersonName, item.CompanyName));
    //        }
    //    }
    //}
    //class Person
    //{
    //    public string Name { get; set; }
    //    public int CompanyID { get; set; }
    //}
    //class Company
    //{
    //    public int CompanyID { get; set; }
    //    public string Name { get; set; }
    //}
    #endregion

    #region 28 理解延迟求值和主动求值之间的区别
    //class Program
    //{
    //    static void Mian(string[] args)
    //    {
    //        List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    //        var temp1 = from c in list where c > 5 select c;
    //        var temp2 = (from c in list where c > 5 select c).ToList<int>();
    //        list[0] = 11;
    //        Console.Write("temp1:");
    //        foreach (var item in temp1)
    //        {
    //            Console.Write(item.ToString() + " ");
    //        }
    //        Console.Write("\ntemp2:");
    //        foreach (var item in temp2)
    //        {
    //            Console.Write(item.ToString() + " ");
    //        }
    //    }
    //}
    #endregion

    #region 29 区别LINQ查询中的IEnumerable<T>和IQueryable<T>
    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //    }
    //}
    #endregion

    #region 30 使用LINQ取代集合中的比较器和迭代器
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        List<Salary> companySalary = new List<Salary>()
    //        {
    //            new Salary(){Name = "Mike", BaseSalary = 3000, Bonus = 1000},
    //            new Salary(){Name = "Rose", BaseSalary = 2000, Bonus = 4000},
    //            new Salary(){Name = "Jeffry", BaseSalary = 1000, Bonus = 6000},
    //            new Salary(){Name = "Steve", BaseSalary = 4000, Bonus = 3000}
    //        };
    //        Console.WriteLine("默认排序：");
    //        foreach (Salary item in companySalary)
    //        {
    //            Console.WriteLine(string.Format("Name:{0}\tBaseSalary:{1}\tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
    //        }
    //        Console.WriteLine("BaseSalary排序：");
    //        var orderByBaseSalary = from s in companySalary orderby s.BaseSalary select s;
    //        foreach (Salary item in orderByBaseSalary)
    //        {
    //            Console.WriteLine(string.Format("Name:{0}\tBaseSalary:{1}\tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
    //        }
    //        Console.WriteLine("Bonus排序：");
    //        var orderByBonus = from s in companySalary orderby s.Bonus select s;
    //        foreach (Salary item in orderByBonus)
    //        {
    //            Console.WriteLine(string.Format("Name:{0}\tBaseSalary:{1}\tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
    //        }
    //    }
    //}
    //class Salary
    //{
    //    public string Name { get; set; }
    //    public int BaseSalary { get; set; }
    //    public int Bonus { get; set; }
    //}
    #endregion

    #region 31 在LINQ查询中避免不必要的迭代
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        MyList list = new MyList();
    //        //var temp = (from c in list where c.Age == 20 select c).ToList();
    //        //Console.WriteLine(list.IteratedNum.ToString());
    //        //list.IteratedNum = 0;
    //        //var temp2 = (from c in list where c.Age >= 20 select c).First();
    //        //Console.WriteLine(list.IteratedNum.ToString());
    //        var temp = (from c in list select c).Take(2).ToList();
    //        Console.WriteLine(list.IteratedNum.ToString());
    //        list.IteratedNum = 0;
    //        var temp2 = (from c in list where c.Name == "Mike" select c).ToList();
    //        Console.WriteLine(list.IteratedNum.ToString());
    //    }
    //}
    //class MyList : IEnumerable<Person>
    //{
    //    List<Person> list = new List<Person>()
    //    {
    //        new Person(){ Name = "Mike", Age = 20 },
    //        new Person(){ Name = "Mike", Age = 30 },
    //        new Person(){ Name = "Rose", Age = 25 },
    //        new Person(){ Name = "Steve", Age = 30 },
    //        new Person(){ Name = "Jessica", Age = 20 }
    //    };
    //    public int IteratedNum { get; set; }
    //    public Person this[int i]
    //    {
    //        get { return list[i]; }
    //        set { this.list[i] = value; }
    //    }

    //    public IEnumerator<Person> GetEnumerator()
    //    {
    //        foreach (var item in list)
    //        {
    //            IteratedNum++;
    //            yield return item;
    //        }
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }
    //}

    //internal class Person
    //{
    //    public string Name { get; internal set; }
    //    public int Age { get; internal set; }
    //}
    #endregion

    #endregion

    #region ThirdChapter 泛型、委托和事件

    #region 32 总是优先考虑泛型
    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //    }
    //}
    //class MyList
    //{
    //    int[] items;
    //    public int this[int i]
    //    {
    //        get => items[i];
    //        set => this.items[i] = value;
    //    }
    //    public int Count => items.Length;
    //}
    //class MyList<T>
    //{
    //    T[] items;
    //    public T this[int i]
    //    {
    //        get => items[i];
    //        set => this.items[i] = value;
    //    }
    //    public int Count => items.Length;
    //}
    #endregion

    #region 33 避免在泛型类型中声明静态成员
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //MyList list1 = new MyList();
    //        //MyList list2 = new MyList();
    //        //Console.WriteLine(MyList.Count);
    //        //MyList<int> list1 = new MyList<int>();
    //        //MyList<int> list2 = new MyList<int>();
    //        //MyList<string> list3 = new MyList<string>();
    //        //Console.WriteLine(MyList<int>.Count);
    //        //Console.WriteLine(MyList<string>.Count);
    //        Console.WriteLine(MyList.Func<int>());
    //        Console.WriteLine(MyList.Func<int>());
    //        Console.WriteLine(MyList.Func<string>());
    //    }
    //}
    //class MyList
    //{
    //    public static int Count { get; set; }
    //    public static int Func<T>()
    //    {
    //        return Count++;
    //    }
    //    public MyList()
    //    {
    //        Count++;
    //    }
    //}
    //class MyList<T>
    //{
    //    public static int Count { get; set; }
    //    public MyList()
    //    {
    //        Count++;
    //    }
    //}
    #endregion

    #region 34 为泛型参数设定约定
    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //    }
    //}
    //class SalaryComputer
    //{
    //    public int Compare<T>(T t1, T t2) where T : Salary
    //    {
    //        if(t1.BaseSalary > t2.BaseSalary)
    //        {
    //            return 1;
    //        }
    //        else if(t1.BaseSalary == t2.BaseSalary)
    //        {
    //            return 0;
    //        }
    //        else
    //        {
    //            return -1;
    //        }
    //    }
    //}
    //class Salary
    //{
    //    public int BaseSalary { get; set; }
    //    public int Bonus { get; set; }
    //}
    #endregion

    #region 35 使用default为泛型类型变量指定初始值
    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //    }
    //    public T Func<T>()
    //    {
    //        T t = default(T);
    //        return t;
    //    }
    //}
    #endregion

    #region 36 使用FCL中的委托声明 37  使用Lambda表达式代替方法和匿名方法
    //class Program
    //{
    //    //delegate int AddHandler(int i, int j);
    //    //delegate void PrintHandler(string msg);
    //    static void Main(string[] args)
    //    {
    //        //AddHandler add = Add;
    //        //PrintHandler print = Print;
    //        //print(add(1, 2).ToString());

    //        //Func<int, int, int> add = Add;
    //        //Action<string> print = Print;
    //        //print(add(1, 2).ToString());

    //        //Func<int, int, int> add = new Func<int, int, int>(Add);
    //        //Action<string> print = new Action<string>(Print);
    //        //print(add(1, 2).ToString());

    //        //Func<int, int, int> add = new Func<int, int, int>(delegate (int i, int j)
    //        //{
    //        //    return i + j;
    //        //});
    //        //Action<string> print = new Action<string>(delegate (string msg)
    //        //{
    //        //    Console.WriteLine(msg);
    //        //});
    //        //print(add(1, 2).ToString());

    //        //Func<int, int, int> add = delegate (int i, int j)
    //        //  {
    //        //      return i + j;
    //        //  };
    //        //Action<string> print = delegate (string msg)
    //        //{
    //        //    Console.WriteLine(msg);
    //        //};
    //        //print(add(1, 2).ToString());

    //        Func<int, int, int> add = (i, j) =>
    //          {
    //              return i + j;
    //          };
    //        Action<string> print = (msg) =>
    //        {
    //            Console.WriteLine(msg);
    //        };
    //        print(add(1, 2).ToString());
    //    }
    //    private static int Add(int i, int j) => i + j;
    //    private static void Print(string msg) => Console.WriteLine(msg);
    //}
    #endregion

    #region 38 小心闭包中的陷阱
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //List<Action> lists = new List<Action>();
    //        //for (int i = 0; i < 5; i++)
    //        //{
    //        //    Action t = () =>
    //        //     {
    //        //         Console.WriteLine(i.ToString());
    //        //     };
    //        //    lists.Add(t);
    //        //}
    //        //foreach (Action t in lists)
    //        //{
    //        //    t();
    //        //}

    //        //List<Action> lists = new List<Action>();
    //        //TempClass tempClass = new TempClass();
    //        //for (tempClass.i = 0; tempClass.i < 5; tempClass.i++)
    //        //{
    //        //    Action t = tempClass.TempFuc;
    //        //    lists.Add(t);
    //        //}
    //        //foreach (Action t in lists)
    //        //{
    //        //    t();
    //        //}

    //        //List<Action> lists = new List<Action>();
    //        //for (int i = 0; i < 5; i++)
    //        //{
    //        //    int temp = i;
    //        //    Action t = () =>
    //        //    {
    //        //        Console.WriteLine(temp.ToString());
    //        //    };
    //        //    lists.Add(t);
    //        //}
    //        //foreach (Action t in lists)
    //        //{
    //        //    t();
    //        //}

    //        List<Action> lists = new List<Action>();
    //        for (int i = 0; i < 5; i++)
    //        {
    //            TempClass tempClass = new TempClass();
    //            tempClass.i = i;
    //            Action t = tempClass.TempFuc;
    //            lists.Add(t);
    //        }
    //        foreach (Action t in lists)
    //        {
    //            t();
    //        }
    //    }
    //}
    //class TempClass
    //{
    //    public int i;
    //    public void TempFuc()
    //    {
    //        Console.WriteLine(i.ToString());
    //    }
    //}
    #endregion

    #region 39 了解委托的实质 40 使用event关键字为委托施加保护 41 实现标准的事件模型
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //FileUploader fl = new FileUploader();
    //        //fl.FileUploaded += Progress;
    //        //fl.FileUploaded += ProgressAnother;
    //        //fl.Upload();
    //        FileUploader fl = new FileUploader();
    //        fl.FileUploaded += Progress;
    //        fl.Upload();
    //    }
    //    static void Progress(object sender, FileUploadEventArgs e)
    //    {
    //        Console.WriteLine(e.FileProgress);
    //    }
    //    static void Progress(int progress)
    //    {
    //        Console.WriteLine(progress);
    //    }
    //    static void ProgressAnother(int progress)
    //    {
    //        Console.WriteLine(string.Format("另一个通知方法：{0}", progress));
    //    }
    //}
    //class FileUploader
    //{
    //    //public delegate void FileUploaderHandler(int progress);
    //    //public event FileUploaderHandler FileUploaded;
    //    public event EventHandler<FileUploadEventArgs> FileUploaded;
    //    public void Upload()
    //    {
    //        //int fileProgress = 100;
    //        //while (fileProgress > 0)
    //        //{
    //        //    //传输代码,省略
    //        //    fileProgress--;
    //        //    if (FileUploaded != null)
    //        //    {
    //        //        FileUploaded(fileProgress);
    //        //    }
    //        //}
    //        FileUploadEventArgs e = new FileUploadEventArgs()
    //        {
    //            FileProgress = 100
    //        };
    //        while (e.FileProgress > 0)
    //        {
    //            //传输代码，省略
    //            e.FileProgress--;
    //            FileUploaded?.Invoke(this, e);
    //        }
    //    }
    //}
    //class FileUploadEventArgs : EventArgs
    //{
    //    public int FileProgress { get; set; }
    //}
    #endregion

    #region 42 使用泛型参数兼容泛型接口的不可变性 43 让接口中的泛型参数支持协变 44 理解委托中的协变
    //class Program
    //{
    //    //static void Main(string[] args)
    //    //{
    //    //    //ISalary<Programmer> s = new BaseSalaryCounter<Programmer>();
    //    //    //ISalary<Manager> t = new BaseSalaryCounter<Manager>();
    //    //    //PrintSalary(s);
    //    //    //PrintSalary(t);
    //    //    IList<Programmer> programmers = new List<Programmer>();
    //    //    IList<Manager> managers = new List<Manager>();
    //    //    PrintPersonName(programmers);
    //    //    PrintPersonName(managers);
    //    //}
    //    //static void PrintSalary(ISalary<Employee> s)
    //    //{
    //    //    s.Pay();
    //    //}
    //    //static void PrintPersonName(IEnumerable<Employee> persons)
    //    //{
    //    //    foreach (Employee person in persons)
    //    //    {
    //    //        Console.WriteLine(person.Name);
    //    //    }
    //    //}
    //    ////static void PrintSalary<T>(ISalary<T> s)
    //    ////{
    //    ////    s.Pay();
    //    ////}

    //    public delegate T GetEmployeeHanlder<T>(string name);
    //    static void Main()
    //    {
    //        GetEmployeeHanlder<Manager> getAManager = GetAManager;
    //        GetEmployeeHanlder<Employee> getAEmployee = GetAManager;
    //        Employee e = getAEmployee("Mike");
    //    }
    //    static Manager GetAManager(string name)
    //    {
    //        Console.WriteLine("我是经理：" + name);
    //        return new Manager() { Name = name };
    //    }
    //    static Employee GetAEmployee(string name)
    //    {
    //        Console.WriteLine("我是雇员：" + name);
    //        return new Employee() { Name = name };
    //    }
    //}
    //interface ISalary<out T>
    //{
    //    void Pay();
    //}
    //class BaseSalaryCounter<T> : ISalary<T>
    //{
    //    public void Pay()
    //    {
    //        Console.WriteLine("Pay base salary");
    //    }
    //}
    //class Employee
    //{
    //    public string Name { get; set; }
    //}
    //class Programmer : Employee
    //{
    //}
    //class Manager : Employee
    //{
    //}
    #endregion

    #region 45 为泛型类型参数指定逆变
    //class Program
    //{
    //    static void Main()
    //    {
    //        Programmer p = new Programmer() { Name = "Mike" };
    //        Manager m = new Manager() { Name = "Steve" };
    //        Test(p, m);
    //    }
    //    static void Test<T>(IMyComparable<T>t1, T t2)
    //    {
    //        //省略
    //    }
    //}
    //public interface IMyComparable<in T>
    //{
    //    int Compare(T other);
    //}
    //public class Employee : IMyComparable<Employee>
    //{
    //    public string Name { get; set; }
    //    public int Compare(Employee other)
    //    {
    //        return Name.CompareTo(other.Name);
    //    }
    //}
    //public class Programmer : Employee, IMyComparable<Programmer>
    //{
    //    public int Compare(Programmer other)
    //    {
    //        return Name.CompareTo(other.Name);
    //    }
    //}
    //public class Manager : Employee
    //{

    //}
    #endregion

    #endregion

    #region ForthChapter 资源管理和序列化

    #region 46 显式释放资源需继承接口IDisposable 47 即使提供了显式释放方法，也应该在终结器中提供隐式清理 48 Dispose方法应允许被多次调用
    #endregion
    #region 49 在Dispose模式中应提取一个受保护的虚方法 50 在Dispose模式中应区别对待托管资源和非托管资源
    #endregion
    #region 51 具有可释放字段的类型或拥有本机资源的类型应该是可释放的 52 及时释放资源 53 必要时应将不再使用的对象引用赋值为null
    //public class SampleClass : IDisposable
    //{
    //    //演示创建一个非托管资源
    //    private IntPtr nativeResource = Marshal.AllocHGlobal(100);
    //    //演示创建一个托管资源
    //    private AnotherResource managedResource = new AnotherResource();
    //    private bool disposed = false;
    //    /// <summary>
    //    /// 实现IDisposable中的Disposable方法
    //    /// </summary>
    //    public void Dispose()
    //    {
    //        //必须为true
    //        Dispose(true);
    //        //通知垃圾回收机制不再调用终结器(析构器)
    //        GC.SuppressFinalize(this);
    //    }
    //    /// <summary>
    //    /// 不是必要的，提供一个Close方法仅仅是为了更符合其他语言(如C++)的规范
    //    /// </summary>
    //    public void Close()
    //    {
    //        Dispose();
    //    }
    //    /// <summary>
    //    /// 必须的，防止程序员忘记了显式调用Dispose方法
    //    /// </summary>
    //    ~SampleClass()
    //    {
    //        //必须为false
    //        Dispose(false);
    //    }
    //    /// <summary>
    //    /// 非密封类修饰用protected virtual
    //    /// 密封类修饰用private
    //    /// </summary>
    //    /// <param name="disposing"></param>
    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (this.disposed)
    //        {
    //            return;
    //        }
    //        if (disposing)
    //        {
    //            //清理托管资源
    //            if (this.managedResource != null)
    //            {
    //                this.managedResource.Dispose();
    //                this.managedResource = null;
    //            }
    //        }
    //        if(this.nativeResource != IntPtr.Zero)
    //        {
    //            Marshal.FreeHGlobal(this.nativeResource);
    //            this.nativeResource = IntPtr.Zero;
    //        }
    //        //让类型知道自己已经被释放
    //        this.disposed = true;
    //    }
    //    public void SamplePublicMethod()
    //    {
    //        if (this.disposed)
    //        {
    //            throw new ObjectDisposedException("SampleClass", "SampleClass is disposed");
    //        }
    //        //省略
    //    }
    //}
    //public class DerivedSampleClass : SampleClass
    //{
    //    //子类的非托管资源
    //    private IntPtr derivedNativeResource = Marshal.AllocHGlobal(100);
    //    //子类的托管资源
    //    private AnotherResource derivedManagedResource = new AnotherResource();
    //    //定义自己的是否释放的标识变量
    //    private bool derivedDisposed = false;
    //    /// <summary>
    //    /// 非密封类修饰用protected virtual
    //    /// 密封类修饰用private
    //    /// </summary>
    //    /// <param name="disposing"></param>
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (this.derivedDisposed)
    //        {
    //            return;
    //        }
    //        if (disposing)
    //        {
    //            //清理托管资源
    //            if(this.derivedManagedResource != null)
    //            {
    //                this.derivedManagedResource.Dispose();
    //                this.derivedManagedResource = null;
    //            }
    //        }
    //        //清理非托管资源
    //        if(this.derivedNativeResource != IntPtr.Zero)
    //        {
    //            Marshal.FreeHGlobal(this.derivedNativeResource);
    //            this.derivedNativeResource = IntPtr.Zero;
    //        }
    //        //调用父类的清理代码
    //        base.Dispose(disposing);
    //        //让类型知道自己已经被释放
    //        this.derivedDisposed = true;
    //    }
    //}
    //internal class AnotherResource : IDisposable
    //{
    //    public void Dispose()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    //class AnotherSampleClass : IDisposable
    //{
    //    private AnotherResource managedResource = new AnotherResource();
    //    private bool disposed = false;
    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }
    //    ~AnotherSampleClass()
    //    {
    //        Dispose(false);
    //    }
    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (this.disposed)
    //        {
    //            return;
    //        }
    //        if (disposing)
    //        {
    //            //清理托管资源
    //            if(this.managedResource != null)
    //            {
    //                this.managedResource.Dispose();
    //                this.managedResource = null;
    //            }
    //        }
    //    }
    //    public void SamplePublicMethod()
    //    {
    //        if (this.disposed)
    //        {
    //            throw new ObjectDisposedException("AnotherSampleClass", "AnotherSampleClass is disposed");
    //        }
    //    }
    //    //省略
    //}
    #endregion

    #region 54 为无用字段标注不可序列化
    //class Program
    //{
    //    static void Main()
    //    {
    //        Person mike = new Person() { Age = 21, Name = "Mike" };
    //        mike.NameChanged += Mike_NameChanged;
    //        BinarySerializer.SerializeToFile(mike, @"d:\", "person.txt");
    //        Person p = BinarySerializer.DeserializeFromFile<Person>(@"d:\person.txt");
    //        p.Name = "Rose";
    //        Console.WriteLine(p.Name);
    //        Console.WriteLine(p.Age.ToString());
    //    }

    //    private static void Mike_NameChanged(object sender, EventArgs e)
    //    {
    //        Console.WriteLine("Name Changed");
    //    }
    //}
    //[Serializable]
    //class Person
    //{
    //    private string name;
    //    public string Name
    //    {
    //        get => name; set
    //        {
    //            NameChanged?.Invoke(this, null);
    //            name = value;
    //        }
    //    }
    //    public int Age { get; set; }

    //    [NonSerialized]
    //    private Department department;
    //    public Department Department { get => department; set => department = value; }
    //    [field: NonSerialized]
    //    public event EventHandler NameChanged;
    //}

    //internal class Department
    //{
    //}
    #endregion

    #region 55 利用定制特性减少可序列化的字段
    //class Program
    //{
    //    static void Main()
    //    {
    //        Person luminjin = new Person() { FirstName = "Minji", LastName = "Lu", ChineseName = "Lu Minji" };
    //        BinarySerializer.SerializeToFile(luminjin, @"d:\", "Person.txt");
    //        Person person = BinarySerializer.DeserializeFromFile<Person>(@"d:\Person.txt");
    //        Console.WriteLine(person.ChineseName);
    //    }
    //}
    //[Serializable]
    //class Person
    //{
    //    public string FirstName;
    //    public string LastName;
    //    [NonSerialized]
    //    public string ChineseName;
    //    [OnDeserialized]
    //    void OnSerialized(StreamingContext context)
    //    {
    //        ChineseName = string.Format("{0} {1}", LastName, FirstName);
    //    }
    //}
    #endregion

    #region 56 使用继承ISerializable接口更灵活地控制序列化过程
    //class Program
    //{
    //    static void Main()
    //    {
    //        Person luminjin = new Person() { FirstName = "Minji", LastName = "Lu" };
    //        BinarySerializer.SerializeToFile(luminjin, @"d:\", "Person.txt");
    //        PersonAnother p = BinarySerializer.DeserializeFromFile<PersonAnother>(@"d:\Person.txt");
    //        Console.WriteLine(p.Name);
    //    }
    //}
    //[Serializable]
    //public class PersonAnother : ISerializable
    //{
    //    public string Name { get; set; }
    //    protected PersonAnother(SerializationInfo info, StreamingContext context)
    //    {
    //        Name = info.GetString("Name");
    //    }

    //    public void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {

    //    }
    //}
    //[Serializable]
    //public class Person : ISerializable
    //{
    //    public string FirstName;
    //    public string LastName;
    //    public string ChineseName;
    //    public Person()
    //    {

    //    }

    //    protected Person(SerializationInfo info, StreamingContext context)
    //    {
    //        //FirstName = info.GetString("FirstName");
    //        //LastName = info.GetString("LastName");
    //        //ChineseName = string.Format("{0} {1}", FirstName, LastName);
    //    }

    //    public void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        //info.AddValue("FirstName", FirstName);
    //        //info.AddValue("LastName", LastName);
    //        info.SetType(typeof(PersonAnother));
    //        info.AddValue("Name", string.Format("{0} {1}", LastName, FirstName));
    //    }
    //}
    #endregion

    #region 57 实现ISerializable的子类型应负责弗雷的序列化
    //class Program
    //{
    //    static void Main()
    //    {
    //        Employee luminjin = new Employee() { Name = "luminji", Salary = 1000 };
    //        BinarySerializer.SerializeToFile(luminjin, @"d:\", "Person.txt");
    //        Employee luminjinCopy = BinarySerializer.DeserializeFromFile<Employee>(@"d:\Person.txt");
    //        Console.WriteLine(string.Format("姓名：{0}", luminjinCopy.Name));
    //        Console.WriteLine(string.Format("薪水：{0}", luminjinCopy.Salary));
    //    }
    //}
    ////public class Person
    ////{
    ////    public string Name { get; set; }
    ////}
    //[Serializable]
    //public class Person : ISerializable
    //{
    //    public string Name { get; set; }
    //    public Person()
    //    {

    //    }
    //    protected Person(SerializationInfo info, StreamingContext context)
    //    {
    //        Name = info.GetString("Name");
    //    }

    //    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        info.AddValue("Name", Name);
    //    }
    //}
    //[Serializable]
    //public class Employee : Person, ISerializable
    //{
    //    public int Salary { get; set; }
    //    public Employee()
    //    {

    //    }

    //    protected Employee(SerializationInfo info, StreamingContext context) : base(info, context)
    //    {
    //        //Name = info.GetString("Name");
    //        Salary = info.GetInt32("Salary");
    //    }

    //    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        //info.AddValue("Name", Name);
    //        base.GetObjectData(info, context);
    //        info.AddValue("Salary", Salary);
    //    }
    //}
    #endregion

    #endregion

    #region FifthChapter 异常与异常定义

    #region 58 用异常抛出代替返回错误代码 59 不要在不恰当的场合下引发异常 60 重新引发异常时使用InnerException
    //class Program
    //{
    //    static void Main()
    //    {
    //        try
    //        {
    //            User user = new User();
    //            SaveUser(user);
    //        }
    //        catch (IOException)
    //        {
    //            //IO异常，通知当前用户
    //        }
    //        catch (UnauthorizedAccessException)
    //        {
    //            //权限失败，通知客户端管理员
    //        }
    //        catch (CommunicationException)
    //        {
    //            //网络异常，通知发送E-mail给网络管理员
    //        }
    //    }

    //    private static void SaveUser(User user)
    //    {
    //        SaveToFile(user);
    //        SaveToDataBase(user);
    //    }

    //    private static int SaveUser1(User user)
    //    {
    //        if (!SaveToFile(user))
    //        {
    //            return 1;
    //        }
    //        if (!SaveToDataBase(user))
    //        {
    //            return 2;
    //        }
    //        return 0;
    //    }

    //    private static bool SaveUser2(User user, ref string errorMsg)
    //    {
    //        if (!SaveToFile(user))
    //        {
    //            errorMsg = "本地保存失败！";
    //            return false;
    //        }
    //        if (!SaveToDataBase(user))
    //        {
    //            errorMsg = "远程保存失败！";
    //            return false;
    //        }
    //        return true;
    //    }

    //    private void SaveUser3(User user)
    //    {
    //        //if(user.Age < 0)
    //        //{
    //        //    throw new ArgumentOutOfRangeException("Age不能为负数。");
    //        //}
    //        ////保存用户

    //        string msg = string.Empty;
    //        if(CheckAge(30,ref msg))
    //        {
    //            SaveUser4(user);
    //        }
    //    }

    //    private void SaveUser4(User user)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    private void Save(User user)
    //    {
    //        try
    //        {
    //            SaveUser5(user);
    //        }
    //        catch (SocketException err)
    //        {
    //            //throw new CommuncationFailureException("网络连接失败，请稍后再试", err);
    //            err.Data.Add("SocketInfo", "网络连接失败，请稍后再试");
    //            throw err;
    //        }
    //    }

    //    private void SaveUser5(User user)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    private bool CheckAge(int age,ref string msg)
    //    {
    //        if(age < 0)
    //        {
    //            msg = "Age不能为负数。";
    //            return false;
    //        }
    //        else if(age > 100)
    //        {
    //            msg = "Age不能>100。";
    //            return false;
    //        }
    //        return true;
    //    }

    //    private static bool SaveToDataBase(User user)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    private static bool SaveToFile(User user)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //[Serializable]
    //internal class CommuncationFailureException : Exception
    //{
    //    public CommuncationFailureException()
    //    {
    //    }

    //    public CommuncationFailureException(string message) : base(message)
    //    {
    //    }

    //    public CommuncationFailureException(string message, Exception innerException) : base(message, innerException)
    //    {
    //    }

    //    protected CommuncationFailureException(SerializationInfo info, StreamingContext context) : base(info, context)
    //    {
    //    }
    //}

    //internal class User
    //{
    //    public int Age { get; internal set; }
    //}


    //[Serializable]
    //internal class CommunicationException : Exception
    //{
    //    public CommunicationException()
    //    {
    //    }

    //    public CommunicationException(string message) : base(message)
    //    {
    //    }

    //    public CommunicationException(string message, Exception innerException) : base(message, innerException)
    //    {
    //    }

    //    protected CommunicationException(SerializationInfo info, StreamingContext context) : base(info, context)
    //    {
    //    }
    //}

    #endregion

    #region 61 避免在finally内撰写无效代码
    //class Program
    //{
    //    static void Main()
    //    {
    //        Console.WriteLine(TestUserReturnInTry2().Name);
    //    }

    //    private static int TestIntReturnBelowFinally()
    //    {
    //        int i;
    //        try
    //        {
    //            i = 1;
    //        }
    //        finally
    //        {
    //            i = 2;
    //            Console.WriteLine("\t将int结果改为2，finally执行完毕");
    //        }
    //        return i;
    //    }

    //    private static int TestIntReturnInTry()
    //    {
    //        int i;
    //        try
    //        {
    //            return i = 1;
    //        }
    //        finally
    //        {
    //            i = 2;
    //            Console.WriteLine("\t将结果改为2，finally执行完毕");
    //        }
    //    }

    //    private static User TestUserReturnInTry()
    //    {
    //        User user = new User() { Name = "Mike", BirthDay = new DateTime(2010, 1, 1) };
    //        try
    //        {
    //            return user;
    //        }
    //        finally
    //        {
    //            user.Name = "Rose";
    //            user.BirthDay = new DateTime(2010, 2, 2);
    //            Console.WriteLine("\t将user.Name改为Rose");
    //        }
    //    }

    //    private static User TestUserReturnInTry2()
    //    {
    //        User user = new User() { Name = "Mike", BirthDay = new DateTime(2010, 1, 1) };
    //        try
    //        {
    //            return user;
    //        }
    //        finally
    //        {
    //            user.Name = "Rose";
    //            user.BirthDay = new DateTime(2010, 2, 2);
    //            user = null;
    //            Console.WriteLine("\t将user置为null");
    //        }
    //    }
    //}

    //internal class User
    //{
    //    public string Name { get; internal set; }
    //    public DateTime BirthDay { get; internal set; }
    //}
    #endregion

    #region 62 避免嵌套异常 63 避免"吃掉"异常
    //public class NestedExceptionSample
    //{
    //    public void MethodWithTry()
    //    {
    //        try
    //        {
    //            new NestedExceptionSample2().MethodWithTry();
    //        }
    //        catch (Exception err)
    //        {
    //            throw err;
    //        }
    //    }
    //    public void MethodNoTry()
    //    {
    //        new NestedExceptionSample2().MethodNoTry();
    //    }
    //}
    //class NestedExceptionSample2
    //{
    //    internal void MethodWithTry()
    //    {
    //        try
    //        {
    //            Method1();
    //        }
    //        catch (Exception err)
    //        {
    //            throw err;
    //        }
    //    }
    //    internal void MethodNoTry()
    //    {
    //        Method1();
    //    }
    //    int Method1()
    //    {
    //        int i = 0;
    //        return 10 / i;
    //    }
    //}
    #endregion

    #region 64 为循环增加Tester-Doer模式，而不是将try-catch置于循环内
    //class Program
    //{
    //    static void Main()
    //    {
    //        Stopwatch watch = Stopwatch.StartNew();
    //        int x = 0;
    //        for (int i = 0; i < 10000; i++)
    //        {
    //            try
    //            {
    //                int j = i / x;
    //            }
    //            catch
    //            {

    //            }
    //        }
    //        Console.WriteLine(watch.ElapsedMilliseconds.ToString());
    //        watch = Stopwatch.StartNew();
    //        for (int i = 0; i < 10000; i++)
    //        {
    //            if (x == 0)
    //            {
    //                continue;
    //            }
    //            int j = i / x;
    //        }
    //        Console.WriteLine(watch.ElapsedMilliseconds.ToString());
    //    }
    //}
    #endregion

    #region 65 总是处理未捕获的异常
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
    //    }

    //    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    //    {
    //        Exception error = (Exception)e.ExceptionObject;
    //        Console.WriteLine("MyHandler caught:" + error.Message);
    //    }
    //}
    #endregion

    #region 66 正确捕获多线程中的异常
    //class Program
    //{
    //    static void Main()
    //    {
    //        Thread t1 = new Thread((ThreadStart)delegate
    //        {
    //            try
    //            {
    //                throw new Exception("多线程异常");
    //            }
    //            catch (Exception error)
    //            {
    //                Console.WriteLine("工作线程异常：" + error.Message + Environment.NewLine + error.StackTrace);
    //            }
    //        });
    //        t1.Start();
    //    }
    //}
    #endregion

    #region 67 慎用自定义异常
    #endregion

    #region 68 从System.Exception或其他常见的基本异常中派生异常

    //[Serializable]
    //public class MyException : Exception
    //{
    //    public MyException() { }
    //    public MyException(string message) : base(message) { }
    //    public MyException(string message, Exception inner) : base(message, inner) { }
    //    protected MyException(
    //      SerializationInfo info,
    //      StreamingContext context) : base(info, context) { }
    //}

    //[Serializable]
    //public class PaperEncryptException : Exception, ISerializable
    //{
    //    private readonly string _paperInfo;
    //    public PaperEncryptException() { }
    //    public PaperEncryptException(string message) : base(message) { }
    //    public PaperEncryptException(string message, Exception inner) : base(message, inner) { }
    //    public PaperEncryptException(string message, string paperInfo) : base(message)
    //    {
    //        _paperInfo = paperInfo;
    //    }
    //    public PaperEncryptException(string message, string paperInfo, Exception inner) : base(message, inner)
    //    {
    //        _paperInfo = paperInfo;
    //    }
    //    protected PaperEncryptException(
    //      SerializationInfo info,
    //      StreamingContext context) : base(info, context) { }
    //    public override string Message => base.Message + " " + _paperInfo;
    //    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        info.AddValue("Args", _paperInfo);
    //        base.GetObjectData(info, context);
    //    }
    //}
    #endregion

    #region 69 应使用finally避免资源泄露
    //class Program
    //{
    //    static void Main()
    //    {
    //        //Method1();
    //        Method3();
    //    }

    //    private static void Method3()
    //    {
    //        ClassShouldDisposeBase c = null;
    //        try
    //        {
    //            c = new ClassShouldDisposeBase("Method3");
    //            Method4();
    //        }
    //        catch
    //        {
    //            Console.WriteLine("在Method3中捕获了异常。");
    //        }
    //        finally
    //        {
    //            c.Dispose();
    //        }
    //    }

    //    private static void Method4()
    //    {
    //        ClassShouldDisposeBase c = null;
    //        try
    //        {
    //            c = new ClassShouldDisposeBase("Method4");
    //            throw new Exception();
    //        }
    //        catch
    //        {
    //            Console.WriteLine("在Method4中捕获了异常。");
    //            throw;
    //        }
    //        finally
    //        {
    //            c.Dispose();
    //        }
    //    }

    //    private static void Method1()
    //    {
    //        ClassShouldDisposeBase c = null;
    //        try
    //        {
    //            c = new ClassShouldDisposeBase("Method1");
    //            Method2();
    //        }
    //        finally
    //        {
    //            c.Dispose();
    //        }
    //    }

    //    static void Method2()
    //    {
    //        ClassShouldDisposeBase c = null;
    //        try
    //        {
    //            c = new ClassShouldDisposeBase("Method2");
    //        }
    //        finally
    //        {
    //            c.Dispose();
    //        }
    //    }
    //}
    //class ClassShouldDisposeBase : IDisposable
    //{
    //    string _methodName;

    //    public ClassShouldDisposeBase(string methodName)
    //    {
    //        _methodName = methodName;
    //    }

    //    #region IDisposable Support
    //    private bool disposedValue = false; // 要检测冗余调用
    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!disposedValue)
    //        {
    //            if (disposing)
    //            {
    //                // TODO: 释放托管状态(托管对象)。
    //            }

    //            // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
    //            // TODO: 将大型字段设置为 null。

    //            disposedValue = true;
    //        }
    //    }

    //    // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
    //    ~ClassShouldDisposeBase()
    //    {
    //        // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
    //        Dispose(false);
    //    }

    //    // 添加此代码以正确实现可处置模式。
    //    public void Dispose()
    //    {
    //        // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
    //        Dispose(true);
    //        // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
    //        GC.SuppressFinalize(this);
    //        Console.WriteLine("在方法：" + _methodName + "中被释放！");
    //    }
    //    #endregion

    //}
    #endregion

    #region 70 避免在调用栈较低的位置记录异常

    #endregion

    #endregion

    #region SixthChapter 异步、多线程、任务和并行

    #region 71 区分异步和多线程应用场景
    //计算密集型工作，采用多线程。
    //IO密集型工作，采用异步机制。
    //class Program
    //{
    //    private void ButtonGetPage_Click(object sender, EventArgs e)
    //    {
    //        Thread t = new Thread(() =>
    //        {
    //            var request = HttpWebRequest.Create("http://www.cnblogs.com/luminj");
    //            var response = request.GetResponse();
    //            var stream = response.GetResponseStream();
    //            using (StreamReader reader = new StreamReader(stream))
    //            {
    //                var content = reader.ReadLine();
    //                //textBoxPage.Text = content;
    //            }
    //        });
    //        t.Start();
    //    }
    //    private void ButtonGetPage_Click1(object sender,EventArgs e)
    //    {
    //        var request = HttpWebRequest.Create("http://www.sina.com.cn");
    //        request.BeginGetResponse(this.AsyncCallbacklmpl, request);
    //    }

    //    private void AsyncCallbacklmpl(IAsyncResult ar)
    //    {
    //        WebRequest request = ar.AsyncState as WebRequest;
    //        var response = request.EndGetResponse(ar);
    //        var stream = response.GetResponseStream();
    //        using (StreamReader reader = new StreamReader(stream))
    //        {
    //            var content = reader.ReadLine();
    //            //txtBoxPage.Text = content;
    //        }
    //    }
    //}
    #endregion

    #region 72 在线程同步中使用信号量

    #endregion

    #region 73 避免锁定不恰当的同步对象
    //class Program
    //{
    //    static void Main()
    //    {
    //        Program p = new Program();
    //        p.ButtonStartThreads_Click();
    //    }
    //    AutoResetEvent autoSet = new AutoResetEvent(false);
    //    List<string> tempList = new List<string>() { "init0", "init1", "init2" };
    //    //private void ButtonStartThreads_Click(object sender,EventArgs e)
    //    private void ButtonStartThreads_Click()
    //    {
    //        object syncObj = new object();
    //        Thread t1 = new Thread(() =>
    //        {
    //            //确保等待t2开始之后才运行下面的代码
    //            autoSet.WaitOne();
    //            lock (syncObj)
    //            {
    //                foreach (var item in tempList)
    //                {
    //                    Thread.Sleep(1000);
    //                }
    //            }
    //        })
    //        {
    //            IsBackground = true
    //        };
    //        t1.Start();
    //        Thread t2 = new Thread(() =>
    //        {
    //            //通知t1可以执行代码
    //            autoSet.Set();
    //            //沉睡1秒是为了确保删除操作在t1的迭代过程中
    //            Thread.Sleep(1000);
    //            lock (syncObj)
    //            {
    //                tempList.RemoveAt(1);
    //            }
    //        })
    //        {
    //            IsBackground = true
    //        };
    //        t2.Start();
    //    }
    //}
    #endregion

    #region 74 警惕线程的IsBackground
    //class Program
    //{
    //    static void Main()
    //    {
    //        Thread t = new Thread(() =>
    //        {
    //            Console.WriteLine("线程开始工作......");
    //            //省略工作代码
    //            Console.ReadKey();
    //            Console.WriteLine("线程结束");
    //        });
    //        //注意，默认就为false
    //        t.IsBackground = false;
    //        t.Start();
    //        Console.WriteLine("主线程结束");
    //    }
    //}
    #endregion

    #region 75 警惕线程不会立即启动
    //class Program
    //{
    //    static int id = 0;
    //    //static void Main()
    //    //{
    //    //    for (int i = 0; i < 10; i++, id++)
    //    //    {
    //    //        Thread t = new Thread(() =>
    //    //        {
    //    //            Console.WriteLine(string.Format("{0}:{1}", Thread.CurrentThread.Name, id));
    //    //        })
    //    //        {
    //    //            Name = string.Format("Thread{0}", i),
    //    //            IsBackground = true
    //    //        };
    //    //        t.Start();
    //    //    }
    //    //    Console.ReadLine();
    //    //}
    //    static void Main()
    //    {
    //        for (int i = 0; i < 10; i++,id++)
    //        {
    //            NewMethod1(i, id);
    //        }
    //        Console.ReadLine();
    //    }

    //    private static void NewMethod1(int i, int realTimeID)
    //    {
    //        Thread t = new Thread(() =>
    //        {
    //            Console.WriteLine(string.Format("{0}:{1}", Thread.CurrentThread.Name, realTimeID));
    //        })
    //        {
    //            Name = string.Format("Thread{0}", i),
    //            IsBackground = true
    //        };
    //        t.Start();
    //    }
    //}
    #endregion

    #region 76 警惕线程的优先级
    //class Program
    //{
    //    static void Main()
    //    {
    //        long t1Num = 0;
    //        long t2Num = 0;
    //        CancellationTokenSource cts = new CancellationTokenSource();
    //        Thread t1 = new Thread(() =>
    //        {
    //            while (true && !cts.Token.IsCancellationRequested)
    //            {
    //                t1Num++;
    //            }
    //        })
    //        {
    //            IsBackground = true,
    //            Priority = ThreadPriority.Highest
    //        };
    //        t1.Start();
    //        Thread t2 = new Thread(() =>
    //        {
    //            while (true && !cts.Token.IsCancellationRequested)
    //            {
    //                t2Num++;
    //            }
    //        })
    //        {
    //            IsBackground = true
    //        };
    //        t2.Start();
    //        Console.ReadLine();
    //        //停止线程
    //        cts.Cancel();
    //        Console.WriteLine("t1Num:" + t1Num.ToString());
    //        Console.WriteLine("t2Num:" + t2Num.ToString());
    //    }
    //}
    #endregion

    #region 77 正确停止线程
    //class Program
    //{
    //    static void Main()
    //    {
    //        CancellationTokenSource cts = new CancellationTokenSource();
    //        cts.Token.Register(() =>
    //        {
    //            Console.WriteLine("工作线程被终止了。");
    //        });
    //        Thread t = new Thread(() =>
    //        {
    //            while (true)
    //            {
    //                if (cts.Token.IsCancellationRequested)
    //                {
    //                    Console.WriteLine("线程被终止！");
    //                    break;
    //                }
    //                Console.WriteLine(DateTime.Now.ToString());
    //                Thread.Sleep(1000);
    //            }
    //        });
    //        t.Start();
    //        Console.ReadLine();
    //        cts.Cancel();
    //    }
    //}
    #endregion

    #region 78 应避免线程数量过多
    //class Program
    //{
    //    static void Main()
    //    {
    //        for (int i = 0; i < 200; i++)
    //        {
    //            Thread t = new Thread(() =>
    //            {
    //                int j = 1;
    //                while (true)
    //                {
    //                    j++;
    //                }
    //            })
    //            {
    //                IsBackground = true
    //            };
    //            t.Start();
    //        }
    //        Thread.Sleep(5000);
    //        Thread t201 = new Thread(() =>
    //        {
    //            while (true)
    //            {
    //                Console.WriteLine("T201正在执行");
    //            }
    //        });
    //        t201.Start();
    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #region 79 使用ThreadPool或BackgroundWorker取代Thread
    //class Program
    //{
    //    private BackgroundWorker worker;
    //    private void StartAsyncButton_Click(object sender, EventArgs e)
    //    {
    //        worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
    //        worker.ProgressChanged += new ProgressChangedEventHandler(Worker_ProgressChanged);
    //        worker.RunWorkerAsync();
    //    }

    //    private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    private void Worker_DoWork(object sender, DoWorkEventArgs e)
    //    {
    //        BackgroundWorker worker = sender as BackgroundWorker;
    //        for (int i = 0; i < 10; i++)
    //        {
    //            worker.ReportProgress(i);
    //            Thread.Sleep(100);
    //        }
    //    }
    //}
    #endregion

    #region 80 用Task代替ThreadPool
    //class Program
    //{
    //    //static void Main()
    //    //{
    //    //    Task t = new Task(() =>
    //    //    {
    //    //        Console.WriteLine("任务开始工作......");
    //    //        //模拟工作过程
    //    //        Thread.Sleep(5000);
    //    //    });
    //    //    t.Start();
    //    //    t.ContinueWith((task) =>
    //    //    {
    //    //        Console.WriteLine("任务完成,完成时候的状态为：");
    //    //        Console.WriteLine("IsCanceled={0}\tIsCompleted={1}\tIsFaulted={2}", task.IsCanceled, task.IsCompleted, task.IsFaulted);
    //    //    });
    //    //    Console.ReadKey();
    //    //}
    //    //static void Main()
    //    //{
    //    //    CancellationTokenSource cts = new CancellationTokenSource();
    //    //    Task<int> t = new Task<int>(() => AddCancelByThrow(cts.Token), cts.Token);
    //    //    t.Start();
    //    //    t.ContinueWith(TaskEndedByCatch);
    //    //    //等待按任意键取消任务
    //    //    Console.ReadKey();
    //    //    cts.Cancel();
    //    //    Console.ReadKey();
    //    //}
    //    static void Main()
    //    {
    //        CancellationTokenSource cts = new CancellationTokenSource();//等待按任意键取消任务
    //        TaskFactory taskFactory = new TaskFactory();
    //        Task[] tasks = new Task[]
    //        {
    //            taskFactory.StartNew(() => Add(cts.Token)),
    //            taskFactory.StartNew(() => Add(cts.Token)),
    //            taskFactory.StartNew(() => Add(cts.Token))
    //        };
    //        //CancellationToken.None提示TasksEnded不能被取消
    //        taskFactory.ContinueWhenAll(tasks,TaskEnded, CancellationToken.None);
    //        Console.ReadKey();
    //        cts.Cancel();
    //        Console.ReadKey();
    //    }

    //    private static void TaskEnded(Task[] tasks)
    //    {
    //        Console.WriteLine("所有任务已完成！");
    //    }

    //    private static void TaskEndedByCatch(Task<int> task)
    //    {
    //        Console.WriteLine("任务完成，完成时候的状态为：");
    //        Console.WriteLine("IsCanceled={0}\tIsCompleted={1}\tIsFaulted={2}", task.IsCanceled, task.IsCompleted, task.IsFaulted);
    //        try
    //        {
    //            Console.WriteLine("任务的返回值为：{0}", task.Result);
    //        }
    //        catch (AggregateException e)
    //        {
    //            e.Handle((err) => err is OperationCanceledException);
    //        }
    //    }

    //    private static int AddCancelByThrow(CancellationToken ct)
    //    {
    //        Console.WriteLine("任务开始......");
    //        int result = 0;
    //        while (true)
    //        {
    //            //ct.ThrowIfCancellationRequested();
    //            if (result == 5)
    //            {
    //                throw new Exception("error");
    //            }
    //            result++;
    //            Thread.Sleep(1000);
    //        }
    //        return result;
    //    }

    //    private static void TaskEnded(Task<int> task)
    //    {
    //        Console.WriteLine("任务完成，完成时候的状态为：");
    //        Console.WriteLine("IsCanceled={0}\tIsCompleted={1}\tIsFaulted={2}", task.IsCanceled, task.IsCompleted, task.IsFaulted);
    //        Console.WriteLine("任务的返回值为：{0}", task.Result);
    //    }

    //    private static int Add(CancellationToken ct)
    //    {
    //        Console.WriteLine("任务开始......");
    //        int result = 0;
    //        while (!ct.IsCancellationRequested)
    //        {
    //            result++;
    //            Thread.Sleep(1000);
    //        }
    //        return result;
    //    }
    //}
    #endregion

    #region 81 使用Parallel简化同步状态下Task的使用
    //class Program
    //{
    //    //static void Main()
    //    //{
    //    //    int[] nums = new int[] { 1, 2, 3, 4 };
    //    //    Parallel.For(0, nums.Length, (i) =>
    //    //      {
    //    //          Console.WriteLine("针对数组索引{0}对应的那个元素{1}的一些工作代码", i, nums[i]);
    //    //      });
    //    //    Console.ReadKey();
    //    //}
    //    //static void Main()
    //    //{
    //    //    List<int> nums = new List<int> { 1, 2, 3, 4 };
    //    //    Parallel.ForEach(nums, (item) =>
    //    //    {
    //    //        Console.WriteLine("针对集合元素{0}的一些工作代码......", item);
    //    //    });
    //    //    Console.ReadKey();
    //    //}
    //    static void Main()
    //    {
    //        Parallel.Invoke(() =>
    //        {
    //            Console.WriteLine("任务1......");
    //        },
    //        () =>
    //        {
    //            Console.WriteLine("任务2......");
    //        },
    //        () =>
    //        {
    //            Console.WriteLine("任务3......");
    //        });
    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #region 82 Paraller简化但不等同于Task默认行为
    //class Program
    //{
    //    //static void Main()
    //    //{
    //    //    Task t = new Task(() =>
    //    //    {
    //    //        while (true)
    //    //        {

    //    //        }
    //    //    });
    //    //    t.Start();
    //    //    Console.WriteLine("主线程即将结束");
    //    //    Console.ReadKey();
    //    //}
    //    static void Main()
    //    {
    //        //在这里也可以使用Invoke方法
    //        Parallel.For(0, 1, (i) =>
    //        {
    //            while (true)
    //            {

    //            }
    //        });
    //        Console.WriteLine("主线程即将结束");
    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #region 83 小心Parallel中的陷阱
    //class Program
    //{
    //    //static void Main()
    //    //{
    //    //    int[] nums = new int[] { 1, 2, 3, 4 };
    //    //    int total = 0;
    //    //    Parallel.For(0, nums.Length, () =>
    //    //    {
    //    //        return 1;
    //    //    }, (i, loopState, subtotal) =>
    //    //    {
    //    //        subtotal += nums[i];
    //    //        return subtotal;
    //    //    }, (x) => Interlocked.Add(ref total, x));
    //    //    Console.WriteLine("total={0}", total);
    //    //    Console.ReadKey();
    //    //}
    //    static void Main()
    //    {
    //        string[] stringArr = new string[] { "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh" };
    //        string result = string.Empty;
    //        Parallel.For(0, stringArr.Length, () => "-", (i, loopState, subResult) =>
    //           {
    //               return subResult += stringArr[i];
    //           }, (threadEndString) =>
    //           {
    //               result += threadEndString;
    //               Console.WriteLine("Inner：" + threadEndString);
    //           });
    //        Console.WriteLine(result);
    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #region 84 使用PLINQ
    //class Program
    //{
    //    static void Main()
    //    {
    //        List<int> intList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    //        var query = from p in intList select p;
    //        Console.WriteLine("以下是LINQ顺序输出：");
    //        foreach (int item in query)
    //        {
    //            Console.WriteLine(item.ToString());
    //        }
    //        Console.WriteLine("以下是PLINQ并行输出：");
    //        var queryParallel = from p in intList.AsParallel() select p;
    //        foreach (int item in queryParallel)
    //        {
    //            Console.WriteLine(item.ToString());
    //        }
    //    }
    //}
    #endregion

    #region 85 Task中的异常处理
    //class Program
    //{
    //    //static void Main()
    //    //{
    //    //    Task t = new Task(() =>
    //    //    {
    //    //        throw new Exception("任务并行编码中产生的未知异常");
    //    //    });
    //    //    t.Start();
    //    //    try
    //    //    {
    //    //        //若有Result，可求Result
    //    //        t.Wait();
    //    //    }
    //    //    catch(AggregateException ex)
    //    //    {
    //    //        foreach (var item in ex.InnerExceptions)
    //    //        {
    //    //            Console.WriteLine("异常类型：{0}{1}来自：{2}{3}异常内容：{4}", item.GetType(), Environment.NewLine, item.Source,
    //    //                Environment.NewLine, item.Message);
    //    //        }
    //    //    }
    //    //    Console.WriteLine("主线程马上结束");
    //    //    Console.ReadKey();
    //    //}
    //    //static void Main()
    //    //{
    //    //    Task t = new Task(() =>
    //    //    {
    //    //        throw new Exception("任务并行编码中产生的未知异常");
    //    //    });
    //    //    t.Start();
    //    //    Task tEnd = t.ContinueWith((task) =>
    //    //    {
    //    //        foreach (Exception item in task.Exception.InnerExceptions)
    //    //        {
    //    //            Console.WriteLine("异常类型：{0}{1}来自：{2}{3}异常内容：{4}", item.GetType(), Environment.NewLine, item.Source,
    //    //                Environment.NewLine, item.Message);
    //    //        }
    //    //    },TaskContinuationOptions.OnlyOnFaulted);
    //    //    Console.WriteLine("主线程马上结束");
    //    //    Console.ReadKey();
    //    //}
    //    //static void Main()
    //    //{
    //    //    Task t = new Task(() =>
    //    //    {
    //    //        throw new InvalidOperationException("任务并行编码中产生的未知异常");
    //    //    });
    //    //    t.Start();
    //    //    Task tEnd = t.ContinueWith((task) =>
    //    //    {
    //    //        throw task.Exception;
    //    //    }, TaskContinuationOptions.OnlyOnFaulted);
    //    //    try
    //    //    {
    //    //        tEnd.Wait();
    //    //    }
    //    //    catch (AggregateException ex)
    //    //    {
    //    //        foreach (var item in ex.InnerExceptions)
    //    //        {
    //    //            Console.WriteLine("异常类型：{0}{1}来自：{2}{3}异常内容：{4}", item.InnerException.GetType(), Environment.NewLine,
    //    //                item.InnerException.Source, Environment.NewLine, item.InnerException.Message);
    //    //        }
    //    //    }
    //    //    Console.WriteLine("主线程马上结束");
    //    //    Console.ReadKey();
    //    //}
    //    static event EventHandler<AggregateExceptionArgs> AggregateExceptionCatched;
    //    public class AggregateExceptionArgs : EventArgs
    //    {
    //        public AggregateException AggregateException { get; set; }
    //    }
    //    static void Main()
    //    {
    //        AggregateExceptionCatched += new EventHandler<AggregateExceptionArgs>(Program_AggregateExceptionCatched);
    //        Task t = new Task(() =>
    //        {
    //            try
    //            {
    //                throw new InvalidOperationException("任务并行编码中产生的未知异常");
    //            }
    //            catch (Exception ex)
    //            {
    //                AggregateExceptionArgs errArgs = new AggregateExceptionArgs()
    //                {
    //                    AggregateException = new AggregateException(ex)
    //                };
    //                AggregateExceptionCatched(null, errArgs);
    //            }
    //        });
    //        t.Start();
    //        Console.WriteLine("主线程马上结束");
    //        Console.ReadKey();
    //    }
    //    static void Program_AggregateExceptionCatched(object sender, AggregateExceptionArgs e)
    //    {
    //        foreach (var item in e.AggregateException.InnerExceptions)
    //        {
    //            Console.WriteLine("异常类型：{0}{1}来自：{2}{3}异常内容：{4}", item.GetType(), Environment.NewLine,
    //                item.Source, Environment.NewLine, item.Message);
    //        }
    //    }
    //}
    #endregion

    #region 86 Parallel中的异常处理
    //class Program
    //{
    //    static void Main()
    //    {
    //        try
    //        {
    //            var parallelExceptions = new ConcurrentQueue<Exception>();
    //            Parallel.For(0, 1, (i) =>
    //            {
    //                try
    //                {
    //                    throw new InvalidOperationException("并行任务中出现的异常");
    //                }
    //                catch (Exception ex)
    //                {
    //                    parallelExceptions.Enqueue(ex);
    //                }
    //                if (parallelExceptions.Count > 0)
    //                {
    //                    throw new AggregateException(parallelExceptions);
    //                }
    //            });
    //        }
    //        catch (AggregateException ex)
    //        {
    //            foreach (Exception item in ex.InnerExceptions)
    //            {
    //                Console.WriteLine("异常类型：{0}{1}来自：{2}{3}异常内容：{4}", item.InnerException.GetType(), Environment.NewLine,
    //                    item.InnerException.Source, Environment.NewLine, item.InnerException.Message);
    //            }
    //        }
    //        Console.WriteLine("主线程马上结束");
    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #region 87 区分WPF和WinForm中的线程模型

    #endregion

    #region 88 并行并不总是速度更快
    //class Program
    //{
    //    static void Main()
    //    {
    //        Stopwatch watch = new Stopwatch();
    //        watch.Start();
    //        DoInFor();
    //        watch.Stop();
    //        Console.WriteLine("同步耗时：{0}", watch.Elapsed);
    //        watch.Restart();
    //        DoInParallerFor();
    //        watch.Stop();
    //        Console.WriteLine("并行耗时：{0}", watch.Elapsed);
    //        Console.ReadKey();
    //    }

    //    static void DoSomething()
    //    {
    //        for (int i = 0; i < 10; i++)
    //        {
    //            i++;
    //        }
    //    }

    //    private static void DoInParallerFor()
    //    {
    //        for (int i = 0; i < 200; i++)
    //        {
    //            DoSomething();
    //        }
    //    }

    //    private static void DoInFor()
    //    {
    //        Parallel.For(0, 200, (i) =>
    //         {
    //             DoSomething();
    //         });
    //    }
    //}
    #endregion

    #region 89 在并行方法体中谨慎使用锁
    //class Program
    //{
    //    static void Main()
    //    {
    //        SampleCalss sample = new SampleCalss();
    //        object syncObj = new object();
    //        Parallel.For(0, 10000000, (i) =>
    //          {
    //              lock (syncObj)
    //              {
    //                  sample.SimpleAdd();
    //              }
    //          });
    //        Console.WriteLine(sample.SomeCount);
    //    }
    //}

    //internal class SampleCalss
    //{
    //    public long SomeCount { get; private set; }

    //    internal void SimpleAdd()
    //    {
    //        SomeCount++;
    //    }
    //}
    #endregion

    #endregion

    #region SeventhChapter 成员设计

    #region 90 不要为抽象类提供公开的构造方法
    //abstract class MyAbstractClass
    //{
    //    protected MyAbstractClass() { }
    //}
    #endregion

    #region 91 可见字段应该重构为属性
    //class Person
    //{
    //    public string Name { get; set; }
    //}
    #endregion

    #region 92 谨慎将数组或集合作为属性
    //class Program
    //{
    //    static void Main()
    //    {
    //        Company microsoft = new Company();
    //        microsoft.Employees[0].Name = "Luminji";
    //        foreach (var item in microsoft.Employees)
    //        {
    //            Console.WriteLine(item.Name);
    //        }
    //        Console.ReadKey();
    //    }
    //}

    //internal class Company
    //{
    //    public Company()
    //    {
    //        Employees = new List<Employee>()
    //        {
    //            new Employee(){Name = "Bill Gates"}
    //        };
    //    }
    //    public IList<Employee> Employees { get; private set; }
    //}
    //internal class Employee
    //{
    //    public string Name { get; internal set; }
    //}
    #endregion

    #region 93 构造方法应初始化主要属性和字段
    //class Company
    //{
    //    Employee specialA = new Employee() { Name = "Mike" };
    //    Employee specialB;
    //    public Employee CEO { get; set; }
    //    public Company()
    //    {
    //        CEO = new Employee() { Name = "Steve" };
    //        specialB = new Employee() { Name = "Rose" };
    //    }
    //}

    //internal class Employee
    //{
    //    public string Name { get; internal set; }
    //}
    #endregion

    #region 94 区别对待override和new
    //class Program
    //{
    //    static void Main()
    //    {
    //        //Shape s = new Circle();
    //        //s.MethodVirtual();
    //        //s.Method();
    //        //Circle circle = new Circle();
    //        //circle.MethodVirtual();
    //        //circle.Method();
    //        //Shape s = new Triangle();
    //        //s.MethodVirtual();
    //        //s.Method();
    //        //Triangle triangle = new Triangle();
    //        //triangle.MethodVirtual();
    //        //triangle.Method();
    //        //Shape s = new Diamond();
    //        //s.MethodVirtual();
    //        //s.Method();
    //        //Diamond diamond = new Diamond();
    //        //diamond.MethodVirtual();
    //        //diamond.Method();
    //        TestShape();
    //        TestDerive();
    //        TestDerive2();
    //    }

    //    private static void TestDerive2()
    //    {
    //        Console.WriteLine("TestDerive2\tStart");
    //        Circle circle = new Circle();
    //        PrintShape(circle);
    //        Rectangle rectangle = new Rectangle();
    //        PrintShape(rectangle);
    //        Triangle triangle = new Triangle();
    //        PrintShape(triangle);
    //        Diamond diamond = new Diamond();
    //        PrintShape(diamond);
    //        Console.WriteLine("TestDerive2\tEnd\n");
    //    }

    //    private static void PrintShape(Shape shape)
    //    {
    //        shape.MethodVirtual();
    //        shape.Method();
    //    }

    //    private static void TestDerive()
    //    {
    //        Console.WriteLine("TestDerive\tStart");
    //        Circle circle = new Circle();
    //        Rectangle rectangle = new Rectangle();
    //        Triangle triangle = new Triangle();
    //        Diamond diamond = new Diamond();
    //        circle.MethodVirtual();
    //        circle.Method();
    //        rectangle.MethodVirtual();
    //        rectangle.Method();
    //        triangle.MethodVirtual();
    //        triangle.Method();
    //        diamond.MethodVirtual();
    //        diamond.Method();
    //        Console.WriteLine("TestShape\tEnd\n");
    //    }

    //    private static void TestShape()
    //    {
    //        Console.WriteLine("TestShape\tStart");
    //        List<Shape> shapes = new List<Shape>
    //        {
    //            new Circle(),
    //            new Rectangle(),
    //            new Triangle(),
    //            new Diamond()
    //        };
    //        foreach (Shape s in shapes)
    //        {
    //            s.MethodVirtual();
    //            s.Method();
    //        }
    //        Console.WriteLine("TestShape\tEnd\n");
    //    }
    //}
    //public class Shape
    //{
    //    public virtual void MethodVirtual()
    //    {
    //        Console.WriteLine("base MethodVitual call");
    //    }
    //    public void Method()
    //    {
    //        Console.WriteLine("base Method call");
    //    }
    //}
    //class Circle : Shape
    //{
    //    public override void MethodVirtual()
    //    {
    //        Console.WriteLine("circle override MethodVirtual");
    //    }
    //}
    //class Rectangle : Shape
    //{

    //}
    //class Triangle : Shape
    //{
    //    public new void MethodVirtual()
    //    {
    //        Console.WriteLine("triangle new MethodVirtual");
    //    }
    //    public new void Method()
    //    {
    //        Console.WriteLine("triangle new Method");
    //    }
    //}
    //class Diamond : Shape
    //{
    //    public void MethodVirtual()
    //    {
    //        Console.WriteLine("Diamond default MethodVirtual");
    //    }
    //    public void Method()
    //    {
    //        Console.WriteLine("Diamond default Method");
    //    }
    //}
    #endregion

    #region 95 避免在构造方法中调用虚成员
    //class Program
    //{
    //    static void Main()
    //    {
    //        American american = new American();
    //        Console.ReadKey();
    //    }
    //}
    //class Person
    //{
    //    public Person()
    //    {
    //        InitSkin();
    //    }
    //    protected virtual void InitSkin()
    //    {
    //        //省略
    //    }
    //}
    //class American : Person
    //{
    //    Race race;
    //    public American() : base()
    //    {
    //        race = new Race() { Name = "White" };
    //    }
    //    protected override void InitSkin()
    //    {
    //        Console.WriteLine(race.Name);
    //    }
    //}

    //internal class Race
    //{
    //    public string Name { get; internal set; }
    //}
    #endregion

    #region 96 成员应优先考虑公开基类型或接口

    #endregion

    #region 97 优先考虑将基类型或接口作为参数传递

    #endregion

    #region 98 用params减少重复参数

    #endregion

    #region 99 重写时不应使用子类参数

    #endregion

    #region 100 静态方法和实例方法没有区别

    #endregion

    #region 101 使用扩展方法，向现有类型“添加”方法
    //class Program
    //{
    //    static void Main()
    //    {
    //        Student student = new Student();
    //        //Console.WriteLine(StudentConverter.GetSexString(student));
    //        Console.WriteLine(student.GetSexString());
    //    }
    //}
    //public static class StudentConverter
    //{
    //    public static string GetSexString(Student student) => student.GetSex() ? "男D" : "女?";
    //}

    //public class Student
    //{
    //    internal bool GetSex()
    //    {
    //        return false;
    //    }
    //}

    //public static class StudentExtension
    //{
    //    public static string GetSexString(this Student student) => student.GetSex() ? "男" : "女";
    //}
    #endregion

    #endregion

    #region EigthChapter 类型设计

    #region 102 区分接口和抽象类的应用场合
    //public abstract class Stream : MarshalByRefObject, IDisposable
    //{
    //    //其他省略
    //    public virtual int ReadByte()
    //    {
    //        byte[] buffer = new byte[1];
    //        if(this.Read(buffer,0,1) == 1)
    //        {
    //            return -1;
    //        }
    //        return buffer[0];
    //    }

    //    private int Read(byte[] buffer, int v1, int v2)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    //其他省略
    //    public void Dispose()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    #endregion

    #region 103 区分组合和继承的应用场所
    //abstract class Stream
    //{
    //    //省略
    //}
    //class FileStream : Stream
    //{
    //    //省略
    //}
    //class MemoryStream : Stream
    //{
    //    //省略
    //}
    //class Context
    //{
    //    //省略
    //}
    //class CultureInfo
    //{
    //    //省略
    //    public void OtherMethod()
    //    {

    //    }
    //}
    //class Thread
    //{
    //    private Context context;
    //    private CultureInfo cultureInfo;
    //    //省略
    //    public void OtherMethod()
    //    {
    //        cultureInfo.OtherMethod();
    //    }
    //}
    #endregion

    #region 104 用多态代替条件语句
    //class Program
    //{
    //    enum DriveCommand
    //    {
    //        Start,
    //        Stop,
    //        Pause,
    //        TurnLeft,
    //        TurnRight,
    //    }
    //    static void Main(string[] args)
    //    {
    //        //DriveCommand command = DriveCommand.Start;
    //        //Drive(command);
    //        //command = DriveCommand.Stop;
    //        //Drive(command);
    //        Commander commander = new StartCommander();
    //        Drive(commander);
    //        commander = new StopCommander();
    //        Drive(commander);
    //    }
    //    static void Drive(Commander commander)
    //    {
    //        commander.Execute();
    //    }
    //    //static void Drive(DriveCommand command)
    //    //{
    //    //    if(command == DriveCommand.Start)
    //    //    {
    //    //        //车辆启动
    //    //    }
    //    //    else if(command == DriveCommand.Stop)
    //    //    {
    //    //        //车辆停止
    //    //    }
    //    //}
    //    static void Drive(DriveCommand command)
    //    {
    //        switch (command)
    //        {
    //            case DriveCommand.Start:
    //                //车辆启动
    //                break;
    //            case DriveCommand.Stop:
    //                //车辆停止
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //}
    //abstract class Commander
    //{
    //    public abstract void Execute();
    //}
    //class StartCommander : Commander
    //{
    //    public override void Execute()
    //    {
    //        //启动
    //    }
    //}
    //class StopCommander : Commander
    //{
    //    public override void Execute()
    //    {
    //        //停止
    //    }
    //}
    #endregion

    #region 105 使用私有构造函数强化单例
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Singleton.Instance.SampleMethod();
    //    }
    //}
    //public sealed class Singleton
    //{
    //    static Singleton instance = null;
    //    static readonly object padlock = new object();
    //    //限制实例在外部被创建
    //    private Singleton()
    //    {

    //    }

    //    public static Singleton Instance
    //    {
    //        get
    //        {
    //            if(instance == null)
    //            {
    //                lock (padlock)
    //                {
    //                    if(instance == null)
    //                    {
    //                        instance = new Singleton();
    //                    }
    //                }
    //            }
    //            return instance;
    //        }
    //    }

    //    public void SampleMethod()
    //    {
    //        //省略
    //    }
    //}
    #endregion

    #region 106 为静态类添加静态构造函数
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        SampleClass.SampleMethod();
    //        Console.ReadKey();
    //    }
    //}
    //static class SampleClass
    //{
    //    static FileStream fileStream;
    //    static SampleClass()
    //    {
    //        try
    //        {
    //            fileStream = File.Open(@"c:\temp.txt", FileMode.Open);
    //        }
    //        catch (FileNotFoundException err)
    //        {
    //            Console.WriteLine(err.Message);
    //            //处理异常
    //        }
    //    }
    //    public static void SampleMethod()
    //    {

    //    }
    //}
    #endregion

    #region 107 区分静态类和单例

    #endregion

    #region 108 将类型标识为sealed

    #endregion

    #region 109 谨慎使用嵌套类
    //public class ArrayList : IList, ICollection, IEnumerable, ICloneable
    //{
    //    public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    //    public bool IsReadOnly => throw new NotImplementedException();

    //    public bool IsFixedSize => throw new NotImplementedException();

    //    public int Count => throw new NotImplementedException();

    //    public object SyncRoot => throw new NotImplementedException();

    //    public bool IsSynchronized => throw new NotImplementedException();

    //    public int Add(object value)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Clear()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public object Clone()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Contains(object value)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void CopyTo(Array array, int index)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerator GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int IndexOf(object value)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Insert(int index, object value)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Remove(object value)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void RemoveAt(int index)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    [Serializable]
    //    private sealed class ArrayListEnumeratorSimple : IEnumerable, ICloneable
    //    {
    //        public object Clone()
    //        {
    //            throw new NotImplementedException();
    //        }

    //        public IEnumerator GetEnumerator()
    //        {
    //            throw new NotImplementedException();
    //        }

    //        internal ArrayListEnumeratorSimple(ArrayList list)
    //        {

    //        }
    //    }
    //}
    #endregion

    #region 110 用类来代替enum
    //enum Week
    //{
    //    Monday,
    //    Tuesday,
    //    Wednesday,
    //    Thursday,
    //    Friday,
    //    Saturday,
    //    Sunday
    //}
    //class Week
    //{
    //    public static readonly Week Monday = new Week(0);
    //    public static readonly Week Tuesday = new Week(1);
    //    private int infoType;
    //    private Week(int infoType)
    //    {
    //        this.infoType = infoType;
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine(EnumHelper.GetDescription(Week.Monday));
    //    }
    //}
    //enum Week
    //{
    //    [EnumDescription("星期一")]
    //    Monday,
    //    [EnumDescription("星期二")]
    //    Tuesday
    //}
    //[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    //public sealed class EnumDescriptionAttribute : Attribute
    //{
    //    private string description;
    //    public string Description => description;
    //    public EnumDescriptionAttribute(string description) : base()
    //    {
    //        this.description = description;
    //    }
    //}
    //public static class EnumHelper
    //{
    //    public static string GetDescription(Enum value)
    //    {
    //        if (value == null)
    //        {
    //            throw new ArgumentNullException("value");
    //        }
    //        string description = value.ToString();
    //        FieldInfo fieldInfo = value.GetType().GetField(description);
    //        EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
    //        if (attributes != null && attributes.Length > 0)
    //        {
    //            description = attributes[0].Description;
    //        }
    //        return description;
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //    }
    //}

    //class Week
    //{
    //    public static readonly Week Monday = new Week(0);
    //    public static readonly Week Tuesday = new Week(1);
    //    private int infoType;
    //    private Week(int infoType)
    //    {
    //        this.infoType = infoType;
    //    }
    //    public override string ToString()
    //    {
    //        switch (infoType)
    //        {
    //            case 0:
    //                return "星期一";
    //            case 1:
    //                return "星期二";
    //            default:
    //                throw new Exception("不正确的星期信息！");
    //        }
    //    }
    //}
    #endregion

    #region 111 避免双向耦合

    #endregion

    #region 112 将现实世界中的对象抽象为类，将可复用对象圈起来就是命名空间

    #endregion

    #endregion

    #region NinthChapter 安全性设计

    #region 113 声明变量前考虑最大值
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        ushort salary = 65534;
    //        checked
    //        {
    //            salary = (ushort)(salary + 1);
    //            Console.WriteLine(string.Format("第一次加薪，工资总数：{0}", salary));
    //            salary = (ushort)(salary + 1);
    //            Console.WriteLine(string.Format("第二次加薪，工资总数：{0}", salary));
    //        }
    //    }
    //}
    #endregion

    #region 114 MD5不再安全
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //string source = "luminji's key";
    //        //string hash = GetMd5Hash(source);
    //        //Console.WriteLine("保存密码原文：{0}的MD5值：{1}到数据库", source, hash);
    //        //Console.WriteLine("请输入密码，按回车键结束......");
    //        //string source = Console.ReadLine();
    //        //if (VerifyMd5Hash(source, "D3A8E4D76A0AEF23B65D9F6D6BCB358F"))
    //        //{
    //        //    Console.WriteLine("密码正确，准许登录系统。");
    //        //}
    //        //else
    //        //{
    //        //    Console.WriteLine("密码有误，拒绝登录。");
    //        //}
    //        Console.WriteLine("开始穷举法破解用户密码......");
    //        string key = string.Empty;
    //        Stopwatch watch = new Stopwatch();
    //        watch.Start();
    //        for (int i = 0; i < 9999; i++)
    //        {
    //            if (VerifyMd5Hash(i.ToString(), "CF79AE6ADDBA60AD018347359BD144D2"))
    //            {
    //                key = i.ToString();
    //                break;
    //            }
    //        }
    //        watch.Stop();
    //        Console.WriteLine("密码已破解，为：{0}，耗时{1}毫秒", key, watch.ElapsedMilliseconds);
    //    }
    //    static string GetMd5Hash(string input)
    //    {
    //        //using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
    //        //{
    //        //    return BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(input))).Replace("-", "");
    //        //}
    //        string hashKey = "Aa1@#$,.Klj+{>.45oP";
    //        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
    //        {
    //            string hashCode = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(input))).Replace("-", "") +
    //                BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(hashKey))).Replace("-", "");
    //            return BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(hashCode))).Replace("-", "");
    //        }
    //    }
    //    static bool VerifyMd5Hash(string input, string hash)
    //    {
    //        string hashOfInput = GetMd5Hash(input);
    //        StringComparer comparer = StringComparer.OrdinalIgnoreCase;
    //        return comparer.Compare(hashOfInput, hash) == 0 ? true : false;
    //    }
    //}
    #endregion

    #region 115 通过HASH来验证文件是否被篡改
    //class Program
    //{
    //    static void Main()
    //    {
    //        string fileHash = GetFileHash(@"C:\temp.txt");
    //        Console.WriteLine("文件MD5-HASH值为：{0}", fileHash);
    //    }
    //    public static string GetFileHash(string filePath)
    //    {
    //        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
    //        {
    //            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
    //            {
    //                return BitConverter.ToString(md5.ComputeHash(fs)).Replace("-", "");
    //            }
    //        }
    //    }
    //}
    #endregion

    #endregion
}