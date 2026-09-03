using ProductListManager;

List<string> products = [];

Display.ShowMenu();

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

Display.ShowSortedProductList(products);

Console.Write("Press <Enter> to continue...");
Console.ReadLine();
