namespace TantaWebAp.Models
{
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
