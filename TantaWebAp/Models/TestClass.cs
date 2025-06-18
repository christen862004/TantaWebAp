namespace TantaWebAp.Models
{
    interface ISort
    {
        void SortArr(int[] arr);
    }

    class BubbleSort:ISort
    {
        public void SortArr(int[] arr)
        {
            //using Bubble Sort Alg
        }
    }
    class SelectionSort:ISort
    {
        public void SortArr(int[] arr)
        {
            //using Bubble Sort Alg
        }
    }

    class ChirsSort : ISort
    {
        public void SortArr(int[] arr)
        {
            
        }
    }

    //depenency 
    //DIP : Dont High Level Class based on Low level Class ,high level based absarction ,interface
    //IOC : dont make classes "Tigh Couple" ,design lossly couple 
    class MyList //High Level
    {
        int[] arr;
        ISort bSort;//any class implement this interface
        public MyList(ISort sortAlg) //design pattern (dependcy Injection)
        {
            arr = new int[10];
            bSort = sortAlg;//dont create  ,ask  (injection)
        }
        public void Sort()//(ISort sortAlg)
        {
            bSort.SortArr(arr);//Bubble
        }
    }









    class MyController
    {
        private object _viewdata;

        public object ViewData
        {
            get { return _viewdata; }
            set { _viewdata = value; }
        }
        
        public dynamic ViewBag
        {
            get { return _viewdata; }
            set { _viewdata = value; }
        }
    }

    public class Parent<T>
    {
        public T Info { get; set; }
    }

    public class Child1 : Parent<string> //close Type
    {   }

    public class Child2<T> : Parent<T> { }
     
    public class TestClass
    {
        public int Add(int x,int y)
        {
            return x + y;
        }
     
        public void Cal()
        {
            MyList list1 = new MyList(new BubbleSort());
            MyList list2 = new MyList(new SelectionSort());
            MyList list3 = new MyList(new ChirsSort());



            MyController contr1=new MyController();
            contr1.ViewData = new Student();
            Student std1 = (Student)contr1.ViewData;//manual unboxing
            int id = contr1.ViewBag.Id;





            Parent<int> obj = new Parent<int>();//close type 1)case 
            Child1 obj2 = new Child1();
            Child2<float> obj3 = new Child2<float>();
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            dynamic o1 = 1;
            dynamic o2 = "hello";
            dynamic o3 = new Student();
            int x = o3.Id;
            //dynamic ddetect type during runtime
            o3 = o2 + o1 + o3;

            int no1 = 10;
            int no2 = 20;
            Add(no1, no2);
        }
    }
}
