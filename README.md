# Quark
Basic C# code for helpers and conversions between units

## Helpers

### Shield
- **IsNull** - Checks if specified parameter is not null. Throws **ArgumentNullException**, if parameter is null.
- **IsOutofRange** - Checks if specified value is in limits. Throws **ArgumentOutOfRangeException**, if value is outside limits.
- **IsNan** - Checks if specified value is valid number. Throws **ArgumentException**, if value is NaN.
- **IsInValidNumber** - Checks if specified value is valid number. Throws **ArgumentException**, if value is NaN or Infinity.
- **IsCollectionEmpty** - Checks if Collection has values. Throws **ArgumentException**, if Collection is empty or  **ArgumentNullException** if collection is null.

### StringExtensions
- **LimitChars** - Limits the input string to the count.
- **GetDouble** - Gets the double from string

### DoubleExtensions
- **LimitTo** - Limits number to boundaries
- **HasValue** - Determines whether the number has value.