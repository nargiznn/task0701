using System;

namespace task0701
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello !");
            string[] products = { "Nestle", "Bounty", "Snickers", "Kinder", "Milka", "Adicto", "KitKat" };
            string opt;
            do
            {
                Console.WriteLine("1.Bütün məhsullara bax");
                Console.WriteLine("2. Seçilmiç məhsula bax (index dəyərinə görə)");
                Console.WriteLine("3. Yeni məhsul əlavə et");
                Console.WriteLine("4. Məhsul adını dəyiş");
                Console.WriteLine("5. Seçilmiş məhsulu sil (id dəyərinə görə)");
                Console.WriteLine("0. Çıx");

              

                Console.WriteLine("Əməliyyatı seçin!");
                opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        Console.WriteLine("\n\n========= Products =========");
                        ShowAllProducts(products);
                        break;
                    case "2":
                        Console.WriteLine("\n\nIndex daxil edin!");
                        string indexStr = Console.ReadLine();
                        try
                        {
                            int index = Convert.ToInt32(indexStr);
                            Console.WriteLine($"product: {products[index]} ");
                        }
                        catch
                        {
                            Console.WriteLine("Xəta baş verdi!");
                        }
                        break;
                    case "3":
                        Console.WriteLine("\n========= Yeni Product =========");
                        Console.Write("Product: ");
                        string product = Console.ReadLine();
                         
                        AddProduct(ref products, product);

                        break;
                    case "4":
                        bool hasProblem;
                        Console.WriteLine("\n=========== Məhsullar ==========");
                        ShowAllProducts(products);
                        do
                        {
                            hasProblem = false;
                            try
                            {
                                EditProduct(products);
                            }
                            catch
                            {
                                Console.WriteLine("Xeta bas verdi!");
                                hasProblem = true;
                            }
                        }
                        while (hasProblem);
                        break;
                    case "5":
                        Console.WriteLine("\n========= Məhsul Sil =========");
                        Console.Write("Məhsulun indexsini daxil edin: ");
                        string indexStrDelete = Console.ReadLine();
                        int indexDelete = Convert.ToInt32(indexStrDelete);
                        if(indexDelete>=0 && indexDelete<products.Length)
                        {
                            DeleteProduct(ref products, indexDelete);
                        }
                        else
                        {
                            Console.WriteLine("Düzgün index daxil edin");
                        }
                       break;

                    default:
                        Console.WriteLine("Yanlış əməliyyat!");
                        break;


                }
            } while (opt != "0");
            Console.WriteLine("Əməliyyat bitdi");
            

        }
        static void ShowAllProducts(string[] arr)
        {
            for(int i=0;i<arr.Length;i++)
                Console.WriteLine($"{i}.{arr[i]}");

        }
        static void AddProduct(ref string[] arr,string newproduct)
        {  
            string[] newArr = new string[arr.Length + 1];
            if (newproduct.Length < 2 || newproduct.Length > 20)
            {
                Console.WriteLine("Məhsul adı minimum 2  max 20 uzunluqda olmalıdır!");
                return;
            }

            
            if (Array.IndexOf(arr, newproduct) != -1)
            {
                Console.WriteLine("Eyni adlı məhsul sistemə ikinci dəfə əlavə oluna bilm");
                return;
            }


            else
            {
                for (int i = 0; i < arr.Length; i++)
                {

                    newArr[i] = arr[i];


                }
            }
            
            newArr[newArr.Length - 1] = newproduct;
            arr = newArr;
           
               


        }

        static void EditProduct(string[] product)
        {
            Console.WriteLine("Məhsulu seçin: ");
            string indexStr = Console.ReadLine();
            int index = Convert.ToInt32(indexStr);
            Console.WriteLine("Yeni məhsul daxil edin: ");
            product[index] = Console.ReadLine();  
        }
       static void DeleteProduct(ref string[] arr , int index)
        {
            string[] newArr = new string[arr.Length - 1];
            for (int i = 0, j = 0; i < arr.Length; i++)
            {
                if (i != index)
                {
                    newArr[j] = arr[i];
                    j++;
                }
            }
            arr = newArr;


        }


    }
}

