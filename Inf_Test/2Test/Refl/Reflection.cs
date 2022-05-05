using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Inf_Test._2Test.Refl
{
    public class Reflection
    {
        public void Run()
        {
            Type myType = typeof(Sourse);
            Type[] parameters = new Type[] { typeof(int) };
            object[] values = new object[] { 8 };
            object object1 = myType.GetConstructor(parameters).Invoke(values);

            //получим все методы типа
            MethodInfo[] allPublicMethods = myType.GetMethods();

            //вызов void StaticMethod()
            MethodInfo publicMethod = myType.GetMethod("StaticMethod");
            publicMethod.Invoke(object1, null);

            // публичное поле
            FieldInfo[] allPublicFields = myType.GetFields();
            FieldInfo publicField = myType.GetField("PublicField");
            publicField.SetValue(object1, 88);
            object object2 = publicField.GetValue(object1);
            Console.WriteLine((int)object2);

            // приватное поле
            FieldInfo privateField = myType.GetField("PrivateField", BindingFlags.Instance | BindingFlags.NonPublic);
            privateField.SetValue(object1, 888);
            object object3 = privateField.GetValue(object1);
            Console.WriteLine((int)object3);
        }
    }
}
