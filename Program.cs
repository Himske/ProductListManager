using ProductListManager;

static void AddProduct(List<string> products) {
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
            if (products.Contains(productName)) {
                Display.ShowWarning("Product already exists.");
            }
            else {
                products.Add(productName);
                Display.ShowSuccess("Product added successfully.");
            }
        }
    }
}

static void DeleteProduct(List<string> products) {
    Console.WriteLine();
    Console.Write("Product name: ");
    string productName = GetInput();

    if (products.Contains(productName)) {
        products.Remove(productName);
        Display.ShowSuccess("Product removed successfully.");
    } else {
        Display.ShowWarning("That product doesn't exist.");
    }
}

static string GetInput() {
    string? input = Console.ReadLine();
    input ??= "";  // Just to make my editor happy
    input = input.Trim().ToUpper();
    return input;
}

static void ListProducts(List<string> products) {
    Display.ShowProductListSorted(products, "Products");
}

static void SearchProduct(List<string> products) {
    List<string> result = [];
    Console.WriteLine();
    Console.Write("Search product: ");
    string query = GetInput();
    foreach (string product in products) {
        if (product.StartsWith(query)) {
            result.Add(product);
        }
    }
    Display.ShowProductListSorted(result, "Results");
}

static List<string> LoadProducts() {
    List<string> products = [];
    try {
        products = File.ReadAllLines("ProductList.txt").ToList();
    } catch {
        Console.WriteLine("No product file found.");
        Console.WriteLine();
    }
    
    return products;
}

static void SaveProducts(List<string> products) {
    File.WriteAllLines("ProductList.txt", products);
}

static void ExitProgram(List<string> products) {
    Console.WriteLine("Saving products...");
    SaveProducts(products);
    Console.WriteLine("Application closed.");
    Environment.Exit(0);
}

static void ShowStatistics(List<string> products) {
    List<int> productNumbers = [];

    foreach (string product in products) {
        string number = product.Split('-')[1];
        productNumbers.Add(int.Parse(number));
    }

    int nofProducts = products.Count;

    Console.WriteLine();
    Console.WriteLine("Statistics:");
    Console.WriteLine($"- Total Products: {nofProducts}");
    Console.WriteLine($"- Lowest Number: {productNumbers.Min()}");
    Console.WriteLine($"- Highest Number: {productNumbers.Max()}");
    Console.WriteLine($"- Average Number: {productNumbers.Sum() / nofProducts}");
}


List<string> products = LoadProducts();

Display.ShowHeading();
Display.ShowMenu();

while (true) {
    Console.Write("Select option: ");
    string? option = Console.ReadLine();

    switch (option) {
        case "1":
            AddProduct(products);
            break;
        case "2":
            ListProducts(products);
            break;
        case "3":
            SearchProduct(products);
            break;
        case "4":
            DeleteProduct(products);
            break;
        case "5":
            ShowStatistics(products);
            break;
        case "6":
            ExitProgram(products);
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }

    Display.ShowOptionDivider();
}
