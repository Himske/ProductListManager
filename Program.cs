using ProductListManager;

List<string> products = [];

Console.WriteLine("-------------------------------------");
Console.WriteLine("PRODUCT LIST MANAGER");
Console.WriteLine("-------------------------------------");
Console.WriteLine();
Console.WriteLine("Enter product names. (LETTERS-NUMBER)");
Console.WriteLine();
Console.WriteLine("Type 'exit' to finish.");
Console.WriteLine();

while (true) {
    Console.Write("Product: ");
    string? productName = Console.ReadLine();

    productName ??= "";  // Just to make my editor happy

    if (productName.Trim().ToLower().Equals("exit")) {
        break;
    }

    productName = productName.ToUpper();

    List<string>  errors = Validation.ValidateInput(productName);

    if (errors.Count > 0) {
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (string error in errors) {
            Console.WriteLine(error);
        }
    }
    else {
        if (products.Count == 0) {
            products.Add(productName);
        }
        else {
            foreach (string product in products) {
                if (string.Equals(productName, product)) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("WARNING! Product already exists.");
                }
                else {
                    products.Add(productName);
                }
            }
        }
    }

    Console.ResetColor();
}

products.Sort();

Console.WriteLine();
Console.WriteLine("Sorted product list:");
Console.WriteLine();
foreach (string product in products) {
    Console.WriteLine($"- {product}");
}

Console.Write("Press <Enter> to continue...");
Console.ReadLine();
