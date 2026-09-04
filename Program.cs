using ProductListManager;

ProductList products = new();

Display.ShowHeading();
Display.ShowMenu();

while (true) {
    Console.Write("Select option: ");
    string? option = Console.ReadLine();

    switch (option) {
        case "1":
            products.AddProduct();
            break;
        case "2":
            products.ListProducts();
            break;
        case "3":
            products.SearchProduct();
            break;
        case "4":
            products.DeleteProduct();
            break;
        case "5":
            products.ShowStatistics();
            break;
        case "6":
            products.ExitProgram();
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }

    Display.ShowOptionDivider();
}
