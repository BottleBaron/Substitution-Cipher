

char[] alphabet = new char[26]{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
string input;
string cipherKey;

// Gets the input to encrypt from the user
// Validates that it is only alphabetic and no numbers                     
while (true)
{
    Console.Clear();

    Console.WriteLine("Please enter the word you wish to encrypt. Use only alphabetic letters.");
    input = Console.ReadLine().ToLower();

    // If there are no integers => If the input is not empty or null => If the input only contains letters from the english alphabet 
    if(!input.Any(char.IsDigit) && !string.IsNullOrEmpty(input) && IsAlphabetic(input))
    {
      
        Console.WriteLine("Input Validated. Press any key to proceed...");
        Console.ReadKey();
        break;
    }
    else
        Console.WriteLine("Incorrect input");

    Console.ReadKey();
}


// Gets the key for encryption from the user
// Validates that it is only alphabetic and 26 in length
while (true)
{
    Console.Clear();

    Console.WriteLine("Please enter a 26 letter key for encryption. Use only alphabetic letters");
    cipherKey = Console.ReadLine().ToLower();

    if(!cipherKey.Any(char.IsDigit) && !string.IsNullOrEmpty(cipherKey) && IsAlphabetic(cipherKey))
    {
        if(cipherKey.Length == alphabet.Length)
        {
            Console.WriteLine("Input Validated. Press any key to encrypt your message...");
            Console.ReadKey();

            Console.WriteLine(input + "\n" + cipherKey + "\n" + Encrypt(input, cipherKey));
            Console.ReadKey();
            break;
        }
        else
            Console.WriteLine("Your input was not 26 letters long");
    }   
    else
        Console.WriteLine("Incorrect input");
    
    Console.ReadKey();
}


// Checks every letter of the input against the alphabet
// Returns true if all letters have a correspondent in the alphabet
bool IsAlphabetic(string input)
{
    int validationPoints = 0;

    foreach (char letter in input)
    {
        foreach (char letters in alphabet)
        {
            if(letter == letters)
            {
                validationPoints++;
                break;
            }
        }
    }


    if(validationPoints == input.Length)
        return true;
    else
        return false;  
}

// Compares each letter of the input to the alphabet
// If a letter matches the alphabet encryptedString is added with that letters corresponding key index
string Encrypt(string input, string cipherKey)
{
    string encryptedString = "";
    
    foreach (char letter in input)
    {
        for (int i = 0; i < alphabet.Length; i++)
        {
            if(letter == alphabet[i])
            {
                encryptedString += cipherKey[i];
            }
        }
    }

    return encryptedString;
}