namespace BlazorMatchGame.Helpers;

public class AnimalHelper
{
    private static Random _random = new();

    public static List<string> GetAnimals()
    {
        List<string> animals = new()
        {
            "🦑","👻","🐖","👽","🦥","🦄","🐳","🦉",
            "🆗", "😀", "💀", "💩", "🙈", "🙉", "🙊", 
            "🐵", "🐶", "🐷", "🐮", "🐯", "🦁", "🐨", 
            "🐙", "🐣", "🐥", "🐦", "🐤", "🐣", "🐔", 
            "🐧", "🐢", "🐛", "🐝", "🐜", "🐞", "🐌",
            "🐠", "🐡", "🐌", "🐬", "🐭", "🐮",
            "🐯", "🐰", "🐱", "🐲", "🐳", "🐴", "🐵", 
            "🐶", "🐷", "🐸", "🐹", "🐺", "🐻", "🐼",
            "🐽", "🐾", "🐿", "👀", "👂", "👃", "👄",
            "👅", "👆", "👇", "👈", "👉", "👊", "👋", 
            "👌", "👍", "👎", "👏", "👐", "👑", "👒", 
            "👓", "👔", "👕", "👖", "👗", "👘", "👙", 
            "👚", "👛", "👜", "👝", "👞", "👟", "👠", 
            "👡", "👢", "👣", "👤", "👥", "👦", "👧", 
            "👨", "👩", "👪", "👫", "👬", "👭", "👮", 
            "👯", "👰", "👱", "👲", "👳", "👴", "👵",
            "👶", "👷", "👸", "👹", "👺", "👻", "👼", 
            "👽", "👾"
        };

        List<string> output = new();
        
        for(int i = 0; i < 8; i++)
        {
            int index = _random.Next(animals.Count);
            output.Add(animals[index]);
            output.Add(animals[index]);
            animals.RemoveAt(index);
        }

        return output;
    }
}
