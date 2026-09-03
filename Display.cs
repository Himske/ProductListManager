namespace ProductListManager {
    public static class Display {
        public static void ShowMenu() {
            Console.WriteLine("=====================================");
            Console.WriteLine("PRODUCT LIST MANAGER");
            Console.WriteLine("=====================================");
            Console.WriteLine();
            Console.WriteLine("Enter product names. (LETTERS-NUMBER)");
            Console.WriteLine();
            Console.WriteLine("Type 'exit' to finish.");
            Console.WriteLine();
        }

        public static void ShowSortedProductList(List<string> products) {
            products.Sort();

            Console.WriteLine();
            Console.WriteLine("Sorted product list:");
            Console.WriteLine();
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
    }
}
