using ProductListManager;

static void AddProduct(List<string> products) {
    while (true) {
        Console.WriteLine();
        Console.Write("Enter product: ");
        string? productName = Console.ReadLine();

        productName ??= "";  // Just to make my editor happy

        if (productName.Trim().ToLower().Equals("exit")) {
            break;
        }

        productName = productName.ToUpper();

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

static void ListProducts(List<string> products) {
    Display.ShowProductListSorted(products);
}

List<string> products = [];

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
            break;
        case "4":
            break;
        case "5":
            break;
        case "6":
            Console.WriteLine("Saving products...");
            // Save products to file
            Console.WriteLine("Application closed.");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }

    Display.ShowOptionDivider();
}
