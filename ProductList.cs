namespace ProductListManager {
    public class ProductList {
        List<string> products = [];

        public ProductList() {
            LoadProducts();
        }
        private static string GetInput() {
            string? input = Console.ReadLine();
            input ??= "";  // Just to make my editor happy
            input = input.Trim().ToUpper();
            return input;
        }

        public void AddProduct() {
            while (true) {
                Console.WriteLine();
                Console.Write("Enter product (enter 'exit' to stop): ");
                string productName = GetInput();

                if (productName.Equals("EXIT")) {
                    break;
                }

                List<string> errors = Validation.ValidateInput(productName);

                if (errors.Count > 0) {
                    Display.ShowErrors(errors);
                }
                else {
                    if (this.products.Contains(productName)) {
                        Display.ShowWarning("Product already exists.");
                    }
                    else {
                        this.products.Add(productName);
                        Display.ShowSuccess("Product added successfully.");
                    }
                }
            }
        }

        public void DeleteProduct() {
            Console.WriteLine();
            Console.Write("Product name: ");
            string productName = GetInput();

            if (this.products.Contains(productName)) {
                this.products.Remove(productName);
                Display.ShowSuccess("Product removed successfully.");
            }
            else {
                Display.ShowWarning("That product doesn't exist.");
            }
        }

        public void ListProducts() {
            Display.ShowProductListSorted(this.products, "Products");
        }

        public void SearchProduct() {
            Console.WriteLine();
            Console.Write("Search product: ");
            string query = GetInput();
            List<string> result = products.FindAll(s => s.Contains(query));
            Display.ShowProductListSorted(result, "Results");
        }

        public void LoadProducts() {
            try {
                this.products = File.ReadAllLines("ProductList.txt").ToList();
            }
            catch {
                Console.WriteLine("No product file found.");
                Console.WriteLine();
            }
        }

        private void SaveProducts() {
            File.WriteAllLines("ProductList.txt", this.products);
        }

        public void ShowStatistics() {
            List<int> productNumbers = [];

            foreach (string product in this.products) {
                string number = product.Split('-')[1];
                productNumbers.Add(int.Parse(number));
            }

            int nofProducts = this.products.Count;

            Console.WriteLine();
            Console.WriteLine("Statistics:");
            Console.WriteLine($"- Total Products: {nofProducts}");
            Console.WriteLine($"- Lowest Number: {productNumbers.Min()}");
            Console.WriteLine($"- Highest Number: {productNumbers.Max()}");
            Console.WriteLine($"- Average Number: {productNumbers.Sum() / nofProducts}");
        }

        public void ExitProgram() {
            Console.WriteLine("Saving products...");
            SaveProducts();
            Console.WriteLine("Application closed.");
            Environment.Exit(0);
        }

    }
}
