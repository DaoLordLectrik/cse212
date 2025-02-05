using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // New set to copy the words being passed in
        var wordList = new HashSet<string>(words);
        // New set for all pairs
        var pairs = new HashSet<string>();
        // New set of all of words used so far
        var usedWords = new HashSet<string>();
        // Loops through words in array of words being passed
        foreach (string word in words)
        {
            // Defines variable "reverseWord" equal to reverse of word being focused on
            string reverseWord = string.Concat(word.Reverse());
            // If reverse word is in list and "usedWords" set doesn't already contain the pair, checks if the words and reverse word aren't the same
            if (wordList.Contains(reverseWord) && !usedWords.Contains(word) && word != reverseWord)
            {
                // If passed, added to the set
                pairs.Add($"{word} & {reverseWord}");
                // Add "reverseWord" to list of "usedWords"
                usedWords.Add(reverseWord);
            }
        }
        // Returns set at end
        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        // New dictionary called "degrees" to contain data
        var degrees = new Dictionary<string, int>();
        // Loop through each line of code
        foreach (var line in File.ReadLines(filename))
        {
            // Separate each line by a comma
            var fields = line.Split(",");
            // Set degree value to 1
            var degree = 1;
            // State degree from the data at index 3 or column #4
            var degreeType = fields[3];
            // If the degrees dictionary doesn't already contain degree type
            if (!degrees.ContainsKey(degreeType))
            {
                // Add degree type to dicationary, add number 1 for first entry
                degrees.Add(degreeType, degree);
            }
            
            else
            {
                // Else increase count of the degree by 1
                degrees[degreeType] += 1;
            }

        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var anagrams1 = new Dictionary<char, int>();
        var anagrams2 = new Dictionary<char, int>();
        foreach (char letter in word1)
        {
            char newChar1 = char.ToUpper(letter);
            if (char.IsWhiteSpace(newChar1))
            {
                continue;
            }
            if (!anagrams1.ContainsKey(newChar1))
            {
                anagrams1.Add(newChar1, 1);
            }
            else
            {
                anagrams1[newChar1] += 1;
            }
        }
        foreach (char letter in word2)
        {
            char newChar2 = char.ToUpper(letter);
            if (char.IsWhiteSpace(newChar2))
            {
                continue;
            }
            if (!anagrams2.ContainsKey(newChar2))
            {
                anagrams2.Add(newChar2, 1);
            }
            else
            {
                anagrams2[newChar2] += 1;
            }
        }
        return false;

        // TODO Problem 3 - ADD YOUR CODE HERE
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}