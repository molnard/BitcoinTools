using NBitcoin;

Console.WriteLine("Give me your scriptPubKey and press ENTER.");
var scriptPubKeyText = Console.ReadLine();
Script scriptPubKey = new (scriptPubKeyText);

Console.WriteLine($"Here is your address - press ENTER.");
var address = scriptPubKey.GetDestinationAddress(Network.Main);
Console.WriteLine(address.ToString());
Console.ReadLine();
