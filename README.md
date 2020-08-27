# Quark
Basic C# code for helpers and conversions between units

## Helpers

### Shield
This calss is useful to validate the input paramenters and throw if invalid inputs are received.

- **IsNull** - Checks if specified parameter is not null. Throws **ArgumentNullException**, if parameter is null.
- **IsOutofRange** - Checks if specified value is in limits. Throws **ArgumentOutOfRangeException**, if value is outside limits.
- **IsNan** - Checks if specified value is valid number. Throws **ArgumentException**, if value is NaN.
- **IsInValidNumber** - Checks if specified value is valid number. Throws **ArgumentException**, if value is NaN or Infinity.
- **IsCollectionEmpty** - Checks if Collection has values. Throws **ArgumentException**, if Collection is empty or  **ArgumentNullException** if collection is null.

```csharp
public void DoWork(Scheme selectedScheme, int age, double RateofInterest,List<Enquiries> questions)
{
	Shield.IsNull(SelectedScheme);
	Shield.IsOutofRange(age, 18, 60);
	Shield.IsInValidNumber(RateofInterest);
	Shield.IsCollectionEmpty(questions);

	// Your logic after inputs are validated
}
```

### StringExtensions

Extensions for string class.
- **LimitChars** - Limits the input string to the count. This is useful when limited number of characters are to be displayed.

```csharp
String longMessage = "This is a very long message.";
Console.WriteLine(longMessage.LimitChars(10);

Output:
This is...
```

- **GetDouble** - Gets the number (double) from string. Easy way to convert string to double.

```csharp
string stringNumber=Device.GetReading();
double value = stringNumber.GetDouble();
```
- **RemoveEmptyLineAtEnd** -  Removes the empty line at end from input string. Equvalent to Trimming the 

- **RemoveEmptyLinesAtEnd** - Removes the empty lines at end from input string.

### DoubleExtensions
- **LimitTo** - Limits number to boundaries.
- **HasValue** - Determines whether the number has value.
- **ToString** - Converts to string with required Decimal places
- **ToDisplayString** - Converts the numeric value of this instance to its equivalent string representation (takes care of NAN and Infinity).

### PathHelper
- **AppFilePath** - Gets the application directory path, Path from where application is launched.
- **CommonDocumentsPath** - Gets the Common Documents path.
- **DirectoryCopy** - Copies the Directories.
- **RandomFileName** -Gets a random folder name or file name.

### CharExtensions
- **ToUnicodeValue** - Returns the Unicode value of the character.
- **ToDisplayValue** -  Returns displayable value for a character.
- **ToUrlValue** - Returns the URL equivalent character.
