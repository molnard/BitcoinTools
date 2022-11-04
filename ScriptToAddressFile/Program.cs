using NBitcoin;

Console.WriteLine("Give me your file with scriptPubKey HEXes and press ENTER.");
var inputFilePath = Console.ReadLine();
FileInfo inputFileInfo = new (inputFilePath!);

FileInfo outputFileInfo = new(Path.ChangeExtension(inputFileInfo.FullName,"out"));

Console.WriteLine($"Your result file will be here: {outputFileInfo.FullName}");

List<string> addresses = new ();
foreach (var line in File.ReadAllLines(inputFileInfo.FullName))
{
    Script scriptPubKey = Script.FromHex(line.Trim());
    var address = scriptPubKey.GetDestinationAddress(Network.Main);
    addresses.Add(address.ToString());
}
File.WriteAllLines(outputFileInfo.FullName,addresses);
