using Countries.Library;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Sweeft.Console;
using Sweeft.Console.Models;



#region დავალება 8

//8.მოცემულია Countries REST API ის მისამართი: https://restcountries.com/v3.1/all, რომელიც აბრუნებს ინფორმაციას ქვეყნების შესახებ.
//დაწერეთ ფუნქცია, რომელიც ყოველი ქვეყნისთვის შექმნის ტექსტურ დოკუმენტს (.txt) სახელად {ქვეყნის_სახელი.txt}.
//თითოეულ დოკუმენტში უნდა იყოს შევსებული ქვეყნის “region”, “subregion”, “latlng”, “area” და “population” ველები.

var rawCountries = await ReadAPI("https://restcountries.com/v3.1/all");
var countries = JsonConvert.DeserializeObject<List<Country>>(rawCountries);



//დირექტორიის შექმნა და ფაილების ჩაყრა, უმჯობესია ფაილის მისამართი არგუმენტად გადავცეთ მაგრამ არ შევცვალე მოცემული ფუნქცია და ისე დავტოვე როგორც იყო.
void GenerateCountryDataFiles(/*string directoryPath*/)
{
    foreach (var country in countries)
    {
        string path = "D:/Countries/";
        string fileName = $"{path}{country.Name.Common}.txt";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            sw.WriteLine(country);
        }
    }
    Console.WriteLine("Countries added into files");
}

//ქვეყნების API -ს წაკითხვა
async Task<string> ReadAPI(string apiUrl)
{
    string result = string.Empty;
    using (HttpClient httpClient = new())
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
    }

    return result;
}

#endregion



#region დავალება 7

//7.დაწერეთ აპლიკაცია EntityFramework-ის (Code-First) გამოყენებით დავალება 6-ის მოცემულობით. დაწერეთ ფუნქცია რომელიც დააბრუნებს ყველა მასწავლებელს,
//რომელიც ასწავლის მოსწავლეს, რომლის სახელია: „გიორგი“.
Teacher[] GetAllTeachersByStudent(string studentName)
{
    ApplicationDbContext context = new();
    var allTeachers = context.Teachers
        .Include(t => t.Pupils)
        .Where(t => t.Pupils.Any(p => p.FirstName == studentName))
        .ToArray();

    return allTeachers;
}

#endregion



#region დავალება 6
//6.დავალების სკრიპტი იხილეთ School.Sql ფაილში...
#endregion



#region დავალება 5
//5.გვაქვს n სართულიანი კიბე, ერთ მოქმედებაში შეგვიძლია ავიდეთ 1 ან 2 საფეხურით. დაწერეთ ფუნქცია რომელიც დაითვლის n სართულზე ასვლის ვარიანტების რაოდენობას.
int CountVariants(int stairCount)
{
    int variants = 0;

    bool oneWayVariant = false;
    bool twoWayVariant = true;

    while (stairCount != 0)
    {
        if (oneWayVariant)
        {
            stairCount--;
            variants++;
        }

        if (twoWayVariant)
        {
            stairCount -= 2;
            variants++;
        }
    }

    return variants;
}
#endregion




#region დავალება 4

//4.მოცემულია String რომელიც შედგება „(„ და „)“ ელემენტებისგან.დაწერეთ ფუნქცია რომელიც აბრუნებს ფრჩხილები არის თუ არა მათემატიკურად სწორად დასმული. მაგ: (()()) სწორი მიმდევრობაა,  ())() არასწორია
bool IsProperly(string sequence)
{
    Stack<char> stack = new Stack<char>();
    foreach (char c in sequence)
    {
        if (c == '(')
        {
            stack.Push(c);
        }
        else if (c == ')')
        {
            if (stack.Count == 0)
            {
                return false;
            }
            char lastElement = stack.Pop();
            if (lastElement != '(')
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    return stack.Count == 0;
}

#endregion



#region დავალება 3

//3 მოცემულია მასივი, რომელიც შედგება მთელი რიცხვებისგან. დაწერეთ ფუნქცია რომელსაც გადაეცემა ეს მასივი და აბრუნებს მინიმალურ მთელ რიცხვს, რომელიც 0-ზე მეტია და ამ მასივში არ შედის.
int NotContains(int[] array)
{
    HashSet<int> set = new(array.Where(x => x > 0));
    int result = 1;
    while (set.Contains(result))
    {
        result++;
    }
    return result;
}

#endregion


#region დავალება 2

//2.გვაქვს 1,5,10,20 და 50 თეთრიანი მონეტები. დაწერეთ ფუნქცია, რომელსაც გადაეცემა თანხა (თეთრებში) და აბრუნებს მონეტების მინიმალურ რაოდენობას, რომლითაც შეგვიძლია ეს თანხა დავახურდაოთ.
int MinSplit(int amount)
{
    int[] coins = { 50, 20, 10, 5, 1 };
    int count = 0;
    for (int i = 0; i < coins.Length; i++)
    {
        while (amount >= coins[i])
        {
            amount -= coins[i];
            count++;
        }
    }
    return count;
}

#endregion



#region დავალება 1

//1.დაწერეთ ფუნქცია, რომელსაც გადაეცემა ტექსტი  და აბრუნებს პალინდრომია თუ არა. (პალინდრომი არის ტექსტი რომელიც ერთნაირად იკითხება ორივე მხრიდან). 
bool IsPalindrome(string text)
{
    text = text.ToLower();

    int start = 0;
    int end = text.Length - 1;

    while (start < end)
    {
        while (!char.IsLetterOrDigit(text[start]) && start < end)
        {
            start++;
        }
        while (!char.IsLetterOrDigit(text[end]) && start < end)
        {
            end--;
        }

        if (text[start] != text[end])
        {
            return false;
        }

        start++;
        end--;
    }

    return true;
}

#endregion


