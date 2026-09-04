namespace ProductListManager {
    public static class Display {
        public static void ShowHeading() {
            Console.WriteLine("=====================================");
            Console.WriteLine("PRODUCT LIST MANAGER");
            Console.WriteLine("=====================================");
        }
        public static void ShowMenu() {
            Console.WriteLine();
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Search Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Statistics");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
        }

        public static void ShowProductListSorted(List<string> products, string heading) {
            products.Sort();

            Console.WriteLine();
            Console.WriteLine($"{heading}:");
            foreach (string product in products) {
                Console.WriteLine($"- {product}");
            }
        }

        public static void ShowWarning(string message) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"WARNING! {message}");
            Console.ResetColor();
        }

        public static void ShowErrors(List<string> errors) {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (string error in errors) {
                Console.WriteLine(error);
            }
            Console.ResetColor();
        }

        public static void ShowSuccess(string message) {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void ShowOptionDivider() {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
        }
    }
}
