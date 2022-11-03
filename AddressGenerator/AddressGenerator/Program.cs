using NBitcoin;

Console.WriteLine("Give me your xpub and press ENTER.");
var extPubKeyText = Console.ReadLine();
var extPubKey = ExtPubKey.Parse(extPubKeyText!, Network.Main);

const int defaultCount = 10000;
Console.WriteLine($"How many keys? default is {defaultCount} just press ENTER to use that.");
var countText = Console.ReadLine();

var count = string.IsNullOrEmpty(countText)? defaultCount : int.Parse(countText);

Console.WriteLine($"Enter output file name or file path and press ENTER.");
var filepathText = Console.ReadLine();

List<string> addresses = new();
for (int i = 0; i < count; i++)
{
    var script = extPubKey.Derive(0, false).Derive(i, false).PubKey.WitHash.ScriptPubKey;
    addresses.Add(script.GetDestinationAddress(Network.Main).ToString());
}

FileInfo fileInfo = new (filepathText!);
File.WriteAllLines(fileInfo.FullName, addresses);

Console.WriteLine($"Your file is here {fileInfo.FullName} - press ENTER.");
Console.ReadLine();




