using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductListManager
{
    public static class Validation
    {
        private static bool HasOnlyOneDash(string input, out string error) {
            string[] inputParts = input.Split('-');
            if (inputParts.Length == 1) {
                error = "Product must contain a dash (-).";
                return false;
            }

            if (inputParts.Length > 2) {
                error = "Product can't have more than 1 dash (-).";
                return false;
            }
            error = "";
            return true;
        }

        private static bool HasOnlyUppercaseCharacters(string input, out string error) {
            foreach (char c in input) {
                if (c < 'A' || c > 'Z') {
                    error ="The left side must contain letters only (A-Z).";
                    return false;
                }
            }
            error = "";
            return true;
        }

        private static bool IsValidNumber(string input, out string error) {
            if (int.TryParse(input, out int number)) {
                if (number < 200 || number > 500) {
                    error = "The numeric part must be between 200 and 500.";
                    return false;
                }
            }
            else {
                error = "The right side must contain number only.";
                return false;
            }
            error = "";
            return true;
        }
        public static List<string> ValidateInput(string input)
        {
            List<string> errors = [];

            if (string.IsNullOrEmpty(input)) {
                errors.Add("Input can't be empty!");
                return errors;
            }

            if (!HasOnlyOneDash(input, out string error)) {
                errors.Add(error);
                return errors;
            }

            string[] inputParts = input.Split('-');

            if (!string.IsNullOrEmpty(inputParts[0])) {
                if (!HasOnlyUppercaseCharacters(inputParts[0], out error)) {
                    errors.Add(error);
                }
            }
            else {
                errors.Add("The left side can't be empty.");
            }

            if (!string.IsNullOrEmpty(inputParts[1])) {
                if (!IsValidNumber(inputParts[1], out error)) {
                    errors.Add(error);
                }
            }
            else {
                errors.Add("The right side can't be empty.");
            }

            return errors;
        }
    }
}
