using System.Reflection;

namespace ReflectionTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type userType = typeof(User);
            object userInstance = Activator.CreateInstance(userType);

           
            FieldInfo idField = userType.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo nameField = userType.GetField("name", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo surnameField = userType.GetField("surname", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo ageField = userType.GetField("age", BindingFlags.NonPublic | BindingFlags.Static);

            idField.SetValue(userInstance, 1);
            nameField.SetValue(userInstance, "Nigar");
            surnameField.SetValue(userInstance, "Asadzade");
            ageField.SetValue(null, 21); 

            
            Console.WriteLine("ID: " + idField.GetValue(userInstance));
            Console.WriteLine("Name: " + nameField.GetValue(userInstance));
            Console.WriteLine("Surname: " + surnameField.GetValue(userInstance));
            Console.WriteLine("Age: " + ageField.GetValue(null));


            MethodInfo getFullNameMethod = userType.GetMethod("GetFullName", BindingFlags.Public | BindingFlags.Instance);
            getFullNameMethod.Invoke(userInstance, null);
        }
    }
}
